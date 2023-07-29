using MasterDetailWASM.Shared.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace MasterDetailWASM.Client.Services.VentaServices
{
    public class VentaService : IVentaService
    {
        private readonly HttpClient _httpClient;
        public VentaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Venta> ListaVentas { get; set; } = new List<Venta>();

        public async Task<bool> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/venta/{id}");
                return true;
            }
            catch (HttpRequestException)
            {

                return false;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<List<Venta>> GetList()
        {
            return await _httpClient.GetFromJsonAsync<List<Venta>>($"api/Venta");
        }

        public async Task<bool> Save(Venta venta)
        {
            try
            {
                if (venta.Id == 0)
                {
                    var response = await _httpClient.PostAsJsonAsync<Venta>($"api/Venta", venta);
                    response.EnsureSuccessStatusCode();
                }
                else
                {
                    var response = await _httpClient.PutAsJsonAsync<Venta>($"api/Venta", venta);
                    response.EnsureSuccessStatusCode();
                }

                return true;
            }
            catch (HttpRequestException)
            {
                
                return false; 
            }
            catch (Exception)
            {
                
                return false; 
            }
        }

        public async Task<Venta> Search(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Venta>($"api/Venta/{id}");

            return response;
        }
    }
}
