using FederaProDesktop.Karting.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
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
        public async Task CrearPilotoAsync(KartingPiloto piloto)
        {
            var response = await httpClient.PostAsJsonAsync("karting/pilotos", piloto);
            response.EnsureSuccessStatusCode();
        }

        public async Task ActualizarPilotoAsync(KartingPiloto piloto)
        {
            if (piloto.Id == 0)
                throw new ArgumentException("El ID del piloto es requerido para la actualización.");

            var response = await httpClient.PutAsJsonAsync($"karting/pilotos/{piloto.Id}", piloto);
            response.EnsureSuccessStatusCode();
        }

        public async Task EliminarPilotoAsync(int pilotoId)
        {
            var response = await httpClient.DeleteAsync($"karting/pilotos/{pilotoId}");
            response.EnsureSuccessStatusCode();
        }
        public async Task<List<KartingPiloto>> ObtenerPilotosPorCompeticionAsync(string nombreCompeticion)
        {
            var url = $"karting/pilotos/competicion/{Uri.EscapeDataString(nombreCompeticion)}";
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new List<KartingPiloto>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<KartingPiloto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
