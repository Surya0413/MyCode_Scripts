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
  public   class Smoke_MasterLookups
    {

        [Test]
        public void Search_Talent_Agency_ByAgentCode()
        {
            try { 
            #region Initialize Class
            SBSLogin login = new SBSLogin();
            HomePage homePage = new HomePage();
            MastersAndLookups masterAndLookups = new MastersAndLookups();
            TalentAgencyManagement talentAgencyManagement = new TalentAgencyManagement();
            #endregion

            #region Data
            DataHandler.Instance.InitializeParameter("AgencyCode", "JINNS");
            #endregion

            login.SBSlogin();
            homePage.Select_Module("Masters and Lookups");
            masterAndLookups.Click_Menu("Maintenance", "Talent Agency Management");
            talentAgencyManagement.Search_Agency_By_AgencyCode();
            talentAgencyManagement.Validate_AgencyCode();
            BrowserHandler.Read_BrowserLog();            
                 
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
        public void Select_AgencyCode()
        {
            try
            {
                #region Initialize Class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                MastersAndLookups masterAndLookups = new MastersAndLookups();
                TalentAgencyManagement talentAgencyManagement = new TalentAgencyManagement();
                #endregion

                #region Read Excel Data               
                DataHandler.Instance.Read_Data_Excel("MasterLookup", "SelectTalentAgency");
                #endregion

                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                masterAndLookups.Click_Menu(DataHandler.Instance.GetParam("MainMenu"), DataHandler.Instance.GetParam("SubMenu"));
                talentAgencyManagement.Select_AgencyName(DataHandler.Instance.GetParam("AgencyCode"));
                talentAgencyManagement.Validate_AgencyCode();

                BrowserHandler.Read_BrowserLog();

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
        public void Search_AgencyName()
        {
            try
            {
                #region Initialize Class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                MastersAndLookups masterAndLookups = new MastersAndLookups();
                TalentAgencyManagement talentAgencyManagement = new TalentAgencyManagement();
                #endregion

                #region Read Excel Data               
                DataHandler.Instance.Read_Data_Excel("MasterLookup", "SearchAgency");
                #endregion

                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                masterAndLookups.Click_Menu(DataHandler.Instance.GetParam("MainMenu"), DataHandler.Instance.GetParam("SubMenu"));
                talentAgencyManagement.SearchBy_AgentName();
                talentAgencyManagement.Validate_AgencyName();
                BrowserHandler.Read_BrowserLog();

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
