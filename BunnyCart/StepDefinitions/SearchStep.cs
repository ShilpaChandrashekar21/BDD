using BunnyCart.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using TechTalk.SpecFlow;


namespace BunnyCart.StepDefinitions
{
    [Binding]

    
    public class SearchStep : CoreCodes
    {
       
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

        [AfterScenario]
        public static void NavigateBackToHomePage()
        {
            driver.Navigate().GoToUrl("https://www.bunnycart.com/");
        }
        [AfterFeature]
        public static void CleanupBrowser()
        {
            driver?.Quit();
        }

        [Given(@"User will be on home page")]
        public void GivenUserWillBeOnHomePage()
        {
            driver.Url = "https://www.bunnycart.com/";
        }

        [When(@"User types search text '([^']*)' in the search box")]
        public void WhenUserTypesSearchTextInTheSearchBox(string input)
        {
            IWebElement? searchBox = driver?.FindElement(By.Id("search"));
            searchBox?.SendKeys(input);
            searchBox?.SendKeys(Keys.Enter);

        }

        

        [Then(@"search results are loaded in the same page with '([^']*)' in url")]
        public void ThenSearchResultsAreLoadedInTheSamePageWithInUrl(string input)
        {

            ToTakeScreenshots();
            try
            {
              
                Assert.That(driver.Url.Contains(input));
                LogTestResult("Search Test ", "Search Test success");
              

            }
            catch (AssertionException ex)
            {
                LogTestResult("Search Test ", $"Search Test failed \n Search Test failed Exception: {ex.Message}");

            }



        }
    }
}
