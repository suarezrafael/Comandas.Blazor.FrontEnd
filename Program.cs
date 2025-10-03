using ComandasBlazor.Components;
using ComandasBlazor.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// URL base da API (pode levar para appsettings.json)
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "http://localhost:5163/";

// Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Storage protegido no navegador (persistência do token/usuário)

// AuthService é Scoped (1 por circuito/usuário)
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ApiService>();

// Handler que injeta Authorization: Bearer <token> em TODAS as chamadas do ApiService
builder.Services.AddScoped<TokenMessageHandler>();

// HttpClient nomeado "Api" (SEM handler) — usado dentro do AuthService para o login
builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();