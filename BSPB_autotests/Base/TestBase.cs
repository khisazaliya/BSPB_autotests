using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allure.Commons;
using NUnit.Framework.Interfaces;
using BSPB_autotests.Pages;

namespace BSPB_autotests.Base
{
    public class TestBase
    {
        protected ApplicationManager app;
        protected ScreenshotMaker? screenshotMaker;

        [OneTimeSetUp]
        public void SetupTest()
        {
            app = ApplicationManager.Instance;
        }

        [TearDown]
        public void QuitTest()
        {
            screenshotMaker = new ScreenshotMaker();
            screenshotMaker.MakeScreenshot(app);
        }
    }
}