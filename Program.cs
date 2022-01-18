using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Games.CSGO;

namespace SocialMedia
{
    internal class Program
    {
        static List<Command> Commands = new();

        static async Task Main(string[] args)
        {
            //await DrawLogo();
            Init();

            //CounterStrike.StartGame();
            //return;

            Console.WriteLine($"Velkommen til {App.Name}. Hvilken av de følgende brukerne vil du logge deg inn på?");

            foreach (var user in App.Users)
            {
                Console.WriteLine(user.Name);
            }

            while (!App.CurrentUser.Online)
            {
                Login();
            }

            ShowTips();

            while (true)
            {
                GetUserInput();
                var index = Commands.FindIndex(x => x.CommandStr == App.UserInput);
                if (index != -1)
                {
                    if (Commands[index].Admin)
                    {
                        if (App.CurrentUser.Admin) Commands[index].Method();
                        else Console.WriteLine("Bruker må være administrator for å bruke denne kommandoen.");
                    }
                    else Commands[index].Method();
                }
                else
                {
                    Console.WriteLine("Feil.. Forsøk en annen kommando.");
                }
            }
        }

        public static async Task DrawLogo()
        {
            string logoText = AppLogoText();
            await Graphics.DrawRectangle(50, 12, ConsoleColor.DarkBlue);
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;

            var textArray = logoText.ToCharArray();
            foreach (var c in textArray)
            {
                Console.Write(c);
                await Task.Delay(5);
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 12);
        }

        private static async void Init()
        {
            App.Name = "Fjøsboka";
            App.Users.AddRange(new List<Person>()
            {
                new Person(1, "Kenneth", "M", 25, "Veien201", false),
                new Person(2, "Marius", "B", 28, "Veien202", false, true),
                new Person(3, "John", "T", 30, "Veien203", false),
                new Person(4, "Petter", "T", 30, "Veien204", false),
                new Person(5, "Marcus", "R", 30, "Veien205", false),
            });
            Console.OutputEncoding = Encoding.UTF8;
            AddUserCommands();
        }

        static void AddUserCommands()
        {
            Commands.AddRange(new List<Command>()
            {
                new Command("vis venner", App.CurrentUser.ShowFriends),
                new Command("legg til venn", App.CurrentUser.AddFriend),
                new Command("slett venn", App.CurrentUser.RemoveFriend),
                new Command("vis index", App.CurrentUser.ShowFriendsIndex),
                new Command("legg til gruppe", App.CurrentUser.AddGroup),
                new Command("endre gruppe", App.CurrentUser.EditGroup),
                new Command("bli med i gruppe", App.CurrentUser.JoinGroup),
                new Command("vis grupper", App.CurrentUser.ShowGroups),
                new Command("logg ut", App.CurrentUser.Logout),
                new Command("vis intro", App.CurrentUser.ShowIntro, true),
            });
        }

        public static void GetUserInput(bool showName = true, bool toLowerChars = true)
        {
            if (showName) Console.Write(App.CurrentUser.Name + ": ");
            App.UserInput = toLowerChars ? Console.ReadLine()?.ToLower() : Console.ReadLine();
        }

        public static void Login()
        {
            GetUserInput();
            var match = App.Users.Exists(item => item.Name.ToLower() == App.UserInput);
            if (match)
            {
                var userIndex = App.Users.FindIndex(x => x.Name.ToLower() == App.UserInput);
                App.CurrentUser = App.Users[userIndex];
                App.CurrentUser.Online = true;
                Console.WriteLine($"Du er nå logget inn som {App.CurrentUser.Name}");
            }
            else
            {
                Console.WriteLine("Fant ikke bruker. Vennligst prøv igjen.");
            }
        }

        static void ShowTips()
        {
            Console.WriteLine("Her er noen kommandoer du kan bruke:");
            foreach (var command in Commands)
            {
                Console.WriteLine(" - " + command.CommandStr);
            }
        }

        static string AppLogoText()
        {
            return @"
    ______ _            _           _         
   |  ____(_)          | |         | |        
   | |__   _  ____  ___| |__   ___ | | ____ _ 
   |  __| | |/ _//\/ __| '_ \ / _ \| |/ / _` |
   | |    | | (//) \__ \ |_) | (_) |   < (_| |
   |_|    | |\//__/|___/_.__/ \___/|_|\_\__,_|
         _/ |                                 
        |__/
";
        }
    }
}                                  