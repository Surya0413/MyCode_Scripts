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
   public  class Adjustments
    {
        [Test]
        public void Smoke_Adjustment_Search()
        {
            try
            {
                #region Initialize class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                ActionLib.Adjustments adjustment = new ActionLib.Adjustments();
                #endregion

                #region data 
                DataHandler.Instance.InitializeParameter("Module", "Adjustments");
                DataHandler.Instance.InitializeParameter("Customer", "34148: PROJECT SILAS");
                DataHandler.Instance.InitializeParameter("Company", "MPF - QA - Media Services");

                #endregion

                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                adjustment.Enter_CustomerDetails();


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
