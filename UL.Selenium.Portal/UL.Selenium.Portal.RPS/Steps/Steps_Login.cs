using System;
using Reqnroll;
using TReVor.Api.Wrapper.Classes;
using TReVor.Core.Classes.Software;
using TReVor.Integrations.Classes;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.WebDriver.Classes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.RPS.Classes;
using UL.Selenium.Portal.RPS.Selenium_Classes;

namespace UL.Selenium.Portal.RPS.Steps
{
	[Binding, Scope(Tag = "Login")]
	class Steps_Login
	{
		private const string UserNameRequiredFieldText = "The User name field is required.";

		private const string PasswordRequiredFieldText = "The Password field is required.";

		private const string AccountOrPasswordIncorrectText = "Account does not exist or password is incorrect.";

		[RegexStepDefinition(@"I log into the RPS Integrated site as Retailer: (.*)")]
		public void LogInAsRetailer(string retailer)
		{
			Report.UseSubSteps = true;

			Report.Info(String.Format("Logging in as retailer {0}", retailer));

			Report.StartStep("I confirm the Landing Page has loaded");
			new Steps_LandingPage().ConfirmLandingPageHasLoaded();

			if (!TReVorSettings.Credentials.AllCredentials.TryGetValue(String.Format("Franky {0} User", retailer), out var user))
			{
				throw new Exception("Failed to find user saved as: " + String.Format("Franky {0} User", retailer));
			}
			Report.StartStep("I enter the account username for: " + String.Format("Franky {0} User", retailer));
			new Steps_Login().EnterUserNameInput(user.UserName);
			Report.StartStep("I enter the account password for: " + String.Format("Franky {0} User", retailer));
			new Steps_Login().EnterPasswordInput(user.Password);
			Report.StartStep("I click Log In");
			new Steps_Login().ClickLogIn();
			GeneralUtilities.WaitForLoadingToFinish();
		}

		[RegexStepDefinition("I confirm the login popup is displayed")]
		public void ConfirmLoginModalIsDisplayed()
		{
			Report.IsTrue(new LogInModal().WaitForContainerToBeVisible(), "Login modal was not displayed!", "Login modal was displayed");
		}

		[RegexStepDefinition(@"I confirm the 'Welcome' login popup is displayed")]
		public void WelcomeLoginPopupIsDisplayed()
		{
			Report.UseSubSteps = true;
			Report.StartStep("I confirm the login modal is displayed");
			this.ConfirmLoginModalIsDisplayed();
			Report.StartStep("Title of the modal is: 'Welcome'");
			Report.IsTrue(new LogInModal().TitleText == "Welcome", "Popup title did not match: 'Welcome'!", "Popup title matched: 'Welcome'");
		}

		[RegexStepDefinition(@"I click 'Log in'")]
		public void ClickLogIn()
		{
			Report.IsTrue(new LogInModal().ClickLoginButton, "Failed to click Log In button", "Clicked Log in button");
		}

		[RegexStepDefinition("The following log in validation errors should be displayed:")]
		public void LogInValidationErrorsShouldBeDisplayed(Table expectedErrors)
		{
			var displayedErrors = new LogInModal().LogInErrors();
			foreach (var row in expectedErrors.Rows)
			{
				var error = row["Error"];
				Report.IsTrue(displayedErrors.Contains(error), "Error: " + error + " was not displayed!", "Error: " + error + " was displayed");
			}
		}

		[RegexStepDefinition(@"I confirm the (User Name|Password) required field error is displayed")]
		public void ConfirmRequiredFieldError(string input)
		{
			switch (input)
			{
				case "User name":
					Report.IsTrue(new LogInModal().LogInErrors().Contains(UserNameRequiredFieldText), "User name required field text error was not displayed!", "User name required field text error was displayed");
					break;
				case "Password":
					Report.IsTrue(new LogInModal().LogInErrors().Contains(PasswordRequiredFieldText), "Password required field text error was not displayed!", "Password required field text error was displayed");
					break;
				default:
					Report.Error("input parameter must be either 'User name' or 'Password'!");
					return;
			}
		}

		[RegexStepDefinition(@"I confirm the required field error is displayed for both User Name and Password")]
		public void ConfirmRequiredFieldForUserNameAndPassword()
		{
			Report.UseSubSteps = true;
			Report.StartStep("I confirm the User Name required field error is displayed");
			this.ConfirmRequiredFieldError("User name");
			Report.StartStep("I confirm the Password required field error is displayed");
			this.ConfirmRequiredFieldError("Password");
		}

		[RegexStepDefinition(@"I confirm the error is displayed indicating Account does not exist or password is incorrect")]
		public void ConfirmAccountError()
		{
			Delay.Seconds(2);
			Report.IsTrue(new LogInModal().LogInErrors().Contains(AccountOrPasswordIncorrectText), "User name required field text error was not displayed!", "User name required field text error was displayed");

			if (new LogInModal().LogInErrors().Contains(AccountOrPasswordIncorrectText))
			{
				Report.Success($"User name required field text error was displayed");
				return;
			}
			Delay.Seconds(1);
			int x = 0;
			while (x < 10)
			{
				if (new LogInModal().LogInErrors().Contains(AccountOrPasswordIncorrectText))
				{
					Report.Success($"User name required field text error was displayed");
					return;
				}
				Delay.Seconds(2);
				x++;

			}
			Report.Failure($"User name required field text error was not displayed!");


		}

		[RegexStepDefinition(@"I enter incorrect credentials for User name and Password fields")]
		public void EnterIncorrectCredentialsForUserNameAndPasswordFields()
		{
			Report.UseSubSteps = true;
			Report.StartStep("Entering incorrect user name");
			this.EnterIncorrectUserName();
			Report.StartStep("Entering incorrect password");
			this.EnterIncorrectPassword();
		}

		[RegexStepDefinition(@"I enter an incorrect User Name")]
		[RegexStepDefinition(@"I enter an incorrect User name")]
		public void EnterIncorrectUserName()
		{
			TReVorSettings.Variables.AllVariables.TryGetValue("RPS Mailosaur Prefix", out string emailPart);
			string randomStr = GeneralUtilities.GenerateRandomAlphanumericStric(6);
			var invalidUserName = randomStr + emailPart;
			Report.Info("Entering random user name: " + invalidUserName);
			this.EnterUserNameInput(invalidUserName);
		}

		[RegexStepDefinition(@"I enter an incorrect Password")]
		public void EnterIncorrectPassword()
		{
			var invalidPassword = GeneralUtilities.GenerateRandomAlphanumericStric(15);

			Report.Info("Entering random password: " + invalidPassword);
			this.EnterPasswordInput(invalidPassword);
		}

		[RegexStepDefinition("I enter: (.*) to the User Name input field")]
		public void EnterUserNameInput(string input)
		{
			Report.IsTrue(new LogInModal().EnterUserName(input), "Failed to enter user name: " + input, "Successfully entered user name: " + input);
		}

		[RegexStepDefinition("I enter: (.*) to the Password input field")]
		public void EnterPasswordInput(string input)
		{
			Report.IsTrue(new LogInModal().EnterPassword(input), "Failed to enter password: " + input, "Successfully entered password: " + input);
		}

		[RegexStepDefinition("I enter the (User Name|Password) for TReVor test user: (.*)")]
		public void EnterUserNameForTrevorTestUser(string input, string savedAs)
		{
			if (TReVorSettings.Credentials.AllCredentials.TryGetValue(savedAs, out var user))
			{
				throw new Exception("Failed to find user saved as: " + savedAs);
			}

			switch (input.ToLower())
			{
				case "user name":
					EnterUserNameForTrevorTestUser(user);
					return;
				case "password":
					EnterPasswordForTrevorTestUser(user);
					return;
				default:
					Report.Error("input parameter must be 'User Name' or 'Password'!");
					return;
			}
		}

		public void EnterUserNameForTrevorTestUser(SoftwareCredentialBasic user)
		{
			var username = user.UserName;
			Report.Info("User name: " + username);
			this.EnterUserNameInput(username);
		}

		public void EnterPasswordForTrevorTestUser(SoftwareCredentialBasic user)
		{
			var password = user.Password;
			Report.Info("Password: " + password);
			this.EnterPasswordInput(password);
		}

		[RegexStepDefinition("I enter the User Name for the active user")]
		public void EnterUserNameForActive()
		{
			if (!Context.Contains("ActiveUser"))
			{
				Report.Error("Failed to find ActiveUser in context");
				return;
			}
			var user = (SoftwareCredentialBasic)Context.GetFromContext("ActiveUser");
			var username = user.UserName;
			Report.Info("User name: " + username);
			this.EnterUserNameInput(username);
		}

		[RegexStepDefinition("I enter the Password for the active user")]
		public void EnterPasswordForActive()
		{
			if (!Context.Contains("ActiveUser"))
			{
				Report.Error("Failed to find ActiveUser in context");
				return;
			}
			var user = (SoftwareCredentialBasic)Context.GetFromContext("ActiveUser");
			var password = user.Password;
			Report.Info("Password: " + password);
			this.EnterPasswordInput(password);
		}

		[RegexStepDefinition(@"I log in as trevor user: (.*)")]
		public void LogInAsTrevorUser(string savedAs)
		{
			if (TReVorSettings.Credentials.AllCredentials.TryGetValue(savedAs, out var user))
			{
				throw new Exception("Failed to find user saved as: " + savedAs);
			}
			Report.UseSubSteps = true;
			Report.StartStep("Enter username");
			this.EnterUserNameForTrevorTestUser(user);
			Report.StartStep("Enter password");
			this.EnterPasswordForTrevorTestUser(user);
			Report.StartStep("Click log in");
			this.ClickLogIn();
			Context.AddToContext("ActiveUser", user);
		}

		[RegexStepDefinition(@"I confirm the 'Close' and 'Log In' buttons are displayed")]
		public void ConfirmCloseAndLogInButtonDisplayed()
		{
			Report.IsTrue(new LogInModal().LoginButtonTextDisplayed(), "Log In button not displayed!", "Log in button displayed");
			Report.IsTrue(new LogInModal().CloseButtonTextDisplayed(), "Close button not displayed!", "Close button displayed");
		}

		[RegexStepDefinition(@"I confirm the 'User Name' and 'Password' fields are displayed")]
		public void ConfirmUserNameAndPasswordFieldsDisplayed()
		{
			Report.IsTrue(new LogInModal().UserNameLabelDisplayed(), "User Name label not displayed!", "User name label displayed");
			Report.IsTrue(new LogInModal().PasswordLabelDisplayed(), "Password label not displayed!", "Password label displayed");
		}

		[RegexStepDefinition("I click the Close button")]
		public void ClickCloseButton()
		{
			Report.IsTrue(new LogInModal().ClickCloseButton(), "Failed to click the Close button", "Clicked the close button");
		}

	}
}
