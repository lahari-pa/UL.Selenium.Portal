using System;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.ExtensionMethods;
using NTTQA.Selenium.Reporting.Core;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "LandingPage"), Scope(Tag = "WERCSmart_LandingPage")]
	public class StepsLandingPage
	{

		[StepDefinition(@"I go to the WERCSmart Log in")]
		[StepDefinition(@"I go to the WERCSmart Log in")]
		[StepDefinition(@"I click the login button")]
		[StepDefinition(@"\[WERCSmart] I go to the WERCSmart Log in")]
		public void ClickTheLoginButton()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Click the WERCSmart login button");
			try
			{
				Report.Info("Beginning to click the Login button");
				var selHomepage = new LandingPage();
				if (!selHomepage.Wait_for_load(1))
				{
					Report.Info("Not on the Homepage, navigating...");
					SeleniumBrowser.Navigate(GlobalParameters.TestUrl);
					Report.IsTrue(selHomepage.Wait_for_load(30), "Homepage failed to load!", "Homepage loaded successfully!");
				}

				selHomepage.Click_Login();
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
		public void ClickSignUpLink()
		{
			Report.Info("Beginning to click the Login button");
			var selHomepage = new LandingPage();
			selHomepage.Click_Signup();
			Report.Screenshot();
			Report.Success("Signup button clicked!");
		}

		[StepDefinition(@"the login page should (appear|dissappear)")]
		public void LoginPageAppears(string appear)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Login page should " + appear);
			try
			{
				Report.Info("Checking that the login page has " + appear + "ed.");
				var selLogin = new Login();
				Report.Screenshot();
				Report.IsTrue(selLogin.Wait_for_load(1) == (appear == "appear"), "Login page did not " + appear + "!", "Login page " + appear + "ed successfully!");
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
				var selLogin = new Login();
				selLogin.ClickOutside();
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
				var selHomepage = new LandingPage();
				var optionsAvailable = selHomepage.NavigationOptionsAvailable();

				foreach (var row in expected.Rows)
				{
					string option = row["Option"];
					Report.Info("Expecting to see menu option: '" + option + "' available on the landing page");
					Report.IsTrue(optionsAvailable.Contains(option),
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
				var selHomepage = new LandingPage();
				Report.IsTrue(selHomepage.SelectOption(option),
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
				bool result = false;
				switch (option)
				{
					case ("Manufacturers"):
						result = new ManufacturersInfo().Wait_for_load();
						break;
					case ("Retailers"):
						result = new RetailersInfo().Wait_for_load();
						break;
					case ("Subscription"):
						result = new SubscriptionInfo().Wait_for_load();
						break;
				}

				Report.IsTrue(result, "Failed to navigate to the " + option + " page!", "Successfully navigated to the " + option + " page!");
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
				var selHomepage = new LandingPage();
				Report.IsTrue(selHomepage.Wait_for_load(), "Landing page did not load!", "Landing page loaded successfully!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the Get Started Now link")]
		public void ClickGetStartedNow()
		{
			var selLandingPageFooter = new LandingPageFooter();
			Report.IsTrue(selLandingPageFooter.ClickGetStartedNow(), "Failed to click Get Started Now", "Successfully clicked Get Started Now");
		}
		[StepDefinition(@"I click the Terms of Use link in the Landing Page footer")]
		public void ClickTermsOfUse()
		{
			var selLandingPageFooter = new LandingPageFooter();
			Report.IsTrue(selLandingPageFooter.ClickTermsOfUse(), "Failed to click Terms of Use", "Successfully clicked Terms of Use");
		}

		[StepDefinition(@"I confirm the WERCSmart Terms of Use page has loaded")]
		public void TermsOfUsePageHasLoaded()
		{
			Report.IsTrue(SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//h1[contains(text(),'Terms of Use')]"), 30) != null,
				"The WERCSmart Terms of Use Page did not load after 30 seconds!",
				"The WERCSmart Terms of Use Page loaded as expected");
		}
	}
}
