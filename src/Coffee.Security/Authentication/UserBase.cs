using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Security.Authentication
{
    public abstract class UserBase : IUser
    {
        #region Properties

        public virtual ICredentials Credentials { get; set; }

        #endregion


        #region Events

        public event EventHandler SignedIn;
        public event EventHandler SignedOut;

        #endregion


        #region

        public void SignIn()
        {
            try
            {
                User.SignIn(this);
                OnSignedIn();
            }
            catch(SecurityException ex)
            {
                throw new SignInException(ex);
            }
        }

        public void SignOut()
        {
            try
            {
                User.SignOut(this);
                OnSignedOut();
            }
            catch (SecurityException ex)
            {
                throw new SignOutException(ex);
            }
        }

        protected void OnSignedIn()
        {
            SignedIn?.Invoke(this, EventArgs.Empty);
        }

        protected void OnSignedOut()
        {
            SignedOut?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
