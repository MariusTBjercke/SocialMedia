using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Games.CSGO
{
    internal class CounterStrike
    {
        static List<Player> T = new();
        static List<Player> CT = new();
        public static bool isPlanted = false;
        public static bool isDefused = false;
        public static bool gameEnded = false;
        public static int bombTimer = 0;

        // Main
        public static async Task StartGame()
        {
            AddTeamMembers();
            Console.WriteLine("Game started.");
            while (!gameEnded)
            {
                await Terrorist.PlantBomb(T);
                await PickRandomPlayer(CT, T, "CT dies");
                await PickRandomPlayer(T, CT, "T dies");
                await Task.Delay(1000);
            }

            Console.WriteLine("Game over.");
        }

        static async Task PickRandomPlayer(List<Player> playerList, List<Player> enemyList,string team)
        {
            Random rnd = new();
            var teamAliveList = playerList.FindAll(x => x.IsDead == false).ToList();
            var enemyAliveList = enemyList.FindAll(x => x.IsDead == false).ToList();
            int index = rnd.Next(0, teamAliveList.Count);
            int playerToKill = 0;
            if (teamAliveList.Count > 0) playerToKill = playerList.FindIndex(x => x.Name == teamAliveList[index].Name);
            bool enemiesAlive = enemyAliveList.Count > 0;
            switch (team, teamAliveList.Count > 0)
            {
                case ("CT dies", true):
                    Terrorist.KillCounterTerrorist(CT[playerToKill],false, enemiesAlive);
                    break;
                case ("T dies", true):
                    await CounterTerrorist.KillTerrorist(T[playerToKill], false, enemiesAlive);
                    break;
                case ("T dies", false):
                    await CounterTerrorist.KillTerrorist(T[playerToKill], true, enemiesAlive);
                    break;
                case ("CT dies", false):
                    Terrorist.KillCounterTerrorist(CT[playerToKill], true, enemiesAlive);
                    break;
            }
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
