using System;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestingProject.Utilities;

namespace ReqnrollTestingProject.StepDefinitions
{
    [Binding]
    public class SM001_1StepDefinitions
    {
        public IWebDriver _driver;
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public SM001_1StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReport = new ExtentSparkReporter("ExtentreportSM.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReport);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = WebDriverManager.GetDriver("edge");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [Given("The user is on the login page.")]
        public void GivenTheUserIsOnTheLoginPage_()
        {
            _driver.Navigate().GoToUrl("http://localhost:5173/");

            _test.Log(Status.Pass, "The user navigated to the login page");
        }

        [When("The user enters the system with username {string} and password {string}.")]
        public void WhenTheUserEntersTheSystemWithUsernameAndPassword_(string username, string password)
        {
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[1]/input")).SendKeys(username);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[2]/div/input")).SendKeys(password);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/button")).Click();

            _test.Log(Status.Info, $"The user enters to the system with credentials: {username} and {password}");

        }

        [When("Enter the name of the simulation {string}.")]
        public void WhenEnterTheNameOfTheSimulation_(string simulationName)
        {
            Thread.Sleep(10000);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[2]/input")).SendKeys(simulationName);

            _test.Log(Status.Info, $"The user enters the name of the simulation: {simulationName}");
        }

        [When("Click the start simulation button.")]
        public void WhenClickTheStartSimulationButton_()
        {
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[2]/button")).Click();

            _test.Log(Status.Info, "The user clicks the start simulation button");
        }

        [Then("Visualize the system in the new simulation created.")]
        public void ThenVisualizeTheSystemInTheNewSimulationCreated_()
        {
            Thread.Sleep(10000);
            try
            {
                bool isErrorVisible = _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[1]")) != null;
                _test.Log(Status.Pass, "The system is visualized in the new simulation created");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "The system is not visualized in the new simulation created");
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
