using MasterDetailWASM.Shared.Models;

namespace MasterDetailWASM.Client.Services.VentaServices
{
    public interface IVentaService
    {
        Task<bool> Save(Venta venta);
        Task<bool> Delete(int id);
        List<Venta> ListaVentas { get; set; }
        Task<List<Venta>> GetList();
        Task<Venta> Search(int id);
    }
}
