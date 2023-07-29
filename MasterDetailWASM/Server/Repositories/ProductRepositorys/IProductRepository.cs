using MasterDetailWASM.Shared.Models;
using System.Linq.Expressions;

namespace MasterDetailWASM.Server.Repositories.ProductRepository.ProductRepository
{
    public interface IProductRepository
    {
        Task<Producto> Search(int id);
        Task<List<Producto>> GetList(Expression<Func<Producto, bool>> criterio);
    }
}
