using System;
using System.Collections.Generic;
using System.Linq;
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


		[Given(@"I navigate to the MyAccount page")]
		public void GivenINavigateToTheMyAccountPage()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I navigate to the MyAccount page");
			try
			{
				TopMenuBar thisTopMenuBar = new TopMenuBar();
				thisTopMenuBar.ClickMyAccount();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[Given(@"I save all the users in the User Grid")]
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
				List<User> OriginalGrid = (List<User>)Context.GetFromContext("userGrid");
				List<User> NewGrid = (List<User>)Context.GetFromContext("userGridNew");
				User SavedUser = (User)Context.GetFromContext(savedAs);

				List<User> Matching = OriginalGrid.Where(y => NewGrid.Any(z => z.Username == y.Username)).ToList();



				User InOriginalButNotNew = OriginalGrid.Where(y => !NewGrid.Any(z => z.Username == y.Username)).ToList().FirstOrDefault();
				User InNewButNotOriginal = NewGrid.Where(y => !OriginalGrid.Any(z => z.Username == y.Username)).ToList().FirstOrDefault();

				Report.IsTrue(InOriginalButNotNew.Username == SavedUser.Username,
					"User: " + SavedUser.Username + " has not been replaced. ",
					"As expected, " + SavedUser.Username + " has been replaced");
				Report.IsTrue(InNewButNotOriginal.Username == replacedBy,
					"User has not been replaced by: " + replacedBy,
					"As expected the replacement user is: " + replacedBy);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[Given(@"I go to (.*) in User Grid for the current user")]
		public void GivenIGoToActionInUserGrid(string action)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I go to " + action + " in User Grid");
			try
			{
				Delay.Seconds(1);
				var selMyAccount = new MyAccount();
				var selTopMenuBar = new TopMenuBar();

				//get name of currently signed in
				string Username = selTopMenuBar.GetCurrentUser();

				Report.IsTrue(selMyAccount.ForUserClickAction(Username, action),
					"Failed to click action: " + action + " for user: " + Username,
					"Successfully clicked action: " + action + " for user: " + Username);

				Delay.Seconds(1);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[Given(@"In the UserDetails screen I save the current User as: (.*)")]
		public void GivenInTheUserDetailsScreenISaveTheCurrentUserAs(string saveAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the UserDetails screen I save the current User as: " + saveAs);
			try
			{
				var MyUserDetails = new UserDetails();
				User ThisUser = new User();

				ThisUser.Username = MyUserDetails.Name;
				ThisUser.Title = MyUserDetails.Title;
				ThisUser.Role = MyUserDetails.UserRole;
				ThisUser.Purview = MyUserDetails.Purview;
				ThisUser.Email = MyUserDetails.EmailAddress;
				ThisUser.Country = MyUserDetails.Country;
				ThisUser.CountryCode = MyUserDetails.CountryCode;
				ThisUser.PhoneNumber = MyUserDetails.PhoneNumber;
				ThisUser.SendNotifications = MyUserDetails.SendNotifications;
				Delay.Seconds(1);

				Context.AddToContext(saveAs, ThisUser);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[Given(@"In the UserDetails page I set Name to be: (.*)")]
		public void GivenInTheUserDetailsPageISetNameToBe(string name)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the UserDetails page I set Name to be: " + name);

			try
			{
				var MyUserDetails = new UserDetails();
				Delay.Seconds(3);
				if (name.ToLower().Contains("saved as"))
				{
					name = ((User)Context.GetFromContext(name.Replace("saved as", "", StringComparison.OrdinalIgnoreCase)))
						.Username;
				}
				Report.Info("Inputting name: " + name);
				MyUserDetails.Name = name;
				Report.IsTrue(MyUserDetails.Name == name, "Failed to set user details name to: " + name,
					"Successfully set name to be: " + name);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[Given(@"In the UserDetails page I click (.*)")]
		public void GivenInTheUserDetailsPageIClick(string buttonToClickText)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the UserDetails page I click " + buttonToClickText);
			try
			{
				var MyUserDetails = new UserDetails();
				Report.IsTrue(MyUserDetails.ClickButton(buttonToClickText), "Failed to click " + buttonToClickText, "Successfully clicked " + buttonToClickText);

				if (buttonToClickText.ToLower() == "save")
				{
					MyUserDetails.ClickButtonOnAddUserDialog("close");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[Given(@"I click Save in My Account")]
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
				foreach (var ThisRow in table.Rows)
				{
					string user_name = ThisRow["User Name"];
					string title = ThisRow["Title"];
					string role = ThisRow["Role"];
					string phone_no = ThisRow["Phone Number"];
					string email_address = ThisRow["Email Address"];
					string confirm_email = ThisRow["Confirm Email"];
					string country_code = ThisRow["Country Code"];
					string country = ThisRow["Country"];

					if (user_name == "User")
					{
						user_name = user_name + "_" + System.DateTime.Now.ToString("HHmmddMMyy");

						ScenarioContext.Current.Add("CurrentUser", user_name);

						Report.Info("User Name = " + user_name);
					}

					if (email_address == "Saved")
					{
						if (ScenarioContext.Current.ContainsKey("CurrentEmail"))
						{
							email_address = ScenarioContext.Current["CurrentEmail"].ToString();
						}
						Report.Info("Email Address = " + email_address);
					}

					if (confirm_email == "Saved")
					{
						if (ScenarioContext.Current.ContainsKey("CurrentEmail"))
						{
							confirm_email = ScenarioContext.Current["CurrentEmail"].ToString();
						}
						Report.Info("Email Address = " + confirm_email);
					}

					if (country_code == "empty")
					{
						country_code = "";
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
					Report.IsTrue(selMyUserForm.Add_New_User(user_name, title, role, phone_no, email_address, confirm_email, country),
						"Failed to Add a New User", "New User Added");

					Delay.Seconds(5 * Delay.SpeedFactor);
					//Check User Has Been Created
					Report.IsTrue(selMyAccount.User_Added_Check(user_name, email_address, role), "User Has Not Been Created",
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

				string user_name = string.Empty;

				if (ScenarioContext.Current.ContainsKey("CurrentUser"))
				{
					user_name = ScenarioContext.Current["CurrentUser"].ToString();
				}

				Report.IsTrue(selMyAccount.Is_User_Active(user_name, active), "User is NOT " + active, "User is " + active);

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}




	}
}
