using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab7.Driver
{
    class DriverSingleton
    {
        static IWebDriver driver;
        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver();
                        break;
                    default:
                        //Map prefs = new HashMap();
                        //prefs.put("profile.default_content_settings.cookies", 2);
                        //ChromeOptions options = new ChromeOptions();
                        //options.setExperimentalOptions("prefs", prefs);
                        //driver = new ChromeDriver(options);

                        //ChromeOptions options = new ChromeOptions();
                        //options.AddAdditionalCapability("chrome", 2);

                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        //driver.Manage().Cookies.AddCookie(new Cookie("2", "profile.default_content_settings.cookies"));
                        
                        break;
                }
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}
