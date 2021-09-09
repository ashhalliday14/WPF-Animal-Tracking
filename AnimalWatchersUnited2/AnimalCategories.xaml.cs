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

        public void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            AnimalCategory animalCategory = new AnimalCategory();
            string[] CategoryArray;

            DataTable dt = new DataTable();
            dt.Columns.Add("Animal Category", typeof(string));

            using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animalcategory.csv"))
            {
                while (!reader.EndOfStream)
                {
                    CategoryArray = reader.ReadLine().Split(',');

                    animalCategory.Category = CategoryArray[0];

                    dt.Rows.Add(CategoryArray);
                }
                DataView dv = new DataView(dt);
                dgAnimalCategories.ItemsSource = dv;
            }
        }

        //click add category
        private void btnAddData_Click(object sender, RoutedEventArgs e)
        {
            addCategoryPopup.IsOpen = true;  
        }

        //click edit category
        private void btnEditData_Click(object sender, RoutedEventArgs e)
        {
            editCategoryPopup.IsOpen = true;
        }

        //click delete category
        private void btnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            deleteCategoryPopup.IsOpen = true;
        }

        //add category popup
        private void AddCategory(object sender, RoutedEventArgs e)
        {
            //take user input for animal category
            string category = inputCategory.Text;

            using (StreamWriter writer = new StreamWriter(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animalcategory.csv", true))
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
            char separatorChar = ','; //values separated by a ,

            var lines = new List<string[]>(); //csv so it has multiple columns

            //read in the file
            using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animalcategory.csv"))
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

            using (var writer = new StreamWriter(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animalcategory.csv")) //write back to the file
            {
                foreach (var item in lines)
                {
                    writer.WriteLine(string.Join(separatorChar.ToString(), item)); //convert string[] to string (line)
                }
            }

            //close the popup
            addCategoryPopup.IsOpen = false;

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

        //edit category popup
        private void EditCategory(object sender, RoutedEventArgs e)
        {
            //take user input for existing and edited category
            string oldCategory = inputEditCategory.Text;
            string newCategory = inputNewCategory.Text;

            List<String> lines = new List<String>(); //create a new list

            //read in csv file
            using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animalcategory.csv"))
            {
                String line;

                while ((line = reader.ReadLine()) != null)
                {
                    for(int i = 0; i < lines.Count; i++)
                    {
                        String[] split = line.Split(','); //split lines with comma

                        if (split[0].Contains(oldCategory)) //chck line contains category entered
                        {
                            split[0] = newCategory;
                            line = String.Join(",", split);
                        }
                    }

                    lines.Add(line); //add new category to list
                }
            }
            //write to csv
            using (StreamWriter writer = new StreamWriter(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animalcategory.csv", false))
            {
                foreach (String line in lines)
                    writer.WriteLine(line); //write the new category to the csv file
            }
            editCategoryPopup.IsOpen = false;
        }
    }
}
