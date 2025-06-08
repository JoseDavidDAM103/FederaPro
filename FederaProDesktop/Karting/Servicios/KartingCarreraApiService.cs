using FederaProDesktop.Karting.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FederaProDesktop.Karting.Servicios
{
    public class KartingCarreraApiService
    {
        private readonly HttpClient httpClient;

        public KartingCarreraApiService()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/")
            };
        }

        public async Task CrearCarreraAsync(CrearKartingCarreraDto dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("karting/carreras", content);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear carrera: {(int)response.StatusCode} - {error}");
            }
        }

        public async Task<List<KartingCarreraDTO>> ObtenerCarrerasPorCompeticionAsync(string nombreCompeticion)
        {
            var response = await httpClient.GetAsync($"karting/competiciones/{nombreCompeticion}/carreras");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<KartingCarreraDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
