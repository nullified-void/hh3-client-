using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using Newtonsoft.Json;
using System.IO;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для editdialog.xaml
    /// </summary>
    public partial class editdialog : Window
    {
        public editdialog(User user)
        {

            InitializeComponent();
            textboxid.IsReadOnly = true;
            FirstNameOLD.IsReadOnly = true;
            SecondNameOLD.IsReadOnly = true;
            LastNameOLD.IsReadOnly = true;
            textboxid.Text = user.id;
            FirstNameOLD.Text = user.FirstName;
            SecondNameOLD.Text = user.SecondName;
            LastNameOLD.Text = user.LastName;
            DateOfBOLD.Text = user.DateOfB;
            FirstNameNEW.Text = user.FirstName;
            SecondNameNEW.Text = user.SecondName;
            LastNameNEW.Text = user.LastName;
            DateOfBNEW.Text = user.DateOfB;
            

        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            User editeduser = new User();
            editeduser.id = textboxid.Text;
            editeduser.FirstName = FirstNameNEW.Text;
            editeduser.SecondName = SecondNameNEW.Text;
            editeduser.LastName = LastNameNEW.Text;
            editeduser.DateOfB = DateOfBNEW.Text;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(MainWindow.Transfer.api.edit);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(editeduser);

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            MainWindow.Transfer.transferuser = editeduser;
            
            this.Close();
        }
    }
}
