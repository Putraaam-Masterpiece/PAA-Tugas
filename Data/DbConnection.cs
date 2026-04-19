using Npgsql;
using System.Data;

public class DbConnection
{
    private readonly IConfiguration _config;
    private readonly string _connectionString;

    public DbConnection(IConfiguration config)
    {
        _config = config;
        _connectionString = _config.GetConnectionString("DefaultConnection");
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}