using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia
{
    internal class Command
    {
        public string CommandStr;
        public Action Method;

        public Command(string command, Action method)
        {
            CommandStr = command;
            Method = method;
        }
    }
}
