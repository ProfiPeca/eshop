public class OrderGateway : TableGateway
{
    public OrderGateway(MySqlConnection conn) : base(conn) { }

    public int Insert(Order o, MySqlTransaction tx)
    {
        var cmd = new MySqlCommand(
            "INSERT INTO `order`(customer_id,created_at,total_price) VALUES (@c,@d,@t)",
            Connection, tx);
        cmd.Parameters.AddWithValue("@c", o.CustomerId);
        cmd.Parameters.AddWithValue("@d", o.CreatedAt);
        cmd.Parameters.AddWithValue("@t", o.TotalPrice);
        cmd.ExecuteNonQuery();
        return (int)cmd.LastInsertedId;
    }
}