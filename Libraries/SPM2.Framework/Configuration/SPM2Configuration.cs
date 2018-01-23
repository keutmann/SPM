using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SPM2.Framework.Configuration
{
    public class SPM2Configuration : ConfigurationSection
    {
        private const string SPM2SECTION_NAME = "SPM2";
        private const string PROVIDERS_NAME = "Providers";

        public SPM2Configuration()
        {
        }


        [ConfigurationProperty(PROVIDERS_NAME)]
        public ProviderElementCollection Providers
        {
            get
            {
                return (ProviderElementCollection)this[PROVIDERS_NAME] ?? new ProviderElementCollection();
            }
        }

        /// <summary>
        /// Returns an ProvidersSection instance
        /// </summary>
        public static SPM2Configuration GetConfig()
        {
            return (SPM2Configuration)ConfigurationManager.GetSection(SPM2SECTION_NAME) ?? new SPM2Configuration();
        }


        public static SPM2Configuration Current
        {
            get
            {
                return Nested._current;
            }
        }

        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly SPM2Configuration _current = GetConfig();
        }


    }
}
