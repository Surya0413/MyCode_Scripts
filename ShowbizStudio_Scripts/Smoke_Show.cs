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
    public class Smoke_Show
    {
        [Test]
        public void Search_ShowByCode()
        {
            try
            {
                #region Initialize Class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                Show show = new Show();
                ShowManagement showManagement = new ShowManagement();
                #endregion

                #region Data
                DataHandler.Instance.InitializeParameter("Module", "Show");
                DataHandler.Instance.InitializeParameter("MainMenu", "Show Masters");
                DataHandler.Instance.InitializeParameter("SubMenu", "Show Management");
                DataHandler.Instance.InitializeParameter("ShowCode", "30301");
                #endregion

                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                show.Select_Menu(DataHandler.Instance.GetParam("MainMenu"), DataHandler.Instance.GetParam("SubMenu"));
                showManagement.Enter_ShowCode();
                showManagement.Click_Search();
                showManagement.Validate_ShowCode();

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
        public void Search_ShowByName()
        {
            try
            {
                #region Initailize Class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                Show show = new Show();
                ShowManagement showManagement = new ShowManagement();
                #endregion

                #region Data
                DataHandler.Instance.InitializeParameter("Module", "Show");
                DataHandler.Instance.InitializeParameter("MainMenu", "Show Masters");
                DataHandler.Instance.InitializeParameter("SubMenu", "Show Management");
                DataHandler.Instance.InitializeParameter("ShowName", "COSAMERICA INC.");
                #endregion 

                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                show.Select_Menu(DataHandler.Instance.GetParam("MainMenu"), DataHandler.Instance.GetParam("SubMenu"));
                showManagement.Enter_ShowName();
                showManagement.Click_Search();
                showManagement.Validate_ShowName();
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
        public void Search_ProductionCompanyManagement()
        {
            try
            {
                #region Initailize Class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                Show show = new Show();
                ProductCompanyManagement productionCompanyManagement = new ProductCompanyManagement();
                #endregion

                #region Data
                DataHandler.Instance.InitializeParameter("Module", "Show");
                DataHandler.Instance.InitializeParameter("MainMenu", "Show Masters");
                DataHandler.Instance.InitializeParameter("SubMenu", "Production Company Management");
                DataHandler.Instance.InitializeParameter("ProductionName", "COSAMERICA INC.");
                #endregion 

                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                show.Select_Menu(DataHandler.Instance.GetParam("MainMenu"), DataHandler.Instance.GetParam("SubMenu"));
                productionCompanyManagement.Enter_ProdCompaName();
                productionCompanyManagement.Click_SearchButton();
                productionCompanyManagement.Validate_ProdCompanyName();

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
        public void Search_ProductionCompanyManagmentCode()
        {
            try
            {

                #region Initialize class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                Show show = new Show();
                ProductCompanyManagement productionCompanyManagement = new ProductCompanyManagement();
                #endregion

                #region data 
                DataHandler.Instance.InitializeParameter("Module", "Show");
                DataHandler.Instance.InitializeParameter("MainMenu", "Show Masters");
                DataHandler.Instance.InitializeParameter("SubMenu", "Production Company Management");
                DataHandler.Instance.InitializeParameter("ProductionCode", "4338");
                #endregion

                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                show.Select_Menu(DataHandler.Instance.GetParam("MainMenu"), DataHandler.Instance.GetParam("SubMenu"));
                productionCompanyManagement.Enter_ProdCompaCode();
                productionCompanyManagement.Click_SearchButton();
                productionCompanyManagement.Validate_ProdCompanyCode();
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
        public void Chec()
        {
            try
            {
                #region Initialize Class
                SBSLogin login = new SBSLogin();
                ClientLoginCode clinetCode = new ClientLoginCode();
                #endregion

                #region Data
                DataHandler.Instance.InitializeParameter("Module", "Show");
                DataHandler.Instance.InitializeParameter("MainMenu", "Show Masters");
                DataHandler.Instance.InitializeParameter("SubMenu", "Show Management");
                DataHandler.Instance.InitializeParameter("ShowCode", "30301");
                #endregion

                login.Client_Login();
                login.Client_MainLogin();
                clinetCode.Click_SendCode();


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
        public void Search_PoolManagemnet()
        {
            try
            {
                #region Initialize class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                Show show = new Show();
                PoolManagement poolManagement = new PoolManagement();
                #endregion

                #region data 
                DataHandler.Instance.InitializeParameter("Module", "Show");
                DataHandler.Instance.InitializeParameter("MainMenu", "Show Masters");
                DataHandler.Instance.InitializeParameter("SubMenu", "Pool Management");
                DataHandler.Instance.InitializeParameter("PoolCode", "152 - DISCOVERY");
                DataHandler.Instance.InitializeParameter("PoolDiscription", "DISCOVERY");
                #endregion

                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                show.Select_Menu(DataHandler.Instance.GetParam("MainMenu"), DataHandler.Instance.GetParam("SubMenu"));

                poolManagement.Enter_PoolData();
                poolManagement.Click_BtnSearch();
                poolManagement.Validate_SearchData();

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
        public void Search_PoolManagmentByGrid()
        {

            try
            {
                #region Initialize class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                Show show = new Show();
                PoolManagement poolManagement = new PoolManagement();
                #endregion

                #region data 
                DataHandler.Instance.InitializeParameter("Module", "Show");
                DataHandler.Instance.InitializeParameter("MainMenu", "Show Masters");
                DataHandler.Instance.InitializeParameter("SubMenu", "Pool Management");
                DataHandler.Instance.InitializeParameter("Poolcode", "152");
                DataHandler.Instance.InitializeParameter("PoolDiscription", "DISCOVERY");
                #endregion

                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                show.Select_Menu(DataHandler.Instance.GetParam("MainMenu"), DataHandler.Instance.GetParam("SubMenu"));
                poolManagement.SelectPool_InGrid();
                poolManagement.Validate_SearchData();

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
        public void Search_GroupByName()
        {

            try
            {
                #region Initialize class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                Show show = new Show();
                GroupManagement groupManagemnt = new GroupManagement();
                #endregion

                #region data 
                DataHandler.Instance.InitializeParameter("Module", "Show");
                DataHandler.Instance.InitializeParameter("MainMenu", "Show Masters");
                DataHandler.Instance.InitializeParameter("SubMenu", "Group Management");
                DataHandler.Instance.InitializeParameter("GroupName", "Sacrifice");
                #endregion

                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                show.Select_Menu(DataHandler.Instance.GetParam("MainMenu"), DataHandler.Instance.GetParam("SubMenu"));
                groupManagemnt.Enter_ShowName();
                groupManagemnt.Click_Search();
                groupManagemnt.ClickOn_Deatils();
                groupManagemnt.Click_GroupManagmentTabs("Group Management");
                groupManagemnt.Validate_GroupName();

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
        public void Search_GroupByCode()
        {

            try
            {
                #region Initialize class
                SBSLogin login = new SBSLogin();
                HomePage homePage = new HomePage();
                Show show = new Show();
                GroupManagement groupManagemnt = new GroupManagement();
                #endregion

                #region data 
                DataHandler.Instance.InitializeParameter("Module", "Show");
                DataHandler.Instance.InitializeParameter("MainMenu", "Show Masters");
                DataHandler.Instance.InitializeParameter("SubMenu", "Group Management");
                DataHandler.Instance.InitializeParameter("GroupCode", "27546");
                DataHandler.Instance.InitializeParameter("GroupName", "RTR Media, Inc.");

                #endregion

                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                show.Select_Menu(DataHandler.Instance.GetParam("MainMenu"), DataHandler.Instance.GetParam("SubMenu"));
                groupManagemnt.Enter_GroupCode();
                groupManagemnt.Click_Search();
                groupManagemnt.ClickOn_Deatils();
                groupManagemnt.Click_GroupManagmentTabs("Group Management");
                groupManagemnt.Validate_GroupName();

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
        public void Smoke_Adjustment()
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

                #endregion

                login.SBSlogin();
                homePage.Select_Module(DataHandler.Instance.GetParam("Module"));
                adjustment.Close_AdjustmentPopup();


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
            // BrowserHandler.Clear_BrowserCatche();
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
