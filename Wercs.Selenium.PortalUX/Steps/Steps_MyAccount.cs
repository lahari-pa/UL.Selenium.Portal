using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SafewareReporting;
using SafewareSeleniumUtilities;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
    [Binding, Scope(Tag = "MyAccount")]
    class StepsMyAccount
    {
        [StepDefinition(@"I should see username for user saved as: (.*) in the right corner")]
        public void ThenIShouldSeeUsernameForUserSavedAsInTheRightCorner(string savedAs)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see username: " + savedAs + " in the top right corner");
            try
            {
                var user = (User)Context.GetFromContext(savedAs);
                TopMenuBar thisTopMenuBar = new TopMenuBar();
                string username = user.FirstName + ", " + user.LastName;
                Report.Info("Looking for username: " + username);
                Report.IsTrue(thisTopMenuBar.GetCurrentUser() == username,
                    "Username should have been showing as: " + username + " but is: " + thisTopMenuBar.GetCurrentUser(),
                    "Username correctly showing as: " + username);
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }


        [StepDefinition(@"I should see username: (.*) in the right corner")]
        public void ThenIShouldSeeUsernameInTheRightCorner(string username)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see username: "+ username + " in the top right corner");
            try
            {
                TopMenuBar thisTopMenuBar = new TopMenuBar();
                Report.IsTrue(thisTopMenuBar.GetCurrentUser() == username,
                    "Username should have been showing as: " + username + " but is: " + thisTopMenuBar.GetCurrentUser(),
                    "Username correctly showing as: " + username);
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [Then(@"I should see company username: (.*)")]
        public void ThenIShouldSeeCompanyUsername(string companyName)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see company username: " + companyName);
            try
            {
                MyAccount myMyAccount = new MyAccount();
                Report.IsTrue(myMyAccount.GetCompanyName() == companyName,
                    "Company name should be showing as: " + companyName + " but is: " + myMyAccount.GetCompanyName(),
                    "Company name is correctly showing as: " + companyName);
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
                var selMyAccount = new MyAccount();
                var headingShowing = selMyAccount.HeaderShowing();
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
                var selMyAccount = new MyAccount();
                var subheadingsShowing = selMyAccount.Subheadings();
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
