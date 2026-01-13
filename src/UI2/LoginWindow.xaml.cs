using MySql.Data.MySqlClient;
using System.Windows;

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
    }
}