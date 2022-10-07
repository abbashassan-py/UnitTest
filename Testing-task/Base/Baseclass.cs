using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Testing_task.pageObject;
using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium.Interactions;
using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestProject_01.baseClass
{


    public class Baseclass 
    {
        //public ExtentReports extent;
        //public ExtentTest test;
        public IWebDriver driver;
        public WebDriverWait wait;
        public Actions action;
        public IJavaScriptExecutor js;
        public indexPage indexPage;
        public AddProductPage addProductPage;
        public CreateAccountPage createAccountPage;
        public AddressPage addressPage;
        public ShippingPage shippingPage;
        public PaymentPage paymentPage;

        public string _URL = "http://automationpractice.com/index.php";

        //[OneTimeSetup]
        [SetUp]
        public void InitializingBrowser() 
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            js = (IJavaScriptExecutor)driver;
            driver.Url = _URL;
            addProductPage = new AddProductPage(driver,wait,action);
            createAccountPage = new CreateAccountPage(driver, wait, action);
            addressPage = new AddressPage(driver, wait, action);
            shippingPage = new ShippingPage(driver, wait, action);
            paymentPage = new PaymentPage(driver, wait, action);    
        }
        //[OneTimeTearDown]
        [TearDown]
        public void terminateBrowser()
        {
            driver.Quit();
        }
    }
}







