using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SocialMedia.Games.CSGO
{
    internal class CounterTerrorist : Player
    {
        public static Timer DefuseTimer = new();
        public static bool IsBeingDefused;

        public CounterTerrorist(string name) : base(name)
        {
            
        }

        public static void DefuseBomb()
        {
            if (CounterStrike.IsSuccessful(10) && !IsBeingDefused)
            {
                Console.WriteLine("The bomb is being defused...");
                DefuseTimer.Interval = 5000;
                DefuseTimer.Elapsed += BombDefused;
                DefuseTimer.AutoReset = false;
                DefuseTimer.Enabled = true;
                IsBeingDefused = true;
            }
        }

        private static void BombDefused(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("The bomb has been defused.");
            Console.WriteLine("Counter-Terrorists win!");
            Terrorist.BombTimer.Enabled = false;
            CounterStrike.IsDefused = true;
            CounterStrike.GameEnded = true;
        }

        public static void KillTerrorist(Player t)
        {
            if (CounterStrike.IsSuccessful(5))
            {
                t.IsDead = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(t.Name + " was killed.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
