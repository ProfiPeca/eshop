using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace Eshop.UI
{
    public partial class ImportWindow : Window
    {
        private readonly MySqlConnection _connection;

        public ImportWindow(MySqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;
        }

        private void ImportCsv_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "CSV (*.csv)|*.csv" };
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    var importer = new CsvImporter(
                        new ProductGateway(_connection));
                    importer.Import(dlg.FileName);

                    StatusText.Text = "CSV import probìhl úspìšnì";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chyba CSV importu:\n" + ex.Message);
                }
            }
        }

        private void ImportJson_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "JSON (*.json)|*.json" };
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    var importer = new JsonImporter(
                        new CustomerGateway(_connection));
                    importer.Import(dlg.FileName);

                    StatusText.Text = "JSON import probìhl úspìšnì";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chyba JSON importu:\n" + ex.Message);
                }
            }
        }
    }
}