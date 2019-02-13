using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mailosaur;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Reporting_Module;
using NTTQA_Reporting_Module.Reporting.Core;
using NTTQA_TReVor_Module.Cache;
using NTTQA_TReVor_Module.Classes;
using SeleniumUtilities;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using WERCSmart;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "Signup"), Scope(Tag = "WERCSmart_Signup")]
	public class StepsSignup
	{
		[StepDefinition(@"the signup page should appear")]
		[StepDefinition(@"\[WERCSmart] The signup page should appear")]
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
		[StepDefinition(@"\[WERCSmart] I define the user: (.*) with the following parameters:")]
		public void DefineUser(string savedAs, Table parameters)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Set up user saved as: '" + savedAs + "'");
			try
			{
				Report.Info("Setting up account details for user: '" + savedAs + "'");
				var account = parameters.CreateInstance<WERCSmartUser>();
				account.Email = EmailFunctions.CreateEmail(account.Email);
				account.Identifier = savedAs;
				Context.AddToContext(savedAs, account, true);
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
		[StepDefinition(@"\[WERCSmart] I enter signup email for user: (.*)")]
		public void GivenIEnterSignupEmailUser(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Enter sign up email for user: " + savedAs);
			try
			{
				var user = (WERCSmartUser)Context.GetFromContext(savedAs);
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
						   thisNewUser.ConfirmPasswordErrorValue, "As expected, confirm password error message is: " + errorMessage);
						break;
					case "Address 1":
						Report.IsTrue(errorMessage == thisNewUser.Address1ErrorValue,
						   "Expected address 1 error message is: " + errorMessage + " actually error message is: " +
						   thisNewUser.Address1ErrorValue, "As expected, address 1 error message is: " + errorMessage);
						break;
					case "City":
						Report.IsTrue(errorMessage == thisNewUser.CityErrorValue,
						   "Expected city error message is: " + errorMessage + " actually error message is: " +
						   thisNewUser.CityErrorValue, "As expected, city error message is: " + errorMessage);
						break;
					case "State":
						Report.IsTrue(errorMessage == thisNewUser.StateErrorValue,
							"Expected state error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.StateErrorValue, "As expected, state error message is: " + errorMessage);
						break;
					case "Zip":
						Report.IsTrue(errorMessage == thisNewUser.ZipErrorValue,
							"Expected zip error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.ZipErrorValue, "As expected, zip error message is: " + errorMessage);
						break;
					case "Company":
						Report.IsTrue(errorMessage == thisNewUser.CompanyErrorValue,
							"Expected company error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.CompanyErrorValue, "As expected, company error message is: " + errorMessage);
						break;
					case "Company Phone":
						Report.IsTrue(errorMessage == thisNewUser.CompanyPhoneErrorValue,
							"Expected company error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.CompanyPhoneErrorValue, "As expected, company phone error message is: " + errorMessage);
						break;
					case "Country Code":
						Report.IsTrue(errorMessage == thisNewUser.CountryCodeErrorValue,
							"Expected country code error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.CountryCodeErrorValue, "As expected, country code error message is: " + errorMessage);
						break;
					case "Emergency Phone Number":
						Report.IsTrue(errorMessage == thisNewUser.EmergencyPhoneNumberErrorValue,
							"Expected emergency phone number error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.EmergencyPhoneNumberErrorValue, "As expected, emergency phone number error message is: " + errorMessage);
						break;
					case "Supplier Type":
						Report.IsTrue(errorMessage == thisNewUser.SupplierTypeErrorValue,
							"Expected supplier type error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.SupplierTypeErrorValue, "As expected, supplier type error message is: " + errorMessage);
						break;

					case "CityQuestion":
						Report.IsTrue(errorMessage == thisNewUser.CityBornErrorValue,
							"Expected In what city were you born?  question error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.CityBornErrorValue, "As expected, In what city were you born?  error message is: " + errorMessage);
						break;
					case "CarQuestion":
						Report.IsTrue(errorMessage == thisNewUser.FirstCarModelErrorValue,
							"Expected What was the model of your first car?  question error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.FirstCarModelErrorValue, "As expected, What was the model of your first car?  error message is: " + errorMessage);
						break;
					case "FriendQuestion":
						Report.IsTrue(errorMessage == thisNewUser.BestFriendErrorValue,
							"Expected What is the first name of your childhood best friend? question error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.BestFriendErrorValue, "As expected, What is the first name of your childhood best friend? error message is: " + errorMessage);
						break;
					case "JobQuestion":
						Report.IsTrue(errorMessage == thisNewUser.FirstJobErrorValue,
							"Expected In what city was your first job? question error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.FirstJobErrorValue, "As expected, In what city was your first job? error message is: " + errorMessage);
						break;
					case "MascotQuestion":
						Report.IsTrue(errorMessage == thisNewUser.HighSchoolMascotErrorValue,
							"Expected What is your high school mascot? question error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.HighSchoolMascotErrorValue, "As expected, What is your high school mascot? error message is: " + errorMessage);
						break;
					case "PINQuestion":
						Report.IsTrue(errorMessage == thisNewUser.PINErrorValue,
							"Expected PIN question error message is: " + errorMessage + " actually error message is: " +
							thisNewUser.PINErrorValue, "As expected, PIN error message is: " + errorMessage);
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
		[StepDefinition(@"\[WERCSmart] I confirm signup email for user: (.*)")]
		public void GivenIConfirmSignupEmailUser(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Enter confirm sign up email for user: " + savedAs);
			try
			{
				var user = (WERCSmartUser)Context.GetFromContext(savedAs);
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

		[StepDefinition(@"\[WERCSmart] I click on submit")]
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
		[StepDefinition(@"\[WERCSmart] The signup thank you page should appear")]
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
		[StepDefinition(@"\[WERCSmart] I save the current emails in the inbox for user saved as: (.*)")]
		public void GivenISaveTheCurrentEmailsInTheInboxFor(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- I save the current emails in this inbox so I can locate the new one when it arrives");
			try
			{
				var user = (WERCSmartUser)Context.GetFromContext(savedAs);
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
		[StepDefinition(@"\[WERCSmart] There (should|should not) be a new email for user: (.*) from: (.*) with the title: (.*)")]
		public void ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle(string shouldOrNot, string savedAs, string emailFrom, string title)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Checking whether there is a new email for user: " + savedAs + " from " + emailFrom + " with title: " + title);
			try
			{
				if (emailFrom.ToLower() == "<sitenotification>")
				{
					emailFrom = TestVariables.GetVariableSavedAs("NotificationEmail");
				}

				Report.Info("Expecting email from: " + emailFrom);

				var user = (WERCSmartUser)Context.GetFromContext(savedAs);
				if (user == null)
				{
					Report.Error("Failed to find a WERCSmart User saved as: " + savedAs);
				}

				Report.Info("Checking for email differences");

				Delay.Seconds(60);
				if (EmailFunctions.WaitForInboxDifferences(user.Email))
				{
					CheckForEmailDifferences(user, emailFrom, title, shouldOrNot == "should");
				}
				else
				{
					if (shouldOrNot == "should not")
					{
						Report.Success("As expected, no email has been received");
					}
					else
					{
						// Try once more just in case there is a delay in recieving the email
						Report.Info("Email did not arrive on first attempt, so trying again...");
						int i = 0;
						while (i < 5)
						{
							Report.Info("Attempt: " + (i + 1));
							if (EmailFunctions.WaitForInboxDifferences(user.Email))
							{
								CheckForEmailDifferences(user, emailFrom, title, shouldOrNot == "should");
								return;
							}

							i++;
						}

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


		public void CheckForEmailDifferences(WERCSmartUser user, string emailFrom, string title, bool should = true)
		{
			var differences = EmailFunctions.GetInboxDifferences(user.Email);

			Report.Info("Checking that differences have been found...");
			if (differences.FirstOrDefault() == null)
			{
				Report.Error("No emails found");
				return;
			}

			Report.Info("Emails have been found!");
			var matchingEmail = differences.FirstOrDefault(x => x.From.FirstOrDefault().Address.ToLower() == emailFrom && x.Subject == title);
			Report.Info("Checking that a matching email has been found");

			if (should)
			{
				Report.IsTrue(matchingEmail != null, "A matching email has not been found.", "Email with subject: " + matchingEmail.Subject + " and body: " + matchingEmail.Text + " has been found.");
			}
			else
			{
				Report.IsTrue(matchingEmail == null, "A matching email has been found.", "Email with subject: " + matchingEmail.Subject + " and body: " + matchingEmail.Text + " has not been found.");
			}

			if (matchingEmail != null)
			{
				using (var sw = new StreamWriter(@"C:\temp\testemail.html"))
				{
					sw.Write(matchingEmail.Html.Body);
					sw.Flush();
					sw.Close();
				}
			}

			Context.AddToContext("Matching", matchingEmail);
		}

		[StepDefinition(@"the email should contain a link to set up the WERCSmart account")]
		[StepDefinition(@"\[WERCSmart] The email should contain a link to set up the WERCSmart account")]
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
		[StepDefinition(@"\[WERCSmart] I click on the link I should see the WERCSmart new account page")]
		public void WhenIClickOnTheLinkIShouldSeeTheWercSmartNewAccountPage()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- When I click on the link I should see the WERCSmart new account page");
			try
			{
				Report.Info("Attempting to open the email link");
				var mylink = Context.GetFromContext("EmailLink").ToString();
				Report.Info("Found a signup link of: '" + mylink + "'");
				Report.Info("Attempting to navigate to the link...");
				SeleniumBrowser.Navigate(mylink);
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
		[StepDefinition(@"\[WERCSmart] I enter the information into the new user form for user saved as: (.*)")]
		public void WhenIEnterTheFollowingInformationIntoTheNewUserForm(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- I enter the data in the table into the new account form.");
			try
			{
				var user = (WERCSmartUser)Context.GetFromContext(savedAs);
				NewUser thisNewUser = new NewUser();
				Report.IsTrue(thisNewUser.Wait_for_load(), "New user form failed to load", "New user form is loaded as expected.");
				Report.Screenshot();

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

		[StepDefinition(@"I should be on the (.*) page of the form")]
		public void ThenIShouldBeOnThePageOfTheForm(string pageTitle)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- check current page title");
			try
			{
				NewUser thisNewUser = new NewUser();
				Report.IsTrue(thisNewUser.WaitForPageTitle(pageTitle, 60),
					pageTitle + " page has not loaded as expected.",
					pageTitle + " page loaded as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[Then(@"I should be on the New Account page of the form")]
		public void ThenIShouldBeOnTheNewAccountPageOfTheForm()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Check that new account page has loaded");
			try
			{
				Report.Info("Checking that the New Account page has loaded");
				NewUser thisNewUser = new NewUser();
				Report.IsTrue(thisNewUser.WaitForPageTitle("New Account", 60),
					"New Account page has not loaded as expected.",
					"New Account page loaded as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"If terms of use page appears I accept")]
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
				var user = (WERCSmartUser)Context.GetFromContext(savedAs);
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

		[StepDefinition(@"I enter the pin: (.*)")]
		public void EnterPin(string pin)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Enter Pin: '" + pin + "'");
			try
			{
				NewUser thisNewUser = new NewUser();
				Report.Info("Beginning to enter pin: '" + pin + "'");
				thisNewUser.Pin = pin;
				Report.IsTrue(pin == thisNewUser.Pin, "Pin was not entered correctly!", "Pin was entered successfully!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I enter the pin for user saved as: (.*)")]
		public void EnterPinForUser(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Enter Pin: for user: '" + savedAs + "'");
			try
			{
				var user = (WERCSmartUser)Context.GetFromContext(savedAs);
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
		[StepDefinition(@"\[WERCSmart] I create a user account with the following parameters saved as: (.*)")]
		public void CreateNewStandardAccount(string savedAs, Table parameters)
		{
			TestReport.UseSubSteps = true;
			var stepsLogin = new StepsLogin();
			DefineUser(savedAs, parameters);
			GivenISaveTheCurrentEmailsInTheInboxFor(savedAs);
			stepsLogin.GivenIClickOnTheNewToWercsmartLink();
			ThenTheSignupPageShouldAppear();
			GivenIEnterSignupEmailUser(savedAs);
			GivenIConfirmSignupEmailUser(savedAs);
			GivenIClickOnSubmit();
			ThenTheSignupThankYouPageShouldAppear();
			ThenThereShouldBeANewEmailForEmamilWithSpecifiedFromAndTitle("should", savedAs, "<sitenotification>", "Link to create WERCSmart Account");
			ThenTheEmailShouldContainALinkToSetUpTheWercSmartAccount();
			WhenIClickOnTheLinkIShouldSeeTheWercSmartNewAccountPage();
			WhenIEnterTheFollowingInformationIntoTheNewUserForm(savedAs);
			WhenInTheNewUserFormIClickOnContinue();
			ThenIShouldBeOnThePageOfTheForm("Security questions");
			EnterTheFollowingIntoSecurityQuestions(savedAs);
			EnterPinForUser(savedAs);
			WhenInTheNewUserFormIClickOnContinue();
			TestReport.UseSubSteps = false;
		}

	}
}
