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
    /// Class: InvalidEmailTestCase
    /// Summary: Test case to verify invalid email
    /// </summary>
    [TestFixture]
    public class InvalidEmailTestCase
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
        public void InvalidEmail_InputkcarsDOTcom_ExpectedResultErrorMessage_Test()
        {
            driver.Navigate().GoToUrl(baseURL);

            WebDriverWait waitForElementToFind = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitForElementToFind.Until(r => r.FindElement(By.LinkText("Add Seller")));

            driver.FindElement(By.LinkText("Add Seller")).Click();

            waitForElementToFind.Until(r => r.FindElement(By.Id("sellerText")));
            driver.FindElement(By.Id("sellerText")).Click();
            driver.FindElement(By.Id("sellerText")).Clear();
            driver.FindElement(By.Id("sellerText")).SendKeys("kCars");
            driver.FindElement(By.Id("addressText")).Click();
            driver.FindElement(By.Id("addressText")).Clear();
            driver.FindElement(By.Id("addressText")).SendKeys("12 franklin st w");
            driver.FindElement(By.Id("cityText")).Click();
            driver.FindElement(By.Id("cityText")).Clear();
            driver.FindElement(By.Id("cityText")).SendKeys("Waterloo");
            driver.FindElement(By.Id("phnoText")).Click();
            driver.FindElement(By.Id("phnoText")).Clear();
            driver.FindElement(By.Id("phnoText")).SendKeys("123-234-1234");
            driver.FindElement(By.Id("emailText")).Click();
            driver.FindElement(By.Id("emailText")).Clear();
            driver.FindElement(By.Id("emailText")).SendKeys("kcars.com");
            driver.FindElement(By.Id("makeText")).Click();
            driver.FindElement(By.Id("makeText")).Clear();
            driver.FindElement(By.Id("makeText")).SendKeys("Audi");
            driver.FindElement(By.Id("modelText")).Click();
            driver.FindElement(By.Id("modelText")).Clear();
            driver.FindElement(By.Id("modelText")).SendKeys("A5 Coupe");
            driver.FindElement(By.Id("yearText")).Click();
            driver.FindElement(By.Id("yearText")).Clear();
            driver.FindElement(By.Id("yearText")).SendKeys("2016");
            driver.FindElement(By.Id("submitButton")).Click();

            waitForElementToFind.Until(r => r.FindElement(By.Id("erroremail")));
            Assert.AreEqual("Please enter email.", driver.FindElement(By.Id("erroremail")).Text);
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
