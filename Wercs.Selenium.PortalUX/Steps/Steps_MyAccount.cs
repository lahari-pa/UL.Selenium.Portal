using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TestStack.White.UIItems.WindowItems;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
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
				TopMenuBar thisTopMenuBar = new TopMenuBar();
				string username = user.FirstName + ", " + user.LastName;
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

		[Then(@"I should see user name: (.*) in the header next to the user icon")]
		public void ThenIShouldSeeUserNameInTheHeaderNextToTheUserIcon(string username)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see username: " + username + " in the top right corner");
			try
			{
				TopMenuBar thisTopMenuBar = new TopMenuBar();
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

		[StepDefinition(@"I should see username: (.*) in the right corner")]
		public void ThenIShouldSeeUsernameInTheRightCorner(string username)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I should see username: " + username + " in the top right corner");
			try
			{
				TopMenuBar thisTopMenuBar = new TopMenuBar();
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
				MyAccount myMyAccount = new MyAccount();
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


		[StepDefinition(@"I navigate to the MyAccount page")]
		public void GivenINavigateToTheMyAccountPage()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I navigate to the MyAccount page");
			try
			{
				Report.Info("Navigating to the My Account page");
				TopMenuBar thisTopMenuBar = new TopMenuBar();
				thisTopMenuBar.ClickMyAccount();
				Report.IsTrue(new MyAccount().Wait_for_load(),
					"The My Account page did not load",
					"The My Account page was loaded");
				GeneralUtilities.Wait_for_load_finish();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
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
				List<User> originalGrid = (List<User>)Context.GetFromContext("userGrid");
				List<User> newGrid = (List<User>)Context.GetFromContext("userGridNew");
				User savedUser = (User)Context.GetFromContext(savedAs);

				List<User> matching = originalGrid.Where(y => newGrid.Any(z => z.Username == y.Username)).ToList();



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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I go to " + action + " in User Grid");
			try
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
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the UserDetails screen I save the current User as: (.*)")]
		public void GivenInTheUserDetailsScreenISaveTheCurrentUserAs(string saveAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the UserDetails screen I save the current User as: " + saveAs);
			try
			{
				var myUserDetails = new UserDetails();
				User thisUser = new User();

				thisUser.Username = myUserDetails.Name;
				thisUser.Title = myUserDetails.Title;
				thisUser.Role = myUserDetails.UserRole;
				thisUser.Purview = myUserDetails.Purview;
				thisUser.Email = myUserDetails.EmailAddress;
				thisUser.Country = myUserDetails.Country;
				thisUser.CountryCode = myUserDetails.CountryCode;
				thisUser.PhoneNumber = myUserDetails.PhoneNumber;
				thisUser.SendNotifications = myUserDetails.SendNotifications;
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
					name = ((User)Context.GetFromContext(name.Replace("saved as", "", StringComparison.OrdinalIgnoreCase)))
						.Username;
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

				if (buttonToClickText.ToLower() == "save")
				{
					myUserDetails.ClickButtonOnAddUserDialog("close");
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
				var headingShowing = selMyAccount.HeaderShowing();
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
				var subheadingsShowing = selMyAccount.Subheadings();
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
				foreach (var thisRow in table.Rows)
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

						ScenarioContext.Current.Add("CurrentUser", userName);

						Report.Info("User Name = " + userName);
					}

					if (emailAddress == "Saved")
					{
						if (ScenarioContext.Current.ContainsKey("CurrentEmail"))
						{
							emailAddress = ScenarioContext.Current["CurrentEmail"].ToString();
						}
						Report.Info("Email Address = " + emailAddress);
					}

					if (confirmEmail == "Saved")
					{
						if (ScenarioContext.Current.ContainsKey("CurrentEmail"))
						{
							confirmEmail = ScenarioContext.Current["CurrentEmail"].ToString();
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

					Delay.Seconds(5 * Delay.SpeedFactor);
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

				if (ScenarioContext.Current.ContainsKey("CurrentUser"))
				{
					userName = ScenarioContext.Current["CurrentUser"].ToString();
				}

				Report.IsTrue(selMyAccount.Is_User_Active(userName, active), "User is NOT " + active, "User is " + active);

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

				foreach (var thisRow in table.Rows)
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
					if (FeatureContext.Current.ContainsKey("CurrentAccount"))
					{
						savedAs = FeatureContext.Current["CurrentAccount"].ToString();
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
			var showing = new MyAccount_CompanyInfo().ReturnUserOrDivisionAccountsNumber(type);
			Report.IsTrue(showing.Trim() == number, "Found: " + showing + " " + type + " accounts, when " + number + " were expected!", "Successfully found: " + number + " " + type + " accounts!");

		}

		[StepDefinition(@"In Your Company User Accounts the user (.*) is associated with the administrator email address")]
		public void UserIsAssociatedAdminEmail(string user)
		{
			List<User> listOfUsers = (List<User>)Context.GetFromContext("userGrid");
			var userMatch = listOfUsers.FirstOrDefault(x => x.Username == user);
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
			var adminEmail = GlobalParameters.Admin1;
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
			var activePage = selMyAccount.UserAccountsActivePage();
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
				foreach (var thisRow in table.Rows)
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
						if (ScenarioContext.Current.ContainsKey("CurrentEmail"))
						{
							emailAddress = ScenarioContext.Current["CurrentEmail"].ToString();
						}
						Report.Info("Email Address = " + emailAddress);
					}

					if (confirmEmail == "Saved")
					{
						if (ScenarioContext.Current.ContainsKey("CurrentEmail"))
						{
							confirmEmail = ScenarioContext.Current["CurrentEmail"].ToString();
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
			var pageNavigationValue = Context.GetFromContext("Page Navigation Value") == null
				? selMyAccount.CurrentPageUserGridNavPageInput()
				: Context.GetFromContext("Page Navigation Value").ToString();

			TestReport.StartStep(GlobalParameters.StepCount + " - I enter the " + direction + " arrow into the page navigation box");
			Report.Info("Entering the " + direction + " arrow key to the user grid page navigation input");
			selMyAccount.KeyToUserGridNavPageInput(direction);
			Report.Info("Pressing the enter key");
			selMyAccount.KeyToUserGridNavPageInput("enter");
			var iteration = direction == "up" ? "increased" : "decreased";
			GlobalParameters.StepCount++;
			TestReport.StartStep(GlobalParameters.StepCount + " - I confirm the page number has " + iteration + " by 1");
			var currentPage = Convert.ToInt32(selMyAccount.UserAccountsActivePage());
			int difference = direction == "up" ? 1 : -1;
			Report.IsTrue(currentPage == Convert.ToInt32(pageNavigationValue) + difference,
				string.Format("The active page did not {0} by 1 after entering the '{1}' arrow into the page navigation box at position '{2}'",
					iteration.Remove(iteration.Length - 1), direction, pageNavigationValue),
				string.Format("The active page correctly {0} by 1 after entering the '{1}' arrow into the page navigation box at position '{2}'",
					iteration, direction, pageNavigationValue));
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
			var tabsDisplayed = selMyLibrary.AllTabs();
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
			var activeTab = selMyLibrary.ActiveTab();
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

			foreach (var thisRow in myTable.Rows)
			{
				string companyName = thisRow["Company Name"];
				Report.Info("Company Name = '" + companyName + "'");
				string adminName = thisRow["Admin Name"];
				Report.Info("Admin Name = '" + adminName + "'");
				string emailAddress = thisRow["Email Address"];
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

	}
}
