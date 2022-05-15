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
    /// Логика взаимодействия для AddBooks.xaml
    /// </summary>
    public partial class AddBooks : Window
    {
        private Books _currentBooks = new Books();
        private int reg = 0;
        int maxid = Book_StoreEntities.GetContext().Books.Max(u => u.Book_number);
        int maxpublisherid = Book_StoreEntities.GetContext().publishers.Max(u => u.Publisher_id);

        public AddBooks(Books SelectBook)
        {
            if (SelectBook != null)
            {
                _currentBooks = SelectBook;
                reg = 1;
            }
            else
            {
                _currentBooks.Book_number = maxid + 1;
            }
            InitializeComponent();
            DataContext = _currentBooks;
            ComboAuthor.ItemsSource = Book_StoreEntities.GetContext().authors.ToList();
            Combopublisher.ItemsSource = Book_StoreEntities.GetContext().publishers.ToList();
        }

        private void BtnSave(object sender, RoutedEventArgs e)
        {
            string _SearchName;
            _SearchName = Combopublisher.Text;
            publishers SearchType = null;
            SearchType = Book_StoreEntities.GetContext().publishers.Where(b => b.Publisher_name == _SearchName).FirstOrDefault();
            _currentBooks.Publisher_id = SearchType.Publisher_id;
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentBooks.Book_name)) errors.AppendLine("Введите название");
            if (_currentBooks.Genre == null) errors.AppendLine("Введите дату начала");
            if (_currentBooks.Book_name == null) errors.AppendLine("Введите дату конца");
            if (reg == 0) Book_StoreEntities.GetContext().Books.Add(_currentBooks);
            else
            {
                var Trs = Book_StoreEntities.GetContext().Books.Where(b => b.Book_number == _currentBooks.Book_number).FirstOrDefault();
                Trs.Image_book = _currentBooks.Image_book;
                Trs.Book_name = _currentBooks.Book_name;
                Trs.Genre = _currentBooks.Genre;
                Trs.Price = _currentBooks.Price;
                Trs.Pubyear = _currentBooks.Pubyear;
                Trs.Book_number = _currentBooks.Book_number;
                Trs.Author_id = _currentBooks.Author_id;
                Trs.publishers.Publisher_name = _currentBooks.publishers.Publisher_name;
                Trs.Amount_book = _currentBooks.Amount_book;

            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {
                Book_StoreEntities.GetContext().SaveChanges();
                MessageBox.Show("Okey!");
                _currentBooks = new Books();
                Booksadm bob = new Booksadm();
                bob.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
    }

