using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using NUnit;
using NUnit.Framework;
namespace ShowbizStudio_Scripts
{
    [SetUpFixture]
   public  class SetupFixtr
    {

    [OneTimeTearDown]
    public void GenerateReport()
    {
        GnerateReports.GenerateFinalReport_Two();
        DataHandler.Instance.ClearDictionary();
            //try
            //{
            //    BrowserHandler.Driver.Close();
            //}
            //catch { }
    }

}
}
