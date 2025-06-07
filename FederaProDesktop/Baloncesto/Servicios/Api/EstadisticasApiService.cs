using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FederaProDesktop.Modelos.DTO;

namespace FederaProDesktop.Servicios.Api
{
    public class EstadisticasApiService
    {
        private readonly HttpClient _httpClient;

        public EstadisticasApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080/basket/partidos/");
        }

        public async Task GuardarEstadisticasAsync(EstadisticasPartidoDTO dto)
        {
            var url = $"http://localhost:8080/basket/partidos/{dto.PartidoId}/estadisticas";
            var response = await _httpClient.PostAsJsonAsync(url, dto);
            response.EnsureSuccessStatusCode();
        }
        public async Task<EstadisticasPartidoDTO> ObtenerEstadisticasPorPartidoAsync(int partidoId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:8080/basket/partidos/estadisticas/{partidoId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<EstadisticasPartidoDTO>();
        }
    }
}
