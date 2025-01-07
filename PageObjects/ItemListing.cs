using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace UnitTestProject1.PageObjects
{
    public class ItemListing
    {
        public IWebDriver driver;
        public By getBookTitle;
        public By addToCartBtn;
        public ItemListing(IWebDriver _driver)
        {
            driver = _driver;
            getBookTitle = By.CssSelector(".x-item-title__mainTitle span");     // Book Title
            addToCartBtn = By.CssSelector("#atcBtn_btn_1 .ux-call-to-action__text");     // Add To Cart Button
        }
    }
}
