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
    public class UM001_2StepDefinitions
    {
        public IWebDriver _driver;
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public UM001_2StepDefinitions(ScenarioContext scenarioContext)
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

        [Given("The user is on the home page")]
        public void GivenTheUserIsOnTheHomePage()
        {
            _driver.Navigate().GoToUrl("http://localhost:5173/");

            _test.Log(Status.Pass, "The user navigated to the login page");
        }

        [When("Enter the username {string} and password {string}")]
        public void WhenEnterTheUsernameAndPassword(string username, string password)
        {
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[1]/input")).SendKeys(username);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[2]/div/input")).SendKeys(password);

            _test.Log(Status.Info, $"The user enters the credentials: {username} and {password}");
        }

        [When("Click on the Login button")]
        public void WhenClickOnTheLoginButton()
        {
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/button")).Click();

            _test.Log(Status.Info, "The user clicks on the login button");
        }

        [Then("View the alert message")]
        public void ThenViewTheAlertMessage()
        {
            Thread.Sleep(2000);
            try
            {
                bool isErrorVisible = _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/p")) != null;
                _test.Log(Status.Pass, "Error message displayed");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "Error message not displayed");
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
