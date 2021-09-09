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
    /// Interaction logic for Wishlists.xaml
    /// </summary>
    public partial class Wishlists : Window
    {
        public Wishlists()
        {
            InitializeComponent();
        }

        //click logout button
        private void ClickLogout(object sender, RoutedEventArgs e)
        {
            //close homepage and open login screen
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //click main menu button
        private void ClickMainMenu(object sender, RoutedEventArgs e)
        {
            //return user to homepage/main menu
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Close();
        }

        //click animals button
        private void ClickAnimal(object sender, RoutedEventArgs e)
        {
            //open up animal page
            Animals animals = new Animals();
            animals.Show();
            this.Close();
        }

        //click sightings button
        private void ClickSightings(object sender, RoutedEventArgs e)
        {
            Sightings sightings = new Sightings();
            sightings.Show();
            this.Close();
        }

        //click wishlists button
        private void ClickWishlists(object sender, RoutedEventArgs e)
        {
            Wishlists wishlist = new Wishlists();
            wishlist.Show();
            this.Close();
        }

        //click animal categories button
        private void ClickAnimalCategories(object sender, RoutedEventArgs e)
        {
            AnimalCategories categories = new AnimalCategories();
            categories.Show();
            this.Close();
        }

        //user clicks view wishlist
        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            EnterUsernamePopup.IsOpen = true;
        }

        private void ViewSightings(object sender, RoutedEventArgs e)
        {
            string username = inputUsername.Text;

            Wishlist wishlist = new Wishlist();
            string[] WishlistArray;
            var wishlists = new List<string[]>();

            DataTable dt = new DataTable();
            dt.Columns.Add("User", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Colour", typeof(string));
            dt.Columns.Add("Size", typeof(string));
            dt.Columns.Add("Sex", typeof(string));

            using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\wishlists.csv"))
            {
                while (!reader.EndOfStream)
                {
                    WishlistArray = reader.ReadLine().Split(',');

                    foreach (var wish in wishlists)
                    {
                        if (wishlist.Username == username)
                        {
                            MessageBox.Show(wishlist.Username);
                            wishlist.Username = WishlistArray[0];
                            wishlist.Type = WishlistArray[1];
                            wishlist.Category = WishlistArray[2];
                            wishlist.Colour = WishlistArray[3];
                            wishlist.Size = WishlistArray[4];
                            wishlist.Sex = WishlistArray[5];
                            continue;
                        }
                        else
                        {
                            MessageBox.Show("No Wishlist for this User");
                        }
                    }

                    dgWishlists.Columns.Count();
                    WishlistArray.Count();

                    dt.Rows.Add(WishlistArray);

                    DataView dv = new DataView(dt);
                    dgWishlists.ItemsSource = dv;
                }
                EnterUsernamePopup.IsOpen = false;
            }
        }

        //user clicks on add wishlist button
        private void btnAddData_Click(object sender, RoutedEventArgs e)
        {
            //open popup to add wishlist item
            addWishlistPopup.IsOpen = true;
        }

        //user clicks on edit wishlist button
        private void btnEditData_Click(object sender, RoutedEventArgs e)
        {
            //open the edit wishlist popup
            editWishlistPopup.IsOpen = true;
        }

        private void btnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            deleteWishlistPopup.IsOpen = true;
        }

        //add wishlist popup
        private void AddWishlist(object sender, RoutedEventArgs e)
        {
            //take user input
            string user = inputUser.Text;
            string animal = inputAnimal.Text;
            string category = inputCategory.Text;
            string colour = inputColour.Text;
            string size = inputSize.Text;
            string sex = inputSex.Text;

            //allow details to be input into csv file
            using (StreamWriter writer = new StreamWriter(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\wishlists.csv", true))
            {
                //write the input into the csv
                writer.WriteLine("{0},{1},{2},{3},{4},{5}", user, animal, category, colour, size, sex.ToString());

                MessageBox.Show("Wishlist Added! Click View Signtings to Display!");
            }

            //close the popup
            addWishlistPopup.IsOpen = false;
        }

        //the edit wishlist popup
        private void EditWishlist(object sender, RoutedEventArgs e)
        {
            //get user input
            string username = inputUsername1.Text;
            string oldAnimal = inputOldAnimal.Text;
            string animal = inputNewAnimal.Text;
            string category = inputNewCategory.Text;
            string colour = inputNewColour.Text;
            string size = inputNewSize.Text;
            string sex = inputNewSex.Text;

            List<String> lines = new List<String>(); //create a new list

            //read in csv file
            using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\wishlists.csv"))
            {
                String line;

                while ((line = reader.ReadLine()) != null)
                {
                    String[] split = line.Split(','); //split lines with comma

                    if (split[0].Contains(username)) //check line contains animal entered
                    {
                        if (split[1].Contains(oldAnimal))
                        {
                            //add new wishlist details
                            split[0] = username;
                            split[1] = animal;
                            split[2] = category;
                            split[3] = colour;
                            split[4] = size;
                            split[5] = sex;
                            line = String.Join(",", split);
                        }
                    }

                    lines.Add(line); //add new animal to list
                }
            }
            //write to csv
            using (StreamWriter writer = new StreamWriter(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\wishlists.csv", false))
            {
                foreach (String line in lines)
                {
                    writer.WriteLine(line); //write the new sighting to the csv file
                }

            }
            editWishlistPopup.IsOpen = false;
        }

        private void DeleteWishlist(object sender, RoutedEventArgs e)
        {
            //take user input for animal 
            string animal = inputAnimalDelete.Text;
            int columnIndex = 1; //index of the field that contains the animal type
            char separatorChar = ','; //values separated by a ,

            var lines = new List<string[]>(); //csv so it has multiple columns

            //read in the file
            using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\wishlists.csv"))
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
                    MessageBox.Show("Animal Sighting Deleted!");
                }
                else
                {
                    MessageBox.Show("Animal could not be deleted.");
                }
            }

            using (var writer = new StreamWriter(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\wishlists.csv")) //write back to the file
            {
                foreach (var item in lines)
                {
                    writer.WriteLine(string.Join(separatorChar.ToString(), item)); //convert string[] to string (line)
                }
            }

            //close the popup
            deleteWishlistPopup.IsOpen = false;
        }
    }
}
