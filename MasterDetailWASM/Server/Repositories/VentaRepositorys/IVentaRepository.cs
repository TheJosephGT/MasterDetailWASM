using MasterDetailWASM.Shared.Models;
using System.Linq.Expressions;

namespace MasterDetailWASM.Server.Repositories.VentaRepositorys
{
    public interface IVentaRepository
    {
        Task<bool> Exists(int id);
        Task<bool> Insert(Venta venta);
        Task<bool> Update(Venta venta);
        Task<bool> Delete(int id);
        Task<Venta> Search(int id);
        Task<List<Venta>> GetList(Expression<Func<Venta, bool>> criterio);
    }
}
