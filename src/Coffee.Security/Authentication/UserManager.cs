using Coffee.Security.Authentication.Helpers;
using Coffee.Security.Authentication.Spoofing;
using System;

namespace Coffee.Security.Authentication
{
    public sealed class UserManager
    {
        #region Fields

        private static UserManager _instance;

        private readonly Spoofer spoofer;
        private IUser _current;

        #endregion


        #region Constructors

        private UserManager()
        {
            spoofer = new Spoofer(this);
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

        public void Spoof()
        {
            spoofer.Spoof();
        }

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
        
        public bool HasNode(string node)
        {
            return Current?.HasNode(node) ?? false;
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
