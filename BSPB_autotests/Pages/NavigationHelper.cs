using BSPB_autotests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BSPB_autotests.Settings.Settings;
namespace BSPB_autotests.Pages
{
    public class NavigationHelper : PageBase
    {
        public NavigationHelper(ApplicationManager manager)
            : base(manager)
        {

        }
        public void OpenWelcomePage()
        {
            if (driver.Url != BaseURL)
                 driver.Navigate().GoToUrl(BaseURL);
            ManageWindowSize();
        }

        public void ManageWindowSize()
        {
            driver.Manage().Window.Maximize();
        }
    }
}
