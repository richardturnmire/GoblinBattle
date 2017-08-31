using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattle2
{
    public class Weapons
    {
        
        private  int _damagePotential;

        public Weapons(string name, int damagePotential)
        {
            Name = name;
            DamagePotential = damagePotential;
        }

        public string Name { get; set; }
        public int DamagePotential
        {
            get { return _damagePotential; }
            set
            {
                if (value < 1)
                    _damagePotential = 0;
                else
                    _damagePotential = value;
            }
        }


    }

    public enum WeaponType
    {
        None,
        Spear,
        Grenade,
        RocketLauncher,
        Missile
    }
}
