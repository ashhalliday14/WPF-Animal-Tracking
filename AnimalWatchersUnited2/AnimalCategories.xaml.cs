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

        //private void ListViewAnimalCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    //create a login list
        //    List<AnimalCategory> category = new List<AnimalCategory>();
        //    using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animalcategory.csv"))
        //    {
        //        //read the first line of csv as a header
        //        var header = reader.ReadLine();

        //        while (!reader.EndOfStream)
        //        {
        //            var line = reader.ReadLine();
        //            var values = line.Split(',');

        //            AnimalCategory c = new AnimalCategory();

        //            c.Id = values[0];
        //            c.Category = values[1];

        //            category.Add(c);
        //        }
        //        foreach (AnimalCategory c in category)
        //        {
        //            Console.WriteLine(c.Category);
        //        }
        //    }
        //}

        ////private void DisplayAnimalCategories_Click(object sender, RoutedEventArgs e)
        ////{
        ////    //create a login list
        ////    List<AnimalCategory> category = new List<AnimalCategory>();
        ////    using (StreamReader reader = new StreamReader(@"C:\Users\ashle\OneDrive\Documents\Uni\Level 5\Object Orientated Programming\Practical\CSV Files\animalcategory.csv"))
        ////    {
        ////        //read the first line of csv as a header
        ////        var header = reader.ReadLine();

        ////        while (!reader.EndOfStream)
        ////        {
        ////            var line = reader.ReadLine();
        ////            var values = line.Split(',');

        ////            AnimalCategory c = new AnimalCategory();

        ////            c.Id = values[0];
        ////            c.Category = values[1];

        ////            category.Add(c);
        ////        }
        ////        foreach (AnimalCategory c in category)
        ////        {
        ////            MessageBox.Show(c.Category);
        ////        }
        ////    }
        ////}

        private void Window_Loaded(object sender, RoutedEventArgs e)
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
                DataGridViewAnimalCategories.ItemsSource = dv;
            }
        }

        private void ClickAnimal(object sender, RoutedEventArgs e)
        {
            Animals animals = new Animals();
            animals.Show();
            this.Close();
        }
    }
}
