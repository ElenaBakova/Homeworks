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

        [SetUp]
        public void startBrowser()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void testSearch()
        {
            driver.Url = testURL;

            //Thread.Sleep(1000);

            IWebElement searchText = driver.FindElement(By.CssSelector("[name = 'q']"));
            searchText.SendKeys($"LambdaTest{Keys.Enter}");
            Thread.Sleep(2000);

            searchText = driver.FindElement(By.CssSelector("[name = 'q']"));
            searchText.Clear();
            searchText.SendKeys($"Unit-Testing{Keys.Enter}");

            //Thread.Sleep(6000);
        }

        /*[TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }*/
    }
}