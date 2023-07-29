using MasterDetailWASM.Shared.Models;

namespace MasterDetailWASM.Client.Services.ProductServices
{
    public interface IProductService
    {
        Task<Producto> Search(int id);
        Task<List<Producto>> GetList();
    }
}
