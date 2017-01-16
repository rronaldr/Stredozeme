using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Stredozeme.Classes;

namespace WPF_Stredozeme.Interfaces
{
    interface IDefenseBehavior
    {
        void Defend(Player p, Enemy e);
    }
}
