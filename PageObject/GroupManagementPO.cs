using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using OpenQA.Selenium;
namespace PageObject
{
  public  class GroupManagementPO
    {
        IWebDriver driver = null;
        public GroupManagementPO()
        {
            driver = BrowserHandler.Driver;
        }

        public IWebElement elementGroupSearchtxt => driver.FindElement(By.Id("txtSearchShowName"));

        public IWebElement elementGrupSearchbtn => driver.FindElement(By.Id("btnSearch"));

        public IWebElement elementGoupSearchCodetxt => driver.FindElement(By.Id("txtSearchShowCode"));

    }
}
