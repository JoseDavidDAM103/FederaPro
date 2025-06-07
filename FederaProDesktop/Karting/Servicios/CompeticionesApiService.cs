using FederaProDesktop.Karting.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
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
                BaseAddress = new Uri("http://localhost:8080/")
            };
        }

        public async Task<List<KartingCompeticion>> GetAllCompeticionesAsync()
        {
            var response = await httpClient.GetAsync("karting/competiciones");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<KartingCompeticion>>();
        }
    }
}
