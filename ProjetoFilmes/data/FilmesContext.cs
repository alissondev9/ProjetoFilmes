using System.Data.SqlClient;

namespace ProjetoFilmes.Data;
public class FilmesContext
{
    private readonly string _connectionString;

    public FilmesContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
