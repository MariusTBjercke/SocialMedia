using System;
using System.Collections.Generic;

namespace SocialMedia
{
    public class App
    {
        public string Name;
        public bool LoggedIn;
        public Person CurrentUser;
        public List<Person> Users = new List<Person>();

        public App(string name)
        {
            Name = name;
        }
    }
}