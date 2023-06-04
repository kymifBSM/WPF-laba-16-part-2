using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WPF_laba_16_part_2;

namespace WPF_laba_16_part_2
{
    public partial class MainWindow : NavigationWindow
    {
        private Dictionary<string, Product> products;
        private List<CartItem> cartItems;
        private decimal total;
        private decimal tax;

        public MainWindow()
        {
            InitializeComponent();
            InitializeProducts();
            cartItems = new List<CartItem>();
            total = 0;
            tax = 0;
            Navigate(new MainPage(this));
        }

        private void InitializeProducts()
        {
            products = new Dictionary<string, Product>();
            products.Add("001", new Product("001", "Apple", "kg", 2.99m));
            products.Add("002", new Product("002", "Banana", "kg", 1.99m));
            products.Add("003", new Product("003", "Milk", "L", 3.49m));
            products.Add("004", new Product("004", "Bread", "pc", 1.79m));
            // Добавьте остальные товары в таблицу
        }

        public void AddToCart(string productCode, decimal quantity)
        {
            if (products.ContainsKey(productCode))
            {
                Product product = products[productCode];
                bool found = false;

                foreach (CartItem item in cartItems)
                {
                    if (item.Product.Code == product.Code)
                    {
                        item.Quantity += quantity;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    cartItems.Add(new CartItem(product, quantity));
                }

                total += product.Price * quantity;
                tax = total * 0.05m;

                MessageBox.Show("Товар добавлен в корзину.");
            }
            else
            {
                MessageBox.Show("Товар с указанным кодом не найден.");
            }
        }

        public void ShowCart()
        {
            Navigate(new CartPage(this, cartItems, total, tax));
        }

        public void Checkout()
        {
            // Здесь вы можете реализовать логику оформления покупки, например,
            // сохранение данных о покупке в базу данных и печать чека.

            cartItems.Clear();
            total = 0;
            tax = 0;
            MessageBox.Show("Покупка оформлена.");
        }
    }

    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }

        public Product(string code, string name, string unit, decimal price)
        {
            Code = code;
            Name = name;
            Unit = unit;
            Price = price;
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cost => Product.Price * Quantity;

        public CartItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
