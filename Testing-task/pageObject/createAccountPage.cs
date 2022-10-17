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
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace Testing_task.pageObject
{
    public class CreateAccountPage : MethodCollections
    {
        private IWebDriver driver = null;
        private WebDriverWait wait = null;
        private SelectElement select = null;
        private Actions action = null;

        private string[] _radioTitles = { "Mr.", "Mrs." };
        private string[] _monthsTitles = { "-","January ", "February", "March", "April", "May", "June", "July",
                                           "August", "September", "October", "November", "December" };
        private string[] _checkBoxTitles = { "Sign up for our newsletter!", "Receive special offers from our partners!" };
        private string[] _statesTitles = { "-", "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware" };

        By _signIn = new ClassLoc("login");
        By _enterEmail = By.Id("email_create");
        By _createAccountBtn = By.Id("SubmitCreate");
        By _ErrorMsg = new IDPath("create_account_error", "ol/li");

        By _radioButtons = new ClassLoc("radio-inline");
        By firstName = By.Id("customer_firstname");
        By lastName = By.Id("customer_lastname");
        By _passwordPlaceholder = By.Id("passwd");  
        By _selectDaysDrop = By.Id("days"); 
        By _selectMonthDrop = By.Id("months");
        By _selectYear = By.Id("years");
        By _newsLettersCheckBx = new ClassLoc("checker");
        By _customerFirstName = By.Id("firstname");
        By _customerLastName = By.Id("lastname");
        By _customerCompany = By.Id("company");
        By _address1 = By.Id("address1");
        By _address2 = By.Id("address2");
        By _city = By.Id("city");
        By _state = By.Id("id_state");
        By _statePlaceHolder = By.Id("uniform-id_state");
        By _postalCode = By.Id("postcode");
        By _addInfo = By.Id("other");
        By _homePhone = By.Id("phone");
        By _mobilePhone = By.Id("phone_mobile");
        By _addressAlias = By.Id("alias");
        By _registerBtn = By.Id("submitAccount");
        By _infoAccountMessage = new ClassLoc("info-account");





        public CreateAccountPage(IWebDriver driver, WebDriverWait wait, Actions action) : base(driver, wait, action)
        {
            this.driver = driver;
            this.wait = wait;
            this.select = select;
            this.action = action;
        }

        public void ClickOnSingIn()
        {
            webElement(_signIn).Click();
        }

        public void EnterEmailAddress(string email)
        {
            webElement(_enterEmail).SendKeys(email);
        }
        public void ClearEmailAddress()
        {
            webElement(_enterEmail).Clear();
        }

        public string CheckEmailTextIsInserted(string _value)
        {
            return GetAttributeFromElement(_enterEmail, _value);
        }

        public string GetErrorMessage()
        {
            return GetTextFromElement(_ErrorMsg);
        }

        public void ClickOnCreatAccount()
        {
            webElement(_createAccountBtn).Click();
        }

        public void ChooseGender(string gender)
        {
            int index = Array.IndexOf(_radioTitles, gender);
            webElements(_radioButtons)[index].Click();
        }

        public void EnterFirstName(string Fname)
        {
            webElement(firstName).SendKeys(Fname);
        }

        public string EnteredFirstNameCheck(string _value)
        {
            return GetAttributeFromElement(firstName, _value);
        }

        public void EnterLastName(string LName)
        {
            webElement(lastName).SendKeys(LName);
        }

        public string EnteredLastNameCheck(string _value)
        {
            return GetAttributeFromElement(lastName, _value);
        }

        public void EnterPassword(string password)
        {
            webElement(_passwordPlaceholder).SendKeys(password);
        }
        public string EnteredPasswordCheck(string _value)
        {
            return GetAttributeFromElement(_passwordPlaceholder, _value);
        }

        public void SelectDays(int _days)
        {
            select = new SelectElement(driver.FindElement(_selectDaysDrop));
            select.SelectByValue("" + _days);

        }
        public void SelectMonth(string _months)
        {
            int index = Array.IndexOf(_monthsTitles, _months);
            select = new SelectElement(driver.FindElement(_selectMonthDrop));
            select.SelectByIndex(index);
        }
        public void SelectMonthByValue(int _month)
        {
            Console.WriteLine(_month);
            select = new SelectElement(driver.FindElement(_selectMonthDrop));
            select.SelectByValue("" + _month.ToString());
        }
        public void SelectYear(int year)
        {
            select = new SelectElement(driver.FindElement(_selectYear));
            select.SelectByValue("" + year);

        } 

        public void SelectCheckBoxOffer(string _titles)
        {
            int index = Array.IndexOf(_checkBoxTitles, _titles);
            webElements(_newsLettersCheckBx)[index].Click();
        }

        public string CustomerFirstNameIsInserted(string _value)
        {
            return GetAttributeFromElement(_customerFirstName, _value);
        }


        public string CustomerLastNameIsInserted(string _value)
        {
            return GetAttributeFromElement(_customerLastName, _value);
        }

        public void EnterCustomerAddress(string _address)
        {
            webElement(_address1).SendKeys(_address);
        }
        public string CustomerAddressIsInserted(string _value)
        {
            return GetAttributeFromElement(_address1, _value);
        }

        public void EnterCustomerAddress2(string _address2)
        {
            webElement(this._address2).SendKeys(_address2);
        }
        public string CustomerAddress2Inserted(string _value)
        {
            return GetAttributeFromElement(_address2, _value);
        }
        public void EnterCompany(string _company)
        {
            webElement(_customerCompany).SendKeys(_company);
        }

        public string CustomerCompanyisInserted(string _value)
        {
            return GetAttributeFromElement(_customerCompany, _value);
        }

        public void EnterCity(string _cityName)
        {
            webElement(_city).SendKeys(_cityName);
        }

        public string IsCityInserted(string _value)
        {
            return GetAttributeFromElement(_city, _value);
        }

        public void SelectState(string _states)
        {
            select = new SelectElement(driver.FindElement(_state));
            select.SelectByText(_states);
        }
        public void EnterPostalCode(int _postalCodeNumber)
        {
            webElement(_postalCode).SendKeys("" + _postalCodeNumber);
        }

        public string IsPostalCodeInserted(string _value)
        {
            return GetAttributeFromElement(_postalCode, _value);
        }

        public void EnterAdditionalInfo(string _text)
        {
            webElement(_addInfo).SendKeys(_text);
        }
        public string IsAddInfoInserted(string _value)
        {
            return GetAttributeFromElement(_addInfo, _value);
        }

        public void EnterHomeNumber(int _number)
        {
            webElement(_homePhone).SendKeys("" + _number);
        }
        public string IsHomeNumberInserted(string _value)
        {
            return GetAttributeFromElement(_homePhone, _value);
        }

        public void EnterMobileNumber(int _number)
        {
            webElement(_mobilePhone).SendKeys("" + _number);
        }
        public string IsMobileNUmberInserted(string _value)
        {
            return GetAttributeFromElement(_mobilePhone, _value);
        }

        public void EnterAliasAddress(string _address)
        {
            webElement(_addressAlias).SendKeys("" + _address);
        }

        public void ClearAliasAddresField()
        {
            webElement(_addressAlias).Clear();
        }

        public string IsAliasAddressInserted(string _value)
        {
            return GetAttributeFromElement(_addressAlias, _value);
        }

        public void ClickOnRegisterBtn()
        {
            webElement(_registerBtn).Click();
        }

        public string MessageForCreatingAccount()
        {
            return GetTextFromElement(_infoAccountMessage);
        }




    }
}
