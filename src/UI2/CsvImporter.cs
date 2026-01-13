using System.Globalization;
using System.IO;

public class CsvImporter
{
    private readonly ProductGateway _gateway;

    public CsvImporter(ProductGateway gateway)
    {
        _gateway = gateway;
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
}
