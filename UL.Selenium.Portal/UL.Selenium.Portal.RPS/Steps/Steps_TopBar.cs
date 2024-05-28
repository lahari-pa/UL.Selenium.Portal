using System;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Classes;
using TReVor.Integrations.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;
using TReVor.Core.Classes.Software;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.RPS.Steps
{
    [Binding, Scope(Tag = "TopBar")]
    class Steps_TopBar
    {
        [RegexStepDefinition(@"I confirm the top menu bar is displayed with the logged in username")]
        public void ConfirmTopBarDisplayedWithLoggedInUser()
        {
            Report.UseSubSteps = true;
            Report.StartStep("I confirm the top bar is displayed");
            Report.IsTrue(new TopBar().WaitForContainerToBeVisible(), "Top menu bar did not load!", "Top menu bar loaded");
            Report.StartStep("I confirm the logged in username is displayed in the top menu bar");
            this.ConfirmLoggedInUserNameTopBar();
        }

		[RegexStepDefinition(@"I confirm the logged in user displayed in the top bar is correct for TReVor user: (.*)")]
		public void ConfirmLoggedInUserNameTopBar(string savedAs)
		{
			if (TReVorSettings.SoftwareCredentials.TryGetValue(savedAs, out var user))
			{
				throw new Exception("Failed to find user saved as: " + savedAs);
			}
			var displayedUser = new TopBar().UserAccountText();
			Report.IsTrue(displayedUser == user.UserName, "Displayed logged in user did not match: " + user.UserName + "! Displayed was: " + displayedUser, "Logged in user was displayed as expected.");

		}

		[RegexStepDefinition(@"I confirm the user displayed in the top bar matches the active logged in user")]
		public void ConfirmLoggedInUserNameTopBar()
		{
			if (!Context.Contains("ActiveUser"))
			{
				Report.Failure("Failed to find logged in user from Context!");
				return;
			}
			var user = (SoftwareCredentialBasic)Context.GetFromContext("ActiveUser");
			var expectedUser = user.UserName;
			Report.Info("Logged in username: " + expectedUser);
			var displayedUser = new TopBar().UserAccountText();
			Report.IsTrue(displayedUser == expectedUser, "Displayed logged in user did not match: " + expectedUser + "! Displayed was: " + displayedUser, "Logged in user was displayed as expected.");
		}

		[RegexStepDefinition(@"I click the user button in the top bar")]
		public void ClickUserNameButtonTopBar()
		{
			Report.IsTrue(new TopBar().ClickUserAccount(), "Failed to click user button in the top bar!", "Clicked user button in the top bar");
		}

		[RegexStepDefinition("I click 'Sign Out' under the user button")]
		public void ClickSignOut()
		{
			Report.IsTrue(new TopBar().ClickSignOut(), "Failed to click Sign Out", "Clicked Sign Out");
		}

		[RegexStepDefinition("I confirm the 'Sign Out' dropdown option is displayed under the user button")]
		public void SignOutDisplayed()
		{
			Report.IsTrue(new TopBar().SignOutDisplayed(), "Sign Out was not displayed!", "Sign Out was displayed");
		}

		[RegexStepDefinition(@"I confirm the UL Logo is displayed in the top bar")]
		public void UlLogoDisplayed()
		{
			Report.IsTrue(new TopBar().UlLogoDisplayed(), "UL logo was not displayed in the top bar!", "UL logo was displayed in the top bar");
		}

		[RegexStepDefinition(@"I click the UL Logo in the top bar")]
		public void ClickUlLogo()
		{
			Report.IsTrue(new TopBar().ClickUlLogo(), "Failed to click the UL logo", "Clicked the UL logo");
		}

		[RegexStepDefinition(@"I confirm the logged in page banner shows background color: red")]
		public void ConfirmPageBannerColorIsRed()
		{

			string expectedColorString = "rgba(177, 31, 35, 1)";
			Report.Info($"The expected rbga color for the background is: {expectedColorString}");
			string foundColorCode = new TopBar().GetTopBarBackgroundColor();
			Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

		}

		[RegexStepDefinition(@"I confirm the logged in page banner shows font color: white")]
		public void ConfirmBannerFontColorIsWhite()
		{

			string expectedColorString = "rgba(255, 255, 255, 1)";
			Report.Info($"The expected rbga color for white is: {expectedColorString}");
			Report.Info("Getting the Brand Name Font Color");
			string brandNameFontColor = new TopBar().GetBradNameFontColor();
			Report.Info($"The Brand Name color was: {brandNameFontColor}");
			Report.IsTrue(brandNameFontColor == expectedColorString, "The color of the brand name was not white", "The color of the brand name was found to be white");
			Report.Info("Getting the User Account Font Color");
			string userAccountFontColor = new TopBar().GetUserAccountFontColor();
			Report.Info($"The User Account color was: {userAccountFontColor}");
			Report.IsTrue(userAccountFontColor == expectedColorString, "The color of the user account was not white", "The color of the user account was found to be white");

		}



		[RegexStepDefinition(@"I confirm the page heading banner shows the WERCSmart Product Suite logo and it reads : (.*)")]
		public void ConfirmBannerFontColorIsWhite(string logoText)
		{

			Report.Info("Getting the WERCSmart product suit logo text...");
			string foundText = new TopBar().GetBrandName();
			Report.Info($"Found the text: {foundText}");
			Report.IsTrue(foundText == logoText, "The Text found did not match the expected text", "The text found matched the expected text");

		}

		/*
		[RegexStepDefinition(@"I confirm the Product Suite Brand Name Logo is displayed in the top bar")]
		public void ProductSuiteLogoDisplayed()
		{
			Report.IsTrue(new TopBar().BrandNameDisplayed(), "UL logo was not displayed in the top bar!", "UL logo was displayed in the top bar");
		}
		*/

		[RegexStepDefinition(@"I confirm the Product Suite Brand Name Logo is displayed in the top bar")]
		public void ProductSuiteLogoDisplayedInRPS()
		{
			Report.IsTrue(new TopBar().UlLogoDisplayed(), "UL logo was not displayed in the top bar!", "UL logo was displayed in the top bar");
		}

		[RegexStepDefinition(@"I click the Product Suite Brand Name Logo in the top bar")]
		public void ClickProductSuiteLogo()
		{
			Report.IsTrue(new TopBar().ClickBrandName(), "Failed to click the UL logo", "Clicked the UL logo");
		}

		[RegexStepDefinition(@"I click the Product Suite Brand Name Logo in the top bar in RPS")]
		public void ClickProductSuiteLogoInRPS()
		{
			Report.IsTrue(new TopBar().ClickBrandNameInRPS(), "Failed to click the UL logo", "Clicked the UL logo");
		}

        [RegexStepDefinition(@"I confirm the logged in page banner shows background color: black")]
        public void ConfirmPageBannerColorIsBlack()
        {

            string expectedColorString = "rgba(0, 43, 69, 1)";
            Report.Info($"The expected rbga color for the background is: {expectedColorString}");
            string foundColorCode = new TopBar().GetTopBarBackgroundColor();
            Report.IsTrue(expectedColorString == foundColorCode, "The found color was not as expected", "The color found was as expected");

        }

    }
}
