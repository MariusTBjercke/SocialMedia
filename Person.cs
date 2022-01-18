using System;
using System.Collections.Generic;

namespace SocialMedia
{
    internal class Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public string Name;
        public int Age;
        public string Address;
        public bool Online;
        private List<int> Friends = new List<int>();

        public Person(int id,string firstName, string lastName, int age, string address, bool online)
        {
            Id = id;
            Name = firstName + lastName;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
            Online = online;
        }

        public void AddFriend()
        {
            Console.Write("Navn på person du vil legge til som venn: ");
            Program.GetUserInput(false);
            var index = App.Users.FindIndex(x => x.Name.ToLower() == App.UserInput);
            if (index != -1)
            {
                Friends.Add(App.Users[index].Id);
                Console.WriteLine($"{App.Users[index].Name} ble lagt til i vennelisten.");
            }
            else Console.WriteLine("Fant ingen bruker med dette navnet.");
        }

        public void ShowFriendsIndex()
        {
            foreach (var friend in Friends)
            {
                Console.WriteLine(friend);
            }
        }

        public void RemoveFriend()
        {
            Console.Write("Navn på venn du vil slette: ");
            Program.GetUserInput(false);
            var index = App.Users.FindIndex(x => x.Name.ToLower() == App.UserInput);
            if (index != -1)
            {
                Friends.Remove(App.Users[index].Id);
                Console.WriteLine($"{App.Users[index].Name} ble slettet.");
            }
            else
            {
                Console.WriteLine("Fant ikke bruker.");
            }
        }

        public void AddGroup()
        {
            
        }

        public void EditGroup()
        {
            throw new NotImplementedException();
        }

        public void JoinGroup()
        {
            throw new NotImplementedException();
        }

        public void ShowFriends()
        {
            if (Friends.Count > 0)
            {
                Console.WriteLine("Dine venner:");
                foreach (var friend in Friends)
                {
                    var index = App.Users.FindIndex(x => x.Id == friend);
                    if (index != -1) Console.WriteLine(App.Users[index].Name);
                }
            }
            else Console.WriteLine("Du har ingen venner.");
        }
    }
}