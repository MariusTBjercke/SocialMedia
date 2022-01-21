using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Games.CSGO
{
    internal class Terrorist : Player
    {

        public Terrorist(string name) : base(name)
        {
            
        }

        public static bool FindBombSite()
        {
            var success = CounterStrike.IsSuccessful(10);
            return success;
        }

        public static async Task PlantBomb(List<Player> teamList)
        {
            var anyoneAlive = teamList.FindAll(x => x.IsDead == false).ToList();
            if (anyoneAlive.Count == 0) return;
            Random Random = new();
            if (FindBombSite() && !CounterStrike.isPlanted)
            {
                Console.WriteLine("Bomb is being planted...");
            }
            if (CounterStrike.isPlanted)
            {
                CounterStrike.bombTimer++;
                var tickOrTock = Random.Next(0, 2);
                Console.WriteLine(tickOrTock == 1 ? "tick" : "tock");
            }

            if (CounterStrike.bombTimer == 5)
            {
                Console.WriteLine("Bomb has been planted.");
                CounterStrike.isPlanted = true;
            }
            if (!CounterStrike.isDefused && CounterStrike.isPlanted && CounterStrike.bombTimer == 20)
            {
                Console.WriteLine("The bomb goes boOOooOm!\n"+
                                  "Terrorist wins!");
                CounterStrike.gameEnded = true;
                CounterStrike.isDefused = true;
            }

        }

        public static void Beep(int amount = 0)
        {
            if (amount > 0)
            {
                for (int i = 0; i < amount; i++)
                {
                    Console.Beep();
                }
            } else Console.Beep();
        }

        public static void KillCounterTerrorist(Player ct, bool allDead, bool enemiesAlive)
        {
            if (!enemiesAlive) return;
            if (!allDead && CounterStrike.IsSuccessful(7))
            {
                ct.IsDead = true;
                Console.WriteLine(ct.Name + " was killed.");
                return;
            }
            else if (allDead)
            {
                Console.WriteLine("Terrorists win!");
                CounterStrike.gameEnded = true;
                return;
            }
        }


    }
}
