using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Fresh_To_Home.utilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using Serilog;

using TechTalk.SpecFlow;

namespace FreshtoHome.Hooks
{
    [Binding]
    public sealed class AllHooks
    {
      public static  IWebDriver? driver;
      
      public static ExtentReports extent;
      static ExtentSparkReporter sparkReporter;
      public static ExtentTest test;

        
        [BeforeFeature]
        public static void InitializeBrowser()
        {
            ReadConfigFile.ReadConfigProperty();
            string currDir = Directory.GetParent(@"../../../").FullName;

            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currDir + "/ExtentReports/extent-report"
                + DateTime.Now.ToString("yyyy_MM_dd/HH-mms-s") + ".html");
            extent.AttachReporter(sparkReporter);



            if (ReadConfigFile.properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (ReadConfigFile.properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }

            driver.Url = ReadConfigFile.properties["baseUrl"];
            driver.Manage().Window.Maximize();
        }
        [BeforeScenario] 
        public static void CreateLogFile() 
        {
            
            string? curDir = Directory.GetParent(@"../../../").FullName;
            string? fileName = curDir + "/logs/log_" +
                DateTime.Now.ToString("dd/ddMMyyyy-hhmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(fileName, rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }

        

        [BeforeScenario]
        public static void RefreshPage() 
        {
            driver?.Navigate().Refresh();
        }
        [AfterScenario]
        public static void NavigateBack()
        {
            driver.Navigate().GoToUrl(ReadConfigFile.properties["baseUrl"]);
            Log.CloseAndFlush();
        }
        [AfterFeature] 
        public static void CloseBrowser() 
        {
            driver?.Close();
            extent.Flush();
        }

    }
}