using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_task.Data;
using Testing_task.pageObject;
using Testing_task.Reports;

namespace Testing_task.testScripts
{
    public class annotationsTest : extentReport
    {
        public static string _ProductNotInStockMessage =        "There are no Products";
        public static string _ProductSuccessfullyAddedMessage = "Product successfully added to your shopping cart";
        public static string _USER_ALREADY_REGISTERED_MSG =
                                                                "An account using this email address has already been registered. " +
                                                                  "Please enter a valid password or request a new one.";

        public static string _Invalid_Email_Text =               "Invalid email address.";

        private string _accountWelcomingMsg =
                                                                 "Welcome to your account. Here you can manage all of your personal information and orders.";
        [Test,Category("Smoke")]
        public void ChooseSeveralProducts()
        {
            Assert.Multiple(() =>
            {
                test = extent.CreateTest("ChooseSeveralProducts").Info("Test Started");
                addProductPage.SelectProductCategory("Dresses");                                // Selecting Product Category from index page
                test.Log(Status.Info, "Dresses Category Selected");
                addProductPage.SelectDressCategory("Casual Dresses");                           // Selecting Dress category from Menu 
                test.Log(Status.Info, "Casual Dresses Category Selected");
                Assert.AreEqual(addProductPage.verifyTitleInDressCategory(), "CASUAL DRESSES ");//Verifying Dress Title
                test.Log(Status.Info, "Verified Casual Dresses Category Selected");
                addProductPage.SelectSize("S");                                                 //Selecting Size 'S'(Small) 
                test.Log(Status.Info, "Size 'S' Selected");
                addProductPage.SelectSize("M");                                                 //Selecting Size 'M'(Medium) 
                test.Log(Status.Info, "Size 'M' Selected");
                js.ExecuteScript("window.scrollBy(0,500)");                                      //Scrolling Window
                test.Log(Status.Info, "Window Scrolled ");
                addProductPage.SelectCotton();                                                   //Selecting Cotton Form Compositions
                test.Log(Status.Info, "Cotton is Selected");
                //addProductPage.SelectInStock();
                //test.Log(Status.Info, "In Stock is Selected");
                addProductPage.ModifyLeftSlider(90, 0);                                         //Move Left Price Range Slider
                test.Log(Status.Info, "Move Price Range Slider to Left");
                addProductPage.ModifyRightSlider(80, 0);
                test.Log(Status.Info, "Move Price Range Slider to Right");                      //Moving Right Price Slider            
                Assert.True(addProductPage.IsAddToCartBtnPresent());                           //Verfiying Add to Cart Btn is Present or not    
                test.Log(Status.Info, "Add to cart Button is Present");
                addProductPage.ClickAddToCartBtn();                                             //Click Add to Cart Btn
                test.Log(Status.Info, "Add to Cart Button is Clicked");
                Thread.Sleep(5000);
                Assert.IsTrue(addProductPage.IsProductCompleteTextDisplayed(_ProductSuccessfullyAddedMessage));//Verfiying Succesfull message is Shown or not
                Assert.AreEqual(addProductPage.VerifyProductDetails(0, "Product"), "Printed Dress");
                Assert.AreEqual(addProductPage.VerifyProductDetails(1, "Colour and Size"), "Orange, S");
                test.Log(Status.Info, "Product Details are Verified");
                Assert.True(addProductPage.IsContinueShoppingBtnDisplayed());                           //Verfiying Continue Shopping btn is Present or not
                test.Log(Status.Info, "Continue Shopping Btn is Displayed");
                addProductPage.ClickOnContinueShoppingBtn();                                            //Click Continue Shopping Btn
                test.Log(Status.Info, "Clicked On Continue Shopping Btn");
                addProductPage.NavigateToCategories("Products");                                        //navigate to Product Category
                test.Log(Status.Info, "Navigate to Product Category");
                addProductPage.SelectDressCategory("Evening Dresses");                                  //selecting 'evening dresses from Category'
                test.Log(Status.Info, "Select Evening Dress from Dress Category");
                addProductPage.SelectSortByDropDown("Product Name: A to Z");                            //Selecting drop Down
                test.Log(Status.Info, "Selecting option 'Product Name: A to Z' from DropDown ");
                js.ExecuteScript("window.scrollBy(0,500)");
                addProductPage.MoveToProductImageLink();                                               // move the mouse cursor to Image Present
                test.Log(Status.Info, "move the mouse cursor to Image Present");
                addProductPage.ClickOnQuickViewSpan();                                                 // Click on quick view
                test.Log(Status.Info, "Click on quick view ");
                addProductPage.SwitchToIframeProduct();                                              // Switching to Iframe
                test.Log(Status.Info, "Switch to Iframe ");
                addProductPage.ChooseColour("Pink");                                               // Selecting Color 'Pink'
                test.Log(Status.Info, " choosing pink color from choice ");
                addProductPage.ClickAddToCartInIframe();                                          // Clicking on Add to Cart Button Present in Iframe
                test.Log(Status.Info, "Clicking on Add to Cart Button Present in Iframe");
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                addProductPage.SwitchToParentFrame();                                              // switiching Back to Parent Frame -- Existing Iframe
                test.Log(Status.Info, "Switch Back to Parent Frame");
                Assert.IsTrue(addProductPage.IsProductCompleteTextDisplayed(_ProductSuccessfullyAddedMessage)); // Verifying successfull Message
                addProductPage.ClickOnContinueShoppingBtn();
                test.Log(Status.Info, "Clicked On Continue Shopping Btn");
                js.ExecuteScript("window.scrollBy(0,-500)");
                addProductPage.NavigateToCategories("Home");                                  //Click on Home To go back to Home-Page
                test.Log(Status.Info, "Navigate to Home ");
                js.ExecuteScript("window.scrollBy(0,-500)");
                addProductPage.ClickOnShoppingCart();
                test.Log(Status.Info, "Clicked On Shopping Cart and Open it in New tab");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Product"), "Product");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Description"), "Description");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Avail."), "Avail.");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Unit price"), "Unit price");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Qty"), "Qty");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Total"), "Total");
                test.Log(Status.Info, "Verfied all the titles present in Shopping Cart");
                js.ExecuteScript("window.scrollBy(0, 500)");
                addProductPage.ClickProceedToCheckoutBtn();
                test.Log(Status.Info, "Clicked On Proceed to CheckOut Btn");
                //js.ExecuteScript("window.scrollBy(0,2000)");                                 //Scroll down to End of the Page
                //Assert.True(addProductPage.IsContanctUsBtnDisplayed());           
                //addProductPage.ClickOnContactUsBtn();                                        // Click on Contact Us Button
                //Thread.Sleep(10000);
            });
        }


        [Test,Category("Regression")]

        [TestCaseSource(typeof(CreateAnAccountData), nameof(CreateAnAccountData.TestDataForAccount))]

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
        
        [Test,Category("Smoke")]
        public void enter_Several_Keywords_in_Search()
        {

            var validateSearch = new indexPage(driver);
            validateSearch.validateSearchField();
        }



        [Test, Category("UAT"), Category("Smoke")]
        public void validate_web_Images()
        {

            var validateImage = new indexPage(driver);
            validateImage.checkImages();
        }


    }
}

















    