using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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
using WpfAnimatedGif;

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
        /// <summary>
        /// Shows roles to choose after clicking start button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGame(object sender, RoutedEventArgs e)
        {
            var controller = ImageBehavior.GetAnimationController(Smoke);
            Fire.Visibility = Visibility.Hidden;
            StartButton.Visibility = Visibility.Collapsed;
            SelectMage.Visibility = Visibility.Visible;
            SelectRanger.Visibility = Visibility.Visible;
            TextLabel.Content = "Choose role";
            Smoke.Visibility = Visibility.Visible;
            controller.Play();
        }
        /// <summary>
        /// If Ranger chose, then close this window and opens a new game window with passed string argument "ranger"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartRanger(object sender, RoutedEventArgs e)
        {
            string role = "Ranger";
            GameWindow x = new GameWindow(role);

            x.Show();
            this.Close();
        }
        /// <summary>
        /// If Ranger chose, then close this window and opens a new game window with passed string argument "mage"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartMage(object sender, RoutedEventArgs e)
        {
            string role = "Mage";
            GameWindow x = new GameWindow(role);
            x.Show();
            this.Close();
        }
    }
}
