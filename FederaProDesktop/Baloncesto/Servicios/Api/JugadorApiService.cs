using FederaProDesktop.Modelos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FederaProDesktop.Servicios.Api
{
    public class JugadorApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:8080/basket/jugadores"; // Asumiendo que este es el endpoint base
        private const string BaseUrlEquipos = "http://localhost:8080/basket/equipos";
        public JugadorApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<BasketJugadoreDTO>> GetJugadoresAsync()
        {
            var response = await _httpClient.GetAsync(BaseUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<BasketJugadoreDTO>>();
        }

        public async Task<BasketJugadoreDTO> GetJugadorPorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<BasketJugadoreDTO>();
        }

        public async Task<List<BasketJugadoreDTO>> BuscarJugadoresAsync(string nombreJugador, string nombreEquipo, string posicion)
        {
            var query = new List<string>();

            if (!string.IsNullOrWhiteSpace(nombreJugador))
                query.Add($"nombre={Uri.EscapeDataString(nombreJugador)}");

            if (!string.IsNullOrWhiteSpace(nombreEquipo))
                query.Add($"nombreEquipo={Uri.EscapeDataString(nombreEquipo)}");

            if (!string.IsNullOrWhiteSpace(posicion))
                query.Add($"posicion={Uri.EscapeDataString(posicion)}");

            string url = $"{BaseUrl}/buscar";
            if (query.Count > 0)
                url += "?" + string.Join("&", query);

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<BasketJugadoreDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task CrearJugadorAsync(CrearActualizarJugadorDTO jugador)
        {
            var json = JsonSerializer.Serialize(jugador);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync($"{BaseUrl}", content);
        }

        public async Task ActualizarJugadorAsync(CrearActualizarJugadorDTO jugador)
        {
            var json = JsonSerializer.Serialize(jugador);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"{BaseUrl}/{jugador.id}", content);
        }

        public async Task EliminarJugadorAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task CargarJugadoresDesdeCsvAsync(string rutaArchivo, BasketEquipoDTO equipo)
        {
            using var form = new MultipartFormDataContent();

            var contenidoArchivo = new ByteArrayContent(await File.ReadAllBytesAsync(rutaArchivo));
            contenidoArchivo.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/csv");

            // Serializar el objeto equipo a JSON
            string equipoJson = JsonSerializer.Serialize(equipo);
            var contenidoEquipo = new StringContent(equipoJson, Encoding.UTF8, "application/json");

            form.Add(contenidoArchivo, "file", Path.GetFileName(rutaArchivo));
            form.Add(new StringContent(equipo.Id.ToString()), "equipoId");

            var response = await _httpClient.PostAsync($"{BaseUrl}/cargar", form);
            response.EnsureSuccessStatusCode();
        }
        public async Task<List<BasketJugadoreDTO>> ObtenerJugadoresPorEquipoAsync(int equipoId)
        {
            var response = await _httpClient.GetAsync($"{BaseUrlEquipos}/{equipoId}/jugadores");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<BasketJugadoreDTO>>();
        }

        public async Task<int?> ObtenerEquipoIdPorNombreAsync(string nombreEquipo)
        {
            var response = await _httpClient.GetAsync($"{BaseUrlEquipos}");
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();
            var equipos = JsonSerializer.Deserialize<List<BasketEquipoDTO>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var equipo = equipos.FirstOrDefault(e => e.Nombre.Equals(nombreEquipo, StringComparison.OrdinalIgnoreCase));
            return equipo?.Id;
        }
    }
}
