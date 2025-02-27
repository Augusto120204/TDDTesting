using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TestProductos
{
    public class DemogaTest
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public DemogaTest()
        {
            var options = new ChromeOptions();
            options.BinaryLocation = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe";
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        public bool EsMailValido(string email)
        {
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        public static bool EsCedulaValida(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula) || cedula.Length != 10 || !cedula.All(char.IsDigit))
                return false;

            int provincia = int.Parse(cedula.Substring(0, 2));
            if (provincia < 1 || provincia > 24)
                return false;

            int digitoVerificador = int.Parse(cedula[9].ToString());
            int suma = 0;

            for (int i = 0; i < 9; i++)
            {
                int num = int.Parse(cedula[i].ToString());
                if (i % 2 == 0)
                    num *= 2;
                if (num > 9)
                    num -= 9;
                suma += num;
            }

            int calculoVerificador = 10 - (suma % 10);
            if (calculoVerificador == 10)
                calculoVerificador = 0;

            return calculoVerificador == digitoVerificador;
        }

        //[Fact]
        public void Test_FormularioVacio()
        {
            try
            {
                _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
                Thread.Sleep(3000);
                var submitButton = _wait.Until(d => d.FindElement(By.Id("submit")));
                Thread.Sleep(3000);
                submitButton.SendKeys(Keys.Enter);
                Thread.Sleep(3000);

                var formValidated = _driver.FindElement(By.ClassName("was-validated"));

                Assert.True(formValidated != null, "El formulario no a sido validado");

            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            finally
            {
                _driver.Quit();
            }
        }

        //[Fact]
        public void Test_DatosInvalidos()
        {
            string nombre = "Augusto";
            string apellido = "Salazar";
            string email = "augusto@gmail.com";
            string fechaNacimiento = "";
            string telefono = "09876543";
            string subjects = "Maths";
            string address = "Calle 13 # 13-13";
            string state = "NCR";
            string city = "Delhi";
            try
            {
                _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
                Thread.Sleep(3000);
                var nombreInput = _wait.Until(d => d.FindElement(By.Id("firstName")));
                var apellidoInput = _wait.Until(d => d.FindElement(By.Id("lastName")));
                var emailInput = _wait.Until(d => d.FindElement(By.Id("userEmail")));
                var generoInput = _wait.Until(d => d.FindElement(By.XPath("//label[@for='gender-radio-1']")));
                var telefonoInput = _wait.Until(d => d.FindElement(By.Id("userNumber")));
                var fechaInput = _wait.Until(d => d.FindElement(By.Id("dateOfBirthInput")));
                var submitButton = _wait.Until(d => d.FindElement(By.Id("submit")));
                var subjectsInput = _wait.Until(d => d.FindElement(By.Id("subjectsInput")));
                var hobbiesInput = _wait.Until(d => d.FindElement(By.XPath("//label[@for='hobbies-checkbox-1']")));
                var addressInput = _wait.Until(d => d.FindElement(By.Id("currentAddress")));
                var stateInput = _wait.Until(d => d.FindElement(By.Id("react-select-3-input")));
                var cityInput = _wait.Until(d => d.FindElement(By.Id("react-select-4-input")));

                nombreInput.SendKeys(nombre);
                Thread.Sleep(1000);
                apellidoInput.SendKeys(apellido);
                Thread.Sleep(1000);
                emailInput.SendKeys(email);
                Thread.Sleep(1000);
                generoInput.Click();
                Thread.Sleep(1000);
                telefonoInput.SendKeys(telefono);
                Thread.Sleep(1000);
                fechaInput.SendKeys(Keys.Control + "a");
                fechaInput.SendKeys(fechaNacimiento);
                fechaInput.SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                subjectsInput.SendKeys(subjects);
                subjectsInput.SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                hobbiesInput.Click();
                Thread.Sleep(1000);
                addressInput.SendKeys(address);
                Thread.Sleep(1000);
                stateInput.SendKeys(state);
                stateInput.SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                cityInput.SendKeys(city);
                cityInput.SendKeys(Keys.Enter);
                Thread.Sleep(5000);
                submitButton.SendKeys(Keys.Enter);
                Thread.Sleep(3000);

                Assert.Equal("rgb(220, 53, 69)", telefonoInput.GetCssValue("border-color"));

            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            finally
            {
                _driver.Quit();
            }
        }

        //[Fact]
        public void Test_CorreoCedula()
        {
            string nombre = "Augusto";
            string apellido = "Salazar";
            string email = "augustogmail.com";
            string cedula = "1234567890";
            string fechaNacimiento = "12 Feb 2004";
            string telefono = "0987654321";
            string subjects = "Maths";
            string address = "Calle 13 # 13-13";
            string state = "NCR";
            string city = "Delhi";
            try
            {
                _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
                Thread.Sleep(3000);
                var nombreInput = _wait.Until(d => d.FindElement(By.Id("firstName")));
                var apellidoInput = _wait.Until(d => d.FindElement(By.Id("lastName")));
                var emailInput = _wait.Until(d => d.FindElement(By.Id("userEmail")));
                var generoInput = _wait.Until(d => d.FindElement(By.XPath("//label[@for='gender-radio-1']")));
                var telefonoInput = _wait.Until(d => d.FindElement(By.Id("userNumber")));
                var fechaInput = _wait.Until(d => d.FindElement(By.Id("dateOfBirthInput")));
                var submitButton = _wait.Until(d => d.FindElement(By.Id("submit")));
                var subjectsInput = _wait.Until(d => d.FindElement(By.Id("subjectsInput")));
                var hobbiesInput = _wait.Until(d => d.FindElement(By.XPath("//label[@for='hobbies-checkbox-1']")));
                var addressInput = _wait.Until(d => d.FindElement(By.Id("currentAddress")));
                var stateInput = _wait.Until(d => d.FindElement(By.Id("react-select-3-input")));
                var cityInput = _wait.Until(d => d.FindElement(By.Id("react-select-4-input")));


                nombreInput.SendKeys(nombre);
                Thread.Sleep(1000);
                apellidoInput.SendKeys(apellido);
                Thread.Sleep(1000);
                emailInput.SendKeys(email);
                Thread.Sleep(1000);
                generoInput.Click();
                Thread.Sleep(1000);
                telefonoInput.SendKeys(telefono);
                Thread.Sleep(1000);
                fechaInput.SendKeys(Keys.Control + "a");
                fechaInput.SendKeys(fechaNacimiento);
                fechaInput.SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                subjectsInput.SendKeys(subjects);
                subjectsInput.SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                hobbiesInput.Click();
                Thread.Sleep(1000);
                addressInput.SendKeys(address);
                Thread.Sleep(1000);
                stateInput.SendKeys(state);
                stateInput.SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                cityInput.SendKeys(city);
                cityInput.SendKeys(Keys.Enter);
                Thread.Sleep(5000);
                submitButton.SendKeys(Keys.Enter);
                Thread.Sleep(3000);

                Assert.Equal("rgb(220, 53, 69)", emailInput.GetCssValue("border-color"));

            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            finally
            {
                _driver.Quit();
            }
        }

        //[Fact]
        public void Test_Valido()
        {
            string nombre = "Augusto";
            string apellido = "Salazar";
            string email = "augusto@gmail.com";
            string fechaNacimiento = "12 Feb 2004";
            string telefono = "0987654321";
            string subjects = "Maths";
            string address = "Calle 13 # 13-13";
            string state = "NCR";
            string city = "Delhi";
            try
            {
                _driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
                Thread.Sleep(5000);
                var nombreInput = _wait.Until(d => d.FindElement(By.Id("firstName")));
                var apellidoInput = _wait.Until(d => d.FindElement(By.Id("lastName")));
                var emailInput = _wait.Until(d => d.FindElement(By.Id("userEmail")));
                var generoInput = _wait.Until(d => d.FindElement(By.XPath("//label[@for='gender-radio-1']")));
                var telefonoInput = _wait.Until(d => d.FindElement(By.Id("userNumber")));
                var fechaInput = _wait.Until(d => d.FindElement(By.Id("dateOfBirthInput")));
                var submitButton = _wait.Until(d => d.FindElement(By.Id("submit")));
                var subjectsInput = _wait.Until(d => d.FindElement(By.Id("subjectsInput")));
                var hobbiesInput = _wait.Until(d => d.FindElement(By.XPath("//label[@for='hobbies-checkbox-1']")));
                var addressInput = _wait.Until(d => d.FindElement(By.Id("currentAddress")));
                var stateInput = _wait.Until(d => d.FindElement(By.Id("react-select-3-input")));
                var cityInput = _wait.Until(d => d.FindElement(By.Id("react-select-4-input")));

                nombreInput.SendKeys(nombre);
                Thread.Sleep(1000);
                apellidoInput.SendKeys(apellido);
                Thread.Sleep(1000);
                emailInput.SendKeys(email);
                Thread.Sleep(1000);
                generoInput.Click();
                Thread.Sleep(1000);
                telefonoInput.SendKeys(telefono);
                Thread.Sleep(1000);
                fechaInput.SendKeys(Keys.Control + "a");
                fechaInput.SendKeys(fechaNacimiento);
                fechaInput.SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                subjectsInput.SendKeys(subjects);
                subjectsInput.SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                hobbiesInput.Click();
                Thread.Sleep(1000);
                addressInput.SendKeys(address);
                Thread.Sleep(1000);
                stateInput.SendKeys(state);
                stateInput.SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                cityInput.SendKeys(city);
                cityInput.SendKeys(Keys.Enter);
                Thread.Sleep(5000);
                submitButton.SendKeys(Keys.Enter);
                Thread.Sleep(3000);

                var modal = _driver.FindElement(By.Id("example-modal-sizes-title-lg"));

                Assert.True(modal != null, "El formulario no a sido validado");

            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            finally
            {
                _driver.Quit();
            }
        }
    }
}
