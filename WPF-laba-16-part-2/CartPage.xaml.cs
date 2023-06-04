using WPF_laba_16_part_2;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        private MainWindow mainWindow;
        private List<CartItem> cartItems;
        private decimal total;
        private decimal tax;

        public CartPage(MainWindow mainWindow, List<CartItem> cartItems, decimal total, decimal tax)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.cartItems = cartItems;
            this.total = total;
            this.tax = tax;

            CartItemsListView.ItemsSource = cartItems;
            TotalTextBlock.Text = total.ToString("C");
            TaxTextBlock.Text = tax.ToString("C");
            GrandTotalTextBlock.Text = (total + tax).ToString("C");
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Checkout();
            mainWindow.Navigate(new MainPage(mainWindow));
        }
    }
}