using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7.Models;
using Lab7.Pages;
using Lab7.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab7.Pages
{
    class StationAndTrainInfoPage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "station")]
        private IWebElement EnterStation { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Search')]")]
        private IWebElement searchButton { get; set; }

        public StationAndTrainInfoPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public StationAndTrainInfoPage InputStationAndSearch(Station station)
        {
            EnterStation.SendKeys(station.StationName);
            searchButton.Click();
            return this;
        }
    }
}
