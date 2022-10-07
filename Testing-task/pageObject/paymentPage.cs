using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Testing_task.ActionMethods;
using Testing_task.CustomLocators;

namespace Testing_task.pageObject
{
    public class PaymentPage : MethodCollections
    {
        private IWebDriver driver = null;
        private WebDriverWait wait = null;
        private Actions action = null;

        By _paymentMethod = new IDPath("HOOK_PAYMENT", "/div/div/p");
        By _pageSubHeader = new ClassLoc("page-subheading");
        By _checkDetails = new ClassPath("box cheque-box", "/p");
        By _confirmOrderBtn = By.XPath("//*[contains(@class, 'button-medium') and @type='submit']");
        By _paymentPageHeader = new ClassLoc("page-heading");

        private string[] _paymentMethodTitles = { "Pay by Bank Wire", "Pay by check" };
        private string[] _checkDetailsParagrapghs = { "Summary", "Total Amount", "Currency", "Confirm your order" };

        public PaymentPage(IWebDriver driver, WebDriverWait wait, Actions action) : base(driver, wait, action)
        {
            this.driver = driver;
            this.wait = wait;
            this.action = action;
        }

        public string GetPaymentMethodHeader()
        {
            return GetTextFromElement(_paymentPageHeader);
        }

        public void ChoosePaymentMethod(string _titles)
        {
            int index = Array.IndexOf(_paymentMethodTitles, _titles);
            webElements(_paymentMethod)[index].Click();
        }

        public string GetPageSubHeader()
        {
            return GetTextFromElement(_pageSubHeader);
        }

        public string GetCheckDetails(string _titles)
        {
            int index = Array.IndexOf(_checkDetailsParagrapghs, _titles);
            return GetTextFromElements(_checkDetails, index);
        }

        public bool IsConfirmBtnDisplayed()
        {
            return ElementIsDisplayed(_confirmOrderBtn);
        }

        public void ClickOnConfirmOrderBtn()
        {
            webElement(_confirmOrderBtn).Click();
        }
    }
}
