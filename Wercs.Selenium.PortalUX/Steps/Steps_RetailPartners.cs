using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
    [Binding, Scope(Tag = "RetailPartners")]
    class Steps_RetailPartners
    {
        [StepDefinition(@"I should see the following subheading (.*)")]
        public void ThenIShouldSeeTheFollowingSubheading(string subheading)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking that the subheading " + subheading + " is showing");
            try
            {
                Report.Info("Checking that the subheading " + subheading + " is showing");
                var Sel_RetailPartners = new RetailPartners();

                if (!Sel_RetailPartners.Wait_for_load(10))
                    throw new Exception("Page failed to load!");

                var SubHeadingsShowing = Sel_RetailPartners.SubHeadingsShowing();
                Report.IsTrue(SubHeadingsShowing.Contains(subheading.Trim()),
                    "Subheading was not showing as expected! Expected: '" + subheading + "', but found: '" + String.Join("', '", SubHeadingsShowing) + "'!",
                    "Subheading was showing: '" + subheading + "', as expected!");
                Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I should see the following heading (.*)")]
        public void ThenIShouldSeeTheFollowingHeading(string heading)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking that the heading " + heading + " is showing");
            try
            {
                Report.Info("Checking that the heading " + heading + " is showing");
                var Sel_RetailPartners = new RetailPartners();

                if (!Sel_RetailPartners.Wait_for_load(10))
                    throw new Exception("Page failed to load!");

                var HeadingShowing = Sel_RetailPartners.HeaderShowing();
                Report.IsTrue(HeadingShowing.Trim()==heading.Trim(),
                    "Header was not showing as expected! Expected: '" + heading + "', but found: '" + HeadingShowing + "'!",
                    "Header was showing: '" + heading + "', as expected!");
                Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }
    }
}
