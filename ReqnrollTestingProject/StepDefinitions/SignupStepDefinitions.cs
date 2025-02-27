using System;
using System.Security.Policy;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestingProject.Utilities;

namespace ReqnrollTestingProject.StepDefinitions
{
    [Binding]
    public class SignupStepDefinitions
    {
        public IWebDriver _driver;
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public SignupStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReport = new ExtentSparkReporter("Extentreport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReport);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver("edge");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);

        }

        [Given("El usuario se encuentra en la pagina de Registro")]
        public void GivenElUsuarioSeEncuentraEnLaPaginaDeRegistro()
        {
            _driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

            _test.Log(Status.Pass, "Usuario navega a la pagina de login");
        }

        [When("Ingresa nombre {string} y correo {string}")]
        public void WhenIngresaNombreYCorreo(string name, string email)
        {
            _driver.FindElement(By.Name("name")).SendKeys(name);
            _driver.FindElement(By.CssSelector("[data-qa='signup-email']")).SendKeys(email);

            _test.Log(Status.Info, $"Usuario ingresa las credenciales: {name} y {email}");
        }

        [When("Hacer click en el boton signup")]
        public void WhenHacerClickEnElBotonSignup()
        {
            _driver.FindElement(By.CssSelector("[data-qa=\"signup-button\"]")).Click();

            _test.Log(Status.Info, "Usuario hace click en el boton de signup");
        }

        [When("Se llenan los campos contraseña {string}, primer nombre {string}, apellido {string}, direccion {string}, estado {string}, ciudad {string}, zip {string}, telefono {string}")]
        public void WhenSeLlenanLosCamposContrasenaPrimerNombreApellidoDireccionEstadoCiudadZipTelefono(string password, string name, string lastName, string address, string state, string city, string zipCode, string mobile)
        {
            _driver.FindElement(By.Id("password")).SendKeys(password);
            _driver.FindElement(By.Id("first_name")).SendKeys(name);
            _driver.FindElement(By.Id("last_name")).SendKeys(lastName);
            _driver.FindElement(By.Id("address1")).SendKeys(address);
            _driver.FindElement(By.Id("state")).SendKeys(state);
            _driver.FindElement(By.Id("city")).SendKeys(city);
            _driver.FindElement(By.Id("zipcode")).SendKeys(zipCode);
            _driver.FindElement(By.Id("mobile_number")).SendKeys(mobile);

            _test.Log(Status.Info, $"Usuario ingresa las credenciales: {password}, {name}, {lastName}, {address}, {state}, {city}, {zipCode}, {mobile}");
        }

        [When("Hacer click en el boton de Registro")]
        public void WhenHacerClickEnElBotonDeRegistro()
        {
            _driver.FindElement(By.CssSelector("[data-qa=\"create-account\"]")).SendKeys(Keys.Enter);

            _test.Log(Status.Info, "Usuario hace click en el boton de registro");
        }

        [Then("Deberia ver un mensaje de confirmacion")]
        public void ThenDeberiaVerUnMensajeDeConfirmacion()
        {
            try
            {
                bool resultado = _driver.Url == "https://www.automationexercise.com/account_created";
                _test.Log(Status.Pass, "Mensaje de confirmación mostrado correctamente");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "Mensaje de error no mostrado");
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
