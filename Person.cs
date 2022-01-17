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
            var index = App.Users.FindIndex(x => x.Name == userInput);
            if (index != -1)
            {
                Friends.Add(index);
                Console.WriteLine($"{userInput} ble lagt til i vennelisten.");
            }
            else Console.WriteLine("Fant ingen bruker med dette navnet.");
        }

        public void RemoveFriend()
        {
            foreach (var x in Friends)
            {
                Console.WriteLine(App.Users[x]);
            }

            Console.Write("Navn på venn: ");
            var userInput = Console.ReadLine();
            Friends.Remove(Convert.ToInt32(userInput));
            Console.WriteLine($"{App.Users[Convert.ToInt32(userInput)]} ble slettet.");
        }

        public void PrintFriends()
        {
            foreach (var x in Friends)
            {
                Console.WriteLine(App.Users[x]);
            }
        }
    }

}