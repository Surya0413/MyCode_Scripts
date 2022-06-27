using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using OpenQA.Selenium;
namespace PageObject
{
  public  class PSHDUserManagementPO
    {
        IWebDriver driver = null;
        public PSHDUserManagementPO()
        {
            driver = BrowserHandler.Driver;
        }

        public IWebElement elementPSHDUserManagementFirstName => driver.FindElement(By.Id("firstname"));
        public IWebElement elementPSHDUserManagementLastName => driver.FindElement(By.Id("lastname"));
        public IWebElement elementPSHDUserManagmentDepartmentdrp => driver.FindElement(By.Id("ddlDepartment"));

        public IWebElement elementPSHDUserManagmentMainMenudrp => driver.FindElement(By.XPath("//li[@role='presentation' and @class='dropdown']//a[@class='dropdown-toggle' and @data-toggle='dropdown']"));

        public IWebElement elementPSHDUserManagmentsubmentUserSecurityManagement => driver.FindElement(By.Id("usersecuritymanagement"));

        public IWebElement elementPSHDUserManagmentSearchbtn => driver.FindElement(By.Id("btnSearch"));
        public IWebElement elementPSHDUserManagmentClearSearchbtn => driver.FindElement(By.Id("btnclear"));


        public IWebElement elementPSHDEditUsermanagmentFirstNametxt => driver.FindElement(By.Id("txtfirstname"));
        public IWebElement elementPSHDEditUsermanagmentLastNametxt => driver.FindElement(By.Id("txtlastname"));

    }
}
