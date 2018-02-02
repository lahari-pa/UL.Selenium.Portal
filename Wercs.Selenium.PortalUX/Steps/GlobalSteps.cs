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
using Wercs.Selenium.PortalUX.Classes;

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
                var selLandingPage = new LandingPage();
                selLandingPage.Click_Login();

                var selLogin = new Login();
                Report.IsTrue(selLogin.Wait_for_load(),"Login page did not load!","Login page loaded successfully!");
                Report.Info("Entering Email: '" + GlobalParameters.Admin1 + "'");
                selLogin.EmailField = GlobalParameters.Admin1;
                Report.Info("Entering Password: '" + GlobalParameters.AdminPassword1 + "'");
                selLogin.PasswordField = GlobalParameters.AdminPassword1;
                Report.Info("Clicking login");
                selLogin.Click_Login();

				//var Sel_TOU = new TermsOfUse();
				//if (Sel_TOU.Wait_for_load(10))
				// Sel_TOU.Accept();

				var selHomepage = new Homepage();
                Report.IsTrue(selHomepage.Wait_for_load(),"Homepage did not load after clicking log in!","Homepage successfully loaded after clicking log in!");
                GeneralUtilities.Wait_for_load_finish();
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                throw;
            }
        }

	    [StepDefinition(@"Login into WERCSmart Portal - Administrator Role - WERCs Account")]
	    public void GivenLoginIntoWERCSmartPortal_AdministratorRole()
	    {
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Log into WERCSmart Portal as Administrator into the WERCs Account");
		    try
		    {
			    Report.Info("Clicking 'Log In' on the Landing Page");
			    var selLandingPage = new LandingPage();
			    selLandingPage.Click_Login();

			    var selLogin = new Login();
			    Report.IsTrue(selLogin.Wait_for_load(), "Login page did not load!", "Login page loaded successfully!");
			    var username = @"Amanda.Coutant@gmail.com";
			    var password = "Thewercs1";

			    Report.Info("Entering Email: '" + username + "'");
			    selLogin.EmailField = username;
				Report.Info("Entering Password: '" + password + "'");
			    selLogin.PasswordField = password;
			    Report.Info("Clicking login");
			    selLogin.Click_Login();

			    //var Sel_TOU = new TermsOfUse();
			    //if (Sel_TOU.Wait_for_load(10))
			    // Sel_TOU.Accept();

			    var selHomepage = new Homepage();
			    Report.IsTrue(selHomepage.Wait_for_load(), "Homepage did not load after clicking log in!", "Homepage successfully loaded after clicking log in!");
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
				{ GeneralUtilities.ScrollToTopOfPage(); }
				else
				{ GeneralUtilities.ScrollToBottomOfPage(); }

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
		public void NavigateToTheUrl(string url)
	    {
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Navigate to URL: " + url);
		    try
		    {
			    Report.Info("Navigating to the URL: " + url);
			    GlobalParameters.Browser.WebBrowser.Navigate().GoToUrl(url);
			    Report.Success("Successfully navigated to the URL: " + url + "!");
			    Report.Screenshot();
		    }
		    catch (Exception ex)
		    {
			    Report.Failure(ex.Message);
			    throw;
		    }
		}

	    [StepDefinition(@"I check that the current URL contains: (.*)")]
	    public void CurrentUrlContains(string url)
	    {
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking that the current URL contains: " + url);
		    try
		    {
			    Report.Info("Checking that the current URL contains: " + url);
			    var currentUrl = GlobalParameters.Browser.WebBrowser.Url;
				Report.Info("Current URL is: " + currentUrl);
				Report.IsTrue(currentUrl.Contains(url),
				    "Current URL was: " + currentUrl + ", which did not contain: " + url + "!",
				    "Curreent URL contained " + url + ", as expected!");
			    Report.Screenshot();
		    }
		    catch (Exception ex)
		    {
			    Report.Failure(ex.Message);
			    throw;
		    }
		}

	    [StepDefinition(@"I close the window that opened")]
	    public void ThenCloseTheWindowThatOpened()
	    {
		    TestReport.BeginTestModule(GlobalParameters.StepCount + " - Closing current window");
		    try
		    {
				var mainWindowHandle = SafewareSeleniumUtilities.Context.GetFromContext("MainWindowHandle");
				if(mainWindowHandle==null)
					Report.Error("No Main Window Handle found!");
				Report.Info("Attempting to close the current window");
				GlobalParameters.Browser.WebBrowser.Close();
				Report.Info("Current window closed, switching to the MainWindowHandle");
				GlobalParameters.Browser.WebBrowser.SwitchTo().Window(mainWindowHandle.ToString());
				Report.Success("Browser window switched successfully!");
				Report.Screenshot();
		    }
		    catch (Exception ex)
		    {
			    Report.Failure(ex.Message);
			    throw;
		    }
		}



		[StepDefinition(@"UNDER DEVELOPMENT")]
        public void Underdevelopment()
        {
            TestReport.BeginTestModule(GlobalParameters.StepCount + " - UNDER DEVELOPMENT");
            try
            {
                Report.Warn("AREA UNDER DEVELOPMENT");
                Report.Failure("AREA UNDER DEVELOPMENT");
                var selBulkActions = new BulkActions();
                if (selBulkActions.Wait_for_load(5))
                {
                    Report.Info("Closing Bulk Actions window as result is not yet developed");
                    selBulkActions.ClickClose();
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
