using Coffee.Security.Authentication;
using Coffee.Security.Authentication.Dummy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Coffee.Security.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void ShouldSignIn()
        {
            var user = new DummyUser();
            user.SignIn();

            Assert.AreEqual(user, User.Current, "User should be signed in");
        }

        [TestMethod]
        public void ShouldSignOut()
        {
            var user = new DummyUser();
            user.SignIn();
            user.SignOut();

            Assert.AreNotEqual(user, User.Current, "User should be signed out");
        }

        [TestMethod]
        public void ShouldSwitch()
        {
            IUser one = new DummyUser()
                , two = new DummyUser();

            one.SignIn();
            two.SignIn();

            Assert.AreEqual(two, User.Current, "User two should be signed in");
        }
    }
}
