using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;

namespace UnitTestProject1.Common
{
    public class CommonFunctions
    {
        public IWebDriver driver;
        public IWebElement element;
        public WebDriverWait wait;

        public CommonFunctions(IWebDriver _driver)
        {
            driver = _driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void QuitDriver()
        { 
            driver.Quit();
        }

        public void OpenUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }
        public void EnterInput(By inputField, string inputText)
        {
            driver.FindElement(inputField).SendKeys(inputText);
        }
        public void ClickElement(By element)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
                driver.FindElement(element).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ClickLink(IWebElement element)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
                element.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void WaitForElementToBeVisible(By element, IWebDriver driver)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(element));
            }
            catch (ElementNotVisibleException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
