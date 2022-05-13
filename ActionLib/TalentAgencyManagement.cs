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
   public  class TalentAgencyManagement
    {
        IWebDriver driver;
        General general = null;
        TalentAgencyManagementPO talentagencyManagement;

        public TalentAgencyManagement()
        {
            driver = BrowserHandler.Driver;
            general = new General();
            talentagencyManagement = new TalentAgencyManagementPO();
        }

        private void WaitFor_TalentAgencyManagement()
        {
            int count = 0;
            while (count <= 6)
            {
                try
                {
                    if (talentagencyManagement.elementTalentAgencyManagement.Enabled)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }

           // general.DrawHighlight(talentagencyManagement.elementTalentAgencyManagement);
        }

        private void WaitFor_GridDisplayRows()
        {
            int count = 0;
            while (count <=5)
            {
                try
                {
                    if (driver.FindElement(By.XPath("//div[contains(@class,'k-grid-content')]/table[contains(@aria-activedescendant,'gridTalentAgencies')]//tr[1]")).Displayed)
                        break;

                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
        }

        public void Select_AgencyName(string agencyName)
        {
            WaitFor_TalentAgencyManagement(); WaitFor_GridDisplayRows();

            general.DrawHighlight(driver.FindElement(By.XPath("//td[text()='" + agencyName + "']")));

            driver.FindElement(By.XPath("//td[text()='"+agencyName+"']/parent::tr")).Click();



        }

        public void Search_Agency_By_AgencyCode()
        {
            WaitFor_GridDisplayRows();

            talentagencyManagement.elementSearchAgencyCode.SendKeys(DataHandler.Instance.GetParam("AgencyCode"));

            talentagencyManagement.elementSearch.Click();
        }


        public void Validate_AgencyCode()
        {         
            int count = 0;
            while(count <= 10)
            {
                try
                {
                    if (talentagencyManagement.elementAgencyCode.GetAttribute("value") == DataHandler.Instance.GetParam("AgencyCode"))
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
            Thread.Sleep(1500);

            general.DrawHighlight(talentagencyManagement.elementAgencyCode);
            Assert.AreEqual(talentagencyManagement.elementAgencyCode.GetAttribute("value"), DataHandler.Instance.GetParam("AgencyCode"));

            Assert.IsTrue(driver.FindElement(By.XPath("//table[@role='grid']//td[text()='" + DataHandler.Instance.GetParam("AgencyCode") + "']")).Displayed);

            general.DrawHighlight(driver.FindElement(By.XPath("//table[@role='grid']//td[text()='" + DataHandler.Instance.GetParam("AgencyCode") + "']")));

        }

        public void SearchBy_AgentName()
        {
            WaitFor_GridDisplayRows();

            talentagencyManagement.elementAgencyName.SendKeys(DataHandler.Instance.GetParam("AgencyName"));
            talentagencyManagement.elementSearch.Click();

        }

        public void Validate_AgencyName()
        {

            int count = 0;
            while (count <= 10)
            {
                try
                {
                    if (talentagencyManagement.elementAgencyCode.GetAttribute("value") == DataHandler.Instance.GetParam("AgencyName"))
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
            Thread.Sleep(1500);

            general.DrawHighlight(talentagencyManagement.elementAgencyName);
            Assert.AreEqual(talentagencyManagement.elementAgencyName.GetAttribute("value"), DataHandler.Instance.GetParam("AgencyName"));

            Assert.IsTrue(driver.FindElement(By.XPath("//table[@role='grid']//td[text()='" + DataHandler.Instance.GetParam("AgencyName") + "']")).Displayed);

            general.DrawHighlight(driver.FindElement(By.XPath("//table[@role='grid']//td[text()='" + DataHandler.Instance.GetParam("AgencyName") + "']")));
        }


    }
}
