using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

namespace AnimalWatchersUnited2
{
    /// <summary>
    /// Interaction logic for Sightings.xaml
    /// </summary>
    public partial class Sightings : Window 
    {
        public Sightings()
        {
            InitializeComponent();
        }

        //click main menu button
        private void ClickMainMenu(object sender, RoutedEventArgs e)
        {
            //return user to homepage/main menu
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Close();
        }

        //click animal categories button
        private void ClickAnimalCategories(object sender, RoutedEventArgs e)
        {
            AnimalCategories categories = new AnimalCategories();
            categories.Show();
            this.Close();
        }

        //click animal button
        private void ClickAnimal(object sender, RoutedEventArgs e)
        {
            Animals animals = new Animals();
            animals.Show();
            this.Close();
        }

        //click logout button
        private void ClickLogout(object sender, RoutedEventArgs e)
        {
            //close homepage and open login screen
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //click sightings button
        private void ClickSightings(object sender, RoutedEventArgs e)
        {
            Sightings sightings = new Sightings();
            sightings.Show();
            this.Close();
        }

        private void ViewSightings(object sender, RoutedEventArgs e)
        {
            string username = inputUsername.Text;

            Sighting sighting = new Sighting();
            string[] SightingArray;
            var sightings = new List<string[]>();

            DataTable dt = new DataTable();
            dt.Columns.Add("User", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Colour", typeof(string));
            dt.Columns.Add("Origin", typeof(string));
            dt.Columns.Add("Location", typeof(string));
            dt.Columns.Add("Size", typeof(string));
            dt.Columns.Add("Sex", typeof(string));

            using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\sightings.csv"))
            {
                while (!reader.EndOfStream)
                {
                    SightingArray = reader.ReadLine().Split(',');

                    foreach (var sight in sightings)
                    {
                        if (sighting.Username == username)
                        {
                            MessageBox.Show(sighting.Username);
                            sighting.Username = SightingArray[0];
                            sighting.Type = SightingArray[1];
                            sighting.Category = SightingArray[2];
                            sighting.Colour = SightingArray[3];
                            sighting.Origin = SightingArray[4];
                            sighting.SightingLocation = SightingArray[5];
                            sighting.Size = SightingArray[6];
                            sighting.Sex = SightingArray[7];
                            continue;
                        }
                        else
                        {
                            MessageBox.Show("No Sightings for this User");
                        }
                    }
                    //if (username == SightingArray[0])
                    //{
                    //    sighting.Username = SightingArray[0];
                    //    sighting.Type = SightingArray[1];
                    //    sighting.Category = SightingArray[2];
                    //    sighting.Colour = SightingArray[3];
                    //    sighting.Origin = SightingArray[4];
                    //    sighting.SightingLocation = SightingArray[5];
                    //    sighting.Size = SightingArray[6];
                    //    sighting.Sex = SightingArray[7];
                    //}
                    //sighting.Username = SightingArray[0];
                    //sighting.Type = SightingArray[1];
                    //sighting.Category = SightingArray[2];
                    //sighting.Colour = SightingArray[3];
                    //sighting.Origin = SightingArray[4];
                    //sighting.SightingLocation = SightingArray[5];
                    //sighting.Size = SightingArray[6];
                    //sighting.Sex = SightingArray[7];

                    dgSightings.Columns.Count();
                    SightingArray.Count();

                    dt.Rows.Add(SightingArray);

                    DataView dv = new DataView(dt);
                    dgSightings.ItemsSource = dv;
                }
                EnterUsernamePopup.IsOpen = false;
            }
        }

        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            EnterUsernamePopup.IsOpen = true;
        }

        private void btnAddData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteData_Click(object sender, RoutedEventArgs e)
        {

        }

        //click wishlist button
        private void ClickWishlists(object sender, RoutedEventArgs e)
        {
            Wishlists wishlist = new Wishlists();
            wishlist.Show();
            this.Close();
        }
    }
}
