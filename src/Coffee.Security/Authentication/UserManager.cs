using Coffee.Security.Authentication.Helpers;
using System;

namespace Coffee.Security.Authentication
{
    public sealed class UserManager
    {
        #region Fields

        private static UserManager _instance;

        private IUser _current;

        #endregion


        #region Constructors

        private UserManager()
        {
            // TODO
        }

        #endregion


        #region Properties

        public IUser Current
        {
            get
            {
                return _current;
            }
            internal set
            {
                var previous = _current;
                _current = value;

                if (previous == null && _current != null)
                    OnSignedIn(_current);
                else if (previous != null && _current == null)
                    OnSignedOut(previous);
                else if(previous != null && _current != null)
                {
                    OnSignedOut(previous);
                    OnSignedIn(_current);
                }
            }
        }

        public static UserManager Instance
        {
            get
            {
                return _instance ?? (_instance = new UserManager());
            }
        }

        #endregion


        #region Events

        public delegate void UserEventHandler(object sender, UserEventArgs e);

        public event UserEventHandler SignedIn;
        public event UserEventHandler SignedOut;

        #endregion


        #region

        public void SignIn(IUser user)
        {
            if (user == null)
                throw new SecurityException(Reason.UserNull);
            else if (user.Equals(Current))
                throw new SecurityException(Reason.UserSignedIn);
            else if (user.Credentials == null)
                throw new SecurityException(Reason.CredentialsNull);
            else if (!user.Credentials.Validate())
                throw new SecurityException(Reason.CredentialsInvalid);

            Current = user;
        }

        public void SignOut(IUser user)
        {
            if (user == null)
                throw new SecurityException(Reason.UserNull);
            else if (!user.Equals(Current))
                throw new SecurityException(Reason.UserNotSignedIn);

            Current = null;
        }

        private void OnSignedIn(IUser user)
        {
            SignedIn?.Invoke(this, new UserEventArgs(user));
        }

        private void OnSignedOut(IUser user)
        {
            SignedOut?.Invoke(this, new UserEventArgs(user));
        }

        #endregion
    }
}
