namespace ComandasBlazor.Models;

public class PedidoCozinhaGetDto
{
    public int Id { get; set; }
    public int NumeroMesa { get; set; }
    public string? NomeCliente { get; set; }
    public string? Titulo { get; set; }
}

public class PedidoCozinhaUpdateDto
{
    public int NovoStatusId { get; set; }
}
