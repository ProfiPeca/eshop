using MySql.Data.MySqlClient;

public class OrderItemGateway : TableGateway
{
    public OrderItemGateway(MySqlConnection conn) : base(conn) { }

    public void Insert(OrderItem i, MySqlTransaction tx)
    {
        var cmd = new MySqlCommand(
            "INSERT INTO order_item(order_id,product_id,quantity,price) VALUES (@o,@p,@q,@pr)",
            Connection, tx);
        cmd.Parameters.AddWithValue("@o", i.OrderId);
        cmd.Parameters.AddWithValue("@p", i.ProductId);
        cmd.Parameters.AddWithValue("@q", i.Quantity);
        cmd.Parameters.AddWithValue("@pr", i.Price);
        cmd.ExecuteNonQuery();
    }
}