using System;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.Reporting.Functions;
using OpenQA.Selenium;
using Reqnroll;
using UL.Automation.Reporting;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "LandingPage"), Scope(Tag = "WERCSmart_LandingPage")]
	public class StepsLandingPage
	{

		[RegexStepDefinition(@"I go to the WERCSmart Log in")]
		[RegexStepDefinition(@"I click the login button")]
		[RegexStepDefinition(@"\[WERCSmart] I go to the WERCSmart Log in")]
		public void ClickTheLoginButton()
		{
			Report.Info("Beginning to click the Login button");
			var selHomepage = new LandingPage();
			if (!selHomepage.WaitForContainerToBeVisible())
			{
				Report.Info("Not on the Homepage, navigating...");
				SeleniumBrowser.Navigate(SeleniumBrowser.BaseTestUrl);
				Report.IsTrue(selHomepage.WaitForContainerToBeVisible(), "Homepage failed to load!", "Homepage loaded successfully!");
			}
			Report.IsTrue(selHomepage.Click_Login(), "Failed to click Log In", "Successfully clicked Log In");
		}

		[RegexStepDefinition(@"I select the Sign Up link")]
		public void ClickSignUpLink()
		{
			Report.IsTrue(new LandingPage().Click_SignUp(), "Failed to click Sign Up", "Successfully clicked Sign Up");
		}

		[RegexStepDefinition(@"the login page should (appear|dissappear)")]
		public void LoginPageAppears(string appear)
		{
			Report.IsTrue(new Login().WaitForContainerToBeVisible() == (appear == "appear"), "Login page did not " + appear + "!", "Login page " + appear + "ed successfully!");
		}

		[RegexStepDefinition("I click outside of the login popup")]
		public void ClickOutisdeOfLoginPopup()
		{
			Report.Info("Clicking outside of the login popup");
			new Login().ClickOutside();
			Report.Info("Clicked outside of the login popup");
			Report.Screenshot();
		}

		[RegexStepDefinition(@"I should see the following menu options in the header:")]
		public void NavigationOptionShowing(Table expected)
		{
			System.Collections.Generic.List<string> optionsAvailable = new LandingPage().NavigationOptionsAvailable();
			foreach (TableRow row in expected.Rows)
			{
				string option = row["Option"];
				Report.Info("Expecting to see menu option: '" + option + "' available on the landing page");
				Report.IsTrue(optionsAvailable.Contains(option),
					"Option: '" + option + "' was not available in the list of navigation options!",
					"Option: '" + option + "' was showing in the list of navigation options");
			}
		}

		[RegexStepDefinition(@"I select the (Manufacturers|Retailers|Subscription) link")]
		public void SelectNavigationOption(string option)
		{
			Report.IsTrue(new LandingPage().SelectOption(option),
				"Failed to select option: " + option + "!",
				"Successfully selected option: " + option + "!");
		}

		[RegexStepDefinition(@"I confirm I am taken to the (Manufacturers|Retailers|Subscription) page")]
		public void ConfirmNavigation(string option)
		{
			switch (option)
			{
				case ("Manufacturers"):
					Report.IsTrue(new ManufacturersInfo().WaitForContainerToBeVisible(),
						"Failed to navigate to the " + option + " page!", "Successfully navigated to the " + option + " page!");
					break;
				case ("Retailers"):
					Report.IsTrue(new RetailersInfo().WaitForContainerToBeVisible(),
						"Failed to navigate to the " + option + " page!", "Successfully navigated to the " + option + " page!");
					break;
				case ("Subscription"):
					Report.IsTrue(new SubscriptionInfo().WaitForContainerToBeVisible(),
						"Failed to navigate to the " + option + " page!", "Successfully navigated to the " + option + " page!");
					break;
				default:
					Report.Error("No valid option was selected. Expected 'Manufacturers', 'Retailers' or 'Subscription' " + option);
					break;
			}
		}

		[RegexStepDefinition(@"the landing page should load")]
		public void LandingPageLoads()
		{
			Report.IsTrue(new LandingPage().WaitForContainerToBeVisible(), "Landing page did not load!", "Landing page loaded successfully!");
		}

		[RegexStepDefinition(@"I click the Get Started Now link")]
		public void ClickGetStartedNow()
		{
			var selLandingPageFooter = new LandingPageFooter();
			Report.IsTrue(selLandingPageFooter.ClickGetStartedNow(), "Failed to click Get Started Now", "Successfully clicked Get Started Now");
		}
		[RegexStepDefinition(@"I click the Terms of Use link in the Landing Page footer")]
		public void ClickTermsOfUse()
		{
			Report.IsTrue(new LandingPageFooter().ClickTermsOfUse(), "Failed to click Terms of Use", "Successfully clicked Terms of Use");
		}

		[RegexStepDefinition(@"I confirm the WERCSmart Terms of Use page has loaded")]
		public void TermsOfUsePageHasLoaded()
		{
			Report.IsTrue(SeleniumBrowser.WebBrowser.FindElement(By.XPath(".//h1[contains(text(),'Terms of Use')]"), 30) != null,
				"The WERCSmart Terms of Use Page did not load after 30 seconds!",
				"The WERCSmart Terms of Use Page loaded as expected");
		}

		[RegexStepDefinition("I Check The landing page has loaded, and report if an Alert and Inactivity Prompt are open if it is not loaded")]
		public void ICheckTheLandinPageHasLoadedAndReportIfNot()
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I Check the Landing page has loaded");

			if (!(new LandingPage().WaitForContainerToBeVisible()))
			{
				Report.Failure($"The Landing page did not load", false);
				if (!new InactivityPopup().WaitForContainerToBeVisible(10))
				{
					Report.Failure($"The Inactivity prompt was not on screen", false);
				}
				else
				{
					Report.Success($"The Inactivity prompt was on screen");
				}
				if (!SeleniumBrowser.Alert.WaitForAlert(5))
				{
					Report.Failure($"The Alert was not on screen", false);
				}
				else
				{
					Report.Success($"The Alert was on screen");
				}
				return;


			}

			Report.Success("The Landing Page was loaded");
		}
	}
}
