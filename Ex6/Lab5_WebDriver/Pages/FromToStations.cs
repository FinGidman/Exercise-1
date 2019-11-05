using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_WebDriver.Pages
{
    class FromToStations
    {
        [FindsBy(How = How.Id, Using = "txtFrom")]
        private IWebElement DepartureStation { get; set; }

        [FindsBy(How = How.Id, Using = "txtTo")]
        private IWebElement ArrivalStation { get; set; }

        public FromToStations(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public FromToStations InputStations(string departureStation, string arrivalStation)
        {
            DepartureStation.SendKeys(departureStation);
            ArrivalStation.SendKeys(arrivalStation);
            return this;
        }
    }
}
