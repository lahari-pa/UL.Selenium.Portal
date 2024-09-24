using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "DemoViewer")]
    class Steps_DemoViewer
    {
        [RegexStepDefinition(@"I confirm the Demo Viewer Page has loaded")]
        public void DemoViewerPageLoaded()
        {
           
            GeneralUtilities.WaitForLoadingToFinish();            
            if (!new DemoViewer().WaitForLoginInputAreaToLoad())
            {
                Report.Error("The login input fields did not load");
            }
            //Would need to swith back and forth to check active tab, avoiding unless test case indicates need to check. 
            //new Steps_Navigation().ConfirmActiveTab("Web Viewers");
            Report.IsTrue(new DemoViewer().WaitForContainerToBeVisible(), "The Demo Viewer Page container did not load!");
            Report.Screenshot();
        }


    } 


}