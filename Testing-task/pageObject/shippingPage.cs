using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_task.ActionMethods;
using Testing_task.CustomLocators;

namespace Testing_task.pageObject
{
    public class ShippingPage : MethodCollections
    {
        private IWebDriver driver = null;
        private WebDriverWait wait = null;
        private Actions action = null;

        By _shippingHeader = new ClassLoc("page-heading");
        By _shippingOptionHeader = new ContainsText("Choose a shipping");
        By _termsAndServicesChbx = By.Id("uniform-cgv");
        By _proceedToCheckoutBtn = By.XPath("//*[@name ='processCarrier' and contains(@class, 'button-medium')]");

        public ShippingPage(IWebDriver driver, WebDriverWait wait, Actions action) : base(driver, wait, action)
        {
            this.driver = driver;
            this.wait = wait;
            this.action = action;
        }

        public string GetShippingHeader()
        {
            return GetTextFromElement(_shippingHeader);
        }

        public string GetChooseShippingOptionsText()
        {
            return GetTextFromElement(_shippingOptionHeader);
        }

        public void ClickOnTermsAndCondCheckbox()
        {
            webElement(_termsAndServicesChbx).Click();
        }

        public void ClickOnProceedToCheckoutBtn()
        {
            webElement(_proceedToCheckoutBtn).Click();
        }
        public bool IsProceedCheckoutBtnDisplayed()
        {
            return ElementIsDisplayed(_proceedToCheckoutBtn);
        }

        public bool IsShippingOptionTextDisplayed(string _value)
        {
            return TextInElement(_shippingOptionHeader, _value);
        }
    }
}
