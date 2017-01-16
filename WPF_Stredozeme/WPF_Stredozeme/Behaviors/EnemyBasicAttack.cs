using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Stredozeme.Classes;
using WPF_Stredozeme.Interfaces;

namespace WPF_Stredozeme.Behaviors
{
    class EnemyBasicAttack : IBasicAttackBeahvior
    {
        /// <summary>
        /// This class defined the behavior of enemy basic attack. Enemy can't have critical strike high as player.
        /// Enemy damage gets random number in range (-10, +4) and that is then taken from Player's current Health
        /// </summary>
        /// <param name="class Player"></param>
        /// <param name="class Enemy"></param>
        public void Attack(Player p, Enemy e)
        {
            int attackdmgmin = e.AttackDmg - 10;
            int attackdmgplus = e.AttackDmg + 4;
            Random random = new Random();
            int randomdmg = random.Next(attackdmgmin, attackdmgplus);
            p.CurrHealth = p.CurrHealth - randomdmg;
        }
    }
}
