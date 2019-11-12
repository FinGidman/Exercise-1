using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using Lab5_WebDriver.Actions;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Lab5_WebDriver
{
    [TestClass]
    public class NationalRailcoukTests
    {
        IWebDriver Browser;

        [TestMethod]
        public void BuyingTicketWithoutSpecifyingInforamtionAboutArriveAndDepartue()
        {
            Browser = new ChromeDriver();
            Browser.Navigate().GoToUrl("http://nationalrail.co.uk");
            //Browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            FromToStations fromToStations = new FromToStations(Browser).InputStations("Manchester", "London");

            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ConfirmSelectionCriteria confirmSelectionCriteria = new ConfirmSelectionCriteria(Browser).ClickSearchButton();
            Browser.Quit();
        }

        [TestMethod]
        public void FirstClassTickets()
        {
            Browser = new ChromeDriver();
            Browser.Navigate().GoToUrl("http://nationalrail.co.uk");
            //Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            FromToStations fromToStations = new FromToStations(Browser).InputStations("Manchester", "London");

            AdditionalCriterias additionalCriterias = new AdditionalCriterias(Browser).AdditionalCriteriasChoise();

            Thread.Sleep(3000);
            
            ConfirmSelectionCriteria confirmSelectionCriteria = new ConfirmSelectionCriteria(Browser).ClickSearchButton();
            Browser.Quit();
        }
    }
}
