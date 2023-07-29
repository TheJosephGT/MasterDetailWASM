using MasterDetailWASM.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace MasterDetailWASM.Client.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Producto>> GetList()
        {
            return await _http.GetFromJsonAsync<List<Producto>>($"api/Product");
        }

        public async Task<Producto> Search(int id)
        {
            return await _http.GetFromJsonAsync<Producto>($"api/Product/{id}");
        }
    }
}
