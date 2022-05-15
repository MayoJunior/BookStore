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
using System.Windows.Shapes;

namespace kursach
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public Books currentProducts = new Books();
        public static int Id_user, Id_order;
        public static string Price;
        //int maxid = Book_StoreEntities.GetContext().Orders.Max(u => u.Id_order);
        public MainPage()
        {
            InitializeComponent();
            var currentProducts = Book_StoreEntities.GetContext().Books.ToList();
            listMain.ItemsSource = currentProducts;
            //DataContext = currentOrder;
            DataContext = currentProducts;
            

        }

        private void btnShopping_Click(object sender, RoutedEventArgs e)
        {
            personal winPer = new personal();
            winPer.Show();
            //this.Close();
        }

        private void btnAddShop_Click(object sender, RoutedEventArgs e)
        {
            /*Orders Shop = new Orders(Id_order, Id_user, Price);
            if (Shop.Id_order == 0)
                Shop.Id_order = maxid + 1;
            onlinestoreEntities.GetContext().Orders.Add(Shop);
            try
            {
                onlinestoreEntities.GetContext().SaveChanges();
                MessageBox.Show("Товар успешно добавлен в корзину");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }*/
        }
        private void listMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
