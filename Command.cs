using System;

namespace SocialMedia
{
    internal class Command
    {
        public string CommandStr { get; set; }
        public Action Method { get; set; }
        public bool Admin { get; set; }

        public Command(string command, Action method, bool admin = false)
        {
            CommandStr = command;
            Method = method;
            Admin = admin;
        }
    }
}
