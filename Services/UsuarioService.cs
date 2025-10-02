using Comandas.Blazor.FrontEnd.Models;

namespace Comandas.Blazor.FrontEnd.Services;

public class UsuarioService
{
    private readonly List<Usuario> _usuarios = new();
    private int _proximoId = 1;

    public UsuarioService()
    {
        // Adicionar alguns usuários de exemplo
        _usuarios.Add(new Usuario
        {
            Id = _proximoId++,
            Nome = "Admin",
            Email = "admin@comandas.com",
            Senha = "admin123",
            DataCadastro = DateTime.Now.AddDays(-30),
            Ativo = true
        });
    }

    public async Task<List<Usuario>> ObterTodos()
    {
        await Task.Delay(100); // Simular chamada assíncrona
        return _usuarios.ToList();
    }

    public async Task<Usuario?> ObterPorId(int id)
    {
        await Task.Delay(100);
        return _usuarios.FirstOrDefault(u => u.Id == id);
    }

    public async Task<bool> Criar(Usuario usuario)
    {
        await Task.Delay(100);
        
        if (_usuarios.Any(u => u.Email == usuario.Email))
        {
            return false; // Email já existe
        }

        usuario.Id = _proximoId++;
        usuario.DataCadastro = DateTime.Now;
        _usuarios.Add(usuario);
        return true;
    }

    public async Task<bool> Atualizar(Usuario usuario)
    {
        await Task.Delay(100);
        
        var usuarioExistente = _usuarios.FirstOrDefault(u => u.Id == usuario.Id);
        if (usuarioExistente == null)
        {
            return false;
        }

        // Verificar se o email já está em uso por outro usuário
        if (_usuarios.Any(u => u.Email == usuario.Email && u.Id != usuario.Id))
        {
            return false;
        }

        usuarioExistente.Nome = usuario.Nome;
        usuarioExistente.Email = usuario.Email;
        usuarioExistente.Ativo = usuario.Ativo;
        
        if (!string.IsNullOrWhiteSpace(usuario.Senha))
        {
            usuarioExistente.Senha = usuario.Senha;
        }

        return true;
    }

    public async Task<bool> Excluir(int id)
    {
        await Task.Delay(100);
        
        var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
        if (usuario == null)
        {
            return false;
        }

        _usuarios.Remove(usuario);
        return true;
    }
}
