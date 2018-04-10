using System;
using System.Linq;
using Mailosaur;
using NPOI.SS.Formula.Functions;
using NUnit.Framework;
using OpenQA.Selenium;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "ForgottenPassword")]
	class StepsForgottenPassword
	{

		[StepDefinition(@"I click the continue button")]
		public void GivenIClickTheContinueButton()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click the continue button");
			try
			{
				var selForgotten = new ForgottenPassword();
				int i = 0;
				while (i < 10)
				{
					try
					{
						selForgotten.Click_Continue();
						break;
					}
					catch (Exception)
					{
						i++;
						Delay.Seconds(1);
					}


				}
				Delay.Seconds(2 * Delay.SpeedFactor);
				Report.Screenshot();
				Report.Success("continue button clicked!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should remain on the Forgotten Password dialog")]
		public void ThenIShouldRemainOnTheForgottenPasswordDialog()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should remain on the Forgotten password dialog");
			try
			{
				Delay.Seconds(5);
				var selForgotten = new ForgottenPassword();
				Assert.That(selForgotten.Exists, "Forgotten password page should be showing.");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[Given(@"I generate a new email address for user saved as (.*)")]
		public void GivenIGenerateANewEmailAddressForUser(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I generate a new email address for user saved as " + savedAs);
			try
			{
				string sEmail = EmailFunctions.CreateEmail("<random>");
				User newUser = new User();
				newUser.Email = sEmail;
				ScenarioContext.Current.Add(savedAs, newUser);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"I enter a Wercsmart email address: (.*)")]
		public void GivenIEnterAWercsmartEmailAddress(string email)
		{
			string sEmail = EmailFunctions.CreateEmail(email);
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I enter a Wercsmart email address: " + sEmail);
			try
			{
				Delay.Seconds(10);
				var selForgotten = new ForgottenPassword();
				selForgotten.Enter_Email(sEmail);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"In the Forgotten Password window I should see the following error messages: (.*)")]
		public void ThenInTheForgottenPasswordWindowIShouldSeeTheFollowingErrorMessages(string errorMessages)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Forgotten Password window I should see the following error messages:" + errorMessages);
			try
			{
				int i = 0;
				while (i < 10)
				{
					try
					{
						var selForgotten = new ForgottenPassword();
						var expectedErrorMessages = errorMessages.Split(',');
						var actualErrorMessages = selForgotten.GetErrors();
						foreach (string expectedErrorMessage in expectedErrorMessages)
						{
							Report.IsTrue(actualErrorMessages.Contains(expectedErrorMessage), "Expected Error message: " + expectedErrorMessage + " is not showing.", "Expected error message: " + expectedErrorMessage + " is showing.");
						}
						break;
					}
					catch (Exception)
					{
						i++;
						Delay.Seconds(1);
					}


				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"I enter a email address: (.*)")]
		[StepDefinition(@"I enter an email address: (.*)")]
		public void GivenIEnterAEmailAddress(string email)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I enter email address: " + email);
			try
			{
				if (email.Contains("savedas"))
				{
					email = email.Replace("savedas", "").Trim();
					email = Context.GetFromContext(email).ToString();
				}

				int i = 0;
				while (i < 10)
				{
					try
					{
						var selForgotten = new ForgottenPassword();
						selForgotten.Enter_Email(email);
						break;
					}
					catch (Exception)
					{
						i++;
						Delay.Seconds(1);
					}
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I enter the email address for user saved as: (.*)")]
		public void GivenIEnterAEmailAddressForUser(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I enter email address for user: " + savedAs);
			try
			{
				Report.Info("Getting user information for User: '" + savedAs + "'");
				var userDetails = (User)Context.GetFromContext(savedAs);
				Report.Info("Found an email of: '" + userDetails.Email + "'");
				Report.Info("Inputting email...");
				var selForgotten = new ForgottenPassword();
				selForgotten.Enter_Email(userDetails.Email);
				Report.Success("Email input successfully!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I enter the email address for the Account saved as: (.*)")]
		public void GivenIEnterTheEmailAddressForTheAccountSavedAsX(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I enter email address for user: " + savedAs);
			try
			{
				Report.Info("Getting user information for User: '" + savedAs + "'");
				var userDetails = (WERCSmartUser)Context.GetFromContext(savedAs);
				Report.Info("Found an email of: '" + userDetails.Email + "'");
				Report.Info("Inputting email...");
				var selForgotten = new ForgottenPassword();
				selForgotten.Enter_Email(userDetails.Email);
				Report.Success("Email input successfully!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"the email should contain a link to reset a WERCSmart Account Password")]
		public void ThenTheEmailShouldContainALinkToSetUpTheWercSmartAccount()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Checking whether there is a link the email which allows Password Reset");
			try
			{
				Report.Info("Checking whether there is a link the email which allows Password Reset");
				Email matchingEmail = (Email)ScenarioContext.Current["Matching"];
				var myLink = matchingEmail.Html.Links[0].Href;
				Report.Info("Found a link: '" + myLink + "' in the email!");
				Context.AddToContext("EmailLink", myLink);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the link in the email I get directed to security questions")]
		public void WhenIClickTheLinkInTheEmailIGetDirectedToSecurityQuestions()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- I click the link in the email I get directed to security questions");
			try
			{
				Report.Info("Clicking the link which allows Password Reset");

				//IWebElement myLink = IWebElement;

				Email matchingEmail = (Email)ScenarioContext.Current["Matching"];
				//var myLink = matchingEmail.Html.Links[0].Href;
				var myLink = matchingEmail.Html.Links.ToList();

				foreach (var Link in myLink)
				{
					var myFP = new ForgottenPassword();

					if (!myFP.Reset_Password_Link(Link))
					{
						throw new Exception("Failed to Click Reset Password Link");
					}
					Report.Success("Reset Password Link Clicked");

				}


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"the message should contain (.*)")]
		public void ThenInTheForgottenPasswordWindowIShouldSeeTheFollowingConfirmationMessage(string confirmMessage)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Forgotten Password window I should see the following confirmation message:" + confirmMessage);

			try
			{
				Delay.Seconds(5);
				Report.Info("Expecting confirmation message " + confirmMessage);
				var sel_forgotpasswordconfirm = new ForgottenPassword();
				var showing = sel_forgotpasswordconfirm.ForgotPasswordSuccessMessage();
				Report.IsTrue(confirmMessage == showing, "Success message showing " + showing, "Success message was showing correctly");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}

		}
		/// <summary>
		/// click the login button that shows on the forget password page
		/// </summary>
		[StepDefinition(@"I click the login button in the Forgotten Password window")]
		public void ClickTheLoginButton()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Click the WERCSmart login button");
			try
			{
				var blah = ResourcePool.UserPool.WERCSmart.WERCSmartUsers;
				Report.Info("Beginning to click the Login button");
				var selForgotPasswordpage = new ForgottenPassword();
				if (!selForgotPasswordpage.Wait_for_load(1))
				{
					Report.Info("Not on the Homepage, navigating...");
					SeleniumBrowser.Navigate(GlobalParameters.TestUrl);
					Report.IsTrue(selForgotPasswordpage.Wait_for_load(30), "Homepage failed to load!", "Homepage loaded successfully!");
				}

				selForgotPasswordpage.Click_Login_Button();
				Report.Screenshot();
				Report.Success("Login button clicked!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Clicking the Cancel button on the forgot password screen
		/// </summary>
		[StepDefinition(@"I click the cancel button")]
		public void GivenIClickTheCancelButton()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click the cancel button");
			try
			{
				var selForgotten = new ForgottenPassword();
				int i = 0;
				while (i < 10)
				{
					try
					{
						selForgotten.Click_Cancel();
						break;
					}
					catch (Exception)
					{
						i++;
						Delay.Seconds(1);
					}


				}
				Report.Screenshot();
				Report.Success("cancel button clicked!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I answer the security questions for Account: (.*)")]
		public void ThenIAnswerTheSecurityQuestionsForAccountX(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I answer the security questions for Account: " + savedAs);
			try
			{
				var myForgotPW = new ForgottenPassword_Questions();
				Report.IsTrue(myForgotPW.Forgot_Password_Questions(savedAs), "Failed to Answer Security Questions", "Security Questions Answered Successfully");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I enter a new password: (.*) and verify: (.*)")]
		public void ThenIEnterANewPasswordPasswordAndVerifyPassword(string new_pw, string verify_pw)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I answer the security questions");
			try
			{
				var myForgotPW = new ForgottenPassword_Questions();

				Report.IsTrue(myForgotPW.New_Password_Form(new_pw, verify_pw), "Failed to Enter New Password and Verify",
					"New Password Entered and Verified");

				ScenarioContext.Current.Add("NewPassword", new_pw);

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the Login button")]
		public void ThenIClickTheLoginButton()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click the Login button");
			try
			{
				var myForgotPW = new ForgottenPassword_Questions();
				Report.IsTrue(myForgotPW.Login_click(), "Failed to Click Login Button", "Login Button Clicked");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}



	}
}
