using System;
using System.Collections.Generic;

namespace Coffee.Security.Authentication
{
    public interface INodeRepository
    {
        #region Properties

        IEnumerable<string> Nodes { get; set; }

        #endregion


        #region Methods

        bool Contains(string node);

        #endregion
    }
}
