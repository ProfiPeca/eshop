using MySql.Data.MySqlClient;

public class ProductGateway : TableGateway
{
    public ProductGateway(MySqlConnection conn) : base(conn) { }

    public List<Product> FindAll()
    {
        var list = new List<Product>();
        var cmd = new MySqlCommand("SELECT * FROM product", Connection);
        using var r = cmd.ExecuteReader();

        while (r.Read())
        {
            list.Add(new Product
            {
                Id = r.GetInt32("id"),
                Name = r.GetString("name"),
                Price = r.GetFloat("price"),
                Category = r.GetString("category"),
                InStock = r.GetBoolean("in_stock")
            });
        }
        return list;
    }

    public void Insert(Product p)
    {
        var cmd = new MySqlCommand(
            "INSERT INTO product(name,price,category,in_stock) VALUES (@n,@p,@c,@i)",
            Connection);
        cmd.Parameters.AddWithValue("@n", p.Name);
        cmd.Parameters.AddWithValue("@p", p.Price);
        cmd.Parameters.AddWithValue("@c", p.Category);
        cmd.Parameters.AddWithValue("@i", p.InStock);
        cmd.ExecuteNonQuery();
    }

    public void Update(Product p)
    {
        var cmd = new MySqlCommand(
            "UPDATE product SET name=@n, price=@p, category=@c, in_stock=@i WHERE id=@id",
            Connection);
        cmd.Parameters.AddWithValue("@id", p.Id);
        cmd.Parameters.AddWithValue("@n", p.Name);
        cmd.Parameters.AddWithValue("@p", p.Price);
        cmd.Parameters.AddWithValue("@c", p.Category);
        cmd.Parameters.AddWithValue("@i", p.InStock);
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        var cmd = new MySqlCommand("DELETE FROM product WHERE id=@id", Connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}