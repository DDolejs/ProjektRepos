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
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace FoodGenerator
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public int TotalCalories = 0;
        #region 
        public Food bf = Food.Create(FoodType.Breakfast, "Breakfast", new[] {""}, "", 0);
        public Food br1 = Food.Create(FoodType.Snack, "1st Break", new[] {""}, "", 0);
        public Food lch = Food.Create(FoodType.Lunch, "Lunch", new[] {""}, "", 0);
        public Food br2 = Food.Create(FoodType.Snack, "2nd Break", new[] { "" }, "", 0);
        public Food dnr = Food.Create(FoodType.Dinner, "Dinner", new[] { "" }, "", 0);
        public FoodDetail fd = new FoodDetail();
        #endregion

        public MainWindow()
        {
            
            InitializeComponent();
           
            breakfast.Content = bf.Name;
            break1.Content = br1.Name;
            lunch.Content = lch.Name;
            break2.Content = br2.Name;
            dinner.Content = dnr.Name;



        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            fd.Close();
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
            do
            {
                bf = StorageManager.getStorage().FindRandomFiltered(FoodType.Breakfast); //ali je bůh
                br1 = StorageManager.getStorage().FindRandomFiltered(FoodType.Snack);
                lch = StorageManager.getStorage().FindRandomFiltered(FoodType.Lunch);
                br2 = StorageManager.getStorage().FindRandomFiltered(FoodType.Snack);
                dnr = StorageManager.getStorage().FindRandomFiltered(FoodType.Dinner);

            } while (br1 == br2);
            
            breakfast.Content = bf.Name;
            break1.Content = br1.Name;
            lunch.Content = lch.Name;
            break2.Content = br2.Name;
            dinner.Content = dnr.Name;
        }

        private void breakfastCheck_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            breakfastTitle.Foreground = Brushes.DarkGreen;
            breakfast.Foreground = Brushes.DarkGreen;
            cb.IsEnabled = false;
            TotalCalories += bf.CaloryCount;

            if (breakfastCheck.IsChecked ==true 
                && break1Check.IsChecked == true 
                && lunchCheck.IsChecked == true 
                && break2Check.IsChecked == true 
                && dinnerCheck.IsChecked == true)
            {

                MessageBox.Show($"Congratulaions! \n" +
                $"You finished todays menu worth {TotalCalories} kcal.", "Menu finished");

            }
            
        }

        private void break1Check_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            break1Title.Foreground = Brushes.DarkGreen;
            break1.Foreground = Brushes.DarkGreen;
            cb.IsEnabled = false;
            TotalCalories += br1.CaloryCount;
            if (breakfastCheck.IsChecked == true
                && break1Check.IsChecked == true
                && lunchCheck.IsChecked == true
                && break2Check.IsChecked == true
                && dinnerCheck.IsChecked == true)
            {

                MessageBox.Show($"Congratulaions! \n" +
                $"You finished todays menu worth {TotalCalories} kcal.", "Menu finished");

            }

        }
        private void lunchCheck_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            lunchTitle.Foreground = Brushes.DarkGreen;
            lunch.Foreground = Brushes.DarkGreen;
            cb.IsEnabled = false;
            TotalCalories += lch.CaloryCount;
            if (breakfastCheck.IsChecked == true
                && break1Check.IsChecked == true
                && lunchCheck.IsChecked == true
                && break2Check.IsChecked == true
                && dinnerCheck.IsChecked == true)
            {
                MessageBox.Show($"Congratulaions! \n" +
                $"You finished todays menu worth {TotalCalories} kcal.", "Menu finished");
            }

        }
        private void break2Check_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            break2Title.Foreground = Brushes.DarkGreen;
            break2.Foreground = Brushes.DarkGreen;
            cb.IsEnabled = false;
            TotalCalories += br2.CaloryCount;
            if (breakfastCheck.IsChecked == true
                && break1Check.IsChecked == true
                && lunchCheck.IsChecked == true
                && break2Check.IsChecked == true
                && dinnerCheck.IsChecked == true)
            {
                    MessageBox.Show($"Congratulaions! \n" +
                    $"You finished todays menu worth {TotalCalories} kcal.", "Menu finished");
                

            }

        }
        private void dinnerCheck_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            dinnerTitle.Foreground = Brushes.DarkGreen;
            dinner.Foreground = Brushes.DarkGreen;
            cb.IsEnabled = false;
            TotalCalories += dnr.CaloryCount;
            if (breakfastCheck.IsChecked == true
                && break1Check.IsChecked == true
                && lunchCheck.IsChecked == true
                && break2Check.IsChecked == true
                && dinnerCheck.IsChecked == true)
            {

                MessageBox.Show($"Congratulaions! \n" +
                $"You finished todays menu worth {TotalCalories} kcal.", "Menu finished");

            }

        }
        private void FillWindow(FoodDetail f, Food fo)
        {
            f.Visibility = Visibility.Visible;
            f.IsEnabled = true;
            f.foodName.Content = fo.Name;
            f.Title = fo.Name;
            foreach (string item in fo.Ingredients)
            {

                f.foodIngredients.Text += " - ";
                f.foodIngredients.Text += item;
                f.foodIngredients.Text += "\n";
            }
            f.foodGuide.Text = fo.Reciepe;
            f.foodCaloryCount.Content = $"Total Calories: {fo.CaloryCount}";

            f.Show();
        }

        private void breakfast_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            FillWindow(fd, bf);
           
            
        }
        private void break1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            FillWindow(fd, br1);
            
        }
        private void lunch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FillWindow(fd, lch);
        }
        private void break2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FillWindow(fd, br2);
        }
        private void dinner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FillWindow(fd, dnr);
        }
    }


    
}
