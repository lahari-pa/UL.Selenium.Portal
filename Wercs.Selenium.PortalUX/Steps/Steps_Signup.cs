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
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
	class StepsSignup
	{
		[StepDefinition(@"the signup page should appear")]
		public void ThenTheSignupPageShouldAppear()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- the signup page should appear");
			try
			{
				Report.Info("Checking that the signup page has loaded...");
				var selSignup = new Signup();
				Report.IsTrue(selSignup.Wait_for_load(), "Signup page did not load!", "Successfully navigated to the signup page!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"Under the Confirm Email text box the following errors should appear")]
		public void ThenUnderTheConfirmEmailTextBoxTheFollowingErrorsShouldAppear(Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Under the Confirm Email text box the following errors should appear");
			try
			{
				var selSignup = new Signup();
				if (selSignup.Confirm_Email_Error_Exists())
				{
					List<string> actualErrors = selSignup.GetConfirmEmailErrors();
					foreach (TechTalk.SpecFlow.TableRow thisrow in table.Rows)
					{
						Report.IsTrue(actualErrors.Contains(thisrow["Error text"]), "Error: " + thisrow["Error text"] + " is not showing as expected.", "Error: " + thisrow["Error text"] + " is showing as expected.");
					}
				}
				else
				{
					throw new Exception("No errors showing!!");
				}

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[Then(@"Under the Enter Email text box the following errors should appear")]
		public void ThenUnderTheEnterEmailTextBoxTheFollowingErrorsShouldAppear(TechTalk.SpecFlow.Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Under the Enter Email text box the following errors should appear");
			try
			{
				var selSignup = new Signup();
				if (selSignup.Enter_Email_Error_Exists())
				{
					List<string> actualErrors = selSignup.GetEnterEmailErrors();
					string sActualErrors = string.Join(",", actualErrors);
					foreach (TechTalk.SpecFlow.TableRow thisrow in table.Rows)
					{
						Report.IsTrue(actualErrors.Contains(thisrow["Error text"]), "Error: " + thisrow["Error text"] + " is not showing as expected. Errors showing are: " + sActualErrors, "Error: " + thisrow["Error text"] + " is showing as expected.");
					}
				}
				else
				{
					throw new Exception("No errors showing!!");
				}

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

		[StepDefinition(@"I click Cancel on the Sign Up screen")]
		public void ClickCancel()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Click Cancel on the Sign Up screen");

			try
			{
				Report.Info("Click Cancel on the Sign Up screen");
				var selSignup = new Signup();
				selSignup.Click_Cancel();
				Report.Success("Clicked cancel successfully");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"I enter signup email for user: (.*)")]
		public void GivenIEnterSignupEmailUser(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Enter sign up email for user: " + savedAs);
			try
			{
				var user = (User)Context.GetFromContext(savedAs);
				Report.Info("Entering email: '" + user.Email + "'");
				var selSignup = new Signup();
				selSignup.Enter_Email(user.Email);
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I enter signup email: (.*)")]
		public void GivenIEnterSignupEmail(string email)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Enter sign up email: " + email);
			try
			{
				var selSignup = new Signup();
				selSignup.Enter_Email(email);
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I paste into signup email: (.*)")]
		public void WhenIPasteIntoSignupEmail(string email)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Paste in sign up email: " + email);
			try
			{
				var selSignup = new Signup();
				selSignup.Enter_Email(email);
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"I confirm signup email: (.*)")]
		public void GivenIConfirmSignup(string email)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Enter confirm sign up email: " + email);
			try
			{
				var selSignup = new Signup();
				selSignup.Enter_ConfirmEmail(email);
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I copy the current value of the signup email")]
		public void GivenICopyTheCurrentValueOfTheSignupEmail()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- I copy the current value of the signup email");
			try
			{
				var selSignup = new Signup();
				selSignup.CopyEnterEmailContentsToClipboard();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"I paste into confirm email: (.*)")]
		public void WhenIPasteIntoConfirmEmail(string email)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Paste in confirm email: " + email);
			try
			{
				var selSignup = new Signup();
				selSignup.PasteIntoConfirmEmailFromClipboard();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[Then(@"In the (.*) entry error I see error message: (.*)")]
		public void ThenInTheEntryErrorISeeErrorMessage(string input, string errorMessage)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- In the " + input + " entry error I see error message: " + errorMessage);
			try
			{
				NewUser thisNewUser = new NewUser();
				switch (input)
				{
					case "Country":
						Report.IsTrue(errorMessage == thisNewUser.CountryErrorValue,
							"Expected country error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.CountryErrorValue, "As expected, country error message is: " + errorMessage);
						break;
					case "First Name":
						Report.IsTrue(errorMessage == thisNewUser.FirstNameErrorValue,
						   "Expected first name error message is: " + errorMessage + " actually error message is: " +
						   thisNewUser.FirstNameErrorValue, "As expected, first name error message is: " + errorMessage);
						break;
					case "Last Name":
						Report.IsTrue(errorMessage == thisNewUser.LastNameErrorValue,
						   "Expected last name error message is: " + errorMessage + " actually error message is: " +
						   thisNewUser.LastNameErrorValue, "As expected, last name error message is: " + errorMessage);
						break;
					case "Password":
						Report.IsTrue(errorMessage == thisNewUser.PasswordErrorValue,
						   "Expected password error message is: " + errorMessage + " actually error message is: " +
						   thisNewUser.PasswordErrorValue, "As expected, password error message is: " + errorMessage);
						break;
					case "Confirm Password":
						Report.IsTrue(errorMessage == thisNewUser.ConfirmPasswordErrorValue,
						   "Expected confirm password error message is: " + errorMessage + " actually error message is: " +
						   thisNewUser.ConfirmPasswordErrorValue, "As expected, password error message is: " + errorMessage);
						break;
					case "Address 1":
						Report.IsTrue(errorMessage == thisNewUser.Address1ErrorValue,
						   "Expected address 1 error message is: " + errorMessage + " actually error message is: " +
						   thisNewUser.Address1ErrorValue, "As expected, password error message is: " + errorMessage);
						break;
					case "City":
						Report.IsTrue(errorMessage == thisNewUser.Address1ErrorValue,
						   "Expected address 1 error message is: " + errorMessage + " actually error message is: " +
						   thisNewUser.Address1ErrorValue, "As expected, password error message is: " + errorMessage);
						break;
					case "State":
						break;
					case "Zip":
						break;
					case "Company":
						break;
					case "Company Phone":
						break;
					case "Country Code":
						break;
					case "Emergency Phone Number":
						break;
					case "Supplier Type":
						break;
					default:
						throw new Exception("Field was not found: " + input);

				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}





		[StepDefinition(@"I confirm signup email for user: (.*)")]
		public void GivenIConfirmSignupEmailUser(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Enter confirm sign up email for user: " + savedAs);
			try
			{
				var user = (User)Context.GetFromContext(savedAs);
				Report.Info("Entering email: '" + user.Email + "'");
				var selSignup = new Signup();
				selSignup.Enter_ConfirmEmail(user.Email);
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
				Delay.Seconds(1);
				Report.Info("Attempting to click submit...");
				var selSignup = new Signup();
				int count = 0;
				while (!selSignup.Click_Submit() && count < 30)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					count++;
				}
				Report.Success("Submit clicked successfully!");
				Delay.Seconds(2);
				if (selSignup.Wait_for_load(1))
				{
					selSignup.Click_Submit();
				}
				Delay.Seconds(2);
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
				var selSignup = new Signup();
				int count = 0;
				while (!selSignup.Wait_for_load(1) && count < 60)
				{
					Delay.Seconds(Delay.SpeedFactor * 1);
					count++;
				}
				Report.Info("Signup page appeared!");
				Report.IsTrue(selSignup.Sign_Up_Thank_You_Page_Exists(),
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
				var user = (User)Context.GetFromContext(savedAs);
				Report.Info("Storing inbox for address: " + user.Email);
				EmailFunctions.StoreCurrentInbox(user.Email);
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
				var user = (User)Context.GetFromContext(savedAs);
				if (EmailFunctions.WaitForInboxDifferences(user.Email))
				{
					var differences = EmailFunctions.GetInboxDifferences(user.Email);
					var matchingEmail = differences.FirstOrDefault(x => x.From.FirstOrDefault().Address == emailFrom && x.Subject == title);

					using (var sw = new StreamWriter(@"C:\temp\testemail.html"))
					{
						sw.Write(matchingEmail.Html.Body);
						sw.Flush();
						sw.Close();
					}

					Context.AddToContext("Matching", matchingEmail);

					if (shouldOrNot == "should")
					{
						Report.IsTrue(matchingEmail != null, "A matching email has not been found.", "Email with subject: " + matchingEmail.Subject + " and body: " + matchingEmail.Text + " has been found.");
					}
					else
					{
						Report.IsTrue(matchingEmail == null, "A matching email has been found.", "Email with subject: " + matchingEmail.Subject + " and body: " + matchingEmail.Text + " has not been found.");
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
		public void ThenTheEmailShouldContainALinkToSetUpTheWercSmartAccount()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Checking whether there is a link the email which sets up the WERCSmart account");
			try
			{
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

		[StepDefinition(@"I should see popup error: (.*)")]
		public void ThenIShouldSeePopupError(string expectedError)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- I should see popup error: " + expectedError);
			try
			{
				Delay.Seconds(2);
				AccountNotifications thisPopup = new AccountNotifications();
				Report.IsTrue(thisPopup.Wait_for_load(30), "Popup error is not showing as expected");
				Report.IsTrue(thisPopup.GetErrorText() == expectedError,
					"Expected error was: " + expectedError + " actual error was: " + thisPopup.GetErrorText(),
					"As expected, error was showing: " + expectedError);
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the popup error I click on Cancel")]
		public void GivenInThePopupErrorIClickOnCancel()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- In the popup error I click on Cancel");
			try
			{
				Delay.Seconds(2);
				AccountNotifications thisPopup = new AccountNotifications();
				Report.IsTrue(thisPopup.Wait_for_load(30), "Popup error is not showing as expected");
				thisPopup.Click_Close();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}



		[StepDefinition(@"I click on the link I should see the WERCSmart new account page")]
		public void WhenIClickOnTheLinkIShouldSeeTheWercSmartNewAccountPage()
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
				NewUser userCreatonPage = new NewUser();
				Report.IsTrue(userCreatonPage.Wait_for_load(30), "New User Creation page did not load!", "User creation page loaded as expected!");
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
				var user = (User)Context.GetFromContext(savedAs);
				NewUser thisNewUser = new NewUser();
				thisNewUser.Country = user.Country;
				thisNewUser.FirstName = user.FirstName;
				thisNewUser.LastName = user.LastName;
				thisNewUser.Password = user.Password;
				thisNewUser.ConfirmPassword = user.Password;
				thisNewUser.Address1 = user.Address1;
				thisNewUser.Address2 = user.Address2;
				thisNewUser.City = user.City;

				if (user.Country == "UNITED STATES")
				{
					thisNewUser.SelectUsState(user.State);
				}
				else
				{
					thisNewUser.State = user.State;
				}


				thisNewUser.Zip = user.Zip;
				thisNewUser.CompanyName = user.CompanyName;
				thisNewUser.CompanyPhone = user.CompanyPhone;
				thisNewUser.CountryCode = user.CountryCode;
				thisNewUser.EmergencyPhoneNumber = user.EmergencyPhoneNumber;
				thisNewUser.SelectSupplierType(user.SupplierType);
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
				NewUser thisNewUser = new NewUser();
				Report.IsTrue(thisNewUser.ClickContinue(), "Failed to click continue!", "Successfully clicked continue!");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Ensure navigation to Security Quuestions");
			try
			{
				Report.Info("Checkin that the Security Questions page has loaded...");
				NewUser thisNewUser = new NewUser();
				Report.IsTrue(thisNewUser.WaitForPageTitle("Security Questions", 60),
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

		[Given(@"If terms of use page appears I accept")]
		public void GivenIfTermsOfUsePageAppearsIAccept()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- If terms of use page appears I accept");
			try
			{
				TermsOfUse myTermsOfUse = new TermsOfUse();
				if (myTermsOfUse.Wait_for_load(60))
				{
					myTermsOfUse.Accept();
				}

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
				var user = (User)Context.GetFromContext(savedAs);
				var userForm = new NewUser();

				userForm.EnterQuestionAnswer("1", user.CityQuestion);
				userForm.EnterQuestionHint("1", user.CityHint);
				userForm.EnterQuestionAnswer("2", user.CarQuestion);
				userForm.EnterQuestionHint("2", user.CarHint);
				userForm.EnterQuestionAnswer("3", user.FriendQuestion);
				userForm.EnterQuestionHint("3", user.FriendHint);
				userForm.EnterQuestionAnswer("4", user.JobQuestion);
				userForm.EnterQuestionHint("4", user.JobHint);
				userForm.EnterQuestionAnswer("5", user.MascotQuestion);
				userForm.EnterQuestionHint("5", user.MascotHint);

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
				var user = (User)Context.GetFromContext(savedAs);
				Report.Info("Beginning to enter pin: '" + user.Pin + "'");
				NewUser thisNewUser = new NewUser();
				thisNewUser.Pin = user.Pin;
				Report.IsTrue(user.Pin == thisNewUser.Pin, "Pin was not entered correctly!", "Pin was entered successfully!");
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
				var stepsLogin = new StepsLogin();
				DefineUser(savedAs, parameters);
				GlobalParameters.StepCount++;
				GivenISaveTheCurrentEmailsInTheInboxFor(savedAs);
				GlobalParameters.StepCount++;
				stepsLogin.GivenIClickOnTheNewToWercsmartLink();
				GlobalParameters.StepCount++;
				ThenTheSignupPageShouldAppear();
				GlobalParameters.StepCount++;
				GivenIEnterSignupEmail(savedAs);
				GlobalParameters.StepCount++;
				GivenIConfirmSignupEmailUser(savedAs);
				GlobalParameters.StepCount++;
				GivenIClickOnSubmit();
				GlobalParameters.StepCount++;
				ThenTheSignupThankYouPageShouldAppear();
				GlobalParameters.StepCount++;
				ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle("should", savedAs, "WERCSmartCustomer@ul.com", "Link to create WERCSmart Account");
				GlobalParameters.StepCount++;
				ThenTheEmailShouldContainALinkToSetUpTheWercSmartAccount();
				GlobalParameters.StepCount++;
				WhenIClickOnTheLinkIShouldSeeTheWercSmartNewAccountPage();
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
