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
        public GameWindow()
        {
            InitializeComponent();
            
        }

        public GameWindow(Player x)
        {
            InitializeComponent();
            story.Add("Hello " + x.Name + " you decided to go on an adventure. There's a message about some events in Erebor. I hope that the fearsome dragon Smaugh didn't awake. Many have tried to kill him and take the treasure that lies in Erebor, left there by the Dwarves.");
            story.Add("Your path will not be easy, there are rumors that Orcs and Skuruk's are coming from Moria lead by the most feared Orc Azog the Defiler.");
            story.Add("Here take some");
            storytext.Text = story[0];

        }
        private void NextTextClick(object sender, RoutedEventArgs e)
        {
            i++;
            storytext.Text = story[i];
            
        }
    }
}
