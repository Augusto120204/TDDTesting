using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollTestingProject.Utilities
{
    public static class WebDriverManager
    {
        public static IWebDriver GetDriver(string browser)
        {
            return browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "brave" => GetBraveDriver(),
                "edge" => new EdgeDriver(),
                _ => throw new ArgumentException("Invalid browser"),
            };
        }

        private static IWebDriver GetBraveDriver()
        {
            var options = new ChromeOptions();
            options.BinaryLocation = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe"; // Ruta al ejecutable de Brave
            return new ChromeDriver(options);
        }

    }
}
