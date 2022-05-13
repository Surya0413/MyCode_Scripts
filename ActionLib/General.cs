using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using OpenQA.Selenium;
namespace ActionLib
{
   public  class General
    {
        IWebDriver driver;


        public General()
        {
            driver = BrowserHandler.Driver;

        }
        public   void DrawHighlight(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('style', 'border: 2px solid red;');", element);
        }
    }
}
