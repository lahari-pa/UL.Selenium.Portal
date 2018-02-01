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
	[Binding, Scope(Tag = "Login")]
	class Steps_Login
	{
		[Given(@"I click on the Forgot Your Password Link")]
		[When(@"I click on the Forgot Your Password Link")]
		[Then(@"I click on the Forgot Your Password Link")]
		[StepDefinition(@"I click on the Forgot Your Password Link")]
		public void GivenIClickOnTheForgotYourPasswordLink()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				var Sel_Login = new Login();
				Sel_Login.Click_Forgotten_Password();

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click on the New to WERCSmart Link")]
		public void GivenIClickOnTheNewToWercsmartLink()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Given I click on the new to WERCSmart link");
			try
			{
				var Sel_Login = new Login();
				Sel_Login.Click_New_To_Wercsmart();

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
				var Sel_Login = new Login();
				Sel_Login.Change_Language(language);
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
				var Sel_Login = new Login();
				Report.Info("Expecting to find: '" + expectedText + "' for the '" + dialog + "' text");
				string Showing = "";
				switch (dialog)
				{
					case ("sign in"):
						Showing = Sel_Login.Form_Header_Text();
						break;
					case ("email label"):
						Showing = Sel_Login.Email_Header_Text();
						break;
					case ("password label"):
						Showing = Sel_Login.Password_Header_Text();
						break;
					case ("forgotten password"):
						Showing = Sel_Login.Forgotten_Password_Text();
						break;
					case ("login button"):
						Showing = Sel_Login.Login_Button_Text();
						break;
					default:
						throw new Exception("Dialog: '" + dialog + "' was not found in the tree!");
				}
				Report.Info("Found: '" + Showing + "' for the '" + dialog + "' text");
				Report.Screenshot();
				Report.IsTrue(expectedText.Trim() == Showing.Trim(), "Text was incorrect!", "Sign In text was showing as expected!");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				var Sel_Login = new Login();
				Report.Info("Ensuring that the " + inputField + " input field is empty");
				switch (inputField)
				{
					case ("email"):
						Sel_Login.Email_Field = "";
						break;
					case ("password"):
						Sel_Login.Password_Field = "";
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				var Sel_Login = new Login();
				Report.Info("Clicking the 'Login' button");
				Sel_Login.Click_Login();
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				var Sel_Login = new Login();
				Report.Info("Getting the validation message for field: '" + field + "'");
				string ErrorShowing = "";
				switch (field)
				{
					case "email":
						ErrorShowing = Sel_Login.Email_Validation();
						break;
					case "password":
						ErrorShowing = Sel_Login.Password_Validation();
						break;
				}
				Report.Info("Expecting to find message: '" + error + "'");
				Report.Info("Actual message was: '" + ErrorShowing + "'");
				Report.IsTrue(ErrorShowing.Trim() == error.Trim(), "Error message was not as expected!", "Error message was showing correctly!");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				var Sel_Login = new Login();
				if (text.Contains("<GUID>"))
				{ text = text.Replace("<GUID>", Guid.NewGuid().ToString().Substring(0, 6)); }

				Report.Info("Inputting '" + text + "' into the " + inputField + " input field");

				switch (inputField)
				{
					case ("email"):
						Sel_Login.Email_Field = text;
						break;
					case ("password"):
						Sel_Login.Password_Field = text;
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
		public void IShouldSeeAServerErrorWithMessage(string expectedMessage)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				Report.Info("Expecting to see a server error with message: '" + expectedMessage + "'");
				var Sel_ServerError = new ServerErrorDialog();
				if (!Sel_ServerError.Wait_for_load(10))
				{
					throw new Exception("Server Error Dialog did not appear!");
				}
				Delay.Seconds(Delay.SpeedFactor * 2);
				var ActualText = Sel_ServerError.Error_Text();
				Report.Info("Actual error text was: '" + ActualText + "'");
				Report.IsTrue(ActualText.Trim() == expectedMessage.Trim(), "Message text did not match! Expected: '" + expectedMessage + "', but got: '" + ActualText + "'!", "Message text matched successfully!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
	}
}
