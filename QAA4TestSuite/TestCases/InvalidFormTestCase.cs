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
    /// Class: InvalidFormTestCase
    /// Summary: Test case with invalid form. Error should be displayed and should not generate the information
    /// </summary>

    [TestFixture]
    class InvalidFormTestCase
    {
        private IWebDriver driver;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/QAA4/index.html";
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
        }

        [Test]
        public void InvalidForm_ClickSubmit_ExpectedErrorMessages_Test()
        {
            driver.Navigate().GoToUrl(baseURL);

            WebDriverWait waitForElementToFind = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitForElementToFind.Until(r => r.FindElement(By.LinkText("Add Seller")));

            driver.FindElement(By.LinkText("Add Seller")).Click();
            driver.FindElement(By.Id("submitButton")).Click();

            waitForElementToFind.Until(r => r.FindElement(By.XPath("//*[@id=\"errorSellerName\"]")));
            Assert.AreEqual("Please enter seller name.", driver.FindElement(By.XPath("//*[@id=\"errorSellerName\"]")).Text);

            waitForElementToFind.Until(r => r.FindElement(By.XPath("//*[@id=\"addressText\"]")));
            Assert.AreEqual("", driver.FindElement(By.XPath("//*[@id=\"addressText\"]")).GetAttribute("value"));

            waitForElementToFind.Until(r => r.FindElement(By.XPath("//*[@id=\"cityText\"]")));
            Assert.AreEqual("", driver.FindElement(By.XPath("//*[@id=\"cityText\"]")).GetAttribute("value"));

            waitForElementToFind.Until(r => r.FindElement(By.XPath("//*[@id=\"phnoText\"]")));
            Assert.AreEqual("", driver.FindElement(By.XPath("//*[@id=\"phnoText\"]")).GetAttribute("value"));

            waitForElementToFind.Until(r => r.FindElement(By.XPath("//*[@id=\"erroremail\"]")));
            Assert.AreEqual("Please enter email.", driver.FindElement(By.XPath("//*[@id=\"erroremail\"]")).Text);

            waitForElementToFind.Until(r => r.FindElement(By.XPath("//*[@id=\"makeText\"]")));
            Assert.AreEqual("", driver.FindElement(By.XPath("//*[@id=\"makeText\"]")).GetAttribute("value"));

            waitForElementToFind.Until(r => r.FindElement(By.XPath("//*[@id=\"modelText\"]")));
            Assert.AreEqual("", driver.FindElement(By.XPath("//*[@id=\"modelText\"]")).GetAttribute("value"));

            waitForElementToFind.Until(r => r.FindElement(By.XPath("//*[@id=\"yearText\"]")));
            Assert.AreEqual("", driver.FindElement(By.XPath("//*[@id=\"yearText\"]")).GetAttribute("value"));
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
