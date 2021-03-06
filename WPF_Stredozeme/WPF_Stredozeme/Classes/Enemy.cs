﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Stredozeme.Classes
{
    public class Enemy
    {
        private string _name, _img;
        private int _level, _attackdmg, _health, _currHealth;

        public Enemy(string name, string image, int level, int attackdmg, int health)
        {
            _name = name;
            _img = image;
            _level = level;
            _attackdmg = attackdmg;
            _health = health;
            _currHealth = _health;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Image
        {
            get { return _img; }
            set { _name = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        public int AttackDmg
        {
            get { return _attackdmg; }
            set { _attackdmg = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int CurrHealth
        {
            get { return _currHealth; }
            set { _currHealth = value; }
        }
    }
}
