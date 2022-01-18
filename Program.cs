using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia
{
    internal class Program
    {

        static List<Command> Commands = new List<Command>();

        static void Main(string[] args)
        {
            Init();

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
                WriteUsername();
                var userInput = Console.ReadLine().ToLower();
                var index = Commands.FindIndex(x => x._command == userInput);
                if (index != -1)
                {
                    Commands[index]._method();
                }
                else
                {
                    Console.WriteLine("Oops.. Forsøk en annen kommando.");
                }
            }
        }

        private static void Init()
        {
            App.Name = "Fjøsboka";
            App.Users.AddRange(new List<Person>()
            {
                new Person("Kenneth", "M", 25, "Veien203", false),
                new Person("Marius", "B", 28, "Vegen200002", false),
                new Person("John", "T", 30, "Kongevegen", false),
            });
            Console.OutputEncoding = Encoding.UTF8;
            AddUserCommands();
        }

        static void AddUserCommands()
        {
            Commands.AddRange(new List<Command>()
            {
                new Command("vis venner", App.CurrentUser.PrintFriends),
                new Command("legg til venn", App.CurrentUser.AddFriend),
                new Command("slett venn", App.CurrentUser.RemoveFriend),
                new Command("vis index", App.CurrentUser.ShowFriendsIndex),
                new Command("lag gruppe", App.CurrentUser.AddGroup),
                new Command("endre gruppe", App.CurrentUser.EditGroup),
                new Command("bli med i gruppe", App.CurrentUser.JoinGroup),
            });
        }

        static void WriteUsername()
        {
            Console.Write(App.CurrentUser.Name + ": ");
        }

        private static void Login()
        {
            WriteUsername();
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
