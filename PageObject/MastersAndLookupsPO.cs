using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using OpenQA.Selenium;
namespace PageObject
{
  public class MastersAndLookupsPO
    {
        IWebDriver driver = null;
        public MastersAndLookupsPO()
        {
            driver = BrowserHandler.Driver;
        }

       public  IWebElement elementMaintenace => driver.FindElement(By.XPath("//li[@role='presentation']//h4[text()='Maintenance ']"));
        public IWebElement elementMasters => driver.FindElement(By.XPath("//li[@role='presentation']//h4[text()='Masters ']"));
        public IWebElement elementLookups => driver.FindElement(By.XPath("//li[@role='presentation']//h4[text()='Lookups ']"));

        public IWebElement elementTalentAgencyManagement => driver.FindElement(By.Id("TalentAgencyManagement"));

        public IWebElement elementClassficationCodeMgmt => driver.FindElement(By.Id("ClassificationCodeMgmt"));
        
    }

}
