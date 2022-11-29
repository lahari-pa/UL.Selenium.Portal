using System;
using System.Linq;
using Mailosaur;
using Mailosaur.Models;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Reporting.Functions;
using NUnit.Framework;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using System.Collections.Generic;
using UL.Automation.Reporting;
using UL.Automation.Utilities;
using UL.Automation.Reporting.Classes;
using UL.Automation.Utilities.Mailosaur.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "ForgottenPassword")]
	class StepsForgottenPassword
	{

		[StepDefinition(@"I click the continue button")]
		public void GivenIClickTheContinueButton()
		{
			Report.StartStep(ReportSettings.StepCounter + " - I click the continue button");
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
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - I should remain on the Forgotten password dialog");
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

		[StepDefinition(@"I generate a new email address for user saved as (.*)")]
		public void GivenIGenerateANewEmailAddressForUser(string savedAs)
		{
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - I generate a new email address for user saved as " + savedAs);
			try
			{
				string sEmail = MailosaurHelpers.DefaultMailbox.CreateEmail("<random>");
				var newUser = new User {
					Email = sEmail
				};
				Context.ScenarioContext.Add(savedAs, newUser);
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
			string sEmail = MailosaurHelpers.DefaultMailbox.CreateEmail(email);
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - I enter a Wercsmart email address: " + sEmail);
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
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - In the Forgotten Password window I should see the following error messages:" + errorMessages);
			try
			{
				int i = 0;
				while (i < 10)
				{
					try
					{
						var selForgotten = new ForgottenPassword();
						string[] expectedErrorMessages = errorMessages.Split(',');
						System.Collections.Generic.List<string> actualErrorMessages = selForgotten.GetErrors();
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
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - I enter email address: " + email);
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
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - I enter email address for user: " + savedAs);
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
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - I enter email address for user: " + savedAs);
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
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + "- Checking whether there is a link the email which allows Password Reset");
			try
			{
				Report.Info("Checking whether there is a link the email which allows Password Reset");
				var matchingEmail = (Mailosaur.Models.Message)Context.ScenarioContext["Matching"];
				string myLink = matchingEmail.Html.Links[0].Href;
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
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + "- I click the link in the email I get directed to security questions");
			try
			{
				Report.Info("Clicking the link which allows Password Reset");

				//IWebElement myLink = IWebElement;

				var matchingEmail = (Mailosaur.Models.Message)Context.ScenarioContext["Matching"];
				//var myLink = matchingEmail.Html.Links[0].Href;
				var myLink = matchingEmail.Html.Links.ToList();
		
				foreach (Link link in myLink)
				{
					var myFp = new ForgottenPassword();

					if (!myFp.Reset_Password_Link(link))
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


		[StepDefinition(@"I confirm that I am on the Security Questions page")]
		public void ThenIConfirmThatIAmOnTheSecurityQuestionsPage()
		{

			var selForgotpasswordconfirm = new ForgottenPasswordQuestions();

			Report.IsTrue(selForgotpasswordconfirm.ConfirmThatUserIsOnSecurityQuestionsPage(), "Failed to reach the Security Questions page", "Successfully reached the Security Questions Page");

		}



		[StepDefinition(@"the message should contain (.*)")]
		public void ThenInTheForgottenPasswordWindowIShouldSeeTheFollowingConfirmationMessage(string confirmMessage)
		{
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - In the Forgotten Password window I should see the following confirmation message:" + confirmMessage);

			try
			{
				Delay.Seconds(5);
				Report.Info("Expecting confirmation message " + confirmMessage);
				var selForgotpasswordconfirm = new ForgottenPassword();
				string showing = selForgotpasswordconfirm.ForgotPasswordSuccessMessage();
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
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - Click the WERCSmart login button");
			try
			{
				Report.Info("Beginning to click the Login button");
				var selForgotPasswordpage = new ForgottenPassword();
				if (!selForgotPasswordpage.Wait_for_load(1))
				{
					Report.Info("Not on the Homepage, navigating...");
					SeleniumWebDriver.CurrentDriver.Navigate(SeleniumWebDriver.BaseTestUrl);
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
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - I click the cancel button");
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
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - I answer the security questions for Account: " + savedAs);
			try
			{
				var myForgotPw = new ForgottenPasswordQuestions();
				Report.IsTrue(myForgotPw.Forgot_Password_Questions(savedAs), "Failed to Answer Security Questions", "Security Questions Answered Successfully");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I enter a new password: (.*) and verify: (.*)")]
		public void ThenIEnterANewPasswordPasswordAndVerifyPassword(string newPw, string verifyPw)
		{
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - I answer the security questions");
			try
			{
				var myForgotPw = new ForgottenPasswordQuestions();

				Report.IsTrue(myForgotPw.New_Password_Form(newPw, verifyPw), "Failed to Enter New Password and Verify",
					"New Password Entered and Verified");

				Context.ScenarioContext.Add("NewPassword", newPw);

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the Login button on Forgotten Password")]
		public void ThenIClickTheLoginButton()
		{
			Report.StartStep(ReportDetails.CurrentDetails.StepCounter + " - I click the Login button");
			try
			{
				var myForgotPw = new ForgottenPasswordQuestions();
				GeneralUtilities.Wait_for_load_finish();
				Report.IsTrue(myForgotPw.Login_click(), "Failed to Click Login Button", "Login Button Clicked");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}



	}
}
