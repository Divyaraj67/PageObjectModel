using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace POM.PageObjects
{
    public class CartPage
    {
        IWebDriver driver;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Elements
        
        private IWebElement checkoutBtn => driver.FindElement(By.Id("checkout"));
        private IWebElement firstName => driver.FindElement(By.Id("first-name"));
        private IWebElement lastName => driver.FindElement(By.Id("last-name"));
        private IWebElement postalCode => driver.FindElement(By.Id("postal-code"));
        private IWebElement continueBtn => driver.FindElement(By.Id("continue"));
        private IWebElement finishBtn => driver.FindElement(By.Id("finish"));
        public string Url => driver.Url;
        public string title => driver.Title;
        #endregion Elements


        #region Methods
        public void checkCart(out string currentUrl)
        {
            checkoutBtn.Click();
            currentUrl = Url;
        }
        public void enterDetails(string firstname, string lastname, string postalcode, out string currentUrl)
        {
            firstName.SendKeys(firstname);
            lastName.SendKeys(lastname);
            postalCode.SendKeys(postalcode);
            continueBtn.Click();
            currentUrl = Url;
        }
        public void finish(out string currentUrl)
        {
            finishBtn.Click();
            currentUrl = Url;
        }

        #endregion Methods
    }
}
