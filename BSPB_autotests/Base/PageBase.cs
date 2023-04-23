using Allure.Commons;
using BSPB_autotests.Reports;
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
        protected Browser Browser;
        public PageBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
            this.Browser = new Browser(driver);
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

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Failed:
                    ExtentReporting.Instance.LogFail($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    ExtentReporting.Instance.LogInfo($"Test skipped {message}");
                    break;
                default:
                    break;
            }

            ExtentReporting.Instance.LogScreenshot(
                "Ending test", Browser.GetScreenshot());

            var screenshot = Browser.SaveScreenshot();
            TestContext.AddTestAttachment(screenshot);
            AllureLifecycle.Instance.AddAttachment("ending test", "image/png", screenshot);
        }
    }
}
