using ProjetoFilmes.Data;

class Program
{
    static void Main()
    {
        var connectionString = "Server=localhost;Database=Filmes;Trusted_Connection=True;";
        var context = new FilmesContext(connectionString);
        var consultas = new Consultas(context);

        Console.WriteLine("Exercicio 1:");
        consultas.Exercicio1();

        Console.WriteLine("\nExercicio 2:");
        consultas.Exercicio2();

        Console.WriteLine("\nExercicio 3:");
        consultas.Exercicio3();

        Console.WriteLine("\nExercicio 4:");
        consultas.Exercicio4();

        Console.WriteLine("\nExercicio 5:");
        consultas.Exercicio5();

        Console.WriteLine("\nExercicio 6:");
        consultas.Exercicio6();

        Console.WriteLine("\nExercicio 7:");
        consultas.Exercicio7();

        Console.WriteLine("\nExercicio 8:");
        consultas.Exercicio8();

        Console.WriteLine("\nExercicio 9:");
        consultas.Exercicio9();

        Console.WriteLine("\nExercicio 10:");
        consultas.Exercicio10();

        Console.WriteLine("\nExercicio 11:");
        consultas.Exercicio11();

        Console.WriteLine("\nExercicio 12:");
        consultas.Exercicio12();
    }
}
