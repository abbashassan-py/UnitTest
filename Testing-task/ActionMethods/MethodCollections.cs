using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace Testing_task.ActionMethods
{
    public class MethodCollections
    {
        public IWebDriver driver = null;
        public WebDriverWait wait = null;
        private Actions action = null;

        public MethodCollections(IWebDriver driver, WebDriverWait wait, Actions action)
        {
            this.driver = driver;
            this.wait = wait;
            this.action = action;
        }

        public IList<IWebElement> webElements(By _locator)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_locator));
        }

        public string GetTextFromElement(By _locator)
        {
            return wait.Until(ExpectedConditions.ElementExists(_locator)).Text;
        }

        public IWebElement webElement(By _locator)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(ExpectedConditions.ElementIsVisible(_locator));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        }

        public bool TextInElement(By _locator, string _value)
        {
            return wait.Until(ExpectedConditions.TextToBePresentInElementLocated(_locator, _value));

        }

        public void ActionDragAndDrop(By _locator, int x, int y)
        {
            action = new Actions(driver);
            action.ClickAndHold(wait.Until(ExpectedConditions.ElementIsVisible(_locator))).DragAndDropToOffset
                (wait.Until(ExpectedConditions.ElementIsVisible(_locator)), x, y).Build().Perform();
        }

        public bool ElementIsDisplayed(By _locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(_locator)).Displayed;
        }

        public string GetTextFromElements(By _locator, int index)
        {

            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_locator))[index].Text;
        }


        public void switchToFrame(By _locator)
        {
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(_locator));
        }

        public void ActionElement(By _locator)
        {
            action = new Actions(driver);
            action.MoveToElement(wait.Until(ExpectedConditions.ElementIsVisible(_locator))).Build().Perform();
        }


        public void SwitchToParentFrame()
        {
 
            driver.SwitchTo().DefaultContent();
        }



        public string GetAttributeFromElement(By _locator, string _value)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(_locator)).GetAttribute(_value);
        }
    }
}
