using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace wpfAuth
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string tLogin = "admin";
        private string tPassword = "admin";
        private int attempCount = 3;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_auth_Click(object sender, RoutedEventArgs e)
        {
            string login = tb_login.Text;
            string password = tb_password.Password;

            if (login == tLogin && password == tPassword)
            {
                MessageBox.Show("Доступ разрешён!", "Авторизация");
                Window window = new personalData();
                window.Show();
                this.Close();
            }
            else
            {
                if (attempCount <= 1)
                {
                    MessageBox.Show("Доступ запрещён! Неверный логин или пароль, количество попыток авторизации исчерпано производиться блокировка приложения на 5 секунд");
                    tb_login.IsEnabled = false;
                    tb_password.IsEnabled = false;
                    bt_auth.IsEnabled = false;
                    timer = new DispatcherTimer()
                    {
                        Interval = TimeSpan.FromSeconds(5)
                    };
                    timer.Tick += Timer_Tick;
                    timer.Start();
                }
                else
                {
                    attempCount--;
                    MessageBox.Show($"Доступ запрещён! Неверный логин или пароль, количество оставшихся попыток авторизации до блокировани приложения:{attempCount}", "Авторизация");
                }
                
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            attempCount = 3;
            tb_login.IsEnabled = true;
            tb_password.IsEnabled = true;
            bt_auth.IsEnabled = true;
            MessageBox.Show("Приложение разблокировано", "Авторизация");
        }

        
    }
}
