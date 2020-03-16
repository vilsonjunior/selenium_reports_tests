using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace POCSelenium.Common
{
    public abstract class BaseDriver : IDisposable
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;
        protected IObjectContainer _objectContainer;
        public BaseDriver(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            SetUpBrowser();
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        public void HighlightElement(IWebElement element)
        {
            if (element.Displayed)
            {
                var jsDriver = (IJavaScriptExecutor)_driver;
                string highlightJavascript = @"arguments[0].setAttribute('style','background: orange; border: 2px solid blue;');";
                jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
                Thread.Sleep(500);
                jsDriver.ExecuteScript(@"arguments[0].setAttribute('style', arguments[1]);", element, "");
                Thread.Sleep(500);
            }
        }

        private void SetUpBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(45);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            _driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(50);
            _driver.Manage().Window.Maximize();
        }
    }
}
