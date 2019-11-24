using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5_WebDriver.Actions
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
            standardClassCheckbox.Click();
            return this;
        }

        public AdditionalCriterias OpenAdditionalCriteriasForm()
        {
            additionalcriteriaslist.Click();

            return this;
        }

        public AdditionalCriterias CloseAdditionalCriteriasForm()
        {
            additionalcriteriaslist.Click();
            return this;
        }
    }
}
