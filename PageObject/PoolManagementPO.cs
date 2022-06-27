using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using OpenQA.Selenium;
namespace PageObject
{
 public  class PoolManagementPO
    {

        IWebDriver driver = null;
        public PoolManagementPO()
        {
            driver = BrowserHandler.Driver;
        }

        public IWebElement elementPoolSearchText => driver.FindElement(By.Id("txtPoolSearch"));

        public IWebElement elemmentPoolSearchBtn => driver.FindElement(By.Id("btnSearch"));

        public IWebElement elementPoolResultSearchText => driver.FindElement(By.Id("txtDescription"));
    }
}
