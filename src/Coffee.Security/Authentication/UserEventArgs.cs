using System;

namespace Coffee.Security.Authentication
{
    public sealed class UserEventArgs : EventArgs
    {
        #region Constructors

        public UserEventArgs(IUser user = null)
        {
            User = user;
        }

        #endregion


        #region Properties

        public IUser User { get; set; }

        #endregion
    }
}
