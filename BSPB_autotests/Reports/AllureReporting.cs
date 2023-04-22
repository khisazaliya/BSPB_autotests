using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPB_autotests.Reports
{
    public class AllureReporting
    {
        [AllureStep("{0}")]
        public void LogStep(string message)
        {
        }
    }
}
