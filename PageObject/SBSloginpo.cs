using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using OpenQA.Selenium;
namespace PageObject
{
  public  class SBSloginpo
    {
         IWebDriver driver = null;
        public SBSloginpo ()
        {
            driver = BrowserHandler.Driver;            
        }

       public  IWebElement elementUsername => driver.FindElement(By.XPath("//input[@id='okta-signin-username']"));
       public  IWebElement elementPassword => driver.FindElement(By.XPath("//input[@id='okta-signin-password']"));
       public  IWebElement elementSubmit => driver.FindElement(By.XPath("//input[@id='okta-signin-submit']"));
              

    }
}
