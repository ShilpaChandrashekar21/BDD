Feature: GoogleSearch
 To perform search operations on google home page

@tag1
Scenario: To perform search with google search button
	Given Google home page should be loaded 
	When Type "hp laptop" in the search box
	And Click on the google search button
	Then the results should be displayed on the next page with title "hp laptop - Google Search"

	Scenario: To perform search with I am feeling Lucky button
	Given Google home page should be loaded 
	When Type "hp laptop" in the search box
	And Click on the  I am feeling Lucky button
	Then the results should be redirected to a new page with title "HP Laptops"
