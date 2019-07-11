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
			Report.Info("Beginning to click the Login button");
			var selHomepage = new LandingPage();
			if (!selHomepage.WaitForContainerToBeVisible())
			{
				Report.Info("Not on the Homepage, navigating...");
				SeleniumBrowser.Navigate(GlobalParameters.TestUrl);
				Report.IsTrue(selHomepage.WaitForContainerToBeVisible(), "Homepage failed to load!", "Homepage loaded successfully!");
			}
			Report.IsTrue(selHomepage.Click_Login(), "Failed to click Log In", "Successfully clicked Log In");
		}

		[StepDefinition(@"I select the Sign Up link")]
		public void ClickSignUpLink()
		{
			Report.IsTrue(new LandingPage().Click_SignUp(), "Failed to click Sign Up", "Successfully clicked Sign Up");
		}

		[StepDefinition(@"the login page should (appear|dissappear)")]
		public void LoginPageAppears(string appear)
		{
			Report.IsTrue(new Login().WaitForContainerToBeVisible() == (appear == "appear"), "Login page did not " + appear + "!", "Login page " + appear + "ed successfully!");
		}

		[StepDefinition("I click outside of the login popup")]
		public void ClickOutisdeOfLoginPopup()
		{
			Report.Info("Clicking outside of the login popup");
			new Login().ClickOutside();
			Report.Info("Clicked outside of the login popup");
			Report.Screenshot();
		}

		[StepDefinition(@"I should see the following menu options in the header:")]
		public void NavigationOptionShowing(Table expected)
		{
			var optionsAvailable = new LandingPage().NavigationOptionsAvailable();
			foreach (var row in expected.Rows)
			{
				string option = row["Option"];
				Report.Info("Expecting to see menu option: '" + option + "' available on the landing page");
				Report.IsTrue(optionsAvailable.Contains(option),
					"Option: '" + option + "' was not available in the list of navigation options!",
					"Option: '" + option + "' was showing in the list of navigation options");
			}
		}

		[StepDefinition(@"I select the (Manufacturers|Retailers|Subscription) link")]
		public void SelectNavigationOption(string option)
		{
			Report.IsTrue(new LandingPage().SelectOption(option),
				"Failed to select option: " + option + "!",
				"Successfully selected option: " + option + "!");
		}

		[StepDefinition(@"I confirm I am taken to the (Manufacturers|Retailers|Subscription) page")]
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

		[StepDefinition(@"the landing page should load")]
		public void LandingPageLoads()
		{
			Report.IsTrue(new LandingPage().WaitForContainerToBeVisible(), "Landing page did not load!", "Landing page loaded successfully!");
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
			Report.IsTrue(new LandingPageFooter().ClickTermsOfUse(), "Failed to click Terms of Use", "Successfully clicked Terms of Use");
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
