﻿using System;

namespace Coffee.Security.Authentication
{
    public interface IUser
    {
        #region Properties

        ICredentials Credentials { get; set; }
        INodeRepository Nodes { get; set; }

        #endregion


        #region Events

        event EventHandler SignedIn;
        event EventHandler SignedOut;

        #endregion


        #region Methods

        void SignIn();
        void SignOut();
        bool HasNode(string node);

        #endregion
    }
}
