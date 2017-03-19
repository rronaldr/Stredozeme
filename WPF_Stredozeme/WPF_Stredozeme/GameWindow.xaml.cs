using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAnimatedGif;
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
        //Counter
        int i = 0;
        //Counts how many fight were won
        public int fightswon = 0;
        //Collection of story texts
        List<string> story = new List<string>();
        //Creating objects
        private Player hrac;
        Enemy enemy1 = new Enemy("Orc" ,"Orc1", 1, 25, 350);
        Enemy enemy2 = new Enemy("Orc", "Orc2", 3, 50, 500);
        Enemy enemy3 = new Enemy("Uruk", "Uruk1", 5, 45, 700);
        Enemy enemy4 = new Enemy("Uruk", "Uruk2", 9, 50, 850);
        Enemy enemy5 = new Enemy("Nazgul", "Boss", 10, 70, 1500);
        Enemy enemy6 = new Enemy("Smaug", "Smaug", 99, 25, 120);
        Enemy enemy7 = new Enemy("DASDADD", "Orc1", 11, 10000, 10);

        //Enemy collection
        List<Enemy> enemies = new List<Enemy>();


        public GameWindow()
        {       
            InitializeComponent();
        }
        public GameWindow(string x)
        {
            //Usage of passed argument to this window
            if (x.Equals("Mage"))
            {
                hrac = new Player(x, "Mage", 1, 60, 850);
            }
            else
            {
                hrac = new Player(x, "Ranger", 1, 35, 1300);
            }   
            InitializeComponent();

            //Adding objects of class Enemy into collection 'enemies'
            enemies.Add(enemy1);
            enemies.Add(enemy2);
            enemies.Add(enemy3);
            enemies.Add(enemy4);
            enemies.Add(enemy5);
            enemies.Add(enemy6);
            enemies.Add(enemy7);

            //Adding story text into collection
            story.Add("Hello " + hrac.Name + " you decided to go on an adventure. There's a message about some events in Erebor. I hope that the fearsome dragon Smaugh didn't awake. Many have tried to kill him and take the treasure that lies in Erebor, left there by the Dwarves.");
            story.Add("Your path will not be easy, there are rumors that Orcs and Skuruk's are coming from Moria lead by the most feared orc Azog the Defiler.");
            story.Add("Your adventure starts in Mirkwood. Elves live in Mirkwood and some tell that they've seen a mystery wizard wandering around Mirkwood.");
            story.Add("You have entered the forest of Mirkwood. You hear some noise in the distance. Do you want to go there?");
            story.Add("You defeated your first enemy. You gained 2 levels. Your health and damage increased");
            story.Add("You continue trough the forest. In the distance you see some old ruined house. Do you want to explore the house?");
            story.Add("You defeated the Orc. You gained 1 level.");
            story.Add("You have discovered Radagast's house. Radegast is one of 5 wizards in Middle-Earth. It seems like nobody has been here for a while.");
            story.Add("As you proceed on your journey you hear some strange noise as a hoard of rabbits were coming your way. You turn around and you see a sledge powered by rabbits. The Brown wizard Radagast rides to you.");
            story.Add("You speak with Radagast for a few hours. When you are about to leave his house he asks you about your adventure. After he finds out you're going to kill Smaug he offers you an enchanted shield or a magic staff.");
            story.Add("Do you want to take the shield or the staff?");
            story.Add("");
            story.Add("You get to the end of the forest from which you can see Erebor. There's a abadoned human city Ravenhill. To get to the mountain's entrance you have to go trough the city.");
            story.Add("You have entered the city.");
            story.Add("At the entrance of Ravenhill you can see a group of Uruk's. You can't go around them, you need to pass trough them. Do you want to engage the Uruk group?");
            story.Add("Well done" + hrac.Name + "you handled that group with ease. You gained 1 level.");
            story.Add("You see a tower in the middle of the city. You should climb it to find a way in the mountain.");
            story.Add("You've reached the tower, but there's another Uruk group guarding the entrance. They have spotted you. Will you fight them?");
            story.Add("You truly became a skilled warrior. Smaugh should be no match for you. You get out of Ravenhill and decide to go to Erebor. Before you go to Erebor you make a camp and rest for a while.");
            story.Add("Yours health was restored");
            story.Add("Now you stand before the bridge to the entrance of Erebor. You hear mighty wind coming you way. A edge cutting sound. You cover your ears and on the horizon you see a Nazgul riding on his fearsome Fellbeast.");
            story.Add("Nazgul lands with the beast and comes to you. If you are going to enter Erebor you have to deafeat the Nazgul king. Do you want to fight?");
            story.Add("That was a tough one. The Nazgul king dodged your last attack and flew away back to Minas Morgul.");
            story.Add("You see some Dwarven runes on the door's. It's a warning that the ones who wish to live, shall go away and never come back. You don't fear anything and decide to enter.");
            story.Add("You see treasures everywhere lying. In the distance you hear a loud breathing. You go closer to the sound to find the source of it.");
            story.Add("When you enter the Great Hall you discover the source. It's Smaug sleeping covered in gold. You see the Arkstone, pride of the Dwarven king before he was forced to leave, because of Smaug.");
            story.Add("You sneak carefully near Smaug and you reach your hand for the Arcstone. Smaug wakes up from his sleep and looks for the Arcstone.");
            story.Add("You need to fight, otherwise you die.");
            story.Add("Smaug burned you in flames. There's no chance anybody is killing Smaug.");

            storytext.Text = story[0];  
        }
        private void NextTextClick(object sender, RoutedEventArgs e)
        {
            //When to show story points
            i++;
            if (i == 4 || i == 6 || i == 15 || i == 18 || i == 22 || i == 28)
            {
                ShowDecisionButtons();
                SetGif();
            }
            else if (i == 29)
            {
                HideButtons();
                exitBtn.Visibility = Visibility.Visible;
            }
            else if (i == 11)
            {
                BtnY.Content = "Staff";
                BtnN.Content = "Shield";
                nextText.Visibility = Visibility.Collapsed;
                BtnN.Visibility = Visibility.Visible;
                BtnY.Visibility = Visibility.Visible;
                if (i == 12)
                {
                    BtnY.Content = "Yes";
                    BtnN.Content = "No";
                }
            }
            else
            {
                ShowContinueButton();
                storytext.Text = story[i];
            }
            Heal();
        }

        private void YesClick(object sender, RoutedEventArgs e)
        {
            //When clicked on "Yes" initiates combat
            
            if (i != 11)
            { 
                Combat();
            }else if (i == 11)
            {
                hrac.AttackDmg = (hrac.AttackDmg / 100) * 15;
                ShowContinueButton();
            }
        }

        private void NoClick(object sender, RoutedEventArgs e)
        {
            //When clicked on "No" game over
            if (i != 11)
            {
                GameOver();
            }
            else if (i == 11)
            {
                hrac.Health = (hrac.Health / 100) * 15;
                ShowContinueButton();
            }
        }

        private void Combat()
        {
            //Initializing combat
            SetCombatStats();
            ShowComabtUI();
        }

        private void BasicAttack(object sender, RoutedEventArgs e)
        {
            //Button that does Basic attack
            IBasicAttackBeahvior attack = new PlayerBasicAttack();
            attack.Attack(hrac, enemies[fightswon]);

            CombatActions();
        }
        private void SpecialAttack(object sender, RoutedEventArgs e)
        {
            //Button that does Special attack
            ISpecialAttackBehavior specialAttack = new PlayerSpecialAbility();
            specialAttack.SpecialAttack(hrac, enemies[fightswon]);
            CombatActions();
        }

        private void EnemyAttack()
        {
            //Enemy do Basic or Special attack depending on what the result of enemy.currentHealt mod 11 is
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

        private void Heal()
        {
            if (i == 21)
            {
                hrac.CurrHealth = hrac.Health;
            }
        }
        private void CombatActions()
        {
            if (fightswon == 5)
            {
                fightswon = 1;
            }
            EnemyAttack();
            //What happens when player wins fight
            if (enemies[fightswon].CurrHealth <= 0)
            {
                fightswon++;
                HeadTxt.Content = "Won";
                HideComabtUI();
                ShowContinueButton();
                storytext.Text = story[i];
            }
            //If player looses
            else if (enemies[fightswon].CurrHealth > 0 && hrac.CurrHealth <= 0)
            {
                Died();
            }
            //Changing value of progressbar's
            hltprgbar1.Value = hrac.CurrHealth;
            hltprgbar2.Value = enemies[fightswon].CurrHealth;

            ILevelUpBehavior levelup = new PlayerLevelUpBehavior();

            //Initiates levelup behavior after every fight won
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
            Defense();
        }
        /// <summary>
        /// Uses player's and enemies defense techniques
        /// </summary>
        private void Defense()
        {
            IDefenseBehavior playerDefense = new PlayerDefense();
            playerDefense.Defend(hrac, enemies[fightswon]);

            IDefenseBehavior enemyDefense = new EnemyDefense();;
            enemyDefense.Defend(hrac, enemies[fightswon]);
        }
        /// <summary>
        /// Displays exit button, if clicked closes application
        /// </summary>
        private void GameOver()
        {
            HideButtons();
            HideComabtUI();
            HeadTxt.Content = "GAME OVER";
            storytext.Text = "You were ambushed by the enemy. There was no way for you to defend yourself";
            exitBtn.Visibility = Visibility.Visible;
        }
        private void GameOverGollum()
        {
            HideButtons();
            HideComabtUI();
            HeadTxt.Content = "GAME OVER";
            storytext.Text = "You didn't answer Gollums riddle correctly, he smashed you in the head with a rock";
            exitBtn.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Displays exit button, if clicked closes application
        /// </summary>
        private void Died()
        {
            HideButtons();
            HideComabtUI();
            HeadTxt.Content = "GAME OVER";
            storytext.Text = "You were defeated";
            exitBtn.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Shows Yes and No buttons and hides Continue button
        /// </summary>
        private void ShowDecisionButtons()
        {
            BtnY.Content = "Yes";
            BtnN.Content = "No";
            nextText.Visibility = Visibility.Collapsed;
            BtnN.Visibility = Visibility.Visible;
            BtnY.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Shows Continue button and hides Decision buttons
        /// </summary>
        private void ShowContinueButton()
        {
            HeadTxt.Content = "Mountain of Smaug";
            nextText.Visibility = Visibility.Visible;
            BtnN.Visibility = Visibility.Collapsed;
            BtnY.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// Hides all buttons
        /// </summary>
        private void HideButtons()
        {
            nextText.Visibility = Visibility.Collapsed;
            BtnN.Visibility = Visibility.Collapsed;
            BtnY.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// Button clicked function, exits application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Sets images, labels, progress bars
        /// </summary>
        private void SetCombatStats()
        {
            var converter = new ImageSourceConverter();
            image1.Source = Application.Current.Resources[hrac.Image] as BitmapImage;
            //image2.Source = Application.Current.Resources[enemies[fightswon].Image] as BitmapImage;

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
        /// <summary>
        /// Shows combat UI
        /// </summary>
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
        /// <summary>
        /// Hides combat UI
        /// </summary>
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

        private void SetGif()
        {
            //ddsd
            string y = enemies[fightswon].Image.ToLower();
            var controller = ImageBehavior.GetAnimationController(image2);
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@"/Images/" + y +".gif", UriKind.RelativeOrAbsolute);
            image.EndInit();
            ImageBehavior.SetAnimatedSource(image2, image);
            ImageBehavior.SetRepeatBehavior(image2, new RepeatBehavior(1));
        }
    }
}
