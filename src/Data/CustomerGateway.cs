public class CustomerGateway : TableGateway
{
    public CustomerGateway(MySqlConnection conn) : base(conn) { }

    public int Insert(Customer c)
    {
        var cmd = new MySqlCommand(
            "INSERT INTO customer(name,email,registered_at) VALUES (@n,@e,@r)",
            Connection);
        cmd.Parameters.AddWithValue("@n", c.Name);
        cmd.Parameters.AddWithValue("@e", c.Email);
        cmd.Parameters.AddWithValue("@r", c.RegisteredAt);
        cmd.ExecuteNonQuery();
        return (int)cmd.LastInsertedId;
    }
}