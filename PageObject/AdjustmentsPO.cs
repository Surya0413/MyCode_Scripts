using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using OpenQA.Selenium;
namespace PageObject
{
public   class AdjustmentsPO
    {
        IWebDriver driver = null;
        public AdjustmentsPO()
        {
            driver = BrowserHandler.Driver;
        }

        public IWebElement elementAdjustmentPopupCustomertxt => driver.FindElement(By.XPath("//div[@id='adjustmentSearchPopupWindow']//input[@id='autoCustomer']"));

        public IWebElement elementAdjustmentPopuClosebtn => driver.FindElement(By.XPath("//span[@id='adjustmentSearchPopupWindow_wnd_title']//following-sibling::div[@class='k-window-actions']/a"));

        public IWebElement elementAdjustmentUlListPanel => driver.FindElement(By.XPath("//ul[@id='autoCustomer_listbox' and @aria-hidden='false']"));

        public IWebElement elementAdjsutmentPayrollCompanytxt => driver.FindElement(By.XPath("//input[@aria-controls='cboPayrollCompany_listbox']"));

        public IWebElement elementAdjustmentParollCompmanyListpanel => driver.FindElement(By.XPath("//ul[@id='cboPayrollCompany_listbox' and @aria-hidden='false']"));

        public IWebElement elmentAdjustmentcbAdjuTxt => driver.FindElement(By.XPath("//input[@aria-controls='cbAdjustmentType_listbox']"));

        public IWebElement elementAdjustmentcbList => driver.FindElement(By.Id("cbAdjustmentType_listbox"));

        public IWebElement elemmentAdjustmentCreateNewAdjustBtn => driver.FindElement(By.Id("btnNewAdjustment"));
        public IWebElement elementAdjustmenSearchbtn => driver.FindElement(By.Id("btnSearch"));
    }
}
