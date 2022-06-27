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
using OpenQA.Selenium.Interactions;
namespace ActionLib
{
    public class PoolManagement
    {

        //ul[@id='txtPoolSearch_listbox']//li[text()='152 - DISCOVERY']

        IWebDriver driver;
        General general = null;
        PoolManagementPO poolManagementPo;

        public PoolManagement()
        {
            driver = BrowserHandler.Driver;
            general = new General();
            poolManagementPo = new PoolManagementPO();
        }

        private void WaitFor_PoolManagemnet()
        {
            int count = 0;
            while (count < 8)
            {
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
                try
                {
                    if (poolManagementPo.elemmentPoolSearchBtn.Enabled)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }


        public void Enter_PoolData()
        {
            WaitFor_PoolManagemnet();
            poolManagementPo.elementPoolSearchText.Click(); Thread.Sleep(500);
            poolManagementPo.elementPoolSearchText.SendKeys(" ");
            poolManagementPo.elementPoolSearchText.SendKeys(Keys.Space); Thread.Sleep(2500);
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("//ul[@id='txtPoolSearch_listbox']//li[text()='" + DataHandler.Instance.GetParam("PoolCode") + "']"))); Thread.Sleep(1000);
            action.Click();
            action.Perform();
            //driver.FindElement(By.XPath("//ul[@id='txtPoolSearch_listbox']//li[text()='" + DataHandler.Instance.GetParam("PoolCode") + "']")).Click();
        }

        public void Click_BtnSearch()
        {
            poolManagementPo.elemmentPoolSearchBtn.Click();
        }


        public void Validate_SearchData()
        {
            //elementPoolResultSearchText

            int count = 0; bool flag = false;
            while (count < 8)
            {
                try
                {
                    if (poolManagementPo.elementPoolResultSearchText.GetAttribute("value") == DataHandler.Instance.GetParam("PoolDiscription"))
                    {
                        general.DrawHighlight(poolManagementPo.elementPoolResultSearchText);
                        // string s = poolManagementPo.elementPoolResultSearchText.GetAttribute("value");
                        flag = true;
                        break;
                    }
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }


            Assert.IsTrue(flag);
        }

        private void WaitFor_GridLoad()
        {
            int coun = 0;
            while (coun < 8)
            {
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
                try
                {
                    if (driver.FindElements(By.XPath("//table[@role='grid' and @class='k-selectable']//tr")).ToList().Count >= 1)
                        break;
                }
                catch { }
                coun++;
                Thread.Sleep(1500);
            }

            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }

        public void SelectPool_InGrid()
        {
            WaitFor_GridLoad();
            driver.FindElement(By.XPath("//table[@role='grid' and @class='k-selectable']//tr/td[text()='" + DataHandler.Instance.GetParam("Poolcode") + "']/following::td[text()='" + DataHandler.Instance.GetParam("PoolDiscription") + "']")).Click();

        }

    }
}
