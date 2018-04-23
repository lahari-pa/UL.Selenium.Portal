using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mailosaur;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TestStack.White.UIItems.WindowItems;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "ConflictMinerals")]
	class Steps_ConflictMinerals
	{

		
		[StepDefinition(@"in the Conflict Minerals page I put in email account for user saved as: (.*)")]
		public void GivenInTheConflictMineralsPageIPutInEmailAccountForUserSavedAs(string savedAsUser)
		{
			try
			{
				User thisUser = (User)Context.GetFromContext(savedAsUser);
				ConflictMinerals thisConflictMinerals = new ConflictMinerals();
				thisConflictMinerals.EmailAddress = thisUser.Email;

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			
		}

		[Then(@"the Conflict Minerals page should load")]
		public void ThenTheConflictMineralsPageShouldLoad()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.Wait_for_load(60), "Conflict Minerals page did not load",
				"Conflict minerals page loaded as expected.");
		}


		[Given(@"in the Conflict Minerals page I put in email account: (.*)")]
		public void GivenInTheConflictMineralsPageIPutInEmailAccount(string emailToEnter)
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();

			if (emailToEnter.ToLower().Contains("saved as"))
			{
				emailToEnter = Context.GetFromContext(emailToEnter.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}

			thisConflictMinerals.NewEmail = emailToEnter;
		}


		[StepDefinition(@"in the Conflict Minerals page I click on Next")]
		public void GivenInTheConflictMineralsPageIClickOnNext()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			thisConflictMinerals.ClickNext();
		}

		[StepDefinition(@"in the Conflict Minerals page the Create Company Account form should have loaded")]
		public void GivenInTheConflictMineralsPageTheCreateCompanyAccountFormShouldHaveLoaded()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.WaitForCompanyContactFormPage(30),
				"Create Company Account form has not loaded", "Create Company Account form has loaded as expected.");
		}

		[StepDefinition(@"in the Conflict Minerals page the Company Contact Person form should have loaded")]
		public void ThenInTheConflictMineralsPageTheCompanyContactPersonFormShouldHaveLoaded()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.WaitForCreateCompanyAccountFormPage(30),
				"Create company account form has not loaded", "Company account form has loaded as expected.");
		}

		[StepDefinition(@"in the Conflict Minerals page the Company Contact Person form email value is: (.*)")]
		public void ThenInTheConflictMineralsPageTheCompanyContactPersonFormEmailValueIs(string expectedEmail)
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			if (expectedEmail.ToLower().Contains("saved as"))
			{
				expectedEmail = Context.GetFromContext(expectedEmail.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}
			Report.IsTrue(thisConflictMinerals.ContactEmail==expectedEmail,
				"Company contact email is not showing as expected. Should be: " + expectedEmail + " but is: " + thisConflictMinerals.ContactEmail, "Contact email is showing as expected: " + expectedEmail);
		}

		[StepDefinition(@"I click on the login button on the congratulations page")]
		public void GivenIClickOnTheLoginButtonOnTheCongratulationsPage()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			thisConflictMinerals.ClickCongratulationsLogin();
		}




		[StepDefinition(@"in the Conflict Minerals page the New Email form should have loaded")]
		public void ThenInTheConflictMineralsPageTheNewEmailFormShouldHaveLoaded()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.WaitForVerifyNewCompanyAccountPage(30),
				"New email form has not loaded", "New email form has loaded as expected.");
		}

		[StepDefinition(@"in the Conflict Minerals page I create enter Company Contact Person as follows:")]
		public void GivenInTheConflictMineralsPageICreateEnterCompanyContactPersonAsFollows(Table table)
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			
			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
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
					default:
						throw new Exception("Field value as not one of the expected ones");

				}
			}
		}

		[StepDefinition(@"I should see a congratulations page")]
		public void ThenIShouldSeeACongratulationsPage()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.WaitForCongratulationsPage(120), "Congratulations page has not loaded",
				"Congratulations page has loaded as expected");
		}

		[StepDefinition(@"in the Conflict Minerals login page I enter Email address: (.*)")]
		public void GivenInTheConflictMineralsLoginPageIEnterEmailAddress(string emailAddress)
		{
			if (emailAddress.ToLower().Contains("saved as"))
			{
				emailAddress = Context.GetFromContext(emailAddress.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			thisConflictMinerals.EmailAddress = emailAddress;
		}

		[StepDefinition(@"the Conflict Minerals Verification page should load")]
		public void ThenTheConflictMineralsVerificationPageShouldLoad()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.WaitForEnterVerificationCodePage(120),
				"Enter verification code page has not loaded", "Enter verification page has loaded");
		}

		[Then(@"the Conflict Minerals terms of use page should load")]
		public void ThenTheConflictMineralsTermsOfUsePageShouldLoad()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.WaitForTermsOfUsePage(60),
				"Terms of use page has not loaded", "Terms of use page has loaded");
		}

		[Then(@"in the Conflict Minerals terms of use I check the Accept checkbox")]
		public void ThenInTheConflictMineralsTermsOfUseICheckTheAcceptCheckbox()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			thisConflictMinerals.AcceptTermsOfUse = true;
		}

		[Then(@"in the Conflict Minerals I should see the dashboard")]
		public void ThenInTheConflictMineralsIShouldSeeTheDashboard()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.WaitForDashboardPage(60),
				"Dashboard page has not loaded", "Dashboard page has loaded");
		}

		[Then(@"in the Conflict Minerals I should see company name in the header: (.*)")]
		public void ThenInTheConflictMineralsIShouldSeeCompanyNameInTheHeader(string companyName)
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			Report.IsTrue(thisConflictMinerals.GetCompanyNameSignedIn().Trim() == companyName,
				"Company name is not showing in header as expected.", "Company name is showing in header as expected.");
		}



		[Then(@"in the Conflict Minerals terms of use I click continue")]
		public void ThenInTheConflictMineralsTermsOfUseIClickContinue()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			thisConflictMinerals.ClickContinue();
		}



		[StepDefinition(@"in the Conflict Minerals login page I enter Password: (.*)")]
		public void GivenInTheConflictMineralsLoginPageIEnterPassword(string password)
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			thisConflictMinerals.Password = password;
		}

		[Then(@"if an error message shows I retry entering password: (.*) and clicking on login")]
		public void ThenIfAnErrorMessageShowsIRetryEnteringPasswordAndClickingOnLogin(string password)
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			if (thisConflictMinerals.ErrorMessageShowing())
			{
				thisConflictMinerals.Password = password;
				thisConflictMinerals.ClickLogin();
			}
		}


		[StepDefinition(@"in the Conflict Minerals login page I click on the Login button")]
		public void GivenInTheConflictMineralsLoginPageIClickOnTheLoginButton()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			thisConflictMinerals.ClickLogin();
		}

		



		[Then(@"I confirm that I have received a Signup confirmation email to account: (.*)")]
		public void ThenIConfirmThatIHaveReceivedASignupConfirmationEmailToAccount(string emailToFind)
		{
			if (emailToFind.ToLower().Contains("saved as"))
			{
				emailToFind = Context.GetFromContext(emailToFind.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}

			Report.IsTrue(EmailFunctions.CheckEmailHasArrived("Signup Confirmation", emailToFind),
				"Email has not arrived as expected", "Email has arrived as expected");
		}

		[Then(@"I confirm that I have received a CARP account email to account: (.*)")]
		public void ThenIConfirmThatIHaveReceivedACARPAccountEmailToAccount(string emailToFind)
		{
			if (emailToFind.ToLower().Contains("saved as"))
			{
				emailToFind = Context.GetFromContext(emailToFind.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}

			Report.IsTrue(EmailFunctions.CheckEmailHasArrived("New CARP Account Created", emailToFind),
				"Email has not arrived as expected", "Email has arrived as expected");
		}

		[Then(@"I confirm that I have a received a Verification code email to account: (.*)")]
		public void ThenIConfirmThatIHaveAReceivedAVerificationCodeEmailToAccount(string emailToFind)
		{
			if (emailToFind.ToLower().Contains("saved as"))
			{
				emailToFind = Context.GetFromContext(emailToFind.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}

			Report.IsTrue(EmailFunctions.CheckEmailHasArrived("New Verification Code", emailToFind),
				"Email has not arrived as expected", "Email has arrived as expected");
		}

		[Then(@"In the Conflict Minerals Verification page I enter verification code: (.*)")]
		public void ThenInTheConflictMineralsVerificationPageIEnterVerificationCode(string verificationCode)
		{
			if (verificationCode.ToLower().Contains("saved as"))
			{
				verificationCode = Context.GetFromContext(verificationCode.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}

			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			thisConflictMinerals.VerificationCode = verificationCode;
		}

		[Then(@"In the Conflict Minerals Verification page I click Verify")]
		public void ThenInTheConflictMineralsVerificationPageIClickVerify()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			thisConflictMinerals.ClickVerify();
		}


		[Given(@"I save the verification code sent to account: (.*) as: (.*)")]
		public void GivenISaveTheVerificationCodeSentToAccountAs(string emailToFind, string saveAs)
		{
			if (emailToFind.ToLower().Contains("saved as"))
			{
				emailToFind = Context.GetFromContext(emailToFind.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}

			var ListOfEmails = EmailFunctions.GetAllEmailsForEmailEmailAddress(emailToFind)
				.OrderByDescending(y => y.CreationDate);
			Email thisEmail = ListOfEmails.FirstOrDefault(x => x.Subject.Contains("New Verification Code"));

			if (thisEmail == null)
			{
				throw new Exception("Failed to find matching email with subject: New Verification Code");
			}

			string EmailBody = thisEmail.Text.ToString();

			Regex regex = new Regex(@"Your verification code is:\s*\d*");
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



		[StepDefinition(@"in the Conflict Minerals page I create enter Company Details as follows:")]
		public void GivenInTheConflictMineralsPageICreateEnterCompanyDetailsAsFollows(Table table)
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();

			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
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




		[StepDefinition(@"in the Conflict Minerals page I click on Create Company Account")]
		public void GivenInTheConflictMineralsPageIClickOnCreateCompanyAccount()
		{
			ConflictMinerals thisConflictMinerals = new ConflictMinerals();
			thisConflictMinerals.ClickCreateCompanyAccount();
		}


	}
}
