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

        private void DataGridViewAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Animal animal= new Animal();
            string[] AnimalArray;

            DataTable dt = new DataTable();
            dt.Columns.Add("Type", typeof(string));
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
                DataGridViewAnimals.ItemsSource = dv;
            }
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

        //click animal categories button
        private void ClickAnimalCategories(object sender, RoutedEventArgs e)
        {
            AnimalCategories categories = new AnimalCategories();
            categories.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Animal animal = new Animal();
            string[] AnimalArray;

            DataTable dt = new DataTable();
            dt.Columns.Add("Type", typeof(string));
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
                DataGridViewAnimals.ItemsSource = dv;
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
