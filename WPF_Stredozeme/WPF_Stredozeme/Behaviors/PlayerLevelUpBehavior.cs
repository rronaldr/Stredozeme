using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Stredozeme.Classes;
using WPF_Stredozeme.Interfaces;

namespace WPF_Stredozeme.Behaviors
{
    class PlayerLevelUpBehavior : ILevelUpBehavior
    {
        /// <summary>
        /// Increases Player's attack damage
        /// </summary>
        /// <param name="class Player"></param>
        public void LevelUp(Player p)
        {
            p.Level = p.Level + 1;
            p.AttackDmg = p.AttackDmg + 15;
        }
    }
}
