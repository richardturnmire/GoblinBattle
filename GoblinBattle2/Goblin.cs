using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GoblinBattle2
{
    public class Goblin
    {
        private static Random _rng = new Random();

        private int _hitPoints;
        private string _name;
        private bool _isDead = false;
        private Weapons[] WeaponCache = new Weapons[2];

        private int _work1;

        public Goblin() : this("Default", 200)
        { }

        public Goblin(string name) : this(name, 200)
        { }

        public Goblin(string name, int hp)

        {
            _name = name;
            _hitPoints = hp;
            DetermineWeapons();
        }

        public int HitPoints
        {
            get { return _hitPoints; }

            set
            {
                if (value <= 0)
                    _isDead = true;
                else
                    _hitPoints = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public bool IsDead
        {
            get { return _isDead; }
            private set
            { _isDead = value; }
        }

        public void Attack(Goblin gob)
        {
            int weapon = _rng.Next(1, WeaponCache.Length);
            int damage = WeaponCache[weapon].DamagePotential;
            string wname = WeaponCache[weapon].Name;

            Console.WriteLine($" {_name} attacks {gob.Name} with a {wname}.");
            gob.Hit(damage);
        }

        public void Hit(int damage)
        {
            int critical = _rng.Next(1, 101) % 2 + 1;
            if (critical == 2)
                Console.WriteLine("\nCritical hit received.\n");

            int totDamage = (damage * critical);
            _hitPoints -= totDamage;
            if (_hitPoints < 0)
                _hitPoints = 0;

            Console.WriteLine($"{_name} received {totDamage} damage. Player has {_hitPoints} points left.");

            if (_hitPoints < 1)
            {
                Console.WriteLine($"\n{_name} has died!");
                Console.ReadKey();
                IsDead = true;
                Program.numStillAlive--;

            }
        }

        private void DetermineWeapons()
        {

            for (int i = 0; i < WeaponCache.Length; i++)
            {
                _work1 = _rng.Next(1, 4);
                WeaponCache[i] = new Weapons(
                   Enum.GetName(typeof(WeaponType), _work1),
                     _work1);
            }

        }
    }

}





