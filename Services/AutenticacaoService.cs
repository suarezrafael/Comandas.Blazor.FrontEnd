using Comandas.Blazor.FrontEnd.Models;

namespace Comandas.Blazor.FrontEnd.Services;

public class AutenticacaoService
{
    public Usuario? UsuarioAtual { get; private set; }
    public bool EstaAutenticado => UsuarioAtual != null;
    
    public event Action? OnAuthenticationStateChanged;

    public async Task<bool> Login(string email, string senha)
    {
        // Simulação de login - em produção, isso deveria chamar uma API
        await Task.Delay(500); // Simular chamada de API
        
        if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(senha))
        {
            UsuarioAtual = new Usuario
            {
                Id = 1,
                Nome = "Usuário Demo",
                Email = email,
                DataCadastro = DateTime.Now,
                Ativo = true
            };
            
            OnAuthenticationStateChanged?.Invoke();
            return true;
        }
        
        return false;
    }

    public void Logout()
    {
        UsuarioAtual = null;
        OnAuthenticationStateChanged?.Invoke();
    }
}
