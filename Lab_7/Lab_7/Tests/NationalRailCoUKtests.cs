﻿using System;
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

        MainPage mainPage;
        WebTable webTable;

        [Test]
        [Description("Find tickets without additional properties")]
        [Category("SearchTest")]
        public void TicketsWithoutAdditionalProperties()
        {
            mainPage = new MainPage(Driver)               
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .SetDateDeparture()
                .Search();

            webTable = new WebTable();
            Assert.IsTrue(webTable.CheckElementsFromDepartureAndArrival("//span[contains(@class,'opFromSection')]",
                "London Blackfriars  ",
                "Manchester Piccadilly  "));
        }

        [Test]
        [Description("First class tickets without additional properties")]
        [Category("SearchTest")]
        public void FirstCLassTickets() //passed
        {
            mainPage = new MainPage(Driver)
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .OpenCloseAdditionalCriterias()
                .SwitchStandardClass()
                .OpenCloseAdditionalCriterias()
                .Search();

            webTable = new WebTable();
            Assert.IsTrue(webTable.CheckTravelClass("//a[contains(@class,'op-listened')]", " First Class Anytime"));
        }

        [Test]
        [Category("Find tickets to another stations without additional properties")]
        [Category("SearchTest")]
        public void TicketsToAnotherStation()
        {
            mainPage = new MainPage(Driver)
                .InputStationsAndSeacrh(RouteCreator.ArrivalBystationName())
                .Search();

            webTable = new WebTable();
            Assert.IsTrue(webTable.CheckElementsFromDepartureAndArrival("//span[contains(@class,'opFromSection')]",
                "Manchester Piccadilly  ",
                "Birmingham Moor Street  "));
        }

        [Test]
        [Description("Find tickets by postcode without additional properties")]
        [Category("SearchTest")]
        public void TicketsByPostCode()//passed but need assert
        {
            mainPage = new MainPage(Driver)
                .InputStationsAndSeacrh(RouteCreator.ArrivalByPostcode())
                .Search();

            webTable = new WebTable();
            Assert.IsTrue(webTable.CheckElementsFromDepartureAndArrival("//span[contains(@class,'opFromSection')]",
                "London Blackfriars  ",
                "Manchester Piccadilly  "));
        }

        //5 Заказ билета с обратным путем
        [Test]
        [Description("Find two way tickets")]
        [Category("SearchTest")]
        public void TwoWayTickets()
        {
            mainPage = new MainPage(Driver)
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .OpenCloseAdditionalCriterias()
                .SwitchReturn()
                .Search();

            webTable = new WebTable();
            Assert.IsTrue(webTable.CheckElementsFromDepartureAndArrival("//span[contains(@class,'opFromSection')]",
                            "London Blackfriars  ",
                            "Manchester Piccadilly  "));
        }

        [Test]
        [Category("Get information about station")]
        [Category("Info")]
        public void GetInfoAboutStation() //passed, sometimes cannot find element
        {
            StationAndTrainInfoPage stationAndTrainInfoPage = new MainPage(Driver)
                .GoToStationAndTrainInfoPage()
                .InputStationAndSearch(RouteCreator.InputStationName());

            Assert.AreEqual("https://www.nationalrail.co.uk/stations/PAD/details.html", Driver.Url);
        }

        [Test]
        [Description("Tickets for few adult people")]
        [Category("SearchTest")]
        public void TicketForFewAdultPeople() //passed
        {
            mainPage = new MainPage(Driver)
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .OpenCloseAdditionalCriterias()
                .OpenListAdultsAndSelect("2")
                .OpenCloseAdditionalCriterias()
                .Search();

            Assert.IsNotNull(Driver.FindElements(By.XPath("//strong[contains(text(),'2')]")));
        }

        [Test]
        [Description("Tickets with time departuew")]
        [Category("SearchTest")]
        public void TicketsByChoosingDepartureTime()// Assert
        {
            mainPage = new MainPage(Driver)
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .OpenCloseAdditionalCriterias()
                .SetHours("21")
                .OpenCloseAdditionalCriterias()
                .Search();

            webTable = new WebTable();
            Assert.IsTrue(webTable.CheckHours("//*[contains(@class,'opTDStackOne')]//div[contains(@class,'opDepartTime')]","21"));
        }

        [Test]
        [Description("Using share button")]
        [Category("ButtonChecking")]
        public void ShareButton() //passed
        {
            mainPage = new MainPage(Driver)
                .OpenSharelist()
                .ClickFacebookBtn();

            //Assert.AreEqual("https://www.nationalrail.co.uk/", Driver.Url);
           Assert.AreEqual(Driver.WindowHandles.Count(), 2);
        }

        [Test]
        [Description("call recent journeys")]
        [Category("SearchTest")]
        public void TakeJourneyFromRecent() //not
        {
            mainPage = new MainPage(Driver)
                .InputStationsAndSeacrh(RouteCreator.WithAllProperties())
                .Search()
                .BackToHome()
                .GetRecentTrain();

            webTable = new WebTable();
            Assert.IsTrue(webTable.CheckElementsFromDepartureAndArrival("//span[contains(@class,'opFromSection')]",
                            "London Blackfriars  ",
                            "Manchester Piccadilly  "));
        }
    }
}
