using MasterDetailWASM.Server.DAL;
using MasterDetailWASM.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MasterDetailWASM.Server.Repositories.ClienteRepositorys
{
    public class ClienteRepository : IClienteRepository
    {
        private Contexto contexto;
        public ClienteRepository(Contexto _contexto)
        {
            contexto = _contexto;
        }

        public async Task<Cliente> Search(int id)
        {
            return await contexto.Clientes.FindAsync(id);
        }

        public async Task<List<Cliente>> GetList(Expression<Func<Cliente, bool>> criterio)
        {
            return contexto.Clientes.AsNoTracking().Where(criterio).ToList();
        }
    }
}
