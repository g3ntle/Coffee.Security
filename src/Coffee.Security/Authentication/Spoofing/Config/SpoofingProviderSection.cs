using System;
using System.Configuration;

namespace Coffee.Security.Authentication.Spoofing.Config
{
    public sealed class SpoofingProviderSection : ConfigurationSection
    {
        #region Fields

        public static readonly SpoofingProviderSection Current = 
            (SpoofingProviderSection)ConfigurationManager.GetSection("spoofingProvider");

        #endregion


        #region Properties

        [ConfigurationProperty("enabled", DefaultValue = false)]
        public bool? Enabled
        {
            get { return (bool?)base["enabled"]; }
            set { base["enabled"] = value; }
        }

        [ConfigurationProperty("userType", DefaultValue = null)]
        public string UserType
        {
            get { return (string)base["userType"]; }
            set { base["userType"] = value; }
        }

        [ConfigurationProperty("credentialsType", DefaultValue = null)]
        public string CredentialsType
        {
            get { return (string)base["credentialsType"]; }
            set { base["credentialsType"] = value; }
        }

        [ConfigurationProperty("args", DefaultValue = null)]
        public string Args
        {
            get { return (string)base["args"]; }
            set { base["args"] = value; }
        }

        #endregion
    }
}