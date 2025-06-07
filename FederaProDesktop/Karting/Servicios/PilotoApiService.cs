using FederaProDesktop.Karting.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FederaProDesktop.Karting.Servicios
{
    public class PilotoApiService
    {
        private readonly HttpClient httpClient;

        public PilotoApiService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri("http://localhost:8080/"); // Ajusta si tu endpoint cambia
        }

        public async Task<List<KartingPiloto>> ObtenerPilotosAsync()
        {
            var response = await httpClient.GetAsync("karting/pilotos");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<KartingPiloto>>();
            }

            return new List<KartingPiloto>();
        }
    }
}
