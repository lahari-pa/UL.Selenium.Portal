using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Mailosaur;
using MySDS.SeleniumClasses;
using NUnit.Framework;
using SafewareReporting;
using SafewareSeleniumUtilities;
using SeleniumUtilities;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "Signup")]
	class Steps_Signup
	{
		[StepDefinition(@"the signup page should appear")]
		public void ThenTheSignupPageShouldAppear()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " " + MethodBase.GetCurrentMethod().Name);
			try
			{
				Report.Info("Checking that the signup page has loaded...");
				var Sel_Signup = new Signup();
				Report.IsTrue(Sel_Signup.Wait_for_load(), "Signup page did not load!", "Successfully navigated to the signup page!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}



		[StepDefinition(@"I define the user: (.*) with the following parameters:")]
		public void DefineUser(string savedAs, Table parameters)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Set up user saved as: '" + savedAs + "'");
			try
			{
				Report.Info("Setting up account details for user: '" + savedAs + "'");
				var account = parameters.CreateInstance<User>();
				account.Email = EmailFunctions.CreateEmail(account.Email);
				Context.AddToContext(savedAs, account);
				Report.Success("Account details saved!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I enter signup email for user: (.*)")]
		public void GivenIEnterSignupEmail(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Enter sign up email for user: " + savedAs);
			try
			{
				var User = (User)Context.GetFromContext(savedAs);
				Report.Info("Entering email: '" + User.Email + "'");
				var Sel_Signup = new Signup();
				Sel_Signup.Enter_Email(User.Email);
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm signup email for user: (.*)")]
		public void GivenIConfirmSignupEmail(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Enter confirm sign up email for user: " + savedAs);
			try
			{
				var User = (User)Context.GetFromContext(savedAs);
				Report.Info("Entering email: '" + User.Email + "'");
				var Sel_Signup = new Signup();
				Sel_Signup.Enter_ConfirmEmail(User.Email);
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click on submit")]
		public void GivenIClickOnSubmit()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Click on submit");
			try
			{
				Report.Info("Attempting to click submit...");
				var Sel_Signup = new Signup();
				int count = 0;
				while (!Sel_Signup.Click_Submit() && count < 30)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					count++;
				}
				Report.Success("Submit clicked successfully!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the signup thank you page should appear")]
		public void ThenTheSignupThankYouPageShouldAppear()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- The signup thank you page should appear");
			try
			{
				Report.Info("Expecting a signup page to appear");
				var Sel_Signup = new Signup();
				int count = 0;
				while (!Sel_Signup.Wait_for_load(1) && count < 60)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					count++;
				}
				Report.Info("Signup page appeared!");
				Report.IsTrue(Sel_Signup.Sign_Up_Thank_You_Page_Exists(),
					"The sign up thank you page does not exist as expected",
					"The sign up page appeared, as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I save the current emails in the inbox for user saved as: (.*)")]
		public void GivenISaveTheCurrentEmailsInTheInboxFor(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- I save the current emails in this inbox so I can locate the new one when it arrives");
			try
			{
				var User = (User)Context.GetFromContext(savedAs);
				Report.Info("Storing inbox for address: " + User.Email);
				EmailFunctions.StoreCurrentInbox(User.Email);
				Report.Success("Inbox stored successfully!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"there (should|should not) be a new email for user: (.*) from: (.*) with the title: (.*)")]
		public void ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle(string shouldOrNot, string savedAs, string emailFrom, string title)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Checking whether there is a new email for user: " + savedAs + " from " + emailFrom + " with title: " + title);
			try
			{
				var User = (User)Context.GetFromContext(savedAs);
				if (EmailFunctions.WaitForInboxDifferences(User.Email))
				{
					var Differences = EmailFunctions.GetInboxDifferences(User.Email);
					var MatchingEmail = Differences.FirstOrDefault(x => x.From.FirstOrDefault().Address == emailFrom && x.Subject == title);

					using (var sw = new StreamWriter(@"C:\temp\testemail.html"))
					{
						sw.Write(MatchingEmail.Html.Body);
						sw.Flush();
						sw.Close();
					}

					Context.AddToContext("Matching", MatchingEmail);

					if (shouldOrNot == "should")
					{
						Report.IsTrue(MatchingEmail != null, "A matching email has not been found.", "Email with subject: " + MatchingEmail.Subject + " and body: " + MatchingEmail.Text + " has been found.");
					}
					else
					{
						Report.IsTrue(MatchingEmail == null, "A matching email has been found.", "Email with subject: " + MatchingEmail.Subject + " and body: " + MatchingEmail.Text + " has not been found.");
					}

				}
				else
				{
					if (shouldOrNot == "should not")
					{
						Report.Success("As expected, no email has been received");
					}
					else
					{
						throw new Exception("Expected email did not arrive");
					}

				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the email should contain a link to set up the WERCSmart account")]
		public void ThenTheEmailShouldContainALinkToSetUpTheWERCSmartAccount()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Checking whether there is a link the email which sets up the WERCSmart account");
			try
			{
				Report.Info("Checking that the email contains a link to set up a WERCSmart Account");
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

		[StepDefinition(@"I click on the link I should see the WERCSmart new account page")]
		public void WhenIClickOnTheLinkIShouldSeeTheWERCSmartNewAccountPage()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- When I click on the link I should see the WERCSmart new account page");
			try
			{
				Report.Info("Attempting to open the email link");
				var mylink = Context.GetFromContext("EmailLink").ToString();
				Report.Info("Found a signup link of: '" + mylink + "'");
				Report.Info("Attempting to navigate to the link...");
				GlobalParameters.Browser.Navigate(mylink);
				Report.Success("Navigated to the link!");
				NewUser UserCreatonPage = new NewUser();
				Report.IsTrue(UserCreatonPage.Wait_for_load(30), "New User Creation page did not load!", "User creation page loaded as expected!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I enter the information into the new user form for user saved as: (.*)")]
		public void WhenIEnterTheFollowingInformationIntoTheNewUserForm(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- I enter the data in the table into the new account form.");
			try
			{
				var User = (User)Context.GetFromContext(savedAs);
				NewUser ThisNewUser = new NewUser();
				ThisNewUser.Country = User.Country;
				ThisNewUser.First_name = User.FirstName;
				ThisNewUser.Last_name = User.LastName;
				ThisNewUser.Password = User.Password;
				ThisNewUser.ConfirmPassword = User.Password;
				ThisNewUser.Address1 = User.Address1;
				ThisNewUser.Address2 = User.Address2;
				ThisNewUser.City = User.City;

				if (User.Country == "UNITED STATES")
				{ ThisNewUser.SelectUSState(User.State); }
				else
				{ ThisNewUser.State = User.State; }

				ThisNewUser.Zip = User.Zip;
				ThisNewUser.CompanyName = User.CompanyName;
				ThisNewUser.CompanyPhone = User.CompanyPhone;
				//ThisNewUser.CountryCode = User.CountryCode;
				ThisNewUser.EmergencyPhoneNumber = User.EmergencyPhoneNumber;
				ThisNewUser.SelectSupplierType(User.SupplierType);
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the new user form I click on continue")]
		public void WhenInTheNewUserFormIClickOnContinue()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- I click continue on the New User form");
			try
			{
				Report.Info("Attempting to click continue");
				NewUser ThisNewUser = new NewUser();
				Report.IsTrue(ThisNewUser.ClickContinue(), "Failed to click continue!", "Successfully clicked continue!");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should be on the Security questions page of the form")]
		public void ThenIShouldBeOnTheSecurityQuestionsPageOfTheForm()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Ensure navigation to Security Questions");
			try
			{
				Report.Info("Checkin that the Security Questions page has loaded...");
				NewUser ThisNewUser = new NewUser();
				Report.IsTrue(ThisNewUser.WaitForPageTitle("Security Questions", 60),
					"Security Questions page has not loaded as expected.",
					"Security Questions page loaded as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I enter the following into the Security Questions window for user saved as: (.*)")]
		public void EnterTheFollowingIntoSecurityQuestions(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Enter Security Question information for user: " + savedAs);
			try
			{
				Report.Info("Beginning entering Security Questions!");
				var User = (User)Context.GetFromContext(savedAs);
				var UserForm = new NewUser();

				UserForm.EnterQuestionAnswer("1", User.CityQuestion);
				UserForm.EnterQuestionHint("1", User.CityHint);
				UserForm.EnterQuestionAnswer("2", User.CarQuestion);
				UserForm.EnterQuestionHint("2", User.CarHint);
				UserForm.EnterQuestionAnswer("3", User.FriendQuestion);
				UserForm.EnterQuestionHint("3", User.FriendHint);
				UserForm.EnterQuestionAnswer("4", User.JobQuestion);
				UserForm.EnterQuestionHint("4", User.JobHint);
				UserForm.EnterQuestionAnswer("5", User.MascotQuestion);
				UserForm.EnterQuestionHint("5", User.MascotHint);

				Report.Info("Security Questions inputted succesfully for user: " + savedAs);
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I enter the pin: for user saved as: (.*)")]
		public void EnterPinForUser(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Enter Pin: for user: '" + savedAs + "'");
			try
			{
				var User = (User)Context.GetFromContext(savedAs);
				Report.Info("Beginning to enter pin: '" + User.Pin + "'");
				NewUser ThisNewUser = new NewUser();
				ThisNewUser.Pin = User.Pin;
				Report.IsTrue(User.Pin == ThisNewUser.Pin, "Pin was not entered correctly!", "Pin was entered successfully!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click on Login")]
		public void WhenIClickOnLogin()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- I Click Login");
			try
			{
				var selSignUp = new Signup();
				selSignUp.Click_Login_On_Sign_Up_Thank_You_Page();
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"I create a user account with the following parameters saved as: (.*)")]
		public void CreateNewStandardAccount(string savedAs, Table parameters)
		{
			try
			{
				var StepsLogin = new Steps_Login();
				DefineUser(savedAs, parameters);
				GlobalParameters.StepCount++;
				GivenISaveTheCurrentEmailsInTheInboxFor(savedAs);
				GlobalParameters.StepCount++;
				StepsLogin.GivenIClickOnTheNewToWercsmartLink();
				GlobalParameters.StepCount++;
				ThenTheSignupPageShouldAppear();
				GlobalParameters.StepCount++;
				GivenIEnterSignupEmail(savedAs);
				GlobalParameters.StepCount++;
				GivenIConfirmSignupEmail(savedAs);
				GlobalParameters.StepCount++;
				GivenIClickOnSubmit();
				GlobalParameters.StepCount++;
				ThenTheSignupThankYouPageShouldAppear();
				GlobalParameters.StepCount++;
				ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle("should", savedAs, "WERCSmartCustomer@ul.com", "Link to create WERCSmart Account");
				GlobalParameters.StepCount++;
				ThenTheEmailShouldContainALinkToSetUpTheWERCSmartAccount();
				GlobalParameters.StepCount++;
				WhenIClickOnTheLinkIShouldSeeTheWERCSmartNewAccountPage();
				GlobalParameters.StepCount++;
				WhenIEnterTheFollowingInformationIntoTheNewUserForm(savedAs);
				GlobalParameters.StepCount++;
				WhenInTheNewUserFormIClickOnContinue();
				GlobalParameters.StepCount++;
				ThenIShouldBeOnTheSecurityQuestionsPageOfTheForm();
				GlobalParameters.StepCount++;
				EnterTheFollowingIntoSecurityQuestions(savedAs);
				GlobalParameters.StepCount++;
				EnterPinForUser(savedAs);
				GlobalParameters.StepCount++;
				WhenInTheNewUserFormIClickOnContinue();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
	}
}
