using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace POM.BaseClass
{
    public class BaseTest
    {
        public IWebDriver driver;

        [SetUp]
        public void Open()
        {
            driver= new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.saucedemo.com/";

        }

        [TearDown]
        public void Close()
        {
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"D:\POM\POM\Screenshots\POM.png", ScreenshotImageFormat.Png);
            driver.Quit();
        }
    }
}
