using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BSPB_autotests.Pages;
using Allure.Commons;
using NUnit.Framework.Interfaces;
using NUnit.Allure.Attributes;

namespace BSPB_autotests
{
    public class ApplicationManager
    {

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
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                //
            }
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
           driver.Quit();
        }

    }
}
