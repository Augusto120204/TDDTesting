using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using ReqnrollTestingProject.Utilities;

namespace ReqnrollTestingProject.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        public IWebDriver _driver;
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
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

        [Given("El usuario se encuentra en la pagina del LogIn")]
        public void GivenElUsuarioSeEncuentraEnLaPaginaDelLogIn()
        {
            _driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

            _test.Log(Status.Pass, "Usuario navega a la pagina de login");
        }

        [When("Ingresa las credenciales correo {string} y la contraseña {string}")]
        public void WhenIngresaLasCredencialesCorreoYLaContrasena(string email, string password)
        {
            _driver.FindElement(By.Name("email")).SendKeys(email);
            _driver.FindElement(By.Name("password")).SendKeys(password);

            _test.Log(Status.Info, $"Usuario ingresa las credenciales: {email} y {password}");
        }

        [When("Hacer click en el boton de Login")]
        public void WhenHacerClickEnElBotonDeLogin()
        {
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            _test.Log(Status.Info, "Usuario hace click en el boton de login");
        }

        [Then("Deberia ver un mensaje de error")]
        public void ThenDeberiaVerUnMensajeDeError()
        {
            try
            {
                bool isErrorVisible = _driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[1]/div/form/p")) != null;
                _test.Log(Status.Pass, "Mensaje de error mostrado correctamente");
            }
            catch(NoSuchElementException)
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
