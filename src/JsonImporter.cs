using System.Text.Json;

public class JsonImporter
{
    private readonly CustomerGateway _gateway;

    public JsonImporter(CustomerGateway gateway)
    {
        _gateway = gateway;
    }

    public void Import(string file)
    {
        var json = File.ReadAllText(file);
        var customers = JsonSerializer.Deserialize<List<Customer>>(json);

        foreach (var c in customers)
        {
            c.RegisteredAt = DateTime.Now;
            _gateway.Insert(c);
        }
    }
}