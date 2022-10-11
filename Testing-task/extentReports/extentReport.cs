using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using TestProject_01.baseClass;
using TechTalk.SpecFlow;

namespace Testing_task.Reports
{
    
    public class extentReport:Baseclass
    {

        public static ExtentReports extent = new ExtentReports();
        public static ExtentTest test;


        [SetUp]
        public void ExtentStarts()
        {
                var reportPath = @"C:\Test\Auto_Test\Auto_Test\Testing-task\Reports\demo.html";
                var htmlReporter = new ExtentHtmlReporter(reportPath);
               
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("Host Name", "LocalHost");
                extent.AddSystemInfo("Environment", "QA");
                extent.AddSystemInfo("UserName", "TestUser");


        }


        [TearDown]
        public void ExtentClose()
        { 
            extent.Flush();


        }
    }


    public class extentReportE2E : Baseclass
    {

        public static ExtentReports extent = new ExtentReports();
        public static ExtentTest test;


        [SetUp]
        public void ExtentStarts()
        {
            var reportPath = @"C:\Test\Auto_Test\Auto_Test\Testing-task\fullReport\extentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "LocalHost");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("UserName", "TestUser");


        }


        [TearDown]
        public void ExtentClose()
        {
            extent.Flush();


        }
    }
}
