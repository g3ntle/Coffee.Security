using Coffee.Beans;
using Coffee.Security.Authentication.Spoofing.Config;
using System;
using System.Reflection;

namespace Coffee.Security.Authentication.Spoofing
{
    public sealed class Spoofer
    {
        #region Fields

        private readonly UserManager manager;

        private IUser _user;

        #endregion


        #region Constructors

        public Spoofer(UserManager manager)
        {
            this.manager = manager;
            
            try
            {
                Initialize();
            }
            catch(Exception ex)
            {
                throw new SecurityException(300, "Unable to spoof", ex);
            }
        }

        #endregion


        #region Properties

        public IUser User
        {
            get { return _user; }
        }

        #endregion


        #region Methods

        private void Initialize()
        {
            var config = SpoofingProviderSection.Current;

            if (config == null || !(config.Enabled ?? false) || config.UserType == null || config.CredentialsType == null)
                return;

            var assembly = Assembly.GetEntryAssembly();
            var userType = Type.GetType(config.UserType);
            var credType = Type.GetType(config.CredentialsType);
            var args = config.Args;

            if (userType == null)
                throw new TypeLoadException($"Unknown type {config.UserType}");
            else if (!typeof(IUser).IsAssignableFrom(userType))
                throw new InvalidCastException($"Type {userType} does not implement IUser");

            if (credType == null)
                throw new TypeLoadException($"Unknown type {config.CredentialsType}");
            else if (!typeof(ICredentials).IsAssignableFrom(credType))
                throw new InvalidCastException($"Type {credType} does not implement IUser");

            var user = Activator.CreateInstance(userType) as IUser;
            var cred = Activator.CreateInstance(credType) as ICredentials;

            _user = user;
            _user.Credentials = cred;
        }

        public void Spoof()
        {

        }

        #endregion
    }
}
