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

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для userinfo.xaml
    /// </summary>
    public partial class userinfo : Window
    {
        public userinfo()
        {
            InitializeComponent();
            username.Content = string.Format("Ваш логин: {0}", MainWindow.Transfer.log.username);
            password.Content = string.Format("Ваш пароль: {0}", MainWindow.Transfer.log.password);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
