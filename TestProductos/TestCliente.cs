using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace TestProductos
{
    public class TestCliente : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public void Dispose()
        {
            _driver.Dispose();
        }

        public TestCliente()
        {
            var options = new ChromeOptions();
            options.BinaryLocation = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe";
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        [Fact]
        public void Ver_Clientes()
        {
            _driver.Navigate().GoToUrl("https://localhost:7047/Cliente");

            Thread.Sleep(3000);

            var tabla = _wait.Until(d => d.FindElement(By.ClassName("table")));

            Thread.Sleep(3000);

            Assert.NotNull(tabla);
        }

        // ================CREATE================

        [Fact]
        public void Create_Cliente()
        {
            string cedulaString = "1727925602";
            string apellidosString = "Perez Perez";
            string nombresString = "Mario David";
            string fechaNacimientoString = "01/01/1990";
            string mailString = "mario@gmail.com";
            string direccionString = "Calle 22";
            string telefonoString = "0987654321";


            _driver.Navigate().GoToUrl("https://localhost:7047/Cliente/Create");

            Thread.Sleep(3000);

            var cedula = _wait.Until(d => d.FindElement(By.Name("Cedula")));
            var apellidos = _wait.Until(d => d.FindElement(By.Name("Apellidos")));
            var nombres = _wait.Until(d => d.FindElement(By.Name("Nombres")));
            var fechaNacimiento = _wait.Until(d => d.FindElement(By.Name("FechaNacimiento")));
            var mail = _wait.Until(d => d.FindElement(By.Name("Mail")));
            var direccion = _wait.Until(d => d.FindElement(By.Name("Direccion")));
            var telefono = _wait.Until(d => d.FindElement(By.Name("Telefono")));

            cedula.SendKeys(cedulaString);
            Thread.Sleep(1000);
            apellidos.SendKeys(apellidosString);
            Thread.Sleep(1000);
            nombres.SendKeys(nombresString);
            Thread.Sleep(1000);
            fechaNacimiento.SendKeys(fechaNacimientoString);
            Thread.Sleep(1000);
            mail.SendKeys(mailString);
            Thread.Sleep(1000);
            direccion.SendKeys(direccionString);
            Thread.Sleep(1000);
            telefono.SendKeys(telefonoString);

            Thread.Sleep(3000);

            _driver.FindElement(By.Id("btnGuardar")).Click();

            Thread.Sleep(3000);

            Assert.Equal("https://localhost:7047/Cliente", _driver.Url);
        }

        [Fact]
        public void Create_Mail_Incorrecto()
        {
            string cedulaString = "1727925602";
            string apellidosString = "Perez Perez";
            string nombresString = "Mario David";
            string fechaNacimientoString = "01/01/1990";
            string mailString = "mariogmailcom";
            string direccionString = "Calle 22";
            string telefonoString = "0987654321";


            _driver.Navigate().GoToUrl("https://localhost:7047/Cliente/Create");

            Thread.Sleep(3000);

            var cedula = _wait.Until(d => d.FindElement(By.Name("Cedula")));
            var apellidos = _wait.Until(d => d.FindElement(By.Name("Apellidos")));
            var nombres = _wait.Until(d => d.FindElement(By.Name("Nombres")));
            var fechaNacimiento = _wait.Until(d => d.FindElement(By.Name("FechaNacimiento")));
            var mail = _wait.Until(d => d.FindElement(By.Name("Mail")));
            var direccion = _wait.Until(d => d.FindElement(By.Name("Direccion")));
            var telefono = _wait.Until(d => d.FindElement(By.Name("Telefono")));

            cedula.SendKeys(cedulaString);
            Thread.Sleep(1000);
            apellidos.SendKeys(apellidosString);
            Thread.Sleep(1000);
            nombres.SendKeys(nombresString);
            Thread.Sleep(1000);
            fechaNacimiento.SendKeys(fechaNacimientoString);
            Thread.Sleep(1000);
            mail.SendKeys(mailString);
            Thread.Sleep(1000);
            direccion.SendKeys(direccionString);
            Thread.Sleep(1000);
            telefono.SendKeys(telefonoString);

            Thread.Sleep(3000);

            _driver.FindElement(By.Id("btnGuardar")).Click();

            Thread.Sleep(3000);

            Assert.Equal("https://localhost:7047/Cliente/Create", _driver.Url);
        }

        [Fact]
        public void Create_Fecha_Invalida()
        {
            string cedulaString = "1727925602";
            string apellidosString = "Perez Perez";
            string nombresString = "Mario David";
            string fechaNacimientoString = "01/01/2030";
            string mailString = "mario@gmail.com";
            string direccionString = "Calle 22";
            string telefonoString = "0987654321";


            _driver.Navigate().GoToUrl("https://localhost:7047/Cliente/Create");

            Thread.Sleep(3000);

            var cedula = _wait.Until(d => d.FindElement(By.Name("Cedula")));
            var apellidos = _wait.Until(d => d.FindElement(By.Name("Apellidos")));
            var nombres = _wait.Until(d => d.FindElement(By.Name("Nombres")));
            var fechaNacimiento = _wait.Until(d => d.FindElement(By.Name("FechaNacimiento")));
            var mail = _wait.Until(d => d.FindElement(By.Name("Mail")));
            var direccion = _wait.Until(d => d.FindElement(By.Name("Direccion")));
            var telefono = _wait.Until(d => d.FindElement(By.Name("Telefono")));

            cedula.SendKeys(cedulaString);
            Thread.Sleep(1000);
            apellidos.SendKeys(apellidosString);
            Thread.Sleep(1000);
            nombres.SendKeys(nombresString);
            Thread.Sleep(1000);
            fechaNacimiento.SendKeys(fechaNacimientoString);
            Thread.Sleep(1000);
            mail.SendKeys(mailString);
            Thread.Sleep(1000);
            direccion.SendKeys(direccionString);
            Thread.Sleep(1000);
            telefono.SendKeys(telefonoString);

            Thread.Sleep(3000);

            _driver.FindElement(By.Id("btnGuardar")).Click();

            Thread.Sleep(3000);

            Assert.Equal("https://localhost:7047/Cliente/Create", _driver.Url);
        }

        [Fact]
        public void Create_Vacio()
        {


            _driver.Navigate().GoToUrl("https://localhost:7047/Cliente/Create");

            Thread.Sleep(3000);

            _driver.FindElement(By.Id("btnGuardar")).Click();

            Thread.Sleep(3000);

            Assert.Equal("https://localhost:7047/Cliente/Create", _driver.Url);
        }

        // ================EDIT================

        [Fact]
        public void Edit_Cliente()
        {
            string cedulaString = "1727925602";
            string apellidosString = "Editado";
            string nombresString = "Pancracio";
            string fechaNacimientoString = "01/01/1990";
            string mailString = "mario@gmail.com";
            string direccionString = "Calle 13";
            string telefonoString = "0987654321";

            _driver.Navigate().GoToUrl("https://localhost:7047/Cliente");
            Thread.Sleep(3000);
            _driver.FindElement(By.XPath("//a[@href='/Cliente/Edit/1']")).Click();

            Thread.Sleep(3000);
            var cedula = _wait.Until(d => d.FindElement(By.Name("Cedula")));
            var apellidos = _wait.Until(d => d.FindElement(By.Name("Apellidos")));
            var nombres = _wait.Until(d => d.FindElement(By.Name("Nombres")));
            var fechaNacimiento = _wait.Until(d => d.FindElement(By.Name("FechaNacimiento")));
            var mail = _wait.Until(d => d.FindElement(By.Name("Mail")));
            var direccion = _wait.Until(d => d.FindElement(By.Name("Direccion")));
            var telefono = _wait.Until(d => d.FindElement(By.Name("Telefono")));
            cedula.Clear();
            Thread.Sleep(1000);

            cedula.SendKeys(cedulaString);
            Thread.Sleep(1000);
            apellidos.Clear();
            Thread.Sleep(1000);
            apellidos.SendKeys(apellidosString);
            Thread.Sleep(1000);
            nombres.Clear();
            Thread.Sleep(1000);
            nombres.SendKeys(nombresString);
            Thread.Sleep(1000);
            fechaNacimiento.Clear();
            Thread.Sleep(1000);
            fechaNacimiento.SendKeys(fechaNacimientoString);
            Thread.Sleep(1000);
            mail.Clear();
            Thread.Sleep(1000);
            mail.SendKeys(mailString);
            Thread.Sleep(1000);
            direccion.Clear();
            Thread.Sleep(1000);
            direccion.SendKeys(direccionString);
            Thread.Sleep(1000);
            telefono.Clear();
            Thread.Sleep(1000);
            telefono.SendKeys(telefonoString);

            Thread.Sleep(3000);

            _driver.FindElement(By.Id("btnEditar")).Click();

            Thread.Sleep(3000);

            Assert.Equal("https://localhost:7047/Cliente", _driver.Url);
        }

        [Fact]
        public void Edit_Telefono_Invalido()
        {
            string cedulaString = "1727925602";
            string apellidosString = "Editado";
            string nombresString = "Pancracio";
            string fechaNacimientoString = "01/01/1990";
            string mailString = "mario@gmail.com";
            string direccionString = "Calle 13";
            string telefonoString = "09876543";

            _driver.Navigate().GoToUrl("https://localhost:7047/Cliente");
            Thread.Sleep(3000);
            _driver.FindElement(By.XPath("//a[@href='/Cliente/Edit/1']")).Click();

            Thread.Sleep(3000);
            var cedula = _wait.Until(d => d.FindElement(By.Name("Cedula")));
            var apellidos = _wait.Until(d => d.FindElement(By.Name("Apellidos")));
            var nombres = _wait.Until(d => d.FindElement(By.Name("Nombres")));
            var fechaNacimiento = _wait.Until(d => d.FindElement(By.Name("FechaNacimiento")));
            var mail = _wait.Until(d => d.FindElement(By.Name("Mail")));
            var direccion = _wait.Until(d => d.FindElement(By.Name("Direccion")));
            var telefono = _wait.Until(d => d.FindElement(By.Name("Telefono")));
            cedula.Clear();
            Thread.Sleep(1000);

            cedula.SendKeys(cedulaString);
            Thread.Sleep(1000);
            apellidos.Clear();
            Thread.Sleep(1000);
            apellidos.SendKeys(apellidosString);
            Thread.Sleep(1000);
            nombres.Clear();
            Thread.Sleep(1000);
            nombres.SendKeys(nombresString);
            Thread.Sleep(1000);
            fechaNacimiento.Clear();
            Thread.Sleep(1000);
            fechaNacimiento.SendKeys(fechaNacimientoString);
            Thread.Sleep(1000);
            mail.Clear();
            Thread.Sleep(1000);
            mail.SendKeys(mailString);
            Thread.Sleep(1000);
            direccion.Clear();
            Thread.Sleep(1000);
            direccion.SendKeys(direccionString);
            Thread.Sleep(1000);
            telefono.Clear();
            Thread.Sleep(1000);
            telefono.SendKeys(telefonoString);

            Thread.Sleep(3000);

            _driver.FindElement(By.Id("btnEditar")).Click();

            Thread.Sleep(3000);

            Assert.Equal("https://localhost:7047/Cliente/Edit/1", _driver.Url);
        }

        // ================DELETE================

        [Fact]
        public void Delete_Cliente()
        {
            int id = 1008;

            _driver.Navigate().GoToUrl("https://localhost:7047/Cliente");
            Thread.Sleep(3000);

            _driver.FindElement(By.XPath("//a[@href='/Cliente/Delete/" + id + "']")).Click();

            Thread.Sleep(3000);
            _driver.FindElement(By.Id("btnEliminar")).Click();
            Thread.Sleep(3000);
            Assert.Equal("https://localhost:7047/Cliente", _driver.Url);
        }
    }
}
