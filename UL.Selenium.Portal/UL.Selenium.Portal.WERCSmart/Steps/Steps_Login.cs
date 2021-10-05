using System;
using System.Reflection;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Login"), Scope(Tag = "WERCSmart_Login")]
	class StepsLogin
	{
		[StepDefinition(@"I click on the Forgot Your Password Link")]
		[When(@"I click on the Forgot Your Password Link")]
		[StepDefinition(@"I click on the Forgot Your Password Link")]
		[StepDefinition(@"I click on the Forgot Your Password Link")]
		public void GivenIClickOnTheForgotYourPasswordLink()
		{
			Report.IsTrue(new Login().Click_Forgotten_Password(), "Failed to click 'Forgot Your Password?'", "Successfully clicked 'Forgot Your Password?'");
		}

		[StepDefinition(@"I click on the New to WERCSmart Link")]
		[StepDefinition(@"\[WERCSmart] I click on the New to WERCSmart Link")]
		public void GivenIClickOnTheNewToWercsmartLink()
		{
			Report.IsTrue(new Login().Click_New_To_WercSmart(), "Failed to click 'New Tt WercSmart' link",
				"Clicked 'New to WERCSmart' link");
		}

		[StepDefinition(@"From the Language drop down I select (.*)")]
		public void WhenFromTheLanguageDropDownISelect(string language)
		{
			Report.StartStep(ReportSettings.StepCounter + " " + MethodBase.GetCurrentMethod().Name);
			try
			{


				Report.Info("Attempting to select " + language + " from the Language Select drop down");
				var selLogin = new Login();
				selLogin.Change_Language(language);
				Report.Screenshot();
				Report.Success("Language selected!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"The element: (.*) should display text: (.*)")]
		public void ThenIShouldSeeForTheDialog(string dialog, string expectedText)
		{
			var selLogin = new Login();
			Report.Info("Expecting to find: '" + expectedText + "' for the '" + dialog + "' text");
			string showing = "";
			switch (dialog)
			{
				case ("sign in"):
					showing = selLogin.Form_Header_Text();
					break;
				case ("email label"):
					showing = selLogin.Email_Header_Text();
					break;
				case ("password label"):
					showing = selLogin.Password_Header_Text();
					break;
				case ("forgotten password"):
					showing = selLogin.Forgotten_Password_Text();
					break;
				case ("login button"):
					showing = selLogin.Login_Button_Text();
					break;
				default:
					throw new Exception("Dialog: '" + dialog + "' was not found in the tree!");
			}
			Report.Info("Found: '" + showing + "' for the '" + dialog + "' text");
			Report.IsTrue(expectedText.Trim() == showing.Trim(), "Text was incorrect!", "Sign In text was showing as expected!");
		}

		[StepDefinition(@"I ensure that the (email|password) input field is not populated")]
		public void ThenIEnsureThatTheInputFieldIsNotPopulated(string inputField)
		{
			Report.StartStep(ReportSettings.StepCounter + " I ensure that the " + inputField + " input field is not populated");
			try
			{
				var selLogin = new Login();
				Report.Info("Ensuring that the " + inputField + " input field is empty");
				switch (inputField)
				{
					case ("email"):
						selLogin.EmailField = "";
						break;
					case ("password"):
						selLogin.PasswordField = "";
						break;
				}

				Report.Success("Input field: '" + inputField + "' should no longer be populated");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the Login button")]
		public void IClickTheLoginButton()
		{
			Report.IsTrue(new Login().Click_Login(), "Failed to click the log in button", "Clicked the log in button");
		}

		[StepDefinition(@"I should see the following error message for (email|password): (.*)")]
		public void ThenIShouldSeeTheFollowingErrorMessageForField(string field, string error)
		{
			var selLogin = new Login();
			Report.Info("Getting the validation message for field: '" + field + "'");
			string errorShowing = "";
			switch (field)
			{
				case "email":
					errorShowing = selLogin.Email_Error_Text();
					break;
				case "password":
					errorShowing = selLogin.Password_Error_Text();
					break;
			}
			Report.Info("Expecting to find message: '" + error + "'");
			Report.Info("Actual message was: '" + errorShowing + "'");
			Report.IsTrue(errorShowing?.Trim() == error.Trim(), "Error message was not as expected!", "Error message was showing correctly!");
		}

		[StepDefinition(@"I login as user: (.*)")]
		public void GivenILoginAsUser(string username)
		{
			var user = (WERCSmartUser)Context.GetFromContext(username);
			if (user == null)
			{
				throw new Exception("Failed to find user in context: " + username);
			}
			if (!new Login().WaitForContainerToBeVisible())
			{
				throw new Exception("Log in page did not load after 30 seconds!");
			}
			this.GivenIPopulateTheInputFieldWith("email", user.Email);
			this.GivenIPopulateTheInputFieldWith("password", user.Password);
			Report.Screenshot();
			this.IClickTheLoginButton();
			Report.IsTrue(new Login().WaitForContainerToBeInvisible(), "Did not redirect from Log in page!");
		}

		[StepDefinition(@"I log in as user: (.*) with password: (.*)")]
		public void ThenILogInAsUserSavedasXWithPasswordY(string username, string password)
		{
			if (!new Login().WaitForContainerToBeVisible())
			{
				throw new Exception("Log in page did not load after 30 seconds!");
			}
			var user = (WERCSmartUser)Context.GetFromContext(username);
			this.GivenIPopulateTheInputFieldWith("email", user.Email);
			this.GivenIPopulateTheInputFieldWith("password", password);
			Report.Screenshot();
			this.IClickTheLoginButton();
			Report.IsTrue(new Login().WaitForContainerToBeInvisible(), "Did not redirect from Log in page!");
		}

		[StepDefinition(@"I populate the (email|password) input field with: (.*)")]
		public void GivenIPopulateTheInputFieldWith(string inputField, string text)
		{
			var selLogin = new Login();
			if (text.Contains("<GUID>"))
			{
				text = text.Replace("<GUID>", Guid.NewGuid().ToString().Substring(0, 6));
			}
			if (text.Contains("saved as"))
			{
				object savedAsValue = Context.GetFromContext(text.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim());
				if (savedAsValue == null)
				{
					throw new Exception("User saved as: " + text.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim() + " was not found in context.");
				}
				var savedUser = (WERCSmartUser)savedAsValue;
				switch (inputField)
				{
					case ("email"):
						text = savedUser.Email;
						break;
					case ("password"):
						text = savedUser.Password;
						break;
				}
			}
			Report.Info("Entering text");
			switch (inputField)
			{
				case ("email"):
					selLogin.EmailField = text;
					break;
				case ("password"):
					selLogin.PasswordField = text;
					break;
			}
			if(inputField == "password")
			{
				Report.Success("Entered text: ' ******** ' in the input field: '" + inputField + "'");

			}
			else
			{
				Report.Success("Entered text: '" + text + "' in the input field: '" + inputField + "'");

			}
			Report.Screenshot();
		}

		[StepDefinition(@"I should see a server error with message: (.*)")]
		public void ShouldSeeAServerErrorWithMessage(string expectedMessage)
		{
			var selServerError = new ServerErrorDialog();
			if (!selServerError.WaitForContainerToBeVisible(10))
			{
				throw new Exception("Server Error Dialog did not appear!");
			}
			string actualText = selServerError.Error_Text();
			Report.Info("Expecting to see a server error with message: '" + expectedMessage + "'");
			Report.Info("Actual error text was: '" + actualText + "'");
			Report.IsTrue(actualText.Trim() == expectedMessage.Trim(), "Message text did not match! Expected: '" + expectedMessage + "', but got: '" + actualText + "'!", "Message text matched successfully!");

		}

		[StepDefinition(@"I popupate the (email|password) input field with credentials for account: (.*)")]
		public void PopulateTheInputFieldWithCredentialsForTrevorUser(string inputField, string accountSavedAs)
		{
			var selLogin = new Login();
			if (!selLogin.WaitForContainerToBeVisible())
			{
				throw new Exception("Log in page did not load after 30 seconds!");
			}
			TReVorTestUsers user = TestUsers.GetUserSavedAs(accountSavedAs);
			if (user == null)
			{
				throw new Exception("The user saved as: " + accountSavedAs + " could not be located in TReVor!");
			}
			string value = "";
			switch (inputField)
			{
				case ("email"):
					value = user.Username;
					selLogin.EmailField = value;
					Report.Success("Text: '" + value + "' was inputted into the input field: '" + inputField + "'");
					break;
				case ("password"):
					value = user.Password;
					selLogin.PasswordField = value;
					Report.Success("Text: '******' was inputted into the input field: '" + inputField + "'");
					break;
			}
		}

		[StepDefinition(@"on the Login page I log in as test user: (.*)")]
		public void GivenILoginAsTestUser(string account)
		{
			if (!new Login().WaitForContainerToBeVisible())
			{
				throw new Exception("Log in page did not load after 30 seconds!");
			}
			TReVorTestUsers user = TestUsers.GetUserSavedAs(account);
			if (user == null)
			{
				throw new Exception("The user saved as: " + account + " could not be located in TReVor!");
			}
			this.GivenIPopulateTheInputFieldWith("email", user.Username);
			this.GivenIPopulateTheInputFieldWith("password", user.Password);
			Report.StartStep("I click the login button");
			this.IClickTheLoginButton();
			Report.IsTrue(new Login().WaitForContainerToBeInvisible(), "Did not redirect from log in page after 30 seconds!");
		}
	}
}
