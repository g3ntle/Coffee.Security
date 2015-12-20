using System;

namespace Coffee.Security.Authentication
{
    public static class User
    {
        #region Properties

        public static IUser Current
        {
            get
            {
                return UserManager.Instance.Current;
            }
        }

        #endregion


        #region Methods

        public static void Spoof()
        {
            UserManager.Instance.Spoof();
        }

        public static void SignIn(IUser user)
        {
            UserManager.Instance.SignIn(user);
        }

        public static void SignOut(IUser user)
        {
            UserManager.Instance.SignOut(user);
        }

        public static bool HasNode(string node)
        {
            return UserManager.Instance.HasNode(node);
        }

        #endregion
    }
}
