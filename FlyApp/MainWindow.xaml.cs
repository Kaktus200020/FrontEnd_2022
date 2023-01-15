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

namespace FlyApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int posX;
        int posY;
        int score = 0;
        int sec = 0;
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblScore.Content = "Score: " + score;
            sec += 1;
            if(sec>=15)
            {
                fly.Visibility = Visibility.Hidden;
                Canvas.SetLeft(lblScore, (MyCanvas.ActualWidth-100)/2);
                Canvas.SetTop(lblScore, (MyCanvas.ActualHeight-100)/ 2);
                lblScore.FontSize = 32;
            }
        }

        private void NewPos()
        {
            Random random = new Random();
            posX= random.Next(1, (int)(MyCanvas.ActualWidth - fly.ActualWidth));
            posY = random.Next(1, (int)(MyCanvas.ActualHeight-fly.ActualHeight));
            Canvas.SetTop(fly, posY);
            Canvas.SetLeft(fly, posX);
        }
        private void MyCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Ellipse)
            {
                score += 1;
                NewPos();
            }
        }
    }
}
