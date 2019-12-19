using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lab7.Driver;
using Lab7.Pages;
using Lab7.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Lab7.Tests
{
    class NationalRailCoUKtests : TestConfig
    {
        //1 поиск билета по городам
        MainPage mainPage;
        [Test]
        [Category("SearchTest")]
        public void BuyingTicketWithoutSpecifyingInforamtionAboutArriveAndDepartue()
        {
            mainPage = new MainPage(Driver)
                .AcceptCookies(Driver)
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .Search();

            Assert.IsNotNull(Driver.FindElement(By.XPath("//a[contains(text(),'Anytime')]")));
        }

        //2 поиск билета первого класса
        [Test]
        [Category("SearchTest")]
        public void FirstCLassTickets()
        {
            mainPage = new MainPage(Driver)
                .AcceptCookies(Driver)
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .OpenCloseAdditionalCriterias(Driver)
                .SwitchStandardClass()
                .OpenCloseAdditionalCriterias(Driver)
                .Search();

            Assert.IsNotNull(Driver.FindElement(By.XPath("//a[contains(text(),'First Class Anytime')]")));
        }

        //3 другие станции
        [Test]
        [Category("SearchTest")]
        public void OrderTicketsByStationName()
        {
            mainPage = new MainPage(Driver)
                .AcceptCookies(Driver)
                .InputStationsAndSeacrh(RouteCreator.ArrivalBystationName())
                .Search();

            Assert.IsNotNull(Driver.FindElement(By.XPath("//a[contains(text(),'Anytime')]")));
        }

        //4 поиск по почтовому коду
        [Test]
        [Category("SearchTest")]
        public void OrderTicketsByPostCode()
        {
            mainPage = new MainPage(Driver)
                .AcceptCookies(Driver)
                .InputStationsAndSeacrh(RouteCreator.ArrivalByPostcode())
                .Search();

            Assert.IsNotNull(Driver.FindElement(By.XPath("//a[contains(text(),'Anytime')]")));
        }

        //5 Заказ билета с обратным путем
        [Test]
        [Category("SearchTest")]
        public void OrderTicketsWithReturning()
        {
            mainPage = new MainPage(Driver)
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .SwitchReturn()
                .Search();

            Assert.IsNotNull(Driver.FindElement(By.XPath("//a[contains(text(),'Anytime')]")));
        }

        //6 Получение инф о станции
        [Test]
        [Category("Info")]
        public void GetInfoAboutStation()
        {
            StationAndTrainInfoPage stationAndTrainInfoPage = new MainPage(Driver)
                .AcceptCookies(Driver)
                .GoToStationAndTrainInfoPage()
                .InputStationAndSearch(RouteCreator.InputStationName());

            Assert.IsNotNull(Driver.FindElement(By.XPath("//abbr[contains(text(),'PAD')]")));
        }

        //7 заказ билета для 2 человек 
        [Test]
        [Category("SearchTest")]
        public void TicketForManyPeople()
        {
            mainPage = new MainPage(Driver)
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .OpenCloseAdditionalCriterias(Driver)
                .OpenListAdults()
                .GetCount()
                .OpenCloseAdditionalCriterias(Driver)
                .Search();

            Assert.IsNotNull(Driver.FindElements(By.XPath("//strong[contains(text(),'2')]")));
        }

        //7 Заказ билета с выбором времени отбытия
        [Test]
        [Category("SearchTest")]
        public void SettingHoursOfDeparture()
        {
            mainPage = new MainPage(Driver)
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .OpenCloseAdditionalCriterias(Driver)
                .GetHours()
                .GetCount()
                .Search();

            Assert.IsNotNull(Driver.FindElements(By.XPath("//strong[contains(text(),'2')]")));
        }

        //9 Использование кнопки нравиться
        [Test]
        [Category("ButtonChecking")]
        public void ShareButton()
        {
            mainPage = new MainPage(Driver)
                .OpenSharelist()
                .ClickFacebookBtn();

            Assert.AreEqual("https://www.nationalrail.co.uk/", Driver.Url);
        }

        //10 заказ из вкладки recent
        [Test]
        [Category("SearchTest")]
        public void TakeJourneyFromRecent()
        {
            mainPage = new MainPage(Driver)
                .GetRecentTrain();

            Assert.AreEqual("https://www.nationalrail.co.uk/", Driver.Url);
        }
    }
}
