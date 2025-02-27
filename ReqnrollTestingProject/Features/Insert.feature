Feature: Insert

Ingreso de la informacion del formulario Clientes a la base de datos

@tag1
Scenario: Insertar Clientes
	Given Llenar los campos dentro del fromulario
	| Cedula     | Apellidos | Nombres  | FechaNacimiento | Mail               | Telefono   | Direccion | Estado |
	| 1593574562 | Murillo   | Penelope | 01/05/2000      | pmurillo@gmail.com | 0999996346 | Quito     | 1      |
	When Registros ingresados en la base de datos
	| Cedula     | Apellidos | Nombres  | FechaNacimiento | Mail               | Telefono   | Direccion | Estado |
	| 1593574562 | Murillo   | Penelope | 01/05/2000      | pmurillo@gmail.com | 0999996346 | Quito     | 1      |
	Then Resultado del ingreso a la base de datos
	| Cedula     | Apellidos | Nombres  | FechaNacimiento | Mail               | Telefono   | Direccion | Estado |
	| 1593574562 | Murillo   | Penelope | 01/05/2000      | pmurillo@gmail.com | 0999996346 | Quito     | 1      |