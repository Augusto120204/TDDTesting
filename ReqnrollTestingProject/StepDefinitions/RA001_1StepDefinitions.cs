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
    public class RA001_1StepDefinitions
    {
        public static IWebDriver _driver;
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;

        public RA001_1StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var sparkReport = new ExtentSparkReporter("Extentreport1.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReport);
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            if (_driver == null)
            {
                _driver = WebDriverManager.GetDriver("edge");
            }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);

        }

        [Given("The user enters to the page of the voting simulation")]
        public void GivenTheUserEntersToThePageOfTheVotingSimulation()
        {
            _driver.Navigate().GoToUrl("http://localhost:5173/");

            _test.Log(Status.Pass, "The user navigated to the login page");
        }

        [When("Login with the username {string} and password {string}")]
        public void WhenLoginWithTheUsernameAndPassword(string username, string password)
        {
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[1]/input")).SendKeys(username);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/div[2]/div/input")).SendKeys(password);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div/div/div/button")).Click();

            _test.Log(Status.Info, $"The user enters the credentials: {username} and {password}");
        }

        [When("Select the province {string}, canton {string}, parish {string} and precint {string}")]
        public void WhenSelectTheProvinceCantonParishAndPrecint(string province, string canton, string parish, string precint)
        {
            Thread.Sleep(10000);
            _driver.FindElement(By.XPath("//*[@id=\"react-select-3-input\"]")).Click();
            _driver.FindElement(By.XPath("//*[@id=\"react-select-3-input\"]")).SendKeys(province);
            _driver.FindElement(By.XPath("//*[@id=\"react-select-3-input\"]")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//*[@id=\"react-select-5-input\"]")).Click();
            _driver.FindElement(By.XPath("//*[@id=\"react-select-5-input\"]")).SendKeys(Keys.Enter);
            _driver.FindElement(By.XPath("//*[@id=\"react-select-5-input\"]")).SendKeys(canton);
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//*[@id=\"react-select-7-input\"]")).Click();
            _driver.FindElement(By.XPath("//*[@id=\"react-select-7-input\"]")).SendKeys(parish);
            _driver.FindElement(By.XPath("//*[@id=\"react-select-7-input\"]")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//*[@id=\"react-select-9-input\"]")).Click();
            _driver.FindElement(By.XPath("//*[@id=\"react-select-9-input\"]")).SendKeys(precint);
            _driver.FindElement(By.XPath("//*[@id=\"react-select-9-input\"]")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[1]/form/button")).SendKeys(Keys.Enter);

            _test.Log(Status.Info, $"The user selects the province: {province}, canton: {canton}, parish: {parish} and precint: {precint}");
        }

        [When("Click the dignity President")]
        public void WhenClickTheDignityPresident()
        {
            Thread.Sleep(10000);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/div[2]/div[1]/div")).Click();

            _test.Log(Status.Info, "The user selects the dignity President");
        }

        [When("Select the political party RC{int}")]
        public void WhenSelectThePoliticalPartyRC(int p0)
        {
            Thread.Sleep(10000);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/div[5]/div[2]/div[1]/div/p")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/div[5]/div[2]/div[2]/div/div[1]")).Click();

            _test.Log(Status.Info, "The user selects the political party RC5");
        }

        [When("Enter the number of votes {int}")]
        public void WhenEnterTheNumberOfVotes(int votes)
        {
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/div[6]/div/input")).SendKeys(Keys.Control + "A");
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/div[6]/div/input")).SendKeys(votes.ToString());
            _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/div[6]/div/div[3]/button[2]")).Click();

            _test.Log(Status.Info, $"The user enters the number of votes: {votes}");
        }

        [Then("Verify that the votes are correctly assigned")]
        public void ThenVerifyThatTheVotesAreCorrectlyAssigned()
        {
            Thread.Sleep(2000);
            try
            {
                var verify = _driver.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/div[5]/div[2]/div[2]/div/div[1]/p[1]"));
                _test.Log(Status.Pass, "The votes are correctly assigned");
            }
            catch (Exception e)
            {
                _test.Log(Status.Fail, "The votes are not correctly assigned");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
            _extent.Flush();
        }
    }
}
