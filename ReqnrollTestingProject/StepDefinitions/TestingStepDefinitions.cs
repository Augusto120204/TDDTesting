using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using Productos.Data;
using Reqnroll;
using ReqnrollTestingProject.Utilities;

namespace ReqnrollTestingProject.StepDefinitions
{
    [Binding]
    public class TestingStepDefinitions
    {
        public IWebDriver _driver;
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public TestingStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReport = new ExtentSparkReporter("Examen.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReport);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver("edge");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);

        }

        [Given("Ingresar a la pagina de creacion de clientes.")]
        public void GivenIngresarALaPaginaDeCreacionDeClientes_()
        {
            _driver.Navigate().GoToUrl("https://localhost:7047/Cliente/Create");

            _test.Log(Status.Pass, "Usuario navega a la pagina de creacion de clientes");
        }

        [When("Llenar los campos dentro del formulario.")]
        public void WhenLlenarLosCamposDentroDelFormulario_(DataTable dataTable)
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
            }

            _driver.FindElement(By.Name("Cedula")).SendKeys(Keys.Control + "A");
            _driver.FindElement(By.Name("Cedula")).SendKeys(cls.Cedula);
            _driver.FindElement(By.Name("Apellidos")).SendKeys(Keys.Control + "A");
            _driver.FindElement(By.Name("Apellidos")).SendKeys(cls.Apellidos);
            _driver.FindElement(By.Name("Nombres")).SendKeys(Keys.Control + "A");
            _driver.FindElement(By.Name("Nombres")).SendKeys(cls.Nombres);
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys(Keys.Control + "A");
            _driver.FindElement(By.Name("FechaNacimiento")).SendKeys(cls.FechaNacimiento.ToString());
            _driver.FindElement(By.Name("Mail")).SendKeys(Keys.Control + "A");
            _driver.FindElement(By.Name("Mail")).SendKeys(cls.Mail);
            _driver.FindElement(By.Name("Direccion")).SendKeys(Keys.Control + "A");
            _driver.FindElement(By.Name("Direccion")).SendKeys(cls.Direccion);
            _driver.FindElement(By.Name("Telefono")).SendKeys(Keys.Control + "A");
            _driver.FindElement(By.Name("Telefono")).SendKeys(cls.Telefono);

            _test.Log(Status.Info, $"Usuario llena los campos del formulario: {cls.Cedula}, {cls.Apellidos}, {cls.Nombres}, {cls.FechaNacimiento}, {cls.Mail}, {cls.Telefono}, {cls.Direccion}");
        }

        [When("Dar clic en el boton de guardar.")]
        public void WhenDarClicEnElBotonDeGuardar_()
        {
            _driver.FindElement(By.Id("btnGuardar")).Click();

            _test.Log(Status.Info, "Usuario hace click en el boton de guardar");
        }

        [Then("Verificar que el cliente fue guardado correctamente.")]
        public void ThenVerificarQueElClienteFueGuardadoCorrectamente_()
        {
            Thread.Sleep(2000);
            bool resultado = _driver.Url == "https://localhost:7047/Cliente";

            if (resultado)
            {
                _test.Log(Status.Pass, "Cliente guardado correctamente");
            }
            else
            {
                _test.Log(Status.Fail, "Cliente no guardado correctamente");
            }
        }

        [Then("Verificar que el cliente no fue guardado correctamente.")]
        public void ThenVerificarQueElClienteNoFueGuardadoCorrectamente_()
        {
            Thread.Sleep(2000);
            bool resultado = _driver.Url == "https://localhost:7047/Cliente/Create";

            if (resultado)
            {
                _test.Log(Status.Pass, "Cliente guardado correctamente");
            }
            else
            {
                _test.Log(Status.Fail, "Cliente no guardado correctamente");
            }
        }

        [Given("Ingresar a la pagina de edicion de clientes.")]
        public void GivenIngresarALaPaginaDeEdicionDeClientes_()
        {
            _driver.Navigate().GoToUrl("https://localhost:7047/Cliente/Edit/1");

            _test.Log(Status.Pass, "Usuario navega a la pagina de edicion de clientes");
        }

        [When("Dar clic en el boton de editar.")]
        public void WhenDarClicEnElBotonDeEditar_()
        {
            _driver.FindElement(By.Id("btnEditar")).Click();

            _test.Log(Status.Info, "Usuario hace click en el boton de editar");
        }

        [Then("Verificar que el cliente fue editado correctamente.")]
        public void ThenVerificarQueElClienteFueEditadoCorrectamente_()
        {
            bool resultado = _driver.Url == "https://localhost:7047/Cliente";

            if (resultado)
            {
                _test.Log(Status.Pass, "Cliente editado correctamente");
            }
            else
            {
                _test.Log(Status.Fail, "Cliente no editado correctamente");
            }
        }

        [Then("Verificar que el cliente no fue editado correctamente.")]
        public void ThenVerificarQueElClienteNoFueEditadoCorrectamente_()
        {
            bool resultado = _driver.Url == "https://localhost:7047/Cliente/Edit/1";

            if (resultado)
            {
                _test.Log(Status.Pass, "Cliente editado correctamente");
            }
            else
            {
                _test.Log(Status.Fail, "Cliente no editado correctamente");
            }
        }


        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
            _extent.Flush();
        }
    }
}
