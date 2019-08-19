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
using System.IO;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int currentPage = 1;
        public int pagesCount;
        public List<User> userlist = new List<User>();
        
        
        public int n = -10;
        public class Transfer
        {
            public static logininfo log = new logininfo();
            public static User transferuser = new User();
            public static APIs api = new APIs();
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void DataGrid_Initialized(object sender, EventArgs e)
        {
            using (var wb = new WebClient())
            {
                Transfer.api = JsonConvert.DeserializeObject<APIs>(File.ReadAllText("APIs.txt"));
                var data = new NameValueCollection();
                var response = wb.UploadValues(Transfer.api.get, "POST", data);
                string responseInString = Encoding.UTF8.GetString(response);
                userlist.AddRange(JsonConvert.DeserializeObject<List<User>>(responseInString));
                BtnNEXT_Click(null, null);
                foreach (DataGridColumn column in DataGrid.Columns)
                {
                    column.Width = new DataGridLength(1.0, DataGridLengthUnitType.Star);
                }
            }
        }

        private void BtnNEXT_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage == pagesCount)
                return;
            else
                if(sender != null)
                    currentPage++;
            if (label1 != null)
                label1.Content = Convert.ToString(currentPage.ToString() + '\\' + pagesCount.ToString());
            n += 10;

            var PageElem = userlist.OrderBy(i => i.id).Skip(n).Take(10);
            DataGrid.ItemsSource = PageElem; 
        }

        private void Label1_Initialized(object sender, EventArgs e)
        {
            if (userlist.Count % 10 == 0)
                pagesCount = userlist.Count / 10;
            else
                pagesCount = userlist.Count / 10 + 1;
            label1.Content = Convert.ToString(currentPage.ToString() + '\\' + pagesCount.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (currentPage ==  1)
                return;
            else
                if (sender != null)
                currentPage--;
            if (label1 != null)
                label1.Content = Convert.ToString(currentPage.ToString() + '\\' + pagesCount.ToString());
            n -= 10;
            var PageElem = userlist.OrderBy(i => i.id).Skip(n).Take(10);
            DataGrid.ItemsSource = PageElem; 
        }

        private void DataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (Transfer.log.access == "user")
            {
                MessageBox.Show("Недостаточно прав для осуществения действия", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (Transfer.log.access == null)
            {
                MessageBox.Show("Вы должны зайти в сеть для осуществления данного действия", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (DataGrid.SelectedItem == null)
                return;

            User useredit = (User)DataGrid.SelectedItem;
            if (useredit.id == null)
            {
                MessageBox.Show("Пожалуйста, перезапустите приложение для изменения добавленных в этой сессии работников.", "Требуется перезапуск", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            editdialog dialog = new editdialog(useredit);
            dialog.ShowDialog();
            if (Transfer.transferuser.FirstName != null)
            userlist.FindAll(s => s.id == Transfer.transferuser.id).ForEach(x =>
            {
                x.FirstName = Transfer.transferuser.FirstName;
                x.SecondName = Transfer.transferuser.SecondName;
                x.LastName = Transfer.transferuser.LastName;
                x.DateOfB = Transfer.transferuser.DateOfB;
            }
            );
            Transfer.transferuser.id = null;
            DataGrid.Items.Refresh();

        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (Transfer.log.access == "user")
            {
                MessageBox.Show("Недостаточно прав для осуществения действия", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (Transfer.log.access == null)
            {
                MessageBox.Show("Вы должны зайти в сеть для осуществления данного действия", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            add_page addpage = new add_page();
            addpage.ShowDialog();
            if (Transfer.transferuser.FirstName != null)
                userlist.Add(MainWindow.Transfer.transferuser);
            DataGrid.Items.Refresh();
            BtnNEXT_Click(this, null);
            Button_Click(this, null);
            
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            if (Transfer.log.access == "user")
            {
                MessageBox.Show("Недостаточно прав для осуществения действия", "Ошибка", MessageBoxButton.OK,MessageBoxImage.Exclamation);
                return;
            }
            if (Transfer.log.access == null)
            {
                MessageBox.Show("Вы должны зайти в сеть для осуществления данного действия", "Ошибка", MessageBoxButton.OK,MessageBoxImage.Exclamation);
                return;
            }
            if (DataGrid.SelectedItem == null)
                return;
            User userdelete = (User)DataGrid.SelectedItem;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Transfer.api.delete);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(userdelete);

                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            userlist.Remove(userdelete);
            DataGrid.Items.Refresh();
            BtnNEXT_Click(this,null);
            Button_Click(this,null);
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            loginpage log = new loginpage();
            log.ShowDialog();
            if (Transfer.log.access == null)
                return;
            if (Transfer.log.access == "admin")
                loginstatus.Content = "Вы зашли как admin.";
            if (Transfer.log.access == "user")
                loginstatus.Content = "Вы зашли как user.";
            logoutBTN.IsEnabled = true;
            loginBTN.IsEnabled = false;
            userinfo.IsEnabled = true;

        }

        private void LogoutBTN_Click(object sender, RoutedEventArgs e)
        {
            Transfer.log.access = null;
            loginstatus.Content = "Вы не в сети.";
            loginBTN.IsEnabled = true;
            userinfo.IsEnabled = false;
            logoutBTN.IsEnabled = false;
        }

        private void Userinfo_Click(object sender, RoutedEventArgs e)
        {
            userinfo info = new userinfo();
            info.ShowDialog();
        }

        private void Userinfo_Initialized(object sender, EventArgs e)
        {
            userinfo.IsEnabled = false;
        }

        private void LogoutBTN_Initialized(object sender, EventArgs e)
        {
            logoutBTN.IsEnabled = false;
        }

        private void SearchBTN_Click(object sender, RoutedEventArgs e)
        {
            var filtered = userlist.Where(search => search.FirstName.StartsWith(searchFirstName.Text) &&
            search.SecondName.StartsWith(searchSecondName.Text) &&
            search.LastName.StartsWith(searchLastName.Text) &&
            search.DateOfB.StartsWith(searchDateOfB.Text));

            DataGrid.ItemsSource = filtered;
        }

        private void CanselBTN_Click(object sender, RoutedEventArgs e)
        {
            searchFirstName.Text = "";
            searchSecondName.Text = "";
            searchLastName.Text = "";
            searchDateOfB.Text = "";
            BtnNEXT_Click(this, null);
            Button_Click(this, null);
        }
    }
}
