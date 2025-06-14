﻿using FederaProDesktop.Modelos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FederaProDesktop.Servicios.Api
{
    public class EquipoApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:8080/basket/equipos";

        public EquipoApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<BasketEquipoDTO>> GetEquiposAsync()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<BasketEquipoDTO>>();
        }

        public async Task<List<BasketEquipoDTO>> BuscarEquiposAsync(string nombre, string ciudad)
        {
            var parametros = new List<string>();

            if (!string.IsNullOrWhiteSpace(nombre))
                parametros.Add($"nombre={Uri.EscapeDataString(nombre)}");

            if (!string.IsNullOrWhiteSpace(ciudad))
                parametros.Add($"ciudad={Uri.EscapeDataString(ciudad)}");

            var query = $"{BaseUrl}/buscar";
            if (parametros.Count > 0)
                query += "?" + string.Join("&", parametros);

            var response = await _httpClient.GetAsync(query);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<BasketEquipoDTO>>();
        }

        public async Task<BasketEquipoDTO> GetEquipoPorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BasketEquipoDTO>();
        }

        public async Task CrearEquipoAsync(BasketEquipoDTO equipo)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}", equipo);
            response.EnsureSuccessStatusCode();
        }

        public async Task ActualizarEquipoAsync(int id, BasketEquipoDTO equipo)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", equipo);
            response.EnsureSuccessStatusCode();
        }
        public async Task EliminarEquipoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task DescargarPlantillaCSVAsync(string rutaDestino)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/plantilla");
            response.EnsureSuccessStatusCode();
            var bytes = await response.Content.ReadAsByteArrayAsync();
            await File.WriteAllBytesAsync(rutaDestino, bytes);
        }

        public async Task CargarEquiposDesdeCSVAsync(string rutaArchivo)
        {
            using var form = new MultipartFormDataContent();
            var contenidoArchivo = new ByteArrayContent(await File.ReadAllBytesAsync(rutaArchivo));
            contenidoArchivo.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/csv");
            form.Add(contenidoArchivo, "archivo", Path.GetFileName(rutaArchivo));

            var response = await _httpClient.PostAsync($"{BaseUrl}/cargar", form);
            response.EnsureSuccessStatusCode();
        }
        public async Task<List<BasketJugadoreDTO>> ObtenerJugadoresPorEquipoAsync(int equipoId)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/equipos/{equipoId}/jugadores");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<BasketJugadoreDTO>>();
        }

        public async Task<List<PartidoDTO>> GetPartidosDelEquipoAsync(int equipoId)
        {
            var url = $"http://localhost:8080/basket/partidos/equipo/{equipoId}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<PartidoDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        public async Task<BasketEquipoDTO> ObtenerEquipoPorNombreAsync(string nombre)
        {
            var response = await _httpClient.GetAsync($"http://localhost:8080/basket/equipos/nombre/{nombre}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BasketEquipoDTO>();
        }
    }
}
