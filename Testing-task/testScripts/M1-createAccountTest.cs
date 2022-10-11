using AventStack.ExtentReports;
using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_task.pageObject;
using Testing_task.Reports;
using TestProject_01.baseClass;

namespace Testing_task.testScripts
{
    public class M1_createAccountPageTest : extentReport
    {
        public static string _USER_ALREADY_REGISTERED_MSG =
            "An account using this email address has already been registered. " +
            "Please enter a valid password or request a new one.";

        public static string _Invalid_Email_Text = "Invalid email address.";
         
        private string _accountWelcomingMsg = 
          "Welcome to your account. Here you can manage all of your personal information and orders.";

        public class CreateAnAccountData
        {
            public static object[] TestDataForAccount =
            {
            new object [] {"abba.s.hasssan.1(@)contour-software.com","Mr.", "abbas", "hassan", "Password1",11, "March", 2000, "Sign up for our newsletter!",
                            "Company", "Address1", "Address2", "City1", "Alabama", 75304, "Additional Info", 222111, 9876789, "CKKR" }

             };

            public static object[] TestDataForAccount_1 =
{
            new object[]
            {
                $"HaiderHassan{DateTime.Now.ToString("MM/dd/yyy hh:mm tt").Replace(" ", "").Replace("/", "").Replace(":", "")}@conntour-sofware.com",
                "Mr.",
                "Haider",
                "hassan",
                "Password1",
                7,
                "July",
                2022,
                "Sign up for our newsletter!",
                "Company",
                "Address1",
                "Address2",
                "City1",
                "Alabama",
                35004,
                "Additional Info",
                452778,
                911345329,
                "Allias 2"
            }
        };
        }


        [Test,Category("UAT"),Category("Smoke")]

        [TestCaseSource(typeof(CreateAnAccountData), nameof(CreateAnAccountData.TestDataForAccount))]
        [TestCaseSource(typeof(CreateAnAccountData), nameof(CreateAnAccountData.TestDataForAccount_1))]

        //[TestCase("Sampleee12344@mail.com",true, false, "Mr.")]
        //[TestCase("abbas.hassan@contour-software.com", true, true, "Mr.")]
        //[TestCase("Sampleee12344@@mail.com", false, "Mr.")]
        //[TestCase("Aaaaaaaaabbcd@mail.com", true, "Mr.")]
        //[TestCase("bvcfha@mail.com", true, "Mrs.")]
        //[TestCase("mailXyzmailmail@gmail,com", false, true, "Mrs.")]

        public void createAnAccount(   string email, string gender, string firstName, string lastName,
                                       string _password, int _days, string _month, int _year, string _checkBoxOffer,
                                       string _company, string _customerAddress1, string _customerAddress2, string _cityName,
                                       string _state, int _postalCode, string _additionalInfo, int _homePhone, int _mobileNum,string _alias)

        {
            test = extent.CreateTest("createAnAccount").Info("Test Started");
            try
            {
                createAccountPage.ClickOnSingIn();
                test.Log(Status.Info, "Sign In Button Clicked");

                createAccountPage.EnterEmailAddress(email);
                test.Log(Status.Info, "Email Address Entered");

                createAccountPage.ClickOnCreatAccount();
                test.Log(Status.Info, "Create Account Button Clicked");


                createAccountPage.ChooseGender(gender);
                test.Log(Status.Info, "Gender Selected through Radio Btn");

                createAccountPage.EnterFirstName(firstName);
                test.Log(Status.Info, "Enter First Name");
                Assert.AreEqual(createAccountPage.EnteredFirstNameCheck("value"), firstName);

                createAccountPage.EnterLastName(lastName);
                test.Log(Status.Info, "Enter last Name");
                Assert.AreEqual(createAccountPage.EnteredLastNameCheck("value"), lastName);

                createAccountPage.EnterPassword(_password);
                test.Log(Status.Info, "Enter password");
                Assert.AreEqual(createAccountPage.EnteredPasswordCheck("value"), _password);

                createAccountPage.SelectDays(_days);
                test.Log(Status.Info, "Enter Days");

                createAccountPage.SelectMonth(_month);
                test.Log(Status.Info, "Enter month");

                createAccountPage.SelectYear(_year);
                test.Log(Status.Info, "Enter year");

                createAccountPage.SelectCheckBoxOffer(_checkBoxOffer);
                test.Log(Status.Info, "select check box");

                js.ExecuteScript("window.scrollBy(0,500)");

                Assert.AreEqual(createAccountPage.CustomerFirstNameIsInserted("value"), firstName);
                Assert.AreEqual(createAccountPage.CustomerLastNameIsInserted("value"), lastName);

                createAccountPage.EnterCompany(_company);
                Assert.AreEqual(createAccountPage.CustomerCompanyisInserted("value"), _company);

                createAccountPage.EnterCustomerAddress(_customerAddress1);
                Assert.AreEqual(createAccountPage.CustomerAddressIsInserted("value"), _customerAddress1);

                createAccountPage.EnterCustomerAddress2(_customerAddress2);
                Assert.AreEqual(createAccountPage.CustomerAddress2Inserted("value"), _customerAddress2);

                js.ExecuteScript("window.scrollBy(0,500)");

                createAccountPage.EnterCity(_cityName);
                test.Log(Status.Info, "Enter City name");

                Assert.AreEqual(createAccountPage.IsCityInserted("value"), _cityName);

                createAccountPage.SelectState(_state);
                test.Log(Status.Info, "select state");

                createAccountPage.EnterPostalCode(_postalCode);
                test.Log(Status.Info, "Enter postal Code");

                Assert.AreEqual(createAccountPage.IsPostalCodeInserted("value"), "" + _postalCode);

                createAccountPage.EnterAdditionalInfo(_additionalInfo);
                test.Log(Status.Info, "Enter Additional Info");
                Assert.AreEqual(createAccountPage.IsAddInfoInserted("value"), _additionalInfo);

                createAccountPage.EnterHomeNumber(_homePhone);
                Assert.AreEqual(createAccountPage.IsHomeNumberInserted("value"), "" + _homePhone);
                test.Log(Status.Info, "Enter Home Number");

                createAccountPage.EnterMobileNumber(_mobileNum);
                Assert.AreEqual(createAccountPage.IsMobileNUmberInserted("value"), "" + _mobileNum);
                test.Log(Status.Info, "Enter mobile Number");

                createAccountPage.ClearAliasAddresField();
                test.Log(Status.Info, "Alias Filed Cleared");
                createAccountPage.EnterAliasAddress(_alias);
                Assert.AreEqual(createAccountPage.IsAliasAddressInserted("value"), _alias);

                createAccountPage.ClickOnRegisterBtn();
                test.Log(Status.Info, "Click On Register Btn");
                Assert.AreEqual(createAccountPage.MessageForCreatingAccount(), _accountWelcomingMsg);
                test.Log(Status.Info, "Welcoming Message Displayed");
            }

            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Invalid email or User Already Registered" + email );
                Assert.That(createAccountPage.GetErrorMessage(), Is.AnyOf(_USER_ALREADY_REGISTERED_MSG, _Invalid_Email_Text));
                test.Log(Status.Info, createAccountPage.GetErrorMessage() + " ==> " + email);
            }

        }
    }
}

