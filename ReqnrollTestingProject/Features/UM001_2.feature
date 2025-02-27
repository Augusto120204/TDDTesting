Feature: UM001_2

A short summary of the feature

@tag1
Scenario: Ensures only authorized users access the system functionalities.
	Given The user is on the home page
	When Enter the username "invalid@gmail.com" and password "invalid"
	And Click on the Login button
	Then View the alert message
