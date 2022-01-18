using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia
{
    internal static class App
    {
        public static string Name;
        public static bool LoggedIn;
        public static Person CurrentUser = new Person(0, "User", "", 0, "", false);
        public static List<Person> Users = new List<Person>();
        public static string UserInput;
    }
}