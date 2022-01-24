using System;
using System.Threading.Tasks;

namespace SocialMedia
{
    internal class Command
    {
        public string CommandStr { get; set; }
        public Action Method { get; set; }
        public bool Admin { get; set; }
        public Func<Task> AsyncMethod;

        public Command(string command, Action method, bool admin = false)
        {
            CommandStr = command;
            Method = method;
            Admin = admin;
        }

        public Command(string command, Func<Task> method, bool admin = false)
        {
            CommandStr = command;
            AsyncMethod = method;
            Admin = admin;
        }
    }
}
