using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab5_WebDriver.Table
{
    class WebTable
    {
        IWebDriver driver;
        public IReadOnlyCollection<IWebElement> getElementsByXpath(string xpath)
        {
            IReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.XPath(xpath));
            return webElements;
        }

        public bool CheckElementsFromDepartureAndArrival(string xpath, string arival, string departure)
        {
            IReadOnlyCollection<IWebElement> collection = getElementsByXpath(xpath);

            foreach (IWebElement w in collection)
            {
                if (w.GetAttribute("InnerText") != departure || w.GetAttribute("InnerText") != arival)
                {
                    return false;
                }
            }
            return true;
        }


        public bool CheckTravelClass(string xpath, string type)
        {
            IReadOnlyCollection<IWebElement> collection = getElementsByXpath(xpath);

            foreach (IWebElement w in collection)
            {
                if (w.GetAttribute("InnerText") != type)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
