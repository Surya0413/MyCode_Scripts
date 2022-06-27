using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using PageObject;
using OpenQA.Selenium;
using System.Threading;
namespace ActionLib
{
  public   class Adjustments
    {
        IWebDriver driver;
        AdjustmentsPO adjustmentPo;
        General genral;

        public Adjustments()
        {
            driver = BrowserHandler.Driver;
            genral = new General();
            adjustmentPo = new AdjustmentsPO();
        }

        private void WaitFor_Adjustments()
        {
            int count = 0;
            while (count <= 14)
            {
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
                try
                {
                    if (adjustmentPo.elementAdjustmentPopupCustomertxt.Enabled)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }

        public void Close_AdjustmentPopup()
        {
            WaitFor_Adjustments();
            // genral.DrawHighlight(driver.FindElement(By.XPath("//span[@id='adjustmentSearchPopupWindow_wnd_title']//following-sibling::div[@class='k-window-actions']")));Thread.Sleep(5000);
            adjustmentPo.elementAdjustmentPopuClosebtn.Click();
        }

        private void waitFor_ListPanelCustomer()
        {
            int count = 0;
            while (count < 3)
            {

                try
                {
                    if (adjustmentPo.elementAdjustmentUlListPanel.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }

        }

        private void waitFor_ListPanelCompany()
        {
            int count = 0;
            while (count < 3)
            {

                try
                {
                    if (adjustmentPo.elementAdjustmentParollCompmanyListpanel.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }

        }

        private void waitFor_ListPanelcbAdjustmentList()
        {
            int count = 0;
            while (count < 3)
            {

                try
                {
                    if (adjustmentPo.elementAdjustmentcbList.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }

        }

        public void Enter_CustomerDetails()
        {
            WaitFor_Adjustments();
            adjustmentPo.elementAdjustmentPopupCustomertxt.Click(); Thread.Sleep(500);
            adjustmentPo.elementAdjustmentPopupCustomertxt.SendKeys(" "); Thread.Sleep(800);

            waitFor_ListPanelCustomer();
            driver.FindElement(By.XPath("//ul[@id='autoCustomer_listbox' and @aria-hidden='false']//li[contains(text(),'" + DataHandler.Instance.GetParam("Customer") + "')]")).Click();

            adjustmentPo.elementAdjsutmentPayrollCompanytxt.Click(); Thread.Sleep(500);
            adjustmentPo.elementAdjsutmentPayrollCompanytxt.SendKeys(" "); Thread.Sleep(800);

            waitFor_ListPanelCompany();
            //  genral.DrawHighlight(adjustmentPo.elementAdjustmentParollCompmanyListpanel);
            driver.FindElement(By.XPath("//ul[@id='cboPayrollCompany_listbox' and @aria-hidden='false']//li[contains(text(),'" + DataHandler.Instance.GetParam("Company") + "')]")).Click();
            // driver.FindElement(By.XPath("//ul[@id='cboPayrollCompany_listbox' and @aria-hidden='false']//li")).Click();

            adjustmentPo.elementAdjustmenSearchbtn.Click();

            WiatFor_LoadGrid(); Thread.Sleep(1000);
            genral.DrawHighlight(driver.FindElements(By.XPath("//div[contains(@class,'k-grid-content')]/table//input[@type='checkbox' and @class='k-checkbox']"))[0]);
            driver.FindElements(By.XPath("//div[contains(@class,'k-grid-content')]/table//input[@type='checkbox' and @class='k-checkbox']"))[0].Click();

            adjustmentPo.elmentAdjustmentcbAdjuTxt.Click(); Thread.Sleep(500);
            adjustmentPo.elmentAdjustmentcbAdjuTxt.SendKeys(" "); Thread.Sleep(800);
            waitFor_ListPanelcbAdjustmentList();


            driver.FindElement(By.XPath("//ul[@id='cbAdjustmentType_listbox']//li[text()='Pay Rate Increase Only']")).Click();

            adjustmentPo.elemmentAdjustmentCreateNewAdjustBtn.Click();
        }

        private void WiatFor_LoadGrid()
        {
            int count = 0;
            while (count < 10)
            {
                try
                {
                    if (driver.FindElements(By.XPath("//div[contains(@class,'k-grid-content')]/table//input[@type='checkbox' and @class='k-checkbox']")).Count > 0)
                        break;
                }
                catch { }
                count++;
                Thread.Sleep(2000);
            }
        } 
    }
}
