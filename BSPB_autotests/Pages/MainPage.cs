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

        private By bankLogo = By.CssSelector("div #header #logo > img.print-hidden");
        private By userName = By.CssSelector("div #header #representee-list > div > button > span.filter-option.pull-left");
        private By communicationWithBank = By.CssSelector("div #header #messages-button");
        private By personalSuggestions = By.CssSelector("div #header #offers-button");
        private By bankContacts = By.CssSelector("div #header #contact-button");
        private By language = By.CssSelector("div #header div.links.pull-right > div > button");
        private By settings = By.CssSelector("div #header #settings-button");
        private By deposits = By.Id("deposits-index");
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
