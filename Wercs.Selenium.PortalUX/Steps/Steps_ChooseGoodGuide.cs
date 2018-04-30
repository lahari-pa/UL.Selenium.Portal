using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mailosaur;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using Wercs.Selenium.PortalUX.Selenium_Classes.ChooseGoodGuide;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag="WERCSmart_ChooseGoodGuide")]
	class Steps_ChooseGoodGuide
	{
		[StepDefinition(@"I click the 'Get Started Now' button")]
		public void ClickGetStartedNowButton()
		{
			Report.IsTrue(new ChooseGoodGuide_Homepage().ClickGetStarted(), "Failed to click the 'Get Started Now' button!", "Successfully clicked the 'Get Started Now' button!");
		}

		[StepDefinition(@"I click the 'Create Company Account' button")]
		public void ClickCreateCompanyAccountButton()
		{
			Report.IsTrue(new ChooseGoodGuide_AccountCreation().ClickCreateCompanyAccount(), "Failed to click the 'Create Company Account' button!", "Successfully clicked the 'Create Company Account' button!");
		}

		[StepDefinition(@"I enter the (Email): (.*)")]
		public void EnterInformationIntoField(string field, string value)
		{
			var accountCreation = new ChooseGoodGuide_AccountCreation();
			switch (field)
			{
				case ("Email"):
				{
					value = EmailFunctions.CreateEmail(value);
					Context.AddToContext("AccountEmailAddress",value);
					accountCreation.Email = value;
					Report.IsTrue(accountCreation.Email == value, "Failed to enter the email address: " + value, "Successfully entered the email address: " + value);
					return;
				}
			}
		}

		[StepDefinition(@"I click the (Next|Cancel) button")]
		public void ClickNextCancelButton(string button)
		{
			var accountCreation = new ChooseGoodGuide_AccountCreation();
			switch (button)
			{
				case ("Next"):
				{
					Report.IsTrue(accountCreation.ClickNext(), "Failed to click " + button + "!", "Successfully clicked " + button + "!");
					return;
				}
				default:
				{
					Report.IsTrue(accountCreation.ClickCancel(), "Failed to click " + button + "!", "Successfully clicked " + button + "!");
					return;
				}
			}
		}

		[StepDefinition(@"I create an account with the following parameters:")]
		public void CreateChooseGoodGuideAccount(Table parameters)
		{
			new Steps_ConflictMinerals().GivenInTheConflictMineralsPageICreateEnterCompanyDetailsAsFollows(parameters);
		}

		[StepDefinition(@"I setup the Company Contact Person as follows:")]
		public void SetupCompanyContactPerson(Table parameters)
		{
			var accountCreation = new ChooseGoodGuide_AccountCreation();
			foreach (TechTalk.SpecFlow.TableRow thisRow in parameters.Rows)
			{
				switch (thisRow["Field"])
				{
					case "Contact":
						accountCreation.Contact = thisRow["Value"].Trim();
						break;
					case "Phone Number":
						accountCreation.ContactPhoneNumber = thisRow["Value"].Trim();
						break;
					case "Additional Emails":
						accountCreation.ContactAdditionalEmails = thisRow["Value"].Trim();
						break;
					case "Password":
						accountCreation.ContactPassword = thisRow["Value"].Trim();
						accountCreation.ContactReEnterPassword = thisRow["Value"].Trim();
						break;
					case ("What city were you born in?"):
						accountCreation.WhatCityWereYouBornIn = thisRow["Value"].Trim();
						break;
					case ("What was the Model of your first car?"):
						accountCreation.WhatWasTheModelOfYourFirstCar = thisRow["Value"].Trim();
						break;
					case ("What is your favorite sport?"):
						accountCreation.WhatIsYourFavouriteSport = thisRow["Value"].Trim();
						break;
					case ("What is your favorite food or drink?"):
						accountCreation.WhatIsYourFavouriteFoodOrDrink = thisRow["Value"].Trim();
						break;
					case ("What is your favorite vacation destination?"):
						accountCreation.WhatIsYourFavouriteVacationDestination = thisRow["Value"].Trim();
						break;
					case ("Secure Password"):
						accountCreation.EnterSecurePassword = thisRow["Value"].Trim();
						break;


					default:
						throw new Exception("Field value as not one of the expected ones");

				}
			}
		}

		[StepDefinition(@"The contact person page should appear")]
		public void ContactPersonPageAppears()
		{
			Report.IsTrue(new ChooseGoodGuide_AccountCreation().WaitForCreateCompanyAccountFormPage(30), "Failed to find the company contact person page after 30 seconds!", "Successfully found the company contact person page!");
		}

		[StepDefinition(@"I get the verification code from the email")]
		public void ThenTheEmailShouldContainALinkToSetUpTheWercSmartAccount()
		{
			Email matchingEmail = (Email)ScenarioContext.Current["Matching"];
			var bodyText = matchingEmail.Text.Body;
			var code = Regex.Match(bodyText, @"Your verification code is: (.*)").Groups[1];

			Report.Info("Found a verification code: '" + code + "' in the email!");
			Context.AddToContext("VerificationCode", code);
		}

		[StepDefinition(@"I wait for the congratulations page to appear")]
		public void WaitForCongratsPageToAppear()
		{
			Report.IsTrue(new ChooseGoodGuide_AccountCreation().WaitForCongratulationsPage(120), "Congratulations page has not loaded", "Congratulations page has loaded as expected");
		}

		[StepDefinition(@"I confirm that I have received a GoodGuide account email to account: (.*)")]
		public void ThenIConfirmThatIHaveReceivedACARPAccountEmailToAccount(string emailToFind)
		{
			if (emailToFind.ToLower().Contains("saved as"))
			{
				emailToFind = Context.GetFromContext(emailToFind.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim())
					.ToString().Trim();
			}

			var passed = EmailFunctions.CheckEmailHasArrived("Welcome to GoodGuide!", emailToFind);
			if (!passed)
			{
				passed = EmailFunctions.CheckEmailHasArrived("Welcome to GoodGuide!", emailToFind);
			}
			Report.IsTrue(passed,"Email has not arrived as expected", "Email has arrived as expected");
		}

		[StepDefinition(@"the GoodGuide Company Details page should load")]
		public void GoodGuideCompanyDetailsPageShouldLoad()
		{
			Report.IsTrue(new ChooseGoodGuide_AccountCreation().GoodGuideDashboardLoads(), "GoodGuide dashboard failed to load!", "GoodGuide dashboard loaded successfully!");
		}
	}
}
