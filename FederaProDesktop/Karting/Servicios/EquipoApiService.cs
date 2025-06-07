using FederaProDesktop.Karting.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FederaProDesktop.Karting.Servicios
{
    public class EquipoApiService
    {
        private readonly HttpClient _httpClient;

        public EquipoApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080/");
        }

        public async Task<List<KartingEquipo>> ObtenerEquiposAsync()
        {
            var response = await _httpClient.GetAsync("karting/equipos");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<KartingEquipo>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            return new List<KartingEquipo>();
        }
        public async Task DescargarCSVAsync(string rutaDestino)
        {
            var response = await _httpClient.GetAsync("/karting/csv/plantilla/equipos");
            response.EnsureSuccessStatusCode();

            var bytes = await response.Content.ReadAsByteArrayAsync();
            await File.WriteAllBytesAsync(rutaDestino, bytes);
        }

        public async Task ImportarCSVAsync(string rutaArchivo)
        {
            using var form = new MultipartFormDataContent();
            using var fileStream = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read);
            using var fileContent = new StreamContent(fileStream);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");

            form.Add(fileContent, "file", Path.GetFileName(rutaArchivo));

            var response = await _httpClient.PostAsync("/karting/csv/cargar/equipos", form);
            response.EnsureSuccessStatusCode();
        }
    }
}
