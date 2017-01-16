using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Stredozeme.Classes;
using WPF_Stredozeme.Interfaces;

namespace WPF_Stredozeme.Behaviors
{
    class PlayerDefense : IDefenseBehavior
    {
        /// <summary>
        /// Same as Enemy defense
        /// </summary>
        /// <param name="class Player"></param>
        /// <param name="class Enemy"></param>
        public void Defend(Player p, Enemy e)
        {
            int mod = p.CurrHealth % 11;
            if (mod == 5 || mod == 10)
            {
                p.CurrHealth = p.CurrHealth + e.AttackDmg;
            }
        }
    }
}
