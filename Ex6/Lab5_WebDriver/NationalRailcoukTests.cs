﻿using System;
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

        [TestInitialize]
        public void Setup()
        {
            Browser = new ChromeDriver();
            Browser.Navigate().GoToUrl("http://nationalrail.co.uk");
        }

        [TestMethod]
        public void BuyingTicketWithoutSpecifyingInforamtionAboutArriveAndDepartue()
        {
            FromToStations fromToStations = new FromToStations(Browser).InputStations("Manchester", "London");

            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ConfirmSelectionCriteria confirmSelectionCriteria = new ConfirmSelectionCriteria(Browser).ClickSearchButton();
        }

        [TestMethod]
        public void FirstClassTickets()
        {
            FromToStations fromToStations = new FromToStations(Browser).InputStations("Manchester", "London");

            AdditionalCriterias additionalCriterias = new AdditionalCriterias(Browser).AdditionalCriteriasChoise();

            Thread.Sleep(3000);
            
            ConfirmSelectionCriteria confirmSelectionCriteria = new ConfirmSelectionCriteria(Browser).ClickSearchButton();
        }

        [TestCleanup]
        public void Clean()
        {
            Browser.Quit();
        }
    }
}
