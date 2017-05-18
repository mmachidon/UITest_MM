using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITest.Base_Components
{
    public enum Locator
    {
        Id,
        CssSelector,
        LinkText,
        Name,
        TagName,
        XPath
    }
    public class ElementLocator
    {
        public ElementLocator(Locator type, string value)
        {
            this.Type= type;
            this.Value = value;
        }
        public Locator Type { get; set; }
        public string Value { get; set; }  
      
    }

}
