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
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab7.Tests
{
    class NationalRailCoUKtests : TestConfig
    {
        //1 поиск билета по городам
        MainPage mainPage;
        WebTable webTable;

        [Test]
        [Description("Find tickets without additional properties")]
        [Category("SearchTest")]
        public void TicketsWithoutAdditionalProperties()
        {
            mainPage = new MainPage(Driver)
                .AcceptCookies()
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .SetDateDeparture()
                .Search();

            webTable = new WebTable();
            Assert.IsTrue(webTable.CheckElementsFromDepartureAndArrival("//span[contains(@class,'opFromSection')]",
                TestDataReader.GetData("ManchesterPIC").Value,
                TestDataReader.GetData("LondonBFR").Value));
        }

        //2 поиск билета первого класса 
        [Test]
        [Description("First class tickets without additional properties")]
        [Category("SearchTest")]
        public void FirstCLassTickets()
        {
            mainPage = new MainPage(Driver)
                .AcceptCookies()
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .OpenCloseAdditionalCriterias()
                .SwitchStandardClass()
                .OpenCloseAdditionalCriterias()
                .Search();

            webTable = new WebTable();
            Assert.IsTrue(webTable.CheckTravelClass("//a[contains(@class,'op-listened')]", "First class"));
        }

        //3 другие станции
        [Test]
        [Category("Find tickets to another stations without additional properties")]
        [Category("SearchTest")]
        public void TicketsToAnotherStation()
        {
            mainPage = new MainPage(Driver)
                .AcceptCookies()
                .InputStationsAndSeacrh(RouteCreator.ArrivalBystationName())
                .Search();

            webTable = new WebTable();
            Assert.IsTrue(webTable.CheckElementsFromDepartureAndArrival("//span[contains(@class,'opFromSection')]",
                TestDataReader.GetData("ManchesterPIC").Value,
                TestDataReader.GetData("BirminghamMS").Value));
        }

        //4 поиск по почтовому коду
        [Test]
        [Description("Find tickets by postcode without additional properties")]
        [Category("SearchTest")]
        public void TicketsByPostCode()
        {
            mainPage = new MainPage(Driver)
                .AcceptCookies()
                .InputStationsAndSeacrh(RouteCreator.ArrivalByPostcode())
                .Search();

            webTable = new WebTable();
            Assert.IsTrue(webTable.CheckElementsFromDepartureAndArrival("//span[contains(@class,'opFromSection')]",
                TestDataReader.GetData("ManchesterPIC").Value,
                "Manchester Piccadilly"));
        }

        //5 Заказ билета с обратным путем
        [Test]
        [Description("Find two way tickets")]
        [Category("SearchTest")]
        public void TwoWayTickets()
        {
            mainPage = new MainPage(Driver)
                .AcceptCookies()
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .SwitchReturn()
                .Search();

            webTable = new WebTable();
            Assert.IsTrue(webTable.CheckElementsFromDepartureAndArrival("//span[contains(@class,'opFromSection')]",
                            TestDataReader.GetData("ManchesterPIC").Value,
                            TestDataReader.GetData("LondonBFR").Value));
        }

        //6 Получение инф о станции 
        //Решить ошибку
        [Test]
        [Category("Get information about station")]
        [Category("Info")]
        public void GetInfoAboutStation()
        {
            StationAndTrainInfoPage stationAndTrainInfoPage = new MainPage(Driver)
                .AcceptCookies()
                .GoToStationAndTrainInfoPage()
                .InputStationAndSearch(RouteCreator.InputStationName());

            Assert.IsNotNull(Driver.FindElement(By.XPath("//abbr[contains(text(),'PAD')]")));
        }

        //7 заказ билета для 2 взрослых человек NOT DONE
        [Test]
        [Description("Tickets for few adult people")]
        [Category("SearchTest")]
        public void TicketForFewAdultPeople()
        {
            mainPage = new MainPage(Driver)
                .AcceptCookies()
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .OpenCloseAdditionalCriterias()
                .OpenListAdultsAndSelect("2")
                .OpenCloseAdditionalCriterias()
                .Search();

            Assert.IsNotNull(Driver.FindElements(By.XPath("//strong[contains(text(),'2')]")));
        }

        //8 Заказ билета с выбором времени отбытия NOT DONE
        //SELECT=DONE ASSERT
        [Test]
        [Description("Tickets with time departuew")]
        [Category("SearchTest")]
        public void TicketsByChoosingDepartureTime()
        {
            mainPage = new MainPage(Driver)
                .AcceptCookies()
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .OpenCloseAdditionalCriterias()
                .SetHours("12")
                .Search();

            webTable = new WebTable();
            Assert.IsTrue(webTable.CheckHours("//*[contains(@class,'opTDStackOne')]//div[contains(@class,'opDepartTime')]","12"));
        }

        //9 Использование кнопки нравиться
        //DONE
        [Test]
        [Description("Using share button")]
        [Category("ButtonChecking")]
        public void ShareButton()
        {
            mainPage = new MainPage(Driver)
                .AcceptCookies()
                .OpenSharelist()
                .ClickFacebookBtn();

            Assert.AreEqual("https://www.nationalrail.co.uk/", Driver.Url);
        }

        //10 заказ из вкладки recent
        //DONE
        [Test]
        [Description("call recent journeys")]
        [Category("SearchTest")]
        public void TakeJourneyFromRecent()
        {
            mainPage = new MainPage(Driver)
                .AcceptCookies()
                .GetRecentTrain();

            Assert.AreEqual("https://www.nationalrail.co.uk/", Driver.Url);
        }
    }
}
