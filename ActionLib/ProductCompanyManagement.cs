using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using PageObject;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
namespace ActionLib
{
    public class ProductCompanyManagement
    {
        IWebDriver driver;
        ProductionCompanyManagementPO productCompanyManagementpo;

        public ProductCompanyManagement()
        {
            driver = BrowserHandler.Driver;
            productCompanyManagementpo = new ProductionCompanyManagementPO();
        }

        private void WaitFor_HomePage()
        {
            int count = 0;
            while (count <= 10)
            {
                driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
                try
                {
                    if (productCompanyManagementpo.elementProduCompanyTitle.Displayed)
                        break;
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }

        public void Enter_ProdCompaName()
        {
            WaitFor_HomePage();
            productCompanyManagementpo.elementProdCompanyName.SendKeys(DataHandler.Instance.GetParam("ProductionName"));
        }

        public void Enter_ProdCompaCode()
        {
            WaitFor_HomePage();
            productCompanyManagementpo.elementProdCompanyCode.SendKeys(DataHandler.Instance.GetParam("ProductionCode"));
        }

        public void Click_SearchButton()
        {
            productCompanyManagementpo.elementProductCompanySearchbtn.Click();
        }


        public void Validate_ProdCompanyName()
        {
            int count = 0;
            bool flag = false;
            while (count <= 8)
            {
                try
                {

                    if (productCompanyManagementpo.elementProductCompanysearchNameText.GetAttribute("value") == DataHandler.Instance.GetParam("ProductionName"))
                    {
                        flag = true;
                        //string ss = productCompanyManagementpo.elementProductCompanysearchNameText.GetAttribute("value");
                        break;
                    }
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }

            Assert.IsTrue(flag);

        }


        public void Validate_ProdCompanyCode()
        {
            int count = 0;
            bool flag = false;
            while (count <= 8)
            {
                try
                {

                    if (productCompanyManagementpo.elementProductCompnaySearchCodeText.GetAttribute("value") == DataHandler.Instance.GetParam("ProductionCode"))
                    {
                        flag = true;
                        string ss = productCompanyManagementpo.elementProductCompnaySearchCodeText.GetAttribute("value");
                        break;
                    }
                }
                catch { }
                Thread.Sleep(1500);
                count++;
            }

            Assert.IsTrue(flag);

        }



    }
}
