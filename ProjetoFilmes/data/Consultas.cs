using System;
using System.Data.SqlClient;

namespace ProjetoFilmes.Data;

public class Consultas
{
    private readonly FilmesContext _context;

    public Consultas(FilmesContext context)
    {
        _context = context;
    }

    private void ExecutarConsulta(string sql, Action<SqlDataReader> action)
    {
        using var conn = _context.GetConnection();
        conn.Open();
        using var cmd = new SqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            action(reader);
        }
    }

    public void Exercicio1() // Nome e ano dos filmes
    {
        string sql = "SELECT Nome, Ano FROM Filmes";
        ExecutarConsulta(sql, r => Console.WriteLine($"{r["Nome"]} - {r["Ano"]}"));
    }

    public void Exercicio2() // Nome e ano, ordenado pelo ano
    {
        string sql = "SELECT Nome, Ano FROM Filmes ORDER BY Ano ASC";
        ExecutarConsulta(sql, r => Console.WriteLine($"{r["Nome"]} - {r["Ano"]}"));
    }

    public void Exercicio3() // "De Volta para o Futuro"
    {
        string sql = "SELECT Nome, Ano, Duracao FROM Filmes WHERE Nome = 'De Volta para o Futuro'";
        ExecutarConsulta(sql, r => Console.WriteLine($"{r["Nome"]} - {r["Ano"]} - {r["Duracao"]} min"));
    }

    public void Exercicio4() // Filmes de 1997
    {
        string sql = "SELECT Nome, Ano FROM Filmes WHERE Ano = 1997";
        ExecutarConsulta(sql, r => Console.WriteLine($"{r["Nome"]} - {r["Ano"]}"));
    }

    public void Exercicio5() // Filmes após 2000
    {
        string sql = "SELECT Nome, Ano FROM Filmes WHERE Ano > 2000";
        ExecutarConsulta(sql, r => Console.WriteLine($"{r["Nome"]} - {r["Ano"]}"));
    }

    public void Exercicio6() // Duração entre 100 e 150
    {
        string sql = "SELECT Nome, Duracao FROM Filmes WHERE Duracao > 100 AND Duracao < 150 ORDER BY Duracao ASC";
        ExecutarConsulta(sql, r => Console.WriteLine($"{r["Nome"]} - {r["Duracao"]} min"));
    }

    public void Exercicio7() // Quantidade de filmes por ano
    {
        string sql = "SELECT Ano, COUNT(*) AS Total FROM Filmes GROUP BY Ano ORDER BY Total DESC";
        ExecutarConsulta(sql, r => Console.WriteLine($"{r["Ano"]} - {r["Total"]} filmes"));
    }

    public void Exercicio8() // Atores masculinos
    {
        string sql = "SELECT PrimeiroNome, UltimoNome FROM Atores WHERE Genero = 'M'";
        ExecutarConsulta(sql, r => Console.WriteLine($"{r["PrimeiroNome"]} {r["UltimoNome"]}"));
    }

    public void Exercicio9() // Atores femininos, ordenados pelo primeiro nome
    {
        string sql = "SELECT PrimeiroNome, UltimoNome FROM Atores WHERE Genero = 'F' ORDER BY PrimeiroNome ASC";
        ExecutarConsulta(sql, r => Console.WriteLine($"{r["PrimeiroNome"]} {r["UltimoNome"]}"));
    }

    public void Exercicio10() // Nome do filme e gênero
    {
        string sql = @"
            SELECT f.Nome AS Filme, g.Genero AS Genero
            FROM Filmes f
            JOIN FilmesGenero fg ON f.Id = fg.IdFilme
            JOIN Generos g ON fg.IdGenero = g.Id";
        ExecutarConsulta(sql, r => Console.WriteLine($"{r["Filme"]} - {r["Genero"]}"));
    }

    public void Exercicio11() // Filmes do gênero "Mistério"
    {
        string sql = @"
            SELECT f.Nome AS Filme, g.Genero AS Genero
            FROM Filmes f
            JOIN FilmesGenero fg ON f.Id = fg.IdFilme
            JOIN Generos g ON fg.IdGenero = g.Id
            WHERE g.Genero = 'Mistério'";
        ExecutarConsulta(sql, r => Console.WriteLine($"{r["Filme"]} - {r["Genero"]}"));
    }

    public void Exercicio12() // Nome do filme e atores com papel
    {
        string sql = @"
            SELECT f.Nome AS Filme, a.PrimeiroNome, a.UltimoNome, ef.Papel
            FROM Filmes f
            JOIN ElencoFilme ef ON f.Id = ef.IdFilme
            JOIN Atores a ON ef.IdAtor = a.Id";
        ExecutarConsulta(sql, r => Console.WriteLine($"{r["Filme"]} - {r["PrimeiroNome"]} {r["UltimoNome"]} - Papel: {r["Papel"]}"));
    }
}
