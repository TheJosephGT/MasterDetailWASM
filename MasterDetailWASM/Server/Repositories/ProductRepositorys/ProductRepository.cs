using MasterDetailWASM.Client.Services;
using MasterDetailWASM.Server.DAL;
using MasterDetailWASM.Server.Repositories.ProductRepository.ProductRepository;
using MasterDetailWASM.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MasterDetailWASM.Server.Repositories.ProductRepository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private Contexto contexto;

        public ProductRepository(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<Producto> Search(int id)
        {
            return await contexto.Productos.FindAsync(id);
        }

        public async Task<List<Producto>> GetList(Expression<Func<Producto, bool>> criterio)
        {
            return contexto.Productos.AsNoTracking().Where(criterio).ToList();
        }
    }
}
