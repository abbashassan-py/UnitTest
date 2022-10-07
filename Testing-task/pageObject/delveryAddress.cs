using DocumentFormat.OpenXml.Vml;
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
    public class AddressPage : MethodCollections
    {
        private IWebDriver driver = null;
        private WebDriverWait wait = null;
        private Actions action = null;
        By _addressHeader = new ClassLoc("page-heading");
        By _deliveryCheckbox = new ContainsClassPath("checkbox", "/div");
        By _deliveryAddressDetails = new IDPath("address_delivery", "/li");
        By _invoceDetails = new IDPath("address_invoice", "/li");
        By _textArea = By.XPath("//*[@class = 'form-control'][@name = 'message']");
        By _proceedToCheckOutBtn = By.Name("processAddress");

        private string[] _deliveryAddressTitles = {"Header", "First Name",  "Company","Adresses", "City State and Postal Code",
                                                    "Country","Phone", "Mobile Phone", "Update"};

        public AddressPage(IWebDriver driver, WebDriverWait wait, Actions action) : base(driver, wait, action)
        {
            this.driver = driver;
            this.wait = wait;
            this.action = action;
        }

        public string ReturnHeader()
        {
            return GetTextFromElement(_addressHeader);
        }

        public void ClickOnBillingDeliveryCheckBox()
        {
            webElement(_deliveryCheckbox).Click();
        }

        public string GetDeliveryAddressDetails(string _titles)
        {
            int index = Array.IndexOf(_deliveryAddressTitles, _titles);
            return GetTextFromElements(_deliveryAddressDetails, index);
        }

        public string GetInvoiceDetails(string _titles)
        {
            int index = Array.IndexOf(_deliveryAddressTitles, _titles);
            return GetTextFromElements(_invoceDetails, index);
        }

        public void EnterRandomTextInPlaceHolderArea(string _text)
        {
            webElement(_textArea).SendKeys(_text);
        }

        public void ClickProceedToCheckOutBtn()
        {
            webElement(_proceedToCheckOutBtn).Click();
        }
    }
}

