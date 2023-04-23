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

        private By openDepositBtn = By.Id("btn-show-rates");
        private By depositsHistory = By.Id("deposits");
        private By rub = By.CssSelector("#deposit-rates > div.row > div.span2 > label:nth-child(2) > input[type=radio]");
        private By month = By.CssSelector("#deposit-rates > div.row > div.span6 > div:nth-child(3) > label:nth-child(2)");
        private By Peter = By.CssSelector("#table-deposit-rates > tbody > tr:nth-child(3) > td:nth-child(7) > a");
        private By ammount = By.Name("amount");
        private By estimated_interest = By.Id("estimated-interest");
        private By submitBtn = By.Id("submit-button");
        private By tariff = By.CssSelector("#contentbar > form > div.conditions-confirmation-block > div:nth-child(1) > div > div > label > p > span > a:nth-child(2)");
        private By agreeDeclare = By.CssSelector("#contentbar > form > div.conditions-confirmation-block > div:nth-child(1) > div > div > label > input");
        private By agreeRules = By.CssSelector("#contentbar > form > div.conditions-confirmation-block > div:nth-child(2) > div > div > label > input");
        private By agreementPopup = By.Id("instant-deposit-agreement-content");
        private By order = By.CssSelector("#instant-deposit-agreement-header > h3");
        private By acceptBtn = By.Id("accept-instant-deposit-agreement-button");
        private By confirmBtn = By.Id("confirm");
        private By successText = By.CssSelector("#contentbar > div.well.success-info > h3");

        public DepositPage(ApplicationManager manager)
               : base(manager)
        {
        }

        public IWebElement FindOpenDepositButton()
        {
            return Element(openDepositBtn);
        }
        public IWebElement FindDepositsHistory()
        {
            return Element(depositsHistory);
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
            return Element(estimated_interest);
        }

        public void ClickSubmitButton()
        {
            ScrollPage();
            Thread.Sleep(3000);
            Click(submitBtn);
        }
        public void ClickTariffLink()
        {
            Click(tariff);
        }

        public void FillAgreementDeclaration()
        {
            ScrollPage();
            Thread.Sleep(3000);
            Click(agreeDeclare);
        }
        public string FillAgreementRules()
        {
            Click(agreeRules);
            Thread.Sleep(2000);

            ScrollElement(agreementPopup);
            Thread.Sleep(2000);

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
