using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Stredozeme.Classes;
using WPF_Stredozeme.Interfaces;

namespace WPF_Stredozeme.Behaviors
{
    class PlayerBasicAttack : IBasicAttackBeahvior
    {
        public void Attack(Player player, Enemy e)
        {
            int attackdmgmin = player.AttackDmg - 8;
            int attackdmgplus = player.AttackDmg + 8;
            Random random = new Random();
            int randomdmg = random.Next(attackdmgmin, attackdmgplus);
            e.CurrHealth = e.CurrHealth - randomdmg;
        }
    }
}
