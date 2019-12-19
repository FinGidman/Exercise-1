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

namespace Lab7.Pages
{
    public abstract class WorkWithTime
    {

        public abstract WorkWithTime WaitElementXPath(IWebDriver driver, int time, string xpath);
        
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            //wait.Until(condition: ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            ////"//a[contains(@title,'Accept All Cookies')]"
            
        
    }
}
