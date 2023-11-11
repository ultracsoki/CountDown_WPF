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

namespace CountDown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Threading.DispatcherTimer timer;
        DateTime datum = DateTime.MinValue;
        public MainWindow()
        {
            InitializeComponent();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
        }

        private void buttonIndit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                datum = Convert.ToDateTime(textBoxDatum.Text);
                if (datum <= DateTime.Now)
                {
                    MessageBox.Show("A bevitt adat az aktuális időpontnál későbbi időpontra kell hogy mutasson!");
                    textBoxDatum.Text = "";
                }
                timer.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Dátum formátumot adjon meg!");
                textBoxDatum.Text = "";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan remainingTime = datum - DateTime.Now;
            //int ev = remainingTime.Days / 365;
            //int honap = (remainingTime.Days - (ev * 365)) / 30;
            //{ev} év {honap} hónap 
            labelVisszaszamlalo.Content = $"{remainingTime.Days} nap {remainingTime.Hours} óra {remainingTime.Minutes} perc {remainingTime.Seconds} másodperc";

            if (remainingTime.TotalSeconds <= 0)
            {
                timer.Stop();
                MessageBox.Show("Az idő lejárt!", "Idő lejárt", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
