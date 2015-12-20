using System;
using System.Collections.Generic;
using System.Linq;

namespace Coffee.Security.Authentication
{
    public abstract class NodeRepositoryBase : INodeRepository
    {
        #region Constants

        private const string Wildcard = "*";

        #endregion


        #region Fields

        private bool _hasWildcard;
        private IEnumerable<string> _nodes;

        #endregion


        #region Properties

        public bool HasWildcard
        {
            get
            {
                return _hasWildcard;
            }
        }

        public IEnumerable<string> Nodes
        {
            get
            {
                return _nodes;
            }
            set
            {
                _nodes = value;
                _hasWildcard = Contains(Wildcard, true);
            }
        }

        #endregion


        #region Methods

        public bool Contains(string node, bool ignore)
        {
            return ((ignore ? false : HasWildcard) ? true : Nodes?.Contains(node) ?? false);
        }

        public bool Contains(string node)
        {
            return Contains(node, false);
        }

        #endregion
    }
}
