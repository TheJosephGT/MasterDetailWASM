using MasterDetailWASM.Shared.Models;
using System.Linq.Expressions;

namespace MasterDetailWASM.Server.Repositories.ClienteRepositorys
{
    public interface IClienteRepository
    {
        Task<Cliente> Search(int id);
        Task<List<Cliente>> GetList(Expression<Func<Cliente, bool>> criterio);
    }
}
