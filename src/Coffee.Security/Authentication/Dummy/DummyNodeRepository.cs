using System;
using System.Collections.Generic;

namespace Coffee.Security.Authentication.Dummy
{
    public class DummyNodeRepository : INodeRepository
    {
        #region Properties

        public IEnumerable<string> Nodes
        {
            get;
            set;
        }

        #endregion


        #region Methods

        public bool Contains(string node)
        {
            return true;
        }

        #endregion
    }
}
