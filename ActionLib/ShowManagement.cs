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
    public class ShowManagement
    {
        IWebDriver driver;
        General general = null;
        ShowManagementPO showManagementPO;

        public ShowManagement()
        {
            driver = BrowserHandler.Driver;
            general = new General();
            showManagementPO = new ShowManagementPO();
        }


        private void WaitFor_ShowPage()
        {
            int count = 0;
            while (count <= 6)
            {
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
                try
                {
                    if (showManagementPO.elementShowManagmentHeader.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }

        public void Enter_ShowCode()
        {
            WaitFor_ShowPage();
            showManagementPO.elementShowCode.SendKeys(DataHandler.Instance.GetParam("ShowCode"));
        }

        public void Click_Search()
        {
            showManagementPO.elementbtnSearch.Click();
        }

        public void Enter_ShowName()
        {
            WaitFor_ShowPage();
            showManagementPO.elementShowMangName.SendKeys(DataHandler.Instance.GetParam("ShowName"));
        }

        public void Validate_ShowName()
        {

            int count = 0;
            while (count <= 6)
            {
                try
                {
                    if (showManagementPO.elementShowMangNameText.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
            Assert.IsTrue(showManagementPO.elementShowMangNameText.GetAttribute("value").Contains(DataHandler.Instance.GetParam("ShowName")));

        }

        public void Validate_ShowCode()
        {

            int count = 0;
            while (count <= 6)
            {
                try
                {
                    if (showManagementPO.elementShowManagCodeText.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
            Assert.AreEqual(showManagementPO.elementShowManagCodeText.GetAttribute("value"), DataHandler.Instance.GetParam("ShowCode"));

        }

    }
}
