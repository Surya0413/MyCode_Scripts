using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using OpenQA.Selenium;
namespace PageObject
{
  public  class ProductionCompanyManagementPO
    {
        IWebDriver driver = null;
        public ProductionCompanyManagementPO()
        {
            driver = BrowserHandler.Driver;
        }

        public IWebElement elementProdCompanyName => driver.FindElement(By.Id("txtSearchProductionCompanyName"));

        public IWebElement elementProdCompanyCode => driver.FindElement(By.Id("txtSearchProductionCompanyCode"));

        public IWebElement elementProduCompanyTitle => driver.FindElement(By.XPath("//div[@id='ProductionCompanyManagementApp']/h3[text()='Production Company Management']"));

        public IWebElement elementProductCompanySearchbtn => driver.FindElement(By.Id("btnSearch"));

        public IWebElement elementProductCompanysearchNameText => driver.FindElement(By.Id("txtProductionCompanyName"));

        public IWebElement elementProductCompnaySearchCodeText => driver.FindElement(By.Id("txtProductionCompanyCode"));
    }
}
