namespace ProjetoFilmes.Models;

public class Filme
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public int Ano { get; set; }
    public int Duracao { get; set; }
}

