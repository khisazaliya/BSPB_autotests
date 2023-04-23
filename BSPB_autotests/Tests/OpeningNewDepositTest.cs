using AventStack.ExtentReports;
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
using static System.Net.Mime.MediaTypeNames;

namespace BSPB_autotests.Tests
{
    [AllureNUnit]
    public class OpeningNewDepositTest : AuthBase
    {

        [AllureDescription("Открыть новый вклад RUB")]
        [Test]
        public void WhenEntedValidData_DepositShouldBeOpened()
        {

            OpenDepositPage();

            OpenDeposit();

            FillDepositParameters();

            SelectDeposit();

            CheckDepositFields();

            ClickNextButton();

            CheckTariffsLink();

            FillCheckboxes();

            ConfirmOpenning();

        }

        [AllureStep("Перейти в раздел \"Вклады\" на карте сайта")]
        public void OpenDepositPage()
        {
            app.Main.RedirectToDeposits();
            Assert.That((app.Deposit.FindDepositsHistory() != null) && (app.Deposit.FindOpenDepositButton() != null));
        }

        [AllureStep("Нажать на кнопку \"Открыть вклад\"")]
        public void OpenDeposit()
        {
            app.Deposit.CLickOpenDepositBnt();
        }

        [AllureStep("Заполнить параметры вклада")]
        public void FillDepositParameters()
        {
            app.Deposit.FillDeposit();
        }

        [AllureStep("Нажать Открыть вклад \"Демо Зимний Петербург онлайн\"")]
        public void SelectDeposit()
        {
            app.Deposit.SelectDeposit();
        }

        [AllureStep("Заполнить поля для оформления")]
        public void CheckDepositFields()
        {
            app.Deposit.FillDepositFields("50000");
            Assert.That(app.Deposit.FindEstimatedInterest() != null);
        }

        [AllureStep("Кликнуть кнопку Дальше")]
        public void ClickNextButton()
        {
            app.Deposit.ClickSubmitButton();
        }

        [AllureStep("Открыть ссылку \"Тарифы\" ")]
        public void CheckTariffsLink()
        {
            var current_url = app.Driver.Url;
            app.Deposit.ClickTariffLink();
            var tabTitle = app.Driver.Title;
            List<String> tabs = new List<String>(app.Driver.WindowHandles);
            app.Driver.SwitchTo().Window(tabs[1]);
            var new_window_url = app.Driver.Url;
            app.Driver.Close();
            app.Driver.SwitchTo().Window(tabs[0]);
            Assert.That((current_url != new_window_url));
        }

        [AllureStep("Заполнить чек боксы с ознакомлением ")]
        public void FillCheckboxes()
        {
            app.Deposit.FillAgreementDeclaration();
            var actualText = app.Deposit.FillAgreementRules();
            Assert.That(actualText, Is.EqualTo("Заявление об открытии срочного вклада"));
        }

        [AllureStep("Нажать \"Подтвердить\"")]
        public void ConfirmOpenning()
        {
            var actualText = app.Deposit.CLickConfirmBtn();
            Assert.That(actualText, Is.EqualTo("Вклад открыт"));
        }

    }
}
