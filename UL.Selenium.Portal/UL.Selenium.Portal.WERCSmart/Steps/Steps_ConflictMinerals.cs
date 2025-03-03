using Reqnroll;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.Utilities.Mailosaur.Classes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using Message = Mailosaur.Models.Message;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "ConflictMinerals")]
	class Steps_ConflictMinerals
	{


		[RegexStepDefinition(@"in the Conflict Minerals page I put in email account for user saved as: (.*)")]
		public void GivenInTheConflictMineralsPageIPutInEmailAccountForUserSavedAs(string savedAsUser)
		{
			try
			{
				var thisUser = (User)Context.GetFromContext(savedAsUser);
				var thisConflictMinerals = new ConflictMinerals {
					EmailAddress = thisUser.Email
				};

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

		}

		[RegexStepDefinition(@"the Conflict Minerals page should load")]
		public void ThenTheConflictMineralsPageShouldLoad()
		{
			var thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.Wait_for_load(60), "Conflict Minerals page did not load",
				"Conflict minerals page loaded as expected.");
		}


		[RegexStepDefinition(@"in the Conflict Minerals page I put in email account: (.*)")]
		public void GivenInTheConflictMineralsPageIPutInEmailAccount(string emailToEnter)
		{
			var thisConflictMinerals = new ConflictMinerals();

			if (emailToEnter.ToLower().Contains("saved as"))
			{
				emailToEnter = Context.GetFromContext(emailToEnter.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}

			thisConflictMinerals.NewEmail = emailToEnter;
		}


		[RegexStepDefinition(@"in the Conflict Minerals page I click on Next")]
		public void GivenInTheConflictMineralsPageIClickOnNext()
		{
			var thisConflictMinerals = new ConflictMinerals();
			thisConflictMinerals.ClickNext();
		}

		[RegexStepDefinition(@"in the Conflict Minerals page the Create Company Account form should have loaded")]
		public void GivenInTheConflictMineralsPageTheCreateCompanyAccountFormShouldHaveLoaded()
		{
			var thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.WaitForCompanyContactFormPage(30),
				"Create Company Account form has not loaded", "Create Company Account form has loaded as expected.");
		}

		[RegexStepDefinition(@"in the Conflict Minerals page the Company Contact Person form should have loaded")]
		public void ThenInTheConflictMineralsPageTheCompanyContactPersonFormShouldHaveLoaded()
		{
			var thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.WaitForCreateCompanyAccountFormPage(30),
				"Create company account form has not loaded", "Company account form has loaded as expected.");
		}

		[RegexStepDefinition(@"in the Conflict Minerals page the Company Contact Person form email value is: (.*)")]
		public void ThenInTheConflictMineralsPageTheCompanyContactPersonFormEmailValueIs(string expectedEmail)
		{
			var thisConflictMinerals = new ConflictMinerals();
			if (expectedEmail.ToLower().Contains("saved as"))
			{
				expectedEmail = Context.GetFromContext(expectedEmail.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}
			Report.IsTrue(thisConflictMinerals.ContactEmail == expectedEmail,
				"Company contact email is not showing as expected. Should be: " + expectedEmail + " but is: " + thisConflictMinerals.ContactEmail, "Contact email is showing as expected: " + expectedEmail);
		}

		[RegexStepDefinition(@"I click on the login button on the congratulations page")]
		public void GivenIClickOnTheLoginButtonOnTheCongratulationsPage()
		{
			var thisConflictMinerals = new ConflictMinerals();
			thisConflictMinerals.ClickCongratulationsLogin();
		}




		[RegexStepDefinition(@"in the Conflict Minerals page the New Email form should have loaded")]
		public void ThenInTheConflictMineralsPageTheNewEmailFormShouldHaveLoaded()
		{
			var thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.WaitForVerifyNewCompanyAccountPage(30),
				"New email form has not loaded", "New email form has loaded as expected.");
		}

		[RegexStepDefinition(@"in the Conflict Minerals page I create enter Company Contact Person as follows:")]
		public void GivenInTheConflictMineralsPageICreateEnterCompanyContactPersonAsFollows(Table table)
		{
			var thisConflictMinerals = new ConflictMinerals();

			foreach (TableRow thisRow in table.Rows)
			{
				switch (thisRow["Field"])
				{
					case "Contact":
						thisConflictMinerals.Contact = thisRow["Value"].Trim();
						break;
					case "Phone Number":
						thisConflictMinerals.ContactPhoneNumber = thisRow["Value"].Trim();
						break;
					case "Additional Emails":
						thisConflictMinerals.ContactAdditionalEmails = thisRow["Value"].Trim();
						break;
					case "Password":
						thisConflictMinerals.ContactPassword = thisRow["Value"].Trim();
						thisConflictMinerals.ContactReEnterPassword = thisRow["Value"].Trim();
						break;
					case "City":
						thisConflictMinerals.ContactCity = thisRow["Value"].Trim();
						break;
					case "Model":
						thisConflictMinerals.ContactModel = thisRow["Value"].Trim();
						break;
					case "Sport":
						thisConflictMinerals.ContactSport = thisRow["Value"].Trim();
						break;
					case "Food":
						thisConflictMinerals.ContactFood = thisRow["Value"].Trim();
						break;
					case "Vacation":
						thisConflictMinerals.ContactVacation = thisRow["Value"].Trim();
						break;
					case "IdentityPassword":
						thisConflictMinerals.ContactIdentityPassword = thisRow["Value"].Trim();
						break;
					default:
						throw new Exception("Field value as not one of the expected ones");

				}
			}
		}

		[RegexStepDefinition(@"I should see a congratulations page")]
		public void ThenIShouldSeeACongratulationsPage()
		{
			var thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.WaitForCongratulationsPage(120), "Congratulations page has not loaded",
				"Congratulations page has loaded as expected");
		}

		[RegexStepDefinition(@"on the (.*) login page I enter the Email address: (.*)")]
		[RegexStepDefinition(@"in the (.*) login page I enter Email address: (.*)")]
		public void GivenInTheConflictMineralsLoginPageIEnterEmailAddress(string dummyType, string emailAddress)
		{
			if (emailAddress.ToLower().Contains("saved as"))
			{
				emailAddress = Context.GetFromContext(emailAddress.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}
			var thisConflictMinerals = new ConflictMinerals {
				EmailAddress = emailAddress
			};
			Report.IsTrue(thisConflictMinerals.EmailAddress == emailAddress, "Failed to input the email address: " + emailAddress, "Successfully inputted the email address: " + emailAddress);
		}

		[RegexStepDefinition(@"the (.*) Verification page should load")]
		//[RegexStepDefinition(@"the (.*) Verification page should load")]
		public void ThenTheConflictMineralsVerificationPageShouldLoad(string dummyTitle)
		{
			Report.IsTrue(new ConflictMinerals().WaitForEnterVerificationCodePage(120),
				"Enter verification code page has not loaded", "Enter verification page has loaded");
		}

		[RegexStepDefinition(@"the (.*) terms of use page should load")]
		//[RegexStepDefinition(@"the (.*) terms of use page should load")]
		public void ThenTheConflictMineralsTermsOfUsePageShouldLoad(string dummyTitle)
		{
			var thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.WaitForTermsOfUsePage(60),
				"Terms of use page has not loaded", "Terms of use page has loaded");
		}

		[RegexStepDefinition(@"in the (.*) terms of use I check the Accept checkbox")]
		[RegexStepDefinition(@"on the (.*) terms of use I check the Accept checkbox")]
		public void ThenInTheConflictMineralsTermsOfUseICheckTheAcceptCheckbox(string dummyTitle)
		{
			var thisConflictMinerals = new ConflictMinerals {
				AcceptTermsOfUse = true
			};
			Report.Success("Successfully accepted the terms of use!");
		}

		[RegexStepDefinition(@"in the Conflict Minerals I should see the dashboard")]
		public void ThenInTheConflictMineralsIShouldSeeTheDashboard()
		{
			var thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.WaitForDashboardPage(60),
				"Dashboard page has not loaded", "Dashboard page has loaded");
		}

		[RegexStepDefinition(@"in the Conflict Minerals I should see company name in the header: (.*)")]
		public void ThenInTheConflictMineralsIShouldSeeCompanyNameInTheHeader(string companyName)
		{
			var thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.GetCompanyNameSignedIn().Trim() == companyName,
				"Company name is not showing in header as expected.", "Company name is showing in header as expected.");
		}

		[RegexStepDefinition(@"in the Conflict Minerals I confirm I see my email address in the header: (.*)")]
		public void ThenInTheConflictMineralsIConfirmISeeMyEmailAddressInTheHeader(string emailAddress)
		{
			if (emailAddress.ToLower().Contains("saved as"))
			{
				emailAddress = Context.GetFromContext(emailAddress.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}
			var thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.GetEmailSignedIn().Trim() == emailAddress,
				"Email address is not showing in header as expected.", "Email address is showing in header as expected.");



		}




		[RegexStepDefinition(@"on the (.*) terms of use I click continue")]
		[RegexStepDefinition(@"in the (.*) terms of use I click continue")]
		public void ThenInTheConflictMineralsTermsOfUseIClickContinue(string dummyTitle)
		{
			Report.IsTrue(new ConflictMinerals().ClickContinue(), "Failed to click continue", "Successfully clicked continue!");
		}


		[RegexStepDefinition(@"on the (.*) login page I enter the Password: (.*)")]
		[RegexStepDefinition(@"in the (.*) login page I enter Password: (.*)")]
		public void GivenInTheConflictMineralsLoginPageIEnterPassword(string dummyTitle, string password)
		{
			var thisConflictMinerals = new ConflictMinerals {
				Password = password
			};
			Report.IsTrue(thisConflictMinerals.Password == password, "Failed to input the password: ********", "Successfully entered the password: ********");

		}

		[RegexStepDefinition(@"if an error message shows I retry entering password: (.*) and clicking on login")]
		public void ThenIfAnErrorMessageShowsIRetryEnteringPasswordAndClickingOnLogin(string password)
		{
			var thisConflictMinerals = new ConflictMinerals();
			if (thisConflictMinerals.ErrorMessageShowing())
			{
				thisConflictMinerals.Password = password;
				thisConflictMinerals.ClickLogin();
			}
		}

		[RegexStepDefinition(@"on the (.*) login page I click on the Login button")]
		[RegexStepDefinition(@"in the (.*) login page I click on the Login button")]
		public void GivenInTheConflictMineralsLoginPageIClickOnTheLoginButton(string dummyTitle)
		{
			Report.IsTrue(new ConflictMinerals().ClickLogin(), "Failed to click the log in button!", "Successfully clicked the log in button!");
		}





		[RegexStepDefinition(@"I confirm that I have received a Signup confirmation email to account: (.*)")]
		public void ThenIConfirmThatIHaveReceivedASignupConfirmationEmailToAccount(string emailToFind)
		{
			if (emailToFind.ToLower().Contains("saved as"))
			{
				emailToFind = Context.GetFromContext(emailToFind.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}

			Report.IsTrue(MailosaurHelpers.DefaultMailbox.CheckEmailHasArrived("Signup Confirmation", emailToFind),
				"Email has not arrived as expected", "Email has arrived as expected");
		}

		[RegexStepDefinition(@"I confirm that I have received a CARP account email to account: (.*)")]
		public void ThenIConfirmThatIHaveReceivedACARPAccountEmailToAccount(string emailToFind)
		{
			if (emailToFind.ToLower().Contains("saved as"))
			{
				emailToFind = Context.GetFromContext(emailToFind.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}


			Report.IsTrue(MailosaurHelpers.DefaultMailbox.CheckEmailHasArrived("New CARP Account Created", emailToFind),
				"Email has not arrived as expected", "Email has arrived as expected");
		}

		[RegexStepDefinition(@"I confirm that I have a received a Verification code email to account: (.*)")]
		public void ThenIConfirmThatIHaveAReceivedAVerificationCodeEmailToAccount(string emailToFind)
		{
			if (emailToFind.ToLower().Contains("saved as"))
			{
				emailToFind = Context.GetFromContext(emailToFind.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}

			for (int i = 0; i < 30; i++)
			{
				if (MailosaurHelpers.DefaultMailbox.CheckEmailHasArrived("New Verification Code", emailToFind))
				{
					Report.Success("Verification code has been found");
					return;
				}
				Delay.Seconds(1);
			}
			Report.Failure("Email has not arrived as expected");
		}

		[RegexStepDefinition(@"In the (.*) Verification page I enter verification code: (.*)")]
		[RegexStepDefinition(@"on the (.*) Verification page I enter verification code: (.*)")]
		public void ThenInTheConflictMineralsVerificationPageIEnterVerificationCode(string dummyTitle, string verificationCode)
		{
			if (verificationCode.ToLower().Contains("saved as"))
			{
				verificationCode = Context.GetFromContext(verificationCode.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}

			var thisConflictMinerals = new ConflictMinerals {
				VerificationCode = verificationCode
			};
			Report.IsTrue(thisConflictMinerals.VerificationCode == verificationCode, "Failed to input the verification code: " + verificationCode, "Successfully inputted the verification code: " + verificationCode);
		}

		[RegexStepDefinition(@"In the (.*) Verification page I click Verify")]
		[RegexStepDefinition(@"on the (.*) Verification page I click Verify")]
		public void ThenInTheConflictMineralsVerificationPageIClickVerify(string dummyTitle)
		{
			var thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.ClickVerify(), "Failed to click the verify button", "Successfully clicked the verify button!");
		}


		[RegexStepDefinition(@"I save the verification code sent to account: (.*) as: (.*)")]
		public void GivenISaveTheVerificationCodeSentToAccountAs(string emailToFind, string saveAs)
		{
			if (emailToFind.ToLower().Contains("saved as"))
			{
				emailToFind = Context.GetFromContext(emailToFind.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}

			IOrderedEnumerable<Message> ListOfEmails = MailosaurHelpers.DefaultMailbox.GetAllEmailsForEmailAddress(emailToFind)
				.OrderByDescending(y => y.Received);

			Message thisEmail = ListOfEmails.FirstOrDefault(x => x.Subject.Contains("New Verification Code"));

			if (thisEmail == null)
			{
				throw new Exception("Failed to find matching email with subject: New Verification Code");
			}

			string EmailBody = thisEmail.Text.ToString();

			var regex = new Regex(@"Your verification code is:\s*\d*");
			Match match = regex.Match(EmailBody);
			if (match.Success)
			{
				string Code = match.Value.Replace("Your verification code is:", "", StringComparison.OrdinalIgnoreCase).Trim();
				Context.AddToContext(saveAs, Code);
				Report.Info("Saved code: " + Code);
			}
			else
			{
				throw new Exception("Failed to find verification code in email body: " + EmailBody);
			}

		}



		[RegexStepDefinition(@"in the Conflict Minerals page I create enter Company Details as follows:")]
		public void GivenInTheConflictMineralsPageICreateEnterCompanyDetailsAsFollows(Table table)
		{
			var thisConflictMinerals = new ConflictMinerals();

			foreach (TableRow thisRow in table.Rows)
			{
				switch (thisRow["Field"])
				{
					case "Company Name":
						thisConflictMinerals.CompanyName = thisRow["Value"].Trim();
						break;
					case "Address":
						thisConflictMinerals.Address1 = thisRow["Value"].Trim();
						break;
					case "Address 2":
						thisConflictMinerals.Address2 = thisRow["Value"].Trim();
						break;
					case "Address 3":
						thisConflictMinerals.Address3 = thisRow["Value"].Trim();
						break;
					case "City":
						thisConflictMinerals.City = thisRow["Value"].Trim();
						break;
					case "State":
						thisConflictMinerals.State = thisRow["Value"].Trim();
						break;
					case "Postal Code":
						thisConflictMinerals.PostalCode = thisRow["Value"].Trim();
						break;
					case "Country":
						thisConflictMinerals.Country = thisRow["Value"].Trim().ToUpper();
						break;
					case "Phone Number":
						thisConflictMinerals.PhoneNumber = thisRow["Value"].Trim();
						break;
					case "Emergency Phone Number":
						thisConflictMinerals.EmergencyPhoneNumber = thisRow["Value"].Trim();
						break;
					case "Fax":
						thisConflictMinerals.Fax = thisRow["Value"].Trim();
						break;
					default:
						throw new Exception("Field value as not one of the expected ones");

				}
			}
		}




		[RegexStepDefinition(@"in the Conflict Minerals page I click on Create Company Account")]
		public void GivenInTheConflictMineralsPageIClickOnCreateCompanyAccount()
		{
			var thisConflictMinerals = new ConflictMinerals();
			thisConflictMinerals.ClickCreateCompanyAccount();
		}


	}
}
