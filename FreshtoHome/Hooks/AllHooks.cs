using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
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
        public static IWebDriver? driver;
        public static Dictionary<string, string>? properties;
        public static ExtentReports extent;
        static ExtentSparkReporter sparkReporter;
        public static ExtentTest test;

        [BeforeFeature]
        public static void ReadConfigProperty()
        {
            properties = new Dictionary<string, string>();
            string curDir = Directory.GetParent(@"../../../").FullName;
            string file = curDir + "/Property/config.properties";

            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;

                }
            }

        }

        [BeforeFeature]
        public static void InitializeBrowser()
        {
            ReadConfigProperty();
            string currDir = Directory.GetParent(@"../../../").FullName;

            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currDir + "/ExtentReports/extent-report"
                + DateTime.Now.ToString("yyyy_MM_dd/HH-mms-s") + ".html");

            extent.AttachReporter(sparkReporter);


            if (properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }

            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();
        }
        [BeforeScenario]
        public static void CreateLogFile()
        {
            /* string? curDir = Directory.GetParent("@../../../").FullName;
             string? fileName = curDir + "/Logs/logs_" + DateTime.Now.ToString("dd/ddMMyyyy_hhmmss") + ".txt";

             Log.Logger = new LoggerConfiguration()
                 .WriteTo.Console()
                 .WriteTo.File(fileName, rollingInterval: RollingInterval.Day)
                 .CreateLogger();*/

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
            driver.Navigate().GoToUrl(properties["baseUrl"]);
            Log.CloseAndFlush();
        }
        [AfterFeature]
        public static void CloseBrowser()
        {
            driver?.Close();
            AllHooks.extent.Flush();
        }


    }
}