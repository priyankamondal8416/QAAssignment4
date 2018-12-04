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
    /// Class: ValidFormTestCase
    /// Summary: Test case to validate the form with correct data
    /// </summary>

    [TestFixture]
    public class ValidFormTestCase
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
        public void ValidForm_InputValidSellerInformation_ExpectedInformationWithGeneratedLink_Test()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.LinkText("Add Seller")).Click();
            driver.FindElement(By.Id("sellerText")).Click();
            driver.FindElement(By.Id("sellerText")).Clear();
            driver.FindElement(By.Id("sellerText")).SendKeys("Bright Auto");
            driver.FindElement(By.Id("addressText")).Click();
            driver.FindElement(By.Id("addressText")).Clear();
            driver.FindElement(By.Id("addressText")).SendKeys("123 Plaza franklin dr");
            driver.FindElement(By.Id("cityText")).Clear();
            driver.FindElement(By.Id("cityText")).SendKeys("Cambridge");
            driver.FindElement(By.Id("phnoText")).Click();
            driver.FindElement(By.Id("phnoText")).Clear();
            driver.FindElement(By.Id("phnoText")).SendKeys("123-123-1234");
            driver.FindElement(By.Id("emailText")).Click();
            driver.FindElement(By.Id("emailText")).Click();
            driver.FindElement(By.Id("emailText")).Clear();
            driver.FindElement(By.Id("emailText")).SendKeys("brightauto@bright.org");
            driver.FindElement(By.Id("makeText")).Click();
            driver.FindElement(By.Id("makeText")).Clear();
            driver.FindElement(By.Id("makeText")).SendKeys("Ford");
            driver.FindElement(By.Id("modelText")).Click();
            driver.FindElement(By.Id("modelText")).Clear();
            driver.FindElement(By.Id("modelText")).SendKeys("Fusion");
            driver.FindElement(By.Id("yearText")).Click();
            driver.FindElement(By.Id("yearText")).Clear();
            driver.FindElement(By.Id("yearText")).SendKeys("2016");
            driver.FindElement(By.Id("submitButton")).Click();           
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
