Feature: BuyingProduct

search for a product and add the same to cart and checkout

Background: User will be on home page

@E2E-testing
Scenario Outline: Buying a product
	#Given User will be on home page
	When User searches for a product '<ProductName>' and hits enter
	Then The url should change with  '<ProductName>'
	When  Selects product at position '<ProductPosition>'
	And Adds the product to cart
	Then Views added product to the cart
	When User clicks on checkout button
	Then the url will be on payment 

Examples: 
	| ProductName | ProductPosition |
	| chicken     | 7               |
	| mutton      | 4               |
