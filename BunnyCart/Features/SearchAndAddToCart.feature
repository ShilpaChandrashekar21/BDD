Feature: SearchAndAddToCart

A short summary of the feature

@E2E_addtocart

Scenario: Search for a product and add product to cart
	Given User will be on home page
	When User types search text '<SearchText>' in the search box
	Then search results are loaded in the same page with '<SearchText>' in url 
	#And Select the product in the position '<ProductPosition>'
	#Then Click on add to cart button

Examples: 
	| SearchText | ProductPosition |
	| water      | 5               |
	| java       | 4               |
