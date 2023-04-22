using BSPB_autotests.Base;
using BSPB_autotests.Reports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BSPB_autotests.Pages
{

    public class LoginPage : PageBase
    {
        protected AllureReporting AllureReport { get; private set; }

        private By username = By.Name("username");
        private By password = By.Name("password");
        private By loginBtn = By.Id("login-button");
        private By loginOptBtn = By.Id("login-otp-button");
        private By userGreeting = By.Id("user-greeting");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            AllureReport = new AllureReporting();
        }


        public LoginPage LoginWithNameAndPassword(string name, string pwd)
        {

            AllureReport.LogStep("enter username");
            Click(username);
            Clear(username);
            SendKeys(username, name);

            AllureReport.LogStep("enter password");
            Click(password);
            Clear(password);
            SendKeys(password, pwd);

            AllureReport.LogStep("click login button");
            Click(loginBtn);


            Thread.Sleep(2000);
            AllureReport.LogStep("click login button again after number entering");
            Click(loginOptBtn);

            AllureReport.LogStep("check if user greeting text is Hello World! ");
            var text = GetText(userGreeting);
            Assert.That(text == "Hello World!");
            return new LoginPage(Driver);
        }
    }
}
