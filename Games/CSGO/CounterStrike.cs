using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Timers;

namespace SocialMedia.Games.CSGO
{
    internal class CounterStrike
    {
        static List<Player> T = new();
        static List<Player> CT = new();
        public static bool IsPlanted;
        public static bool IsBeingPlanted;
        public static bool IsDefused;
        public static bool GameEnded;

        // Main
        public static async Task StartGame()
        {
            AddTeamMembers();
            Console.WriteLine("Game started.");
            while (!GameEnded)
            {
                Terrorist.PlantBomb();
                if (IsAnyoneAlive(CT))
                {
                    if (IsPlanted) CounterTerrorist.DefuseBomb();
                    if (IsAnyoneAlive(T))
                    {
                        Terrorist.KillCounterTerrorist(PickRandomPlayer(CT));
                        CounterTerrorist.KillTerrorist(PickRandomPlayer(T));
                    }
                    else
                    {
                        if (!IsPlanted)
                        {
                            Console.WriteLine("Counter-Terrorists win!");
                            GameEnded = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Terrorists win!");
                    GameEnded = true;
                }
                await Task.Delay(1000);
            }

            Console.WriteLine("Game over.");
        }

        private static bool IsAnyoneAlive(List<Player> team)
        {
            var aliveList = team.FindAll(x => x.IsDead == false).ToList();
            if (aliveList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Player PickRandomPlayer(List<Player> enemyList)
        {
            var rnd = new Random();
            // Check which players are still alive
            var aliveList = enemyList.FindAll(x => x.IsDead == false).ToList();
            var randomIndex = rnd.Next(0, aliveList.Count);
            // Check the random name's correspondence with original enemy list
            var enemyIndex = enemyList.FindIndex(x => x.Name == aliveList[randomIndex].Name);
            // Return random player object
            return enemyList[enemyIndex];
        }

        public static void MainMenu()
        {
            Console.WriteLine(LogoText());
            Console.WriteLine("1. ");
        }

        public static bool IsSuccessful(int maxValue)
        {
            Random rnd = new Random();
            return rnd.Next(0, maxValue) == 2;
        }

        static void AddTeamMembers()
        {
            // Terrorists
            T.AddRange(new List<Player>()
            {
                new Terrorist("T-Derk"),
                new Terrorist("T-Gnerk"),
                new Terrorist("T-Hurk"),
                new Terrorist("T-Burk"),
                new Terrorist("T-Snurk"),
            });
            // Counter-Terrorists
            CT.AddRange(new List<Player>()
            {
                new CounterTerrorist("CT-Gnikk"),
                new CounterTerrorist("CT-Gnukk"),
                new CounterTerrorist("CT-Gnakk"),
                new CounterTerrorist("CT-Grakk"),
                new CounterTerrorist("CT-Glakk"),
            });
        }

        public static string LogoText()
        {
            return @"
  _____  _____   _____  ____  
 / ____|/ ____| / ____|/ __ \ 
| |    | (___(_) |  __| |  | |
| |     \___ \ | | |_ | |  | |
| |____ ____) || |__| | |__| |
 \_____|_____(_)\_____|\____/ ";
        }

    }
}
