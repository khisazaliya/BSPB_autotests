using AventStack.ExtentReports;
using BSPB_autotests.Base;
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
    public class RegisterNewCreditCardTest : AuthBase
    {

        [AllureDescription("Проверка шапки <header> сайта БСПБ")]
        [Test]
        public void WhenEnterValidData_CreditCardShouldBeRegistered()
        {

            OpenCreditPage();

            OpenCredit();

            CheckAnimation();

            CheckApllyCreditCard("https://online-bspb.ru/calculator/creditcard");

            EnterValidData();

            ConfirmApplication();

        }

        [AllureStep("Перейти в раздел \"Кредиты\" на карте сайта")]
        public void OpenCreditPage()
        {
            app.Main.RedirectToCredits();
            Assert.That(app.Credit.FindLoanApplicationBtn() != null);
        }

        [AllureStep("ЛКМ на кнопке \"Оформить кредитный продукт\"")]
        public void OpenCredit()
        {
            app.Credit.ClickLoanApplicationBtn();
            Assert.That(app.Credit.FindCreditProducts != null);
        }

        [AllureStep("Проверить анимацию при наведении курсора мыши на плитки продуктов")]
        public void CheckAnimation()
        {
            Assert.That(app.Credit.isCreditAnimated() == true);
        }

        [AllureStep("ЛКМ на кнопке \"Оформить заявку\"")]
        public void CheckApllyCreditCard(string url)
        {
            app.Credit.ApplyCreditCard();
            var current_url = app.Driver.Url;
            Assert.That(current_url == url);
        }

        [AllureStep("Заполнить персональные данные")]
        public void EnterValidData()
        {
            //
        }

        [AllureStep("ЛКМ на кнопке \"Оформить заявку\"")]
        public void ConfirmApplication()
        {
            //
        }
    }
}
