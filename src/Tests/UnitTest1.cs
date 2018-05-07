using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Xunit;

namespace vsts_test
{
    public class UnitTest1 : IDisposable
    {
        public UnitTest1()
        {
            urlApp = "http://www.bing.com/";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
        }

        private IWebDriver driver;
        private string urlApp;

        [Fact]
        public void MyTest()
        {
            driver.Navigate().GoToUrl($"{urlApp}/");
            driver.FindElement(By.Id("sb_form_q")).SendKeys("VSTS");
            driver.FindElement(By.Id("sb_form_go")).Click();
            driver.FindElement(By.XPath("//ol[@id='b_results']/li[3]/h2/a")).Click();
            Assert.True(driver.Title.Contains("VSTS"));
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
