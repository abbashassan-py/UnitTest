using AventStack.ExtentReports;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

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
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;
using System.Xml;


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


        [Test, Category("UAT"), Category("Smoke")]

        [TestCaseSource(typeof(CreateAnAccountData), nameof(CreateAnAccountData.TestDataForAccount))]
        [TestCaseSource(typeof(CreateAnAccountData), nameof(CreateAnAccountData.TestDataForAccount_1))]

        //[TestCase("Sampleee12344@mail.com",true, false, "Mr.")]
        //[TestCase("abbas.hassan@contour-software.com", true, true, "Mr.")]
        //[TestCase("Sampleee12344@@mail.com", false, "Mr.")]
        //[TestCase("Aaaaaaaaabbcd@mail.com", true, "Mr.")]
        //[TestCase("bvcfha@mail.com", true, "Mrs.")]
        //[TestCase("mailXyzmailmail@gmail,com", false, true, "Mrs.")]

        public void createAnAccount(string email, string gender, string firstName, string lastName,
                                       string _password, int _days, string _month, int _year, string _checkBoxOffer,
                                       string _company, string _customerAddress1, string _customerAddress2, string _cityName,
                                       string _state, int _postalCode, string _additionalInfo, int _homePhone, int _mobileNum, string _alias)

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
                Console.WriteLine("Invalid email or User Already Registered" + email);
                Assert.That(createAccountPage.GetErrorMessage(), Is.AnyOf(_USER_ALREADY_REGISTERED_MSG, _Invalid_Email_Text));
                test.Log(Status.Info, createAccountPage.GetErrorMessage() + " ==> " + email);
            }

        }

        [Test, Category("DataDrivenTestingUsingSQL")]
        public void DataDrivenTestingUsingSQL()
        {
            var flag = false;
            SqlConnection con1 = new SqlConnection("Data Source=CRKRL-HASSAABB1;Initial Catalog=Testing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False ");
            con1.Open();
            string query2 = "update form set email = 'zain'+REPLACE(REPLACE(CONVERT(nvarchar,GETDATE()),' ',''),':','')+'@gmail.com' where title = 'Mr.'";
            SqlCommand cmd2 = new SqlCommand(query2, con1);
            string query = "Select * from form";
            SqlDataReader reader2 = cmd2.ExecuteReader();
            reader2.Close();
            SqlCommand cmd = new SqlCommand(query, con1);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (!flag)
                {
                    createAccountPage.ClickOnSingIn();
                    Thread.Sleep(5000);
                }
                string email = reader.GetString(3).Trim();
                createAccountPage.EnterEmailAddress(email);
                Console.WriteLine(email);
                createAccountPage.ClickOnCreatAccount();
                Thread.Sleep(5000);
                //createAccountPage.ClearEmailAddress()
                string title = reader.GetString(0).Trim();
                createAccountPage.ChooseGender(title);
                string fname = reader.GetString(1).Trim();
                createAccountPage.EnterFirstName(fname);
                string lname = reader.GetString(2).Trim();
                createAccountPage.EnterLastName(lname);
                string pwd = reader.GetString(4).Trim();
                createAccountPage.EnterPassword(pwd);
                string dob = reader.GetDateTime(5).ToString("dd/MM/yyy");
                string[] arrDob = dob.Split('/');
                string days = arrDob[0].ToString();
                createAccountPage.SelectDays(Convert.ToInt32(days));
                string month = arrDob[1].ToString();
                createAccountPage.SelectMonthByValue(Convert.ToInt32(month));
                string year = arrDob[2].ToString();
                createAccountPage.SelectYear(Convert.ToInt32(year));
                string company = reader.GetString(6).Trim();
                createAccountPage.EnterCompany(company);
                string customerAddress1 = reader.GetString(7).Trim();
                createAccountPage.EnterCustomerAddress(customerAddress1);
                string customerAddress2 = reader.GetString(8).Trim();
                createAccountPage.EnterCustomerAddress2(customerAddress2);
                string city = reader.GetString(9).Trim();
                createAccountPage.EnterCity(city);
                string state = reader.GetString(10).Trim();
                createAccountPage.SelectState(state);
                string postalcode = reader.GetString(11).Trim();
                createAccountPage.EnterPostalCode(Convert.ToInt32(postalcode));
                string additionalInfo = reader.GetString(13).Trim();
                createAccountPage.EnterAdditionalInfo(additionalInfo);
                string homePhone = reader.GetString(14).Trim();
                createAccountPage.EnterHomeNumber(Convert.ToInt32(homePhone));
                string mobilePhone = reader.GetString(15).Trim();
                createAccountPage.EnterMobileNumber(Convert.ToInt32(mobilePhone));


            }
        }



        [Test, Category("DataDrivenTestingUsingXML")]
        public void DataDrivenTestingUsingXML()
        {
            XmlTextReader xmlTextReader = new XmlTextReader("C:\\Test\\Auto_Test\\Auto_Test\\Testing-task\\data.xml");
            while (xmlTextReader.Read())
            {
                if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "email")
                {
                    createAccountPage.ClickOnSingIn();
                    string email = xmlTextReader.ReadElementString();
                    createAccountPage.EnterEmailAddress(email);
                    createAccountPage.ClickOnCreatAccount();
                }
                if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "fname")
                {

                    string fname = xmlTextReader.ReadElementString();
                    createAccountPage.EnterFirstName(fname);
                    string lname = xmlTextReader.ReadElementString();
                    createAccountPage.EnterLastName(lname);
                    string pwd = xmlTextReader.ReadElementString();
                    createAccountPage.EnterPassword(pwd);
                    string day = xmlTextReader.ReadElementString();
                    createAccountPage.SelectDays(Convert.ToInt32(day));
                    string month = xmlTextReader.ReadElementString();
                    createAccountPage.SelectMonth(month);
                    string year = xmlTextReader.ReadElementString();
                    createAccountPage.SelectYear(Convert.ToInt32(year));
                    string company = xmlTextReader.ReadElementString();
                    createAccountPage.EnterCompany(company);
                    string customerAddress1 = xmlTextReader.ReadElementString();
                    createAccountPage.EnterCustomerAddress(customerAddress1);
                    string customerAddress2 = xmlTextReader.ReadElementString();
                    createAccountPage.EnterCustomerAddress2(customerAddress2);
                    string city = xmlTextReader.ReadElementString();
                    createAccountPage.EnterCity(city);
                    string state = xmlTextReader.ReadElementString();
                    createAccountPage.SelectState(state);
                    string postalcode = xmlTextReader.ReadElementString();
                    createAccountPage.EnterPostalCode(Convert.ToInt32(postalcode));
                    string additionalInfo = xmlTextReader.ReadElementString();
                    createAccountPage.EnterAdditionalInfo(additionalInfo);
                    string homePhone = xmlTextReader.ReadElementString();
                    createAccountPage.EnterHomeNumber(Convert.ToInt32(homePhone));
                    string mobilePhone = xmlTextReader.ReadElementString();
                    createAccountPage.EnterMobileNumber(Convert.ToInt32(mobilePhone));


                    Thread.Sleep(5000);
                }

            }
        }


        //while (textReader.Read())
        //{
        //    createAccountPage.ClickOnSingIn();

        //    textReader.MoveToElement();
        //    string email = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.DataRow[0].ToString();
        //    Console.WriteLine("Name:" + textReader.Name);

        //    Thread.Sleep(5000);
        //createAccountPage.ClearEmailAddress()
        //string title = reader_1.GetString(0).Trim();
        //createAccountPage.ChooseGender(title);
        //string fname = reader_1.GetString(1).Trim();
        //createAccountPage.EnterFirstName(fname);
        //string lname = reader.GetString(2).Trim();
        //createAccountPage.EnterLastName(lname);
        //string pwd = reader.GetString(4).Trim();
        //createAccountPage.EnterPassword(pwd);
        //string dob = reader.GetDateTime(5).ToString("dd/MM/yyy");
        //string[] arrDob = dob.Split('/');
        //string days = arrDob[0].ToString();
        //createAccountPage.SelectDays(Convert.ToInt32(days));
        //string month = arrDob[1].ToString();
        //createAccountPage.SelectMonthByValue(Convert.ToInt32(month));
        //string year = arrDob[2].ToString();
        //createAccountPage.SelectYear(Convert.ToInt32(year));
        //string company = reader.GetString(6).Trim();
        //createAccountPage.EnterCompany(company);
        //string customerAddress1 = reader.GetString(7).Trim();
        //createAccountPage.EnterCustomerAddress(customerAddress1);
        //string customerAddress2 = reader.GetString(8).Trim();
        //createAccountPage.EnterCustomerAddress2(customerAddress2);
        //string city = reader.GetString(9).Trim();
        //createAccountPage.EnterCity(city);
        //string state = reader.GetString(10).Trim();
        //createAccountPage.SelectState(state);
        //string postalcode = reader.GetString(11).Trim();
        //createAccountPage.EnterPostalCode(Convert.ToInt32(postalcode));
        //string additionalInfo = reader.GetString(13).Trim();
        //createAccountPage.EnterAdditionalInfo(additionalInfo);
        //string homePhone = reader.GetString(14).Trim();
        //createAccountPage.EnterHomeNumber(Convert.ToInt32(homePhone));
        //string mobilePhone = reader.GetString(15).Trim();
        //createAccountPage.EnterMobileNumber(Convert.ToInt32(mobilePhone));


    }



}







