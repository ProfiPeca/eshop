using MySql.Data.MySqlClient;
using System.Collections.Generic;

public class ReportGateway : TableGateway
{
    public ReportGateway(MySqlConnection connection) : base(connection) { }

    public List<CustomerOrderReport> LoadCustomerReport()
    {
        var list = new List<CustomerOrderReport>();

        var cmd = new MySqlCommand(
            "SELECT * FROM v_customer_order_report",
            Connection);

        using var r = cmd.ExecuteReader();
        while (r.Read())
        {
            list.Add(new CustomerOrderReport
            {
                CustomerName = r.GetString("customer_name"),
                OrderCount = r.GetInt32("order_count"),
                TotalSpent = r.GetFloat("total_spent"),
                FirstOrder = r.GetDateTime("first_order"),
                LastOrder = r.GetDateTime("last_order")
            });
        }
        return list;
    }
}