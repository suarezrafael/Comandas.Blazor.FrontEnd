using System.Text;
using System.Text.Json;

namespace ComandasBlazor.Services;

public class ApiService
{
    private readonly IHttpClientFactory _httpClient;
    private static readonly JsonSerializerOptions _json = new() { PropertyNameCaseInsensitive = true };

    public ApiService(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient; // já vem com BaseAddress e TokenMessageHandler
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        try
        {
            var client = _httpClient.CreateClient("Api");

            var response = await client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, _json);
        }
        catch
        {
            return default;
        }
    }

    public async Task<T?> PostAsync<T>(string endpoint, object data)
    {
        try
        {
            var client = _httpClient.CreateClient("Api");
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseContent, _json);
        }
        catch
        {
            return default;
        }
    }

    public async Task<bool> PutAsync(string endpoint, object data)
    {
        try
        {
            var client = _httpClient.CreateClient("Api");
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(endpoint, content);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(string endpoint)
    {
        try
        {
            var client = _httpClient.CreateClient("Api");
            var response = await client.DeleteAsync(endpoint);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> PatchAsync(string endpoint)
    {
        try
        {
            var client = _httpClient.CreateClient("Api");
            var response = await client.PatchAsync(endpoint, null);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}
