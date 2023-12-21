using FreshtoHome.Hooks;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshtoHome.utilities
{
   public  class CoreCodes
    {
        public string TakeScreenshots(IWebDriver driver)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;   
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            string? curDir = Directory.GetParent(@"../../../").FullName;

            string ? fileName = curDir + "/Screenshots/ss_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".png";

            screenshot.SaveAsFile(fileName);
            return fileName;
        }

        protected void LogTestResult(string? testName, string? result, string? errorMessage = null)
        {
            Log.Information(result);
            if (errorMessage == null)
            {
                Log.Information(testName + " Passed");
                AllHooks.test.Pass(result);
            }
            else
            {
               
                Log.Error($"Test failed for {testName} \n Exception:\n{errorMessage}");
                AllHooks.test.Fail(result);
            }


        

        }
    }
}
