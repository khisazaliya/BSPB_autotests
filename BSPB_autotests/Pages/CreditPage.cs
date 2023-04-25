using BSPB_autotests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPB_autotests.Pages
{
    public class CreditPage : PageBase
    {
        //кнопка "Оформить кредитный продукт"
        private By loanApplicationBtn = By.Id("loan-application-btn");

        //плитки продуктов
        private By creditProducts = By.Id("unified-loan-application-selector");

        //плитка "Кредитная карта"
        private By credit = By.CssSelector("#contentbar > div.unified-loan-application-selector > div:nth-child(1) > div:nth-child(2)");

        //кнопка "Оформить заявку" на плитке "Кредитная карта"
        private By creditCardApplyBtn = By.Id("credit-card-loan-apply");

        public CreditPage(ApplicationManager manager) : base(manager)
        {
        }

        public IWebElement FindLoanApplicationBtn()
        {
            return Element(loanApplicationBtn);
        }

        public void ClickLoanApplicationBtn()
        {
            Click(loanApplicationBtn);
        }

        public IWebElement FindCreditProducts()
        {
            return Element(creditProducts);
        }

        public bool isCreditAnimated()
        {
            return GetCssValue(credit) != null;
        }

        public void ApplyCreditCard()
        {
            Click(creditCardApplyBtn);
        }

        public void EndTest()
        {
            EndTest();
        }
    }
}
