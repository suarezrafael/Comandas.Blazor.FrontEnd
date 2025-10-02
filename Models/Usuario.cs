namespace ComandasBlazor.Models;

public class Usuario
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
}

public class UsuarioRequest
{
    public string? Email { get; set; }
    public string? Senha { get; set; }
}

public class UsuarioResponse
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Token { get; set; }
}
