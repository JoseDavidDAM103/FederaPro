using FederaProDesktop.DTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class UsuarioApiService
{
    private readonly HttpClient _httpClient;

    public UsuarioApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("http://localhost:8080/api/usuarios/");
    }

    public async Task<LoginResponse?> LoginAsync(string correo, string contraseña)
    {
        var request = new LoginRequest { Correo = correo, Contraseña = contraseña };
        var response = await _httpClient.PostAsJsonAsync("login", request);

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        else
            return null;
    }

    public async Task<bool> ExisteCorreoAsync(string correo)
    {
        var response = await _httpClient.GetAsync($"existe?correo={Uri.EscapeDataString(correo)}");
        if (!response.IsSuccessStatusCode)
            return false;

        var existe = await response.Content.ReadFromJsonAsync<bool>();
        return existe;
    }

    public async Task<List<DeporteDTO>> ObtenerDeportesAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:8080/api/deportes");

        if (!response.IsSuccessStatusCode)
            return new List<DeporteDTO>();

        return await response.Content.ReadFromJsonAsync<List<DeporteDTO>>();
    }

    public async Task<bool> RegistrarUsuarioAsync(UsuarioRegistroRequest usuario)
    {
        var response = await _httpClient.PostAsJsonAsync("http://localhost:8080/api/usuarios", usuario);
        return response.IsSuccessStatusCode;
    }
}
