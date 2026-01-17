namespace ProjetoFilmes.Models;

public class Ator

{
    public int Id { get; set; }
    public string PrimeiroNome { get; set; } = null!;
    public string UltimoNome { get; set; } = null!;
    public string Genero { get; set; } = null!; // "M" ou "F"
}

