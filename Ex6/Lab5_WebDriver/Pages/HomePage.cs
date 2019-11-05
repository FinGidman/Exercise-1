using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_WebDriver.Pages
{
    class HomePage
    {
        [FindsBy(How = How.ClassName, Using ="first")]
        private IWebElement Home { get; set; }

        public HomePage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public HomePage BackToHomwPage()
        {
            Home.Click();
            return this;
        }
    }
}
