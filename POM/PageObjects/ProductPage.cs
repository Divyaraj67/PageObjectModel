using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace POM.PageObjects
{
    public class ProductPage
    {

        IWebDriver driver;
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        

        #region Elements
        private IWebElement productOne => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement productTwo => driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        private IWebElement cartIcon => driver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a"));
        public string Url => driver.Url;
        public string title => driver.Title;
        #endregion Elements

        #region Methods
        public void productSelection(out string currentUrl)
        {
            productOne.Click();
            productTwo.Click();
            cartIcon.Click();
            currentUrl = Url;
        }
        #endregion Methods
    }
}
