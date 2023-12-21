using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace LinkedinTests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        public  static  IWebDriver? driver;
        private IWebElement? password;

         [BeforeFeature]
         public static void Initialize()
         {
            driver = new ChromeDriver();
        }
/*
        [BeforeScenario]
       public static void LoadUrl()
        {
            driver.Url = "https://www.linkedin.com/";
            driver.Manage().Window.Maximize();

        }*/

        [AfterFeature]
        public static void CleanUp()
        {
            driver.Close();
        }

        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {
            driver.Url = "https://www.linkedin.com/";
            driver.Manage().Window.Maximize();
        }

        [When(@"User will enter username '(.*)'")]
        public void WhenUserWillEnterUsername(string username)
        {
            DefaultWait<IWebDriver?> fwait = new DefaultWait<IWebDriver?>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fwait.Message);//fwait.Message = "No such element"

            IWebElement? emailInput = fwait.Until(d => d?.FindElement(By.Id("session_key")));
            emailInput?.SendKeys(username);
            
        }

        [When(@"User will enter password '(.*)'")]
        public void WhenUserWillEnterPassword(string pwd)
        {
            DefaultWait<IWebDriver?> fwait = new DefaultWait<IWebDriver?>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fwait.Message);

            password = fwait.Until(d => d?.FindElement(By.Id("session_password")));
            password?.SendKeys(pwd);
            
        }

        [When(@"User will click  on login button")]
        public void WhenUserWillClickOnLoginButton()
        {

            IJavaScriptExecutor? js = (IJavaScriptExecutor?)driver;
            js?.ExecuteScript("arguments[0].scrollIntoView(true); ",
                driver?.FindElement(By.XPath("//button[@type='submit']")));
            js?.ExecuteScript("arguments[0].click(); ",
                driver?.FindElement(By.XPath("//button[@type='submit']")));
        }

        [Then(@"User will be redirected to Homepage")]
        public void ThenUserWillBeRedirectedToHomepage()
        {
           
            Assert.That(condition: driver.Url.Equals("https://www.linkedin.com/"));
        }

        [Then(@"Error message for Password length will be thrown")]
        public void ThenErrorMessageForPasswordLengthWillBeThrown()
        {
            Assert.That(driver.FindElement(By.XPath("//p[@for='session_password']")).Text.Contains("at least 6 characters"));
        }

        [When(@"User will click  on show button")]
        public void WhenUserWillClickOnShowButton()
        {
           IWebElement? showButton= driver?.FindElement(By.XPath("//button[text()='Show']"));
            showButton?.Click();
        }

        [Then(@"the password characters should be shown")]
        public void ThenThePasswordCharactersShouldBeShown()
        {
            Assert.That(password.GetAttribute("type").Equals("text"));
        }

        [When(@"User will click  on hide button")]
        public void WhenUserWillClickOnHideButton()
        {
            IWebElement? hideButton = driver?.FindElement(By.XPath("//button[text()='Hide']"));
            hideButton?.Click();
        }

        [Then(@"the password characters should not be shown")]
        public void ThenThePasswordCharactersShouldNotBeShown()
        {
            Assert.That(password.GetAttribute("type").Equals("password"));
        }

        

    }
}
