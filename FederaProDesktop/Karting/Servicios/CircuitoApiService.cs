using FederaProDesktop.Karting.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FederaProDesktop.Karting.Servicios
{
    public class CircuitoApiService
    {
        private readonly HttpClient _httpClient;

        public CircuitoApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/") // Ajusta si tu endpoint cambia
            };
        }

        public async Task<List<KartingCircuito>> ObtenerCircuitosAsync()
        {
            var response = await _httpClient.GetAsync("karting/circuitos");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<KartingCircuito>>();
            return new List<KartingCircuito>();
        }

        public async Task<KartingCircuito> ObtenerCircuitoPorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"karting/circuitos/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<KartingCircuito>();
            return null;
        }

        public async Task<bool> CrearCircuitoAsync(KartingCircuito circuito)
        {
            var response = await _httpClient.PostAsJsonAsync("karting/circuitos", circuito);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ActualizarCircuitoAsync(KartingCircuito circuito)
        {
            if (circuito.Id == 0) return false;
            var response = await _httpClient.PutAsJsonAsync($"karting/circuitos/{circuito.Id}", circuito);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarCircuitoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"karting/circuitos/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
