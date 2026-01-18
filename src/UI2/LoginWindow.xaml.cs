using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System.Text.Json;
using System.Windows;
using System.IO;

namespace Eshop.UI
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string cs =
                $"Server={HostBox.Text};Database={DbBox.Text};Uid={UserBox.Text};Pwd={PasswordBox.Password};";

            try
            {
                var conn = new MySqlConnection(cs);
                conn.Open();

                MessageBox.Show("Pøipojení úspìšné", "OK",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                var main = new MainWindow(conn);
                main.Show();
                Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Chyba pøipojení:\n" + ex.Message,
                    "Chyba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
        private void LoadConfig_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "JSON soubory (*.json)|*.json",
                Title = "Vyberte konfiguraèní soubor databáze"
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var json = File.ReadAllText(dialog.FileName);
                    var config = JsonSerializer.Deserialize<DbConfig>(json);

                    if (config == null)
                        throw new Exception("Konfigurace je neplatná.");

                    HostBox.Text = config.Host;
                    DbBox.Text = config.Database;
                    UserBox.Text = config.User;
                    PasswordBox.Password = config.Password;

                    MessageBox.Show("Konfigurace úspìšnì naètena.",
                        "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Chyba pøi naèítání konfigurace:\n{ex.Message}",
                        "Chyba",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }
    }
}