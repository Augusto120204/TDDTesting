Feature: Signup

A short summary of the feature

@tag1
Scenario: Registro Nuevo Usuario
	Given El usuario se encuentra en la pagina de Registro
	When Ingresa nombre "Penelope" y correo "penelope@gmail.com"
	And Hacer click en el boton signup
	And Se llenan los campos contraseña "123456", primer nombre "Penelope", apellido "Murillo", direccion "Quito", estado "Pichincha", ciudad "Quito", zip "123", telefono "0987654321"
	And Hacer click en el boton de Registro
	Then Deberia ver un mensaje de confirmacion
