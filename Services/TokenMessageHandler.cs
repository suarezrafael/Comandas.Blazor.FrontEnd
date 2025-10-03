using System.Net.Http.Headers;

namespace ComandasBlazor.Services;

public class TokenMessageHandler : DelegatingHandler
{
    private readonly AuthService _auth;

    public TokenMessageHandler(AuthService auth)
    {
        _auth = auth;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var token = _auth.Token;
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return base.SendAsync(request, ct);
    }
}
