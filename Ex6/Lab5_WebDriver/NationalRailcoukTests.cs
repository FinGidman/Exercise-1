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
        WebDriverWait wait;
        AdditionalCriterias additionalCriterias;

        [TestInitialize]
        public void Setup()
        {
            Browser = new ChromeDriver();
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl("http://nationalrail.co.uk");
        }

        [TestMethod]
        public void BuyingTicketWithoutSpecifyingInforamtionAboutArriveAndDepartue()
        {
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            FromToStations fromToStations = new FromToStations(Browser).InputStations("Manchester", "London Blackfriars");
            ConfirmSelectionCriteria confirmSelectionCriteria = new ConfirmSelectionCriteria(Browser).ClickSearchButton();

            Assert.IsNotNull(Browser.FindElement(By.XPath("//a[contains(text(),'Anytime')]")));
        }

        [TestMethod]
        public void FirstClassTickets()
        {
            wait = new WebDriverWait(Browser, TimeSpan.FromSeconds(5));
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            FromToStations fromToStations = new FromToStations(Browser).InputStations("Manchester", "London Blackfriars");

            additionalCriterias = new AdditionalCriterias(Browser).OpenAdditionalCriteriasForm();
            additionalCriterias = new AdditionalCriterias(Browser).AdditionalCriteriasChoise();
            wait.Until(condition: ExpectedConditions.ElementToBeClickable(By.Id("opPasgrRlcrd")));
            additionalCriterias = new AdditionalCriterias(Browser).CloseAdditionalCriteriasForm();
           
            wait.Until(condition: ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Go')]")));
            ConfirmSelectionCriteria confirmSelectionCriteria = new ConfirmSelectionCriteria(Browser).ClickSearchButton();

            Assert.IsNotNull(Browser.FindElement(By.XPath("//a[contains(text(),'First Class Anytime')]")));
        }

        [TestCleanup]
        public void Clean()
        {
            Browser.Quit();
        }
    }
}
