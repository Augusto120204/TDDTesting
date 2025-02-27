using System;
using FluentAssertions;
using Productos.Data;
using Productos.Models;
using Reqnroll;

namespace ReqnrollTestingProject.StepDefinitions
{
    [Binding]
    public class InsertStepDefinitions
    {

        private readonly ClienteDataAccessLayer _clienteDAL = new ClienteDataAccessLayer();

        [Given("Llenar los campos dentro del fromulario")]
        public void GivenLlenarLosCamposDentroDelFromulario(DataTable dataTable)
        {
            var resultado = dataTable.Rows.Count;

            //Assert.True(resultado > 0);
            resultado.Should().BeGreaterThanOrEqualTo(1);
        }

        [When("Registros ingresados en la base de datos")]
        public void WhenRegistrosIngresadosEnLaBaseDeDatos(DataTable dataTable)
        {
            var cliente = dataTable.CreateSet<Cliente>().ToList();

            Cliente cls = new Cliente();

            foreach (var item in cliente)
            {
                cls.Cedula = item.Cedula;
                cls.Nombres = item.Nombres;
                cls.Apellidos = item.Apellidos;
                cls.FechaNacimiento = item.FechaNacimiento;
                cls.Mail = item.Mail;
                cls.Telefono = item.Telefono;
                cls.Direccion = item.Direccion;
                cls.Estado = item.Estado;
                _clienteDAL.addCliente(cls);
            }
        }

        [Then("Resultado del ingreso a la base de datos")]
        public void ThenResultadoDelIngresoALaBaseDeDatos(DataTable dataTable)
        {
            List<Cliente> lstCliente = _clienteDAL.getAllClientes();

            var cliente = dataTable.CreateSet<Cliente>().ToList();

            int encontrado = 0;

            foreach (var item in lstCliente)
            {
                if(lstCliente.Contains(item))
                {
                    encontrado++;
                    break;
                }
            }

            Assert.True(encontrado > 0);
        }
    }
}
