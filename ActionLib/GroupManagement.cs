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
    public class GroupManagement
    {

        IWebDriver driver;
        General general = null;
        GroupManagementPO groupManagementPo;

        public GroupManagement()
        {
            driver = BrowserHandler.Driver;
            general = new General();
            groupManagementPo = new GroupManagementPO();
        }

        private void WaitFor_PoolManagemnet()
        {
            int count = 0;
            while (count < 8)
            {
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
                try
                {
                    if (groupManagementPo.elementGroupSearchtxt.Enabled)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);

        }

        public void Enter_ShowName()
        {
            WaitFor_PoolManagemnet();
            groupManagementPo.elementGroupSearchtxt.SendKeys(DataHandler.Instance.GetParam("GroupName"));
        }

        public void Click_Search()
        {
            groupManagementPo.elementGrupSearchbtn.Click();
        }

        public void ClickOn_Deatils()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//table[@role='grid']//td[contains(text(),'" + DataHandler.Instance.GetParam("GroupName") + "')]//following-sibling::td/a")).Click();
        }
        //public void ClickOnCode_Deatils()
        //{
        //    Thread.Sleep(2000);
        //    driver.FindElement(By.XPath("//table[@role='grid']//tr//td/a[text()='Details']")).Click();
        //}

        public void Click_GroupManagmentTabs(string tabName)
        {
            WaitFor_PoolManagemnet();
            // general.DrawHighlight(driver.FindElement(By.XPath("//ul[@id='tabs']//li/a[text()='" + tabName + "']")));
            driver.FindElement(By.XPath("//ul[@id='tabs']//li/a[text()='" + tabName + "']")).Click();

        }

        public void Validate_GroupName()
        {
            // general.DrawHighlight(driver.FindElement(By.Id("txtGroupName")));
            //string ss = driver.FindElement(By.Id("txtGroupName")).GetAttribute("value");
            Assert.IsTrue(driver.FindElement(By.Id("txtGroupName")).GetAttribute("value").Contains(DataHandler.Instance.GetParam("GroupName")));
        }

        public void Enter_GroupCode()
        {
            WaitFor_PoolManagemnet();
            groupManagementPo.elementGoupSearchCodetxt.SendKeys(DataHandler.Instance.GetParam("GroupCode"));

        }

    }
}
