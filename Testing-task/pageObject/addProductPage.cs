using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Testing_task.ActionMethods;
using Testing_task.CustomLocators;

namespace Testing_task.pageObject
{
    public class AddProductPage : MethodCollections
    {
        private IWebDriver driver = null;
        private WebDriverWait wait = null;
        private Actions action = null;
        private SelectElement select = null;

        private string[] _categoriesTitles = { "Women", "Dresses", "T-shirts" };
        private string[] _categoryDressTitles = { "Casual Dresses", "Evening Dresses", "Summer Dresses" };
        private string[] _sizesTitles = { "S", "M", "L" };
        private string[] _productDetailsTitles = { "Product", "Colour and Size" };
        private string[] _navigationCategoryTitles = { "Home", "Women", "Products" };
        private string[] _colorChoiceTitles = { "Biege", "Pink" };
        private string[] _summaryTitles = { "Product", "Description", "Avail.", "Unit price", "Qty", "Total", "Empty" };

        By _productsCategories = new ContainsClassPath("menu-content", "/li"); 
        By _dressCategory = new IDPath("categories_block_left", "/div/ul/li");
        By _dressHeader = new ContainsClassPath("product-listing", "/span[1]");
        By _size = new IDPath("ul_layered_id_attribute_group_1", "/li/div");
        By _cottonChecker = By.Id("uniform-layered_id_feature_5");
        By _inStockChecker = By.Id("uniform-layered_quantity_1");
        By _leftSliderBtn = new IDPath("layered_price_slider", "/a[1]");
        By _RightSliderBtn = new IDPath("layered_price_slider", "/a[2]");
        By _addToCartBtn = By.XPath("//*[@title = 'Add to cart']");
        By _productSuccessHeader = new ClassPath("cross", "/../h2");
        By _productDetails = new ClassPath("layer_cart_product_info", "/span");
        By _continueShoppingBtn = By.XPath("//*[@title = 'Continue shopping']");
        By _navigateToCategory = new ClassPath("breadcrumb clearfix", "/a");
        By _contactUsBtn = By.XPath("//a[contains(.,'Selenium Framework')]");
        By _quickViewSpan = new ClassLoc ("quick-view");
        By _iframeLoc = By.XPath("//*[contains(@id, 'fancybox')]");
        By _productSortDrpDwn = By.Id("selectProductSort");
        By _productImageLink = By.XPath("//*[@class = 'product_img_link' and @title = 'Printed Dress']");
        By _colourField = new IDPath("color_to_pick_list", "/li");
        By _addToCartInIframe = By.Name("Submit");
        By _cartSummary = new IDPath("cart_summary", "/thead/tr/th");
        By _addressHeader = new ClassLoc("page-heading");
        By _proceedToCheckOutBtn = By.LinkText("Proceed to checkout");
        //      By _productInStockFailed = By.XPath("");
        //      By _shoppingCart = By.XPath("//*[@title = 'View my shopping cart']");
        //      By _closeIframe = By.XPath(".//*[@title='Close']");
        //      By _imagChoosing = new IDPath("thumbs_list_frame", "/li");

        public AddProductPage(IWebDriver driver, WebDriverWait wait, Actions action) : base(driver, wait, action)
        {
            this.driver = driver;
            this.wait = wait;
            this.action = action;
        }
        
        public void SelectProductCategory(string _titles)
        {
            int index = Array.IndexOf(_categoriesTitles, _titles);
            webElements(_productsCategories)[index].Click();
        }

        public void SelectDressCategory(string _titles)
        {
            int index = Array.IndexOf(_categoryDressTitles, _titles);
            webElements(_dressCategory)[index].Click();
        }

        public string verifyTitleInDressCategory()
        {
            return GetTextFromElement(_dressHeader);
        }

        public void SelectSize(string _titles)
        {
            int index = Array.IndexOf(_sizesTitles, _titles);
            webElements(_size)[index].Click();
        }

        public void SelectCotton()
        {
            webElement(_cottonChecker).Click();
        }

        public void SelectInStock()
        {
            webElement(_inStockChecker).Click();
        }

        public void ModifyLeftSlider(int x, int y)
        {
            ActionDragAndDrop(_leftSliderBtn, x, y);
        }

        public void ModifyRightSlider(int x, int y)
        {
            ActionDragAndDrop(_RightSliderBtn, x, y);
        }

        public void ClickAddToCartBtn()
        {
            webElement(_addToCartBtn).Click();
        }

        public bool IsAddToCartBtnPresent()
        {
            return ElementIsDisplayed(_addToCartBtn);
        }

        public bool IsProductCompleteTextDisplayed(string _value)
        {
            return TextInElement(_productSuccessHeader, _value);
        }

        public string VerifyProductDetails(int index, string _titles)
        {
            index = Array.IndexOf(_productDetailsTitles, _titles);
            return GetTextFromElements(_productDetails, index);
        }

        public bool IsContinueShoppingBtnDisplayed()
        {
            return ElementIsDisplayed(_continueShoppingBtn);
        }

        public void ClickOnContinueShoppingBtn()
        {
            webElement(_continueShoppingBtn).Click();
        }

        public void NavigateToCategories(string _title)
        {
            int index = Array.IndexOf(_navigationCategoryTitles, _title);
            webElements(_navigateToCategory)[index].Click();
        }

        public bool IsContanctUsBtnDisplayed()
        {
            return ElementIsDisplayed(_contactUsBtn);
        }

        public void SelectSortByDropDown(string _titles)
        {
            select = new SelectElement(driver.FindElement(_productSortDrpDwn));
            select.SelectByText(_titles);
        }

        public void ClickOnQuickViewSpan()
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            ActionElement(_quickViewSpan);
            webElement(_quickViewSpan).Click();
        }

        public void SwitchToIframeProduct() // iFrame handling
        {
            switchToFrame(_iframeLoc);
        }

        public void MoveToProductImageLink() // move the mouse cursor to Image Present   
        {
            ActionElement(_productImageLink);
        }

        public void ChooseColour(string _titles) // choosing color of dress in iFrame
        {
            int index = Array.IndexOf(_colorChoiceTitles, _titles);
            webElements(_colourField)[index].Click();
        }

        public void ClickAddToCartInIframe()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("Submit"))).Click();
            //IWebElement element = driver.FindElement(By.XPath("//*[@id=\"add_to_cart\"]/button"));
            //element.Click();
            //IWebElement _addToCartBtnn = driver.FindElement(By.XPath(".//*[@id='add_to_cart' or @name='Submit']"));
            //action = new Actions(driver);
            //action.MoveToElement(_addToCartBtnn).Click();
            //webElement(_closeIframe).Click();
            webElement(_addToCartInIframe).Click();
        }

        public void ClickOnShoppingCart()
        {
            //webElement(_shoppingCart).Click();
            IWebElement element = driver.FindElement(By.XPath("//*[@title = 'View my shopping cart']"));
            action = new Actions(driver);
            action.KeyDown(Keys.Control).Click(element).Build().Perform();//Multi-Tab Handling 
            driver.SwitchTo().Window(driver.WindowHandles[1]);//switiching to new tab
        }

        public string VerifySummaryTitles(string _titles)
        {
            int index = Array.IndexOf(_summaryTitles, _titles);
            return GetTextFromElements(_cartSummary, index);
        }

        public void ClickProceedToCheckoutBtn()
        {
            webElement(_proceedToCheckOutBtn).Click();
        }

        //public void ClickOnContactUsBtn() //not-used
        //{
        //    IWebElement element = driver.FindElement(By.XPath("//a[contains(.,'Selenium Framework')]"));
        //    action = new Actions(driver);
        //    action.KeyDown(Keys.Control).Click(element).Build().Perform();//Multi-Tab Handling 
        //    driver.SwitchTo().Window(driver.WindowHandles[1]);//switiching to new tab
        //}
        public string ReturnBillingHeader()
        {
            return GetTextFromElement(_addressHeader);
        }

    }
}
