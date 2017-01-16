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
using WPF_Stredozeme.Behaviors;
using WPF_Stredozeme.Classes;
using WPF_Stredozeme.Interfaces;

namespace WPF_Stredozeme
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        int i = 0;
        public int fightswon = 0;
        List<string> story = new List<string>();
        private Player hrac;
        Enemy enemy1 = new Enemy("Orc" ,"Images/orc.jpg", 1, 25, 120);
        Enemy enemy2 = new Enemy("Orc","Images/orc2.jpg", 3, 50, 250);
        Enemy enemy3 = new Enemy("Uruk","Images/uruk.jpg", 5, 45, 400);
        Enemy enemy4 = new Enemy("Uruk","Images/uruk2.jpg", 7, 50, 500);
        Enemy enemy5 = new Enemy("Uruk", "Images/uruk2.jpg", 7, 50, 500);
        List<Enemy> enemies = new List<Enemy>();
        

        public GameWindow()
        {       
            InitializeComponent();
        }
        public GameWindow(string x)
        {
            if (x.Equals("Mage"))
            {
                hrac = new Player(x, "Images/mage.jpg", 1, 50, 350);
            }
            else
            {
                hrac = new Player(x, "Images/ranger.jpg", 1, 35, 500);
            }   
            InitializeComponent();

            enemies.Add(enemy1);
            enemies.Add(enemy2);
            enemies.Add(enemy3);
            enemies.Add(enemy4);
            enemies.Add(enemy5);

            story.Add("Hello " + hrac.Name + " you decided to go on an adventure. There's a message about some events in Erebor. I hope that the fearsome dragon Smaugh didn't awake. Many have tried to kill him and take the treasure that lies in Erebor, left there by the Dwarves.");
            story.Add("Your path will not be easy, there are rumors that Orcs and Skuruk's are coming from Moria lead by the most feared orc Azog the Defiler.");
            story.Add("Your adventure starts in Mirkwood. Elves live in Mirkwood and some tell that they've seen a mystery wizard wandering around Mirkwood.");
            story.Add("You have entered the forest of Mirkwood. You hear some noise in the distance. Do you want to go there?");
            story.Add("You defeated your first enemy. You gained 2 levels. Your health and damage increased");
            story.Add("You continue trough the forest. In the distance you see some old ruined house. Do you want to explore the house?");
            story.Add("You defeated the Orc. You gained 1 level.");
            story.Add("You have discovered Radegast's house. Radegast is one of 5 wizards in Middle-Earth. It seems like nobody has been here for a while. You decide to countinue your journey.");
            story.Add("You get to the end of the forest from which you can see Erebor. There's a abadoned human city Ravenhill. To get to the mountain's entrance you have to go trough the city.");
            story.Add("You have entered the city.");
            story.Add("At the entrance of Ravenhill you can see a group of Uruk's. You can't go around them, you need to pass trough them. Do you want to engage the Uruk group?");
            story.Add("Well done" + hrac.Name + "you handled that group with ease. You gained 1 level.");
            story.Add("You see a tower in the middle of the city. You should climb it to find a way in the mountain.");
            story.Add("You've reached the tower, but there's another Uruk group guarding the entrance. They have spotted you. Will you fight them?");
            story.Add("You truly became a skilled warrior. Smaugh should be no match for you. You get out of Ravenhill and decide to go to Erebor.");
            story.Add("STORY TO BE CONTINUED");

            storytext.Text = story[0];  
        }
        private void NextTextClick(object sender, RoutedEventArgs e)
        {
            i++;
            if (i == 4 || i == 6 || i == 11 || i == 14)
            {
                ShowDecisionButtons();
            }
            else if (i == 16)
            {
                HideButtons();
                exitBtn.Visibility = Visibility.Visible;
            }
            else
            {
                ShowContinueButton();
                storytext.Text = story[i];
            }
        }

        private void YesClick(object sender, RoutedEventArgs e)
        {
            Combat();
        }

        private void NoClick(object sender, RoutedEventArgs e)
        {
            GameOver();   
        }

        private void Combat()
        {
            SetCombatStats();
            ShowComabtUI();
        }

        private void BasicAttack(object sender, RoutedEventArgs e)
        {
            IBasicAttackBeahvior attack = new PlayerBasicAttack();
            attack.Attack(hrac, enemies[fightswon]);

            CombatActions();
        }
        private void SpecialAttack(object sender, RoutedEventArgs e)
        {
            ISpecialAttackBehavior specialAttack = new PlayerSpecialAbility();
            specialAttack.SpecialAttack(hrac, enemies[fightswon]);

            CombatActions();
        }

        private void EnemyAttack()
        {
            int dice = enemies[fightswon].CurrHealth % 11;
            if (dice == 0 || dice == 2 || dice == 4 || dice == 5 || dice == 6 || dice == 7 || dice == 9)
            {
                IBasicAttackBeahvior enemyAttack = new EnemyBasicAttack();
                enemyAttack.Attack(hrac, enemies[fightswon]);
            }
            else if (dice == 1 || dice == 3 || dice == 8 || dice == 10)
            {
                ISpecialAttackBehavior enemySpecialAttack = new EnemySpecialAttack();
                enemySpecialAttack.SpecialAttack(hrac, enemies[fightswon]);
            }
        }

        private void CombatActions()
        {
            EnemyAttack();

            if (enemies[fightswon].CurrHealth <= 0)
            {
                fightswon++;
                HeadTxt.Content = "Won";
                HideComabtUI();
                ShowContinueButton();
                storytext.Text = story[i];
            }
            else if (enemies[fightswon].CurrHealth > 0 && hrac.CurrHealth <= 0)
            {
                Died();
            }
            hltprgbar1.Value = hrac.CurrHealth;
            hltprgbar2.Value = enemies[fightswon].CurrHealth;

            ILevelUpBehavior levelup = new PlayerLevelUpBehavior();

            if (fightswon == 1)
            {
                levelup.LevelUp(hrac);
            } else if (fightswon == 2)
            {
                levelup.LevelUp(hrac);
            }
            else if (fightswon == 3)
            {
                levelup.LevelUp(hrac);
            }
        }

        private void Defense()
        {
            IDefenseBehavior playerDefense = new PlayerDefense();
            playerDefense.Defend(hrac, enemies[fightswon]);

            IDefenseBehavior enemyDefense = new EnemyDefense();;
            enemyDefense.Defend(hrac, enemies[fightswon]);
        }
        private void GameOver()
        {
            HideButtons();
            HideComabtUI();
            HeadTxt.Content = "GAME OVER";
            storytext.Text = "You were ambushed by the enemy. There was no way for you to defend yourself";
            exitBtn.Visibility = Visibility.Visible;
        }

        private void Died()
        {
            HideButtons();
            HideComabtUI();
            HeadTxt.Content = "GAME OVER";
            storytext.Text = "You were defeated";
            exitBtn.Visibility = Visibility.Visible;
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
            HeadTxt.Content = "Mountain of Smaug";
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

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SetCombatStats()
        {
            var converter = new ImageSourceConverter();
            image1.Source = (ImageSource)converter.ConvertFromString("pack://application:,,,/" + hrac.Image);
            image2.Source = (ImageSource)converter.ConvertFromString("pack://application:,,,/" + enemies[fightswon].Image);

            label1.Content = hrac.Name;
            label3.Content = "Level: " + hrac.Level.ToString();
            hltprgbar1.Maximum = hrac.Health;
            hltprgbar1.Value = hrac.CurrHealth;
            lvlprgbar1.Value = hrac.Level;

            label4.Content = enemies[fightswon].Name;
            label6.Content = "Level: " + enemies[fightswon].Level.ToString();
            hltprgbar2.Maximum = enemies[fightswon].Health;
            hltprgbar2.Value = enemies[fightswon].CurrHealth;
            lvlprgbar2.Value = enemies[fightswon].Level;
        }
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
        }

        private void HideComabtUI()
        {
            image1.Visibility = Visibility.Collapsed;
            image2.Visibility = Visibility.Collapsed;
            label1.Visibility = Visibility.Collapsed;
            label2.Visibility = Visibility.Collapsed;
            label3.Visibility = Visibility.Collapsed;
            label4.Visibility = Visibility.Collapsed;
            label5.Visibility = Visibility.Collapsed;
            label6.Visibility = Visibility.Collapsed;
            hltprgbar1.Visibility = Visibility.Collapsed;
            hltprgbar2.Visibility = Visibility.Collapsed;
            lvlprgbar1.Visibility = Visibility.Collapsed;
            lvlprgbar2.Visibility = Visibility.Collapsed;
            combatBtn1.Visibility = Visibility.Collapsed;
            combatBtn2.Visibility = Visibility.Collapsed;
        }
    }
}
