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
    /// Interaction logic for Animals.xaml
    /// </summary>
    public partial class Animals : Window
    {
        public Animals()
        {
            InitializeComponent();
        }

        //filepath for animal file
        string filepath = @"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animal.csv";

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

        //user clicks add animal button
        private void btnAddData_Click(object sender, RoutedEventArgs e)
        {
            //direct user to add animal popup
            addAnimalPopup.IsOpen = true;
        }

        //user clicks on edit animal button
        private void btnEditData_Click(object sender, RoutedEventArgs e)
        {
            //open edit animal popup
            editAnimalPopup.IsOpen = true;
        }

        //user clicks delete animal button
        private void btnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            //direct user to delete animal popup
            deleteAnimalPopup.IsOpen = true;
        }

        //user clicks view animals
        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = new Animal(); //create a new instance of animal
            string[] AnimalArray; //create an animal array

            DataTable dt = new DataTable(); //new instance of datatable
            //create headers for all columns in datatable
            dt.Columns.Add("Animal  Type", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Colour", typeof(string));
            dt.Columns.Add("Origin", typeof(string));

            //read in animal csv
            using (StreamReader reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    AnimalArray = reader.ReadLine().Split(','); //split lines by a comma

                    //position of all columns within the array
                    animal.Type = AnimalArray[0];
                    animal.Category = AnimalArray[1];
                    animal.Colour = AnimalArray[2];
                    animal.Origin = AnimalArray[3];

                    dt.Rows.Add(AnimalArray); //add data to the array
                }
                
                DataView dv = new DataView(dt); //fill datatable with data from array
                dgAnimas.ItemsSource = dv; //display data in the datatable
            }
        }

        //add a new animal
        private void AddAnimal(object sender, RoutedEventArgs e)
        {
            //take user input for animals
            string animal = inputAnimalType.Text;
            string category = inputAnimalCategory.Text;
            string colour = inputAnimalColour.Text;
            string origin = inputAnimalOrigin.Text;

            //reads in animal csv and allows user to write to it
            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                //write the input into the csv
                writer.WriteLine("{0},{1},{2},{3}", animal,category,colour,origin.ToString());

                MessageBox.Show("Animal Added! Click View Animals to Display!");
            }
            //close the popup
            addAnimalPopup.IsOpen = false;
        }

        //delete an animal
        private void DeleteAnimal(object sender, RoutedEventArgs e)
        {
            //take user input for animal 
            string animal = inputAnimalDelete.Text;
            int columnIndex = 0; //index of the field that contains the animal type
            char separatorChar = ','; //values separated by a comma

            var lines = new List<string[]>(); //create a new ist

            //read in the file
            using (StreamReader reader = new StreamReader(filepath))
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
                    line[1] = string.Empty;
                    line[2] = string.Empty;
                    line[3] = string.Empty;
                    MessageBox.Show("Animal Deleted!");
                }
            }
            //write back to the csv file
            using (var writer = new StreamWriter(filepath)) 
            {
                foreach (var item in lines) //iterate through the lines
                {
                    writer.WriteLine(string.Join(separatorChar.ToString(), item)); //convert string[] to string (line)
                }
            }
            //close the popup
            deleteAnimalPopup.IsOpen = false;
        }

        //edit animal popup
        private void EditAnimal(object sender, RoutedEventArgs e)
        {
            //get user input
            string oldAnimal = inputEditAnimal.Text;
            string newAnimal = inputNewAnimal.Text;
            string category = inputNewCategory.Text;
            string colour = inputNewColour.Text;
            string origin = inputNewOrigin.Text;

            List<String> lines = new List<String>(); //create a new list

            //read in csv file
            using (StreamReader reader = new StreamReader(filepath))
            {
                String line;

                while ((line = reader.ReadLine()) != null) //check lines are not null
                {
                    String[] split = line.Split(','); //split lines with comma

                    if (split[0].Contains(oldAnimal)) //check line contains animal entered
                    {
                        //add new animal details
                        split[0] = newAnimal;
                        split[1] = category;
                        split[2] = colour;
                        split[3] = origin;
                        line = String.Join(",", split); //split with a comma
                    }

                    lines.Add(line); //add new animal to list
                }
            }
            //write to csv
            using (StreamWriter writer = new StreamWriter(filepath, false))
            {
                foreach (String line in lines) //iterate through lines
                {
                    writer.WriteLine(line); //write the new animal to the csv file
                }     
            }
            //close the edit animal popup
            editAnimalPopup.IsOpen = false;
        }
    }
}
