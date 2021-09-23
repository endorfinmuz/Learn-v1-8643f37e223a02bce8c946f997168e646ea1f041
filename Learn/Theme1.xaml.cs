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
using Learn.ThemesTapeData.Theme1;

namespace Learn
{
    /// <summary>
    /// Логика взаимодействия для Theme1.xaml
    /// </summary>
    public partial class Theme1 : Page
    {
        public Theme1()
        {
            InitializeComponent();

            BT_Theme1_Part1.Background = Brushes.DeepSkyBlue;
            FirstTheme.Content = new TH1_Tape1();
        }

        private void CleanButtonsColor()
        {
            BT_Theme1_Part1.Background = Brushes.DodgerBlue;
            BT_Theme1_Part2.Background = Brushes.DodgerBlue;
            BT_Theme1_Part3.Background = Brushes.DodgerBlue;
            BT_Theme1_Part4.Background = Brushes.DodgerBlue;
        }

        private void BT_Theme1_Part1_Click(object sender, RoutedEventArgs e)
        {
            CleanButtonsColor();
            BT_Theme1_Part1.Background = Brushes.DeepSkyBlue;
            FirstTheme.Content = new TH1_Tape1();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPage mp = new MainPage();
            mp.MenuContentGrid.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Collapsed;
        }

        private void BT_Theme1_Part2_Click(object sender, RoutedEventArgs e)
        {
            CleanButtonsColor();
            BT_Theme1_Part2.Background = Brushes.DeepSkyBlue;
            FirstTheme.Content = new TH1_Tape2();
        }

        private void BT_Theme1_Part5_Click(object sender, RoutedEventArgs e)
        {
            CleanButtonsColor();
            BT_Theme1_Part5.Background = Brushes.DeepSkyBlue;
            FirstTheme.Content = new TH1_Tape5_Test();
        }
    }
}
