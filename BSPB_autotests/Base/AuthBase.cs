using Allure.Commons;
using BSPB_autotests.Models;
using BSPB_autotests.Settings;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BSPB_autotests.Settings.Settings;

namespace BSPB_autotests.Base
{
    public class AuthBase : TestBase
    {
        public UserData _user = new UserData(Username, Password);

        [SetUp]
        public void CheckAuth()
        {
            app.Navigation.OpenWelcomePage();
            if (app.Main.FindUsername != null) return;
            app.Login.LoginWithNameAndPassword(Username, Password);
            app.Login.PassAuthentification(AuthCode);
        }

    }
}
