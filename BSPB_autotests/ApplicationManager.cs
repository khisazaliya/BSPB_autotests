using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BSPB_autotests.Pages;
using BSPB_autotests.Reports;
using Allure.Commons;
using NUnit.Framework.Interfaces;
using NUnit.Allure.Attributes;

namespace BSPB_autotests
{
    public class ApplicationManager
    {
        protected static AllureReporting AllureReport { get; private set; }
        protected Browser Browser { get; private set; }
        private IWebDriver driver;

        private LoginPage login;
        private MainPage main;
        private DepositPage deposit;
        private CreditPage credit;

        private NavigationHelper navigation;
        private IJavaScriptExecutor js;


        public static readonly ApplicationManager Instance = new();

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            login = new LoginPage(this);
            main = new MainPage(this);
            deposit = new DepositPage(this);
            credit = new CreditPage(this);
            navigation = new NavigationHelper(this);
            js = (IJavaScriptExecutor)driver;
            Browser = new Browser(driver);
            InitializeReport();
            AllureReport = new AllureReporting();
        }

        ~ApplicationManager()
        {
            try
            {
                EndTest();
                ExtentReporting.Instance.EndReporting();
                driver.Quit();
            }
            catch (Exception)
            {
                //
            }
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

        public static void InitializeReport()
        {
            var methodName = TestContext.CurrentContext.Test.MethodName;
            if (methodName != null)
                ExtentReporting.Instance.CreateTest(methodName);
            else
                ExtentReporting.Instance.CreateTest("test");
        }
        public static ApplicationManager GetInstance()
        {

            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.OpenWelcomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public NavigationHelper Navigation
        {
            get
            {
                return navigation;
            }
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public LoginPage Login
        {
            get
            {
                return login;
            }
        }
        public MainPage Main
        {
            get
            {
                return main;
            }
        }

        public DepositPage Deposit
        {
            get
            {
                return deposit;
            }
        }

        public CreditPage Credit
        {
            get
            {
                return credit;
            }
        }

        public void Stop()
        {
            EndTest();
            ExtentReporting.Instance.EndReporting();
            Driver.Quit();
        }

        public void EndReport()
        {
            ExtentReporting.Instance.EndReporting();
            Driver.Quit();
        }
    }
}
