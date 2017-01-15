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
using WPF_Stredozeme.Classes;

namespace WPF_Stredozeme
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            StartButton.Visibility = Visibility.Collapsed;
            SelectMage.Visibility = Visibility.Visible;
            SelectRanger.Visibility = Visibility.Visible;
            TextLabel.Content = "Choose role";
        }

        private void StartRanger(object sender, RoutedEventArgs e)
        {
            string role = "Ranger";
            GameWindow x = new GameWindow(role);
            x.Show();
            this.Close();
        }
        private void StartMage(object sender, RoutedEventArgs e)
        {
            string role = "Mage";
            GameWindow x = new GameWindow(role);
            x.Show();
            this.Close();
        }
    }
}
