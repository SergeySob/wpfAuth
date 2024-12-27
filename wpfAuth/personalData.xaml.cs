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

namespace wpfAuth
{
    /// <summary>
    /// Логика взаимодействия для personalData.xaml
    /// </summary>
    public partial class personalData : Window
    {
        public personalData()
        {
            InitializeComponent();
        }

        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Window window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
