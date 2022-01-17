using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            App.Name = "Fjøsboka";
            App.Users.AddRange(new List<Person>()
            {
                new Person("Kenneth", "M", 25, "Veien203", false),
                new Person("Marius", "B", 28, "Vegen200002", false),
                new Person("John", "T", 30, "Kongevegen", false),
            });

            Console.WriteLine($"Velkommen til {App.Name}. Hvilken av de følgende brukerne vil du logge deg inn på?");

            foreach (var user in App.Users)
            {
                Console.WriteLine(user.Name);
            }

            while (!App.LoggedIn)
            {
                Login();
            }

            ShowTips();
            
            while (true)
            {
                var userInput = Console.ReadLine().ToLower();
                if (userInput == "vis venner") App.CurrentUser.PrintFriends();
                if (userInput == "legg til venn") App.CurrentUser.AddFriend();
                if (userInput == "slett venn") App.CurrentUser.RemoveFriend();
                if (userInput == "vis index") App.CurrentUser.ShowFriendsIndex();
                if (userInput == "avslutt") break;
            }
        }

        private static void Login()
        {
            Console.Write(App.CurrentUser.Name + ": ");
            var userInput = Console.ReadLine().ToLower();
            var match = App.Users.Exists(item => item.Name.ToLower() == userInput);
            if (match)
            {
                var userIndex = App.Users.FindIndex(x => x.Name.ToLower() == userInput);
                App.CurrentUser = App.Users[userIndex];
                App.CurrentUser.Online = true;
                App.LoggedIn = true;
                Console.WriteLine($"Du er nå logget inn som {App.CurrentUser.Name}");
            }
            else
            {
                Console.WriteLine("Fant ikke bruker. Vennligst prøv igjen.");
            }
        }

        static void ShowTips()
        {
            var tipsList = new List<string>();
            tipsList.AddRange(new List<string>()
            {
                "legg til venn",
                "slett venn",
                "vis venner",
            });
            Console.WriteLine("Her er noen kommandoer du kan bruke:");
            foreach (var tips in tipsList)
            {
                Console.WriteLine(" - " + tips);
            }
        }
    }
}
