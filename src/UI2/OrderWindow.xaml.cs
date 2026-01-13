using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Eshop.UI
{
    public partial class OrderWindow : Window
    {
        private readonly MySqlConnection _connection;
        private readonly CustomerGateway _customerGateway;
        private readonly ProductGateway _productGateway;
        private readonly OrderGateway _orderGateway;
        private readonly OrderItemGateway _itemGateway;

        public OrderWindow(MySqlConnection connection)
        {
            InitializeComponent();

            _connection = connection;
            _customerGateway = new CustomerGateway(connection);
            _productGateway = new ProductGateway(connection);
            _orderGateway = new OrderGateway(connection);
            _itemGateway = new OrderItemGateway(connection);

            LoadData();
        }

        private void LoadData()
        {
            CustomerBox.ItemsSource = _customerGateway.FindAll();

            var products = _productGateway.FindAll()
                .Select(p => new ProductOrderItem
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = 0
                }).ToList();

            ProductGrid.ItemsSource = products;
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerBox.SelectedItem is not Customer customer)
            {
                MessageBox.Show("Vyberte zákazníka");
                return;
            }

            var items = ((List<ProductOrderItem>)ProductGrid.ItemsSource)
                .Where(i => i.Quantity > 0)
                .ToList();

            if (!items.Any())
            {
                MessageBox.Show("Vyberte alespoò jednu položku");
                return;
            }

            float total = items.Sum(i => i.Price * i.Quantity);

            using var tx = _connection.BeginTransaction();

            try
            {
                var order = new Order
                {
                    CustomerId = customer.Id,
                    CreatedAt = DateTime.Now,
                    TotalPrice = total
                };

                int orderId = _orderGateway.Insert(order, tx);

                foreach (var i in items)
                {
                    _itemGateway.Insert(new OrderItem
                    {
                        OrderId = orderId,
                        ProductId = i.ProductId,
                        Quantity = i.Quantity,
                        Price = i.Price
                    }, tx);
                }

                tx.Commit();
                MessageBox.Show("Objednávka úspìšnì vytvoøena");
                Close();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("Chyba pøi ukládání:\n" + ex.Message);
            }
        }
    }
}