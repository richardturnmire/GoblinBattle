using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattle2
{
    class Program
    {
        public static Goblin[] goblins = new Goblin[10];
        public static int numStillAlive = 0;
        public static int numPlayers;
        private static Random whosNext = new Random();
        private static int _whosTurn;
        private static int _whoToAttack;

        static void Main(string[] args)
        {
            GetPlayers();

            while (numStillAlive > 1)
            {

                _whosTurn = DetermineWhosNext();
                _whoToAttack = DetermineWhoToAttack();

                {
                    goblins[_whosTurn].Attack(goblins[_whoToAttack]);

                }

            }

            DetermineTheWinner();
            Console.ReadLine();
        }


        private static void GetPlayers()
        {
            string _name;

            Console.WriteLine($"Enter information for up to 10 players");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"\nEnter name for player {i + 1} or Q if last player has been entered");
                _name = Console.ReadLine();
                if (_name != "Q")
                {
                    Console.WriteLine($"Enter number of hit points for player {_name}");
                    if (!int.TryParse(Console.ReadLine(), out int _hit))
                    {
                        Console.WriteLine("Invalid value for hit points, defaulting to 100");
                        _hit = 100;
                    }
                    goblins[i] = new Goblin(_name, _hit);
                    
                    numStillAlive++;
                }
                else
                {
                    break;
                }

            }
            numPlayers = numStillAlive;

        }

        private static int DetermineWhosNext()
        {
            bool playerFnd = false;
            int _results;
            do
            {
                _results = whosNext.Next(numPlayers);
                if (!goblins[_results].IsDead)
                    playerFnd = true;
            } while (!playerFnd);

            return _results;
        }
        private static int DetermineWhoToAttack()
        {
            bool playerFnd = false;
            int _results;
            do
            {
                _results = whosNext.Next(numPlayers);
                if (_whosTurn != _results && !goblins[_results].IsDead)
                    playerFnd = true;
            } while (!playerFnd);

            return _results;
        }

        private static void DetermineTheWinner()
        {
            for (int i = 0; i < numPlayers; i++)
            {
                if (!goblins[i].IsDead)
                {
                    Console.WriteLine($"\n{goblins[i].Name} wins!");
                    break;
                }
            }


        }
    }
}

    

    




