using System;
using System.Collections.Generic;

namespace SocialMedia
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public string Name;
        public int Age;
        public string Address;
        public bool Online;
        private List<int> Friends = new List<int>();

        public Person(string firstName, string lastName, int age, string address, bool online)
        {
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
            var userInput = Console.ReadLine();
            var index = App.Users.FindIndex(x => x.Name.ToLower() == userInput.ToLower());
            if (index != -1)
            {
                Friends.Add(index);
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
            var userInput = Console.ReadLine();
            var index = App.Users.FindIndex(x => x.Name.ToLower() == userInput.ToLower());
            if (index != -1)
            {
                Friends.Remove(index);
                Console.WriteLine($"{App.Users[index].Name} ble slettet.");
            }
            else
            {
                Console.WriteLine("Fant ikke bruker.");
            }
        }

        public void PrintFriends()
        {
            Console.WriteLine("Dine venner:");
            foreach (var x in Friends)
            {
                Console.WriteLine(App.Users[x].Name);
            }
        }
    }

}