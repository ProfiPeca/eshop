using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Windows;

namespace Eshop.UI
{
    public partial class MainWindow : Window
    {
        private readonly MySqlConnection _connection;

        public MainWindow(MySqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;
        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cmd = new MySqlCommand(SqlBox.Text, _connection);

                if (SqlBox.Text.Trim().ToUpper().StartsWith("SELECT"))
                {
                    using var reader = cmd.ExecuteReader();
                    var sb = new StringBuilder();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                            sb.Append(reader[i] + "\t");
                        sb.AppendLine();
                    }

                    MessageBox.Show(sb.ToString(), "Výsledek");
                }
                else
                {
                    int rows = cmd.ExecuteNonQuery();
                    StatusText.Text = $"Ovlivnìno øádkù: {rows}";
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "SQL chyba:\n" + ex.Message,
                    "Chyba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            var win = new ProductWindow(_connection);
            win.ShowDialog();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            var win = new OrderWindow(_connection);
            win.ShowDialog();
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            var win = new ReportWindow(_connection);
            win.ShowDialog();
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            new ImportWindow(_connection).ShowDialog();
        }

    }
}
