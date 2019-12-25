using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7.Models;
using Lab7.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Lab7.Driver;
using Lab7.Models;
using Lab7.Services;
using Lab7.Pages;

namespace Lab7.Pages
{
    abstract class WorkWithTime
    {
        
        WebDriverWait wait;
        public WorkWithTime WaitElementXPath(int time, string xpath)
        {
            wait = new WebDriverWait(DriverSingleton.GetDriver(), TimeSpan.FromSeconds(time));
            wait.Until(condition: ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            return this;
        }

        public WorkWithTime WaitElementId(int time, string id)
        {
            wait = new WebDriverWait(DriverSingleton.GetDriver(), TimeSpan.FromSeconds(time));
            wait.Until(condition: ExpectedConditions.ElementToBeClickable(By.Id(id)));
            return this;
        }
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            //wait.Until(condition: ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            ////"//a[contains(@title,'Accept All Cookies')]"
            
        
    }
}
