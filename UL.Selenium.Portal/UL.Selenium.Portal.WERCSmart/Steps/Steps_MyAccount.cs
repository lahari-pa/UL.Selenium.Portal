using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.UniversalFunctions;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.Cache;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using NTTQA.Selenium.TReVor;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "MyAccount")]
	class StepsMyAccount
	{
		[StepDefinition(@"I should see username for user saved as: (.*) in the right corner")]
		public void ThenIShouldSeeUsernameForUserSavedAsInTheRightCorner(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see username: " + savedAs + " in the top right corner");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see username: " + username + " in the top right corner");
			try
			{
				if (username.ToLower().Contains("saved as"))
				{
					var savedUser = (User)Context
						.GetFromContext(username.Replace("saved as", "", StringComparison.OrdinalIgnoreCase).Trim());
					username = savedUser.Username;
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see username: " + username + " in the top right corner");
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

		[Then(@"I should see company username: (.*)")]
		public void ThenIShouldSeeCompanyUsername(string companyName)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see company username: " + companyName);
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I save all the users in the User Grid");
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

		[Then(@"In the User Grid the user saved as: (.*) has been replaced by: (.*)")]
		public void ThenInTheUserGridTheSavedUserNameHasBeenReplacedBy(string savedAs, string replacedBy)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the User Grid the saved user name (" + savedAs + ") has been replaced by: " + replacedBy);
			try
			{
				Delay.Seconds(20);
				var selMyAccount = new MyAccount();
				Report.IsTrue(selMyAccount.SaveUserGrid("userGridNew"), "Failed to save users in the user Grid", "Successfully saved users in the User grid");
				Delay.Seconds(2);
				var originalGrid = (List<User>)Context.GetFromContext("userGrid");
				var newGrid = (List<User>)Context.GetFromContext("userGridNew");
				var savedUser = (User)Context.GetFromContext(savedAs);

				var matching = originalGrid.Where(y => newGrid.Any(z => z.Username == y.Username)).ToList();



				User inOriginalButNotNew = originalGrid.Where(y => !newGrid.Any(z => z.Username == y.Username)).ToList().FirstOrDefault();
				User inNewButNotOriginal = newGrid.Where(y => !originalGrid.Any(z => z.Username == y.Username)).ToList().FirstOrDefault();

				Report.IsTrue(inOriginalButNotNew.Username == savedUser.Username,
					"User: " + savedUser.Username + " has not been replaced. ",
					"As expected, " + savedUser.Username + " has been replaced");
				Report.IsTrue(inNewButNotOriginal.Username == replacedBy,
					"User has not been replaced by: " + replacedBy,
					"As expected the replacement user is: " + replacedBy);
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
			Report.IsTrue(selMyAccount.ForUserClickAction(username, action),
				"Failed to click action: " + action + " for user: " + username,
				"Successfully clicked action: " + action + " for user: " + username);
			Delay.Seconds(1);
		}

		[StepDefinition(@"In the UserDetails screen I save the current User as: (.*)")]
		public void GivenInTheUserDetailsScreenISaveTheCurrentUserAs(string saveAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the UserDetails screen I save the current User as: " + saveAs);
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the UserDetails page I set Name to be: " + name);

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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the UserDetails page I click " + buttonToClickText);
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click Save in My Account");


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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see the heading " + headingExpected);
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see the heading " + subheadingExpected);
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I add a new user with the following information");
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

						Context.ScenarioContext.Add("CurrentUser", userName);

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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the new user is " + active);
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I select the ... from the Actions column");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click Approve");
			try
			{
				var modal = new ModalDialog();

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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click Close");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click on NEW SUBSCRIPTION");
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

		[StepDefinition(@"In the My Account screen I navigate to the (Company Information|Subscription Information|Payment Methods|Order History|My Library) page")]
		[StepDefinition(@"In the My Account page I navigate to the (Company Information|Subscription Information|Payment Methods|Order History|My Library) page")]
		public void ThenInTheMyAccountScreenINavigateToTheXPage(string nav_option)
		{
			var selMyAccount = new MyAccount();
			Report.IsTrue(selMyAccount.Accounts_Navigation(nav_option), "Failed to Navigate to " + nav_option,
				"Successully Navigated to " + nav_option);
		}

		[StepDefinition(@"In the Subscription Information screen I confirm the Status has the correct information: (.*) Formulated, (.*) Articles, (.*) Enhanced Articles")]
		public void ThenInTheSubscriptionInformationScreenIConfirmTheStatusHasTheCorrectInformationFormulatedArticlesEnhancedArticles(string form_no, string art_no, string en_art_no)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Subscription Information screen I confirm the Status has the correct information: " + form_no + " Formulated, " + art_no + " Articles, " + en_art_no + " Enhanced Articles");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Subscription Information screen I confirm the Subscription History table has the correct information");
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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Order History screen I select  " + radio_option);
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

		[StepDefinition(@"In the Order History screen I get the Invoice Number and Date and confirm the invoice email has arrived for user saved as: (.*)")]
		public void ThenInTheOrderHistoryScreenIGetTheInvoiceNumberAndDateAndConfirmTheInvoiceEmailHasArrivedForUserSavedAs(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Order History screen I get the Invoice Number and Date and confirm the invoice email has arrived for user saved as: " + savedAs);
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
			var listOfUsers = (List<User>)Context.GetFromContext("userGrid");
			User userMatch = listOfUsers.FirstOrDefault(x => x.Username == user);
			Report.IsFalse(userMatch == null,
				"The user: " + user + " was not found in the My Account user grid",
				"The user: " + user + " was found in the My Account user grid");
			if (userMatch == null)
			{
				Report.Failure("The user: " + user + " was not found in the My Account user grid");
				Report.Screenshot();
				return;
			}
			Report.Success("The user: " + user + " was found in the My Account user grid");
			Report.Screenshot();
			string adminEmail = new MyAccount().GetAdminEmail();

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
				string myEmail = EmailFunctions.CreateEmail(myDate);
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

			TestReport.StartStep(GlobalParameters.StepCount + " - I enter the " + direction + " arrow into the page navigation box");
			Report.Info("Entering the " + direction + " arrow key to the user grid page navigation input");
			selMyAccount.KeyToUserGridNavPageInput(direction);
			Report.Info("Pressing the enter key");
			selMyAccount.KeyToUserGridNavPageInput("enter");
			string iteration = direction == "up" ? "increased" : "decreased";
			GlobalParameters.StepCount++;
			TestReport.StartStep(GlobalParameters.StepCount + " - I confirm the page number has " + iteration + " by 1");
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
			tabs.Rows.ForEach(x => tabsExpected.Add(x["Tab"]));
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


		[StepDefinition(@"I update the password for TReVor test user: (.*) in the change user password popup")]
		public void IUpdateThePasswordForTrevorTestUser(string savedAs)
		{
			// Get user credentials from TReVor based on saved as ID
			TestUser user = TestUsers.GetUserSavedAs(savedAs);
			if (user == null)
			{
				Report.Failure("Unable to find TReVor test user saved as: " + savedAs);
				return;
			}

			string oldPassword = user.Password;
			string newPassword = "";
			// If the current password ends in a character, append with a 1 for the new password
			if (!char.IsDigit(oldPassword.Last()))
			{
				newPassword = oldPassword + "1";
			}
			else
			{
				char[] passwordChr = oldPassword.ToCharArray();
				string result = string.Join("", passwordChr.Select(x => char.IsDigit(x) ? x.ToString() : "|")).Split('|').LastOrDefault().Trim();
				newPassword = oldPassword.TrimEnd(result) + (Convert.ToInt32(result) + 1);
			}
			var selModal = new ModalDialog();
			if (!Report.IsTrue(selModal.Wait_for_load(), "Expected a modal dialog to load!", "Modal dialog loaded as expected"))
			{
				return;
			}

			// If the password has expired, the old password is required. Else it isn't.
			if (selModal.LoginPasswordFieldPresent())
			{
				Report.Info("Entering current password in the input: " + oldPassword);
				selModal.EnterLoginPassword(oldPassword);
			}

			GeneralUtilities.Wait_for_load_finish();
			int attempt = 0;
			while (attempt < 10)
			{
				Report.Info("Entering new password in New Password input: " + newPassword);
				selModal.EnterNewPassword(newPassword);
				Report.Info("Entering new password in Verify Password input: " + newPassword);
				selModal.EnterVerifyPassword(newPassword);
				Report.Info("Clicking save in the Change Password popup");
				Report.IsTrue(selModal.ClickSave(),
					"Failed to click save in Change Password",
					"Successfully clicked save in Change Password");
				GeneralUtilities.Wait_for_load_finish();
				if (selModal.GetAllText().Any(x => x.Contains("used too recently")))
				{
					Report.Info("The test attempted to assign a previously used password! Iterating the password suffix...");
					Report.Info($"Current attempted password is: {newPassword}");
					char[] passwordChr = newPassword.ToCharArray();
					string result = string.Join("", passwordChr.Select(x => char.IsDigit(x) ? x.ToString() : "|")).Split('|').LastOrDefault().Trim();
					newPassword = newPassword.TrimEnd(result) + (Convert.ToInt32(result) + 1);
					Report.Info($"New attempted password is: {newPassword}");
					if (selModal.Click_Close())
					{
						Report.Info($"Attempt {attempt}. Trying again...");
						attempt++;
						continue;
					}
					throw new Exception("Failed to close the secondary password modal!");
				}
				Report.Info("Clicking close in the Change Password popup");
				Report.IsTrue(selModal.Click_Close(),
					"Failed to click close in Change Password",
					"Successfully clicked clse in Change Password");
				GeneralUtilities.Wait_for_load_finish();
				if (selModal.Wait_for_close())
				{
					Report.Info("Updating the password in TReVor Test Users");
					Api.UpdateTestUserPassword(savedAs, newPassword);
					return;
				}
				throw new Exception("Modal dialog did not close!");
			}
			Report.Failure("Failed after 10 attempts to change the password!");
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


		[StepDefinition(@"In Stewardship table I select the following options: (.*)  and (.*) for the (.*) field")]
		public void StewardshipInformation(string field, string options1, string options2, string option3)
		{
			GeneralUtilities.ScrollToBottomOfPage();
			var mystwdinfo = new MyAccount_CompanyInfo();
			Report.IsTrue(mystwdinfo.StewardshipEdit_click(), "failed to click edit", "successfully clicked edit");
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(mystwdinfo.EnterStewardshipInfo(field, options1, options2, option3), "failed to enter stewardship information", "successfully entered steward information");
			Report.IsTrue(mystwdinfo.StewardshipSave_click(), "failed to click save", "successfully clicked save");
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
	}
}
