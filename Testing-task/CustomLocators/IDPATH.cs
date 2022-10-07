using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_task.CustomLocators
{
    public class IDPath : By
    {
        public IDPath(string _value, string _additionalPath)
        {
            FindElementMethod = (ISearchContext context) =>
            {
                IWebElement mockElement = context.FindElement(By.XPath("//*[@id ='" + _value + "']/" + _additionalPath));
                return mockElement;
            };

            FindElementsMethod = (ISearchContext context) =>
            {
                ReadOnlyCollection<IWebElement> mockElements = context.FindElements(By.XPath("//*[@id ='" + _value + "']/" + _additionalPath));
                return mockElements;
            };
        }
    }
}
