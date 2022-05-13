using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using PageObject;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;

namespace ActionLib
{
   public  class PayrollTracking
    {
        IWebDriver driver;
        General general;

        public PayrollTracking()
        {
            driver = BrowserHandler.Driver;
            general = new General();
            
        }

        private void WiatFor_HomePage()
        {
            int count = 0;
            int counts = driver.WindowHandles.Count;
            while (count <= 6)
            {
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
                try
                {
                    if (driver.FindElement(By.XPath("//b[text()='DOCUMENTS']")).Enabled)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }


        public  void Validate_AllDocumnentMenu_Pdf()
        {

            WiatFor_HomePage();
            //Main Menu
            driver.FindElement(By.XPath("//b[text()='" + DataHandler.Instance.GetParam("MainMenu", "") + "']")).Click(); Thread.Sleep(1000);

            //Sub Menu
            general.DrawHighlight(driver.FindElement(By.XPath("//ul[@class='dropdown-menu show']//a[contains(text(),'" + DataHandler.Instance.GetParam("SubMenu", "") + "')]"))); Thread.Sleep(1500);
            driver.FindElement(By.XPath("//ul[@class='dropdown-menu show']//a[contains(text(),'" + DataHandler.Instance.GetParam("SubMenu", "") + "')]")).Click();

            // Wait For PDF page
            int count = 0;
            while (count <= 3)
            {
                if (driver.WindowHandles.Count == 3)
                    break;

                Thread.Sleep(1500);
                count++;
            }



            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);

            Assert.IsTrue(driver.Url.Contains(DataHandler.Instance.GetParam("PDF", ""))); Thread.Sleep(1500);

            driver.Close(); Thread.Sleep(1000);

            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }

        public  void Validate_AllTaxIncentivInstruction_Pdf()
        {

            WiatFor_HomePage();
            //Main Menu
            driver.FindElement(By.XPath("//b[text()='" + DataHandler.Instance.GetParam("MainMenu", "") + "']")).Click(); Thread.Sleep(1000);

            //Sub Menu
          //  general.DrawHighlight(driver.FindElement(By.XPath("//ul[@class='dropdown-menu show']//a[contains(text(),'" + DataHandler.Instance.GetParam("SubMenu", "") + "')]"))); Thread.Sleep(1500);
            driver.FindElement(By.XPath("//ul[@class='dropdown-menu show']//a[contains(text(),'" + DataHandler.Instance.GetParam("SubMenu", "") + "')]")).Click();

            // Wait For PDF page
            int count = 0;
            while (count <= 3)
            {
                if (driver.WindowHandles.Count == 3)
                    break;

                Thread.Sleep(1500);
                count++;
            }



            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);

            Assert.IsTrue(driver.Url.Contains(DataHandler.Instance.GetParam("PDF", ""))); Thread.Sleep(1500);

            driver.Close(); Thread.Sleep(1000);

            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }


        public void Validate_AllStateForm_Pdf()
        {
            WiatFor_HomePage();
            //Main Menu
            driver.FindElement(By.XPath("//b[text()='" + DataHandler.Instance.GetParam("MainMenu", "") + "']")).Click(); Thread.Sleep(1000);

            //Sub Menu
          //  general.DrawHighlight(driver.FindElement(By.XPath("//ul[@class='dropdown-menu show']//a[contains(text(),'" + DataHandler.Instance.GetParam("SubMenu", "") + "')]"))); Thread.Sleep(1500);
            driver.FindElement(By.XPath("//ul[@class='dropdown-menu show']//a[contains(text(),'" + DataHandler.Instance.GetParam("SubMenu", "") + "')]")).Click(); Thread.Sleep(1000);

            //Inner Menu
            driver.FindElement(By.XPath("//ul[@class='dropdown-menu show']//a[contains(text(),'" + DataHandler.Instance.GetParam("SubMenu", "") + "')]/following-sibling::ul[@class='dropdown-menu']//a[contains(text(),'" + DataHandler.Instance.GetParam("InnerMenu", "") + "')]")).Click();
            // Wait For PDF page
            int count = 0;
            while (count <= 3)
            {
                if (driver.WindowHandles.Count == 3)
                    break;

                Thread.Sleep(1500);
                count++;
            }



            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);

            Assert.IsTrue(driver.Url.Contains(DataHandler.Instance.GetParam("PDF", ""))); Thread.Sleep(1500);

            driver.Close(); Thread.Sleep(1000);

            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }


        public void Validate_PayrollTools()
        {
            WiatFor_HomePage();
            //Main Menu
            driver.FindElement(By.XPath("//b[text()='" + DataHandler.Instance.GetParam("MainMenu", "") + "']")).Click(); Thread.Sleep(1000);

            //Sub Menu
            //  general.DrawHighlight(driver.FindElement(By.XPath("//ul[@class='dropdown-menu show']//a[contains(text(),'" + DataHandler.Instance.GetParam("SubMenu", "") + "')]"))); Thread.Sleep(1500);
            driver.FindElement(By.XPath("//ul[@class='dropdown-menu show']//a[contains(text(),'" + DataHandler.Instance.GetParam("SubMenu", "") + "')]")).Click(); Thread.Sleep(1000);

            int count = 0;
            while (count <= 3)
            {
                if (driver.WindowHandles.Count == 3)
                    break;

                Thread.Sleep(1500);
                count++;
            }

            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);

            count = 0;

            if (DataHandler.Instance.GetParam("SubMenu", "") == "Payroll Tracking" || DataHandler.Instance.GetParam("SubMenu", "") == "TiM-Starts To Be Processed")
            {
                while (count < 3)
                {
                    try
                    {
                        
                        if (driver.FindElement(By.XPath("//label[contains(text(),'" + DataHandler.Instance.GetParam("Validate", "") + "')]")).Displayed)
                            break;

                    }
                    catch { }
                    count++;
                    Thread.Sleep(1500);
                }

                general.DrawHighlight(driver.FindElement(By.XPath("//label[contains(text(),'" + DataHandler.Instance.GetParam("Validate", "") + "')]"))); Thread.Sleep(1500);

                Assert.IsTrue(driver.FindElement(By.XPath("//label[contains(text(),'" + DataHandler.Instance.GetParam("Validate", "") + "')]")).Displayed); Thread.Sleep(1500);
            }
            else if(DataHandler.Instance.GetParam("SubMenu", "") == "Coordinator Management")
            {
                while (count < 3)
                {
                    try
                    {
                        if (driver.FindElement(By.XPath("//a[contains(text(),'" + DataHandler.Instance.GetParam("Validate", "") + "')]")).Displayed)
                            break;

                    }
                    catch { }
                    count++;
                    Thread.Sleep(1500);
                }
                general.DrawHighlight(driver.FindElement(By.XPath("//a[contains(text(),'" + DataHandler.Instance.GetParam("Validate", "") + "')]")));
                Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'" + DataHandler.Instance.GetParam("Validate", "") + "')]")).Displayed); Thread.Sleep(1500);
            }
            else
            {
                while (count < 3)
                {
                    try
                    {
                        if (driver.FindElement(By.XPath("//h2[text()='" + DataHandler.Instance.GetParam("Validate", "") + "']")).Displayed)
                            break;

                    }
                    catch { }
                    count++;
                    Thread.Sleep(1500);
                }
                general.DrawHighlight(driver.FindElement(By.XPath("//h2[text()='" + DataHandler.Instance.GetParam("Validate", "") + "']")));
                Assert.IsTrue(driver.FindElement(By.XPath("//h2[text()='" + DataHandler.Instance.GetParam("Validate", "") + "']")).Displayed); Thread.Sleep(1500);
            }

            driver.Close(); Thread.Sleep(1000);

            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);

        }

    }
 }
