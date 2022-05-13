using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PageObject;
using Core;
using System.Threading;

namespace ActionLib
{
  public  class SBSLogin
    {
        SBSloginpo sbsLoginPo;
        IWebDriver driver;
        public SBSLogin ()
        {
            driver = BrowserHandler.Driver;
            sbsLoginPo = new SBSloginpo();
        }

        private void WaitFor_LoginPage()
        {
            int count = 0;
            while (count<5)
            {
                try
                {
                    if (sbsLoginPo.elementUsername.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
        }

        public void SBSlogin()
        {
            WaitFor_LoginPage();

            sbsLoginPo.elementUsername.Click();
            sbsLoginPo.elementUsername.Clear();
            sbsLoginPo.elementUsername.SendKeys(DataHandler.Instance.GetParam("Username"));Thread.Sleep(500);

            sbsLoginPo.elementPassword.Click();
            sbsLoginPo.elementPassword.Clear();
            sbsLoginPo.elementPassword.SendKeys(DataHandler.Instance.GetParam("Password")); Thread.Sleep(500);

            sbsLoginPo.elementSubmit.Click();

        }

    }
}
