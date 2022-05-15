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
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Window
    {
        public static int index = 0;
        public static string Login, Password;
        public login()
        {
            InitializeComponent();
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win1 = new MainWindow();
            win1.Show();
            this.Close();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            Users User = null;

            Login = txtLogin.Text;
            Password = txtPassword.Password;
            User = Book_StoreEntities.GetContext().Users.Where(b => b.Password_user == Password && b.Login_user == Login).FirstOrDefault();

            if (User == null) MessageBox.Show("Введите корректные данные или создайте новую учетную запись");
            else
            {
                MessageBox.Show("Успешно");
                index = User.Id_user;
                Login = User.Login_user;
                Password = User.Password_user;
                MainPage win4 = new MainPage();
                win4.Show();
                this.Close();
            }
            
        }
    }
}
