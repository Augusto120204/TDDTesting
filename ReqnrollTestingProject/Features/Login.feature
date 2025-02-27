Feature: Login

A short summary of the feature

@tag1
Scenario: Usuario inicia sesion incorrectamente
	Given El usuario se encuentra en la pagina del LogIn
	When Ingresa las credenciales correo "testuser@mail.com" y la contraseña "123456"
	And Hacer click en el boton de Login
	Then Deberia ver un mensaje de error
