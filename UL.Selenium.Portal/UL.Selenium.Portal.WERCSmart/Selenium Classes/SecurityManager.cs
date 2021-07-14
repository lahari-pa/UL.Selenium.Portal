using OpenQA.Selenium;
//using OpenQA.Selenium.DevTools.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UL.Automation.Reporting.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.Selenium.BaseClasses;
using UL.Automation.Selenium.Classes;
using UL.Automation.Selenium.Extensions;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes
{
	public class SecurityManager : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//body[//span[@id='lblTitle' and contains(text(),'Security Manager')]]");

		private IWebElement ObjectDropDown => ContainerElement.FindElement(By.XPath(".//select[@id='cboSecurityObject']"), 2);

		private string _buttonString;

		private IWebElement Button => ContainerElement.FindElement(By.XPath($"//a[span[contains(text(),'{_buttonString}')]]"), 2);

		public bool SelectObjectDropDown(string option)
		{
			if (this.ObjectDropDown == null)
			{
				Report.Error("Could not find the object drop down menu");
				return false;
			}
			List<IWebElement> DropDownOptions = this.ObjectDropDown.FindElements(By.XPath(".//option"), 2).ToList();
			if (DropDownOptions.Count == 0)
			{
				Report.Error("There were no options to select.");
				return false;
			}
			string ToMatch = $@"^(\* |! |){Regex.Escape(option)}";
			foreach (var DDOption in DropDownOptions)
			{
				Match match = Regex.Match(DDOption.Text, ToMatch);
				if (match.Success)
				{
					this.ObjectDropDown.Select(DDOption.Text);
					return true;
				}
			}
			Report.Error($"There were no options that matched the string {option}");
			return false;
		}

		public bool ClickButton(string buttonName)
		{
			_buttonString = buttonName;
			if (Button == null)
			{
				Report.Error($"Could not find a button with the name {buttonName}");
				return false;
			}
			return Button.TryClick();
		}

		public bool ButtonIsAvailable(string buttonName)
		{
			_buttonString = buttonName;
			return Button != null;
		}
	}
	public class SecurityManager_Modules : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//form[@name='frmModules']");

		private IWebElement ObjectTable => this.ContainerElement.FindElement(By.XPath(".//table[@id='srSecModules_tblSelectRecord']//table[@rules='cols']"), 2);

		private IWebElement ObjectTableHeader => this.ObjectTable.FindElement(By.XPath(".//tr[contains(@class,'Header')]"), 2);

		private IWebElement EditModuleBtn => this.ContainerElement.FindElement(By.XPath(".//a[contains(@title,'Edit selected')]"), 2);

		public bool ClickEditBtn()
		{
			if (this.EditModuleBtn == null)
			{
				Report.Error("Could not find the Edit Selected Modules button.");
				return false;
			}
			return this.EditModuleBtn.TryClick();
		}

		public int GetHeaderNum(string columnName)
		{
			int i = 2;//Starts at 2 to account for column with only a select box in it
			foreach (var header in this.ObjectTableHeader.FindElements(By.XPath(".//a"), 2).ToList())
			{
				if (header.Text.Contains(columnName))
				{
					return i;
				}
				else
				{
					i++;
				}
			}
			Report.Error($"There was no column named {columnName}.");
			return 0;
		}

		public bool ClickItemUnderHeader(string item, string columnName)
		{
			int colNum = this.GetHeaderNum(columnName);
			int i = 1;
			var rows = this.ObjectTable.FindElements(By.XPath($".//tr[not(contains(@class,'Header'))]//td[{colNum}]"), 2).ToList();
			bool output = false;
			foreach (var row in rows)
			{
				if (row.Text.Equals(item))
				{
					output = row.TryClick();
					break;
				}
				else
				{
					i++;
				}
			}
			if (i > rows.Count)
			{
				Report.Error($"There were no item under {columnName} containing the text {item}");
				return false;
			}
			var inputObject = this.ObjectTable.FindElements(By.XPath(".//input"), 2).ToList();
			return inputObject[i].TryCheck() && output;
		}
	}
	public class SecurityManager_SetAccessWindow : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//form[@name='frmSecRoles']");

		private IWebElement RoleTable => this.ContainerElement.FindElement(By.XPath(".//table[@id='srSecRoles_grdSR']"), 2);

		private List<IWebElement> Roles => this.RoleTable.FindElements(By.XPath(".//tr[not(contains(@class,'Header'))]"), 2).ToList();

		private IWebElement Headers => this.RoleTable.FindElement(By.XPath(".//tr[contains(@class,'Header')]"), 2);

		private IWebElement PermissionsDropDown => this.ContainerElement.FindElement(By.XPath(".//select[@id='cboPermissions']"), 2);

		private IWebElement ChangeRightsBtn => this.ContainerElement.FindElement(By.XPath(".//a[@id='btnChangeRights']"), 2);

		public int GetHeaderNum(string columnName)
		{
			int i = 2;//Starts at 2 to account for column with only a select box in it
			foreach (var header in this.Headers.FindElements(By.XPath(".//a"), 2).ToList())
			{
				if (header.Text.Contains(columnName))
				{
					return i;
				}
				else
				{
					i++;
				}
			}
			Report.Error($"There was no column named {columnName}.");
			return 0;
		}
		public bool SelectItemUnderHeader(string role, string column)
		{
			int colNum = this.GetHeaderNum(column);
			int i = 1;
			bool output = false;
			foreach (var row in Roles)
			{
				IWebElement cell = row.FindElement(By.XPath($".//td[{colNum}]"), 2);
				if (cell.Text.Equals(role))
				{
					output = cell.TryClick();
					break;
				}
				else
				{
					i++;
				}
			}
			if (i > Roles.Count)
			{
				Report.Error($"There were no item under {column} containing the text {role}");
				return false;
			}
			var inputObject = this.RoleTable.FindElements(By.XPath(".//input"), 2).ToList();
			return inputObject[i].TryCheck() && output;
		}

		public bool SelectAccessLevel(string accessLevel)
		{
			if (this.PermissionsDropDown == null)
			{
				Report.Error("Could not find the permissions drop down menu");
				return false;
			}
			List<IWebElement> DropDownOptions = this.PermissionsDropDown.FindElements(By.XPath(".//option"), 2).ToList();
			if (DropDownOptions.Count == 0)
			{
				Report.Error("There were no options to select.");
				return false;
			}
			string ToMatch = $@"^(\* |! |){Regex.Escape(accessLevel)}";
			foreach (var DDOption in DropDownOptions)
			{
				Match match = Regex.Match(DDOption.Text, ToMatch);
				if (match.Success)
				{
					this.PermissionsDropDown.Select(DDOption.Text);
					return true;
				}
			}
			Report.Error($"There were no options that matched the string {accessLevel}");
			return false;
		}

		public bool ClickToSetAccessLevel()
		{
			if (this.ChangeRightsBtn == null)
			{
				Report.Error("Could not find the Change Multiple button.");
				return false;
			}
			return this.ChangeRightsBtn.JsClick();
		}
	}
	public class SecurityManager_Screens : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//form[@name='Form1']");

		private IWebElement FilterIcon => this.ContainerElement.FindElement(By.XPath(".//a[contains(@title,'Filter by keyword')]"), 2);

		private IWebElement FilterSearchBox => this.ContainerElement.FindElement(By.XPath(".//table[contains(@id,'tblFilter')]"), 2);

		private string _searchType;
		private IWebElement SearchDropDown => this.FilterSearchBox.FindElement(By.XPath($".//span[contains(text(),'{_searchType}')]/../..//select"), 2);

		private IWebElement SearchTextBox => this.FilterSearchBox.FindElement(By.XPath($".//span[contains(text(),'{_searchType}')]/../..//input"), 2);

		private IWebElement ApplyBtn => this.FilterSearchBox.FindElement(By.XPath(".//input[contains(@id,'cmdApply')]"), 2);

		private IWebElement ObjectTable => this.ContainerElement.FindElement(By.XPath("//table[@id='srSecScreens_divRounded']//table[@id='srSecScreens_grdSR']"), 2);

		private IWebElement ObjectTableHeader => this.ObjectTable.FindElement(By.XPath(".//tr[contains(@class,'Header')]"), 2);

		private IWebElement EditScreensBtn => this.ContainerElement.FindElement(By.XPath(".//a[contains(@title,'Edit selected')]"), 2);

		public bool ClickItemUnderHeader(string item, string columnName)
		{
			int colNum = this.GetHeaderNum(columnName);
			int i = 1;
			foreach (var row in this.ObjectTable.FindElements(By.XPath($".//tr[not(contains(@class,'Header'))]//td[{colNum}]"), 2).ToList())
			{
				if (row.Text.Equals(item))
				{
					return row.TryClick();
				}
				else
				{
					i++;
				}
			}
			Report.Error($"There were no item under {columnName} containing the text {item}");
			return false;
		}

		public int GetHeaderNum(string columnName)
		{
			int i = 1;
			foreach (var header in this.ObjectTableHeader.FindElements(By.XPath(".//a"), 2).ToList())
			{
				if (header.Text.Contains(columnName))
				{
					return i;
				}
				else
				{
					i++;
				}
			}
			Report.Error($"There was no column named {columnName}.");
			return 0;
		}

		public bool ClickFilterIcon()
		{
			if (this.FilterIcon == null)
			{
				Report.Error("Could not find the filter icon link.");
				return false;
			}
			return this.FilterIcon.TryClick();
		}

		public bool SelectFilterTypeDropDown(string filterName, string filterType)
		{
			_searchType = filterName;
			if (this.SearchDropDown == null)
			{
				Report.Error("Could not find the Search drop down.");
				return false;
			}
			List<IWebElement> DropDownOptions = this.SearchDropDown.FindElements(By.XPath(".//option"), 2).ToList();
			if (DropDownOptions.Count == 0)
			{
				Report.Error("There were no options to select.");
				return false;
			}
			string ToMatch = $@"^(\* |! |){Regex.Escape(filterType)}";
			foreach (var option in DropDownOptions)
			{
				Match match = Regex.Match(option.Text, ToMatch);
				if (match.Success)
				{
					this.SearchDropDown.Select(option.Text);
					return true;
				}
			}
			Report.Error($"There were no options that matched the string {filterType}");
			return false;
		}

		public bool EnterFilterText(string filterName, string filterText)
		{
			_searchType = filterName;
			if (this.SearchTextBox == null)
			{
				Report.Error("Could not find the search Text box");
				return false;
			}
			return this.SearchTextBox.TryEnterText(filterText);
		}

		public bool ClickApplyBtn()
		{
			if (this.ApplyBtn == null)
			{
				Report.Error("Could not find the filter apply button.");
				return false;
			}
			return this.ApplyBtn.TryClick();
		}

		public bool ClickEditBtn()
		{
			if (this.EditScreensBtn == null)
			{
				Report.Error("Could not find the edit button");
				return false;
			}
			return this.EditScreensBtn.TryClick();
		}
	}
	public class SecurityManager_UsersAndRoles : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='grid wfull fringe-clear']");

		private IWebElement UserRolesGridContainer => this.ContainerElement.FindElement(By.XPath(".//div[div/span[contains(text(),'Users and roles')]]"), 2);

		private IWebElement SearchBar => this.UserRolesGridContainer.FindElement(By.XPath(".//table[@role='presentation']"), 2);

		private List<IWebElement> SearchTitles => this.SearchBar.FindElements(By.XPath(".//tr[contains(@class,'labels')]/th[not(contains(@style,'display: none;'))]"), 2).ToList();

		private List<IWebElement> SearchInputs => this.SearchBar.FindElements(By.XPath(".//tr[contains(@class,'toolbar')]/th[not(contains(@style,'display: none;'))]//input"), 2).ToList();

		private IWebElement ResultsTable => this.UserRolesGridContainer.FindElement(By.XPath(".//table[@id='UandRGrid-grid']"), 2);

		private IWebElement TableHeaderContainer => this.UserRolesGridContainer.FindElement(By.XPath(".//div[@id='pg_UandRGrid-grid_toppager']"), 2);

		private string _buttonName;

		private IWebElement TargetButton => this.TableHeaderContainer.FindElement(By.XPath($".//div[contains(@title,'{_buttonName}')]"), 2);

		private IWebElement AllRolesBtn => this.ContainerElement.FindElement(By.XPath($".//input[@title='All Roles']"), 2);


		public bool UserNameSearch(string searchType, string userName)
		{
			if (this.SearchTitles.Count != this.SearchInputs.Count)
			{
				Report.Error("Search titles and inputs count did not match");
				return false;
			}
			if (this.SearchTitles.Count == 0)
			{
				Report.Error("There were no search titles or inputs.");
				return false;
			}
			string ToMatch = $@"^(\* |! |){Regex.Escape(searchType)}";
			var searches = this.SearchTitles.Zip(this.SearchInputs, (t, i) => new { Title = t, Input = i });
			foreach (var search in searches)
			{
				Match match = Regex.Match(search.Title.Text.Trim(), ToMatch);
				if (match.Success)
				{
					return search.Input.TryEnterTextAndTab(userName.ToLower());
				}
			}
			Report.Error($"There was no search title that matched {searchType}.");
			return false;
		}

		public bool RightClickUserName(string searchType, string userName)
		{
			if (this.SearchTitles.Count != this.SearchInputs.Count)
			{
				Report.Error("Search titles and inputs count did not match");
				return false;
			}
			if (this.SearchTitles.Count == 0)
			{
				Report.Error("There were no search titles or inputs.");
				return false;
			}
			string ToMatch = $@"^(\* |! |){Regex.Escape(searchType)}";
			int index = 0;
			foreach (var titles in this.SearchTitles)
			{
				index++;
				Match match = Regex.Match(titles.Text.Trim(), ToMatch);
				if (match.Success)
				{
					var UserNamesList = this.ResultsTable.FindElements(By.XPath($"//tr[contains(@id,'UandRGrid-grid')]/td[not(contains(@style,'display: none;'))][{index}]"), 2).ToList();
					if (UserNamesList.Count == 0)
					{
						Report.Error($"There were no usernames for the search: {userName}");
						return false;
					}
					else
					{
						string ToMatch2 = $@"^{Regex.Escape(userName)}$";
						foreach (var name in UserNamesList)
						{
							Match match2 = Regex.Match(name.Text.Trim(), ToMatch2);
							if (match2.Success)
							{
								Report.Info("Found the username");
								try
								{
									name.RightClick();
									return true;
								}
								catch (Exception)
								{
									Report.Error($"Could not right click the item: {userName}");
									return false;
								}
							}
						}
					}
				}
			}
			Report.Error($"There was no search title that matched {searchType}.");
			return false;
		}

		public bool DoubleClickUserName(string searchType, string userName)
		{
			if (searchTitles.Count != searchInputs.Count)
			{
				Report.Error("Search titles and inputs count did not match");
				return false;
			}
			if (searchTitles.Count == 0)
			{
				Report.Error("There were no search titles or inputs.");
				return false;
			}
			string ToMatch = $@"^(\* |! |){Regex.Escape(searchType)}";
			int index = 0;
			foreach (var titles in searchTitles)
			{
				index++;
				Match match = Regex.Match(titles.Text.Trim(), ToMatch);
				if (match.Success)
				{
					var UserNamesList = ResultsTable.FindElements(By.XPath($"//tr[contains(@id,'UandRGrid-grid')]/td[not(contains(@style,'display: none;'))][{index}]"), 2).ToList();
					if (UserNamesList.Count == 0)
					{
						Report.Error($"There were no usernames for the search: {userName}");
						return false;
					}
					else
					{
						string ToMatch2 = $@"^{Regex.Escape(userName)}$";
						foreach (var name in UserNamesList)
						{
							Match match2 = Regex.Match(name.Text.Trim(), ToMatch2);
							if (match2.Success)
							{
								Report.Info("Found the username");
								return name.TryDoubleClick();
							}
						}
					}
				}
			}
			Report.Error($"There was no search title that matched {searchType}.");
			return false;
		}

		public bool ClickUserName(string searchType, string userName)
		{
			if (searchTitles.Count != searchInputs.Count)
			{
				Report.Error("Search titles and inputs count did not match");
				return false;
			}
			if (searchTitles.Count == 0)
			{
				Report.Error("There were no search titles or inputs.");
				return false;
			}
			string ToMatch = $@"^(\* |! |){Regex.Escape(searchType)}";
			int index = 0;
			foreach (var titles in searchTitles)
			{
				index++;
				Match match = Regex.Match(titles.Text.Trim(), ToMatch);
				if (match.Success)
				{
					var UserNamesList = ResultsTable.FindElements(By.XPath($"//tr[contains(@id,'UandRGrid-grid')]/td[not(contains(@style,'display: none;'))][{index}]"), 2).ToList();
					if (UserNamesList.Count == 0)
					{
						Report.Error($"There were no usernames for the search: {userName}");
						return false;
					}
					else
					{
						string ToMatch2 = $@"^{Regex.Escape(userName)}$";
						foreach (var name in UserNamesList)
						{
							Match match2 = Regex.Match(name.Text.Trim(), ToMatch2);
							if (match2.Success)
							{
								Report.Info("Found the username");
								return name.TryClick();
							}
						}
					}
				}
			}
			Report.Error($"There was no search title that matched {searchType}.");
			return false;
		}

		public bool ButtonIsAvialable(string buttonName)
		{
			ButtonName = buttonName;
			return TargetButton != null;
		}

		public bool ClickAllRolesBtn(string buttonName)
		{
			if (AllRolesBtn == null)
			{
				Report.Error($"Could not find the '{buttonName}' button");
				return false;
			}
			return AllRolesBtn.TryClick();
		}

		public bool AllRolesButtonIsAvailable(string buttonName)
		{
			return AllRolesBtn != null;
		}

		internal bool ClickButton(string buttonName)
		{
			ButtonName = buttonName;
			return TargetButton != null ? TargetButton.TryClick() : false;
		}
	}
	public class SecurityManager_EditUser : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//form[@name='UserEdit']");

		private IWebElement ChangePassBtn => ContainerElement.FindElement(By.Id("cmdPasswordReset"), 2);

		public bool ClickChangePass()
		{
			if (ChangePassBtn == null)
			{
				Report.Error("Could not find the Change password button");
				return false;
			}
			return ChangePassBtn.TryClick();
		}

	}

	public class SecurityManager_AddUser : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//form[@name='UserEdit']");

		private IWebElement FirstNameTxtBox => ContainerElement.FindElement(By.XPath(".//input[@name='txtFirstName']"), 2);

		private IWebElement LastNameTxtBox => ContainerElement.FindElement(By.XPath(".//input[@name='txtLastName']"), 2);

		private IWebElement EmailAddTxtBox => ContainerElement.FindElement(By.XPath(".//input[@name='txtEmail']"), 2);

		private IWebElement PasswordTxtBox => ContainerElement.FindElement(By.XPath(".//input[@name='txtPassword']"), 2);
		private IWebElement ConfirmTxtBox => ContainerElement.FindElement(By.XPath(".//input[@name='txtReTypePassword']"), 2);
		private IWebElement UsernameTxtBox => ContainerElement.FindElement(By.XPath(".//input[@name='txtUserName']"), 2);

		private IWebElement RoleDropDown => ContainerElement.FindElement(By.XPath(".//select[@name='cboRole']"), 2);

		private List<IWebElement> RoleOptions => RoleDropDown.FindElements(By.XPath("./option"), 2).ToList();

		private IWebElement BackupUserBtn => ContainerElement.FindElement(By.XPath(".//input[@type='submit'][@name='ucSelectUser$cmdSelect']"), 2);//ucSelectPlant$cmdSelect

		private IWebElement PlantBtn => ContainerElement.FindElement(By.XPath(".//input[@type='submit'][@name='ucSelectPlant$cmdSelect']"), 2);

		private IWebElement SaveBtn => ContainerElement.FindElement(By.XPath(".//a[@id='btnSave']"), 2);

		public bool EnterEmail(string emailAdd)
		{
			return EmailAddTxtBox != null && EmailAddTxtBox.TryEnterTextAndTab(emailAdd);
		}

		public bool EnterFirstName(string first)
		{
			return FirstNameTxtBox != null && FirstNameTxtBox.TryEnterTextAndTab(first);
		}

		public bool EnterLastName(string last)
		{
			return LastNameTxtBox != null && LastNameTxtBox.TryEnterTextAndTab(last);
		}

		public bool EnterPassword(string password)
		{
			return PasswordTxtBox != null && PasswordTxtBox.TryEnterTextAndTab(password, true, 0.1);
		}

		public bool ConfirmPassword(string password)
		{
			return ConfirmTxtBox != null && ConfirmTxtBox.TryEnterTextAndTab(password, true, 0.1);
		}

		public bool EnterUserName(string userName)
		{
			return UsernameTxtBox != null && UsernameTxtBox.TryEnterTextAndTab(userName);
		}

		internal bool SelectRole(string role)
		{
			if (RoleDropDown == null)
			{
				Report.Error("Could not find the role drop down");
				return false;
			}
			if (RoleOptions.Count() < 1)
			{
				Report.Error("Could not find any roles under the role drop down.");
				return false;
			}
			string ToMatch = $@"^(\* |! |){Regex.Escape(role)}";
			foreach (var option in RoleOptions)
			{
				Match match = Regex.Match(option.Text.Trim(), ToMatch);
				if (match.Success)
				{
					try
					{
						RoleDropDown.Select(option.Text);
						return true;
					}
					catch (Exception)
					{
						Report.Error($"Could not select the option {option.Text}");
						return false;
					}
				}
			}
			Report.Error($"Could not find any matching Roles, Please create this role:{role}");
			return false;
		}

		internal bool ClickBackupUserBttn()
		{
			return BackupUserBtn != null && BackupUserBtn.TryClick();
		}

		internal bool ClickPlantBttn()
		{
			return PlantBtn != null && PlantBtn.TryClick();
		}

		internal bool ClickSaveBttn()
		{
			return SaveBtn != null && SaveBtn.TryClick();
		}
	}
	public class SecurityManager_SelectUser : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//form[@name='Form1']//table[@id='srUsers_tblSelectRecord']");

		private IWebElement FilterButton => ContainerElement.FindElement(By.XPath("//a[@id='srUsers_lnkFilter']"), 2);

		private IWebElement FilterTable => ContainerElement.FindElement(By.XPath(".//table[@id='srUsers_tblFilter']"), 2);

		private string SearchHeader;

		private IWebElement SearchRow => FilterTable.FindElement(By.XPath($".//table//tr[td/span[contains(text(),'{SearchHeader}')]]"), 2);

		private IWebElement SearchDropDown => SearchRow.FindElement(By.XPath($".//select"), 2);

		private IWebElement SearchTextBox => SearchRow.FindElement(By.XPath(".//input"), 2);

		private IWebElement ApplyBtn => FilterTable.FindElement(By.XPath(".//input[@type='submit'][@title='Apply']"), 2);

		private IWebElement DataTable => ContainerElement.FindElement(By.XPath(".//div[@id='srUsers_divSRData']//table"), 2);

		private List<IWebElement> ColHeaders => DataTable.FindElements(By.XPath($".//tr[contains(@class,'Header')]//a"), 2).ToList();

		internal bool ClickFilterBtn()
		{
			return FilterButton != null && FilterButton.TryClick();
		}

		internal bool SelectFilterType(string filterName, string searchType)
		{
			SearchHeader = filterName;
			if (SearchRow == null)
			{
				Report.Error($"Could not find the filter for {filterName}");
				return false;
			}
			if (SearchDropDown == null)
			{
				Report.Error($"Could not find the dropdown for the {filterName} row.");
				return false;
			}
			List<IWebElement> DropDownOptions = SearchDropDown.FindElements(By.XPath(".//option"), 2).ToList();
			if (DropDownOptions.Count == 0)
			{
				Report.Error("There were no options to select.");
				return false;
			}
			string ToMatch = $@"^(\* |! |){Regex.Escape(searchType)}";
			foreach (var option in DropDownOptions)
			{
				Match match = Regex.Match(option.Text, ToMatch);
				if (match.Success)
				{
					SearchDropDown.Select(option.Text);
					return true;
				}
			}
			Report.Error($"There were no options that matched the string {searchType}");
			return false;
		}

		internal bool EnterFilterText(string searchHeader, string searchText)
		{
			SearchHeader = searchHeader;
			if (SearchRow == null)
			{
				Report.Error($"Could not find the filter for {searchHeader}");
				return false;
			}
			if (SearchTextBox == null)
			{
				Report.Error($"Could not find the text box for the filter {searchHeader}");
				return false;
			}
			else
			{
				return SearchTextBox.TryEnterText(searchText);
			}
		}

		internal bool ClickApplyFilterBtn()
		{
			return ApplyBtn == null ? false : ApplyBtn.TryClick();
		}

		internal bool SelectItem(string columnHeader, string userName)
		{
			Delay.Seconds(1);
			if (ColHeaders.Count() < 1)
			{
				Report.Error("Could not find the column headers.");
				return false;
			}
			string ToMatch = $@"^(\* |! |){Regex.Escape(columnHeader)}";
			int colNum = 0;
			foreach (var header in ColHeaders)
			{
				Match match = Regex.Match(header.Text.Trim(), ToMatch);
				if (match.Success)
				{
					break;
				}
				else
				{
					colNum++;
				}
			}
			if (colNum >= ColHeaders.Count())
			{
				Report.Error($"Could not find the column with the header {columnHeader}");
				return false;
			}
			List<IWebElement> rows = DataTable.FindElements(By.XPath($"//tr[contains(@class,'Item')]//td[{colNum + 1}]"), 2).ToList();
			ToMatch = $"^{Regex.Escape(userName)}$";
			foreach (var row in rows)
			{
				Match match = Regex.Match(row.Text.Trim(), ToMatch);
				if (match.Success)
				{
					return row.TryClick();
				}
			}
			Report.Error($"Could not find the username {userName}");
			return false;
		}
	}

	public class SecurityManager_SelectLocation : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//form[@name='Form1']//table[@id='srPlants_divRounded']");

		private IWebElement DataTable => ContainerElement.FindElement(By.XPath(".//div[@id='srPlants_divSRData']//table"), 2);

		private List<IWebElement> ColHeaders => DataTable.FindElements(By.XPath($".//tr[contains(@class,'Header')]//a"), 2).ToList();

		internal bool SelectItem(string columnHeader, string plant)
		{
			if (ColHeaders.Count() < 1)
			{
				Report.Error("Could not find the column headers.");
				return false;
			}
			string ToMatch = $@"^(\* |! |){Regex.Escape(columnHeader)}";
			int colNum = 0;
			foreach (var header in ColHeaders)
			{
				Match match = Regex.Match(header.Text.Trim(), ToMatch);
				if (match.Success)
				{
					break;
				}
				else
				{
					colNum++;
				}
			}
			if (colNum >= ColHeaders.Count())
			{
				Report.Error($"Could not find the column with the header {columnHeader}");
				return false;
			}
			List<IWebElement> rows = DataTable.FindElements(By.XPath($"//tr[contains(@class,'Item')]//td[{colNum + 1}]"), 2).ToList();
			ToMatch = $"^{Regex.Escape(plant)}$";
			foreach (var row in rows)
			{
				Match match = Regex.Match(row.Text.Trim(), ToMatch);
				if (match.Success)
				{
					return row.TryClick();
				}
			}
			Report.Error($"Could not find the username {plant}");
			return false;
		}
	}
	public class SecurityManager_ResetYourPassword : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//div[@class='grid wfull fringe-clear']");

		private IWebElement UserName => ContainerElement.FindElement(By.XPath(".//label[@for='UserName']"), 2);

		private IWebElement NewPassTxtBox => ContainerElement.FindElement(By.Id("NewPassword"), 2);

		private IWebElement ConfirmPassTxtBox => ContainerElement.FindElement(By.Id("ConfirmPassword"), 2);

		private IWebElement SubmitButton => ContainerElement.FindElement(By.Id("submit"), 2);

		public bool VerifyUserName(string userName)
		{
			if (UserName == null)
			{
				Report.Error("Could not find the User Name on the page.");
				return false;
			}
			return UserName.Text == userName;
		}

		public bool EnterNewPassword(string password)
		{
			if (NewPassTxtBox == null)
			{
				Report.Error("Could not find the New Password text box.");
				return false;
			}
			return NewPassTxtBox.TryEnterText(password);
		}

		public bool EnterConfirmPassword(string password)
		{
			if (ConfirmPassTxtBox == null)
			{
				Report.Error("Could not find the Confirm Password text box.");
				return false;
			}
			return ConfirmPassTxtBox.TryEnterText(password);
		}

		public bool ClickSubmitPassword(string pass)
		{
			if (SubmitButton == null)
			{
				Report.Error("Could not find the submit button.");
				return false;
			}
			else
			{
				return SubmitButton.TryClick();
			}
		}
	}
	public class SecurityManager_Roles : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//form[@name='Form1']//table[@id='srRoles_divRounded']");

		private IWebElement CommandButtonsContainer => ContainerElement.FindElement(By.XPath(".//div[@id='srRoles_cmdButtons']"), 2);

		private string ButtonName;

		private IWebElement TargetButton => CommandButtonsContainer.FindElement(By.XPath($"./a[contains(@title,'{ButtonName}')]"), 2);

		private IWebElement RoleTableContainer => ContainerElement.FindElement(By.XPath(".//table[@id='srRoles_grdSR']"), 2);

		private List<IWebElement> RoleData => RoleTableContainer.FindElements(By.XPath(".//tr[contains(@class,'Item')]/td[2]"), 2).ToList();
		public bool ButtonAvilable(string buttonName)
		{
			ButtonName = buttonName;
			return TargetButton != null;
		}

		public bool DoubleClickRole(string roleName)
		{
			var role2select = RoleData.Where(R => R.Text.Contains(roleName));
			if (role2select.Count() != 1)
			{
				Report.Error($"Could not find a unique Role with the name {roleName}");
				return false;
			}
			else
			{
				return role2select.First().TryDoubleClick();
			}
		}
	}
	public class SecurityManager_RightsByRoles : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//form[@name='Rights']");

		private string DropDownName;

		private IWebElement TargetDropDown => ContainerElement.FindElement(By.XPath($".//td[span[contains(text(),'{DropDownName}')]]//select"), 2);
		public bool SelectFromDropDown(string dropDownString, string dropDownName)
		{
			DropDownName = dropDownName;
			List<IWebElement> dropDownOptions = TargetDropDown.FindElements(By.XPath(".//option"), 2).ToList();
			var query = from options in dropDownOptions
						where options.Text.Contains(dropDownString)
						select options;
			string ToMatch = $@"^(\* |! |){Regex.Escape(dropDownString)}";
			if (query.Count() > 1)
			{
				query = from options in query
						where Regex.Match(options.Text.Trim(), ToMatch).Success
						select options;
			}
			if (query.Count() < 1)
			{
				Report.Error($"Could not find any options containing the text {dropDownString}.");
				return false;
			}
			try
			{
				TargetDropDown.Select(query.First().Text);
				return true;
			}
			catch (Exception)
			{
				Report.Error($"Could not select {query.First().Text} for the {dropDownName} drop down");
				return false;
			}

		}
	}
	public class SecurityManager_RightsByRoles_Data : SeleniumBaseObject
	{
		protected override By ContainerElementLocator => By.XPath("//body[//form[@name='Form1']]");

		private IWebElement DataTable => ContainerElement.FindElement(By.XPath(".//table[tbody/tr[td/a[contains(text(),'Rights by role')]]]"), 2);
		private List<IWebElement> ItemsList => DataTable.FindElements(By.XPath(".//table[not(contains(@style,'display: none'))]//tr[contains(@class,'Item') and not(@class='FilItem')]"), 2).ToList();

		private IWebElement ColumnHeaders => DataTable.FindElement(By.XPath(".//table[not(contains(@style,'display: none'))]//tr[contains(@class,'ColHeader')]"), 2);

		private IWebElement ContextMenu => ContainerElement.FindElement(By.XPath(".//table[@id='tblContext']"), 2);

		public bool RightClickItemNum(int productNum, string columnName)
		{
			if (ColumnHeaders == null)
			{
				Report.Error("There were no column headers.");
				return false;
			}
			List<IWebElement> columns = ColumnHeaders.FindElements(By.XPath(".//td[not(contains(@style,'display: none'))]"), 2).ToList();
			var columnNum = columns.FindIndex(c => c.Text.Contains(columnName));
			if (columnNum < 0)
			{
				Report.Error($"There was no column with the name {columnName}");
				return false;
			}
			if (ItemsList.Count() < productNum)
			{
				Report.Error("There were not enough products in the list visiable");
				return false;
			}
			var item = ItemsList[productNum - 1];//c# is 0 index
			IWebElement data = item.FindElement(By.XPath($".//td[{columnNum + 1}]"), 2);// xpaths are 1 index, while c# is 0 index
			if (data == null)
			{
				Report.Error($"Could not find the cell data for column {columnName} and item {productNum}");
				return false;
			}
			try
			{
				data.RightClick();
				return true;
			}
			catch (Exception)
			{
				Report.Error("There was an error when right clicking the item.");
				return false;
			}
		}

		public bool RightClickMenuItemDisplayed(string menuItem)
		{
			if (ContextMenu == null)
			{
				Report.Info("The context menu does not exist, so the menu item can't be displayed.");
				return false;
			}
			if (ContextMenu.Text.Contains(menuItem))
			{
				Report.Info($"The context menu contained the text '{menuItem}'");
				return true;
			}
			else
			{
				Report.Error($"The context menu did not contain the text '{menuItem}'");
				return false;
			}
		}
	}
}
