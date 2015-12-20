using System;
using System.Collections.Generic;

namespace Coffee.Security.Authentication.Helpers
{
    public static class ReasonHelper
    {
        #region Constants

        private static readonly Dictionary<Reason, int> ErrorCodes = new Dictionary<Reason, int>()
        {
            { Reason.UserNull, 101 },
            { Reason.CredentialsNull, 102 },
            { Reason.UserInvalid, 103 },
            { Reason.CredentialsInvalid, 104 },
            { Reason.UserSignedIn, 201 },
            { Reason.UserNotSignedIn, 202 }
        };

        private static readonly Dictionary<Reason, string> Messages = new Dictionary<Reason, string>()
        {
            { Reason.UserNull, Resources.Strings.UserNull },
            { Reason.CredentialsNull, Resources.Strings.CredentialsNull },
            { Reason.UserInvalid, Resources.Strings.UserInvalid },
            { Reason.CredentialsInvalid, Resources.Strings.CredentialsInvalid },
            { Reason.UserSignedIn, Resources.Strings.UserSignedIn },
            { Reason.UserNotSignedIn, Resources.Strings.UserNotSignedIn }
        };

        #endregion


        #region Methods

        public static int GetErrorCode(this Reason instance)
        {
            int result = -1;
            ErrorCodes.TryGetValue(instance, out result);
            return result;
        }

        public static string GetMessage(this Reason instance)
        {
            string result = null;
            Messages.TryGetValue(instance, out result);
            return result;
        }

        public static T GetException<T>(this Reason instance) where T : Exception
        {
            return (T) new Exception();
        }

        #endregion
    }
}
