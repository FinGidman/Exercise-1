using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_WebDriver.Pages
{
    class SignInPage
    {
        [FindsBy(How = How.Id, Using = "signinEmail")]
        private IWebElement Login { get; set; }

        [FindsBy(How = How.Id, Using = "signinPword")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "loginNow")]
        public IWebElement SignInButton { get; set; }

        public SignInPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public SignInPage InputSignInInformation(string Login, string Password)
        {
            //Login.SendKeys(Login);
            //Password.SendKeys(Password);
            SignInButton.Click();
            return this;
        }
    }
}
