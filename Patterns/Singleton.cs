using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public sealed class WebDriverManager
    {
        private static IWebDriver _driver;
        private static readonly object _lock = new();

        private WebDriverManager() { }

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    lock (_lock)
                    {
                        if (_driver == null)
                        {
                            _driver = new ChromeDriver();
                            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                            _driver.Manage().Window.Maximize();
                        }
                    }
                }
                return _driver;
            }
        }

        public static void Quit()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}
