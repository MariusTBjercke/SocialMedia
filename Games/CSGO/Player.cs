using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Games.CSGO
{
    internal class Player
    {
        public string Name { get; set; }
        public bool IsDead { get; set; }

        public Player(string name)
        {
            Name = name;
            IsDead = false;
        }
    }
}
