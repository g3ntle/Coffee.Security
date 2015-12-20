using System;

namespace Coffee.Security.Authentication
{
    public class SignInException : SecurityException
    {
        #region Constructors

        public SignInException(SecurityException inner) 
            : base(inner?.ErrorCode ?? -1, "Unable to sign in", inner) { }

        #endregion
    }
}
