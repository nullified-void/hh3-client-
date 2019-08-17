using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для add_page.xaml
    /// </summary>
    public partial class add_page : Window
    {
        public add_page()
        {
            
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FirstName.Text == string.Empty || 
                SecondName.Text == string.Empty || 
                LastName.Text == string.Empty || 
                DateOfB.Text == string.Empty)
                return;
            MainWindow.Transfer.transferuser.FirstName = FirstName.Text;
            MainWindow.Transfer.transferuser.SecondName = SecondName.Text;
            MainWindow.Transfer.transferuser.LastName = LastName.Text;
            MainWindow.Transfer.transferuser.DateOfB = DateOfB.Text;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:59735/api/values/add");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(MainWindow.Transfer.transferuser);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            this.Close();
        }
    }
}
