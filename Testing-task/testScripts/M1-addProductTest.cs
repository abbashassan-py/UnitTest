using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using Testing_task.Reports;
using TestProject_01.baseClass;

namespace Testing_task.testScripts
{
    public class M1_addProductTest : extentReport
    {
        public static string _ProductNotInStockMessage = "There are no Products";
        string _ProductSuccessfullyAddedMessage = "Product successfully added to your shopping cart";

        [Test]
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
    }
}
