using System;

namespace Coffee.Security.Authentication.Dummy
{
    public sealed class DummyUser : UserBase
    {
        #region Fields

        private ICredentials _credentials;
        private string _name;

        #endregion


        #region Constructors

        public DummyUser(string name)
        {
            _credentials = new DummyCredentials();
            _name = name;
        }

        public DummyUser() : this("Dummy") { }

        #endregion


        #region Properties

        public override ICredentials Credentials
        {
            get
            {
                return _credentials;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        #endregion


        #region Methods

        public override string ToString()
        {
            return _name;
        }

        #endregion
    }
}
