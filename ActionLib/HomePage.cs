using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using PageObject;
using OpenQA.Selenium;
using System.Threading;

namespace ActionLib
{
  public  class HomePage
    {
        IWebDriver driver;
        HomePagepo homepagepo;

        public HomePage ()
        {
            driver = BrowserHandler.Driver;
            homepagepo = new HomePagepo();
        }

        private void WiatFor_HomePage()
        {
            int count = 0;
            while (count <= 10)
            {
                try
                {
                    if (homepagepo.elementPayrollTracking.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
        }

        public void Select_Module(string module)
        {
            WiatFor_HomePage();

            switch (module)
            {
                case "Invoicing":
                    {
                        homepagepo.elementInvoice.Click();
                        break;
                    }
                case "Employee Maintenance":
                    {
                        homepagepo.elementEmployeeMaintenance.Click();
                        break;
                    }
                case "Report":
                    {
                        homepagepo.elementReport.Click();
                        break;
                    }
                case "Masters and Lookups":
                    {
                        homepagepo.elementMasterLookups.Click();
                        break;
                    }
                case "Union Agreements":
                    {
                        homepagepo.elementUnionAgreements.Click();
                        break;
                    }
                case "Employee Merge":
                    {
                        homepagepo.elementEmployeeMerge.Click();
                        break;
                    }
                case "PSHD":
                    {
                        homepagepo.elementPSHD.Click();
                        break;
                    }
                case "Labor Relations":
                    {
                        homepagepo.elementLaborRelations.Click();
                        break;
                    }
                case "Accounting":
                    {
                        homepagepo.elementAccounting.Click();
                        break;
                    }
                case "Show":
                    {
                        homepagepo.elementShow.Click();
                        break;
                    }
                case "User Settings":
                    {
                        homepagepo.elementUserSettings.Click();
                        break;
                    }
                case "Payroll Tracking":
                    {
                        homepagepo.elementPayrollTracking.Click();
                        break;
                    }
            }
        }

    }
}
