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
           DataHandler.Instance.InitializeParameter("URL", @"https://dev.show.com/");                       
            DataHandler.Instance.InitializeParameter("Environment", "QA");
         //   DataHandler.Instance.InitializeParameter("Browser", "Edge");
            DataHandler.Instance.InitializeParameter("Browser", "Chrome");
            DataHandler.Instance.InitializeParameter("Username", "surya.sasidhar@gmail.com");
            DataHandler.Instance.InitializeParameter("Password", "Monday@17122012");           

        }

        [Test]
        public void Showbizstudio_Dev_Parameters()
        {
             DataHandler.Instance.InitializeParameter("URL", @"https://dev.show.com/");                       
            DataHandler.Instance.InitializeParameter("Environment", "QA");
         //   DataHandler.Instance.InitializeParameter("Browser", "Edge");
            DataHandler.Instance.InitializeParameter("Browser", "Chrome");
            DataHandler.Instance.InitializeParameter("Username", "surya.sasidhar@gmail.com");
            DataHandler.Instance.InitializeParameter("Password", "Monday@17122012");     
        }

        [Test]
        public void Showbizstudio_Stage_Parameters()
        {
           DataHandler.Instance.InitializeParameter("URL", @"https://dev.show.com/");                       
            DataHandler.Instance.InitializeParameter("Environment", "QA");
         //   DataHandler.Instance.InitializeParameter("Browser", "Edge");
            DataHandler.Instance.InitializeParameter("Browser", "Chrome");
            DataHandler.Instance.InitializeParameter("Username", "surya.sasidhar@gmail.com");
            DataHandler.Instance.InitializeParameter("Password", "Monday@17122012");     
        }

        [TearDown]
        public void MyTestCleanup()
        {
            DataHandler.Instance.BulkExport("xml");
            DataHandler.Instance.ClearDictionary();
        }

    }
}
