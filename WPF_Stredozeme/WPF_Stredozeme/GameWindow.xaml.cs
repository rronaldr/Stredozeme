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
using WPF_Stredozeme.Classes;

namespace WPF_Stredozeme
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        int i = 0;
        List<string> story = new List<string>();
        private Player hrac;
        Orc enemy1 = new Orc(1, 25, 120);
        Orc enemy2 = new Orc(3, 50, 250);
        Uruk enemy3 = new Uruk(5, 40, 400);
        Uruk enemy4 = new Uruk(7, 50, 500);

        public GameWindow()
        {
            InitializeComponent();  
        }
        public GameWindow(string x)
        {
            if (x.Equals("Mage"))
            {
                hrac = new Player(x, 1, 50, 200);
            }
            else
            {
                hrac = new Player(x, 1, 35, 350);
            }   
            InitializeComponent();
            story.Add("Hello " + hrac.Name + " you decided to go on an adventure. There's a message about some events in Erebor. I hope that the fearsome dragon Smaugh didn't awake. Many have tried to kill him and take the treasure that lies in Erebor, left there by the Dwarves.");
            story.Add("Your path will not be easy, there are rumors that Orcs and Skuruk's are coming from Moria lead by the most feared orc Azog the Defiler.");
            story.Add("Your adventure starts in Mirkwood. Elves live in Mirkwood and some tell that they've seen a mystery wizard wandering around Mirkwood.");
            story.Add("You have entered the forest of Mirkwood. You hear some noise in the distance. Do you want to go there?");
            storytext.Text = story[0];
        }
        private void NextTextClick(object sender, RoutedEventArgs e)
        {
            i++;
            if (i == 4)
            {
                ShowDecisionButtons();
            }
            else
            {
                ShowContinueButton();
                storytext.Text = story[i];
            }
        }

        private void YesClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void NoClick(object sender, RoutedEventArgs e)
        {
            GameOver();   
        }

        private void ShowDecisionButtons()
        {
            BtnY.Content = "Yes";
            BtnN.Content = "No";
            nextText.Visibility = Visibility.Collapsed;
            BtnN.Visibility = Visibility.Visible;
            BtnY.Visibility = Visibility.Visible;
        }
        private void ShowContinueButton()
        {
            nextText.Visibility = Visibility.Visible;
            BtnN.Visibility = Visibility.Collapsed;
            BtnY.Visibility = Visibility.Collapsed;
        }
        private void HideButtons()
        {
            nextText.Visibility = Visibility.Collapsed;
            BtnN.Visibility = Visibility.Collapsed;
            BtnY.Visibility = Visibility.Collapsed;
        }

        private void GameOver()
        {
            HideButtons();
            HeadTxt.Content = "GAME OVER";
            storytext.Text = "You were ambushed by the enemy. There was no way for you to defend yourself";
            
        }
        //private void Died()
    }
}
