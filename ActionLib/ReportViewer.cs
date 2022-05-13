using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using PageObject;
using OpenQA.Selenium;
using System.Threading;
using AutoIt;
using NUnit.Framework;

namespace ActionLib
{
   public  class ReportViewer
    {

        IWebDriver driver;
        General general = null;

        public ReportViewer()
        {
            driver = BrowserHandler.Driver;
            general = new General();
           
        }
        public void WaitFor_CredentailReport()
        {

            int count = 0;
            while (count <= 2)
            {
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);

                try
                {
                    if (driver.Url.Contains("ReportViewer"))
                        break;
                }
                catch { }
                count++;

                Thread.Sleep(1500);
            }

            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }


        public void Validate_Window()
        {
            WaitFor_CredentailReport();
           
            int count = 0;
            while (count <= 3)
            {
                try
                {
                    if (AutoItX.WinGetTitle("Windows Security").Equals("Windows Security"))
                        break;
                 }
                catch { }

                Thread.Sleep(1500);
                count++;
            }

            
          
        }

        public void Enter_Credentails()
        {
            Thread.Sleep(1000);
            AutoItX.Send(DataHandler.Instance.GetParam("RUsername")); Thread.Sleep(500);
            AutoItX.Send("{TAB}"); Thread.Sleep(500);
            AutoItX.Send(DataHandler.Instance.GetParam("RPassword")); Thread.Sleep(500);
            AutoItX.Send("{TAB}"); Thread.Sleep(500);
            AutoItX.Send("{ENTER}"); Thread.Sleep(500);
           
            
        }

        private void WaitFor_ReportPage()
        {
            int count = 0;
             while (count <=8)
            {
                try
                {
                    if (driver.FindElement(By.XPath("//div[contains(text(),'Page 1 of')]")).Displayed)
                        break;

                }catch { }
                Thread.Sleep(1500);
                count++;
            }
        }

        /// <summary>
        /// Validate the report page with 'Page 1 of'
        /// </summary>
        public void Validate_ReportPage()
        {
            WaitFor_ReportPage();
            general.DrawHighlight(driver.FindElement(By.XPath("//div[contains(text(),'Page 1 of')]")));
            Assert.IsTrue(driver.FindElement(By.XPath("//div[contains(text(),'Page 1 of')]")).Displayed);
        }


    }
}
