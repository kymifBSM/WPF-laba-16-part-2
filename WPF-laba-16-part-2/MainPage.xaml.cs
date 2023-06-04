using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_laba_16_part_2
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private MainWindow mainWindow;

        public MainPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            string productCode = ProductCodeTextBox.Text;
            decimal quantity = decimal.Parse(QuantityTextBox.Text, CultureInfo.InvariantCulture);

            mainWindow.AddToCart(productCode, quantity);

            ProductCodeTextBox.Text = string.Empty;
            QuantityTextBox.Text = string.Empty;
        }

        private void ShowCartButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowCart();
        }
    }
}