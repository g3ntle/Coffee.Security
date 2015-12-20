using System;

namespace Coffee.Security.Authentication
{
    public static class User
    {
        #region Methods

        public static void SignIn(IUser user)
        {
            UserManager.Instance.SignIn(user);
        }

        public static void SignOut(IUser user)
        {
            UserManager.Instance.SignOut(user);
        }

        #endregion
    }
}
