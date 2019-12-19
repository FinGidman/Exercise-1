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
        WebDriverWait wait;
        public override WorkWithTime WaitElementXPath(IWebDriver driver, int time, string xpath)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(condition: ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            return this;
        }

        WorkWithTime workWithTime;
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Station & Train info')]")]
        private IWebElement StationAndtrainInfoPagelink { get; set; }

        [FindsBy(How = How.ClassName, Using = "clear op-recent-journey-link op-060-tracked")]
        private IWebElement RecentJourneys { get; set; }

        //видимые поля
        [FindsBy(How = How.Id, Using = "txtFrom")] //станция отбытия
        private IWebElement DepartureStation { get; set; }

        [FindsBy(How = How.Id, Using = "txtTo")] //станция прибытия
        private IWebElement ArrivalStation { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Share ')]")]
        private IWebElement ShareCMlist { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Facebook')]")]
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

        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'2')]")] //взрослые
        private IWebElement adultsCount { get; set; }

        [FindsBy(How = How.Id, Using = "sltHours")] //время
        private IWebElement Hours { get; set; }

        //подтверждение поиска
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Go')]")] //подтвержжение поиска
        private IWebElement searchButton { get; set; }

        //Cookies
        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'Accept All Cookies')]")] //принять cookies
        private IWebElement AcceptCookiesButton { get; set; }

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
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
            searchButton.Click();
            return this;
        }

        public MainPage AcceptCookies(IWebDriver driver)
        {
            WaitElementXPath(driver, 60, "//a[contains(@title,'Accept All Cookies')]");
            AcceptCookiesButton.Click();
            return this;
        }

        public MainPage OpenCloseAdditionalCriterias(IWebDriver driver)
        {
            WaitElementXPath(driver, 10, "//span[contains(text(),'Go')]");
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

        public MainPage OpenListAdults()
        {
            Adults.Click();
            return this;
        }

        public MainPage GetCount()
        {
            adultsCount.Click();
            return this;
        }

        public MainPage GetRecentTrain()
        {
            RecentJourneys.Click();
            return this;
        }

        public MainPage GetHours()
        {
            Hours.Click();
            return this;
        }

        public MainPage OpenSharelist()
        {
            ShareCMlist.Click();
            return this;
        }

        public MainPage ClickFacebookBtn()
        {
            FacebookBtn.Click();
            return this;
        }
    }
}
