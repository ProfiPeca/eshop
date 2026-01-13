using MySql.Data.MySqlClient;

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

    public List<Customer> FindAll()
    {
        var list = new List<Customer>();
        var cmd = new MySqlCommand("SELECT * FROM customer", Connection);
        using var r = cmd.ExecuteReader();

        while (r.Read())
        {
            list.Add(new Customer
            {
                Id = r.GetInt32("id"),
                Name = r.GetString("name"),
                Email = r.GetString("email"),
                RegisteredAt = r.GetDateTime("registered_at")
            });
        }
        return list;
    }

}