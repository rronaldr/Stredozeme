﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Stredozeme.Classes;
using WPF_Stredozeme.Interfaces;

namespace WPF_Stredozeme.Behaviors
{
    class PlayerSpecialAbility : ISpecialAttackBehavior
    {
        public void SpecialAttack(Player p, Enemy e)
        {
            int attackdmgmin = p.AttackDmg - 10;
            int attackdmgplus = p.AttackDmg + 10;
            Random random = new Random();
            int randomdmg = random.Next(attackdmgmin, attackdmgplus);
            int skilldmg = (randomdmg / 3) * (p.CurrHealth / 90);
            e.CurrHealth = e.CurrHealth - skilldmg;
        }
    }
}
