using MasterDetailWASM.Server.DAL;
using MasterDetailWASM.Shared.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MasterDetailWASM.Server.Repositories.VentaRepositorys
{
    public class VentaRepository : IVentaRepository
    {
        private Contexto _contexto;

        public VentaRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Exists(int id)
        {
            return await _contexto.Ventas.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> Insert(Venta venta)
        {
            InsertDetail(venta);
            await _contexto.Ventas.AddAsync(venta);
            bool salida = await _contexto.SaveChangesAsync() > 0;
            _contexto.Entry(venta).State = EntityState.Detached;
            return salida;
        }

        private async Task InsertDetail(Venta venta)
        {
            if (venta.DetalleVentas != null)
            {
                foreach (var item in venta.DetalleVentas)
                {
                    var producto = await _contexto.Productos.FindAsync(item.ProductoId);


                    if (producto != null)
                    {
                        producto.Existencia -= item.Cantidad;
                        _contexto.Productos.Update(producto);

                    }
                }
            }
        }

        public async Task<bool> Delete(int id)
        {
            var eliminado = await _contexto.Ventas.Include(o => o.DetalleVentas).SingleOrDefaultAsync(o => o.Id == id);

            if (eliminado != null)
            {
                foreach (var item in eliminado.DetalleVentas)
                {
                    var producto = await _contexto.Productos.FindAsync(item.ProductoId);

                    if (producto != null)
                    {
                        producto.Existencia += item.Cantidad;
                        _contexto.Productos.Update(producto);
                    }
                }

                _contexto.Ventas.Remove(eliminado);
                bool salida = await _contexto.SaveChangesAsync() >= 0;
                _contexto.Entry(eliminado).State = EntityState.Detached;
                return salida;
            }

            return false;
        }

        public async Task<bool> Update(Venta venta)
        {
            var DetalleAnterior = await _contexto.Ventas.Include(o => o.DetalleVentas).AsNoTracking().SingleOrDefaultAsync(o => o.Id == venta.Id);

            if (DetalleAnterior != null)
            {
                foreach (var item in DetalleAnterior.DetalleVentas)
                {
                    var producto = await _contexto.Productos.FindAsync(item.ProductoId);

                    if (producto != null)
                    {
                        producto.Existencia += item.Cantidad;
                        _contexto.Productos.Update(producto);
                    }
                }

                _contexto.Database.ExecuteSqlRaw($"DELETE FROM DetalleVenta WHERE VentaId={venta.Id};");


                foreach (var item in venta.DetalleVentas)
                {
                    var producto = await _contexto.Productos.FindAsync(item.ProductoId);

                    if (producto != null)
                    {
                        producto.Existencia -= item.Cantidad;
                        _contexto.Add(item);
                        _contexto.Productos.Update(producto);
                    }
                }
            }

            _contexto.Ventas.Update(venta);
            bool salida = await _contexto.SaveChangesAsync() > 0;
            _contexto.Entry(venta).State = EntityState.Detached;
            return salida;
        }

        public async Task<Venta> Search(int id)
        {
            return await _contexto.Ventas.Include("DetalleVentas").FirstAsync(x => x.Id == id);
        }

        public async Task<List<Venta>> GetList(Expression<Func<Venta, bool>> criterio)
        {
            return _contexto.Ventas.AsNoTracking().Where(criterio).ToList();
        }
    }
}
