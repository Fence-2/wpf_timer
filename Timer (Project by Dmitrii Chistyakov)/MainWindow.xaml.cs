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
using System.Windows.Threading;

namespace Timer__Project_by_Dmitrii_Chistyakov_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        DateTime TimerTime = new DateTime();
        DateTime Lap_Difference = new DateTime();
        int lap_num = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimerTime = TimerTime.AddSeconds(1);
            TimerLabel.Content = (TimerTime).ToString("HH:mm:ss");
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void lap_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Add($"Круг {lap_num}: " + (TimerTime - Lap_Difference).ToString());
            Lap_Difference = TimerTime;
            lap_num++;
        }
        
        private void reset_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            TimerTime = DateTime.MinValue;
            Lap_Difference = DateTime.MinValue;
            TimerLabel.Content = TimerTime.ToString("HH:mm:ss");
            lap_num = 1;
            ListBox.Items.Clear();
        }
    }
}
