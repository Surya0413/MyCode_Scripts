using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using OpenQA.Selenium;
namespace PageObject
{
  public   class ShowPO
    {
        IWebDriver driver = null;
        public ShowPO()
        {
            driver = BrowserHandler.Driver;
        }

        public IWebElement elementdropdownShoMasters => driver.FindElement(By.XPath("//a[@class='dropdown-toggle']/h4[contains(text(),'Show Masters')]"));

        public IWebElement elementShowManagement => driver.FindElement(By.XPath("//a[text()='Show Management']"));

        public IWebElement elementShowManagmentHeader => driver.FindElement(By.XPath("//div[contains(@class,'col-md-4')]/h3[text()='Show Management']"));

        public IWebElement elementProductionCompanyManagmnt => driver.FindElement(By.XPath("//a[text()='Production Company Management']"));

        public IWebElement elementPoolManagmnt => driver.FindElement(By.XPath("//a[text()='Pool Management']"));
        public IWebElement elementGroupManagmnt => driver.FindElement(By.XPath("//a[text()='Group Management']"));
    }
}
