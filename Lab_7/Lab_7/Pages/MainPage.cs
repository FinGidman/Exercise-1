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
    class MainPage : WorkWithTime
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'sign in')]")]
        private IWebElement SignInLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Station & Train info')]")]
        private IWebElement StationAndtrainInfoPagelink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@data-oprow,'1')]")]
        private IWebElement RecentJourneys { get; set; }

        //видимые поля
        [FindsBy(How = How.Id, Using = "txtFrom")] //станция отбытия
        private IWebElement DepartureStation { get; set; }

        [FindsBy(How = How.Id, Using = "txtTo")] //станция прибытия
        private IWebElement ArrivalStation { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Share ')]")]
        private IWebElement ShareCMlist { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'Share on Facebook (opens in a new window)')]")]
        private IWebElement FacebookBtn { get; set; }

        //дополнительные критерии
        [FindsBy(How = How.Id, Using = "opPasgrRlcrd")] //список доп. критерий отбора
        private IWebElement additionalcriteriaslist { get; set; }

        [FindsBy(How = How.Id, Using = "standard-class")] //стандартный класс
        private IWebElement standardClassCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "ret-ch")] //обратный путь
        private IWebElement returnCheckbox { get; set; }

        [FindsBy(How = How.Id, Using ="adults")] //взрослые
        private IWebElement Adults { get; set; }

        [FindsBy(How = How.Id, Using = "sltHours")] //время
        private IWebElement Hours { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Go')]")] //подтвержжение поиск
        private IWebElement searchButton { get; set; }

        //Cookies
        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'Accept All Cookies')]")] //принять cookies
        private IWebElement AcceptCookiesButton { get; set; }

        [FindsBy(How = How.Id, Using = "txtDate")] //время
        private IWebElement DateDeparture { get; set; }

        [FindsBy(How = How.XPath, Using ="//span[contains(text(),'Home')]")]
        private IWebElement Home { get; set; }

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public MainPage SignIn()
        {
            SignInLink.Click();
            return this;
        }

        //инфо о станции надо перейти на стр
        public StationAndTrainInfoPage GoToStationAndTrainInfoPage()
        {
            StationAndtrainInfoPagelink.Click();
            return new StationAndTrainInfoPage(driver);
        }

        public MainPage InputStationsAndSeacrh(Route route)
        {
            DepartureStation.SendKeys(route.DepartureCity);
            ArrivalStation.SendKeys(route.ArrivalCity); 
            return this;
        }

        public MainPage Search()
        {
            WaitElementXPath(60, "//span[contains(text(),'Go')]");
            searchButton.Click();
            return this;
        }

        public MainPage AcceptCookies()
        {
            WaitElementByXpathCookies(60, "//a[contains(@title,'Accept All Cookies')]");
            AcceptCookiesButton.Click();
            return this;
        }

        public MainPage OpenCloseAdditionalCriterias()
        {
            WaitElementXPath(10, "//span[contains(text(),'Go')]");
            additionalcriteriaslist.Click();
            return this;
        }

        public MainPage SwitchStandardClass()
        {
            standardClassCheckbox.Click();
            return this;
        }

        public MainPage SwitchReturn()
        {
            
            returnCheckbox.Click();
            return this;
        }

        public MainPage OpenListAdultsAndSelect(string value)
        {
            Adults.Click();
            var element = new SelectElement(Adults);
            element.SelectByValue(value);
            return this;
        }

        public MainPage GetRecentTrain()
        {
            RecentJourneys.Click();
            return this;
        }

        public MainPage SetHours(string time)
        {
            Hours.Click();
            var elements = new SelectElement(Hours);
            elements.SelectByValue(time);
            return this;
        }

        public MainPage OpenSharelist()
        {
            ShareCMlist.Click();
            return this;
        }

        public MainPage ClickFacebookBtn()
        {
            WaitElementXPath(10, "//a[contains(@title,'Share on Facebook (opens in a new window)')]");
            FacebookBtn.Click();
            //FacebookBtn.Click();
            return this;
        }

        public MainPage SetDateDeparture()
        {
            DateDeparture.Clear();
            DateDeparture.SendKeys("27/12/2019");
            return this;
        }

        public MainPage BackToHome()
        {
            Home.Click();
            return this;
        }
    }
}
