using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "DemoStatus")]
    class Steps_DemoStatus
    {
        [StepDefinition(@"I confirm the Demo Status Page has loaded")]
        public void DemoStatusPageLoaded()
        {

            GeneralUtilities.WaitForLoadingToFinish();
            if (!new DemoStatus().WaitForLoginInputAreaToLoad())
            {
                Report.Error("The login input fields did not load");
            }
            //Would need to swith back and forth to check active tab, avoiding unless test case indicates need to check. 
            //new Steps_Navigation().ConfirmActiveTab("Web Viewers");
            Report.IsTrue(new DemoStatus().WaitForContainerToBeVisible(), "The Demo Status Page container did not load!");
            Report.Screenshot();
        }


    }


}