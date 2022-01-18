using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

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
        public List<int> Friends = new();
        public bool Admin;

        public Person(int id,string firstName, string lastName, int age, string address, bool online, bool admin = false)
        {
            Id = id;
            Name = firstName + lastName;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
            Online = online;
            Admin = admin;
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
            Console.Write("Navn på gruppen: ");
            Program.GetUserInput(false, false);

            // Get latest ID
            int newId;
            if (App.Groups.Count > 0)
            {
                var lastId = App.Groups.OrderByDescending(x => x.Id).First().Id;
                newId = lastId + 1;
            }
            else
            {
                newId = 0;
            }

            App.Groups.Add(new Group(newId, App.UserInput));
            Console.WriteLine($"Gruppen '{App.UserInput}' ble lagt til.");
        }

        public void ShowGroups()
        {
            foreach (var group in App.Groups)
            {
                Console.WriteLine(group.Name);
            }

            Console.Write("Sjekk medlemmer ved å skrive inn navnet på en gruppe (trykk enter for å hoppe over): ");
            Program.GetUserInput(false);

            if (App.UserInput.Trim(' ') != "")
            {
                var index = App.Groups.FindIndex(x => x.Name.ToLower() == App.UserInput);
                if (index != -1)
                {
                    var memberAmount = App.Groups[index].Members.Count;
                    Console.WriteLine(memberAmount > 1
                        ? $"Gruppen {App.Groups[index].Name} har {memberAmount.ToString()} brukere. Disse er:"
                        : $"Gruppen {App.Groups[index].Name} har {memberAmount.ToString()} bruker. Det er:");
                    foreach (var id in App.Groups[index].Members)
                    {
                        var userIndex = App.Users.FindIndex(x => x.Id == id);
                        if (userIndex != -1) Console.WriteLine(App.Users[userIndex].Name);
                    }
                }
            }
        }

        public void EditGroup()
        {
            throw new NotImplementedException();
        }

        public void JoinGroup()
        {
            Console.WriteLine("Du kan bli medlem av disse gruppene:");

            foreach (var group in App.Groups)
            {
                Console.WriteLine(group.Name);
            }

            Console.Write("Navn på gruppe: ");
            Program.GetUserInput(false);

            var index = App.Groups.FindIndex(x => x.Name.ToLower() == App.UserInput);
            if (index != -1)
            {
                App.Groups[index].AddMember(App.CurrentUser.Id);
                Console.WriteLine($"Du ble medlem av '{App.Groups[index].Name}'.");
            }
            else
            {
                Console.WriteLine("Fant ikke gruppe.");
            }
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

        public void Logout()
        {
            App.CurrentUser = new Person(0, "Bruker", "", 0, "", false);
            Console.WriteLine("Du er nå logget ut. Du kan logge inn ved å skrive inn navnet på en bruker.");

            while (!App.CurrentUser.Online)
            {
                Program.Login();
            }
        }

        public async void ShowIntro()
        {
            await Program.DrawLogo();
        }
    }
}