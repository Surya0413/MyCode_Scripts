using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using Core;
namespace ShowbizStudio_Scripts
{
  public   class Environments
    {
        [Test]
        public void Showbizstudio_QA_Parameters()
        {
            DataHandler.Instance.InitializeParameter("URL", @"https://qa.show.com/");
            DataHandler.Instance.InitializeParameter("Environment", "QA");
              DataHandler.Instance.InitializeParameter("Browser", "Edge");
           // DataHandler.Instance.InitializeParameter("Browser", "Chrome");
            DataHandler.Instance.InitializeParameter("Username", "surya.sasidhar@ccrw.com");
            DataHandler.Instance.InitializeParameter("Password", "T7122012sk");
            DataHandler.Instance.InitializeParameter("RUsername", @"co.mdia-services.com\reports");
            DataHandler.Instance.InitializeParameter("RPassword", "@ShbioOnly");

        }

        [Test]
        public void Showbizstudio_Dev_Parameters()
        {
            DataHandler.Instance.InitializeParameter("URL", @"https://qa.show.com/");
            DataHandler.Instance.InitializeParameter("Environment", "QA");
              DataHandler.Instance.InitializeParameter("Browser", "Edge");
           // DataHandler.Instance.InitializeParameter("Browser", "Chrome");
            DataHandler.Instance.InitializeParameter("Username", "surya.sasidhar@ccrw.com");
            DataHandler.Instance.InitializeParameter("Password", "T7122012sk");
        }

        [Test]
        public void Showbizstudio_Stage_Parameters()
        {
            DataHandler.Instance.InitializeParameter("URL", @"https://qa.show.com/");
            DataHandler.Instance.InitializeParameter("Environment", "QA");
              DataHandler.Instance.InitializeParameter("Browser", "Edge");
           // DataHandler.Instance.InitializeParameter("Browser", "Chrome");
            DataHandler.Instance.InitializeParameter("Username", "surya.sasidhar@ccrw.com");
            DataHandler.Instance.InitializeParameter("Password", "T7122012sk");
        }


        [Test]
        public void ClientShowBiz_Stage()
        {
            DataHandler.Instance.InitializeParameter("URL", @"https://qa.show.com/");
            DataHandler.Instance.InitializeParameter("Environment", "QA");
              DataHandler.Instance.InitializeParameter("Browser", "Edge");
           // DataHandler.Instance.InitializeParameter("Browser", "Chrome");
            DataHandler.Instance.InitializeParameter("Username", "surya.sasidhar@ccrw.com");
            DataHandler.Instance.InitializeParameter("Password", "T7122012sk");
        }

        [TearDown]
        public void MyTestCleanup()
        {
            DataHandler.Instance.BulkExport("xml");
            DataHandler.Instance.ClearDictionary();
        }

    }
}
