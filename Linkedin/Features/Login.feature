Feature: Login

User logs-in with valid credentials(username,password)
the home page will load after successfull login

Background: 
	Given User will be on the login page

@positive
Scenario: Login with Valid Credentials
	When User will enter username
	And User will enter password
	And User will click  on login button
	Then User will be redirected to Homepage

@negative
Scenario: Login with Invalid Credentials
	When User will enter username
	And User will enter password
	And User will click  on login button
	Then Error message for Password length will be thrown

@regression
Scenario: Check for Password Hidden display
	When User will enter password
	And User will click  on show button
	And User will click  on hide button
	Then the password characters should not be shown

@regression
Scenario: Check for Password Show display
	When User will enter password
	And User will click  on show button
	Then the password characters should be shown
