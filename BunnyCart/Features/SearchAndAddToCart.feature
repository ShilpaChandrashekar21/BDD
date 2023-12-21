Feature: SearchAndAddToCart

A short summary of the feature


@E2E_addtocart
Scenario Outline: 01 Search for a product and add product to cart
	Given User will be on home page
	When User types search text '<SearchText>' in the search box
	Then search results are loaded in the same page with '<SearchText>' in url
	And The heading should have '<SearchText>'
	And Title should have '<SearchText>'
	When User selects product at '<ProductPosition>
	Then The selected product page is loaded	

Examples: 
	| SearchText | ProductPosition |
	| water      | 3               |
	| java       | 2               |
	


#Scenario: Check for title after search
#	Given User will be on home page
#	When User types search text '<SearchText>' in the search box
#	And Select the product in the position '<ProductPosition>'
#	And Click on add to cart button

	#Then search results are loaded in the same page with '<SearchText>' in url 

#Scenario: 02 Select product
#	Given User will be on search result page
#	When User selects product at '<ProductPosition>
#	Then The selected product page is loaded	
#	
#Examples: 
#	| SearchText | ProductPosition |
#	| water      | 3               |
	