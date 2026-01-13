using MySql.Data.MySqlClient;

public static class DbConnectionFactory
{
    public static MySqlConnection Create(DbConfig cfg)
    {
        var cs = $"Server={cfg.Host};Database={cfg.Database};Uid={cfg.User};Pwd={cfg.Password};";
        var conn = new MySqlConnection(cs);
        conn.Open();
        return conn;
    }
}