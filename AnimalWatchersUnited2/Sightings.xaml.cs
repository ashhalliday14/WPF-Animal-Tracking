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

                    dgSightings.Columns.Count();
                    SightingArray.Count();

                    dt.Rows.Add(SightingArray);

                    DataView dv = new DataView(dt);
                    dgSightings.ItemsSource = dv;
                }
                EnterUsernamePopup.IsOpen = false;
            }
        }

        //user clicks view sightings
        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            //display the popup to enter username
            EnterUsernamePopup.IsOpen = true;
        }

        //user clicks add a sighting
        private void btnAddData_Click(object sender, RoutedEventArgs e)
        {
            //display popup to add a sighting
            addSightingPopup.IsOpen = true;
        }

        //user clicks edit a sighting
        private void btnEditData_Click(object sender, RoutedEventArgs e)
        {
            //display the edit a sighting popup
            editSightingPopup.IsOpen = true;
        }

        private void btnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            deleteSightingPopup.IsOpen = true;
        }

        //click wishlist button
        private void ClickWishlists(object sender, RoutedEventArgs e)
        {
            Wishlists wishlist = new Wishlists();
            wishlist.Show();
            this.Close();
        }

        //add a new sighting button
        private void AddSighting(object sender, RoutedEventArgs e)
        {
            //take user input
            string user = inputUser.Text;
            string animal = inputAnimal.Text;
            string category = inputCategory.Text;
            string colour = inputColour.Text;
            string origin = inputOrigin.Text;
            string location = inputLocation.Text;
            string size = inputSize.Text;
            string sex = inputSex.Text;

            //allow details to be input into csv file
            using (StreamWriter writer = new StreamWriter(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\sightings.csv", true))
            {
                //write the input into the csv
                writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", user, animal, category, colour, origin, location, size, sex.ToString());

                MessageBox.Show("Signting Added! Click View Signtings to Display!");
            }

            //close the popup
            addSightingPopup.IsOpen = false;
        }

        private void EditSighting(object sender, RoutedEventArgs e)
        {
            //get user input
            string username = inputUsername1.Text;
            string oldAnimal = inputOldAnimal.Text;
            string animal = inputNewAnimal.Text;
            string category = inputNewCategory.Text;
            string colour = inputNewColour.Text;
            string origin = inputNewOrigin.Text;
            string location = inputNewLocation.Text;
            string size = inputNewSize.Text;
            string sex = inputNewSex.Text;

            List<String> lines = new List<String>(); //create a new list

            //read in csv file
            using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\sightings.csv"))
            {
                String line;

                while ((line = reader.ReadLine()) != null)
                {
                    String[] split = line.Split(','); //split lines with comma

                    if (split[0].Contains(username)) //check line contains animal entered
                    {
                        if (split[1].Contains(oldAnimal))
                        {
                            //add new animal details
                            split[0] = username;
                            split[1] = animal;
                            split[2] = category;
                            split[3] = colour;
                            split[4] = origin;
                            split[5] = location;
                            split[6] = size;
                            split[7] = sex;
                            line = String.Join(",", split);
                        }  
                    }

                    lines.Add(line); //add new animal to list
                }
            }
            //write to csv
            using (StreamWriter writer = new StreamWriter(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\sightings.csv", false))
            {
                foreach (String line in lines)
                {
                    writer.WriteLine(line); //write the new sighting to the csv file
                }

            }
            editSightingPopup.IsOpen = false;
        }

        private void DeleteSighting(object sender, RoutedEventArgs e)
        {
            //take user input for animal 
            string animal = inputAnimalDelete.Text;
            int columnIndex = 1; //index of the field that contains the animal type
            char separatorChar = ','; //values separated by a ,

            var lines = new List<string[]>(); //csv so it has multiple columns

            //read in the file
            using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\sightings.csv"))
            {

                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine().Split(separatorChar)); //adding the files content line-by-line and split by the separator character
                }
            }

            foreach (var line in lines) //iterate through the lines
            {
                if (line[columnIndex] == animal) //check category equals what user entered
                {
                    line[columnIndex] = string.Empty; //delete content if this is true
                    line[0] = string.Empty;
                    line[2] = string.Empty;
                    line[3] = string.Empty;
                    line[4] = string.Empty;
                    line[5] = string.Empty;
                    line[6] = string.Empty;
                    line[7] = string.Empty;
                    MessageBox.Show("Animal Sighting Deleted!");
                }
                else
                {
                    MessageBox.Show("Animal could not be deleted.");
                }
            }

            using (var writer = new StreamWriter(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\sightings.csv")) //write back to the file
            {
                foreach (var item in lines)
                {
                    writer.WriteLine(string.Join(separatorChar.ToString(), item)); //convert string[] to string (line)
                }
            }

            //close the popup
            deleteSightingPopup.IsOpen = false;
        }
    }
}
