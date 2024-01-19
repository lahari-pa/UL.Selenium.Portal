using System;
using System.Collections.Generic;
using System.Linq;
using Mailosaur;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Automation.Utilities;
using System.Text.RegularExpressions;
using TReVor.Integrations.Classes;
using static NUnit.Framework.Internal.OSPlatform;
using UL.Automation.Utilities.Mailosaur.Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "MyAccount")]
	class StepsMyAccount
	{
		[StepDefinition(@"I should see username for user saved as: (.*) in the right corner")]
		public void ThenIShouldSeeUsernameForUserSavedAsInTheRightCorner(string savedAs)
		{
			Report.StartStep(ReportSettings.StepCounter + " - I should see username: " + savedAs + " in the top right corner");
			try
			{
				var user = (WERCSmartUser)Context.GetFromContext(savedAs);
				if (user == null)
				{
					Report.Failure("Could not find user saved as: " + savedAs + " in context");
					return;
				}
				var thisTopMenuBar = new TopMenuBar();
				string username = user.FirstName + " " + user.LastName;
				Report.Info("Looking for username: " + username);
				Report.IsTrue(thisTopMenuBar.GetCurrentUser() == username,
					"Username should have been showing as: " + username + " but is: " + thisTopMenuBar.GetCurrentUser(),
					"Username correctly showing as: " + username);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see user name: (.*) in the header next to the user icon")]
		public void ThenIShouldSeeUserNameInTheHeaderNextToTheUserIcon(string username)
		{
			Report.StartStep(ReportSettings.StepCounter + " - I should see username: " + username + " in the top right corner");
		
			try
			{
				if (username.ToLower().Contains("saved as"))
				{
					var savedUser = (User)Context
						.GetFromContext(username.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim());
					username = savedUser.Username;
				}
				if (username == "<RandomString>")
				{
					string randomStringSaved = (string)Context.GetFromContext(username);
					username = randomStringSaved;
					Report.Info($"The username was expected to be: '{username}'");
				}
				var thisTopMenuBar = new TopMenuBar();
				Report.Info("Looking for username: " + username);
				Report.IsTrue(thisTopMenuBar.GetCurrentUser() == username,
					"Username should have been showing as: " + username + " but is: " + thisTopMenuBar.GetCurrentUser(),
					"Username correctly showing as: " + username);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see a user name in the header next to the user icon")]
		public void ThenIShouldSeeAUserNameNextToTheUserIcon()
		{
			var thisTopMenuBar = new TopMenuBar();
			string currentUser = thisTopMenuBar.GetCurrentUser();
			Report.IsTrue(currentUser.Length > 0,
				"Username should be showing", "Username showing as: " + currentUser);
		}

		[StepDefinition(@"I should see username: (.*) in the right corner")]
		public void ThenIShouldSeeUsernameInTheRightCorner(string username)
		{
			Report.StartStep(ReportSettings.StepCounter + " - I should see username: " + username + " in the top right corner");
			try
			{
				var thisTopMenuBar = new TopMenuBar();
				Report.IsTrue(thisTopMenuBar.GetCurrentUser() == username,
					"Username should have been showing as: " + username + " but is: " + thisTopMenuBar.GetCurrentUser(),
					"Username correctly showing as: " + username);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see company username: (.*)")]
		public void ThenIShouldSeeCompanyUsername(string companyName)
		{
			Report.StartStep(ReportSettings.StepCounter + " - I should see company username: " + companyName);
			try
			{
				var myMyAccount = new MyAccount();
				Report.IsTrue(myMyAccount.GetCompanyName() == companyName,
					"Company name should be showing as: " + companyName + " but is: " + myMyAccount.GetCompanyName(),
					"Company name is correctly showing as: " + companyName);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I save the administrator Company Name as: (.*)")]
		public void SaveCompanyNameToContext(string savedAs)
		{
			var companyName = new MyAccount().GetCompanyName();
			if (companyName == null)
			{
				Report.Failure("Failed to get Company Name on My Account");
				Report.Screenshot();
			}
			else
			{
				Report.Info("Company Name is: " + companyName);
			}
			Report.Info("Adding Company Name to context");
			Context.AddToContext(savedAs, companyName);
		}

		[StepDefinition(@"I navigate to the MyAccount page")]
		public void GivenINavigateToTheMyAccountPage()
		{
			Report.Info("Navigating to the My Account page");
			var thisTopMenuBar = new TopMenuBar();
			thisTopMenuBar.ClickMyAccount();
			Report.IsTrue(new MyAccount().Wait_for_load(),
				"The My Account page did not load",
				"The My Account page was loaded");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I save all the users in the User Grid")]
		public void GivenISaveAllTheUsersInTheUserGrid()
		{
			Report.StartStep(ReportSettings.StepCounter + " - I save all the users in the User Grid");
			try
			{
				var selMyAccount = new MyAccount();
				Report.IsTrue(selMyAccount.SaveUserGrid("userGrid"), "Failed to save users in the user Grid", "Successfully saved users in the User grid");

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the User Grid the user saved as: (.*) has been replaced by: (.*)")]
		public void ThenInTheUserGridTheSavedUserNameHasBeenReplacedBy(string savedAs, string replacedBy)
		{
			Report.StartStep(ReportSettings.StepCounter + " - In the User Grid the saved user name (" + savedAs + ") has been replaced by: " + replacedBy);
			if(replacedBy== "<RandomString>")
			{
				string randomStringSaved = (string)Context.GetFromContext(replacedBy);
				replacedBy = randomStringSaved;
				Report.Info($"The replaced by string was expected to be: '{replacedBy}'");
			}


			try
			{
				Delay.Seconds(20);
				var selMyAccount = new MyAccount();
				Report.IsTrue(selMyAccount.SaveUserGrid("userGridNew"), "Failed to save users in the user Grid", "Successfully saved users in the User grid");
				Delay.Seconds(2);
				Report.Info($"Original Grid");
				var originalGrid = (List<User>)Context.GetFromContext("userGrid");
				Report.Info($"New Grid");
				var newGrid = (List<User>)Context.GetFromContext("userGridNew");
				Report.Info($"Saved User");
				var savedUser = (User)Context.GetFromContext(savedAs);

				var matching = originalGrid.Where(y => newGrid.Any(z => z.Username == y.Username)).ToList();

				

				User inOriginalButNotNew = originalGrid.Where(y => !newGrid.Any(z => z.Username == y.Username)).ToList().FirstOrDefault();
				User inNewButNotOriginal = newGrid.Where(y => !originalGrid.Any(z => z.Username == y.Username)).ToList().FirstOrDefault();

				Report.IsTrue(inOriginalButNotNew.Username.Contains(savedUser.Username), "User: " + savedUser.Username + " was not found in the orginal list. ", "As expected, " + savedUser.Username + " was found in the original list");
				Report.IsTrue(inNewButNotOriginal.Username.Contains(replacedBy), "User has not been replaced by: " + replacedBy, "As expected the replacement user is: " + replacedBy);


				//Report.IsTrue(inOriginalButNotNew.Username == savedUser.Username,"User: " + savedUser.Username + " has not been replaced. ","As expected, " + savedUser.Username + " has been replaced");
				//Report.IsTrue(inNewButNotOriginal.Username == replacedBy,"User has not been replaced by: " + replacedBy, "As expected the replacement user is: " + replacedBy);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I go to (.*) in User Grid for the current user")]
		public void GivenIGoToActionInUserGrid(string action)
		{
			Delay.Seconds(1);
			var selMyAccount = new MyAccount();
			var selTopMenuBar = new TopMenuBar();

			//get name of currently signed in
			string username = selTopMenuBar.GetCurrentUser();
			selMyAccount.EnterSearchTextAndClickFind(username);
			Report.IsTrue(selMyAccount.ForUserClickAction(username, action),
				$"Failed to click action: {action } for user: { username }",
				$"Successfully clicked action: { action } for user:{ username }");
			Delay.Seconds(1);
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I go to (.*) in User Grid for the the user called: (.*)")]
		public void GivenIGoToActionInUserGridForGiven(string action, string username)
		{


			Delay.Seconds(1);
			var selMyAccount = new MyAccount();
			var selTopMenuBar = new TopMenuBar();


			Report.IsTrue(selMyAccount.ForUserClickAction(username, action),
				"Failed to click action: " + action + " for user: " + username,
				"Successfully clicked action: " + action + " for user: " + username);
			Delay.Seconds(1);
		}

		[StepDefinition(@"In the UserDetails screen I save the current User as: (.*)")]
		public void GivenInTheUserDetailsScreenISaveTheCurrentUserAs(string saveAs)
		{
			Report.StartStep(ReportSettings.StepCounter + " - In the UserDetails screen I save the current User as: " + saveAs);
			try
			{
				var myUserDetails = new UserDetails();
				var thisUser = new User {
					Username = myUserDetails.Name,
					Title = myUserDetails.Title,
					Role = myUserDetails.UserRole,
					Purview = myUserDetails.Purview,
					Email = myUserDetails.EmailAddress,
					Country = myUserDetails.Country,
					CountryCode = myUserDetails.CountryCode,
					PhoneNumber = myUserDetails.PhoneNumber,
					SendNotifications = myUserDetails.SendNotifications
				};
				Delay.Seconds(1);

				Context.AddToContext(saveAs, thisUser);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the UserDetails page I set Name to be: (.*)")]
		public void GivenInTheUserDetailsPageISetNameToBe(string name)
		{
			Report.StartStep(ReportSettings.StepCounter + " - In the UserDetails page I set Name to be: " + name);

			try
			{
				var myUserDetails = new UserDetails();
				Delay.Seconds(3);
				if (name.ToLower().Contains("saved as"))
				{
					var user = (User)Context.GetFromContext(name.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim());
					if (user == null)
					{
						Report.Failure("The user saved as: " + name + " was not found in context");
						return;
					}
					name = user.Username;
				}
				if(name=="<RandomString>")
				{
					string newRandom = GeneralUtilities.GenerateRandomString(12);
					name = newRandom;
					Context.AddToContext("<RandomString>", newRandom);
				}


				Report.Info("Inputting name: " + name);
				myUserDetails.Name = name;
				Report.IsTrue(myUserDetails.Name == name, "Failed to set user details name to: " + name,
					"Successfully set name to be: " + name);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the UserDetails page I click (.*)")]
		public void GivenInTheUserDetailsPageIClick(string buttonToClickText)
		{
			Report.StartStep(ReportSettings.StepCounter + " - In the UserDetails page I click " + buttonToClickText);
			try
			{
				var myUserDetails = new UserDetails();
				Report.IsTrue(myUserDetails.ClickButton(buttonToClickText), "Failed to click " + buttonToClickText, "Successfully clicked " + buttonToClickText);
				GeneralUtilities.Wait_for_load_finish();
				if (buttonToClickText.ToLower() == "save")
				{
					myUserDetails.ClickButtonOnAddUserDialog("close");
					GeneralUtilities.Wait_for_load_finish();
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click Save in My Account")]
		public void GivenIClickSaveInMyAccount()
		{
			Report.StartStep(ReportSettings.StepCounter + " - I click Save in My Account");


			try
			{

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see the heading: (.*) on the My Account page")]
		public void CorrectHeadingShowing(string headingExpected)
		{
			Report.StartStep(ReportSettings.StepCounter + " - I should see the heading " + headingExpected);
			try
			{
				Report.Info("Checking that I see the heading: '" + headingExpected + "'");
				var selMyAccount = new MyAccount();
				string headingShowing = selMyAccount.HeaderShowing();
				Report.IsTrue(headingShowing.Trim() == headingExpected.Trim(),
					"Heading was not as expected! Expected: " + headingExpected + ", but found " + headingShowing + "!",
					"Heading was showing: " + headingShowing + ", as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see the subheading: (.*) on the My Account page")]
		public void CorrectSubHeadingShowing(string subheadingExpected)
		{
			Report.StartStep(ReportSettings.StepCounter + " - I should see the heading " + subheadingExpected);
			try
			{
				Report.Info("Checking that I see the heading: '" + subheadingExpected + "'");
				var selMyAccount = new MyAccount();
				List<string> subheadingsShowing = selMyAccount.Subheadings();
				Report.IsTrue(subheadingsShowing.Any(x => x.StartsWith(subheadingExpected.Trim())),
					"Subheading was not as expected! Expected: " + subheadingExpected + ", but found " + string.Join(", ", subheadingsShowing) + "!",
					"Heading was showing: " + subheadingExpected + ", as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I add a new user with the following information")]
		public void ThenIAddANewUserWithTheFollowingInformation(Table table)
		{
			Report.StartStep($"{Report.Details.StepIndex} - I add a new user with the following information");
			try
			{
				foreach (TableRow thisRow in table.Rows)
				{
					string userName = thisRow["User Name"];
					string title = thisRow["Title"];
					string role = thisRow["Role"];
					string phoneNo = thisRow["Phone Number"];
					string emailAddress = thisRow["Email Address"];
					string confirmEmail = thisRow["Confirm Email"];
					string countryCode = thisRow["Country Code"];
					string country = thisRow["Country"];

					if (userName == "User")
					{
						userName = userName + "_" + System.DateTime.Now.ToString("HHmmddMMyy");

						Context.AddToContext("CurrentUser", userName);

						Report.Info("User Name = " + userName);
					}
					if (userName == "Random") 
					{
						string randomstr = Context.ScenarioContext["CurrentEmail"].ToString().Replace(".kxxyxunf@mailosaur.io", "");
						userName = "User_" + randomstr;
						Context.AddToContext("CurrentUser", userName);
						Report.Info("User Name = " + userName);
					}


					if (emailAddress == "Saved")
					{
						if (Context.ScenarioContext.ContainsKey("CurrentEmail"))
						{
							emailAddress = Context.ScenarioContext["CurrentEmail"].ToString();
						}
						Report.Info("Email Address = " + emailAddress);
					}
					// adding this to allow checking for confirmation email to the new user
					//MailosaurFunctions.StoreCurrentInbox(emailAddress);
					MailosaurHelpers.DefaultMailbox.StoreCurrentInbox(emailAddress);
					if (confirmEmail == "Saved")
					{
						if (Context.ScenarioContext.ContainsKey("CurrentEmail"))
						{
							confirmEmail = Context.ScenarioContext["CurrentEmail"].ToString();
						}
						Report.Info("Email Address = " + confirmEmail);
					}

					if (countryCode == "empty")
					{
						countryCode = "";
					}

					var selMyAccount = new MyAccount();
					//Open New User Form
					Report.IsTrue(selMyAccount.Add_New_User_click(), "Failed to Click Add New User Link",
						"New User Form Link Clicked");
					Delay.Seconds(5);
					var selMyUserForm = new UserDetails();
					//Check Form Has Opened
					Report.IsTrue(!selMyUserForm.Exists, "Failed to Open Add User Form", "Add User Form Open");
					//Add New User
					Report.IsTrue(selMyUserForm.Add_New_User(userName, title, role, phoneNo, emailAddress, confirmEmail, country),
						"Failed to Add a New User", "New User Added");
					Delay.Seconds(10);
					//Check User Has Been Created
					Report.IsTrue(selMyAccount.User_Added_Check(userName, emailAddress, role), "User Has Not Been Created",
						"User Created Successfully");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm the new user is (Not Active|Active)")]
		public void ThenIConfirmTheNewUserIsX(string active)
		{
			Report.StartStep(ReportSettings.StepCounter + " - I confirm the new user is " + active);
			try
			{
				var selMyAccount = new MyAccount();

				string userName = string.Empty;

				if (Context.ScenarioContext.ContainsKey("CurrentUser"))
				{
					userName = Context.ScenarioContext["CurrentUser"].ToString();
				}

				Report.IsTrue(selMyAccount.Is_User_Active(userName, active), "User is NOT " + active, "User is " + active);

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Select the ... from the Actions column of the account I just created and select (Deactivate|Activate)")]
		public void IClickDeactivateFromTheActionsColumn(string activate)
		{
			Report.StartStep(ReportSettings.StepCounter + " - I select the ... from the Actions column");
			try
			{
				var selMyAccount = new MyAccount();

				string userName = string.Empty;

				if (Context.ScenarioContext.ContainsKey("CurrentUser"))
				{
					userName = Context.ScenarioContext["CurrentUser"].ToString();
				}

				Report.IsTrue(selMyAccount.Select_ActivateDeactivate(userName, activate), "Could not click ellipses", "Successfully clicked ellipses");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Click approve in dialog")]
		public void IClickApprove()
		{
			Report.StartStep(ReportSettings.StepCounter + " - I click Approve");
			try
			{

				var modal = new ModalDialog();

				modal.WaitForContainerToBeVisible(20);
				Report.IsTrue(modal.ClickApprove(), "Could not click Approve in modal window", "Successfully clicked Approve in modal window");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Click close in dialog")]
		public void IClickClose()
		{
			Delay.Seconds(3);
			Report.StartStep(ReportSettings.StepCounter + " - I click Close");
			try
			{
				var modal = new ModalDialog();

				Report.IsTrue(modal.Click_Close(), "Could not click Close in modal window", "Successfully clicked Close in modal window");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click on NEW SUBSCRIPTION")]
		public void ThenIClickOnNewSubscription()
		{
			Report.StartStep(ReportSettings.StepCounter + " - I click on NEW SUBSCRIPTION");
			try
			{
				var selMyAccount = new MyAccount();
				Delay.Seconds(1.5 * Delay.SpeedFactor);
				Report.IsTrue(selMyAccount.New_Subscription_click(), "Failed to Click NEW SUBSCRIPTION Button",
					"NEW SUBSCRIPTION Button Clicked");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the My Account page I confirm that the subscription level is: (.*)")]
		public void InTheMyAccountPageIConfirmThatTheSubscriptionLevelIs(string savedAs)
		{
			string subSavedAs = Context.GetFromContext(savedAs)?.ToString();
			Report.IsTrue(new MyAccount().ConfirmSubscriptionLevel(subSavedAs), "Failed to find matching subscription level '" + subSavedAs + "'.",
				"Successfully found subscription level '" + subSavedAs + "'.");
		}

		[StepDefinition(@"In the Subscription Information screen I verify section (.*) is present with product types:")]
		public void ThenInTheSubscriptionInformationScreenIVerifySectionSubmittedIsPresentWithProductTypes(string sectionName, Table table)
		{
			if (Report.IsTrue(new MyAccount_SubscriptionInfo().ProductTypesSectionExists(sectionName), $"Failed to find product types section {sectionName} in the Subscription Information screen", $"Successfully found product types section {sectionName} in the Subscription Information screen"))
			{
				if (Report.IsTrue(new MyAccount_SubscriptionInfo().ProductTypesExists(sectionName), $"Failed to find product types in section {sectionName}", $"Successfully found product types in section {sectionName}"))
				{
					Report.IsTrue(new MyAccount_SubscriptionInfo().SectionExists(sectionName, table), $"Failed to verify product types in section {sectionName}", $"Successfully verified product types in section {sectionName}");
				}
			}
		}
		[StepDefinition(@"I get the count of products in section (.*) and save as: (.*)")]
		public void ThenIGetTheCountOfProductsInSectionSubmittedAndSaveAsProductsCount(string sectionName, string savedAs)
		{
			if (Report.IsTrue(new MyAccount_SubscriptionInfo().ProductTypesSectionExists(sectionName), $"Failed to find product types section {sectionName} in the Subscription Information screen", $"Successfully found product types section {sectionName} in the Subscription Information screen"))
			{
				if (Report.IsTrue(new MyAccount_SubscriptionInfo().ProductTypesExists(sectionName), $"Failed to find product types in section {sectionName}", $"Successfully found product types in section {sectionName}"))
				{
					Report.IsTrue(new MyAccount_SubscriptionInfo().SaveProductsCount(sectionName, savedAs), $"Failed to save the count of products from section {sectionName}", $"Successfully saved the count of products from section {sectionName}");
				}
			}
		}

		[StepDefinition(@"I verify the products count encreased for type (.*) in section (.*) then was before saved as: (.*)")]
		public void ThenIVerifyTheProductsCountEncreasedForTypeSingleRetailerInSectionSubmittedThenWasBeforeSavedAsProductsCount(string productType, string sectionName, string savedAs)
		{
			if (Report.IsTrue(new MyAccount_SubscriptionInfo().ProductTypesSectionExists(sectionName), $"Failed to find product types section {sectionName} in the Subscription Information screen", $"Successfully found product types section {sectionName} in the Subscription Information screen"))
			{
				if (Report.IsTrue(new MyAccount_SubscriptionInfo().ProductTypesExists(sectionName), $"Failed to find product types in section {sectionName}", $"Successfully found product types in section {sectionName}"))
				{
					Report.IsTrue(new MyAccount_SubscriptionInfo().VerifyProductsCount(productType, sectionName, savedAs), $"Failed to confirm the product count was changed correctly", $"Successfully confirmed the product count was changed correctly");
				}
			}
		}

		[StepDefinition(@"In MyAccount page I verify Subscription section exist with options:")]
		public void ThenInMyAccountPageIVerifySubscriptionSectionExistWithOptions(Table table)
		{
			Report.IsTrue(new MyAccount().HeaderExists("Subscription"), $"Failed to confirm Subscription header exists", $"Successfully confirmed the Subscription header exists");
			if (Report.IsTrue(new MyAccount().SubscriptionOptionsExists(), "Failed to find section Subscription in My Account page", "Successfully found section Subscription in My Account page"))
			{
				Report.IsTrue(new MyAccount().VerifySubscriptionOptions(table), $"Failed to verify all options in the Subscription section", $"Successfully verified all options in the Subscription section");	
			}
		}

		[Then(@"In MyAccount page I get Subscription detailes and save data as: (.*)")]
		public void ThenInMyAccountPageIGetSubscriptionDetailesAndSaveDataAsMyAccountSubscription(string savedAs)
		{
			if (Report.IsTrue(new MyAccount().SubscriptionDetailsExists(), "Failed to find Subscription details in My Account page", "Successfully found Subscription details in My Account page"))
			{
				Report.IsTrue(new MyAccount().SaveSubscriptionDetails(savedAs), $"Failed to get and save Subscription details", $"Successfully got and saved Subscription details");
			}
		}

		[StepDefinition(@"In the My Account screen I navigate to the (Company Information|Subscription Information|Payment Methods|Order History|My Library) page")]
		[StepDefinition(@"In the My Account page I navigate to the (Company Information|Subscription Information|Payment Methods|Order History|My Library) page")]
		public void ThenInTheMyAccountScreenINavigateToTheXPage(string nav_option)
		{
			var selMyAccount = new MyAccount();
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(selMyAccount.Accounts_Navigation(nav_option), $"Failed to Navigate to { nav_option}",
				$"Successully Navigated to { nav_option}");
		}

		[StepDefinition(@"I verify Subscription details on Subscription Information page match with saved as: (.*)")]
		public void ThenIVerifySubscriptionDetailsOnSubscriptionInformationPageMatchWithSavedAsMyAccountSubscription(string savedAs)
		{
			Report.IsTrue(new MyAccount().HeaderExists("Subscription"), $"Failed to confirm Subscription header exists", $"Successfully confirmed the Subscription header exists");
			if (Report.IsTrue(new MyAccount_SubscriptionInfo().SubscriptionDetailsListExists(), "Failed to find Subscription details in Subscription Information page", "Successfully found Subscription details in Subscription Information page"))
			{
				Report.IsTrue(new MyAccount_SubscriptionInfo().CheckSubscriptionDetails(savedAs), $"Failed to confirm Subscription details match with My Account page", $"Successfully confirmed Subscription details match with My Account page");
			}
		}

		[StepDefinition(@"In the Subscription Information I see option (.*) under (.*) section")]
		public void ThenInTheSubscriptionInformationISeeOptionSingleRetailerUnderSubmittedSection(string option, string section)
		{
			if (Report.IsTrue(new MyAccount_SubscriptionInfo().ProductTypesSectionExists(section), $"Failed to find product types section {section} in the Subscription Information screen", $"Successfully found product types section {section} in the Subscription Information screen"))
			{
				if (Report.IsTrue(new MyAccount_SubscriptionInfo().ProductTypesExists(section), $"Failed to find product types in section {section}", $"Successfully found product types in section {section}"))
				{
					Report.IsTrue(new MyAccount_SubscriptionInfo().CheckOptionExistsInSection(option, section), $"Failed to find option {option} in section {section}", $"Successfully found option {option} in section {section}");
				}
			}
		}

		[StepDefinition(@"In the Subscription Information in Subscription History under Subscription Level Status I see option (.*)")]
		public void ThenInTheSubscriptionInformationInSubscriptionHistoryUnderSubscriptionLevelStatusISeeOptionSingleRetailer(string option)
		{
			Report.IsTrue(new MyAccount_SubscriptionInfo().Subscription_Level_Status(option),
										$"Failed to Confirm Subscription Level Status contains option {option}", $"Subscription Level Status Correct contains option {option}");
		}




		[StepDefinition(@"In the Subscription Information screen I confirm the Status has the correct information: (.*) Formulated, (.*) Articles, (.*) Enhanced Articles")]
		public void ThenInTheSubscriptionInformationScreenIConfirmTheStatusHasTheCorrectInformationFormulatedArticlesEnhancedArticles(string form_no, string art_no, string en_art_no)
		{
			Report.StartSubStep(Report.Details.StepIndex + " - In the Subscription Information screen I confirm the Status has the correct information: " + form_no + " Formulated, " + art_no + " Articles, " + en_art_no + " Enhanced Articles");
			try
			{
				var selMyAccount = new MyAccount_SubscriptionInfo();

				Report.IsTrue(selMyAccount.Status_Information_Correct(form_no, art_no, en_art_no), "Subscription Information is Incorrect",
					"Subscription Information is Correct");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Subscription Information screen I confirm the Subscription History table has the correct information")]
		public void ThenInTheSubscriptionInformationScreenIConfirmTheSubscriptionHistoryTableHasTheCorrectInformation(Table table)
		{
			Report.StartStep(ReportSettings.StepCounter + " - In the Subscription Information screen I confirm the Subscription History table has the correct information");
			try
			{
				var selMyAccount = new MyAccount_SubscriptionInfo();

				foreach (TableRow thisRow in table.Rows)
				{
					try
					{
						string sub_level_status = thisRow["Subscription Level Status"];
						string qty = thisRow["Quantity"];

						Report.Info("Subscription Level Status = " + sub_level_status);
						Report.Info("Quantity = " + qty);

						Report.IsTrue(selMyAccount.Subscription_Level_Status(sub_level_status),
							"Failed to Confirm Subscription Level Status", "Subscription Level Status Correct");
						Report.IsTrue(selMyAccount.Subscription_Quantity(qty, sub_level_status),
							"Failed to Confirm Quantity", "Quantity Correct");
					}
					catch (Exception ex)
					{
						Report.Error(ex.Message);
					}

				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Subscription Information screen I click the Upgrade button")]
		public void ThenIClickTheUpgradeButton()
		{
			var selMyAccount = new MyAccount_SubscriptionInfo();

			Report.IsTrue(selMyAccount.Click_Upgrade_Button(), "Failed to Click UPGRADE Button",
				"UPGRADE Button Clicked and Subscription Upgrade Page Opened");
		}

		[StepDefinition(@"In the Order History screen I select (Subscription|WERCSmart)")]
		public void ThenInTheOrderHistoryScreenISelectX(string radio_option)
		{
			Report.StartStep(ReportSettings.StepCounter + " - In the Order History screen I select  " + radio_option);
			try
			{
				var selMyAccount = new MyAccount_OrderHistory();

				Report.IsTrue(selMyAccount.Order_History_Select(radio_option), "Failed to Select " + radio_option,
					"Successully Selected " + radio_option);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
		[StepDefinition(@"In the Order History screen I save first Invoice Number as: (.*)")]
		public void ThenInTheOrderHistoryScreenISaveFirstInvoiceNumberAsInvoiceNumber(string savedAs)
		{
			var orderHistory = new MyAccount_OrderHistory();

			if (Report.IsTrue(orderHistory.InvoiceNumberExists(), "Failed to find Ivoice Number under Order Number column", "Successfully found Ivoice Number under Order Number column"))
				{
				string getInvoiceNumber = orderHistory.GetFirstInvoiceNumber();
				if(getInvoiceNumber != null)
				{
					Context.AddToContext(savedAs, getInvoiceNumber);
					Report.Info($"Successfully saved Invoice Number {getInvoiceNumber}");
				}
				else
				{
					Report.Failure("Can not get Invoice Number");
				}
			}
		}


		[StepDefinition(@"In the Order History screen I get the Invoice Number and Date and confirm the invoice email has arrived for user saved as: (.*)")]
		public void ThenInTheOrderHistoryScreenIGetTheInvoiceNumberAndDateAndConfirmTheInvoiceEmailHasArrivedForUserSavedAs(string savedAs)
		{
			Report.StartStep(ReportSettings.StepCounter + " - In the Order History screen I get the Invoice Number and Date and confirm the invoice email has arrived for user saved as: " + savedAs);
			try
			{
				var myOrder = new MyAccount_OrderHistory();
				var myAccount = new MyAccount();

				if (savedAs == "New_Sub")
				{
					if (Context.FeatureContext.ContainsKey("CurrentAccount"))
					{
						savedAs = Context.FeatureContext["CurrentAccount"].ToString();
					}
					Report.Info("Account = " + savedAs);
				}

				var wsUser = (WERCSmartUser)Context.GetFromContext(savedAs);

				string myInvoice = myOrder.Get_Invoice_Number(wsUser.CompanyName);

				if (!myAccount.Invoice_Email_Arrived(myInvoice, wsUser.Email))
				{
					throw new Exception("Email has Not Arrived for User: " + savedAs);
				}
				Report.Success("Invoice Email has Arrived for User: " + savedAs);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click on the option (User Accounts|Division Accounts)")]
		public void ClickingOnMyAccountOptionDivisionUserAccounts(string option)
		{
			Report.IsTrue(new MyAccount().IClickOnAccountFilter(option), "Failed to click on option: " + option, "Successfully clicked on option: " + option);
		}

		[StepDefinition(@"I (should|should not) see the Division Accounts grid")]
		public void DivisionsAccountGridIsShowing(string shouldornot)
		{
			bool expected = shouldornot == "should";
			bool showing = new MyAccount().DivisionGridShowing();
			Report.IsTrue(showing == expected, "Division area " + (showing ? "was" : "was not") + showing + "!", "Division area " + (showing ? "was" : "was not") + showing + "!");
		}

		[StepDefinition(@"In the Company Information screen I should see (.*) (Division|User) Accounts")]
		public void CompanyInformation_DivisionAccountsShowing(string number, string type)
		{
			string showing = new MyAccount_CompanyInfo().ReturnUserOrDivisionAccountsNumber(type);
			Report.IsTrue(showing.Trim() == number, "Found: " + showing + " " + type + " accounts, when " + number + " were expected!", "Successfully found: " + number + " " + type + " accounts!");

		}

		[StepDefinition(@"In Your Company User Accounts the user (.*) is associated with the administrator email address")]
		public void UserIsAssociatedAdminEmail(string user)
		{
			Delay.Seconds(2);
			var listOfUsers = (List<User>)Context.GetFromContext("userGrid");
			User userMatch = listOfUsers.FirstOrDefault(x => x.Username == user);
			Delay.Seconds(2);
			Report.IsFalse(userMatch == null,
				"The user: " + user + " was not found in the My Account user grid",
				"The user: " + user + " was found in the My Account user grid");
			if (userMatch == null)
			{
				Report.Failure("The user: " + user + " was not found in the My Account user grid");
				Report.Screenshot();
				return;
			}
			Delay.Seconds(2);
			Report.Success("The user: " + user + " was found in the My Account user grid");
			Report.Screenshot();
			string adminEmail = new MyAccount().GetAdminEmail();
			Delay.Seconds(2);
			Report.IsTrue(userMatch.Email == adminEmail,
				string.Format("The user: '{0}' was not associated with the email address: '{1}'",
					user, adminEmail),
				string.Format("The user: '{0}' was associated with the email address: '{1}' as expected",
					user, adminEmail));
		}

		[StepDefinition(@"The My Account user grid is currently on page number: (.*)")]
		public void UserGridIsActiveOnPageNumber(string expectedPage)
		{
			var selMyAccount = new MyAccount();
			string activePage = selMyAccount.UserAccountsActivePage();
			Report.IsTrue(activePage == expectedPage,
				"The My Account user grid is not on the expected page: " + expectedPage + ". It is on page: " + activePage,
				"The My Account user grid is on the expected page: " + expectedPage);
		}

		[StepDefinition(@"I click (next|previous|...) in the My Account user grid")]
		public void ClickNextPrevInUserGrid(string navOption)
		{
			Report.IsTrue(new MyAccount().UserGridNavigation(navOption),
				"Failed to navigate in the user grid with action: " + navOption,
				"Successfully navigated in the user grid with action: " + navOption);
		}

		[StepDefinition(@"I add (.*) new users with emails using the following information")]
		public void AddMultipleUsersWithEmails(string userCount, Table table)
		{
			for (int i = 0; i < Convert.ToInt32(userCount); i++)
			{
				string myDate = DateTime.Now.ToString("HHmmssddMMyy");
				string myEmail = MailosaurFunctions.CreateEmail(myDate);
				if (myEmail == "")
				{
					throw new Exception("Failed to Create a New Email Address");
				}
				Context.AddToContext("CurrentEmail", myEmail);
				Report.Success("Email Address Created and Saved in Scenario Context");
				foreach (TableRow thisRow in table.Rows)
				{
					string userName = thisRow["User Name"];
					string title = thisRow["Title"];
					string role = thisRow["Role"];
					string phoneNo = thisRow["Phone Number"];
					string emailAddress = thisRow["Email Address"];
					string confirmEmail = thisRow["Confirm Email"];
					string countryCode = thisRow["Country Code"];
					string country = thisRow["Country"];

					if (userName == "User")
					{
						userName = userName + "_" + System.DateTime.Now.ToString("HHmmddMMyy");

						Context.AddToContext("CurrentUser", userName);

						Report.Info("User Name = " + userName);
					}

					if (emailAddress == "Saved")
					{
						if (Context.ScenarioContext.ContainsKey("CurrentEmail"))
						{
							emailAddress = Context.ScenarioContext["CurrentEmail"].ToString();
						}
						Report.Info("Email Address = " + emailAddress);
					}

					if (confirmEmail == "Saved")
					{
						if (Context.ScenarioContext.ContainsKey("CurrentEmail"))
						{
							confirmEmail = Context.ScenarioContext["CurrentEmail"].ToString();
						}
						Report.Info("Email Address = " + confirmEmail);
					}

					if (countryCode == "empty")
					{
						countryCode = "";
					}
					var selMyAccount = new MyAccount();
					//Open New User Form
					Report.IsTrue(selMyAccount.Add_New_User_click(), "Failed to Click Add New User Link",
						"New User Form Link Clicked");
					Delay.Seconds(3 * Delay.SpeedFactor);
					var selMyUserForm = new UserDetails();
					//Check Form Has Opened
					Report.IsTrue(!selMyUserForm.Exists, "Failed to Open Add User Form", "Add User Form Open");
					//Add New User
					Report.IsTrue(selMyUserForm.Add_New_User(userName, title, role, phoneNo, emailAddress, confirmEmail, country),
						"Failed to Add a New User", "New User Added");

					Delay.Seconds(1 * Delay.SpeedFactor);

				}
			}
		}

		[StepDefinition(@"I see the user grid page navigation input with up and down arrows")]
		public void PageInputNumber()
		{
			Report.IsTrue(new MyAccount().UserGridNavPageInputShowing(),
				"The user grid page navigation input was not visible",
				"The user grid page navigation input was visible as expected");
		}

		[StepDefinition(@"I enter the (up|down) arrow into the user grid page navigation box then the correct page is shown")]
		public void EnterArrowUserGridNavigationBox(string direction)
		{
			var selMyAccount = new MyAccount();
			string pageNavigationValue = Context.GetFromContext("Page Navigation Value") == null
				? selMyAccount.CurrentPageUserGridNavPageInput()
				: Context.GetFromContext("Page Navigation Value").ToString();

			Report.StartStep(ReportSettings.StepCounter + " - I enter the " + direction + " arrow into the page navigation box");
			Report.Info("Entering the " + direction + " arrow key to the user grid page navigation input");
			selMyAccount.KeyToUserGridNavPageInput(direction);
			Report.Info("Pressing the enter key");
			selMyAccount.KeyToUserGridNavPageInput("enter");
			string iteration = direction == "up" ? "increased" : "decreased";
			ReportSettings.StepCounter++;
			Report.StartStep(ReportSettings.StepCounter + " - I confirm the page number has " + iteration + " by 1");
			int currentPage = Convert.ToInt32(selMyAccount.UserAccountsActivePage());
			int difference = direction == "up" ? 1 : -1;
			Report.IsTrue(currentPage == Convert.ToInt32(pageNavigationValue) + difference,
				string.Format("The active page did not {0} by 1 after entering the '{1}' arrow into the page navigation box at position '{2}'",
					iteration.Remove(iteration.Length - 1), direction, pageNavigationValue),
				string.Format("The active page correctly {0} by 1 to page {1} after entering the '{2}' arrow into the page navigation box at position '{3}'",
					iteration, currentPage, direction, pageNavigationValue));
		}

		[StepDefinition(@"I type the number (.*) into the user grid page navigation box and press the enter key")]
		public void TypeNumberUserGridNavigationBoxAndPressEnter(string pageNum)
		{
			var selMyAccount = new MyAccount();
			Report.Info("Entering text: " + pageNum + " into the user grid page navigation input");
			selMyAccount.NumToUserGridNavPageInput(pageNum);
			Report.Info("Pressing the enter key");
			selMyAccount.KeyToUserGridNavPageInput("enter");
		}

		[StepDefinition(@"I should see the following tabs in the My Library page")]
		public void TabsShowingInMyLibrary(Table tabs)
		{
			var selMyLibrary = new MyAccount_MyLibrary();
			var tabsExpected = new List<string>();
			tabs.Rows.Cast<TableRow>().ToList().ForEach(x => tabsExpected.Add(x["Tab"]));
			List<string> tabsDisplayed = selMyLibrary.AllTabs();
			Report.IsTrue(!tabsDisplayed.Except(tabsExpected).Any() && tabsDisplayed.Count == tabsExpected.Count,
				"The displayed tabs did not match the list of expected tabs. Displayed was: " + string.Join(", ", tabsDisplayed),
				"The displayed tabs matched the list of expected tabs: " + string.Join(", ", tabsDisplayed));
		}

		[StepDefinition(@"I navigate to the (My Packaging Types|My Brands|My Distributors|My Ingredients) tab in the My Library page")]
		public void ClickTabMyLibrary(string tab)
		{
			Report.Info("Clicking the My Library tab with heading: " + tab);
			Report.IsTrue(new MyAccount_MyLibrary().ClickTab(tab),
				"Failed to navigate to the :" + tab + " tab",
				"Successfully navigated to the :" + tab + " tab");
		}

		[StepDefinition(@"I confirm the current active tab on the My Library page is: (.*)")]

		public void CurrentActiveTabMyLibrary(string expectedTab)
		{
			var selMyLibrary = new MyAccount_MyLibrary();
			var selMyPackagingTypes = new MyPackagingTypes();
			string activeTab = selMyLibrary.ActiveTab();
			Report.IsTrue(selMyPackagingTypes.Active = activeTab == expectedTab,
				"The current active tab was not: " + expectedTab + "' as expected. The active tab was: " + activeTab,
				"The current active tab was: '" + activeTab + "' as expected");
		}

		[StepDefinition(@"I click 'Add New' in the (My Packaging Types|My Brands) section of My Library")]
		public void ClickAddNewMyLibrary(string tab)
		{
			if (tab == "My Packaging Types")
			{
				Report.IsTrue(new MyPackagingTypes().AddNew(),
					"Failed to click 'Add New' under My Packaging Types",
					"Successfully clicked 'Add New' under My Packaging Types");
				GeneralUtilities.Wait_for_load_finish();
				return;
			}
			if (tab == "My Brands")
			{
				Report.IsTrue(new MyBrands().AddNew(),
					"Failed to click 'Add New' under My Brands",
					"Successfully clicked 'Add New' under My Brands");
				return;
			}
			Report.Failure("Unable to 'Add New' for specified section: " + tab);
		}

		[StepDefinition(@"In the Company Information page I confirm the Company Information is correct")]
		public void ThenInTheCompanyInformationPageIConfirmTheCompanyInformationIsCorrect(Table myTable)
		{
			var myCompanyInfo = new MyAccount_CompanyInfo();

			foreach (TableRow thisRow in myTable.Rows)
			{
				string companyName = thisRow["Company Name"];
				if(companyName.Contains("<RandomID>"))
				{
					string currentUsedEmail = TestUsers.GetUserSavedAs(thisRow["Email Address"].TrimStart('<').TrimEnd('>')).Username;
					string edited1 = currentUsedEmail.Replace("User_", "");
					string userString = edited1.Replace(TestVariables.GetVariableSavedAs("Mailosaur Prefix"), "");
					companyName= companyName.Replace("<RandomID>", userString);		
					
				}

				Report.Info("Company Name = '" + companyName + "'");
				string adminName = thisRow["Admin Name"];
				Report.Info("Admin Name = '" + adminName + "'");
				string emailAddress = thisRow["Email Address"];

				if (emailAddress.StartsWith("<") && emailAddress.EndsWith(">"))
				{
					emailAddress = TestUsers.GetUserSavedAs(emailAddress.TrimStart('<').TrimEnd('>')).Username;
				}

				Report.Info("Email Address = '" + emailAddress + "'");
				string supplierType = thisRow["Supplier Type"];
				Report.Info("Supplier Type = '" + supplierType + "'");
				string country = thisRow["Country"].ToUpper();
				Report.Info("Country = '" + country + "'");
				string address = thisRow["Address"];
				Report.Info("Address = '" + address + "'");
				string city = thisRow["City"];
				Report.Info("City = '" + city + "'");
				string state = thisRow["State"];
				Report.Info("State = '" + state + "'");
				string zipCode = thisRow["Zip Code"];
				Report.Info("Zip Code = '" + zipCode + "'");
				string countryCode = thisRow["Country Code"];
				Report.Info("Country Code = '" + countryCode + "'");
				string companyPhone = thisRow["Phone"];
				Report.Info("Phone = '" + companyPhone + "'");

				Report.IsTrue(myCompanyInfo.Company_Information_Correct(companyName, adminName, emailAddress, supplierType,
						country, address, city, state, zipCode, countryCode, companyPhone),
					"Failed to Confirm Correct Company Information", "Correct Company Information Confirmed");
			}
		}

		[StepDefinition(@"I close the 'Thank You' user updated dialog")]
		public void CloseThankYouUpdated()
		{
			Report.IsTrue(new AddUserThankYouDialog().Updated_User_Thank_You_Close(), "Failed to click Close in Thank You pop up", "Successfully clicked Close in the Thank You pop up");
		}

		[StepDefinition(@"I close the 'Thank You' user added dialog")]
		public void CloseThankYouCreated()
		{
			Report.IsTrue(new AddUserThankYouDialog().Add_User_Thank_You(), "Failed to click Close in Thank You pop up", "Successfully clicked Close in the Thank You pop up");
		}


		

		[StepDefinition(@"I click the 'How to Subscribe' link in My Account")]
		public void ClickHowToSubscribeLinkInMyAccount()
		{
			Report.IsTrue(new MyAccount().ClickHowToSubscribeLink(), "Failed to click the 'How to Subscribe' link!", "Successfully clicked the 'How to Subscribe' link");
		}

		[StepDefinition(@"In the ""(.*)"" WercSmart Solutions article, I click the link for 'To view a video... click here'")]
		public void InWercSmartSolutionArticleIClickViewVideoHere(string articleHeading)
		{
			string displayedArticle = new WercSmartSolutionsArticle().ArticleHeading();
			if (Report.IsTrue(displayedArticle == articleHeading, "The correct article was not displayed! Expected: " + articleHeading + " but got: " + displayedArticle, "The correct article heading was dipslayed: " + articleHeading))
			{
				Report.IsTrue(new SubscriptionEnrollmentManagement().ClickViewVideo(), "Failed to click 'View Video here' on the Subscription Enrollment and Management article!", "Successfully clicked 'View Video here' on the Subscription Enrollment and Management article");
			}
		}

		[StepDefinition(@"I confirm a new tab opens to YouTube with a video titled: (.*)")]
		public void ConfirmANewTabOpensToYouTubeWithVideoTitled(string videoTitle)
		{
			var selYoutube = new YouTube();
			System.Collections.ObjectModel.ReadOnlyCollection<string> allHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			foreach (string handle in allHandles)
			{
				SeleniumBrowser.WebBrowser.SwitchTo().Window(handle);
				if (selYoutube.Wait_for_load(10))
				{
					Report.Success("The YouTube tab was opened");
					Report.Screenshot();
					Report.Info("Saving YouTube window to context");
					new GlobalSteps().SaveTheCurrentWindowAs("YouTube");
					 if (selYoutube.VideoDisplayed())
					{
						string actualTitle = selYoutube.VideoTitle();
						Report.IsTrue(actualTitle == videoTitle, "The video title did not match the expected text! Expected: " + videoTitle + " but found: " + actualTitle, "A video was displayed with the title: " + videoTitle + " as expected");
						return;
					}
					Report.Failure("There was no video displayed on YouTube!");
					Report.Screenshot();
					return;
				}
			}
			Report.Failure("The YouTube tab did not open as expected!");
			Report.Screenshot();
		}

		[StepDefinition(@"I check that there are at least (\d) pages of users\. If not this test will not work\.")]
		public void GivenICheckThatThereAreAtLeastSixPagesOfUsers_IfNotThisTestWillNotWork_(int minPages)
		{
			Report.IsTrue(new MyAccount().GetHighestPageNo() > 5,
				"Can't run this test since we need a page count of 6 or higher", "OK to continue with this test.");
		}

		[StepDefinition(@"In the Subscription Information screen I confirm status is: (.*)")]
		public void ThenIConfirmStatus(string status)
		{
			var selMyAccount = new MyAccount_SubscriptionInfo();

			Report.IsTrue(selMyAccount.Get_Status() == status, "status is not as expected",
				"Status is as expected");
		}

		[StepDefinition(@"In the Subscription Information screen I confirm grace period is: (.*)")]
		public void ThenIConfirmGracePeriod(string gracePeriod)
		{
			var selMyAccount = new MyAccount_SubscriptionInfo();

			Report.IsTrue(selMyAccount.Get_GracePeriod() == gracePeriod, "grace period is not as expected",
				"grace period is as expected");
		}


		[StepDefinition(@"In Stewardship table I select the following options for field: (.*) and stewardship as: (.*) and Issue date: (.*) and Expire Date: (.*)")]
		public void StewardshipInformation(string field, string options1)
		{
			GeneralUtilities.ScrollToBottomOfPage();
			var mystwdinfo = new MyAccount_CompanyInfo();
			Report.IsTrue(mystwdinfo.StewardshipEdit_click(), "failed to click edit", "successfully clicked edit");
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(mystwdinfo.EnterStewardshipInfo(field, options1), "failed to enter stewardship information", "successfully entered steward information");
			Report.IsTrue(mystwdinfo.StewardshipSaveOrCancel_Click("Save"), "failed to click save", "successfully clicked save");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I add the following in Canada Supplier Address")]
		public void AddCanadaAddress(string options1, string options2, string option3, string options4, string options5, string option6, string option7)
		{
			GeneralUtilities.ScrollToBottomOfPage();
			var canadd = new MyAccount_CompanyInfo();
			Report.IsTrue(canadd.Canada_Supplier_Edit_click(), "failed to click edit", "successfully clicked edit");
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(canadd.Add_Canada_Supplier_Address(options1, options2, option3, options4, options5, option6, option7), "failed to enter stewardship information", "successfully entered steward information");
			Report.IsTrue(canadd.Canada_Supplier_Save_click(), "failed to click save", "successfully clicked save");
			GeneralUtilities.Wait_for_load_finish();
		}


		[StepDefinition(@"I update the password for for the selected user in the change user password popup, using the admin password: (.*)")]
		public void IUpdateThePasswordForGivenUser(string savedAs)
		{
			var adminUser = TestUsers.GetUserSavedAs(savedAs);

			if (adminUser == null)
			{
				Report.Error($"The test user: {savedAs} could not found in TReVor");
				return;
			}

			string adminPassword = adminUser.Password;


			var selModal = new ModalDialog();
			if (!Report.IsTrue(selModal.Wait_for_load(), "Expected a modal dialog to load!", "Modal dialog loaded as expected"))
			{
				return;
			}

			if (selModal.LoginPasswordFieldPresent())
			{
				Report.Info("Entering Admin password in the input: *******");
				selModal.EnterLoginPassword(adminPassword);
			}

			GeneralUtilities.Wait_for_load_finish();
			Report.Info("Clicking Continue");
			selModal.ClickContinue();
			Report.Info("Entering new password in New Password input: *******");
			selModal.EnterNewPassword(adminPassword);
			Report.Info("Entering new password in Verify Password input: *******");
			selModal.EnterVerifyPassword(adminPassword);
			Report.Info("Clicking save in the Change Password popup");
			Report.IsTrue(selModal.ClickSave(),
				"Failed to click save in Change Password",
				"Successfully clicked save in Change Password");
			GeneralUtilities.Wait_for_load_finish();

			Report.Info("Clicking close in the Change Password popup");
			Report.IsTrue(selModal.Click_Close(),
				"Failed to click close in Change Password",
				"Successfully clicked clse in Change Password");
			GeneralUtilities.Wait_for_load_finish();




		}


		[StepDefinition(@"I reset the password on the newly created user account using the admin password for the account: (.*)")]
		public void ResetUserPassword(string savedAs)
		{

			string user = Context.GetFromContext("CurrentUser").ToString();
			if (user == null)
			{
				Report.Error("The CurrentUser was not saved in context");
				return;
			}

			ReportSettings.UseSubSteps = true;

			Report.StartStep($"I update the password for user: {user}");
			var selMyAccount = new StepsMyAccount();
			Report.Info("Clicking Reset Password for the current logged in user");
			selMyAccount.GivenIGoToActionInUserGridForGiven("Reset Password", user);
			Report.Info("Updating the password for test user " + user);
			selMyAccount.IUpdateThePasswordForGivenUser(savedAs);


		}

		[StepDefinition(@"I create a new user with the following information and set the password from the admin account: (.*)")]
		public void CreateUserAndSetPassword(string savedAs, Table table)
		{

			ReportSettings.UseSubSteps = true;

			Report.StartStep("I add a new user");
			Report.Info("Adding user with the following information");
			SpecFlowReporting.Table(table);
			this.ThenIAddANewUserWithTheFollowingInformation(table);
			var adminUser = TestUsers.GetUserSavedAs(savedAs);
			var allUsers = new MyAccount().UserGrid();
			var newUsername = Context.GetFromContext("CurrentUser").ToString();
			var matchingUser = allUsers.FirstOrDefault(x => x.Username == newUsername);

			if (matchingUser == null)
			{
				Report.Failure($"The User '{newUsername}' could not be found in the user grid");
				return;
			}
			string email = matchingUser.Email.TrimEnd(".kxxyxunf@mailosaur.io");
			string password = adminUser.Password;


			//User newUser = new User { Email = email, Password = password };
			//Context.AddToContext("NewUser",newUser);

			Report.StartStep("I reset the password for the new user to match the admin password");
			this.ResetUserPassword(savedAs);

			Table userTable = new Table("Field", "Value");
			userTable.AddRow("Email", email);
			userTable.AddRow("Password", password);
			userTable.AddRow("PhoneQuestion", "PhoneQuestion");
			userTable.AddRow("PhoneHint", "PhoneHint");
			userTable.AddRow("MentorQuestion", "MentorQuestion ");
			userTable.AddRow("MentorHint", "MentorHint");
			userTable.AddRow("FriendQuestion", "FriendQuestion");
			userTable.AddRow("FriendHint", "FriendHint");
			userTable.AddRow("AnimalQuestion", "AnimalQuestion");
			userTable.AddRow("AnimalHint", "AnimalHint");
			userTable.AddRow("CollegeQuestion", "CollegeQuestion");
			userTable.AddRow("CollegeHint", "CollegeHint");
			userTable.AddRow("Pin", "1234");

			new StepsSignup().DefineUser("NewUser", userTable);

			//var testuser= (WERCSmartUser)Context.GetFromContext("NewUser");









		}


		[StepDefinition(@"In Stewardship table I select I have no stewardship Numbers")]
		public void ClickIhaveNoStewardshipNumbers()
		{
			ReportSettings.UseSubSteps = true;
			GeneralUtilities.ScrollToBottomOfPage();
			var modaldialog = new ModalDialog();
			var mystwdinfo = new MyAccount_CompanyInfo();
			Report.IsTrue(mystwdinfo.StewardshipEdit_click(), "failed to click edit", "successfully clicked edit");
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(mystwdinfo.NoStewardshipCheckbox_click(), "failed to click checkbox", "successfully clicked checkbox");
			new GlobalSteps().WaitForAModalDialogToOpen();		


			Report.IsTrue(modaldialog.Click_Yes(), "failed to click Yes", "successfully clicked Yes");

			Report.IsTrue(mystwdinfo.StewardshipSaveOrCancel_Click("Save"), "failed to click save", "successfully clicked save");
			GeneralUtilities.Wait_for_load_finish();
		}

		/// <summary>
		/// Requires a string parameter saved to context as: CurrentEmail which is called in the add a new user step
		/// </summary>
		[StepDefinition(@"I confirm there was an email with title: (.*) sent to the new user and I click the link with text: (.*)")]
		public void ThenTheEmailShouldContainALinkToSetUpTheWercSmartAccount(string emailTitle, string linkText)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("Checking an email has been sent to the new user with title: " + emailTitle);
			var emailFrom = TestVariables.GetVariableSavedAs("NotificationEmail");
			var email = Context.GetFromContext("CurrentEmail").ToString();
			List<Email> differences = MailosaurFunctions.GetInboxDifferences(email);
			Report.Info("Checking that email differences have been found...");
			if (differences.FirstOrDefault() == null)
			{
				Report.Error("No emails found");
				return;
			}
			Report.Info("Emails have been found!");
			Email matchingEmail = differences.FirstOrDefault(x => x.From != null && x.From.FirstOrDefault()?.Address.ToLower() == emailFrom && x.Subject.Contains(emailTitle));
			if (matchingEmail == null)
			{
				Report.Failure($"No matching email from: {emailFrom} with subject: {emailTitle} was found!");
				return;
			}
			var links = matchingEmail.Html.Links;
			if (links == null || !links.Any())
			{
				Report.Failure("No links were found in the email!");
				return;
			}
			var link = links.FirstOrDefault(x => x.Text.Contains(linkText))?.Href;
			if (link == null)
			{
				Report.Failure("No link was found with text: " + linkText);
				return;
			}
			Report.Info("Found a matching link in the email!");
			Report.StartStep("Navigating to the link address");
			SeleniumBrowser.Navigate(link);
		}

		[StepDefinition(@"I Select the Active filter")]
		public void ISelectTheActiveFilter()
		{
			Report.IsTrue(new MyAccount().IClickOnAccountActiveFilter(), "Failed to select the Active Filter", "Successfully selected the Active Filter");
		}

		[StepDefinition(@"I Select the Inactive filter")]
		public void ISelectTheInActiveFilter()
		{
			Report.IsTrue(new MyAccount().IClickOnAccountInActiveFilter(), "Failed to select the Inactive Filter", "Successfully selected the Inactive Filter");
		}

		[StepDefinition(@"I Confirm that you (See|Don't See) the user you just created in the grid")]
		public void IConfirmThatYouSeeTheUserJustCreatedInGrid(string presence)
		{
			Report.StartStep(ReportSettings.StepCounter + " - I confirm that you " + presence + " the new user I just created is in the Gird");
			try
			{
				var selMyAccount = new MyAccount();

				string userName = string.Empty;

				if (Context.ScenarioContext.ContainsKey("CurrentUser"))
				{
					userName = Context.ScenarioContext["CurrentUser"].ToString();
				}
				if (presence == "See")
				{
					Report.IsTrue(selMyAccount.Is_User_In_Grid(userName), "The User just created was Not Found In the Grid", "The User just created was found in the Grid");
				}
				if (presence == "Don't See")
				{
					Report.IsFalse(selMyAccount.Is_User_In_Grid(userName), "The User just created was found in the Grid", "The User just created was Not Found In the Grid");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In Stewardship table click edit")]
		public void StewardshipTableEditClick()
		{
			try
			{
				GeneralUtilities.ScrollToBottomOfPage();
				var mystwdinfo = new MyAccount_CompanyInfo();
				Report.IsTrue(mystwdinfo.StewardshipEdit_click(), "failed to click edit", "successfully clicked edit");
				GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}

		}

		[StepDefinition(@"In Stewardship table I click: (.*)")]
		public void StewardshipSaveorCancel(string option)
		{
			try
			{
				GeneralUtilities.ScrollToBottomOfPage();
				var mystwdinfo = new MyAccount_CompanyInfo();
				Report.IsTrue(mystwdinfo.StewardshipSaveOrCancel_Click(option), "failed to click option", "successfully clicked option");
				GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Create new users in the My Account page via the user Grid until there are atleast: (.*) pages present")]
		public void ICreateXNewUsersInTheMyAccountPageViaTheUserGrid(int noPages)
		{
			
			var myAccount = new MyAccount();
			Report.Info($"There are currently a total of { myAccount.GetHighestPageNo()}");
			if (myAccount.GetHighestPageNo()< noPages)
			{
				int i = 0;
				int remainingPages = noPages - myAccount.GetHighestPageNo();
				int limit = remainingPages * 10;
				Report.Info($"Limiting the max number of new users that I will create to: {limit}");

				while (myAccount.GetHighestPageNo()< noPages && i<limit)
				{
					new Steps_Shared().GivenICallSharedStepCreateNewUserViaUserGrid();
					i++;
				}
				if (i < limit)
				{
					Report.Info($"The New user limit was not reached");
				}
				else
				{
					Report.Info($"The New user limit was reached");
				}

				Report.Info($"The Highest Page Number is currently: {myAccount.GetHighestPageNo()}");
				Report.IsTrue(myAccount.GetHighestPageNo() >= noPages, "The total number of pages was not atleast:"+noPages, "The total number of pages was atleast:" + noPages);
				
			}
			else
			{
				Report.Success($"The Current Number of total pages was atleast {noPages}, no new users where created.");
			}

		}

		[StepDefinition(@"I confirm that I do not see any stewardship information")]
		public void NoStewardshipData()
		{
			try
			{
				GeneralUtilities.ScrollToBottomOfPage();
				var mystwdinfo = new MyAccount_CompanyInfo();
				var stwdinfo = mystwdinfo.StewardshipFieldsNoData();
				Report.IsTrue(stwdinfo.FirstOrDefault().IsNullOrEmpty(),
					"Can see Stewardship information", "Stewardship information is not available as expected");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click on the 'Edit' button in Company information in the Stewardship Numbers section")]
		public void ThenIClickOnTheLink()
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.IsTrue(MyAccountObject.ClickOnEditButtonInCompanyInformationPageInStewardshipNumbersSection(), "Failed to click on 'Edit' button", "Successfully clicked 'Edit' button");
		}

		[StepDefinition(@"I fill in Stweardship Numbers information")]
		public void ThenIFillInStweardshipNumbersInformation(Table table)
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.IsTrue(MyAccountObject.FillInStewardshipData(table), "Failed to fill in Stewardship table data", "Successfully filled in Stewardship table data");
		}

		[StepDefinition(@"I save Stewardship Numbers information")]
		public void ThenISaveStewardshipNumbersInformation()
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.IsTrue(MyAccountObject.ClickSaveButtonForStewardshipNumbers(), "Failed to save Stewardship table data", "Successfully saved Stewardship table data");
		}

		[StepDefinition(@"I confirm that the data saved in the Stewardshp Numbers section is correct")]
		public void ThenIConfirmThatTheDataSavedIsCorrect(Table table)
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.IsTrue(MyAccountObject.CheckStewardshipNumbersTableDataAfterItHasBeenSaved(table), "Table data was not correct", "Table data was correct");
		}


		[StepDefinition(@"I check that a heading with the name: (.*) exists")]
		public void ThenICheckThatAHeadingWithTheNameStewardshipNumbersExists(string headingName)
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.IsTrue(MyAccountObject.SearchForHeadingInCompanyInformationPageWithName(headingName), $"Heading with name: { headingName }, was not found", $"Heading with name: { headingName }, was found");
		}

		[StepDefinition(@"I check if there is a table in the Stewardship Numbers section")]
		public void ThenICheckIfThereIsATableInTheStewardshipNumbersSection()
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.IsTrue(MyAccountObject.CheckForTableInCompanyInformationPageInStewardshipNumbersSection(), "Failed to find a table", "Successfully found a table");
		}

		[StepDefinition(@"I find out how many rows are in the table in the Stewardship Numbers section")]
		public void ThenIFindOutHowManyRowsAreInATable()
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.Info("The nuumber of columns in the table is: " + MyAccountObject.CheckNumberOfColumnsInTableInCompanyInformationPageInStewardshipNumbersSection());
		}

		[StepDefinition(@"I check if the Stewardship Numbers table columns names match the following column names")]
		public void ThenICheckIfColumnNamesMatch(Table table)
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.IsTrue(MyAccountObject.CheckIfColumnNamesMatchInCompanyInformationPageInStewardshipNumbersSection(table), "Column names do not match", "Column names match");
		}

		[StepDefinition(@"I check if the Stewardship Numbers table province names match the following province names")]
		public void ThenICheckProvinceNames(Table table)
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.IsTrue(MyAccountObject.CheckProvinceNamesInCompanyInformationPageInStewardshipNumbersSection(table), "Province names do not match", "Province names match");
		}

		[StepDefinition(@"I check if 'Edit' button exists in the Stewardship Numbers section")]
		public void ThenICheckIfButtonExistsInTheStewardshipNumbersSection()
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.IsTrue(MyAccountObject.CheckForEditButtonCheckProvinceNamesInCompanyInformationPageInStewardshipNumbersSection(), "Edit button does exist in the Stewardship Numbers section", "Edit button exists in the Stewardship Numbers section");
		}

		[StepDefinition(@"I add following stewardship information")]
		public void AddStewardshipInformation(Table table)
		{
			try
			{
				GeneralUtilities.ScrollToBottomOfPage();
				var mystwdinfo = new MyAccount_CompanyInfo();
				Report.IsTrue(mystwdinfo.StewardshipEdit_click(), "failed to click edit", "successfully clicked edit");
				GeneralUtilities.Wait_for_load_finish();
				foreach (TableRow row in table.Rows)
				{
					Report.IsTrue(mystwdinfo.EnterStewardshipInfo(row["Province"], row["Stewardship"]), "failed to enter stewardship information", "successfully entered steward information");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I call a Shared Step to create a new password for the account saved as: (.*)")]
		public void ThenICallSharedStepToCreateANewPassword(string accountSavedAs)
		{
			ForgottenPasswordQuestions FP = new ForgottenPasswordQuestions();
			MyAccount MyAccountObject = new MyAccount();		

			TReVorTestUsers currentUser = TestUsers.GetUserSavedAs(accountSavedAs);
			
			string currentPassword = currentUser.Password;
			
			string pattern = @"Welcome(\d+)!";
			Regex rg = new Regex(pattern);
			Match match = rg.Match(currentPassword);
			if(match.Success)
			{
				Report.Info("The Password found in TReVor matched the expected format");
				string intStr = match.Groups[1].Value;
				int passNumber = Convert.ToInt32(intStr);
				if (passNumber<99)
				{
					passNumber++;
				}
				else
				{
					passNumber = 1;
				}
				string updatedPassword = "Welcome" + passNumber.ToString() + "!";
				Context.AddToContext("contextPassword", updatedPassword);
			}
			else
			{
				Report.Info("The password found in TReVor did not match the expected format, setting the new password to use the correct format.");				 
				string newPassword = "Welcome1!";
				Context.AddToContext("contextPassword", newPassword);
				
			}		
			int i = 0;
			bool acceptedPass = false;
			//here is where we loop before clicking close check that the "too recent password" popup is not present, if it is, click close in that popup and try +1 to the number (if number =99 set it to 1)
			while (i<10 && acceptedPass==false)
			{
				var contextPassword = (string)Context.GetFromContext("contextPassword");
				FP.New_Password_Form(contextPassword, contextPassword);
				bool passwordResetInWERCS = Report.IsTrue(MyAccountObject.ClickSaveInChangeUserPasswordWindow(), "Failed to click save", "Successfully clicked save");
				bool popupOpen = false;
				int y = 0;
				while (popupOpen == false && y < 5)
				{
					popupOpen = MyAccountObject.PasswordTooRecentPopupPresent();
					Delay.Seconds(1);
					y++;
				}

				if (!MyAccountObject.PasswordTooRecentPopupPresent())
				{
					Report.Info("There was no popup present with the message 'This password was used too recently.'");
					acceptedPass = true;
					
				}
				else
				{
					Report.Info("There was a popup present with the message 'This password was used too recently.'");
					Report.Info("Attempting to Close the Popup");
					if (MyAccountObject.CloseInPasswordTooRecentPopupPresent())
					{
						MyAccountObject.ClickCloseInPasswordTooRecentPopup();
					}
					bool popupClosed = false;
					int j = 0;
					while (popupClosed == false && j<5)
					{
						if(!MyAccountObject.PasswordTooRecentPopupPresent())
						{
							popupClosed = true;
							Report.Info("The Password Too Recent Popup was closed successfully");
						}
						else
						{
							Report.Info("The Password Too Recent Popup was still showing");
							Delay.Seconds(1);
						}
						j++;
					}
					if(!popupClosed)
					{
						Report.Failure("The Password Too Recent Popup was still showing after 5 seconds");
						return;
					}
					Report.Info("Attempting to add '1' to the Password");
					var basePassword = (string)Context.GetFromContext("contextPassword");
					string passwordNumberStr = basePassword.Replace("Welcome", "").TrimEnd("!");
					int passwordNumberInt = Convert.ToInt32(passwordNumberStr);
					if(passwordNumberInt==99)
					{
						passwordNumberInt = 0;
					}
					int passwordNumberIncreased = passwordNumberInt+1;
					string increasedPasswordFull= "Welcome" + passwordNumberIncreased.ToString() + "!";
					Context.AddToContext("contextPassword", increasedPasswordFull);
					i++;


				}			
				
			}
			if(acceptedPass==false)
			{
				Report.Failure("The Password was still showing as Too recent even after increasing the value 10 times");
				return;
			}
			if (MyAccountObject.CloseInPasswordTooRecentPopupPresent())
			{
				Report.IsTrue(MyAccountObject.ClickCloseInChangeUserPasswordWindow(), "Failed to click close", "Successfully clicked close");
			}

			var finalPassword = (string)Context.GetFromContext("contextPassword");
			if (acceptedPass)
			{
				var user = TReVor.Integrations.Classes.TReVorSettings.GetCredential(accountSavedAs);
				if (user == null)
				{
					Report.Info("TReVor user does not exist");
				}
				else
				{
					Report.Info("TReVor user does exist");
				}

				//if (Report.IsTrue(TReVorSettings.TReVor.CacheFunctions.UpdateTestUserPassword(user.TestUserId, finalPassword), "Not able to update password in TReVor", "Successfully updated password in TReVor"))
				//TReVorSettings.TReVor.CacheFunctions.UpdateTestUserPassword(user.TestUserId, finalPassword);
				string accountUsername = user.UserName;
				TReVor.Integrations.Classes.TReVorSettings.UpdateCredential(user.Alias, accountUsername, finalPassword);
				TReVor.Integrations.Classes.TReVorSettings.Refresh.SoftwareCredentials();
				var foundUser = TReVor.Integrations.Classes.TReVorSettings.GetCredential(user.Alias);
				string userpass = foundUser.Password;
				Report.IsTrue(userpass == finalPassword, "Not able to update password in TReVor", "Successfully updated password in TReVor");
				TReVor.Integrations.Classes.TReVorSettings.Refresh.SoftwareCredentials();
				TReVor.Integrations.Classes.TReVorSettings.Refresh.SoftwareCredentials();


			}
		}

		[StepDefinition(@"I pass the following data to the Stweardship Numbers table")]
		public void ThenPassTableStweardshipNumbersInformation(Table table)
		{
			MyAccount MyAccountObject = new MyAccount();
			MyAccountObject.ClickOnEditButtonInCompanyInformationPageInStewardshipNumbersSection();
			Report.IsTrue(MyAccountObject.FillInStewardshipData(table), "Failed to fill in Stewardship table data", "Successfully filled in Stewardship table data");
		}

		[StepDefinition(@"I save the Stewardship Numbers data")]
		public void ThenISaveTheStewardshipNumbersData()
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.IsTrue(MyAccountObject.ClickSaveButtonForStewardshipNumbers(), "Failed to click save", "Successfully clicked save");
		}

		[StepDefinition(@"I look for the error: (.*) in the row with the province: (.*)")]
		public void GivenICallSharedStepMyAccountStewardshipNumbersDateValidation(string error, string province)
		{

			MyAccount_CompanyInfo MyAccount_CompanyInfoObject = new MyAccount_CompanyInfo();
			Report.IsTrue(MyAccount_CompanyInfoObject.ConfirmErrorInStewardshipInfoTable(error, province), "An error has not been found in the row with Province: " + province + ", and it should've been, Error: " + error, "An error has been found in the row with Province: " + province + ", which is correct, Error: " + error);

		}

		[StepDefinition(@"I search for user with email")]
		public void ThenISearchForUserWithEmailSaved()
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.IsTrue(MyAccountObject.SearchForUserSavedAs(), "Failed to find user with email", "Successfully found user with email");
		}

		[StepDefinition(@"I confirm following error message displayed for confirm email text box: (.*)")]
		public void ThenIConfirmEmailDoesNotMatchError(string errorMessage)
		{
			MyAccount MyAccountObject = new MyAccount();
			if (MyAccountObject.ConfirmEmailError() != null)
			{
				Report.IsTrue(MyAccountObject.ConfirmEmailError().Text == errorMessage, "Failed to verify the confirm email error message", "Successfully found confirm email error message");
			}
			else
			{
				Report.Info("No error message displayed");
			}
		}

		[StepDefinition(@"I clear the name and email address fields text")]
		public void ThenIClearNameAndEmailInput()
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.Info("I clear the Name and Email input text");
			try
			{
				MyAccountObject.ClearNameAndEmailInput();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm following error message displayed for email text box: (.*)")]
		public void ThenIConfirmEmailAlreadyExistsError(string errorMessage)
		{
			MyAccount MyAccountObject = new MyAccount();
			if (MyAccountObject.EmailError() != null)
			{
				Report.IsTrue(MyAccountObject.EmailError().Text == errorMessage, "Failed to verify the email already exists error message", "Successfully found already exists email error message");
			}
			else
			{
				Report.Info("No error message displayed");
			}
		}

		[StepDefinition(@"I confirm following error message displayed for last name input empty text box: (.*)")]
		public void ThenIConfirmLatNameInputEmptyError(string errorMessage)
		{
			MyAccount MyAccountObject = new MyAccount();
			if (MyAccountObject.LastNameEmptyError() != null)
			{
				Report.IsTrue(MyAccountObject.LastNameEmptyError().Text == errorMessage, "Failed to verify the name input empty error message", "Successfully found name input empty error message");
			}
			else
			{
				Report.Info("No error message displayed");
			}
		}

		[StepDefinition(@"I click on Add new User link")]
		public void IClickOnAddNewUserLink()
		{
			var selMyAccount = new MyAccount();
			//Open New User Form
			Delay.Seconds(10);
			Report.IsTrue(selMyAccount.Add_New_User_click(), "Failed to Click Add New User Link",
				"New User Form Link Clicked");
			Delay.Seconds(5);
		}

		[StepDefinition(@"I add following new User information")]
		public void AddUserInformation(Table table)
		{
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.StartStep(Report.Details.StepIndex + " - I enter data with the following information");
				foreach (TableRow thisRow in table.Rows)
				{
					string userName = thisRow["User Name"];
					string title = thisRow["Title"];
					string role = thisRow["Role"];
					string phoneNo = thisRow["Phone Number"];
					string emailAddress = thisRow["Email Address"];
					string confirmEmail = thisRow["Confirm Email"];
					string countryCode = thisRow["Country Code"];
					string country = thisRow["Country"];

					var selMyUserForm = new UserDetails();
					//Check Form Has Opened
					Report.IsTrue(!selMyUserForm.Exists, "Failed to Open Add User Form", "Add User Form Open");					
					selMyUserForm.Add_User_Check(userName, title, role, phoneNo, emailAddress, confirmEmail, country);
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
		[StepDefinition(@"In the dialog I click on Cancel")]
		public void GivenInThePopupErrorIClickOnCancel()
		{
			try
			{
				var selMyAccount = new MyAccount();
				selMyAccount.CancelButtonOnAddUserDialog("Cancel");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I enter new password and confirm password input fields with diff data: (.*) for the account saved as: (.*)")]
		public void ThenIEnterANewAndConfirmPassword(string diffPassword, string accountSavedAs)
		{
			try
			{
				MyAccount MyAccountObject = new MyAccount();
				ForgottenPasswordQuestions FP = new ForgottenPasswordQuestions();
				TReVorTestUsers currentUser = TestUsers.GetUserSavedAs(accountSavedAs);
				string contextPassword = currentUser.Password;
				Report.IsTrue(FP.Enter_New_Password(contextPassword), $"New Password with '{ contextPassword }' not entered");
				Report.IsTrue(FP.Enter_Verify_Password(diffPassword), $"Confirm Password with '{ diffPassword }' entered");
				MyAccountObject.ClickSaveInChangeUserPasswordWindow();
				Delay.Seconds(2);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Confirm mismatch error message displayed: (.*)")]
		public void ThenIConfirmMismatchPasswordErrorMessage(string errMsg)
		{
			try
			{
				MyAccount MyAccountObject = new MyAccount();
				if (MyAccountObject.GetMismatchErrorText() != null)
				{
					Report.IsTrue(MyAccountObject.GetMismatchErrorText() == errMsg, "Expected error message not displayed", $"'{errMsg}' message displayed successfully");
				}
				else
				{
					Report.Info("No error message displayed");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
		[StepDefinition(@"I enter new password for the account saved as: (.*)")]
		public void ThenIEnterANewPassword(string accountSavedAs)
		{
			try
			{
				MyAccount MyAccountObject = new MyAccount();
				ForgottenPasswordQuestions FP = new ForgottenPasswordQuestions();
				TReVorTestUsers currentUser = TestUsers.GetUserSavedAs(accountSavedAs);

				string contextPassword = currentUser.Password;
				Report.IsTrue(FP.Enter_New_Password(contextPassword), $"New Password with '{ contextPassword }' not entered");
				Report.IsTrue(FP.Enter_Verify_Password(contextPassword), $"Confirm Password with '{ contextPassword }' entered");
				MyAccountObject.ClickSaveInChangeUserPasswordWindow();
				Delay.Seconds(5);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Confirm following error message displayed: (.*)")]
		public void ThenIConfirmPasswordErrorMessage(string errMsg)
		{
			try
			{
				MyAccount MyAccountObject = new MyAccount();
				if (MyAccountObject.GetErrorPopupText() != null)
				{					
				Report.IsTrue(MyAccountObject.GetErrorPopupText() == errMsg, "Expected error message not displayed", $"'{errMsg}' message displayed successfully");
			}
			else
				{
					Report.Info("No error message displayed");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
		[StepDefinition(@"I Confirm that I see the field : (.*)")]
		public void ThenInTheOrderHistoryScreenISelect(string value)
		{
			Report.StartStep($" In the Order History screen I confirm { value }");
			try
			{
				var selMyAccount = new MyAccount_OrderHistory();
				Report.IsTrue(selMyAccount.FieldExists(value), $"Failed to find { value}",
					$"Successully found { value }");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I filter with order Number : (.*), (.*)")]
		public void IFilterWithOrderNumber(string orderNum, string action)
		{
			Report.StartStep($" In the Order Number search text box enter { orderNum }");
			try
			{
				var MyAccount = new MyAccount();
				var selMyAccount = new MyAccount_OrderHistory();
				MyAccount.OrderSearchText(orderNum);
				selMyAccount.ClickGivenFilterAction(action);
				GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
		[StepDefinition(@"I Confirm (.*) results are correct: (.*)")]
		public void IConfirmInvoiceOrderNumFilterResult(string action, string value)
		{
			Report.StartStep($" I confirm Order Number filter working as expected ");
			try
			{
				var MyAccount = new MyAccount();
				if (action == "Clear Filter")
				{
					int count = MyAccount.OrderNumberClearFilter();
					Report.IsTrue(count > 1, "Order Number clear Filter not working as expected",
							"Order Number clear Filter working as expected");
				}
				else if (action == "Filter")
				{
					int count = MyAccount.OrderSearchFilterResult();
					Report.IsTrue(count == 1, "Order Number Filter not working as expected",
						"Order Number Filter working as expected");
					Report.IsTrue(MyAccount.OrderNumberData(value), "specified order number does not match",
							"Order Number matched successfully");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
		[StepDefinition(@"I click view details link")]
		public void IClickViewDetailsLink()
		{
			Report.StartStep($" I click the view details link");
			try
			{
				var MyAccount = new MyAccount();
				Report.IsTrue(MyAccount.ClickViewDetailsLink(), "view details link not clickable",
							"view details link clicked successfully");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm (.*) tab is selected by default")]
		public void ThenIConfirmSelectedTabDisplayed(string value)
		{
			Report.StartStep($" I confirm WERCSmart tab displayed by default");
			var selorderAccount = new MyAccount_OrderHistory();
			Report.IsTrue(selorderAccount.TabExists(value), $" {value} is not selected by default", $" {value} selected by default");
		}

		[StepDefinition(@"I confirm following columns displayed")]
		public void ThenIConfirmIfColumnNamesMatch(Table table)
		{
			Report.StartStep($" I confirm following WERCSmart table columns displayed");
			var selorderAccount = new MyAccount_OrderHistory();
			List<string> columnsNotFound = selorderAccount.CheckWercsmartTabColumns(table);

			Report.IsTrue(columnsNotFound.Count == 0, "One or more of the columns were not found", "Successfully found all columns");

			foreach (string columnName in columnsNotFound)
			{
				Report.Info($"Column not found: { columnName}");
			}
		}

		[StepDefinition(@"I filter Product Name (.*) with action: (.*)")]
		public void IFilterWithWPSID(string wpsId, string action)
		{
			Report.StartStep($" In the WPSID search text box enter { wpsId }");
			try
			{
				var MyAccount = new MyAccount();
				var selMyAccount = new MyAccount_OrderHistory();
				MyAccount.ProductSearchText(wpsId);
				selMyAccount.ClickGivenFilterAction(action);
				GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I save Description as: (.*)")]
		public void ISaveDescription(string saveAs)
		{
			try
			{
				var myOderHistoryDetails = new MyAccount_OrderHistory();
				var thisDescription = myOderHistoryDetails.Description;
				Delay.Seconds(1);

				Context.AddToContext(saveAs, thisDescription);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
		[StepDefinition(@"I Confirm Product name or wpsId Filter results (.*) are correct : (.*)")]
		public void IConfirmProductNameFilterResult(string value, string text)
		{
			try
			{
				var description = Context.GetFromContext(value);

				Report.IsTrue(description.Equals(text), "product name Filter not working as expected",
						"product name Filter working as expected");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Confirm Clear Filter returns correct results: (.*)")]
		public void IConfirmProductNameClearFilter(string value)
		{
			try
			{
				var MyAccount = new MyAccount();
				var selorderAccount = new MyAccount_OrderHistory();
				selorderAccount.ClickGivenFilterAction(value);
				int count = MyAccount.OrderNumberClearFilter();
				Report.IsTrue(count > 2, "Product Name clear Filter not working as expected", "Product Name clear Filter working as expected");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I apply filtering with: (.*) Status")]
		public void IApplyFilterResult(string value)
		{
			try
			{
			var selorderAccount = new MyAccount_OrderHistory();
			selorderAccount.ApplyFilterBySearch(value);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm filtered with the completed status")]
		public void IConfirmFilterByDropdownResultWithSelectedStatus()
		{
			try
			{
				var selorderAccount = new MyAccount_OrderHistory();
				string Srcstatus = selorderAccount.FilterBySearchResult();
				Report.IsTrue(Srcstatus.Length > 2, "Product FilterBy search not working as expected", "Product FilterBy search working as expected");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
		[StepDefinition(@"I click on Filter Button")]
		public void IClickFilterButton()
		{
			var selorderAccount = new MyAccount_OrderHistory();
			selorderAccount.FilterButton();
		}
	}
}
