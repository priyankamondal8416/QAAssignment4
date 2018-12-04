using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCases
{
    /// <summary>
    /// Class: SearchWithNoDataTestCase
    /// Summary: When website is not having any seller information, this test case should pass. Otherwise it should fail.
    /// </summary>
    /// 
    [TestFixture]
    public class SearchWithNoDataTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/QAA4/index.html";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void Search_InputNothing_ExpectedResultNoSellerFoundOnWesiteDotPleaseAddSellerFirst_Test()
        {
            driver.Navigate().GoToUrl(baseURL);

            WebDriverWait waitForElementToFind = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitForElementToFind.Until(r => r.FindElement(By.Id("searchText")));
            driver.FindElement(By.Id("searchText")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Add Seller'])[1]/following::button[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='No Sellers found on website. Please add sellers.'])[1]/following::button[1]")).Click();
            Assert.AreEqual("No Sellers found on website. Please add sellers.", driver.FindElement(By.XPath("//*[@id=\"productTitle\"]")).Text);

            driver.Navigate().GoToUrl(baseURL);
            waitForElementToFind.Until(r => r.FindElement(By.Id("searchText")));
            driver.FindElement(By.Id("searchText")).Click();
            driver.FindElement(By.Id("searchText")).Clear();
            driver.FindElement(By.Id("searchText")).SendKeys("test");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Add Seller'])[1]/following::button[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='No Sellers found on website. Please add sellers.'])[1]/following::button[1]")).Click();

            waitForElementToFind.Until(r => r.FindElement(By.XPath("//*[@id=\"productTitle\"]")));
            Assert.AreEqual("No Sellers found on website. Please add sellers.", driver.FindElement(By.XPath("//*[@id=\"productTitle\"]")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
