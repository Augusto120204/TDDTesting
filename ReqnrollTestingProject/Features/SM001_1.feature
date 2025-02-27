Feature: SM001_1

A short summary of the feature

@tag1
Scenario: Allow users to create voting simulations
	Given The user is on the login page.
	When The user enters the system with username "admin@gmail.com" and password "admin".
	And Enter the name of the simulation "Testing".
	And Click the start simulation button.
	Then Visualize the system in the new simulation created.
