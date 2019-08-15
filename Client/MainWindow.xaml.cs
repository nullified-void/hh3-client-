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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public response GetResponse;
        public MainWindow()
        {
            InitializeComponent();
        }
        private async Task getinfo()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59735/");
            string url = "http://localhost:59735/api/values/get";
            object n = 0;
            this.GetResponse = await HttpHelper.RequestPostAsync(client, url, n);
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void DataGrid_Initialized(object sender, EventArgs e)
        {
            using (var wb = new WebClient())
            {
                List<User> userlist = new List<User>();
                var data = new NameValueCollection();
                data["username"] = "myUser";
                data["password"] = "myPassword";
                string url = "http://localhost:59735/api/values/get";
                var response = wb.UploadValues(url, "POST", data);
                string responseInString = Encoding.UTF8.GetString(response);
                userlist.AddRange(JsonConvert.DeserializeObject<List<User>>(responseInString));
                
            }
        }
    }
}
