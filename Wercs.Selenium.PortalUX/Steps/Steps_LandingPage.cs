using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "LandingPage")]
	class Steps_LandingPage
	{

		[Given(@"I go to the WERCSmart Log in")]
		[StepDefinition(@"I go to the WERCSmart Log in")]
		[StepDefinition(@"I click the login button")]
		public void IClickTheLoginButton()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Click the WERCSmart login button");
			try
			{
				Report.Info("Beginning to click the Login button");
				var Sel_Homepage = new LandingPage();
				if (!Sel_Homepage.Wait_for_load(1))
				{
					Report.Info("Not on the Homepage, navigating...");
					GlobalParameters.Browser.WebBrowser.Navigate().GoToUrl(GlobalParameters.TestUrl);
					Report.IsTrue(Sel_Homepage.Wait_for_load(30), "Homepage failed to load!", "Homepage loaded successfully!");
				}

				Sel_Homepage.Click_Login();
				Report.Screenshot();
				Report.Success("Login button clicked!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I select the Sign Up link")]
		public void IClickSignUpLink()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				Report.Info("Beginning to click the Login button");
				var Sel_Homepage = new LandingPage();
				Sel_Homepage.Click_Signup();
				Report.Screenshot();
				Report.Success("Signup button clicked!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the login page should (appear|dissappear)")]
		public void LoginPageAppears(string appear)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Login page should " + appear);
			try
			{
				Report.Info("Checking that the login page has " + appear + "ed.");
				var Sel_Login = new Login();
				Report.Screenshot();
				Report.IsTrue(Sel_Login.Wait_for_load(1) == (appear == "appear"), "Login page did not " + appear + "!", "Login page " + appear + "ed successfully!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition("I click outside of the login popup")]
		public void ClickOutisdeOfLoginPopup()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click outside the login popup");
			try
			{
				Report.Info("Clicking outside of the login popup");
				var Sel_Login = new Login();
				Sel_Login.ClickOutside();
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see the following menu options in the header:")]
		public void NavigationOptionShowing(Table expected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see the following menu options in the header");
			try
			{
				var Sel_Homepage = new LandingPage();
				var OptionsAvailable = Sel_Homepage.NavigationOptionsAvailable();

				foreach (var Row in expected.Rows)
				{
					string option = Row["Option"];
					Report.Info("Expecting to see menu option: '" + option + "' available on the landing page");
					Report.IsTrue(OptionsAvailable.Contains(option),
						"Option: '" + option + "' was not available in the list of navigation options!",
						"Option: '" + option + "' was showing in the list of navigation options");
				}

				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I select the (Manufacturers|Retailers|Subscription) link")]
		public void SelectNavigationOption(string option)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Select " + option);
			try
			{
				Report.Info("Selecting option: " + option);
				var Sel_Homepage = new LandingPage();
				Report.IsTrue(Sel_Homepage.SelectOption(option),
					"Failed to select option: " + option + "!",
					"Succesfully selected option: " + option + "!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm I am taken to the (Manufacturers|Retailers|Subscription) page")]
		public void ConfirmNavigation(string option)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Confirm you are taken to the " + option + " page");
			try
			{
				Report.Info("Checking that the correct page has loaded successfully");
				bool Result = false;
				switch (option)
				{
					case ("Manufacturers"):
						Result = new ManufacturersInfo().Wait_for_load();
						break;
					case ("Retailers"):
						Result = new RetailersInfo().Wait_for_load();
						break;
					case ("Subscription"):
						Result = new SubscriptionInfo().Wait_for_load();
						break;
				}

				Report.IsTrue(Result, "Failed to navigate to the " + option + " page!", "Successfully navigated to the " + option + " page!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the landing page should load")]
		public void LandingPageLoads()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Landing Page should load");
			try
			{
				Report.Info("Expecting the Landing Page to load");
				var Sel_Homepage = new LandingPage();
				Report.IsTrue(Sel_Homepage.Wait_for_load(), "Landing page did not load!", "Landing page loaded successfully!");
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
