using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using SafewareReporting;
using TechTalk.SpecFlow;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;

using NUnit.Framework;
using SeleniumUtilities;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using Wercs.Selenium.PortalUX.Steps;

[assembly: Apartment(ApartmentState.STA)]

namespace WERCSmart
{
    [Binding]
    public class GlobalSteps
    {
		[StepDefinition(@"I login into the WERCSmart Portal - Administrator Role")]
        [StepDefinition(@"I login as the administrator")]
        [Given(@"I login as the administrator")]
        [When(@"I login as the administrator")]
        [Then(@"I login as the administrator")]
        public void GivenILoginAsTheAdministrator()
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Log into WERCSmart Portal as Administrator");
            try
            {
                Report.Info("Clicking 'Log In' on the Landing Page");
                var SelLandingPage = new LandingPage();
                SelLandingPage.Click_Login();

                var Sel_Login = new Login();
                Report.IsTrue(Sel_Login.Wait_for_load(),"Login page did not load!","Login page loaded successfully!");
                Report.Info("Entering Email: '" + GlobalParameters.Admin1 + "'");
                Sel_Login.Email_Field = GlobalParameters.Admin1;
                Report.Info("Entering Password: '" + GlobalParameters.AdminPassword1 + "'");
                Sel_Login.Password_Field = GlobalParameters.AdminPassword1;
                Report.Info("Clicking login");
                Sel_Login.Click_Login();

	            //var Sel_TOU = new TermsOfUse();
	            //if (Sel_TOU.Wait_for_load(10))
		           // Sel_TOU.Accept();

				var Sel_Homepage = new Homepage();
                Report.IsTrue(Sel_Homepage.Wait_for_load(),"Homepage did not load after clicking log in!","Homepage successfully loaded after clicking log in!");
                GeneralUtilities.Wait_for_load_finish();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I logout")]
        public void GivenILogout()
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
            try
            {
                TopMenuBar thisTopMenuBar = new TopMenuBar();
                Assert.That(thisTopMenuBar.ClickSignOut());
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

        [StepDefinition(@"I scroll to the (top|bottom) of the page")]
        public void ThenIScrollToTheOfThePage(string topbottom)
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - Scroll to " + topbottom + " of page");
            try
            {
                Report.Info("Attempting to scroll to the " + topbottom + " of the page");
                if (topbottom == "top")
                    GeneralUtilities.ScrollToTopOfPage();
                else
                    GeneralUtilities.ScrollToBottomOfPage();

                Report.Screenshot();
                Report.Success("Scrolled to the " + topbottom + " of the page!");
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

	    [StepDefinition(@"I navigate to the landing page")]
	    public void NavigateToLandingPage()
	    {
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Navigate to landing page");
		    try
		    {
				Report.Info("Navigating to the landing page");
				GlobalParameters.Browser.WebBrowser.Navigate().GoToUrl(GlobalParameters.TestUrl);
				Report.Success("Successfully navigated to the landing page!");
		    }
		    catch (Exception ex)
		    {
			    Report.Failure(ex.Message);
			    throw;
		    }
		}

	    [StepDefinition(@"I navigate to the URL: (.*)")]
		public void INavigateToTheURL(string URL)
	    {
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Navigate to URL: " + URL);
		    try
		    {
			    Report.Info("Navigating to the URL: " + URL);
			    GlobalParameters.Browser.WebBrowser.Navigate().GoToUrl(URL);
			    Report.Success("Successfully navigated to the URL: " + URL + "!");
			    Report.Screenshot();
		    }
		    catch (Exception ex)
		    {
			    Report.Failure(ex.Message);
			    throw;
		    }
		}


		[StepDefinition(@"UNDER DEVELOPMENT")]
        public void UNDERDEVELOPMENT()
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - UNDER DEVELOPMENT");
            try
            {
                Report.Warn("AREA UNDER DEVELOPMENT");
                Report.Failure("AREA UNDER DEVELOPMENT");
                var Sel_BulkActions = new BulkActions();
                if (Sel_BulkActions.Wait_for_load(5))
                {
                    Report.Info("Closing Bulk Actions window as result is not yet developed");
                    Sel_BulkActions.ClickClose();
                    Report.Screenshot();
                }
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }



    }

    
}
