using System;

namespace Coffee.Security.Authentication
{
    public enum Reason
    {
        UserNull,
        CredentialsNull,
        UserInvalid,
        CredentialsInvalid,
        UserSignedIn,
        UserNotSignedIn
    }
}
