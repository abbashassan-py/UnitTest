using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using Testing_task.Data;
using Testing_task.pageObject;
using Testing_task.Reports;


namespace Testing_task.testScripts
{
    public class endToend : extentReportE2E
    {

        public string _ProductSuccessfullyAddedMessage = "Product successfully added to your shopping cart";
        public string _accountWelcomingMsg = "Welcome to your account. Here you can manage all of your personal information and orders.";
        public string _BILLING_HEADER_TITLE = "Shopping-cart summary";
        public string _DELIVERY_HEADER = "YOUR DELIVERY ADDRESS";
        public string _BILING_DETAILS_HEADER = "YOUR BILLING ADDRESS";
        public string _SHIPPING_HEADER = "SHIPPING";
        public string _PAYMENT_PAGE_HEADER = "PLEASE CHOOSE YOUR PAYMENT METHOD";
        public string _ORDER_SUMMARY_HEADER = "ORDER SUMMARY";
        public string _PAGE_SUMMARY_SUB_HEADER = "BANK-WIRE PAYMENT.";


        [TestCaseSource(typeof(CreateAnAccountData), nameof(CreateAnAccountData.TestDataForAccount))]
        public void EndToEnd(string email, string gender, string firstName, string lastName,
                                       string _password, int _days, string _month, int _year, string _checkBoxOffer,
                                       string _company, string _customerAddress1, string _customerAddress2, string _cityName,
                                       string _state, int _postalCode, string _additionalInfo, int _homePhone, int _mobileNum, string _alias)

        {

            // Sign-in
            test = extent.CreateTest("CreateAnAccount").Info("Test Started_1");
            createAccountPage.ClickOnSingIn();
            test.Log(Status.Info, "Sign In Button Clicked");
            createAccountPage.EnterEmailAddress(email);
            test.Log(Status.Info, "Email Address Entered");
            createAccountPage.ClickOnCreatAccount();
            test.Log(Status.Info, "Create Account Button Clicked");

            // Registration - Form

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


            addProductPage.NavigateToCategories("Home");

            // Choosing Products

            test = extent.CreateTest("ChooseSeveralProducts").Info("Test Started_2");

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

            Assert.AreEqual(addProductPage.VerifySummaryTitles("Product"), "Product");           /*         verfiying Summary titles      */
            Assert.AreEqual(addProductPage.VerifySummaryTitles("Description"), "Description");
            Assert.AreEqual(addProductPage.VerifySummaryTitles("Avail."), "Avail.");
            Assert.AreEqual(addProductPage.VerifySummaryTitles("Unit price"), "Unit price");
            Assert.AreEqual(addProductPage.VerifySummaryTitles("Qty"), "Qty");
            Assert.AreEqual(addProductPage.VerifySummaryTitles("Total"), "Total");
            test.Log(Status.Info, "Verfied all the titles present in Shopping Cart");
            js.ExecuteScript("window.scrollBy(0, 500)");
            addProductPage.ClickProceedToCheckoutBtn();                                             //Proceed to Check out Btn clicked
            test.Log(Status.Info, "Clicked On Proceed to CheckOut Btn");



            //Address

            test = extent.CreateTest("Address Page").Info("Test Started_3");
            driver.SwitchTo().Window(driver.WindowHandles[2]);
            js.ExecuteScript("window.scrollBy(0,400)");
            addressPage.ClickOnBillingDeliveryCheckBox();
            test.Log(Status.Info, "Click on Chexk Box");
            Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Header"), _DELIVERY_HEADER);
            test.Log(Status.Info, " delivery address header displayed");
            Assert.AreEqual(addressPage.GetDeliveryAddressDetails("First Name"), firstName + " " + lastName);
            test.Log(Status.Info, "Full name displayed ");
            Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Company"), _company);
            test.Log(Status.Info, "Company name displayed ");
            Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Adresses"), _customerAddress1 + " " + _customerAddress2);
            test.Log(Status.Info, "Adresses displayed ");
            Assert.AreEqual(addressPage.GetDeliveryAddressDetails("City State and Postal Code"), _cityName + ", " + _state + " " + _postalCode);
            test.Log(Status.Info, "City State and Postal Code displayed ");
            Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Country"), "United States");
            test.Log(Status.Info, "Country displayed ");
            Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Phone"), "" + _homePhone);
            test.Log(Status.Info, "Phone displayed ");
            Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Mobile Phone"), "" + _mobileNum);
            test.Log(Status.Info, "Mobile Phone displayed ");

            Assert.AreEqual(addressPage.GetInvoiceDetails("Header"), _BILING_DETAILS_HEADER);
            test.Log(Status.Info, " Billing address header displayed");
            Assert.AreEqual(addressPage.GetInvoiceDetails("First Name"), firstName + " " + lastName);
            test.Log(Status.Info, "Full name displayed ");
            Assert.AreEqual(addressPage.GetInvoiceDetails("Company"), _company);
            test.Log(Status.Info, "Company name displayed ");
            Assert.AreEqual(addressPage.GetInvoiceDetails("Adresses"), _customerAddress1 + " " + _customerAddress2);
            test.Log(Status.Info, "Adresses displayed ");
            Assert.AreEqual(addressPage.GetInvoiceDetails("City State and Postal Code"), _cityName + ", " + _state + " " + _postalCode);
            test.Log(Status.Info, "City State and Postal Code displayed ");
            Assert.AreEqual(addressPage.GetInvoiceDetails("Country"), "United States");
            test.Log(Status.Info, "Country displayed ");
            Assert.AreEqual(addressPage.GetInvoiceDetails("Phone"), "" + _homePhone);
            test.Log(Status.Info, "Phone displayed ");
            Assert.AreEqual(addressPage.GetInvoiceDetails("Mobile Phone"), "" + _mobileNum);
            test.Log(Status.Info, "Mobile Phone displayed ");
            addressPage.EnterRandomTextInPlaceHolderArea("Random text is inserted");
            test.Log(Status.Info, "Random text is inserted ");
            js.ExecuteScript("window.scrollBy(0,500)");
            addressPage.ClickProceedToCheckOutBtn();
            test.Log(Status.Info, "Proceed To Check Out Btn Clicked");

            //Shipping

            test = extent.CreateTest("Shipping Page").Info("Test Started_4");
            Assert.AreEqual(shippingPage.GetShippingHeader(), _SHIPPING_HEADER);
            test.Log(Status.Info, " shipping address header displayed");
            shippingPage.ClickOnTermsAndCondCheckbox();
            test.Log(Status.Info, " Click On Terms And Cond. Checkbox");
            js.ExecuteScript("window.scrollBy(0,500)");
            Assert.True(shippingPage.IsProceedCheckoutBtnDisplayed());
            shippingPage.ClickOnProceedToCheckoutBtn();
            test.Log(Status.Info, "Proceed To Check Out Btn Clicked");


          
            
                //PAYMENT PAGE
                Assert.AreEqual(paymentPage.GetPaymentMethodHeader(), _PAYMENT_PAGE_HEADER);
                js.ExecuteScript("window.scrollBy(0,500)");
                paymentPage.ChoosePaymentMethod("Pay by Bank Wire");
                test.Log(Status.Info, "choose 'Pay by Bank Wire' Method");
                Assert.AreEqual(paymentPage.GetPaymentMethodHeader(), _ORDER_SUMMARY_HEADER);
                test.Log(Status.Info, " order Summary header displayed");
                Assert.AreEqual(paymentPage.GetPageSubHeader(), _PAGE_SUMMARY_SUB_HEADER);
                test.Log(Status.Info, " page Summary Sub header displayed");
                Assert.AreEqual(paymentPage.GetCheckDetails("Summary"), "You have chosen to pay by bank wire. Here is a short summary of your order:");

                Assert.AreEqual(paymentPage.GetCheckDetails("Currency"), "- We allow the following currency to be sent via bank wire: Dollar");
                Assert.AreEqual(paymentPage.GetCheckDetails("Confirm your order"),
                "- Bank wire account information will be displayed on the next page.\r\n- Please confirm your order by clicking \"I confirm my order.\".");
                Assert.True(paymentPage.IsConfirmBtnDisplayed());
                test.Log(Status.Info, " 'I Confirm My order Btn' displayed");
                paymentPage.ClickOnConfirmOrderBtn();
                test.Log(Status.Info, "'I Confirm My order Btn' Clicked");
                Thread.Sleep(2000);


            
        }
    }
}
