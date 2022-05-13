using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using OpenQA.Selenium;
namespace PageObject
{
  public  class ReportsPO
    {
        IWebDriver driver = null;
        public ReportsPO()
        {
            driver = BrowserHandler.Driver;
        }

    public    IWebElement elementReportPage => driver.FindElement(By.Id("reports1"));
        //div[@id='idtreeview']//span[@class='k-in' and text()='Invoice Package']
        //button[@id='btnClearAll']
        public IWebElement elementAddCriteria => driver.FindElement(By.Id("btnAddSearchCalue"));
        public IWebElement elementClearAll => driver.FindElement(By.Id("btnClearAll"));
        public IWebElement elementRunReport => driver.FindElement(By.Id("btnReport"));
    }
}
