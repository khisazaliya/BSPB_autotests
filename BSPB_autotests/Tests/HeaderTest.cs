using BSPB_autotests.Base;
using BSPB_autotests.Models;
using BSPB_autotests.Pages;
using BSPB_autotests.Reports;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using BSPB_autotests.Settings;
using static BSPB_autotests.Settings.Settings;
using Allure.Commons;
using NUnit.Framework.Interfaces;
using NPOI.Util;

namespace BSPB_autotests.Tests
{

    [AllureNUnit]
    public class HeaderTest : AuthBase
    {
        public UserData _user = new UserData(Username, Password);

        [AllureDescription("Проверка шапки <header> сайта БСПБ")]
        [Test]
        public void WhenLoginWithValidNameAndPassword_HeaderShouldAppear()
        {

            OpenPage();

            Login();

            Auth();

            CheckBankLogo();

            CheckBankLogoText();

            CheckUsername();

            CheckCommunicationWithBankButton();

            CheckPersonalSuggestionsButton();

            CheckBankContactsButton();

            CheckLanguageButton();

            CheckSettingsButton();

            AllureLifecycle.Instance.AddAttachment(("Any text", new ByteArrayInputStream(((Screenshot)app.Driver).AsByteArray)).ToString());
        }

        [AllureStep("Открыть сайт")]
        public void OpenPage()
        {
            app.Navigation.OpenWelcomePage();
        }

        [AllureStep("Авторизоваться на сайте")]
        public void Login()
        {
            app.Login.LoginWithNameAndPassword(Username, Password);
        }

        [AllureStep("Пройти аутентификацию с помощью кода")]
        public void Auth()
        {
            app.Login.PassAuthentification(AuthCode);
        }

        [AllureStep("<header> Наличие кнопки \"Настройки\"")]
        public void CheckSettingsButton()
        {
            var element = app.Main.FindSettingsButton();
            Assert.IsNotNull(element);
        }

        [AllureStep("<header> Наличие кнопки переключения на английский язык сайта ")]
        public void CheckLanguageButton()
        {
            var element = app.Main.FindLanguageButton();
            Assert.IsNotNull(element);
        }

        [AllureStep("<header> Наличие кнопки \"Контакты Банка\"")]
        public void CheckBankContactsButton()
        {
            var element = app.Main.FindBankContactsButton();
            Assert.IsNotNull(element);
        }

        [AllureStep("<header> Наличие кнопки \"Персональные предложения\"")]
        public void CheckPersonalSuggestionsButton()
        {
            var element = app.Main.FindPersonalSuggestionsButton();
            Assert.IsNotNull(element);
        }

        [AllureStep("<header> Наличие кнопки \"Переписка с Банком\"")]
        public void CheckCommunicationWithBankButton()
        {
            var element = app.Main.FindCommunicationWithBankButton();
            Assert.IsNotNull(element);
        }

        [AllureStep("<header> Отображение наименования физического/юридического лица")]

        public void CheckUsername()
        {
            var username = app.Main.FindUsername();
            var expectedUsername = "Королёва Ольга";
            Assert.That(username, Is.EqualTo(expectedUsername));
        }

        [AllureStep("<header> Отображение наименования Банка")]
        public void CheckBankLogoText()
        {
            var logoText = app.Main.FindBankLogoText();
            var expectedLogoText = "Интернет банк - Банк Санкт-Петербург";
            Assert.That(expectedLogoText == logoText);
        }

        [AllureStep("<header> Отображение логотипа Банка")]
        public void CheckBankLogo()
        {
            var bankLogo = app.Main.FindBankLogo();
            Assert.That(bankLogo != null);
        }

    }
}
