using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using System;
using TechTalk.SpecFlow;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Steps;
using UL.Automation.Selenium.Classes;
using UL.Automation.Reporting.Classes;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.TReVor.Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Studio_SecurityManager")]
	public class Steps_SecurityManager
	{
		[StepDefinition(@"I select '(.*)' from the Security Manager drop down")]
		public void WhenISelectFromTheSecurityManagerDropDown(string option)
		{
			SecurityManager SM = new SecurityManager();
			Report.IsTrue(SM.SelectObjectDropDown(option), $"Failed to select {option} from the drop down menu", $"Successfully selected {option} from the drop down menu");
		}

		[StepDefinition(@"I select module '(.*)' under '(.*)'")]
		public void ThenISelectModuleUnder(string item, string columnName)
		{
			GeneralUtilities.SwitchToFrame("<1>");
			SecurityManager_Modules SM_M = new SecurityManager_Modules();
			Report.IsTrue(SM_M.ClickItemUnderHeader(item, columnName), $"Failed to click {item} in column {columnName}", $"Successfully clicked {item} in column {columnName}");
			GeneralUtilities.ExitIFrame();
		}
		[StepDefinition(@"I click to edit the selected module")]
		public void ThenIClickToEditTheSelectedModule()
		{
			GeneralUtilities.SwitchToFrame("<1>");
			SecurityManager_Modules SM_M = new SecurityManager_Modules();
			Report.IsTrue(SM_M.ClickEditBtn(), "Failed to click the edit button", "Successfully clicked the edit button");
			GeneralUtilities.ExitIFrame();
		}

		[StepDefinition(@"in the '(.*)' window, I select role '(.*)' under '(.*)'")]
		public void WhenInTheWindowISelectUnder(string windowName, string role, string column)
		{
			SecurityManager_SetAccessWindow SM_SAW = new SecurityManager_SetAccessWindow();
			Report.IsTrue(SM_SAW.SelectItemUnderHeader(role, column), $"Failed to select item {role} under column {column}", $"Successfully selected item {role} under column {column}");
		}

		[StepDefinition(@"in the '(.*)' window, I set the access level to '(.*)'")]
		public void WhenInTheWindowISetTheAccessLevelTo(string windowName, string accessLevel)
		{
			SecurityManager_SetAccessWindow SM_SAW = new SecurityManager_SetAccessWindow();
			Report.IsTrue(SM_SAW.SelectAccessLevel(accessLevel), $"Failed to select the access level '{accessLevel}'", $"Successfully selected the access level '{accessLevel}'");
		}
		[StepDefinition(@"in the '(.*)' window, I click to set the access level")]
		public void ThenInTheWindowIClickToSetTheAccessLevel(string windowName)
		{
			SecurityManager_SetAccessWindow SM_SAW = new SecurityManager_SetAccessWindow();
			Report.IsTrue(SM_SAW.ClickToSetAccessLevel(), "Failed to click the Change Multiple button.", "Successfully clicked the Change Multiple button.", showSuccessScreenshot: false);
		}	

		

		[StepDefinition(@"I select screen '(.*)' under '(.*)'")]
		public void ThenISelectScreenUnder(string item, string columnName)
		{
			GeneralUtilities.SwitchToFrame("<1>");
			SecurityManager_Screens SM_S = new SecurityManager_Screens();
			Report.IsTrue(SM_S.ClickItemUnderHeader(item, columnName), $"Failed to click {item} in column {columnName}", $"Successfully clicked {item} in column {columnName}");
			GeneralUtilities.ExitIFrame();
		}
		[StepDefinition(@"I click to open the screen filter builder")]
		public void WhenIClickToOpenTheScreenFilterBuilder()
		{
			GeneralUtilities.SwitchToFrame("<1>");
			SecurityManager_Screens SM_S = new SecurityManager_Screens();
			Report.IsTrue(SM_S.ClickFilterIcon(), "Failed to click the filter icon.", "Successfully clicked the filter icon.");
			GeneralUtilities.ExitIFrame();
		}
		[StepDefinition(@"I filter for the screens '(.*)' that '(.*)' '(.*)'")]
		public void ThenIFilterForTheScreensThat(string filterName, string filterType, string filterText)
		{
			GeneralUtilities.SwitchToFrame("<1>");
			SecurityManager_Screens SM_S = new SecurityManager_Screens();
			Report.IsTrue(SM_S.SelectFilterTypeDropDown(filterName, filterType), $"Failed to select filter type {filterType}", "Successfully selected filter type");
			Report.IsTrue(SM_S.EnterFilterText(filterName, filterText), $"Failed enter search text {filterText}", "Successfully entered search text");
			GeneralUtilities.ExitIFrame();
		}

		[StepDefinition(@"I click to apply the screens filter")]
		public void ThenIClickToApplyTheScreensFilter()
		{
			GeneralUtilities.SwitchToFrame("<1>");
			SecurityManager_Screens SM_S = new SecurityManager_Screens();
			Report.IsTrue(SM_S.ClickApplyBtn(), "Failed to click the apply button.", "Successfully clicked the apply button.");
			GeneralUtilities.ExitIFrame();
		}
		[StepDefinition(@"I click to edit the selected screen")]
		public void ThenIClickToEditTheSelectedScreen()
		{
			GeneralUtilities.SwitchToFrame("<1>");
			SecurityManager_Screens SM_S = new SecurityManager_Screens();
			Report.IsTrue(SM_S.ClickEditBtn(), "Failed to click the edit button.", "Successfully clicked the edit button.");
			GeneralUtilities.ExitIFrame();
		}		

		[StepDefinition(@"I apply the following Screen security settings to '(.*)'")]
		public void ThenIApplyTheFollowingSecuritySettings(string role, Table table)
		{
			ReportDetails.CurrentDetails.UseSubSteps = true;
			string filterName = table.Rows[0]["FilterName"], filterType = table.Rows[0]["FilterType"], filterText = table.Rows[0]["FilterText"], objectName = table.Rows[0]["ObjectName"], windowName = table.Rows[0]["WindowName"], accessLevel = table.Rows[0]["AccessLevel"];
			GlobalSteps GS = new GlobalSteps();

			Report.StartSubStep($"When I select 'Screens' from the Security Manager drop down");
			WhenISelectFromTheSecurityManagerDropDown("Screens");

			Report.StartSubStep($"When I click to open the screen filter builder");
			WhenIClickToOpenTheScreenFilterBuilder();

			Report.StartSubStep($"Then I filter for the screens '{filterName}' that '{filterType}' '{filterText}'");
			ThenIFilterForTheScreensThat(filterName, filterType, filterText);

			Report.StartSubStep($"Then I click to apply the screens filter");
			ThenIClickToApplyTheScreensFilter();

			Report.StartSubStep($"Then I select screen '{objectName}' under 'Object Name'");
			ThenISelectScreenUnder(objectName, "Object Name");

			Report.StartSubStep($"Then I click to edit the selected screen");
			ThenIClickToEditTheSelectedScreen();

			Report.StartSubStep($"Then the '{windowName}' window should load");
			GS.ThenTheWindowShouldLoad(windowName, "should");

			Report.StartSubStep($"Given I switch to the '{windowName}' window");
			GS.GivenISwitchToTheWindow(windowName);

			Report.StartSubStep($"When in the '{windowName}' window, I select role 'Security Testing' under 'Role Name'");
			WhenInTheWindowISelectUnder(windowName, role, "Role Name");

			Report.StartSubStep($"And in the '{windowName}' window, I set the access level to 'Full access'");
			WhenInTheWindowISetTheAccessLevelTo(windowName, accessLevel);

			Report.StartSubStep($"Then in the '{windowName}' window, I click to set the access level");
			ThenInTheWindowIClickToSetTheAccessLevel(windowName);

			Report.StartSubStep($"Given I switch to the 'UL Wercs Studio' window");
			GS.GivenISwitchToTheWindow("UL Wercs Studio");

			Report.StartSubStep("Then I switch to the 'Security Manager' tab");
			GS.WhenISwitchToTheTab("Security Manager");
		}

		[StepDefinition(@"In Security Manager, I click the '(.*)' button")]
		public void WhenInSecurityManagerIClickTheButton(string buttonName)
		{
			SecurityManager SM = new SecurityManager();
			Report.IsTrue(SM.ClickButton(buttonName), $"Failed to click the button {buttonName}", $"Successfully clicked the button {buttonName}");
		}

		[StepDefinition(@"Under '(.*)' I search for the username stored in '(.*)'")]
		public void WhenISearchForTheUserNameForTheStoredUserSCREENSECURITY(string searchType, string savedAs)
		{
			SecurityManager_UsersAndRoles SM_UAR = new SecurityManager_UsersAndRoles();
			//bool credentialsFound = TReVorSettings.SoftwareCredentials.TryGetValue(savedAs, out var credentials);

			TReVorTestUsers trevuser = TestUsers.GetUserSavedAs(savedAs);
			bool credentialsFound = trevuser != null;

			if (credentialsFound)
			{
				Report.IsTrue(SM_UAR.UserNameSearch(searchType, trevuser.Username), $"Failed to enter the username", $"Successfully entered the username");
				Delay.Seconds(5);
			}
			else
			{
				Report.Error($"Could not find the Credentials for {savedAs}");
				Report.EndScenario();
			}
		}

		[StepDefinition(@"Under '(.*)' I right click the username stored in '(.*)'")]
		public void ThenUnderIRightClickTheUsernameStoredIn(string searchType, string savedAs)
		{
			SecurityManager_UsersAndRoles SM_UAR = new SecurityManager_UsersAndRoles();
			//bool credentialsFound = TReVorSettings.SoftwareCredentials.TryGetValue(savedAs, out var credentials);

			TReVorTestUsers trevuser = TestUsers.GetUserSavedAs(savedAs);
			bool credentialsFound = trevuser != null;
			if (credentialsFound)
			{
				Report.IsTrue(SM_UAR.RightClickUserName(searchType, trevuser.Username), $"Failed to right click the username", $"Successfully right cliked the username");
			}
			else
			{
				Report.Error($"Could not find the Credentials for {savedAs}");
				Report.EndScenario();
			}
		}
		[StepDefinition(@"Under '(.*)' I double click the username stored in '(.*)'")]
		public void ThenUnderIDoubleClickTheUsernameStoredIn(string searchType, string savedAs)
		{
			SecurityManager_UsersAndRoles SM_UAR = new SecurityManager_UsersAndRoles();
			//bool credentialsFound = TReVorSettings.SoftwareCredentials.TryGetValue(savedAs, out var credentials);

			TReVorTestUsers trevuser = TestUsers.GetUserSavedAs(savedAs);
			bool credentialsFound = trevuser != null;
			if (credentialsFound)
			{
				Report.IsTrue(SM_UAR.DoubleClickUserName(searchType, trevuser.Username), $"Failed to click the username", $"Successfully clicked the username");
			}
			else
			{
				Report.Error($"Could not find the Credentials for {savedAs}");
				Report.EndScenario();
			}
		}
		[StepDefinition(@"Under '(.*)' I click the username stored in '(.*)'")]
		public void ThenUnderIClickTheUsernameStoredIn(string searchType, string savedAs)
		{
			SecurityManager_UsersAndRoles SM_UAR = new SecurityManager_UsersAndRoles();
			//bool credentialsFound = TReVorSettings.SoftwareCredentials.TryGetValue(savedAs, out var credentials);

			TReVorTestUsers trevuser = TestUsers.GetUserSavedAs(savedAs);
			bool credentialsFound = trevuser != null;
			if (credentialsFound)
			{
				Report.IsTrue(SM_UAR.ClickUserName(searchType, trevuser.Username), $"Failed to click the username", $"Successfully clicked the username");
			}
			else
			{
				Report.Error($"Could not find the Credentials for {savedAs}");
				Report.EndScenario();
			}
		}

		[StepDefinition(@"in the '(Users and Roles)' window, the '(Add Row|Edit Row|Delete Row)' Button (is|is not) available")]
		public void ThenInTheWindowTheButtonIsNotAvailable(string windowName, string buttonName, string isOrIsNot)
		{
			SecurityManager_UsersAndRoles SM_UAR = new SecurityManager_UsersAndRoles();
			if (isOrIsNot == "is")
			{
				Report.IsTrue(SM_UAR.ButtonIsAvialable(buttonName), $"Failed, could not find the button {buttonName}", $"Success, found the button {buttonName}");
			}
			else
			{
				Report.IsFalse(SM_UAR.ButtonIsAvialable(buttonName), $"Failed, found the button {buttonName}", $"Success, could not find the button {buttonName}");
			}

		}
		[StepDefinition(@"in the '(Users and Roles)' window, I click the '(Add Row|Edit Row|Delete Row)' Button ")]
		public void ThenInTheWindowIClickTheAddEditDeleteButton(string windowName, string buttonName)
		{
			SecurityManager_UsersAndRoles SM_UAR = new SecurityManager_UsersAndRoles();
			Report.IsTrue(SM_UAR.ClickButton(buttonName), $"Failed, could not click the button {buttonName}", $"Success, clicked the button {buttonName}");

		}

		[StepDefinition(@"in the '(Edit)' window, I click the '(Change password)' button")]
		public void WhenInTheWindowIClickTheButton(string windowName, string buttonName)
		{
			SecurityManager_EditUser SM_EU = new SecurityManager_EditUser();
			Report.IsTrue(SM_EU.ClickChangePass(), $"Could not click the {buttonName} button", $"Successfully clicked the {buttonName} button.");
		}
		[StepDefinition(@"The password reset page displays the username saved as '(.*)'")]
		public void GivenThePasswordResetPageDisplaysTheUsernameSavedAs(string savedAs)
		{
			SecurityManager_ResetYourPassword SM_RYP = new SecurityManager_ResetYourPassword();
			//bool credentialsFound = TReVorSettings.SoftwareCredentials.TryGetValue(savedAs, out var credentials);

			TReVorTestUsers trevuser = TestUsers.GetUserSavedAs(savedAs);
			bool credentialsFound = trevuser != null;
			if (credentialsFound)
			{
				Report.IsTrue(SM_RYP.VerifyUserName(trevuser.Username), $"Failed find the username {trevuser.Username} on the page", $"Successfully found the username {trevuser.Username} on the page");
			}
			else
			{
				Report.Error($"Could not find the Credentials for {savedAs}");
				Report.EndScenario();
			}
		}
		[StepDefinition(@"In the '(Users and Roles)' window, I click the '(All Roles)' button")]
		public void ThenInTheWindowIClickTheButton(string windowName, string buttonName)
		{
			SecurityManager_UsersAndRoles SM_UAR = new SecurityManager_UsersAndRoles();
			Report.IsTrue(SM_UAR.ClickAllRolesBtn(buttonName), $"Failed to click the '{buttonName}' button", $"Successfully clicked the '{buttonName}' button");
		}
		[StepDefinition(@"in the '(Roles)' window, the '(Add new role|Edit selected|Delete selected)' button (is|is not) available")]
		public void ThenInTheRolesWindowTheButtonIsNotAvailable(string windowName, string buttonName, string isOrIsNot)
		{
			SecurityManager_Roles SM_R = new SecurityManager_Roles();
			if (isOrIsNot == "is")
			{
				Report.IsTrue(SM_R.ButtonAvilable(buttonName), $"Failed, could not find the '{buttonName}' button", $"Success, could find the '{buttonName}' button");
			}
			else
			{
				Report.IsFalse(SM_R.ButtonAvilable(buttonName), $"Failed, could find the '{buttonName}' button", $"Success, could not find the '{buttonName}' button");

			}
		}
		[StepDefinition(@"In Security Manager, the '(.*)' button (is|is not) available")]
		public void WhenInSecurityManagerTheButtonIsNotAvailable(string buttonName, string isOrIsNot)
		{

			SecurityManager SM = new SecurityManager();
			if (isOrIsNot == "is")
			{
				Report.IsTrue(SM.ButtonIsAvailable(buttonName), $"Failed, the '{buttonName}' button was not available", $"Success, the '{buttonName}' button was available");
			}
			else
			{
				Report.IsFalse(SM.ButtonIsAvailable(buttonName), $"Failed, the '{buttonName}' button was available", $"Success, the '{buttonName}' button was not available");
			}
		}
		[StepDefinition(@"In the '(Users and Roles)' window, the '(All Roles)' button (is|is not) available")]
		public void ThenInTheUARWindowTheRolesButtonIsNotAvailable(string windowName, string buttonName, string isOrIsNot)
		{
			SecurityManager_UsersAndRoles SM_UAR = new SecurityManager_UsersAndRoles();
			if (isOrIsNot == "is")
			{
				Report.IsTrue(SM_UAR.AllRolesButtonIsAvailable(buttonName), $"Failed, the '{buttonName}' button was not available", $"Success, the '{buttonName}' button was available");
			}
			else
			{
				Report.IsFalse(SM_UAR.AllRolesButtonIsAvailable(buttonName), $"Failed, the '{buttonName}' button was available", $"Success, the '{buttonName}' button was not available");
			}
		}
		[StepDefinition(@"In the '(Roles)' window, I double click the role '(.*)'")]
		public void WhenInTheWindowIDoubleClickTheRole(string windowName, string roleName)
		{
			SecurityManager_Roles SM_R = new SecurityManager_Roles();
			Report.IsTrue(SM_R.DoubleClickRole(roleName), $"Failed, could not click the Role {roleName}", $"Success, could click the Role {roleName}");
		}
		[StepDefinition(@"In the Security Manager - Rights by roles page, I select '(.*)' under '(Roles|Category)'")]
		public void WhenInTheSecurityMAnager_RolesPageISelectUnder(string dropDownOption, string dropDownName)
		{
			SecurityManager_RightsByRoles SM_RBR = new SecurityManager_RightsByRoles();
			Report.IsTrue(SM_RBR.SelectFromDropDown(dropDownOption, dropDownName), $"Failed, could not select '{dropDownOption}' under '{dropDownName}'.", $"Success, could select '{dropDownOption}' under '{dropDownName}'.");
		}
		[StepDefinition(@"In the Security Manager - Rights by roles page, I right click the product in position '(.*)' under column '(.*)'")]
		public void ThenInTheSecurityManager_RightsByRolesPageIRightClickTheProductUnder(int productNum, string columnName)
		{
			GeneralUtilities.SwitchToFrame("<1>");
			SecurityManager_RightsByRoles_Data SM_RBR_D = new SecurityManager_RightsByRoles_Data();
			Report.IsTrue(SM_RBR_D.RightClickItemNum(productNum, columnName), $"Failed could not right click the item in postion {productNum}", $"Success could right click the item in postion {productNum}", showSuccessScreenshot: false);
			;
			GeneralUtilities.ExitIFrame();

		}
		[StepDefinition(@"In the Security Manager - Rights by roles page, a context menu (should|should not) contain '(Full access|No access|Read only)'")]
		public void ThenInTheSecurityManager_RightsByRolesPageAContextMenuShouldNotContain(string shouldOrShouldNot, string menuItem)
		{
			GeneralUtilities.SwitchToFrame("<1>");
			SecurityManager_RightsByRoles_Data SM_RBR_D = new SecurityManager_RightsByRoles_Data();
			if (shouldOrShouldNot == "should")
			{
				Report.IsTrue(SM_RBR_D.RightClickMenuItemDisplayed(menuItem), "", "");
			}
			else
			{
				Report.IsFalse(SM_RBR_D.RightClickMenuItemDisplayed(menuItem), "", "");
			}
			GeneralUtilities.ExitIFrame();
		}

	}
}

