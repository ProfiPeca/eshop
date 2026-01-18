using System.Globalization;
using System.IO;

public class CsvImporter
{
    private readonly ProductGateway _gateway;
    private readonly CustomerGateway _customerGateway;

    public CsvImporter(ProductGateway gateway)
    {
        _gateway = gateway;
    }

    public CsvImporter(CustomerGateway gateway)
    {
        _customerGateway = gateway;
    }

    public void Import(string file)
    {
        var lines = File.ReadAllLines(file).Skip(1);

        foreach (var l in lines)
        {
            var p = l.Split(';');

            _gateway.Insert(new Product
            {
                Name = p[0],
                Price = float.Parse(p[1], CultureInfo.InvariantCulture),
                Category = p[2],
                InStock = p[3] == "1"
            });
        }
    }

    public void ImportCustomer(string file)
    {
        var lines = File.ReadAllLines(file).Skip(1);

        foreach (var l in lines)
        {
            var p = l.Split(';');

            _customerGateway.Insert(new Customer
            {
                Name = p[0],
                Email = p[1],
                RegisteredAt = DateTime.Now
            });
        }
    }
}
