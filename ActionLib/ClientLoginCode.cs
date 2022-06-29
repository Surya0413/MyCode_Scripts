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
    public class ClientLoginCode
    {

        IWebDriver driver;


        public ClientLoginCode()
        {
            driver = BrowserHandler.Driver;
        }

        private void WaitForCodepage()
        {
            int count = 0;
            while (count <= 8)
            {
                try
                {
                    if (driver.FindElement(By.XPath("//a[text()='Send code']")).Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
        }

        public void Click_SendCode()
        {
            WaitForCodepage();
            driver.FindElement(By.XPath("//a[text()='Send code']")).Click();

        }



    }
}
