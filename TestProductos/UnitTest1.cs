using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace TestProductos
{
    public class UnitTest1
    {

        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public UnitTest1()
        {
            var options = new ChromeOptions();
            options.BinaryLocation = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe";
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        public void Test1()
        {

        }

        //public bool EsMailValido(string email)
        //{
        //    return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        //}

        //[Theory]
        //[InlineData("usuario@gmail.com", true)]
        //[InlineData("test@empresa.com", true)]
        //[InlineData("correo_prueba.com", false)]
        //[InlineData("sinarrobanicomcom", false)]
        //public void TestMail(string email, bool expected)
        //{
        //    bool resultado = EsMailValido(email);
        //    Assert.Equal(expected, resultado);
        //}

        //[Fact]
        //public void Test_NavegadorGoogle()
        //{
        //    try
        //    {
        //        _driver.Navigate().GoToUrl("https://www.bing.com");
        //        var searchBox = _wait.Until(d => d.FindElement(By.Name("q")));

        //        Thread.Sleep(3000);
        //        searchBox.SendKeys("Selenium");

        //        Thread.Sleep(3000);
        //        //searchBox.SendKeys(Keys.Enter);
        //        _driver.FindElement(By.Id("search_icon")).Click();

        //        Thread.Sleep(5000);

        //        var searchResults = _wait.Until(d => d.FindElements(By.CssSelector("h2")));

        //        Assert.True(searchResults.Count > 0, "No se encontraron resultados de la busqueda");

        //        Console.WriteLine("Resultados de la busqueda");
        //        Console.WriteLine("Esperando 10 segundos para cerrar el navegador");

        //        Thread.Sleep(10000);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.True(false, ex.Message);
        //    }
        //    finally
        //    {
        //        _driver.Quit();
        //    }
        //}
    }
}