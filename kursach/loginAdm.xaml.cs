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
    /// Логика взаимодействия для loginAdm.xaml
    /// </summary>
    public partial class loginAdm : Window
    {
        public static int index = 0;
        string Login, Password;
        public loginAdm()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            Users_two User = null;

            Login = txtLogin.Text;
            Password = txtPassword.Password;
            User = Book_StoreEntities.GetContext().Users_two.Where(b => b.Password_user == Password && b.Login_user == Login).FirstOrDefault();

            if (User == null) MessageBox.Show("Не найдено");
            else
            {
                MessageBox.Show("Успешно");
                index = -1;
                Adminview adm = new Adminview();
                adm.Show();
                this.Close();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win1 = new MainWindow();
            win1.Show();
            this.Close();
        }
    }
}
