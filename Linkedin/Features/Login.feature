Feature: Login

User logs-in with valid credentials(username,password)
the home page will load after successfull login

Background: 
	Given User will be on the login page

@positive
Scenario Outline: Login with Valid Credentials
	When User will enter username '<Username>'
	And User will enter password '<Password>'
	And User will click  on login button
	Then User will be redirected to Homepage

Examples: 
	| Username    | Password |
	| abc@xys.com | 12345    |
	| def@xyz.com | 98765    |
@negative
Scenario Outline: Login with Invalid Credentials
	When User will enter username '<Username>'
	And User will enter password '<Password>'
	And User will click  on login button
	Then Error message for Password length will be thrown

Examples: 
	| Username    | Password |
	| aaa@xys.com | 1234     |
	| ddd@xyz.com | 9876     |

@regression
Scenario Outline: Check for Password Hidden display
	When User will enter password '<Password>'
	And User will click  on show button
	And User will click  on hide button
	Then the password characters should not be shown

Examples: 
	| Password |
	| 123      |
	

@regression
Scenario Outline: Check for Password Show display
	When User will enter password '<Password>'
	And User will click  on show button
	Then the password characters should be shown

Examples: 
	| Password |
	| 12345    |
	

