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
        Orc enemy1 = new Orc("Images/orc.jpg", 1, 25, 120);
        Orc enemy2 = new Orc("Images/orc2.jpg", 3, 50, 250);
        Uruk enemy3 = new Uruk("Images/uruk.jpg", 5, 40, 400);
        Uruk enemy4 = new Uruk("Images/uruk2.jpg", 7, 50, 500);

        public GameWindow()
        {
            InitializeComponent();  
        }
        public GameWindow(string x)
        {
            if (x.Equals("Mage"))
            {
                hrac = new Player(x, "Images/mage.jpg", 1, 50, 200);
            }
            else
            {
                hrac = new Player(x, "Images/ranger.jpg", 1, 35, 350);
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
            ShowComabtUI();
        }

        private void NoClick(object sender, RoutedEventArgs e)
        {
            GameOver();   
        }

        private void Combat()
        {
            ShowComabtUI();
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
        private void ShowComabtUI()
        {
            HeadTxt.Content = "Battle";
            storytext.Text = "";
            HideButtons();
            image1.Visibility = Visibility.Visible;
            image2.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            label2.Visibility = Visibility.Visible;
            label3.Visibility = Visibility.Visible;
            label4.Visibility = Visibility.Visible;
            label5.Visibility = Visibility.Visible;
            label6.Visibility = Visibility.Visible;
            hltprgbar1.Visibility = Visibility.Visible;
            hltprgbar2.Visibility = Visibility.Visible;
            lvlprgbar1.Visibility = Visibility.Visible;
            lvlprgbar2.Visibility = Visibility.Visible;
            combatBtn1.Visibility = Visibility.Visible;
            combatBtn2.Visibility = Visibility.Visible;

            var converter = new ImageSourceConverter();
            image1.Source = (ImageSource)converter.ConvertFromString("pack://application:,,,/" + hrac.Image);
            image2.Source = (ImageSource)converter.ConvertFromString("pack://application:,,,/" + enemy1.Image);
            label1.Content = hrac.Name;
            label4.Content = enemy1.Name;
            label3.Content = "Level: " + hrac.Level.ToString();
            label6.Content = "Level: " + enemy1.Level.ToString();
            hltprgbar1.Maximum = hrac.Health;
            hltprgbar2.Maximum = enemy1.Health;
            hltprgbar1.Value = hrac.CurrHealth;
            hltprgbar2.Value = enemy1.CurrHealth;
            lvlprgbar1.Value = hrac.Level;
        }
    }
}
