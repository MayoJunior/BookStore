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
    /// Логика взаимодействия для Booksadm.xaml
    /// </summary>
    public partial class Booksadm : Window
    {
        public Booksadm()
        {
            InitializeComponent();
            DGridBooks.ItemsSource = Book_StoreEntities.GetContext().Books.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddBooks lol = new AddBooks(null);
            lol.Show();
            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var BooksForRemoving = DGridBooks.SelectedItems.Cast<Books>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {BooksForRemoving.Count()} элементов?", "Внимание!",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Book_StoreEntities.GetContext().Books.RemoveRange(BooksForRemoving);
                    Book_StoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridBooks.ItemsSource = Book_StoreEntities.GetContext().Books.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnBack_click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var BooksForUpdating = DGridBooks.SelectedItems.Cast<Books>().FirstOrDefault();
            AddBooks lol = new AddBooks(BooksForUpdating);
            lol.Show();
            this.Close();
        }
    }
}
