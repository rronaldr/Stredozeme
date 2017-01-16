using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Stredozeme.Classes;
using WPF_Stredozeme.Interfaces;

namespace WPF_Stredozeme.Behaviors
{
    class EnemyDefense : IDefenseBehavior
    {
        /// <summary>
        /// Enemies current health mod 11, if mod is 5 OR 10 there's is a 100% block. Chance of blocking attack is very small.
        /// </summary>
        /// <param name="class Player"></param>
        /// <param name="class Enemy"></param>
        public void Defend(Player p, Enemy e)
        {
            int mod = e.CurrHealth % 11;
            if (mod == 5 || mod == 10)
            {
                e.CurrHealth = e.CurrHealth + p.AttackDmg;
            }
        }
    }
}
