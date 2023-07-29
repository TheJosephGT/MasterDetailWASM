using MasterDetailWASM.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace MasterDetailWASM.Client.Services.ClienteServices
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _http;

        public ClienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Cliente>> GetList()
        {
            return await _http.GetFromJsonAsync<List<Cliente>>($"api/cliente");
        }

        public async Task<Cliente> Search(int id)
        {
            return await _http.GetFromJsonAsync<Cliente>($"api/cliente/{id}");
        }
    }
}
