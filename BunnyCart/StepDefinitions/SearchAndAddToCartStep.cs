using System;
using TechTalk.SpecFlow;

namespace BunnyCart.StepDefinitions
{
    [Binding]
    public class SearchAndAddToCartStep
    {
        [When(@"User search for a product '([^']*)' in search box")]
        public void WhenUserSearchForAProductInSearchBox(string water)
        {
            throw new PendingStepException();
        }

        [When(@"Select the product in the position '([^']*)'")]
        public void WhenSelectTheProductInThePosition(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"Click on add to cart button")]
        public void ThenClickOnAddToCartButton()
        {
            throw new PendingStepException();
        }
    }
}
