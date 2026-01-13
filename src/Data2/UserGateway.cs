public class UserGateway : TableGateway
{
    public UserGateway(MySqlConnection conn) : base(conn) { }

    public User FindByLogin(string username, string hash)
    {
        var cmd = new MySqlCommand(
            "SELECT * FROM user WHERE username=@u AND password_hash=@p AND is_active=1",
            Connection);
        cmd.Parameters.AddWithValue("@u", username);
        cmd.Parameters.AddWithValue("@p", hash);

        using var r = cmd.ExecuteReader();
        if (!r.Read()) return null;

        return new User
        {
            Id = r.GetInt32("id"),
            Username = r.GetString("username"),
            Role = r.GetString("role"),
            IsActive = r.GetBoolean("is_active")
        };
    }
}