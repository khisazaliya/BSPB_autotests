using BSPB_autotests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPB_autotests.Pages
{
    public class DepositPage : PageBase
    {
        //кнопка "Открыть вклад"
        private By openDepositBtn = By.Id("btn-show-rates");

        //таблица история вкладов
        private By depositsHistory = By.Id("deposits");

        //радиокнопка "rub"
        private By rub = By.CssSelector("#deposit-rates label.radio input[value='RUB']");

        //радиокнопка "1 месяц"
        private By month = By.CssSelector("#deposit-rates label.radio input[value='31']");

        //кнопка "Открыть вклад" на Демо Зимний Петербург онлайн
        private By Peter = By.XPath("//a[contains(@data-web-analytics-event,'Демо Зимний Петербург онлайн')]");

        //инпут сумма вклада
        private By ammount = By.Name("amount");

        //выпадающий список "Счет"
        private By estimated_interest = By.Id("estimated-interest");

        //кнопка "Дальше"
        private By submitBtn = By.CssSelector("button[id='submit-button']");

        //ссылка "Тарифы"
        private By tariff = By.XPath("//a[contains(text(), 'Тариф')]");

        //чекбокс "Я ознакомлен(а) и соглашаюсь с Правилами..."
        private By agreeDeclare = By.CssSelector(".immune.required.condition[name='condition.newDepositConditions']");

        //чекбокс "Я ознакомлен(а) с Заявлением..."
        private By agreeRules = By.CssSelector(".immune.required.condition[name='condition.instantDepositAgreement']");

        //всплывающее окно "Заявление об открытии срочного вклада"
        private By agreementPopup = By.Id("instant-deposit-agreement-content");

        //заголовок окна "Заявление об открытии срочного вклада"
        private By order = By.CssSelector("#instant-deposit-agreement-header > h3");

        //кнопка "Принимаю" в окне "Заявление об открытии срочного вклада"
        private By acceptBtn = By.Id("accept-instant-deposit-agreement-button");

        //кнопка "Подтвердить"
        private By confirmBtn = By.Id("confirm");

        //сообщение об успешном открытии вклада
        private By successText = By.CssSelector("#contentbar > div.well.success-info > h3");

        public DepositPage(ApplicationManager manager)
               : base(manager)
        {
        }

        public IWebElement FindOpenDepositButton()
        {
            return FindElementIsVisible(openDepositBtn);
        }
        public IWebElement FindDepositsHistory()
        {
            return FindElementIsVisible(depositsHistory);
        }

        public void CLickOpenDepositBnt()
        {
            Click(openDepositBtn);
        }
        public void FillDeposit()
        {
            Click(rub);
            Click(month);
        }

        public void SelectDeposit()
        {
            Click(Peter);
        }

        public void FillDepositFields(string ammountValue)
        {
            Click(ammount);
            SendKeys(ammount, ammountValue);
        }

        public IWebElement FindEstimatedInterest()
        {
            return FindElementIsVisible(estimated_interest);
        }

        public void ClickSubmitButton()
        {
            ScrollPage();
            Thread.Sleep(2000);
            Click(submitBtn);
        }
        public void ClickTariffLink()
        {
            Click(tariff);
        }

        public void FillAgreementDeclaration()
        {
            ScrollPage();
            Click(agreeDeclare);
        }
        public string FillAgreementRules()
        {
            Click(agreeRules);

            ScrollElement(agreementPopup);

            return GetText(order);
        }

        public string CLickConfirmBtn()
        {
            Click(acceptBtn);
            Click(confirmBtn);
            return GetText(successText);
        }

        public void EndTest()
        {
            EndTest();
        }
    }
}
