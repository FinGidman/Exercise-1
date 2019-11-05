using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Lab5_WebDriver
{
    [TestClass]
    public class NationalRailcoukTests
    {
        IWebDriver Browser;

        //[TestMethod]
        public void BuyingTicketWithoutSpecifyingInforamtionAboutArriveAndDepartue()
        {
            //Тест 1. Заказ билета из Манчестера в Лондон
            Browser = new ChromeDriver();
            Browser.Navigate().GoToUrl("http://nationalrail.co.uk");
            Thread.Sleep(5000);
            IWebElement departuePlace = Browser.FindElement(By.Id("txtFrom"));
            departuePlace.SendKeys("Manchester");

            IWebElement arivePlace = Browser.FindElement(By.Id("txtTo"));
            arivePlace.SendKeys("London");

            //Browser.FindElement(By.TagName("button")).Click();
            //Browser.FindElement(By.Id("go")).Click();
            //Browser.FindElement(By.XPath("//*button[@class='b-y lrg rgt not-IE6' and id='go']")).Click();

            Thread.Sleep(5000);
            Browser.FindElement(By.XPath("/html/body/div[5]/form/div/div[1]/div[1]/button")).Click();
            //Browser.FindElement(By.XPath("/html/body/div[5]/form/div/div[1]/div[1]/button/span")).Click();

            Browser.Quit();
        }

        [TestMethod]
        public void FirstClassTickets()
        {
            //Тест 2. Заказ билета первого класса
            Browser = new ChromeDriver();
            Browser.Navigate().GoToUrl("http://nationalrail.co.uk");
            Thread.Sleep(5000);
            IWebElement departuePlace = Browser.FindElement(By.Id("txtFrom"));
            departuePlace.SendKeys("Manchester");

            IWebElement arivePlace = Browser.FindElement(By.Id("txtTo"));
            arivePlace.SendKeys("London");

            Browser.FindElement(By.Id("opPasgrRlcrd")).Click();
            Browser.FindElement(By.Id("standard-class")).Click();
            Browser.FindElement(By.Id("opPasgrRlcrd")).Click();

            Thread.Sleep(2000);
            //Browser.FindElement(By.XPath("/html/body/div[5]/form/div/div[1]/div[1]/button")).Click();
            Browser.FindElement(By.Id("go")).Click();
            //Thread.Sleep(5000);
            //action = new Actions(Browser);
            //action.MoveToElement(Browser.FindElement(By.XPath("/html/body/div[5]/form/div/div[1]/div[1]/button")));

            Browser.Quit();
        }
    }
}
