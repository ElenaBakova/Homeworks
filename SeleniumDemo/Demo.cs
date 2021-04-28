using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SeleniumDemo
{
    class SeleniumDemo
    {
        string testURL = "https://www.google.com";

        IWebDriver driver;

        /// <summary>
        /// Opens Chrome, maximizes window
        /// </summary>
        [SetUp]
        public void startBrowser()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Test script
        /// </summary>
        [Test]
        public void testSearch()
        {
            driver.Url = testURL;

            IWebElement searchText = driver.FindElement(By.CssSelector("[name = 'q']"));
            searchText.SendKeys($"LambdaTest{Keys.Enter}");
            Thread.Sleep(2000);

            searchText = driver.FindElement(By.CssSelector("[name = 'q']"));
            searchText.Clear();
            searchText.SendKeys($"Unit-Testing{Keys.Enter}");

        }

        /// <summary>
        /// Closes browser
        /// </summary>
        [TearDown]
        public void closeBrowser()
        {
            Thread.Sleep(6000);
            driver.Quit();
        }
    }
}