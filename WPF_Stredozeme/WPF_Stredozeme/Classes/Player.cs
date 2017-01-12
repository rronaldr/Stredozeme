using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Stredozeme.Classes
{
    class Player
    {
        /// <summary>
        /// Player class constructor
        /// </summary>
        public Player(string name, string role, int level, int attackdmg, int health, int currHealth)
        {
            _name = name;
            _role = role;
            _level = level;
            _attackdmg = attackdmg;
            _health = health;
            _currHealth = currHealth;
        }

        private string _name, _role;
        private int _level, _attackdmg, _health, _currHealth;
    }
}
