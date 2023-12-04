using BunnyCart.Hooks;
using BunnyCart.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using System;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
    [Binding]
    public class SearchAndAddToCartStep :CoreCodes
    {
            IWebDriver? driver = AllHooks.driver;
        string? title;

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
            Log.Information("Searching " + input);
            searchBox?.SendKeys(Keys.Enter);

        }


        [When(@"User selects product at '(.*)")]
        public void WhenUserSelectsProductAt(int position)
        {
            IWebElement element = driver.FindElement(By.XPath("(//a[@class='product-item-link'])" + "[" + position + "]"));
            title = element.Text;
            element.Click();
            Log.Information("Clicked on " + position + " element");

        }

        [Then(@"search results are loaded in the same page with '([^']*)' in url")]
        public void ThenSearchResultsAreLoadedInTheSamePageWithInUrl(string input)
        {

            ToTakeScreenshots(driver);
            try
            {

                Assert.That(driver.Url.Contains(input));
                LogTestResult("Url Test ", "Search Url Test success");


            }
            catch (AssertionException ex)
            {
                LogTestResult(" Url Test ", $"Search Url Test failed \n Search Url Test failed Exception: {ex.Message}");

            }



        }

        [Then(@"The heading should have '([^']*)'")]
        public void ThenTheHeadingShouldHave(string input)
        {
            ToTakeScreenshots(driver);
            try
            {

                Assert.That(driver.FindElement(By.ClassName("base")).Text.Contains(input));
                LogTestResult("Heading Test ", "Search Heading Test success");

            }
            catch (AssertionException ex)
            {
                LogTestResult(" Heading Test ", $"Search Heading Test failed \n Search Heading Test failed Exception: {ex.Message}");

            }
        }


        [Then(@"Title should have '([^']*)'")]
        public void ThenTitleShouldHave(string input)
        {
            ToTakeScreenshots(driver);
            try
            {

                Assert.That(driver.Title.Contains(input));
                LogTestResult("Title Test ", "Search Title Test success");

            }
            catch (AssertionException ex)
            {
                LogTestResult(" Title Test ", $"Search Title Test failed \n Search Title Test failed Exception: {ex.Message}");

            }
        }

       /* [Given(@"User will be on search result page")]
        public void GivenUserWillBeOnSearchResultPage()
        {
            driver.Url = "https://www.bunnycart.com/catalogsearch/result/?q=water";
        }*/

       

        [Then(@"The selected product page is loaded")]
        public void ThenTheSelectedProductPageIsLoaded()
        {
            ToTakeScreenshots(driver);
            try
            {
                Assert.That(title.Equals(driver.FindElement(By.XPath("//span[@class='base']")).Text));
                LogTestResult("Select Product", "Select Product scenario success");
            }
            catch(AssertionException ex)
            {
                LogTestResult("Select Product ", $"Select Product scenario failed \n Select Product scenario Exception: {ex.Message}");

            }
        }




    }
}
