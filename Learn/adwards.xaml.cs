using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Learn
{
    public partial class adwards : Page
    {
        public static RegistryKey currentUserKey = Registry.CurrentUser;

        public adwards()
        {
            InitializeComponent();

            RegistryKey open = currentUserKey.OpenSubKey("LearnData");
            int progress = Convert.ToInt32(open.GetValue("stagesago"));
            if (progress == 0)
            {
                RegisterAdward.Opacity = 100;
            }
            else if (progress == 1)
            {
                RegisterAdward.Opacity = 100;
                FirstThemeAdward.Opacity = 100;
            }
            else if (progress == 2)
            {
                RegisterAdward.Opacity = 100;
                FirstThemeAdward.Opacity = 100;
                SecondThemeAdward.Opacity = 100;
            }


        }

        private void RatingGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<RatingGridData> result = new List<RatingGridData>(3);
            result.Add(new RatingGridData(1, "Максим", 300));
            result.Add(new RatingGridData(2, "Андрей", 500));
            result.Add(new RatingGridData(3, "Екатерина", 120));
            RatingGrid.ItemsSource = result;

            RatingGrid.Items.SortDescriptions.Add(new SortDescription(RatingGrid.Columns[2].SortMemberPath, ListSortDirection.Descending));

            foreach (var col in RatingGrid.Columns)
            {
                col.SortDirection = null;
            }
            RatingGrid.Columns[2].SortDirection = ListSortDirection.Descending;
            RatingGrid.Items.Refresh();
        }

        private void RatingGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RatingGridData path = RatingGrid.SelectedItem as RatingGridData;
            MessageBox.Show(" ID: " + path.Id + "\n Имя: " + path.Name + "\n Счёт: " + path.Score);
        }

        private void RatingGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
