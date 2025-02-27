Feature: RA001_1

A short summary of the feature

@tag1
Scenario: Verify that votes are correctly assigned according to a specific precinct, board and candidate
	Given The user enters to the page of the voting simulation
	When Login with the username "admin@gmail.com" and password "admin"
	And Select the province "Azuay", canton "Camilo Ponce Enriquez", parish "Camilo Ponce Enriquez" and precint "Escuela de Educacion Basica el Diamante"
	And Click the dignity President
	And Select the political party RC5
	And Enter the number of votes 5
	Then Verify that the votes are correctly assigned
