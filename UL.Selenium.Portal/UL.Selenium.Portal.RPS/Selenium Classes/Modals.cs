using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.RPS.Selenium_Classes
{
	class BaseModalDialog : SeleniumBaseObject
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.XPath("//div[contains(@class, 'modal fade')][@role = 'dialog'][contains(@style,'display')]");

		private IWebElement TitleByClass => ContainerElement.FindElement(By.ClassName("modal-title"), 1);

		private IWebElement ButtonWithText(string btnText) => FindElement(By.XPath($".//button[text()='{btnText}'] | .//input[@value='{btnText}']"), 1);

		private IWebElement CloseTopRightX => ContainerElement.FindElement(By.XPath(".//button[@class='close']"), 1);

		private IWebElement BodyElement => ContainerElement.FindElement(By.XPath($".//div[@class='modal-body']"), 2);
		#endregion

		#region Methods
		public string TitleText => this.TitleByClass?.Text;

		public bool ClickButtonByText(string text) => this.ButtonWithText(text).TryClick();

		public bool ButtonWithTextDisplayed(string text)
		{
			var el = this.ButtonWithText(text);
			return el != null && el.Displayed;
		}

		public bool ClickCloseTopRightX() => this.CloseTopRightX.TryClick();

		public string GetBodyText()
		{
			var el = this.BodyElement;
			if (el == null)
			{
				Report.Info($"The body element was null");
				return null;
			}
			return el.Text;
		}

		public bool BodyTextMatches(string expectedText)
		{
			string textFound = this.GetBodyText();
			if (textFound == null)
			{
				Report.Info($"The text was null");
				return false;
			}
			return textFound == expectedText;
		}

		#endregion
	}

	//JW 091521 - Deprecated (use LogInModal within Login.cs Selenium Class)
	class LogInModal : BaseModalDialog
	{
		#region Page Objects
		protected override By ContainerElementLocator => By.Id("loginModal");

		private IWebElement LoginButton => ContainerElement.WaitUntilElementVisible(By.Id("cmdLogIn"), 1);

		private IWebElement UserNameInput => ContainerElement.WaitUntilElementVisible(By.Id("UserName"), 1);

		private IWebElement PasswordInput => ContainerElement.WaitUntilElementVisible(By.Id("Password"), 1);

		private IWebElement ValidationErrors => ContainerElement.WaitUntilElementVisible(By.XPath(".//div[@class='validation-summary-errors']"), 3);

		private IWebElement UserNameLabel => this.UserNameInput.FindElement(By.XPath("./preceding-sibling::label[position()=1]"), 1);

		private IWebElement PasswordLabel => this.PasswordInput.FindElement(By.XPath("./preceding-sibling::label[position()=1]"), 1);

		#endregion

		#region Methods
		public bool UserNameLabelDisplayed() => this.UserNameLabel != null && this.UserNameLabel.Text.ToLower() == "user name";

		public bool PasswordLabelDisplayed() => this.PasswordLabel != null && this.PasswordLabel.Text == "Password";

		public bool LoginButtonTextDisplayed() => this.LoginButton?.GetValue() == "Log In";

		public bool CloseButtonTextDisplayed() => this.ButtonWithTextDisplayed("Close");

		public bool ClickCloseButton() => this.ClickButtonByText("Close");

		public bool ClickLoginButton => this.LoginButton.TryClick();

		public bool EnterUserName(string text) => this.UserNameInput.TryEnterText(text) && this.UserNameInput.GetValue() == text;

		public bool EnterPassword(string text) => this.PasswordInput.TryEnterText(text) && this.PasswordInput.GetValue() == text;

		public List<string> LogInErrors() => this.ValidationErrors.FindElements(By.XPath("./ul/li"), 1)?.Select(x => x.Text).ToList();
		#endregion
	}

	class SelectChartModal : BaseModalDialog
	{
		#region Page Objects
		private List<IWebElement> DisplayedListItems => FindElements(By.XPath("//ul[@class='list-group']/li[not(@style = 'display: none;')]"), 1).ToList();

		private List<IWebElement> DisplayedListItemTitles => this.DisplayedListItems.Select(x => x.FindElement(By.XPath("./a/span"), 1)).ToList();
		#endregion

		#region Methods
		public List<string> DisplayedListOptions() => this.DisplayedListItems.Select(x => x.Text).ToList();

		public bool ClickListItem(string item)
		{
			try
			{
				return DisplayedListItemTitles.FirstOrDefault(x => x.Text == item).TryClick();
			}
			catch
			{
				return false;
			}
		}
		#endregion
	}

	class NoValudUPCsModal : BaseModalDialog
	{
		#region Page Objects

		#endregion

		#region Methods

		#endregion

	}

	class MoreFiltersModal : BaseModalDialog
    {
		#region Page Objects
		public IWebElement ModalSpinner => ContainerElement.FindElement(By.XPath(".//i[@class='fa fa-spinner fa-spin']"), 1);
		private IWebElement FiltersArea => ContainerElement.FindElement(By.XPath(".//div[@class='row justify-content-center filters-area']"), 1);

        #region Filter By Page Objects
        private IWebElement FilterBySelector => FiltersArea.FindElement(By.XPath(".//select"),1);
		private IWebElement FilteredBySelectorDisplay => FiltersArea.FindElement(By.XPath(".//span[contains(@class,'select2-container')]"), 1);
		private IWebElement FilterBySelectorDropdown => FindElement(By.XPath("//span[contains(@class,'select2-dropdown')]"), 1);
		private List<IWebElement> FilterBySelectorDropdownOptions => FilterBySelectorDropdown.FindElements(By.XPath(".//li[@class='select2-results__option']"), 1).ToList();
		private IWebElement FilterBySelectorDropdownOption(string optionLabel) => FilterBySelectorDropdown.FindElement(By.XPath($".//li[@class='select2-results__option'][text()='{optionLabel}']"), 1);
		private IWebElement FilterBySelectorDropdownSearch => FilterBySelectorDropdown.FindElement(By.XPath(".//input[@class='select2-search__field']"), 1);
		#endregion

		#region Filter Option Page Objects
		private IWebElement FilterOptionArea => FiltersArea.FindElement(By.XPath("./div[not(@data-select2-id)]"), 1);
		private IWebElement FilterOptionTitle => FilterOptionArea.FindElement(By.XPath(".//p/strong"), 1);
		private IWebElement FilterOptionInputDiv => FilterOptionArea.FindElement(By.XPath(".//div[contains(@class,'input-group')]"), 1);
		private IWebElement FilterOptionInputSearch => FilterOptionInputDiv.FindElement(By.XPath(".//input[@type='text'][not(contains(@class,'date'))]"), 1);
		private IWebElement FilterOptionInputDate(string placeholderText) => FilterOptionInputDiv.FindElement(By.XPath($".//input[@type='text'][contains(@class,'date')][@placeholder='{placeholderText}']"), 1);
		private List<IWebElement> FilterOptionOptionsList => FilterOptionArea.FindElements(By.XPath(".//div[@class='form-check']//input"), 1).ToList();
		private IWebElement FilterOptionOption(string optionLabel) => FilterOptionArea.FindElement(By.XPath($".//div[@class='form-check'][contains(.,'{optionLabel}')]//input"), 1);
		#endregion

		#region Breadcrumbs Container Objects
		private IWebElement BreadcrumbsContainer => ContainerElement.FindElement(By.XPath(".//div[@class='tinyscroll breadcrumbs-container']"), 1);
		private IWebElement BreadcrumbsContainerTitle => BreadcrumbsContainer.FindElement(By.XPath(".//strong[text()]"), 1);
		private List<IWebElement> BreadcrumbsList => BreadcrumbsContainer.FindElements(By.XPath(".//span[@class='btn btn-gray btn-xs marbot-10']"), 1).ToList();
		private IWebElement Breadcrumb(string breadcrumbTitle) => BreadcrumbsContainer.FindElement(By.XPath($".//span[@class='btn btn-gray btn-xs marbot-10'][contains(normalize-space(),\"{breadcrumbTitle}\")]"), 1);
		private IWebElement BreadCrumbCloseButton(string breadcrumbTitle) => Breadcrumb(breadcrumbTitle).FindElement(By.XPath(".//i[@class = 'fa fa-remove']"), 1);
		#endregion
		#endregion

		#region Methods
		public bool ModalSpinnerExists()
        {
			Report.Info($"Attempting to confirm Modal Spinner exists.");
			return ModalSpinner != null;
        }

		public bool ModalSpinnerWaitToDisappear(int secondsToWait=30)
        {
			Report.Info($"Attempting to wait {secondsToWait} seconds for Modal Spinner to disappear.");
			bool result = true;
			while(ModalSpinnerExists())
            {
				Delay.Seconds(1);
				secondsToWait--;
				if(secondsToWait == 0)
                {
					Report.Info($"Modal Spinner failed to disappear after {secondsToWait} seconds.");
					result = false;
					break;
                }
            }
			return result;
        }

        #region Filter By Methods
        public bool FilterBySelectorExists()
        {
			Report.Info("Attempting to confirm the Filter By selector exists.");
			return FilterBySelector != null;
        }

		public bool FilterBySelectorClick()
        {
			Report.Info("Attempting to click the Filter By selector.");
			return FilteredBySelectorDisplay.TryClick();

		}

		public bool FilterBySelectorDropdownOpen()
        {
			Report.Info("Attempting to confirm that the Filter By selector dorpdown menu is open.");
			return FilterBySelectorDropdown != null;
        }

		public int FilterBySelectorDropdownOptionsCount()
        {
			Report.Info("Attempting to get the number of options in the Filter By selector dropdown.");
			return FilterBySelectorDropdownOptions.Count();
        }

		public bool FilterBySelectorDropdownOptionExists(string optionLabel)
        {
			Report.Info($"Attempting to confirm '{optionLabel}' option exists.");
			return FilterBySelectorDropdownOption(optionLabel) != null;

		}

		public bool FilterBySelectorDropdownOptionClick(string optionLabel)
        {
			Report.Info($"Attempting to click '{optionLabel}' option.");
			return FilterBySelectorDropdownOption(optionLabel).TryClick();
		}

		public bool FilterBySelectorDropdownOptionSearchExists()
        {
			Report.Info("Attempting to confirm Filter By selector dropdown search exists.");
			return FilterBySelectorDropdownSearch != null;
		}

		public bool FilterBySelectorDropdownOptionSearchClick()
        {
			Report.Info("Attempting to click Filter By selector dropdown search.");
			return FilterBySelectorDropdownSearch.TryClick();
        }

		public bool FilterBySelectorDropdownOptionsSearchEnterText(string textstring)
        {
			Report.Info($"Attempting to enter '{textstring}' into the Filter By selector dropdown search.");
			return FilterBySelectorDropdownSearch.TryEnterText(textstring);
        }
		#endregion

		#region Filter Option Methods
		public bool FilterOptionAreaExists()
        {
			Report.Info($"Attempting to confirm Filter Option Area exists.");
			return FilterOptionArea != null;
		}

		public bool FilterOptionTitleExists()
        {
			Report.Info($"Attempting to confirm Filter Options title exists.");
			return FilterOptionTitle != null;
        }

		public string FilterOptionTitleGet()
		{
			Report.Info($"Attempting to get Filter Options title.");
			return FilterOptionTitle.Text;
		}

		public bool FilterOptionOptionsListExists()
        {
			Report.Info("Attempting to confirm the Filter Option Options List exists.");
			return FilterOptionOptionsList != null;
		}

		public int FilterOptionOptionsListCount()
        {
			Report.Info("Attempting to get the number of options in the Filter Option Options List.");
			return FilterOptionOptionsList.Count();
		}

		public bool FilterOptionOptionsListOptionExists(int iOption)
        {
			Report.Info($"Attempting to confirm Filter Option Options List Option #{iOption} exists.");
			return iOption < FilterOptionOptionsListCount() && iOption >= 0;
        }

		public string FilterOptionOptionsListOptionLabelGet(int iOption)
        {
			Report.Info($"Attempting to get Filter Option Options List Option #{iOption} label.");
			return FilterOptionOptionsList[iOption].Text;
        }

		public bool FilterOptionOptionsListOptionClick(int iOption)
        {
			Report.Info($"Attempting to click Filter Option Options List Option #{iOption}.");
			return FilterOptionOptionsList[iOption].TryClick();
        }

		public bool FilterOptionOptionExists(string optionLabel)
        {
			Report.Info($"Attempting to confirm Filter Option '{optionLabel}' Option exists.");
			return FilterOptionOption(optionLabel) != null;
		}

		public bool FilterOptionOptionClick(string optionLabel)
        {
			Report.Info($"Attempting to click Filter Option '{optionLabel}' Option.");
			return FilterOptionOption(optionLabel).TryClick();
        }
		#endregion

		#region Breadcrumb Container Methods
		public bool BreadcrumbContainerExists()
        {
			Report.Info("Attempting to confirm Breadcrumb Container exists.");
			return BreadcrumbsContainer != null;
        }

		public bool BreadcrumbsListExists()
        {
			Report.Info("Attempting to confirm the Breadcrumbs List exsits.");
			return BreadcrumbsList != null;
        }

		public int BreadcrumbsListCount()
        {
			Report.Info("Attempting to count number of breadcrumbs in Breadcrumb List.");
			int breadcrumbCount;
            if (!BreadcrumbsListExists())
            {
				breadcrumbCount = 0;
            }
            else
            {
				breadcrumbCount = BreadcrumbsList.Count();
            }
			return breadcrumbCount;
        }

		public bool BreadcrumbExists(string breadcrumbTitle)
        {
			Report.Info($"Attempting to confirm '{breadcrumbTitle}' Breadcrumb exists.");
			return Breadcrumb(breadcrumbTitle) != null;
        }

		public bool BreadcrumbClose(string breadcrumbTitle)
        {
			Report.Info($"Attempting to close '{breadcrumbTitle}' Breadcrumb.");
			return BreadCrumbCloseButton(breadcrumbTitle).TryClick();

		}
		#endregion
		#endregion
	}
}
