using ComandasBlazor.Models;
using System.Text;
using System.Text.Json;

namespace ComandasBlazor.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private string? _token;
    private UsuarioResponse? _currentUser;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public string? Token => _token;
    public UsuarioResponse? CurrentUser => _currentUser;
    public bool IsAuthenticated => !string.IsNullOrEmpty(_token);

    public async Task<bool> LoginAsync(string email, string senha)
    {
        try
        {
            var request = new UsuarioRequest { Email = email, Senha = senha };
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Usuarios/login", content);
            
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _currentUser = JsonSerializer.Deserialize<UsuarioResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                _token = _currentUser?.Token;
                return true;
            }
            return false;
        }
        catch
        {
            return false;
        }
    }

    public void Logout()
    {
        _token = null;
        _currentUser = null;
    }
}
