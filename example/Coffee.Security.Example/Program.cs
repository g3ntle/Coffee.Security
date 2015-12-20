using Coffee.Security.Authentication;
using Coffee.Security.Authentication.Dummy;
using System;

namespace Coffee.Security.Example
{
    public class Program
    {
        #region Methods

        public void Run()
        {
            User.Spoof();

            //var manager = UserManager.Instance;

            //manager.SignedIn += (sender, e) => Console.WriteLine($"{e.User} signed in..");
            //manager.SignedOut += (sender, e) => Console.WriteLine($"{e.User} signed out..");

            //IUser john = new DummyUser("John"),
            //      jane = new DummyUser("Jane");

            //john.SignIn(); // Sign in as John
            //jane.SignIn(); // Sign in as Jane (replacing John)
            //jane.SignOut(); // Sign out
        }

        public static void Main(string[] args)
        {
            Console.Title = "Example";
            new Program().Run();
            Console.Read();
        }

        #endregion
    }
}
