using ComandasBlazor.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Text;
using System.Text.Json;

namespace ComandasBlazor.Services;

public class AuthService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ProtectedLocalStorage _pls;

    private string? _token;
    private UsuarioResponse? _currentUser;
    private bool _initialized;

    private const string TOKEN_KEY = "auth_token";
    private const string USER_KEY = "auth_user";

    public AuthService(IHttpClientFactory clientFactory, ProtectedLocalStorage pls)
    {
        _clientFactory = clientFactory;
        _pls = pls;
    }

    public string? Token => _token;
    public UsuarioResponse? CurrentUser => _currentUser;
    public bool IsAuthenticated => !string.IsNullOrEmpty(_token);

    public async Task EnsureInitializedAsync()
    {
        if (_initialized) return;
        _initialized = true;

        var token = await _pls.GetAsync<string>(TOKEN_KEY);
        if (token.Success && !string.IsNullOrEmpty(token.Value))
        {
            _token = token.Value;
            var user = await _pls.GetAsync<UsuarioResponse>(USER_KEY);
            if (user.Success)
            {
                _currentUser = user.Value;
            }
        }
    }

    public async Task<bool> LoginAsync(string email, string senha)
    {
        try
        {
            var client = _clientFactory.CreateClient("Api");

            var request = new UsuarioRequest { Email = email, Senha = senha };
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Usuarios/login", content);
            if (!response.IsSuccessStatusCode)
                return false;

            var responseContent = await response.Content.ReadAsStringAsync();
            _currentUser = JsonSerializer.Deserialize<UsuarioResponse>(
                responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            _token = _currentUser?.Token;

            if (string.IsNullOrEmpty(_token))
                return false;

            // Persistir no navegador
            await _pls.SetAsync(TOKEN_KEY, _token);
            await _pls.SetAsync(USER_KEY, _currentUser!);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task LogoutAsync()
    {
        _token = null;
        _currentUser = null;
        await _pls.DeleteAsync(TOKEN_KEY);
        await _pls.DeleteAsync(USER_KEY);
    }
}
