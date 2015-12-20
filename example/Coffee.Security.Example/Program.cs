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
            var manager = UserManager.Instance;

            manager.SignedIn += (sender, e) => Console.WriteLine($"{e.User} signed in..");
            manager.SignedOut += (sender, e) => Console.WriteLine($"{e.User} signed out..");

            IUser john = new DummyUser("John"),
                  jane = new DummyUser("Jane");

            john.SignIn();
            jane.SignIn();
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
