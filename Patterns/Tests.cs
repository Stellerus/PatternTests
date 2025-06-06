using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Patterns.HomePage;

namespace Patterns
{
    [TestFixture]
    public class EHUWebTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = WebDriverManager.Driver;
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverManager.Quit();
        }

        [Test]
        public void Test_AboutEHUPageNavigation()
        {
            var homePage = PageFactory.GetPage<HomePage>();
            homePage.Open();
            homePage.GoToAbout();

            var aboutPage = PageFactory.GetPage<AboutPage>();
            Assert.That(driver.Url, Is.EqualTo(aboutPage.Url));
            Assert.That(aboutPage.ContainsText("About European Humanities University"));
        }

        [Test]
        public void Test_SearchFunctionality()
        {
            var homePage = PageFactory.GetPage<HomePage>();
            homePage.Open();

            var searchQuery = new SearchQueryBuilder()
                .SetQuery("study programs")
                .Build();

            homePage.Search(searchQuery);

            Assert.That(driver.Url, Does.Contain("/?s=study+programs"));
            Assert.That(driver.PageSource.ToLower(), Does.Contain(searchQuery));
        }

        [Test]
        public void Test_LanguageChangeToLithuanian()
        {
            var homePage = PageFactory.GetPage<HomePage>();
            homePage.Open();

            homePage.ChangeLanguageToLithuanian();

            Assert.That(driver.Url, Does.StartWith("https://lt.ehu.lt/"));
            Assert.That(driver.PageSource, Does.Contain("Europos humanitarinis universitetas"));
        }

        [Test]
        public void Test_ContactFormVisibility()
        {
            var contactPage = PageFactory.GetPage<ContactPage>();
            contactPage.Open();

            var pageSource = contactPage.PageSource;

            Assert.That(pageSource, Does.Contain("franciskscarynacr@gmail.com"));
            Assert.That(Regex.IsMatch(pageSource, @"\+370\s?\d{2}\s?\d{5,6}"), Is.True);
            Assert.That(Regex.IsMatch(pageSource, @"\+375\s?\d{2}\s?\d{6,7}"), Is.True);
            Assert.That(
                pageSource.Contains("Facebook") || pageSource.Contains("Telegram") || pageSource.Contains("VK"),
                Is.True
            );
        }
    }

}
