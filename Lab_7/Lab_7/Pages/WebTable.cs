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

namespace Lab_7.Pages
{
    public class WebTable
    {
        private IWebElement _webTable;

        public WebTable(IWebElement webTable)
        {
            set_webTable(webTable);
        }

        public IWebElement get_webTable()
        {
            return _webTable;
        }

        public void set_webTable(IWebElement _webTable)
        {
            this._webTable = _webTable;
        }


        public IReadOnlyList<IWebElement> getelementsTableFromElemntById (string id)
        {
            IReadOnlyList<IWebElement> tableRows = _webTable.FindElements(By.Id(id));
            return tableRows;
        }

        public IWebElement getElement(string value, IReadOnlyList<IWebElement> webElements)
        {
            //IWebElement element = webElements //webElements.Any(w => w.FindElement(By.XPath($"//option[contains(@value,{value})]")));
            //    int t = webElements.
            //return element;
        }
    }
}
