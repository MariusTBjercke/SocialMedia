using System;
using System.Text;

namespace SocialMedia
{
    internal class Program
    {
        static App app = new App("Fjøsboka");

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            app.Users.Add(new Person("Kenneth", "M", 25, "Veien203", false));
            app.Users.Add(new Person("Marius", "B", 28, "Vegen200002", false));
            app.Users.Add(new Person("John", "T", 30, "Kongevegen", false));

            Console.WriteLine($"Velkommen til {app.Name}. Hvilken bruker vil du logge deg inn på?");
            
            while (!app.LoggedIn)
            {
                Login();
            }

            while (true)
            {
                var userInput = Console.ReadLine().ToLower();

                if (userInput == "vis venner") app.CurrentUser.PrintFriends();
                if (userInput == "legg til venn") app.CurrentUser.AddFriend();
                if (userInput == "slett venn") app.CurrentUser.RemoveFriend();
            }
        }

        private static void Login()
        {
            var userInput = Console.ReadLine().ToLower();
            var match = app.Users.Exists(item => item.Name.ToLower() == userInput);
            if (match)
            {
                var userIndex = app.Users.FindIndex(x => x.Name.ToLower() == userInput);
                app.CurrentUser = app.Users[userIndex];
                var currentUser = app.CurrentUser;
                app.CurrentUser.Online = true;
                app.LoggedIn = true;
                Console.WriteLine($"Du er nå logget inn som {currentUser.Name}");
            }
            else
            {
                Console.WriteLine("Fant ikke bruker. Vennligst prøv igjen.");
            }
        }
    }
}
