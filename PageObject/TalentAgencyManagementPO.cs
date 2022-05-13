using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using OpenQA.Selenium;
namespace PageObject
{
  public   class TalentAgencyManagementPO
    {


        IWebDriver driver = null;
        public TalentAgencyManagementPO()
        {
            driver = BrowserHandler.Driver;
        }


       public  IWebElement elementTalentAgencyManagement => driver.FindElement(By.XPath("//h3[text()='Talent Agency Management']"));

        public IWebElement elementSearchAgencyCode => driver.FindElement(By.Id("txtSearchTalentAgencyCode"));

        public IWebElement elementAgencyName => driver.FindElement(By.Id("txtSearchTalentAgencyName"));

        public IWebElement elementSearch => driver.FindElement(By.Id("btnGoFindTalentAgency"));

        public IWebElement elementClear => driver.FindElement(By.Id("btnClearSearch"));

        public IWebElement elementAgencyCode => driver.FindElement(By.Id("txtAgencyCode"));

        //td[text()='ABSEILING COMMUNITY']/parent::tr


    }
}
