using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Games.CSGO
{
    internal class CounterStrike
    {
        static Terrorists T = new Terrorists();
        static CounterTerrorists CT = new CounterTerrorists();

        public static void StartGame()
        {
            AddTeamMembers();
        }

        static void AddTeamMembers()
        {
            // Terrorists
            T.Members.AddRange(new List<Soldier>()
            {
                new Terrorist("Derk", false),
                new Terrorist("Gnerk", false),
                new Terrorist("Hurk", false),
                new Terrorist("Hodor", false),
                new Terrorist("Horlor", false),
            });
            // Counter-Terrorists
            CT.Members.AddRange(new List<CounterTerrorist>()
            {
                new CounterTerrorist("Gnikk", false),
                new CounterTerrorist("Gnukk", false),
                new CounterTerrorist("Gnakk", false),
                new CounterTerrorist("Grakk", false),
                new CounterTerrorist("Glakk", false),
            });
        }
    }
}
