using Allure.Commons;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
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
        public PageBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }

        public IWebElement Element(By by)
        {
            return driver.FindElement(by);
        }

        public void Click(By by)
        {
            Element(by).Click();
        }

        public void Clear(By by)
        {
            Element(by).Clear();
        }

        public void SendKeys(By by, string text)
        {
            Element(by).SendKeys(text);
        }
        public void ScrollPage()
        {
            By html = By.TagName("html");
            Element(html).SendKeys(Keys.End);
        }
        public void ScrollElement(By by)
        {
            driver.ExecuteJavaScript("arguments[0].scrollTop = arguments[0].scrollHeight", Element(by));
        }
        public string GetText(By by)
        {
            return Element(by).Text;
        }

        public string GetAlt(By by)
        {
            return Element(by).GetAttribute("alt");
        }

        public string GetCssValue(By by)
        {
            return Element(by).GetCssValue("transition");
        }
    }
}
