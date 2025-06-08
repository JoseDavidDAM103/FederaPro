using FederaProDesktop.Karting.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace FederaProDesktop.Karting.Servicios
{
    public class EstadisticasCarreraApiService
    {
        private readonly HttpClient httpClient;

        public EstadisticasCarreraApiService()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/")
            };
        }

        public async Task<bool> GuardarEstadisticasAsync(List<KartingEstadisticaPilotoDTO> lista)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("karting/estadisticas/piloto/guardar", lista);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar estadísticas: " + ex.Message);
                return false;
            }
        }
    }
}
