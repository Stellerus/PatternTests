using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public abstract class BasePage
    {
        protected IWebDriver Driver => WebDriverManager.Driver;

        public abstract string Url { get; }

        public void Open()
        {
            Driver.Navigate().GoToUrl(Url);
        }
    }

    public class AboutPage : BasePage
    {
        public override string Url => "https://en.ehu.lt/about/";

        public string Title => Driver.Title;

        public bool ContainsText(string text) => Driver.PageSource.Contains(text);
    }
    public class HomePage : BasePage
    {
        public override string Url => "https://en.ehu.lt/";

        public void GoToAbout()
        {
            Driver.FindElement(By.CssSelector("li[data-id='about']")).Click();
        }

        public void Search(string query)
        {
            var searchInput = Driver.FindElement(By.Name("s"));
            searchInput.SendKeys(query);
            searchInput.SendKeys(Keys.Enter);
        }

        public void ChangeLanguageToLithuanian()
        {
            Driver.FindElement(By.LinkText("Lietuvių")).Click();
        }

        public class ContactPage : BasePage
        {
            public override string Url => "https://en.ehu.lt/contact/";

            public string PageSource => Driver.PageSource;
        }


    }
}
