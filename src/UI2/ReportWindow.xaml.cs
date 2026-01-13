using MySql.Data.MySqlClient;
using System.Windows;

namespace Eshop.UI
{
    public partial class ReportWindow : Window
    {
        private readonly ReportGateway _gateway;

        public ReportWindow(MySqlConnection connection)
        {
            InitializeComponent();
            _gateway = new ReportGateway(connection);
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            ReportGrid.ItemsSource = _gateway.LoadCustomerReport();
        }
    }
}
