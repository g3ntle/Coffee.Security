using Coffee.Security.Authentication;
using Coffee.Security.Authentication.Dummy;
using System;
using System.Globalization;
using System.Threading;

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

            john.SignIn(); // Sign in as John
            jane.SignIn(); // Sign in as Jane (replacing John)
            jane.SignOut(); // Sign out
        }

        public static void Main(string[] args)
        {
            Console.Title = "Example";
            
            try
            {
                new Program().Run();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + ": " + ex.InnerException?.Message);
            }

            Console.Read();
        }

        #endregion
    }
}
