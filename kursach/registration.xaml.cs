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
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public static int index = 0;
        int maxid = Book_StoreEntities.GetContext().Users.Max(u => u.Id_user);
        private Users User = new Users();
        public registration(Users SelectUsers)
        {
            InitializeComponent();
            if (SelectUsers != null)
                User = SelectUsers;
            DataContext = User;
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            string Login = txtLogin.Text.Trim();
            //string Password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(User.Login_user))
                errors.AppendLine("Укажите свой логин");
            if (string.IsNullOrWhiteSpace(User.Password_user))
                errors.AppendLine("Введите пароль");
            if (Book_StoreEntities.GetContext().Users.Any(d => d.Login_user == Login))
                errors.AppendLine("Пользователь с таким логином уже существует");

            string str2;
            int i = 0;
            bool boo;
            int yes = 0;
            if (User.Password_user.Length < 6)
                errors.AppendLine("Пароль должен быть длиннее 6 символов");
            str2 = User.Password_user.ToLower();
            if (User.Password_user == str2)
                errors.AppendLine("В пароле должны быть большие буквы");
            char[] array = User.Password_user.ToCharArray();
            while (User.Password_user.Length > i)
            {
                boo = Char.IsDigit(array[i]);
                if (boo == true) yes = yes + 1;
                i = i + 1;
            }
            if (User.Password_user.Length <= yes)
                errors.AppendLine("Пароль должен включать в себя ещё и буквы, большие и маленькие");
            if (yes == 0)
                errors.AppendLine("Пароль должен включать в себя ещё и цифры");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (User.Id_user == 0)
                User.Id_user = maxid + 1;
            Book_StoreEntities.GetContext().Users.Add(User);
            try
            {
                Book_StoreEntities.GetContext().SaveChanges();
                MessageBox.Show("Аккаунт успешно создан! Теперь вы можете успешно авторизоваться.");
                index = User.Id_user;
                /*MainPage win4 = new MainPage();
                win4.Show();
                this.Close();
                */

                login win2 = new login();
                win2.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
