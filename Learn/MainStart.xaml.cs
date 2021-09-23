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
using System.Windows.Shapes;

namespace Learn
{
    /// <summary>
    /// Логика взаимодействия для MainStart.xaml
    /// </summary>
    public partial class MainStart : Window
    {
        public MainStart()
        {
            InitializeComponent();
        }

        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
                timer.Tick += new EventHandler(timerTick);
                timer.Interval = new TimeSpan(0, 0, 5);
                timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            MainWindow mn = new MainWindow();
            mn.Show();
        }
    }
}
