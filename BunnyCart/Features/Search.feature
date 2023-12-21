Feature: Search

Search for a  product 

@product_search
Scenario Outline: Search for products
	Given User will be on home page
	When User types search text '<SearchText>' in the search box
	Then search results are loaded in the same page with '<SearchText>' in url 
Examples: 
	| SearchText |
	| water      |
	| hair       |
	| java       |
