using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5_WebDriver.Pages
{
    class AdditionalCriterias
    {
        [FindsBy(How = How.Id, Using = "opPasgrRlcrd")]
        private IWebElement additionalcriteriaslist { get; set; }

        [FindsBy(How = How.Id, Using = "standard-class")]
        private IWebElement standardClassCheckbox { get; set; }

        public AdditionalCriterias(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public AdditionalCriterias AdditionalCriteriasChoise()
        {
            additionalcriteriaslist.Click();
            standardClassCheckbox.Click();
            Thread.Sleep(3000);
            additionalcriteriaslist.Click();
            return this;
        }
    }
}
