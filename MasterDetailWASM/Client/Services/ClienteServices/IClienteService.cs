using MasterDetailWASM.Shared.Models;

namespace MasterDetailWASM.Client.Services.ClienteServices
{
    public interface IClienteService
    {
        Task<Cliente> Search(int id);
        Task<List<Cliente>> GetList();
    }
}
