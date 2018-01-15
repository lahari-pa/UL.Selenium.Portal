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
    [Binding, Scope(Tag = "MyAccount")]
    class Steps_MyAccount
    {
        [Then(@"I should see username: (.*) in the right corner")]
        public void ThenIShouldSeeUsernameInTheRightCorner(string Username)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see username: "+ Username + " in the top right corner");
            try
            {
                TopMenuBar thisTopMenuBar = new TopMenuBar();
                Report.IsTrue(thisTopMenuBar.GetCurrentUser() == Username,
                    "Username should have been showing as: " + Username + " but is: " + thisTopMenuBar.GetCurrentUser(),
                    "Username correctly showing as: " + Username);
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [Given(@"I navigate to the MyAccount page")]
        public void GivenINavigateToTheMyAccountPage()
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - I navigate to the MyAccount page");
            try
            {
                TopMenuBar thisTopMenuBar = new TopMenuBar();
                thisTopMenuBar.ClickMyAccount();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }



        [StepDefinition(@"I should see the heading: (.*) on the My Account page")]
        public void CorrectHeadingShowing(string headingExpected)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see the heading " + headingExpected);
            try
            {
                Report.Info("Checking that I see the heading: '" + headingExpected + "'");
                var Sel_MyAccount = new MyAccount();
                var headingShowing = Sel_MyAccount.HeaderShowing();
                Report.IsTrue(headingShowing.Trim() == headingExpected.Trim(), 
                    "Heading was not as expected! Expected: " + headingExpected + ", but found " + headingShowing + "!", 
                    "Heading was showing: " + headingShowing + ", as expected!");
                Report.Screenshot();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I should see the subheading: (.*) on the My Account page")]
        public void CorrectSubHeadingShowing(string subheadingExpected)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see the heading " + subheadingExpected);
            try
            {
                Report.Info("Checking that I see the heading: '" + subheadingExpected + "'");
                var Sel_MyAccount = new MyAccount();
                var subheadingsShowing = Sel_MyAccount.Subheadings();
                Report.IsTrue(subheadingsShowing.Any(x=>x.StartsWith(subheadingExpected.Trim())),
                    "Subheading was not as expected! Expected: " + subheadingExpected + ", but found " + String.Join(", ",subheadingsShowing) + "!",
                    "Heading was showing: " + subheadingExpected + ", as expected!");
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
