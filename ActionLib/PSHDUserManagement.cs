using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using PageObject;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
namespace ActionLib
{
    public class PSHDUserManagement
    {
        IWebDriver driver;
        PSHDUserManagementPO pshdUserManagmentPo;
        General general;

        public PSHDUserManagement()
        {
            driver = BrowserHandler.Driver;
            pshdUserManagmentPo = new PSHDUserManagementPO();
            general = new General();
        }

        private void WiatFor_UserManagementPage()
        {
            int count = 0;
            while (count <= 10)
            {
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
                try
                {
                    if (pshdUserManagmentPo.elementPSHDUserManagmentMainMenudrp.Enabled)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }

        public void UserManagement_Search()
        {
            try
            {
                Click_Menu(DataHandler.Instance.GetParam("Menu")); Thread.Sleep(500);
                pshdUserManagmentPo.elementPSHDUserManagementFirstName.SendKeys(DataHandler.Instance.GetParam("FirstName")); Thread.Sleep(500);
                pshdUserManagmentPo.elementPSHDUserManagementLastName.SendKeys(DataHandler.Instance.GetParam("LastName")); Thread.Sleep(500);

                driver.FindElement(By.XPath("//span[@class='k-dropdown-wrap k-state-default']//span[@class='k-select']")).Click(); Thread.Sleep(800);

                driver.FindElement(By.XPath("//ul[@id='ddlDepartment_listbox']//li[text()='" + DataHandler.Instance.GetParam("Department") + "']")).Click();

                pshdUserManagmentPo.elementPSHDUserManagmentSearchbtn.Click(); Thread.Sleep(1000);

                Validate_GridData(DataHandler.Instance.GetParam("FirstName") + "|" + DataHandler.Instance.GetParam("LastName"));
                Validate_EditUserManagement();


            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        private void Validate_GridData(string validateData)
        {
            WaitFor_GridLoad(validateData.Split('|')[0]);
            foreach (string validString in validateData.Split('|'))
            {
                general.DrawHighlight(driver.FindElement(By.XPath("//div[@id='usergrid']//table[@class='k-selectable']//td[text()='" + validString + "']"))); Thread.Sleep(500);
                Assert.IsTrue(driver.FindElement(By.XPath("//div[@id='usergrid']//table[@class='k-selectable']//td[text()='" + validString + "']")).Displayed); Thread.Sleep(500);
            }
        }

        private void WaitFor_GridLoad(string strngData)
        {
            int count = 0;
            while (count < 5)
            {
                try
                {
                    if (driver.FindElement(By.XPath("//div[@id='usergrid']//table[@class='k-selectable']//td[text()='" + strngData + "']")).Displayed)
                        break;
                }
                catch { }
                count++;
                Thread.Sleep(1500);
            }
        }

        private void Validate_EditUserManagement()
        {
            if (DataHandler.Instance.Any("FirstName"))
            {
                general.DrawHighlight(pshdUserManagmentPo.elementPSHDEditUsermanagmentFirstNametxt);
                Assert.IsTrue(pshdUserManagmentPo.elementPSHDEditUsermanagmentFirstNametxt.GetAttribute("value") == DataHandler.Instance.GetParam("FirstName"));
            }
            if (DataHandler.Instance.Any("LastName"))
            {
                general.DrawHighlight(pshdUserManagmentPo.elementPSHDEditUsermanagmentLastNametxt);
                Assert.IsTrue(pshdUserManagmentPo.elementPSHDEditUsermanagmentLastNametxt.GetAttribute("value") == DataHandler.Instance.GetParam("LastName"));
            }

            if (DataHandler.Instance.Any("Department"))
            {
                general.DrawHighlight(driver.FindElement(By.XPath("//span[@role='option' and @class='k-input']//ancestor::div//label[@id='ddldepartmentedit_label']/following-sibling::span")));
                Assert.IsTrue(driver.FindElement(By.XPath("//span[@role='option' and @class='k-input']//ancestor::div//label[@id='ddldepartmentedit_label']/following-sibling::span")).GetAttribute("innerText") == DataHandler.Instance.GetParam("Department"));
            }

        }


        public void Click_Menu(string Menu)
        {
            WiatFor_UserManagementPage();
            pshdUserManagmentPo.elementPSHDUserManagmentMainMenudrp.Click(); Thread.Sleep(800);
            switch (Menu)
            {
                case "User Security Management":
                    {
                        pshdUserManagmentPo.elementPSHDUserManagmentsubmentUserSecurityManagement.Click();
                        break;
                    }
            }
        }
    }
}
