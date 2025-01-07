using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace UnitTestProject1.PageObjects
{
    public class SignInPage
    {
        public IWebDriver driver;
        public By humanCheckBox;
        public By addToCartBtn;
        public SignInPage(IWebDriver _driver)
        {
            driver = _driver;
            humanCheckBox = By.CssSelector("#anchor-tc");     // Click on I am human checkbox
        }
    }
}
