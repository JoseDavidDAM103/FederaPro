using FederaProDesktop.Karting.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FederaProDesktop.Karting.Servicios
{
    public class KartingCompeticionApiService
    {
        private readonly HttpClient httpClient;

        public KartingCompeticionApiService()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/karting/competiciones/")
            };
        }

        public async Task<List<KartingCompeticion>> ObtenerCompeticionesAsync()
        {
            var response = await httpClient.GetAsync("");
            if (!response.IsSuccessStatusCode) return new List<KartingCompeticion>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<KartingCompeticion>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<KartingCompeticion> ObtenerCompeticionPorIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<KartingCompeticion>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<KartingCompeticion> CrearCompeticionAsync(KartingCompeticion nueva)
        {
            var json = JsonSerializer.Serialize(nueva);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("", content);
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<KartingCompeticion>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<KartingCompeticion> ActualizarCompeticionAsync(int id, KartingCompeticion actualizada)
        {
            var json = JsonSerializer.Serialize(actualizada);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{id}", content);
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<KartingCompeticion>(responseJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> EliminarCompeticionAsync(int id)
        {
            var response = await httpClient.DeleteAsync($"{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<KartingClasificacionPilotoDTO>> ObtenerClasificacionPilotosAsync(string nombreCompeticion)
        {
            var response = await httpClient.GetAsync($"karting/competiciones/{nombreCompeticion}/clasificacion/pilotos");
            if (!response.IsSuccessStatusCode)
                return new List<KartingClasificacionPilotoDTO>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<KartingClasificacionPilotoDTO>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<List<KartingClasificacionEquipoDTO>> ObtenerClasificacionEquiposAsync(string nombreCompeticion)
        {
            var response = await httpClient.GetAsync($"karting/competiciones/{nombreCompeticion}/clasificacion/equipos");
            if (!response.IsSuccessStatusCode)
                return new List<KartingClasificacionEquipoDTO>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<KartingClasificacionEquipoDTO>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<List<KartingCarreraDTO>> ObtenerCarrerasDeCompeticionAsync(string nombreCompeticion)
        {
            var url = $"karting/competiciones/{nombreCompeticion}/carreras";

            var response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return new List<KartingCarreraDTO>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<KartingCarreraDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
