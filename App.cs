using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia
{
    internal static class App
    {
        public static string Name;
        public static bool LoggedIn;
        public static Person CurrentUser = new Person(0, "Bruker", "", 0, "", false);
        public static List<Person> Users = new();
        public static List<Group> Groups = new();
        public static string UserInput;
    }
}