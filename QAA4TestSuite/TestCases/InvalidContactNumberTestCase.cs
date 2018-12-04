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
    /// Class:
    /// Summary: Test Case to verify invalid contact number
    /// </summary>
    [TestFixture]
    public class InvalidContactNumberTestCase
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
        public void InvalidContactNumberTestCase_Input201Dash233Dash34rr_AND_Input201Dash233Dashabcd_ExpectedErrorMessage_Test()
        {
            driver.Navigate().GoToUrl(baseURL);

            WebDriverWait waitForElementToFind = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitForElementToFind.Until(r => r.FindElement(By.LinkText("Add Seller")));

            driver.FindElement(By.LinkText("Add Seller")).Click();
            driver.FindElement(By.Id("sellerText")).Click();
            driver.FindElement(By.Id("sellerText")).Clear();
            driver.FindElement(By.Id("sellerText")).SendKeys("JDP");
            driver.FindElement(By.Id("addressText")).Click();
            driver.FindElement(By.Id("addressText")).Clear();
            driver.FindElement(By.Id("addressText")).SendKeys("23 selly dr");
            driver.FindElement(By.Id("cityText")).Click();
            driver.FindElement(By.Id("cityText")).Clear();
            driver.FindElement(By.Id("cityText")).SendKeys("Kitchener");
            driver.FindElement(By.Id("phnoText")).Click();
            driver.FindElement(By.Id("phnoText")).Clear();
            driver.FindElement(By.Id("phnoText")).SendKeys("201-233-34rr");
            driver.FindElement(By.Id("emailText")).Click();
            driver.FindElement(By.Id("emailText")).Clear();
            driver.FindElement(By.Id("emailText")).SendKeys("service@jdp.com");
            driver.FindElement(By.Id("makeText")).Click();
            driver.FindElement(By.Id("makeText")).Clear();
            driver.FindElement(By.Id("makeText")).SendKeys("Honda");
            driver.FindElement(By.Id("modelText")).Click();
            driver.FindElement(By.Id("modelText")).Clear();
            driver.FindElement(By.Id("modelText")).SendKeys("Civic");
            driver.FindElement(By.Id("yearText")).Click();
            driver.FindElement(By.Id("yearText")).Clear();
            driver.FindElement(By.Id("yearText")).SendKeys("2014");
            driver.FindElement(By.Id("submitButton")).Click();

            waitForElementToFind.Until(r => r.FindElement(By.Id("errorphoneNumber")));
            Assert.AreEqual("Please enter phone number. Check the 'info' to see suported format", driver.FindElement(By.Id("errorphoneNumber")).Text);

            waitForElementToFind.Until(r => r.FindElement(By.Id("phnoText")));
            driver.FindElement(By.Id("phnoText")).Clear();
            driver.FindElement(By.Id("phnoText")).SendKeys("201-233-abcd");

            waitForElementToFind.Until(r => r.FindElement(By.Id("submitButton")));
            driver.FindElement(By.Id("submitButton")).Click();

            waitForElementToFind.Until(r => r.FindElement(By.Id("errorphoneNumber")));
            Assert.AreEqual("Please enter phone number. Check the 'info' to see suported format", driver.FindElement(By.Id("errorphoneNumber")).Text);
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
