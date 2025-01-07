using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using UnitTestProject1.Common;
using UnitTestProject1.PageObjects;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public IWebDriver driver;
        CommonFunctions objCommonFunctions;
        HomePage objHomePage;
        ItemListing objItemListing;
        public TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestInitialize]
        public void Setup()
        {
            // Initialize ChromeDriver
            driver = new ChromeDriver(TestContext.Properties["ChromeDriver"].ToString());
            objCommonFunctions = new CommonFunctions(driver);
            objHomePage = new HomePage(driver);
            objItemListing = new ItemListing(driver);
        }

        [TestCleanup]
        public void CleanUp()
        {
            // Close the browser
            //driver.Quit();
            objCommonFunctions.QuitDriver();
        }

        [TestMethod]
        public void TestHomePageTitle()
        {
            string appUrl = TestContext.Properties["WebAppUrl"].ToString();
            string searchText = TestContext.Properties["SearchText"].ToString();
            string bookName = "";

            // Start Test Steps
            //objCommonFunctions.LaunchBrowser();     // Launch the browser
            objCommonFunctions.OpenUrl(appUrl);     // Navigate to the web application
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            Assert.AreEqual(TestContext.Properties["HomeTitle"].ToString(), js.ExecuteScript("return document.getElementsByTagName(\"title\")[0].innerText;"));

            //Sign In Here
            //objCommonFunctions.ClickElement(objHomePage.signInLink);     // Click on Sign In Link


            objCommonFunctions.EnterInput(objHomePage.searchBox, searchText);   // Search the text
            objCommonFunctions.ClickElement(objHomePage.searchBtn);     // Click on Submit/Search Button
            
            IList<IWebElement> listOfBooks = driver.FindElements(objHomePage.booksList);
            Assert.IsNotNull(listOfBooks);
            bookName = listOfBooks[0].Text;
            objCommonFunctions.ClickLink(listOfBooks[0]);

            // Get all window handles
            var windowHandles = driver.WindowHandles; // Switch to the new tab i.e the last window handle
            driver.SwitchTo().Window(windowHandles[windowHandles.Count - 1]);

            objCommonFunctions.WaitForElementToBeVisible(objItemListing.getBookTitle, driver);
            Assert.IsTrue(js.ExecuteScript("return document.getElementsByTagName(\"title\")[0].innerText;").ToString().Contains(driver.FindElement(objItemListing.getBookTitle).Text));    //driver.FindElement(objHomePage.title).Text
            objCommonFunctions.ClickElement(objItemListing.addToCartBtn);     // Click on Add to cart Button
            
            // Assert the title of the page
            //Assert.AreEqual("Example Domain", driver.Title);
        }
    }
}
