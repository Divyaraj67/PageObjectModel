using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace POM.PageObjects
{
    public class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        #region Elements
        

        private IWebElement username => driver.FindElement(By.Id("user-name"));
        private IWebElement password => driver.FindElement(By.Id("password"));
        private IWebElement loginBtn => driver.FindElement(By.Id("login-button"));


        public string Url => driver.Url;
        public string title => driver.Title;

        #endregion Elements




        #region Methods

        public void userLogin(string userID, string pass, out string currentUrl)
        {
            username.SendKeys(userID);
            password.SendKeys(pass);
            loginBtn.Click();
            currentUrl = Url;
        }
        public void getTitle(out string pageTitle)
        {
            pageTitle = title;
        }


        #endregion Methods
    }
}
