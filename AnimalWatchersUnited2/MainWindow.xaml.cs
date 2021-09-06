using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
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

namespace AnimalWatchersUnited2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //user clicks login
        private void ClickLogin(object sender, RoutedEventArgs e)
        {
            //store username and password variables
            string username = EnterUsername.Text;
            string password = EnterPassword.Password;

            //create a login list
            List<Login> login = new List<Login>();

            //pull in the login csv file
            using(StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\login.csv"))
            {
                //read the first line of csv as a header
                var header = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    //read first like as header and separate by commas
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    Login l = new Login();

                    //username and password value positions
                    l.Username = values[1];
                    l.Password = values[2];

                    login.Add(l);
                }

                //loop through all login data in csv 
                foreach (Login l in login)
                {
                    //if username and password match csv
                    if (username == l.Username && password == l.Password)
                    {
                        //direct user to homepage
                        Homepage homepage = new Homepage();
                        homepage.Show();
                        this.Close();
                        break;
                    }
                    else if (username == null)
                    {
                        MessageBox.Show("Please enter a username");
                        continue;
                    }
                    else if (password == null)
                    {
                        MessageBox.Show("Please enter a username");
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
