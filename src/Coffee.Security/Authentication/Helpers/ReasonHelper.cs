using System;
using System.Collections.Generic;
using System.Resources;

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
            { Reason.UserNull, "User cannot be null" },
            { Reason.CredentialsNull, "Credentials cannot be null" },
            { Reason.UserInvalid, "Invalid user" },
            { Reason.CredentialsInvalid, "Invalid credentials" },
            { Reason.UserSignedIn, "User already signed in" },
            { Reason.UserNotSignedIn, "User not signed in" }
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
