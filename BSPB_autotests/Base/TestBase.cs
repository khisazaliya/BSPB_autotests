using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSPB_autotests.Reports;
using Allure.Commons;
using NUnit.Framework.Interfaces;
using BSPB_autotests.Pages;

namespace BSPB_autotests.Base
{
    public class TestBase
    {
        public IWebDriver driver;
        protected AllureReporting AllureReport { get; private set; }
        protected Browser Browser { get; private set; }

        [SetUp]
        public void Setup()
        {
            var methodName = TestContext.CurrentContext.Test.MethodName;
            if (methodName != null)
                ExtentReporting.Instance.CreateTest(methodName);
            else
                ExtentReporting.Instance.CreateTest("test");
            AllureReport = new AllureReporting();

            driver = new ChromeDriver();
            Browser = new Browser(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://idemo.bspb.ru/");
        }

        [TearDown]
        public void CleanUp()
        {
            EndTest();
            ExtentReporting.Instance.EndReporting();
            driver.Close();
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
