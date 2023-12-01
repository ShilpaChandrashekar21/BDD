using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SampleProject.StepDefinitions
{
    [Binding]
    public class GoogleSearchStepDefinitions
    {
        IWebDriver? driver;

        [BeforeScenario] 
        public void InitializeBrowser() 
        { 
            driver = new ChromeDriver();
            
            
        }

        [AfterScenario]
        public void CleanupBrowser()
        {
            driver?.Quit();
        }

        [Given(@"Google home page should be loaded")]
        public void GivenGoogleHomePageShouldBeLoaded()
        {
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();

        }

        [When(@"Type ""([^""]*)"" in the search box")]
        public void WhenTypeInTheSearchBox(string searchText)
        {
            driver?.FindElement(By.Id("APjFqb")).SendKeys(searchText);
           


        }

        [When(@"Click on the google search button")]
        public void WhenClickOnTheGoogleSearchButton()
        {
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMilliseconds(150);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fwait.Message = "Element not found";
            IWebElement? gsButton = fwait.Until(d =>
            {
              IWebElement searchButton =  d.FindElement(By.ClassName("gNO89b"));
                return searchButton.Displayed ? searchButton : null;
            });
            if(gsButton != null)
            {
                gsButton.Click();
            }
           
        }

        [Then(@"the results should be displayed on the next page with title ""([^""]*)""")]
        public void ThenTheResultsShouldBeDisplayedOnTheNextPageWithTitle(string title)
        {
           Assert.That(driver.Title.Equals(title));
        }

        [When(@"Click on the  I am feeling Lucky button")]
        public void WhenClickOnTheIAmFeelingLuckyButton()
        {
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMilliseconds(150);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fwait.Message = "Element not found";
            IWebElement? imflButton = fwait.Until(d =>
            {
                IWebElement searchButton = d.FindElement(By.ClassName("RNmpXc"));
                return searchButton.Displayed ? searchButton : null;
            });
            if (imflButton != null)
            {
                imflButton.Click();
            }
        }

        [Then(@"the results should be redirected to a new page with title ""([^""]*)""")]
        public void ThenTheResultsShouldBeRedirectedToANewPageWithTitle(string title)
        {
            Assert.That(driver.Title.Contains(title));
        }


    }
}
