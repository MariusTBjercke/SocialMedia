using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia
{
    internal class Command
    {
        public string _command;
        public Action _method;

        public Command(string command, Action method)
        {
            _command = command;
            _method = method;
        }


    }
}
