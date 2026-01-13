using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows;

namespace Eshop.UI
{
    public partial class ProductWindow : Window
    {
        private readonly ProductGateway _gateway;

        public ProductWindow(MySqlConnection connection)
        {
            InitializeComponent();
            _gateway = new ProductGateway(connection);
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            ProductGrid.ItemsSource = _gateway.FindAll();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var p = new Product
            {
                Name = "Nový produkt",
                Price = 0,
                Category = "BOOK",
                InStock = true
            };

            _gateway.Insert(p);
            Load_Click(null, null);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            foreach (Product p in ProductGrid.ItemsSource)
            {
                if (p.Id > 0)
                    _gateway.Update(p);
            }
            MessageBox.Show("Zmìny uloženy");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem is Product p)
            {
                if (MessageBox.Show("Opravdu smazat?", "Potvrzení",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _gateway.Delete(p.Id);
                    Load_Click(null, null);
                }
            }
        }
    }
}
