using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace UnitTestProject1.PageObjects
{
    public class HomePage
    {
        // Create Locators of Home Page
        public IWebDriver driver;

        public By searchBox;
        public By title;
        public By searchBtn;
        public By booksList;
        public By signInLink;

        public HomePage(IWebDriver _driver)
        {
            driver = _driver;
            title = By.TagName("title"); // Electronics, Cars, Fashion, Collectibles &amp; More | eBay
            searchBox = By.CssSelector("input[type=text]");
            searchBtn = By.Id("gh-btn");
            booksList = By.CssSelector(".srp-results .s-item__info a .s-item__title");
            signInLink = By.LinkText("Sign In");

        }
    }
}
