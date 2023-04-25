using Allure.Commons;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BSPB_autotests
{
    public class ScreenshotMaker
    {

        public void MakeScreenshot(ApplicationManager app)
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)app.Driver).GetScreenshot();
                var filename = TestContext.CurrentContext.Test.MethodName + "_screenshot_" + DateTime.Now.Ticks + ".png";
                var directory = Directory.GetCurrentDirectory()
                 + "\\allure-results\\";
                var path = directory + filename;
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(path);
                AllureLifecycle.Instance.AddAttachment(filename, "image/png", path);
            }
        }
    }
}
