namespace ComandasBlazor.Models;

public class Comanda
{
    public int Id { get; set; }
    public int NumeroMesa { get; set; }
    public string? NomeCliente { get; set; }
    public int SituacaoComanda { get; set; }
    public List<ComandaItem>? ComandaItems { get; set; }
}

public class ComandaDto
{
    public int NumeroMesa { get; set; }
    public string? NomeCliente { get; set; }
    public List<int>? CardapioItems { get; set; }
}

public class ComandaGetDto
{
    public int Id { get; set; }
    public int NumeroMesa { get; set; }
    public string? NomeCliente { get; set; }
    public List<ComandaItensGetDto>? ComandaItens { get; set; }
}

public class ComandaItem
{
    public int Id { get; set; }
    public int CardapioItemId { get; set; }
    public CardapioItem? CardapioItem { get; set; }
    public int ComandaId { get; set; }
    public Comanda? Comanda { get; set; }
}

public class ComandaItemUpdateDto
{
    public int CardapioItemId { get; set; }
    public int Id { get; set; }
    public bool Excluir { get; set; }
    public bool Incluir { get; set; }
}

public class ComandaItensGetDto
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
}

public class ComandaUpdateDto
{
    public int Id { get; set; }
    public int NumeroMesa { get; set; }
    public string? NomeCliente { get; set; }
    public List<ComandaItemUpdateDto>? ComandaItens { get; set; }
}
