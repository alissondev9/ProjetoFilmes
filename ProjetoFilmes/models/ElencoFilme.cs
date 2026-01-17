namespace ProjetoFilmes.Models;

public class ElencoFilme
{
    public int Id { get; set; }
    public int IdAtor { get; set; }
    public int IdFilme { get; set; }
    public string Papel { get; set; } = null!;
}

