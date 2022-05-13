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
    public class Smoke_PayrollTracking
    {

        [Test]
        public void Validate_PayRoll_Documents()
        {
            try
            {
                #region Initialize Class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                PayrollTracking payrollTracking = new PayrollTracking();
                #endregion

                login.SBSlogin();
                homePage.Select_Module("Payroll Tracking");
                DataHandler.Instance.LoopVoidFunction("Documents.xml", () => payrollTracking.Validate_AllDocumnentMenu_Pdf());
                
            }
            catch (Exception ex)
            {
                DataHandler.Instance.InitializeParameter("Error",ex.Message);
                throw new Exception();
            }
            finally
            {
                BrowserHandler.CloseAllDrivers();
            }
        }

        [Test]
        public void Validate_PayRoll_TaxIncentive_Instructions()
        {
            try
            { 
            #region Initialize Class
            SBSLogin login = new SBSLogin();
            HomePage homePage = new HomePage();
            PayrollTracking payrollTracking = new PayrollTracking();
            #endregion

            login.SBSlogin();
            homePage.Select_Module("Payroll Tracking");
            DataHandler.Instance.LoopVoidFunction("TaxIncentiveInstruction.xml", () => payrollTracking.Validate_AllTaxIncentivInstruction_Pdf());
            
            }
            catch (Exception ex)
            {
                DataHandler.Instance.InitializeParameter("Error", ex.Message+" "+ex.GetType().FullName.Replace("\"", ""));
                throw new Exception();
            }
            finally
            {
                BrowserHandler.CloseAllDrivers();
            }
        }

        [Test]
        public void Validate_PayRoll_StateForm()
        {
            try
            { 
            #region Initialize Class
            SBSLogin login = new SBSLogin();
            HomePage homePage = new HomePage();
            PayrollTracking payrollTracking = new PayrollTracking();
            #endregion

            login.SBSlogin();
            homePage.Select_Module("Payroll Tracking");
            DataHandler.Instance.LoopVoidFunction("StateForms.xml", () => payrollTracking.Validate_AllStateForm_Pdf());
            
            }
            catch (Exception ex)
            {
                DataHandler.Instance.InitializeParameter("Error",ex.Message);
                throw new Exception();
            }
            finally
            {
                BrowserHandler.CloseAllDrivers();
            }
        }

        [Test]
        public void Report_Accounting()
        {
            try
            { 
            #region Initialize Class
            SBSLogin login = new SBSLogin();
            HomePage homePage = new HomePage();
            Reports reports = new Reports();
            ReportViewer reportViewer = new ReportViewer();
            #endregion

            login.SBSlogin();
            homePage.Select_Module("Report");
            reports.Select_Report_Option("Accounting", "DAR Journal Entry");
            reports.Enter_Criteria("AD4 - QA - NEW KINETIC, LLC");
            reports.Click_Report_Button("Add Criteria");
            reports.Click_Report_Button("Run Report");
            reportViewer.Validate_Window();
            reportViewer.Enter_Credentails();
            reportViewer.Validate_ReportPage();
            
            }
            catch (Exception ex)
            {
                DataHandler.Instance.InitializeParameter("Error",ex.Message.Replace("\"","").Replace ("\'",""));
                throw new Exception();
            }
            finally
            {
                BrowserHandler.CloseAllDrivers();
            }
        }

      //  [Test]
        public void Divisions()
        {
            try
            {
                int z = 1;
                int i = z / 0;
            }
            catch (Exception ex)
            {
                DataHandler.Instance.InitializeParameter("Error", ex.Message + " " + ex.GetType().FullName.Replace("\"",""));
                throw new Exception();
            }
            finally
            {
                BrowserHandler.CloseAllDrivers();
            }
        }


        [Test]
        public void Validate_PayRollTools()
        {
            try
            {
                #region Initialize Class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                PayrollTracking payrollTracking = new PayrollTracking();
                #endregion

                login.SBSlogin();
                homePage.Select_Module("Payroll Tracking");
                DataHandler.Instance.LoopVoidFunction("PayRollTools.xml", () => payrollTracking.Validate_PayrollTools());

            }
            catch (Exception ex)
            {
                DataHandler.Instance.InitializeParameter("Error", ex.Message);
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
