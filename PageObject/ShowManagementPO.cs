using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using OpenQA.Selenium;
namespace PageObject
{
   public  class ShowManagementPO
    {
        IWebDriver driver = null;
        public ShowManagementPO()
        {
            driver = BrowserHandler.Driver;
        }

        public IWebElement elementShowManagmentHeader => driver.FindElement(By.XPath("//div[contains(@class,'col-md-4')]/h3[text()='Show Management']"));
        public IWebElement elementShowCode => driver.FindElement(By.Id("txtSearchShowCode"));

        public IWebElement elementbtnSearch => driver.FindElement(By.Id("btnSearch"));

        public IWebElement elementShowMangName => driver.FindElement(By.Id("txtSearchShowName"));

        public IWebElement elementShowMangNameText => driver.FindElement(By.Id("txtShowName"));

        public IWebElement elementShowManagCodeText => driver.FindElement(By.Id("txtShowCode"));
    }
}
