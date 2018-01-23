using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SPM2.Framework.Configuration
{
    public class ProviderElementCollection : ConfigurationElementCollection<ProviderTypes, ProviderElement>
    {
        protected override string ElementName
        {
            get
            {
                return "add";
            }
        }


        public override ConfigurationElementCollectionType CollectionType
        {
            get 
            {
                return ConfigurationElementCollectionType.BasicMap; 
            }
        }

        protected override ProviderTypes GetElementKey(ProviderElement element)
        {
            return element.Name;
        }
    }
}
