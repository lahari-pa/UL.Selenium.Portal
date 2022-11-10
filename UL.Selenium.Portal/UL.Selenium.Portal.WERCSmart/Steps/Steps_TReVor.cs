using BoDi;
using System.Collections.Generic;
using System.Linq;
using System;
using TechTalk.SpecFlow;
using TReVor.Core.Classes.Software;
using TReVor.Integrations.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding]
	internal class StepsTReVor
	{
		internal GlobalSteps GlobalSteps { get; }
		internal RetailPartners RetailPartners { get; }
		internal Homepage Homepage { get; }
		internal WebDriverInterface WebDriverInterface { get; }

		internal StepsTReVor(IObjectContainer container)
		{
			this.WebDriverInterface = container.Resolve<WebDriverInterface>();
			this.GlobalSteps = container.Resolve<GlobalSteps>();
			this.RetailPartners = container.Resolve<RetailPartners>();
			this.Homepage = container.Resolve<Homepage>();
		}

		[StepDefinition(@"I update the password for the following TReVor test users:")]
		public void UpdateThePasswordForTheFollowingTrevorTestUsers(Table users)
		{
			Report.UseSubSteps = true;
			List<string> aliases = users.Rows.ToList().Select(x => x["User"]).ToList();

			foreach (string alias in aliases)
			{
				this.UpdatePasswordForUser(alias);
			}
		}

		[StepDefinition(@"I update the password for all TReVor Test Users within the current branch")]
		public void UpdateThePasswordForAllTrevorTestUsersWithinCurrentBranch()
		{
			Report.UseSubSteps = true;
			List<SoftwareCredentialBasic> allTestUsers = TReVorSettings.Credentials.AllCredentials.Select(x => x.Value).ToList();
			List<string> aliases = allTestUsers.Select(x => x.Alias).ToList();

			Report.Info("Updating password for the following users: " + string.Join(", ", aliases.Select(x => $"'{x}'")));
			foreach (string alias in aliases)
			{
				this.UpdatePasswordForUser(alias);
			}
		}

		[StepDefinition(@"I update the password for TReVor test user: (.*) in the change user password popup")]
		public void UpdateThePasswordForTrevorTestUser(string alias)
		{
			try
			{
				// Get user credentials from TReVor based on saved as ID
				SoftwareCredentialBasic user = TReVorSettings.Credentials.GetCredential(alias);

				if (user == null)
				{
					Report.Failure($"Unable to find TReVor test user saved as: {alias}");
					return;
				}

				string oldPassword = user.Password;
				string newPassword = this.GenerateNewPassword(oldPassword);

				ModalDialog selModal = new ModalDialog();
				if (!Report.IsTrue(selModal.WaitForContainerToBeVisible(), "Expected a modal dialog to load!", "Modal dialog loaded as expected"))
				{
					return;
				}

				// If the password has expired, the old password is required. Else it isn't.
				if (selModal.LoginPasswordFieldPresent())
				{
					Report.Info("Entering current password in the input: *******");
					selModal.EnterLoginPassword(oldPassword);
				}

				GeneralUtilities.Wait_for_load_finish();

				int attempt = 0;
				while (attempt < 10)
				{
					Report.Info("Entering new password in New Password input: *******");
					selModal.EnterNewPassword(newPassword);

					Report.Info("Entering new password in Verify Password input: *******");
					selModal.EnterVerifyPassword(newPassword);

					Report.Info("Clicking save in the Change Password popup");
					Report.IsTrue(selModal.ClickSave(), "Failed to click save in Change Password", "Successfully clicked save in Change Password");

					GeneralUtilities.Wait_for_load_finish();

					if (!selModal.WaitForContainerToBeInvisible())
					{
						if (selModal.GetAllText().Any(x => x.Contains("used too recently")))
						{
							Report.Info("The test attempted to assign a previously used password! Iterating the password suffix...");
							Report.Info($"Current attempted password is: *******");

							newPassword = this.GenerateNewPassword(newPassword);
							Report.Info($"New attempted password is: *******");

							if (selModal.Click_Close())
							{
								Report.Info($"Attempt {attempt}. Trying again...");
								attempt++;
								continue;
							}
						}

						throw new Exception("Modal dialog did not close!");
					}

					Report.Info("Updating the password in TReVor Test Users");
					this.UpdateUserTrevorPassword(user, newPassword);
					return;
				}

				Report.Failure("Failed after 10 attempts to change the password!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
			}
		}

		// ===== HELPER METHODS ===== //
		
		private void UpdatePasswordForUser(string alias)
		{
			Report.StartStep($"I update the password for user: {alias}");

			SoftwareCredentialBasic user = TReVorSettings.Credentials.GetCredential(alias);
			if (user == null)
			{
				Report.Failure($"Failed to find a user saved as: {alias}");
				return;
			}

			string currentPassword = user.Password;
			string newPassword = this.GenerateNewPassword(currentPassword);

			if (!user.UserName.Contains("@"))
			{
				Report.Info("The email did not contain an '@' so continuing to the next user.");
				return;
			}

			if (user.Alias == "PayPal")
			{
				Report.Info("We do not need to update the PayPal password");
				return;
			}

			string baseTestUrl = TReVorSettings.Variables.GetVariable("TestUrl");
			if (string.IsNullOrEmpty(baseTestUrl))
			{
				Report.Failure("Failed to find a variable called 'TestUrl'!");
				return;
			}
			
			if (!this.LoginToAccount(user))
			{
				Report.Failure("Failed to login to account!");
				return;
			}

			SeleniumWebDriver.CurrentDriver.WaitForPageLoad();

			PasswordExpired passwordExpired = new PasswordExpired();
			Login loginScreen = new Login();

			if (!this.Homepage.WaitForContainerToBeVisible(20))
			{
				// If 90 day expiry present, then attempt to reset the user's password.
				if (passwordExpired.WaitForContainerToBeVisible(5))
				{
					string message = passwordExpired.TopMessage();
					if (message != null && message.Contains("Your password has expired after 90 days for security reasons"))
					{
						Report.Info("The password expired after 90 days.");
						Report.Info("Attempting to reset password...");

						Report.Info("Entering original password...");
						passwordExpired.OriginalPassword = currentPassword;

						Report.Info("Entering new password...");
						passwordExpired.NewPassword = newPassword;

						Report.Info("Entering verify password...");
						passwordExpired.VerifyPassword = newPassword;

						Report.Info("Clicking continue");
						passwordExpired.ClickContinue();

						GeneralUtilities.Wait_for_load_finish();

						// Then the 'Thank You' page should load..
						if (passwordExpired.TopHeading().Contains("Thank You"))
						{
							if (!this.UpdateUserTrevorPassword(user, newPassword))
							{
								return;
							}

							Report.Info("Navigating to the landing page");

							SeleniumWebDriver.CurrentDriver.Navigate(baseTestUrl);

							this.GlobalSteps.ILogInWithTheAccountSavedInTrevorAs(alias);
							Report.Info("Logging out");

							this.GlobalSteps.GivenILogout();
							SeleniumWebDriver.CurrentDriver.Navigate(baseTestUrl);
							return;
						}

						Report.Failure("Failed to update password in 90 day expiry page");
						SeleniumWebDriver.CurrentDriver.Navigate().GoToUrl(baseTestUrl);
						return;
					}
				}
				else if (loginScreen.WaitForContainerToBeVisible(5))
				{
					string errorMessage = loginScreen.AccountNotificationsMessageText();
					if (!string.IsNullOrEmpty(errorMessage))
					{
						Report.Failure($"Failed to login. Found error message: {errorMessage}");
					}

					errorMessage = loginScreen.GetServerErrorMessage();
					if (!string.IsNullOrEmpty(errorMessage))
					{
						Report.Failure($"Failed to login. Found server error: {errorMessage}");
					}
				}

				// Then we're on the log in screen (incorrect password)
				Report.Info("Navigating to the landing page");
				SeleniumWebDriver.CurrentDriver.Navigate().GoToUrl(baseTestUrl);
				return;
			}
			
			string alert = this.RetailPartners.WarningMessage();

			if (alert != null && alert.Contains("The recipients listed below have additional Data Consent requests"))
			{
				Report.Info("Account needs to be reviewed - data consent requests. Continuing to the next account");
				Report.Info("Logging out");
				this.GlobalSteps.GivenILogout();
				return;
			}

			new StepsHomepage().IfDataConsentRequestsModalIsShowingAddRequiredTiers();

			StepsMyAccount selMyAccount = new StepsMyAccount();

			Report.Info("Navigating to My Account from the homepage");
			selMyAccount.GivenINavigateToTheMyAccountPage();

			Report.Info("Clicking Reset Password for the current logged in user");
			selMyAccount.GivenIGoToActionInUserGrid("Reset Password");

			Report.Info($"Updating the password for test user {alias}");
			this.UpdateThePasswordForTrevorTestUser(alias);

			if (!new Login().WaitForContainerToBeVisible())
			{
				Report.Info("Redirected to an unexpected page!");
			}

			Report.Info("Navigating to the landing page");
			SeleniumWebDriver.CurrentDriver.Navigate().GoToUrl(baseTestUrl);

			Report.Info("Checking I can log in with the new credentials");
			this.GlobalSteps.ILogInWithTheAccountSavedInTrevorAs(alias);

			Report.Info("Logging out");
			this.GlobalSteps.GivenILogout();

			SeleniumWebDriver.CurrentDriver.Navigate().GoToUrl(baseTestUrl);
		}

		private string GenerateNewPassword(string currentPassword)
		{
			string newPassword = null;

			// If the current password ends in a character, append with a 1 for the new password
			if (char.IsDigit(currentPassword.Last()))
			{
				char[] passwordChr = currentPassword.ToCharArray();
				string result = string.Join("", passwordChr.Select(x => char.IsDigit(x) ? x.ToString() : "|")).Split('|').LastOrDefault()?.Trim();

				if (result != null)
				{
					newPassword = currentPassword.TrimEnd(result.ToCharArray()) + (Convert.ToInt32(result) + 1);
				}
			}

			if (newPassword == null)
			{
				newPassword = $"{currentPassword}1";
			}

			return newPassword;
		}

		private bool UpdateUserTrevorPassword(SoftwareCredentialBasic user, string newPassword)
		{
			Report.Info("Attempting to store the updated password in TReVor...");
			if (!TReVorSettings.Credentials.UpdateCredential(user.Alias, user.UserName, newPassword))
			{
				Report.Failure("Failed to save password in TReVor (please contact a member of the TReVor team)!");
				return false;
			}

			Report.Success("Updated password stored successfully!", showScreenshot: false);

			Report.Info("Refreshing stored credentials...");
			TReVorSettings.Credentials.Refresh();

			Report.Info("Verifying that the password was updated...");
			user = TReVorSettings.Credentials.GetCredential(user.Alias);

			if (!string.Equals(user.Password, newPassword))
			{
				Report.Failure("Failed to find the updated password in TReVor (please contact a member of the TReVor team)!");
				return false;
			}

			Report.Success("New password found successfully!", showScreenshot: false);
			return true;
		}

		private bool LoginToAccount(SoftwareCredentialBasic user)
		{
			TopMenuBar topMenuBar = new TopMenuBar();
			if (topMenuBar.WaitForContainerToBeVisible(1) && topMenuBar.LoggedIn())
			{
				Report.Info("Logged in, logging out");
				if (!Report.IsTrue(new TopMenuBar().ClickSignOut(), "Failed to click Sign Out"))
				{
					return false;
				}
			}

			return this.GlobalSteps.PerformBasicLogin(user.UserName, user.Password);
		}
	}
}
