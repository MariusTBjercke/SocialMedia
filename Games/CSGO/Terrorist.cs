using System;
using System.Threading.Tasks;
using System.Timers;

namespace SocialMedia.Games.CSGO
{
    internal class Terrorist : Player
    {
        public static Timer BombTimer;
        public static Timer PlantedTimer;

        public Terrorist(string name) : base(name)
        {
            
        }

        public static void PlantBomb()
        {
            if (CounterStrike.IsSuccessful(10) && !CounterStrike.IsBeingPlanted)
            {
                Console.WriteLine("Bomb is being planted...");
                PlantedTimer = new Timer();
                PlantedTimer.Interval = 5000;
                PlantedTimer.Elapsed += BombHasBeenPlanted;
                PlantedTimer.AutoReset = false;
                PlantedTimer.Enabled = true;
                CounterStrike.IsBeingPlanted = true;
            }
        }

        private static void BombHasBeenPlanted(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Bomb has been planted.");
            BombTimer = new Timer();
            BombTimer.Interval = 15000;
            BombTimer.Elapsed += BombExplosion;
            BombTimer.AutoReset = false;
            BombTimer.Enabled = true;
            CounterStrike.IsPlanted = true;
        }

        private static void BombExplosion(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("The bomb goes boOOooOm!\n" +
                              "Terrorist wins!");
            CounterStrike.GameEnded = true;
            CounterStrike.IsDefused = true;
        }

        public static void KillCounterTerrorist(Player ct)
        {
            if (CounterStrike.IsSuccessful(7))
            {
                ct.IsDead = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ct.Name + " was killed.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


    }
}
