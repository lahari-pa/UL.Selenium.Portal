using System;
using System.Reflection;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Automation_Classes.Universal_Functions;
using NTTQA_Reporting_Module;
using NTTQA_Reporting_Module.Reporting.Core;
using NTTQA_TReVor_Module.Cache;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "Login"), Scope(Tag = "WERCSmart_Login")]
	class StepsLogin
	{
		[StepDefinition(@"I click on the Forgot Your Password Link")]
		[When(@"I click on the Forgot Your Password Link")]
		[Then(@"I click on the Forgot Your Password Link")]
		[StepDefinition(@"I click on the Forgot Your Password Link")]
		public void GivenIClickOnTheForgotYourPasswordLink()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				var selLogin = new Login();
				selLogin.Click_Forgotten_Password();

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click on the New to WERCSmart Link")]
		[StepDefinition(@"\[WERCSmart] I click on the New to WERCSmart Link")]
		public void GivenIClickOnTheNewToWercsmartLink()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Given I click on the new to WERCSmart link");
			try
			{
				var selLogin = new Login();
				selLogin.Click_New_To_Wercsmart();

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"From the Language drop down I select (.*)")]
		public void WhenFromTheLanguageDropDownISelect(string language)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
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

		[StepDefinition(@"I should see for the (.*): (.*)")]
		public void ThenIShouldSeeForTheDialog(string dialog, string expectedText)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
			try
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
				Report.Screenshot();
				Report.IsTrue(expectedText.Trim() == showing.Trim(), "Text was incorrect!", "Sign In text was showing as expected!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I ensure that the (email|password) input field is not populated")]
		public void ThenIEnsureThatTheInputFieldIsNotPopulated(string inputField)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " I ensure that the " + inputField + " input field is not populated");
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

		[StepDefinition(@"I select the Login button")]
		public void WhenISelectTheLoginButton()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " I select the Login button");
			try
			{
				var selLogin = new Login();
				Report.Info("Clicking the 'Login' button");
				selLogin.Click_Login();
				Report.Info("Login button clicked successfully");

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see the following error message for (email|password): (.*)")]
		public void ThenIShouldSeeTheFollowingErrorMessageForField(string field, string error)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " I should see the following error message for " + field + ": " + error);
			try
			{
				var selLogin = new Login();
				Report.Info("Getting the validation message for field: '" + field + "'");
				string errorShowing = "";
				switch (field)
				{
					case "email":
						errorShowing = selLogin.Email_Validation();
						break;
					case "password":
						errorShowing = selLogin.Password_Validation();
						break;
				}
				Report.Info("Expecting to find message: '" + error + "'");
				Report.Info("Actual message was: '" + errorShowing + "'");
				Report.IsTrue(errorShowing.Trim() == error.Trim(), "Error message was not as expected!", "Error message was showing correctly!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I login as user: (.*)")]
		public void GivenILoginAsUser(string username)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " I login as user: " + username);
			try
			{
				var user = (WERCSmartUser)Context.GetFromContext(username);
				GivenIPopulateTheInputFieldWith("email", user.Email);
				Delay.Seconds(5);
				GivenIPopulateTheInputFieldWith("password", user.Password);
				Delay.Seconds(5);
				Report.Screenshot();
				WhenISelectTheLoginButton();
				Delay.Seconds(5);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I log in as user: (.*) with password: (.*)")]
		public void ThenILogInAsUserSavedasXWithPasswordY(string username, string password)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " I login as user: " + username + " with password: " + password);
			try
			{
				Delay.Seconds(3);
				var user = (WERCSmartUser)Context.GetFromContext(username);
				GivenIPopulateTheInputFieldWith("email", user.Email);
				Delay.Seconds(5);
				GivenIPopulateTheInputFieldWith("password", password);
				Delay.Seconds(5);
				Report.Screenshot();
				WhenISelectTheLoginButton();
				Delay.Seconds(5);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I populate the (email|password) input field with: (.*)")]
		public void GivenIPopulateTheInputFieldWith(string inputField, string text)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- I populate the " + inputField + " input field with: " + text);
			try
			{
				var selLogin = new Login();
				if (text.Contains("<GUID>"))
				{
					text = text.Replace("<GUID>", Guid.NewGuid().ToString().Substring(0, 6));
				}

				if (text.Contains("saved as"))
				{
					var savedAsValue = Context.GetFromContext(text.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim());

					if (savedAsValue == null)
					{
						throw new Exception("Expected value: " + text.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim() +
											" was not found in context.");
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

				Report.Info("Inputting '" + text + "' into the " + inputField + " input field");

				switch (inputField)
				{
					case ("email"):
						selLogin.EmailField = text;
						break;
					case ("password"):
						selLogin.PasswordField = text;
						break;
				}

				Report.Success("Text: '" + text + "' was inputted into the input field: '" + inputField + "'");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see a server error with message: (.*)")]
		public void ShouldSeeAServerErrorWithMessage(string expectedMessage)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				Report.Info("Expecting to see a server error with message: '" + expectedMessage + "'");
				var selServerError = new ServerErrorDialog();
				if (!selServerError.Wait_for_load(10))
				{
					throw new Exception("Server Error Dialog did not appear!");
				}
				Delay.Seconds(Delay.SpeedFactor * 2);
				var actualText = selServerError.Error_Text();
				Report.Info("Actual error text was: '" + actualText + "'");
				Report.IsTrue(actualText.Trim() == expectedMessage.Trim(), "Message text did not match! Expected: '" + expectedMessage + "', but got: '" + actualText + "'!", "Message text matched successfully!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I popupate the (email|password) input field with credientials for account: (.*)")]
		public void PopulateTheInputFieldWithCredentialsForTrevorUser(string inputField, string accountSavedAs)
		{
			try
			{
				var selLogin = new Login();
				var user = TestUsers.GetUserSavedAs(accountSavedAs);
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
						break;
					case ("password"):
						value = user.Password;
						selLogin.PasswordField = value;
						break;
				}
				Report.Success("Text: '" + value + "' was inputted into the input field: '" + inputField + "'");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
			}
		}
	}
}
