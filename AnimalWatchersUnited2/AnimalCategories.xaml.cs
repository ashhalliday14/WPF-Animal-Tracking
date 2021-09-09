using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
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
using Microsoft.Win32;

namespace AnimalWatchersUnited2
{
    /// <summary>
    /// Interaction logic for AnimalCategories.xaml
    /// </summary>
    public partial class AnimalCategories : Window
    {
        public AnimalCategories()
        {
            InitializeComponent();
        }

        //filepath for animal categories csv
        string filepath = @"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animalcategory.csv";

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
            //open up the sightings page
            Sightings sightings = new Sightings();
            sightings.Show();
            this.Close();
        }

        //click wishlists button
        private void ClickWishlists(object sender, RoutedEventArgs e)
        {
            //open up the wishlist page
            Wishlists wishlist = new Wishlists();
            wishlist.Show();
            this.Close();
        }

        //click add category
        private void btnAddData_Click(object sender, RoutedEventArgs e)
        {
            //display the add category popup
            addCategoryPopup.IsOpen = true;
        }

        //click edit category
        private void btnEditData_Click(object sender, RoutedEventArgs e)
        {
            //display the adit category popup
            editCategoryPopup.IsOpen = true;
        }

        //click delete category
        private void btnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            //display delete category popup
            deleteCategoryPopup.IsOpen = true;
        }

        //user clicks on view categories
        public void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            AnimalCategory animalCategory = new AnimalCategory(); //create new instance of animal category
            string[] CategoryArray; //create a category array

            DataTable dt = new DataTable(); //instance of the datatable
            dt.Columns.Add("Animal Category", typeof(string)); //add a header in the datatable

            //read in the animal category csv file
            using (StreamReader reader = new StreamReader(filepath))
            {
                while (!reader.EndOfStream)
                {
                    CategoryArray = reader.ReadLine().Split(','); //split the data by commas

                    animalCategory.Category = CategoryArray[0]; //animal category is in position 0

                    dt.Rows.Add(CategoryArray); //add data to the category array
                }
                DataView dv = new DataView(dt); //fill data table with data from array
                dgAnimalCategories.ItemsSource = dv; //display the data in the data table
            }
        }

        //add category popup
        private void AddCategory(object sender, RoutedEventArgs e)
        {
            //take user input for animal category
            string category = inputCategory.Text;

            //read in the animal category csv file and allow user to write to it
            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                //write the input into the csv
                writer.WriteLine(category);

                MessageBox.Show("Animal Category Added! Click View Animal Category to Display!");
            }
            //close the popup
            addCategoryPopup.IsOpen = false;
        }

        //delete an animal cateogry popup
        private void DeleteCategory(object sender, RoutedEventArgs e)
        {
            //take user input for animal category
            string category = inputCategoryDelete.Text;
            int columnIndex = 0; //index of the field that contains the categories
            char separatorChar = ','; //values separated by a comma

            var lines = new List<string[]>(); //create a new list

            //read in the animal categories file
            using (StreamReader reader = new StreamReader(filepath))
            {         
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine().Split(separatorChar)); //adding the files content line-by-line and split by the separator character
                }
            }

            foreach (var line in lines) //iterate through the lines
            {
                if (line[columnIndex] == category) //check category equals what user entered
                    line[columnIndex] = string.Empty; //delete content if this is true
            }

            using (var writer = new StreamWriter(filepath)) //write back to the file
            {
                foreach (var item in lines)
                {
                    writer.WriteLine(string.Join(separatorChar.ToString(), item)); //convert string[] to string (line)
                }
            }
            //close the popup
            addCategoryPopup.IsOpen = false;
        }

        //edit category popup
        private void EditCategory(object sender, RoutedEventArgs e)
        {
            //take user input for existing and edited category
            string oldCategory = inputEditCategory.Text;
            string newCategory = inputNewCategory.Text;

            List<String> lines = new List<String>(); //create a new list

            //read in csv file
            using (StreamReader reader = new StreamReader(filepath))
            {
                String line;

                while ((line = reader.ReadLine()) != null) //check like is not null
                {
                    String[] split = line.Split(','); //split lines with comma

                    if (split[0].Contains(oldCategory)) //chck line contains category entered
                    {
                        split[0] = newCategory; //category is in position 0
                        line = String.Join(",", split); //split with a comma
                    }

                    lines.Add(line); //add new category to list
                }
            }
            //write to csv
            using (StreamWriter writer = new StreamWriter(filepath, false))
            {
                foreach (String line in lines)
                    writer.WriteLine(line); //write the new category to the csv file
            }
            //close the edit category popup
            editCategoryPopup.IsOpen = false;
        }
    }
}
