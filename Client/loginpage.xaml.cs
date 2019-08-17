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
    /// Логика взаимодействия для loginpage.xaml
    /// </summary>
    public partial class loginpage : Window
    {
        public loginpage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string response = "";
            MainWindow.Transfer.log.password = passfield.Text;
            MainWindow.Transfer.log.username = Username.Text;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:59735/api/values/auth");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(MainWindow.Transfer.log);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                response = result;
            }
            MainWindow.Transfer.log.access = response.ToString();
            this.Close();
        }
    }
}
