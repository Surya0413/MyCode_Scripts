using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Core;
using ActionLib;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using STContext = NUnit.Framework.TestContext;
using System.IO;
using System.Diagnostics;
namespace ShowbizStudio_Scripts
{
    [TestFixture]
    public class PSHDUserManagement
    {


        [Test]
        public void UserManagement_Search()
        {
            try
            {
                #region Initialize Class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                ActionLib.PSHDUserManagement pshdUserManagement = new ActionLib.PSHDUserManagement();
                DataHandler.Instance.InitializeParameter("Module", "PSHD");
                DataHandler.Instance.InitializeParameter("Menu", "User Security Management");
                #endregion



                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                DataHandler.Instance.Read_TableData_Excel("MasterLookup", "Sheet2", () => pshdUserManagement.UserManagement_Search());
            }
            catch (Exception ex)
            {
                DataHandler.Instance.InitializeParameter("Error", ex.Message.Replace("\"", "").Replace("\'", ""));
                throw new Exception();
            }
            finally
            {
                BrowserHandler.CloseAllDrivers();
            }
        }

        [Test]
        public void UserManagement_SearchExcel()
        {
            try
            {
                #region Initialize Class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                ActionLib.PSHDUserManagement pshdUserManagement = new ActionLib.PSHDUserManagement();
                DataHandler.Instance.InitializeParameter("Module", "PSHD");
                DataHandler.Instance.InitializeParameter("Menu", "User Security Management");
                DataHandler.Instance.Read_Data_Excel("MasterLookup", "Sheet3");
                #endregion


                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                pshdUserManagement.UserManagement_Search();

            }
            catch (Exception ex)
            {
                DataHandler.Instance.InitializeParameter("Error", ex.Message.Replace("\"", "").Replace("\'", ""));
                throw new Exception();
            }
            finally
            {
                BrowserHandler.CloseAllDrivers();
            }
        }





        [SetUp]
        public void Initialize()
        {
            testContextInstance = STContext.CurrentContext;
            DataHandler.Instance.InitializeParameter("ResultsDirectory", NUnit.Framework.TestContext.CurrentContext.TestDirectory);
            DataHandler.Instance.ImportData(ConfigurationManager.AppSettings["ParametersPath"] + "Parameters.xml");
            BrowserHandler.InitBrowser();
            BrowserHandler.LoadApplication();
            GnerateReports.Start();
        }


        [TearDown]
        public void ClearInitialize()
        {
            GnerateReports.CreateReport(testContextInstance);
            DataHandler.Instance.ClearDictionary();
        }


        private STContext testContextInstance;
        public STContext TeContext
        {
            get { return testContextInstance; }
            set
            {
                testContextInstance = value;  //  TeContext = value;  
            }
        }


    }
}
