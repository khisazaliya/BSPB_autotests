using BSPB_autotests.Base;
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

        private By username = By.Name("username");
        private By password = By.Name("password");
        private By loginBtn = By.Id("login-button");
        private By loginOptBtn = By.Id("login-otp-button");
        private By codeInput = By.Id("otp-code");

        public LoginPage(ApplicationManager manager)
               : base(manager)
        {
        }

        public void LoginWithNameAndPassword(string name, string pwd)
        {

            Click(username);
            Clear(username);
            SendKeys(username, name);

            Click(password);
            Clear(password);
            SendKeys(password, pwd);

            Click(loginBtn);
        }

        public void PassAuthentification(string code)
        {
            Thread.Sleep(2000);
            Click(codeInput);
            Clear(codeInput);
            SendKeys(codeInput, code);
            Click(loginOptBtn);

        }
        public void EndTest()
        {
            EndTest();
        }
    }
}
