using FederaProDesktop.Modelos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FederaProDesktop.Servicios.Api
{
    internal class BasketCompeticionApi
    {

        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:8080/basket/competiciones";

        public BasketCompeticionApi()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<BasketCompeticionDTO>> GetCompeticionesAsync()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<BasketCompeticionDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<object> CrearCompeticionAsync(CrearCompeticionDTO competicion)
        {
            var json = JsonSerializer.Serialize(competicion, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(BaseUrl, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task GenerarPartidosAsync(string nombreCompeticion)
        {
            var url = $"{BaseUrl}/{Uri.EscapeDataString(nombreCompeticion)}/generar-partidos";
            var response = await _httpClient.PostAsync(url, null);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<PartidoDTO>> GetPartidosDeCompeticionAsync(string nombreCompeticion)
        {
            var url = $"http://localhost:8080/basket/partidos/competicion/{Uri.EscapeDataString(nombreCompeticion)}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<PartidoDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        public async Task<List<ClasificacionEquipoDTO>> ObtenerClasificacionAsync(string nombreCompeticion)
        {
            var response = await _httpClient.GetAsync($"http://localhost:8080/basket/competiciones/clasificacion/{nombreCompeticion}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ClasificacionEquipoDTO>>();
        }
    }
}
