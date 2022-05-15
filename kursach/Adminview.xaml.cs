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
    /// Логика взаимодействия для Adminview.xaml
    /// </summary>
    public partial class Adminview : Window
    {
        public Adminview()
        {
            InitializeComponent();
        }

        private void BtnBooks_click(object sender, RoutedEventArgs e)
        {
            Booksadm adm = new Booksadm();
            adm.Show();
            this.Close();
        }

        private void BtnPublishers_click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAuthors_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
