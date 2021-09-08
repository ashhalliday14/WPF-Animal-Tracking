﻿using System;
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

        //private void DataGridViewAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //    Animal animal= new Animal();
        //    string[] AnimalArray;

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Type", typeof(string));
        //    dt.Columns.Add("Category", typeof(string));
        //    dt.Columns.Add("Colour", typeof(string));
        //    dt.Columns.Add("Origin", typeof(string));

        //    using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animal.csv"))
        //    {
        //        while (!reader.EndOfStream)
        //        {
        //            AnimalArray = reader.ReadLine().Split(',');

        //            animal.Type = AnimalArray[0];
        //            animal.Category = AnimalArray[1];
        //            animal.Colour = AnimalArray[2];
        //            animal.Origin = AnimalArray[3];

        //            dt.Rows.Add(AnimalArray);
        //        }
        //        DataView dv = new DataView(dt);
        //        DataGridViewAnimals.ItemsSource = dv;
        //    }
        //}

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

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Animal animal = new Animal();
        //    string[] AnimalArray;s

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Type", typeof(string));
        //    dt.Columns.Add("Category", typeof(string));
        //    dt.Columns.Add("Colour", typeof(string));
        //    dt.Columns.Add("Origin", typeof(string));

        //    using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animal.csv"))
        //    {
        //        while (!reader.EndOfStream)
        //        {
        //            AnimalArray = reader.ReadLine().Split(',');

        //            animal.Type = AnimalArray[0];
        //            animal.Category = AnimalArray[1];
        //            animal.Colour = AnimalArray[2];
        //            animal.Origin = AnimalArray[3];

        //            dt.Rows.Add(AnimalArray);
        //        }
        //        DataView dv = new DataView(dt);
        //        DataGridViewAnimals.ItemsSource = dv;
        //    }
        //}

        private void ClickAnimal(object sender, RoutedEventArgs e)
        {
            Animals animals = new Animals();
            animals.Show();
            this.Close();
        }

        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = new Animal();
            string[] AnimalArray;

            DataTable dt = new DataTable();
            dt.Columns.Add("Animal  Type", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Colour", typeof(string));
            dt.Columns.Add("Origin", typeof(string));

            using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animal.csv"))
            {
                while (!reader.EndOfStream)
                {
                    AnimalArray = reader.ReadLine().Split(',');

                    animal.Type = AnimalArray[0];
                    animal.Category = AnimalArray[1];
                    animal.Colour = AnimalArray[2];
                    animal.Origin = AnimalArray[3];

                    dt.Rows.Add(AnimalArray);
                }
                
                DataView dv = new DataView(dt);
                dgAnimas.ItemsSource = dv;
            }
        }

        private void btnAddData_Click(object sender, RoutedEventArgs e)
        {
            addAnimalPopup.IsOpen = true;
        }

        private void btnEditData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            deleteAnimalPopup.IsOpen = true;
        }

        //add a new animal
        private void AddAnimal(object sender, RoutedEventArgs e)
        {
            //take user input for animals
            string animal = inputAnimalType.Text;
            string category = inputAnimalCategory.Text;
            string colour = inputAnimalColour.Text;
            string origin = inputAnimalOrigin.Text;

            using (StreamWriter writer = new StreamWriter(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animal.csv", true))
            {
                //write the input into the csv
                writer.WriteLine("{0},{1},{2},{3}", animal,category,colour,origin.ToString());

                MessageBox.Show("Animal Added! Click View Animals to Display!");
            }

            //close the popup
            addAnimalPopup.IsOpen = false;
        }

        //delete an animal
        private void DeleteCategory(object sender, RoutedEventArgs e)
        {
            //take user input for animal 
            string category = inputAnimalDelete.Text;
            int columnIndex = 0; //index of the field that contains the animal type
            char separatorChar = ','; //values separated by a ,

            var lines = new List<string[]>(); //csv so it has multiple columns

            //read in the file
            using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animal.csv"))
            {

                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine().Split(separatorChar)); //adding the files content line-by-line and split by the separator character
                }
            }

            foreach (var line in lines) //iterate through the lines
            {
                if (line[columnIndex] == category) //check category equals what user entered
                {
                    line[columnIndex] = string.Empty; //delete content if this is true
                    line[1] = string.Empty;
                    line[2] = string.Empty;
                    line[3] = string.Empty;
                    MessageBox.Show("Animal Deleted!");
                }
                else
                {
                    MessageBox.Show("Animal could not be deleted.");
                }
            }

            using (var writer = new StreamWriter(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animal.csv")) //write back to the file
            {
                foreach (var item in lines)
                {
                    writer.WriteLine(string.Join(separatorChar.ToString(), item)); //convert string[] to string (line)
                }
            }

            //close the popup
            deleteAnimalPopup.IsOpen = false;
        }
    }
}
