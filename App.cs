using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia
{
    internal static class App
    {
        public static string Name;
        public static User CurrentUser = new User(0, "Bruker", "", "", 0, "", false);
        public static List<User> Users = new();
        public static List<Group> Groups = new();
        public static string UserInput;
    }
}