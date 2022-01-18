using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Games.CSGO
{
    internal class Soldier
    {
        public string Name { get; set; }
        public bool IsDead { get; set; }

        public Soldier(string name, bool isDead)
        {
            Name = name;
            IsDead = isDead;
        }
    }
}
