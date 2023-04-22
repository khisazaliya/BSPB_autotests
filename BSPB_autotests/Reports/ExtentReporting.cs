using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BSPB_autotests.Reports
{
    public sealed class ExtentReporting
    {
        private static ExtentReporting? instance = null;
        private static readonly object myLock = new object();

        private ExtentReports? extentReports;
        private ExtentTest? extentTest;

        private ExtentReporting() { }

        public static ExtentReporting Instance
        {
            get
            {
                lock (myLock)
                {
                    if (instance == null)
                    {
                        instance = new ExtentReporting();
                    }
                    return instance;
                }
            }
        }

        private ExtentReports StartReporting()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\";

            if (extentReports == null)
            {
                Directory.CreateDirectory(path);

                extentReports = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter(path);

                extentReports.AttachReporter(htmlReporter);
            }

            return extentReports;
        }

        /// <param name="testName"></param>
        public void CreateTest(string testName)
        {
            extentTest = StartReporting().CreateTest(testName);
        }

        public void EndReporting()
        {
            StartReporting().Flush();
        }

        /// <param name="info"></param>
        public void LogInfo(string info)
        {
            extentTest?.Info(info);
        }

        /// <param name="info"></param>
        public void LogPass(string info)
        {
            extentTest?.Pass(info);
        }

        /// <param name="info"></param>
        public void LogFail(string info)
        {
            extentTest?.Fail(info);
        }

        /// <param name="info"></param>
        /// <param name="image"></param>
        public void LogScreenshot(string info, string image)
        {
            extentTest?.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
    }
}
