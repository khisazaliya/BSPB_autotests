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

        //поле ввода логина
        private By username = By.Name("username");

        //поле ввода пароля
        private By password = By.Name("password");

        //кнопка "Войти"
        private By loginBtn = By.Id("login-button");

        //кнопка "Войти" после ввода кода подтверждения
        private By loginOptBtn = By.Id("login-otp-button");

        //поле ввода кода подтверждения
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
