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

namespace kursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            login win2 = new login();
            win2.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Вы, уверены, что хотите выйти ?", "Выход", MessageBoxButton.YesNo);
            if (Result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            registration win3 = new registration(null);
            win3.Show();
            this.Close();
            //Hide();
        }

        private void btnAdm_Click(object sender, RoutedEventArgs e)
        {
            loginAdm winAdmLog = new loginAdm();
            winAdmLog.Show();
            this.Close();
        }
    }
}
