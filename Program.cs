using System;
using System.Collections.Generic;
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

            await CounterStrike.StartGame();
            return;

            await DrawLogo();
            Init();

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
            await Task.Delay(2000);
        }

        private static void Init()
        {
            App.Name = "Fjøsboka";
            App.Users.AddRange(new List<User>()
            {
                new User(1, "Kenneth", "M", "passord", 25, "Veien201", false),
                new User(2, "Marius", "B", "passord", 28, "Veien202", false, true),
                new User(3, "John", "T", "passord", 30, "Veien203", false),
                new User(4, "Petter", "T", "passord", 30, "Veien204", false),
                new User(5, "Marcus", "R", "passord", 30, "Veien205", false),
            });
            Console.OutputEncoding = Encoding.UTF8;
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
                new Command("hjelp", ShowTips),
                new Command("kommandoer", ShowTips),
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
            var userIndex = App.Users.FindIndex(x => x.Name.ToLower() == App.UserInput);
            if (userIndex != -1)
            {
                while (!App.CurrentUser.Online)
                {
                    Console.Write("Passord: ");
                    App.UserInput = null;
                    // Replace input with asterisks
                    while (true)
                    {
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                        {
                            Console.WriteLine();
                            break;
                        }
                        if (key.Key == ConsoleKey.Backspace && App.UserInput.Length > 0)
                        {
                            App.UserInput = App.UserInput.Remove(App.UserInput.Length - 1, 1);
                            Console.Write("\b \b");
                        }
                        else
                        {
                            App.UserInput += key.KeyChar;
                            Console.Write("*");
                        }
                    }

                    if (App.Users[userIndex].Password == App.UserInput)
                    {
                        App.CurrentUser = App.Users[userIndex];
                        App.CurrentUser.Online = true;
                        Graphics.SetTextColor(ConsoleColor.Green);
                        Console.WriteLine($"Du er nå logget inn som {App.CurrentUser.Name}");
                        Graphics.ResetTextColor();
                    }
                    else
                    {
                        Console.WriteLine("Feil passord. Vennligst prøv igjen.");
                    }
                }

                Graphics.ResetTextColor();
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