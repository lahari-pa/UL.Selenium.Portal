using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mailosaur;
using NUnit.Framework;
using SafewareReporting;
using SafewareSeleniumUtilities;
using SeleniumUtilities;

using TechTalk.SpecFlow;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "ForgottenPassword")]
	class Steps_ForgottenPassword
	{

		[StepDefinition(@"I click the next button")]
		public void GivenIClickTheNextButton()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click the next button");
			try
			{
				var Sel_Forgotten = new ForgottenPassword();
				Sel_Forgotten.Click_Continue();
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
				Delay.Seconds(10);
				var Sel_Forgotten = new ForgottenPassword();
				Assert.That(Sel_Forgotten.Exists, "Forgotten password page should be showing.");
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
				User NewUser = new User();
				NewUser.Email = sEmail;
				ScenarioContext.Current.Add(savedAs, NewUser);
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
				var Sel_Forgotten = new ForgottenPassword();
				Sel_Forgotten.Enter_Email(sEmail);
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
				Delay.Seconds(10);
				var Sel_Forgotten = new ForgottenPassword();
				var ExpectedErrorMessages = errorMessages.Split(',');
				var ActualErrorMessages = Sel_Forgotten.GetErrors();

				foreach (string ExpectedErrorMessage in ExpectedErrorMessages)
				{
					Report.IsTrue(ActualErrorMessages.Contains(ExpectedErrorMessage), "Expected Error message: " + ExpectedErrorMessage + " is not showing.", "Expected error message: " + ExpectedErrorMessage + " is showing.");
				}

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"I enter a email address: (.*)")]
		public void GivenIEnterAEmailAddress(string email)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I enter email address: " + email);
			try
			{
				Delay.Seconds(10);
				var Sel_Forgotten = new ForgottenPassword();
				Sel_Forgotten.Enter_Email(email);
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
				var UserDetails = (User)Context.GetFromContext(savedAs);
				Report.Info("Found an email of: '" + UserDetails.Email + "'");
				Report.Info("Inputting email...");
				var Sel_Forgotten = new ForgottenPassword();
				Sel_Forgotten.Enter_Email(UserDetails.Email);
				Report.Success("Email input successfully!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the continue button in the Forgotten Password window")]
		public void GivenIClickTheContinueButton()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking the continue button in the Forgotten Password window");
			try
			{
				Report.Info("Attempting to click the continue button...");
				var Sel_Forgotten = new ForgottenPassword();
				Sel_Forgotten.Click_Continue();
				Report.Success("Continue clicked successfully");
				Delay.Seconds(10);

				try
				{
					ServerError ThisServerError = new ServerError();
					if (ThisServerError.Wait_for_load())
					{
						Report.Error("Server error is showing: " + ThisServerError.GetErrorMessage());
						ThisServerError.Click_Close();
					}

				}
				catch (Exception)
				{
					//just catch...
				}


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the email should contain a link to reset a WERCSmart Account Password")]
		public void ThenTheEmailShouldContainALinkToSetUpTheWERCSmartAccount()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Checking whether there is a link the email which allows Password Reset");
			try
			{
				Report.Info("Checking whether there is a link the email which allows Password Reset");
				Email MatchingEmail = (Email)ScenarioContext.Current["Matching"];
				var myLink = MatchingEmail.Html.Links[0].Href;
				Report.Info("Found a link: '" + myLink + "' in the email!");
				Context.AddToContext("EmailLink", myLink);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

	}
}
