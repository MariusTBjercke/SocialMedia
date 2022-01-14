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
        private List<string> Friends = new List<string>();

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
            Friends.Add(userInput);
            Console.WriteLine($"{userInput} ble lagt til i vennelisten.");
        }

        public void RemoveFriend()
        {
            foreach (var friend in Friends)
            {
                Console.WriteLine(friend);
            }

            Console.Write("Navn på venn: ");
            var userInput = Console.ReadLine();
            Friends.Remove(userInput);
            Console.WriteLine($"{userInput} ble slettet.");
        }

        public void PrintFriends()
        {
            foreach (var friend in Friends)
            {
                Console.WriteLine(friend);
            }
        }
    }

}