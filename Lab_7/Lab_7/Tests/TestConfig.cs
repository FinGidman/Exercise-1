using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lab7.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework.Interfaces;

namespace Lab7.Tests
{
    public class TestConfig
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setter()
        {
            Driver = DriverSingleton.GetDriver();
            Driver.Navigate().GoToUrl("https://www.nationalrail.co.uk/");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }


        [TearDown]
        public void ClearDriver()
        {
            if(TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
            }
            //DriverSingleton.CloseDriver();
        }
    }
}
