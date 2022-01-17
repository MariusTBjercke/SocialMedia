using System;
using System.Text;

namespace SocialMedia
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            App.Name = "Fjøsboka";
            App.Users.Add(new Person("Kenneth", "M", 25, "Veien203", false));
            App.Users.Add(new Person("Marius", "B", 28, "Vegen200002", false));
            App.Users.Add(new Person("John", "T", 30, "Kongevegen", false));

            Console.WriteLine($"Velkommen til {App.Name}. Hvilken bruker vil du logge deg inn på?");
            
            while (!App.LoggedIn)
            {
                Login();
            }

            while (true)
            {
                var userInput = Console.ReadLine().ToLower();

                if (userInput == "vis venner") App.CurrentUser.PrintFriends();
                if (userInput == "legg til venn") App.CurrentUser.AddFriend();
                if (userInput == "slett venn") App.CurrentUser.RemoveFriend();
            }
        }

        private static void Login()
        {
            var userInput = Console.ReadLine().ToLower();
            var match = App.Users.Exists(item => item.Name.ToLower() == userInput);
            if (match)
            {
                var userIndex = App.Users.FindIndex(x => x.Name.ToLower() == userInput);
                App.CurrentUser = App.Users[userIndex];
                var currentUser = App.CurrentUser;
                App.CurrentUser.Online = true;
                App.LoggedIn = true;
                Console.WriteLine($"Du er nå logget inn som {currentUser.Name}");
            }
            else
            {
                Console.WriteLine("Fant ikke bruker. Vennligst prøv igjen.");
            }
        }
    }
}
