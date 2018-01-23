using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPM2.Framework.Components
{
    public class FirstAcceptRuleEngine<TSource>  
    {
        private IEnumerable<IRule<TSource>> _rules;

        public FirstAcceptRuleEngine(IEnumerable<IRule<TSource>> rules)
        {
            _rules = rules;
        }

        public bool Check(TSource source, bool defaultValue)
        {
            foreach (var item in _rules)
            {
                if (item.Accept(source))
                {
                    return item.Check(source);
                }
            }

            return defaultValue;
        }
    }
}
