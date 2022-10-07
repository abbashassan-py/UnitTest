using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Testing_task.pageObject
{
    public class indexPage
    {
        IWebDriver driver;
        public indexPage(IWebDriver driver)

        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.Id,Using = "search_query_top")] //finds the search field
        public IWebElement searchField { get; set; }

        [FindsBy(How = How.XPath , Using = "//*[@id=\"searchbox\"]/button")] //finds the magnify-glass(search button)
        public IWebElement searchBtn { get; set; }

        private  List<string> txtTosearch = new List<string> { "Women", "Dresses", "T-shirts" };//list of keywords for validating search field



        public void validateSearchField()
        {
            for (int i = 0; i < txtTosearch.Count; i++) //iterate through list *txtTosearch* 
            {
                searchField.SendKeys(txtTosearch[i]);//input keywords one by one in search field
                searchBtn.Click(); // clicks the magnify-glass(search button)
                searchField.Clear();// clears the search field for keyword next in list
            }





        }
        public void checkImages()
        {
            //check all images are present in webpage and non is broken
            IWebElement ImageFile = driver.FindElement(By.TagName("img"));
            Boolean ImagePresent = (Boolean)((IJavaScriptExecutor)driver).ExecuteScript(
                "return arguments[0].complete && typeof arguments[0].naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0", ImageFile);


        }
    }
}
