using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Core;
using OpenQA.Selenium;
 
using PageObject;
 
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace ActionLib
{
  public  class Reports
    {
        IWebDriver driver;
        ReportsPO reportsPo;
        General general;
        public Reports()
        {
            driver = BrowserHandler.Driver;
            reportsPo = new ReportsPO();
            general = new General();
        }


        private void WaitFor_ReportsPage()
        {
            int count = 0;
            while (count <= 6)
            {
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
                try
                {
                    if (reportsPo.elementReportPage.Enabled)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;

            }

            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }

        public void Select_Report_Option(string option,string subOption)
        {
            WaitFor_ReportsPage();
            switch (option)
            {
                case "ACA":
                    {
                        driver.FindElement(By.XPath("//span[@class='k-in' and text()='" + option + "']")).Click();
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("//div[@id='idtreeview']//span[@class='k-in' and text()='" + option + "']/parent::div/following-sibling::ul[@class='k-group']/li[@role='treeitem']//span[text()='" + subOption + "']")).Click();

                        break;
                    }
                case "Accounting":
                    {
                        driver.FindElement(By.XPath("//span[@class='k-in' and text()='" + option + "']")).Click();
                        Thread.Sleep(2000);
                        //driver.FindElement(By.XPath("//div[@id='idtreeview']//span[@class='k-in' and text()='" + option + "']/parent::div/following-sibling::ul[@class='k-group']/li[@role='treeitem']//span[text()='" + subOption + "']")).Click();
                        driver.FindElement(By.XPath("//ul[@class='k-group']/li[@role='treeitem']//span[text()='" + subOption + "']")).Click();

                        break;
                    }
                case "Commercial Talent":
                    {
                        driver.FindElement(By.XPath("//span[@class='k-in' and text()='" + option + "']")).Click();
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("//div[@id='idtreeview']//span[@class='k-in' and text()='" + option + "']/parent::div/following-sibling::ul[@class='k-group']/li[@role='treeitem']//span[text()='" + subOption + "']")).Click();

                        break;
                    }
                case "Custom Reporting":
                    {
                        driver.FindElement(By.XPath("//span[@class='k-in' and text()='" + option + "']")).Click();
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("//div[@id='idtreeview']//span[@class='k-in' and text()='" + option + "']/parent::div/following-sibling::ul[@class='k-group']/li[@role='treeitem']//span[text()='" + subOption + "']")).Click();

                        break;
                    }
                case "Taxes":
                    {
                        driver.FindElement(By.XPath("//span[@class='k-in' and text()='" + option + "']")).Click();
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("//div[@id='idtreeview']//span[@class='k-in' and text()='" + option + "']/parent::div/following-sibling::ul[@class='k-group']/li[@role='treeitem']//span[text()='" + subOption + "']")).Click();

                        break;
                    }
            }
        }

        public void Enter_Criteria(string criteria)
        {
            Thread.Sleep(1500);
            int count = 0;
            while (count <= 2)
            {
                try
                {
                    if (driver.FindElement(By.Id("idAutoPayrollText")).Enabled)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }

             driver.FindElement(By.Id("idAutoPayrollText")).Click(); Thread.Sleep(1000);
             driver.FindElement(By.Id("idAutoPayrollText")).SendKeys(Keys.Space); Thread.Sleep(2500);
             driver.FindElement(By.XPath("//ul[@id='idAutoPayrollText_listbox']//li[contains(text(),'" + criteria + "')]")).Click();
             Thread.Sleep(2500);            
        }

        public void Click_Report_Button(string button)
        {
            Thread.Sleep(1500);
            switch (button)
            {
                case "Add Criteria":
                    {
                       // general.DrawHighlight(reportsPo.elementAddCriteria);
                        Thread.Sleep(500);
                       // ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", reportsPo.elementAddCriteria);
                        reportsPo.elementAddCriteria.Click();
                        break;
                    }
                case "Create All":
                    {
                        Thread.Sleep(500);
                        reportsPo.elementClearAll.Click();
                        break;
                    }
                case "Run Report":
                    {
                        Thread.Sleep(500);
                        //general.DrawHighlight(reportsPo.elementAddCriteria);
                       // ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", reportsPo.elementRunReport);
                         reportsPo.elementRunReport.Click();
                        break;
                    }
            }
         }

    }
}
