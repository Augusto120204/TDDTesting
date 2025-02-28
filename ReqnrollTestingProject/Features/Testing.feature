Feature: Testing

A short summary of the feature

@AgregarClienteValido
Scenario: Agregar Cliente valido
	Given Ingresar a la pagina de creacion de clientes.
	When Llenar los campos dentro del formulario.
	| Cedula     | Apellidos | Nombres  | FechaNacimiento | Mail               | Telefono   | Direccion | Estado |
	| 1593574562 | Murillo   | Penelope | 11/15/1999      | pmurillo@gmail.com | 0999996346 | Quito     | 1      |
	And Dar clic en el boton de guardar.
	Then Verificar que el cliente fue guardado correctamente.

@AgregarClienteInvalido
Scenario: Agregar Cliente invalido
	Given Ingresar a la pagina de creacion de clientes.
	When Llenar los campos dentro del formulario.
		| Cedula     | Apellidos | Nombres  | FechaNacimiento | Mail             | Telefono   | Direccion | Estado |
		| 1593574562 | Murillo   | Penelope | 11/15/1999      | pmurillogmailcom | 0999996346 | Quito     | 1      |
	And Dar clic en el boton de guardar.
	Then Verificar que el cliente no fue guardado correctamente.

@EditarClienteValido
Scenario: Editar Cliente valido
	Given Ingresar a la pagina de edicion de clientes.
	When Llenar los campos dentro del formulario.
		| Cedula     | Apellidos | Nombres  | FechaNacimiento | Mail               | Telefono   | Direccion | Estado |
		| 1593574562 | Murillo   | Penelope | 11/15/1999      | pmurillo@gmail.com | 0999996346 | Quito     | 1      |
	And Dar clic en el boton de editar.
	Then Verificar que el cliente fue editado correctamente.

@EditarClienteInvalido
Scenario: Editar Cliente invalido
	Given Ingresar a la pagina de edicion de clientes.
	When Llenar los campos dentro del formulario.
		| Cedula     | Apellidos | Nombres  | FechaNacimiento | Mail             | Telefono   | Direccion | Estado |
		| 1593574562 | Murillo   | Penelope | 11/15/1999      | pmurillogmailcom | 0999996346 | Quito     | 1      |
	And Dar clic en el boton de editar.
	Then Verificar que el cliente no fue editado correctamente.