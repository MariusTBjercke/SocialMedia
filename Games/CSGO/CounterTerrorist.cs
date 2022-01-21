using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Games.CSGO
{
    internal class CounterTerrorist : Player
    {

        public CounterTerrorist(string name) : base(name)
        {
            
        }

        public static async Task DefuseBomb()
        {
            Console.WriteLine("The bomb is being defused...");
            await Task.Delay(5000);
            Console.WriteLine("The bomb has been defused...");
            Console.WriteLine("Counter-terrorists win!");
            CounterStrike.isDefused = true;
            CounterStrike.gameEnded = true;
        }

        public static async Task KillTerrorist(Player t, bool allDead, bool enemiesAlive)
        {
            if (!enemiesAlive) return;
            if (!CounterStrike.isPlanted && !allDead && CounterStrike.IsSuccessful(5))
            {
                t.IsDead = true;
                Console.WriteLine(t.Name + " was killed.");
                return;
            }
            else if (CounterStrike.isPlanted && allDead)
            {
                await DefuseBomb();
                return;
            }
            else if (allDead && !CounterStrike.isPlanted)
            {
                Console.WriteLine("Counter-Terrorists win!");
                CounterStrike.gameEnded = true;
                return;
            }
            else if (!allDead && CounterStrike.IsSuccessful(3))
            {
                t.IsDead = true;
                Console.WriteLine(t.Name + " was killed.");
                return;
            }
        }
    }
}
