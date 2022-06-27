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
    public class Show
    {
        IWebDriver driver;
        General general = null;
        ShowPO showPO;

        public Show()
        {
            driver = BrowserHandler.Driver;
            general = new General();
            showPO = new ShowPO();
        }


        private void WaitFor_ShowPage()
        {
            int count = 0;
            while (count <= 6)
            {
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
                try
                {
                    if (showPO.elementdropdownShoMasters.Enabled)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }

        public void Select_Menu(string MainMenu, string SubMenu)
        {
            WaitFor_ShowPage();

            switch (MainMenu)
            {
                case "Show Masters":
                    {
                        //  general.DrawHighlight(showPO.elementdropdownShoMasters);
                        showPO.elementdropdownShoMasters.Click(); Thread.Sleep(500);
                        switch (SubMenu)
                        {
                            case "Show Management":
                                {
                                    //  general.DrawHighlight(showPO.elementShowManagement);
                                    showPO.elementShowManagement.Click(); Thread.Sleep(500);
                                    break;
                                }
                            case "Production Company Management":
                                {
                                    showPO.elementProductionCompanyManagmnt.Click(); Thread.Sleep(500);
                                    break;
                                }
                            case "Pool Management":
                                {
                                    showPO.elementPoolManagmnt.Click(); Thread.Sleep(500);
                                    break;
                                }
                            case "Group Management":
                                {
                                    showPO.elementGroupManagmnt.Click(); Thread.Sleep(500);
                                    break;
                                }
                        }

                        break;
                    }
            }
        }




    }
}
