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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Window
    {
        String _name;
        public UserPage()
        {
            InitializeComponent();
            var currentBook = Book_StoreEntities.GetContext().Books.ToList();
            listMain.ItemsSource = currentBook;
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            MainWindow winAuth = new MainWindow();
            winAuth.Show();
            this.Close();
            
        }
        /*private void FindBooks_TextChanged(object sender, TextChangedEventArgs e)
        {
            Books Name = null;

            _name = FindBooks.Text;
            Name = Book_StoreEntities.GetContext().Books.Where(b => b.Book_name == _name).FirstOrDefault();
            if (Name == null)
            {
                listMain.ItemsSource = Book_StoreEntities.GetContext().Books.ToList();
            }
            else
            {
                listMain.ItemsSource = Book_StoreEntities.GetContext().Books.Where(b => b.Book_name == _name).ToList();
            }
        }*/
    }
}
