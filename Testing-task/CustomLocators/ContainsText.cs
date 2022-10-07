using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_task.CustomLocators
{
    public class ContainsText : By
    {
        public ContainsText(string _value)
        {
            FindElementMethod = (ISearchContext context) =>
            {
                IWebElement mockElement = context.FindElement(By.XPath("//*[contains(text(),'" + _value + "')]"));
                return mockElement;
            };

            FindElementsMethod = (ISearchContext context) =>
            {
                ReadOnlyCollection<IWebElement> mockElements = context.FindElements(By.XPath("//*[contains(text(),'" + _value + "')]"));
                return (ReadOnlyCollection<IWebElement>)(IWebElement)mockElements;
            };
        }
    }
}
