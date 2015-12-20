using Coffee.Security.Authentication;
using Coffee.Security.Authentication.Helpers;
using System;
namespace Coffee.Security
{
    public class SecurityException : Exception
    {
        #region Constructors

        public SecurityException(int errorCode, string message, Exception inner) : base(message, inner)
        {
            ErrorCode = errorCode;
        }

        public SecurityException(int errorCode, string message) : this(errorCode, message, null) { }
        public SecurityException(Reason reason, Exception inner) : this(reason.GetErrorCode(), reason.GetMessage(), inner) { }
        public SecurityException(Reason reason) : this(reason, null) { }

        #endregion


        #region Properties

        public int ErrorCode { get; set; }

        #endregion
    }
}
