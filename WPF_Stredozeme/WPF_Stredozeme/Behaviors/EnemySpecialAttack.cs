using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Stredozeme.Classes;
using WPF_Stredozeme.Interfaces;

namespace WPF_Stredozeme.Behaviors
{
    class EnemySpecialAttack : ISpecialAttackBehavior
    {/// <summary>
    /// Random enemy dmg from a range. Special attack deals more damage when close to full health
    /// </summary>
    /// <param name="class Player"></param>
    /// <param name="class Enemy"></param>
        public void SpecialAttack(Player p, Enemy e)
        {
            int attackdmgmin = p.AttackDmg - 14;
            int attackdmgplus = p.AttackDmg + 6;
            Random random = new Random();
            int randomdmg = random.Next(attackdmgmin, attackdmgplus);
            int skilldmg = (randomdmg / 3) * (p.CurrHealth / 90);
            p.CurrHealth = p.CurrHealth - skilldmg;
        }
    }
}
