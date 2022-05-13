using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using OpenQA.Selenium;
namespace PageObject
{
   public  class HomePagepo
    {
        IWebDriver driver = null;
        public HomePagepo()
        {
            driver = BrowserHandler.Driver;
        }

        public  IWebElement elementInvoice => driver.FindElement(By.XPath("//div[@id='divInvoices']"));
        public IWebElement elementEmployeeMaintenance => driver.FindElement(By.XPath("//div[@id='divEmpMaintenance']"));

        public IWebElement elementReport => driver.FindElement(By.XPath("//div[@id='divReports']"));

        public IWebElement elementMasterLookups => driver.FindElement(By.XPath("//div[@id='divMastersLookups']"));

        public IWebElement elementUnionAgreements => driver.FindElement(By.XPath("//div[@id='divUnionAgreements']"));

        public IWebElement elementEmployeeMerge => driver.FindElement(By.XPath("//div[@id='divEmployeeMerge']"));

        public IWebElement elementPSHD => driver.FindElement(By.XPath("//div[@id='divPSHDAdministration']"));

        public IWebElement elementLaborRelations => driver.FindElement(By.XPath("//div[@id='divLaborRelations']"));

        public IWebElement elementAccounting => driver.FindElement(By.XPath("//div[@id='divAccounting']"));

        public IWebElement elementShow => driver.FindElement(By.XPath("//div[@id='divShow']"));

        public IWebElement elementUserSettings => driver.FindElement(By.XPath("//div[@id='divUserSettings']"));

        public IWebElement elementPayrollTracking => driver.FindElement(By.XPath("//div[@id='divPayrollTracking']"));

        public IWebElement elementClientFiles => driver.FindElement(By.XPath("//div[@id='divClientFiles']"));

        public IWebElement elementSoftwareSupport => driver.FindElement(By.XPath("//div[@id='divHTGSoftwareSupport']"));
        public IWebElement elementCommandAndControls => driver.FindElement(By.XPath("//div[@id='divHTGCommandAndControl']"));
    }
}
