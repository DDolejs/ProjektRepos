using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodGenerator
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Storage st = new Storage();
        public int TotalCalories = 0;
        #region 
        public Food bf = Food.Create(FoodType.Breakfast, "Breakfast", new[] {""}, "", 0);
        public Food br1 = Food.Create(FoodType.Snack, "1st Break", new[] {""}, "", 0);
        public Food lch = Food.Create(FoodType.Lunch, "Lunch", new[] {""}, "", 0);
        public Food br2 = Food.Create(FoodType.Snack, "2nd Break", new[] { "" }, "", 0);
        public Food dnr = Food.Create(FoodType.Dinner, "Dinner", new[] { "" }, "", 0);
        #endregion

        public MainWindow()
        {
            
            InitializeComponent();
            
            Food example = Food.Create(FoodType.Breakfast, "test", new[] { "mouka", "sůl" }, "tohle..tamto...", 150);
            Food example2 = Food.Create(FoodType.Breakfast, "test", new[] { "mouka", "sůl" }, "tohle..tamto...", 150);
            Food example3 = Food.Create(FoodType.Breakfast, "test", new[] { "mouka", "sůl" }, "tohle..tamto...", 150);
            StorageManager.getStorage().Foods.Add(example);
            StorageManager.getStorage().Foods.Add(example2);
            StorageManager.getStorage().Foods.Add(example3);

            StorageManager.save();


            //breakfast.Content = bf.Name;
            //break1.Content = br1.Name;
            //lunch.Content = lch.Name;
            //break2.Content = br2.Name;
            //dinner.Content = dnr.Name;




        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox item in grid.Children.OfType<CheckBox>())
            {
                item.IsEnabled = true;
                item.IsChecked = false;
            }
            foreach (Label item in grid.Children.OfType<Label>())
            {
                item.Foreground = Brushes.Black;
            }
            TotalCalories = 0;
            //bf = st.FindRandomFiltered(FoodType.Breakfast);
            //br1 = st.FindRandomFiltered(FoodType.Snack);
            //lch = st.FindRandomFiltered(FoodType.Lunch);
            //br2 = st.FindRandomFiltered(FoodType.Snack);
            //dnr = st.FindRandomFiltered(FoodType.Dinner);

        }

        private void breakfastCheck_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            breakfastTitle.Foreground = Brushes.DarkGreen;
            breakfast.Foreground = Brushes.DarkGreen;
            cb.IsEnabled = false;
            TotalCalories += bf.CaloryCount;
            
        }

        private void break1Check_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            break1Title.Foreground = Brushes.DarkGreen;
            break1.Foreground = Brushes.DarkGreen;
            cb.IsEnabled = false;
            TotalCalories += br1.CaloryCount;

        }
        private void lunchCheck_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            lunchTitle.Foreground = Brushes.DarkGreen;
            lunch.Foreground = Brushes.DarkGreen;
            cb.IsEnabled = false;
            TotalCalories += lch.CaloryCount;

        }
        private void break2Check_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            break2Title.Foreground = Brushes.DarkGreen;
            break2.Foreground = Brushes.DarkGreen;
            cb.IsEnabled = false;
            TotalCalories += br2.CaloryCount;

        }
        private void dinnerCheck_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            dinnerTitle.Foreground = Brushes.DarkGreen;
            dinner.Foreground = Brushes.DarkGreen;
            cb.IsEnabled = false;
            TotalCalories += dnr.CaloryCount;

        }

    }

    
}
