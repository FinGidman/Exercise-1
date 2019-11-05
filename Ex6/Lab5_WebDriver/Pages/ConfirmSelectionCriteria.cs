using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_WebDriver.Pages
{
    class ConfirmSelectionCriteria
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/form/div/div[1]/div[1]/button")]
        private IWebElement searchButton { get; set; }

        public ConfirmSelectionCriteria(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public ConfirmSelectionCriteria ClickSearchButton()
        {
            searchButton.Click();
            return this;
        }
    }
}
