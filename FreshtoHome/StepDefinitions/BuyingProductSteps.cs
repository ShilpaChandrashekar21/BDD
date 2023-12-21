using FreshtoHome.Hooks;
using FreshtoHome.utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace FreshtoHome.StepDefinitions
{
    [Binding]
    public class BuyingProductSteps : CoreCodes
    {
        IWebDriver? driver = AllHooks.driver;
        [Given(@"User will be on home page")]
        public void GivenUserWillBeOnHomePage()
        {
            driver.Url = "https://www.freshtohome.com/";
        }

        [When(@"User searches for a product '([^']*)' and hits enter")]
        public void WhenUserSearchesForAProductAndHitsEnter(string input)
        {
            IWebElement? search = driver.FindElement(By.ClassName("input-text"));
            search.SendKeys(input);
            search.SendKeys(Keys.Enter);
        }

        [Then(@"The url should change with  '([^']*)'")]
        public void ThenTheUrlShouldChangeWith(string input)
        {
            TakeScreenshots(driver);
            try
            {
                Assert.That(driver.Url.Contains(input));
                LogTestResult("Search url test", "Search url test success");
            }
            catch (AssertionException ex)
            {

                LogTestResult("Search url test", $"Search url test failed \n Search url test failed Exception \n={ex.Message}");

            }
        }

        [When(@"Selects product at position '([^']*)'")]
        public void WhenSelectsProductAtPosition(string position)
        {
            IWebElement selectProduct = driver.FindElement(By.XPath("(//img[@class='curved'])" + "[" + position + "]"));
            selectProduct.Click();
        }

        [When(@"Adds the product to cart")]
        public void WhenAddsTheProductToCart()
        {
            IWebElement addToCart = driver.FindElement(By.XPath("(//button[@title='Add to Cart' ])[1]"));
            addToCart.Click();
        }

        [Then(@"Views added product to the cart")]
        public void ThenViewsAddedProductToTheCart()
        {
            IWebElement cart = driver.FindElement(By.ClassName("menu-cart-icon"));
            cart.Click();
        }

        [When(@"User clicks on checkout button")]
        public void WhenUserClicksOnCheckoutButton()
        {
            IWebElement? checkout = driver.FindElement(By.XPath("//button[@title='Go to Checkout']"));
            checkout.Click();
        }

        [Then(@"the url will be on payment")]
        public void ThenTheUrlWillBeOnPayment()
        {
            TakeScreenshots(driver);
            try
            {
                Assert.That(driver.Url.Contains("checkout"));
                LogTestResult("checkout url test", "checkout url test success");
            }
            catch (AssertionException ex)
            {

                LogTestResult("checkout url test", $"checkout url test failed \n checkout url test failed Exception \n={ex.Message}");

            }
        }
    }
}
