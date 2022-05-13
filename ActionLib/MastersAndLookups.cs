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
  public  class MastersAndLookups
    {
            IWebDriver driver;
            General general = null;
            MastersAndLookupsPO masterAndLookups;

            public MastersAndLookups()
            {
                driver = BrowserHandler.Driver;
                general = new General();
                masterAndLookups = new MastersAndLookupsPO();

            }


        private void WaitFor_MasterAndlookupPage()
        {
            int count = 0;
            while (count <= 6)
            {
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
                try
                {
                    if (masterAndLookups.elementMaintenace.Enabled)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }

        public void Click_Menu(string Menu, string subMenu)
        {
            WaitFor_MasterAndlookupPage();
            switch(Menu)
            {
                 case "Maintenance":
                    {
                        masterAndLookups.elementMaintenace.Click();Thread.Sleep(500);
                        switch (subMenu)
                        {
                            case "Talent Agency Management":
                                {
                                    masterAndLookups.elementTalentAgencyManagement.Click(); Thread.Sleep(500);
                                    break;
                                }
                        }

                        break;
                    }
            }
        }



    }
}
