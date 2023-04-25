using BSPB_autotests.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPB_autotests.Pages
{
    public class MainPage : PageBase
    {
        //логотип Банка
        private By bankLogo = By.CssSelector("div #header #logo > img.print-hidden");

        //наименование физического/юридического лица
        private By userName = By.CssSelector("div #header #representee-list > div > button > span.filter-option.pull-left");

        //кнопка "Переписка с Банком"
        private By communicationWithBank = By.CssSelector("div #header #messages-button");

        //кнопка "Персональные предложения"
        private By personalSuggestions = By.CssSelector("div #header #offers-button");

        //кнопка "Контакты Банка"
        private By bankContacts = By.CssSelector("div #header #contact-button");

        //кнопка переключения на англ. язык сайта
        private By language = By.CssSelector("div #header div.links.pull-right > div > button");

        //кнопка "Настройки"
        private By settings = By.CssSelector("div #header #settings-button");

        //кнопка "Вклады"
        private By deposits = By.Id("deposits-index");

        //кнопка "Кредиты"
        private By credits = By.Id("loans-index");
        public MainPage(ApplicationManager manager)
            : base(manager)
        {
        }


        public IWebElement FindBankLogo()
        {
            return Element(bankLogo);
        }

        public string FindBankLogoText()
        {
            return GetAlt(bankLogo).ToString();
        }

        public string FindUsername()
        {
            return GetText(userName);
        }

        public IWebElement FindCommunicationWithBankButton()
        {
            return Element(communicationWithBank);

        }

        public IWebElement FindPersonalSuggestionsButton()
        {
            Thread.Sleep(5000);
            return Element(personalSuggestions);

        }

        public IWebElement FindBankContactsButton()
        {
            Thread.Sleep(5000);
            return Element(bankContacts);

        }
        public IWebElement FindLanguageButton()
        {
            Thread.Sleep(5000);
            return Element(language);

        }

        public IWebElement FindSettingsButton()
        {

            Thread.Sleep(5000);
            return Element(settings);

        }

        public void RedirectToDeposits()
        {
            Click(deposits);
        }

        public void RedirectToCredits()
        {
            Click(credits);
        }


    }
}
