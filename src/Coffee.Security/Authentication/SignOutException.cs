using System;

namespace Coffee.Security.Authentication
{
    public class SignOutException : SecurityException
    {
        #region Constructors

        public SignOutException(SecurityException inner) 
            : base(inner?.ErrorCode ?? -1, Resources.Strings.SignOutFailed, inner) { }

        #endregion
    }
}
