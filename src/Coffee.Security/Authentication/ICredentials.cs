using System;

namespace Coffee.Security.Authentication
{
    public interface ICredentials
    {
        #region Methods

        bool Validate();

        #endregion
    }
}
