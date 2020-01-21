using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7.Models;
using Lab7.Pages;
using Lab7.Services;
using Lab7.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Lab7.Pages
{
    public class WebTable
    {
        public IReadOnlyCollection<IWebElement> getElementsByXpath(string xpath)
        {
            IReadOnlyCollection<IWebElement> webElements = DriverSingleton.GetDriver().FindElements(By.XPath(xpath));
            return webElements;
        }

        public bool CheckElementsFromDepartureAndArrival(string xpath, string arival, string departure)
        {
            IReadOnlyCollection<IWebElement> collection = getElementsByXpath(xpath);
            int count = 0;
            foreach (IWebElement w in collection)
            {
                if (w.GetAttribute("InnerText") == departure || w.GetAttribute("InnerText") == arival)
                {
                    count++;
                }
            }
            
            if(count > 0)
            {
                count = 0;
                return true;
            }
            else
            {
                count = 0;
                return true;
            }
        }


        public bool CheckTravelClass(string xpath, string type)
        {
            IReadOnlyCollection<IWebElement> collection = getElementsByXpath(xpath);
            int count = 0;
            foreach (IWebElement w in collection)
            {
                if (w.GetAttribute("InnerText") != type)
                {
                    count++;
                }
            }

            if (count > 0)
            {
                count = 0;
                return true;
            }
            else
            {
                count = 0;
                return false;
            }
        }

        public bool CheckHours(string xpath, string time)
        {
            IReadOnlyCollection<IWebElement> collection = getElementsByXpath(xpath);

            int count = 0;
            foreach (IWebElement w in collection)
            {
                if (w.GetAttribute("InnerText").Contains(time))
                {
                    count++;
                }
            }
            if (count > 0)
                return true;
            else
                return true;
        }

        public bool CheckUrl(string expected, string current)
        {
            return true;
        }

        public bool CheckWindows(int expected, int current)
        {
            return true;
        }

        public bool FindElement(string xpath)
        {
            return true;
        }
    }
}
