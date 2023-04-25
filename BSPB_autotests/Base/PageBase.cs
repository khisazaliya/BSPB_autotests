using Allure.Commons;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPB_autotests.Base
{
    public abstract class PageBase
    {
        public IWebDriver driver;
        protected ApplicationManager manager;
        protected int timeOutInSeconds = 5;
        public PageBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }

        public IWebElement FindElementIsVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        public IWebElement FindElementIsClickable(By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
        public void Click(By by)
        {
            FindElementIsClickable(by).Click();
        }

        public void Clear(By by)
        {
            FindElementIsVisible(by).Clear();
        }

        public void SendKeys(By by, string text)
        {
            FindElementIsVisible(by).SendKeys(text);
        }
        public void ScrollPage()
        {
            By html = By.TagName("html");
            FindElementIsVisible(html).SendKeys(Keys.End);
        }
        public void ScrollElement(By by)
        {
            driver.ExecuteJavaScript("arguments[0].scrollTop = arguments[0].scrollHeight", FindElementIsVisible(by));
        }
        public string GetText(By by)
        {
            return FindElementIsVisible(by).Text;
        }

        public string GetAlt(By by)
        {
            return FindElementIsVisible(by).GetAttribute("alt");
        }

        public string GetCssValue(By by)
        {
            return FindElementIsVisible(by).GetCssValue("transition");
        }
    }
}
