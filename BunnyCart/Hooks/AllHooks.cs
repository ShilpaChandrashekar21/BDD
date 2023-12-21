using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using TechTalk.SpecFlow;

namespace BunnyCart.Hooks
{
    [Binding]
    public sealed class AllHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public static IWebDriver? driver;

        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [BeforeFeature]
        public static void CreatingLog()
        {
            string? curDir = Directory.GetParent(@"../../../").FullName;
            string? fileName = curDir + "/Logs/search" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                 .WriteTo.Console()
                 .WriteTo.File(fileName, rollingInterval: RollingInterval.Day)
                 .CreateLogger();

        }

        /*[AfterScenario]
        public static void NavigateBackToHomePage()
        {
            driver?.Navigate().GoToUrl("https://www.bunnycart.com/");
        }*/

        [AfterFeature]
        public static void CleanupBrowser()
        {
            driver?.Quit();
        }

        
    }
}