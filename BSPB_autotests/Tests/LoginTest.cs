using BSPB_autotests.Base;
using BSPB_autotests.Pages;
using BSPB_autotests.Reports;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPB_autotests.Tests
{

    [AllureNUnit]
    public class LoginExampleTest5 : TestBase
    {

        [Test]
        public void WhenLoginWithValidNameAndPassword_SuccessMessageShouldAppear()
        {
            LoginPage mainPage = new LoginPage(driver);
            mainPage.LoginWithNameAndPassword("demo", "demo");
        }

    }
}
