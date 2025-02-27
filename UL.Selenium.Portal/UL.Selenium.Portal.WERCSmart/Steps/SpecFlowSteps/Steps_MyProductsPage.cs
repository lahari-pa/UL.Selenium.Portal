using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "MyProductsPage")]
	internal class Steps_MyProductsPage
	{
		#region Prototype Steps
		#region Button Prototype Steps
		//[RegexStepDefinition(@"On the My Products page, confirm (.*) button (does|does not) exists")]
		public void MyProductsPageConfirmButtonExists(string buttonLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			Report.IsTrue(expected == myProductsPage.LabeledButtonExists(buttonLabel), $"Failure, failed to confirm '{buttonLabel}' button {does_doesnot} exist.", $"Success, confirmed '{buttonLabel}' button {does_doesnot} exist.");
		}

		//[RegexStepDefinition(@"On the My Products page, click the (.*) button")]
		public void MyProductsPageClickButton(string buttonLabel)
		{
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.LabeledButtonExists(buttonLabel), $"Failure, failed to confirm '{buttonLabel}' button does exist.", $"Success, confirmed '{buttonLabel}' button does exist."))
			{
				Report.IsTrue(myProductsPage.LabeledButtonClick(buttonLabel), $"Failure, failed to click '{buttonLabel}' button.", $"Success, clicked '{buttonLabel}' button.");
			}
		}
		#endregion

		#region Checkbox Prototype Steps
		//[RegexStepDefinition(@"On the My Products page, confirm (.*) checkbox (does|does not) exists")]
		public void MyProductsPageConfirmCheckboxExists(string checkboxLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			Report.IsTrue(expected == myProductsPage.CheckboxExists(checkboxLabel), $"Failure, failed to confirm '{checkboxLabel}' checkbox {does_doesnot} exist.", $"Success, confirmed '{checkboxLabel}' checkbox {does_doesnot} exist.");
		}

		//[RegexStepDefinition(@"On the My Products page, click the (.*) checkbox")]
		public void MyProductsPageClickCheckbox(string checkboxLabel)
		{
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.CheckboxExists(checkboxLabel), $"Failure, failed to confirm '{checkboxLabel}' checkbox does exist.", $"Success, confirmed '{checkboxLabel}' checkbox does exist."))
			{
				Report.IsTrue(myProductsPage.CheckboxClick(checkboxLabel), $"Failure, failed to click '{checkboxLabel}' checkbox.", $"Success, clicked '{checkboxLabel}' checkbox.");
			}
		}

		//[RegexStepDefinition(@"On the My Products page, confirm the (.*) checkbox (is|is not) checked")]
		public void MyProductsPageCheckboxChecked(string checkboxLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.CheckboxExists(checkboxLabel), $"Failure, failed to confirm '{checkboxLabel}' checkbox does exist.", $"Success, confirmed '{checkboxLabel}' checkbox does exist."))
			{
				Report.IsTrue(expected == myProductsPage.CheckboxChecked(checkboxLabel), $"Failure, failed to confirm '{checkboxLabel}' checkbox {is_isnot} checked.", $"Success, confirmed '{checkboxLabel}' checkbox {is_isnot} checked.");
			}
		}

		//[RegexStepDefinition(@"On the My Products page, (check|uncheck) the (.*) checkbox")]
		public void MyProductsPageCheckUnCheckCheckbox(string check_uncheck, string checkboxLabel)
		{
			bool expected = check_uncheck == "check";
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.CheckboxExists(checkboxLabel), $"Failure, failed to confirm '{checkboxLabel}' checkbox does exist.", $"Success, confirmed '{checkboxLabel}' checkbox does exist."))
			{
				if (expected != myProductsPage.CheckboxChecked(checkboxLabel))
				{
					Report.IsTrue(myProductsPage.CheckboxClick(checkboxLabel), $"Failure, failed to click '{checkboxLabel}' checkbox.", $"Success, clicked '{checkboxLabel}' checkbox.");
				}
				Report.IsTrue(expected == myProductsPage.CheckboxChecked(checkboxLabel), $"Failure, failed to {check_uncheck} '{checkboxLabel}' checkbox.", $"Success, {check_uncheck}ed '{checkboxLabel}' checkbox.");
			}
		}
		#endregion

		#region Labeled Dropdown Prototype Steps
		//[RegexStepDefinition(@"On the My Products page, confirm (.*) dropdown (does|does not) exists")]
		public void MyProductsPageConfirmLabeledDropdownExists(string dropdownLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			Report.IsTrue(expected == myProductsPage.LabeledDropdownExists(dropdownLabel), $"Failure, failed to confirm '{dropdownLabel}' dropdown {does_doesnot} exist.", $"Success, confirmed '{dropdownLabel}' dropdown {does_doesnot} exist.");
		}

		//[RegexStepDefinition(@"On the My Products page, click the (.*) dropdown")]
		public void MyProductsPageClickLabeledDropdown(string dropdownLabel)
		{
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.LabeledDropdownExists(dropdownLabel), $"Failure, failed to confirm '{dropdownLabel}' dropdown does exist.", $"Success, confirmed '{dropdownLabel}' dropdown does exist."))
			{
				Report.IsTrue(myProductsPage.LabeledDropdownClick(dropdownLabel), $"Failure, failed to click '{dropdownLabel}' dropdown.", $"Success, clicked '{dropdownLabel}' dropdown.");
			}
		}

		//[RegexStepDefinition(@"On the My Products page, confirm the (.*) dropdown current value is: (.*)")]
		public void MyProductsPageConfirmLabeledDropdownValue(string dropdownLabel, string expectedValue)
		{
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.LabeledDropdownExists(dropdownLabel), $"Failure, failed to confirm '{dropdownLabel}' dropdown does exist.", $"Success, confirmed '{dropdownLabel}' dropdown does exist."))
			{
				string dropdownValue = myProductsPage.LabeledDropdownValue(dropdownLabel);
				Report.IsTrue(dropdownValue.Equals(expectedValue), $"Failure, '{dropdownLabel}' dropdown value '{dropdownValue}' is not expected value '{expectedValue}'.", $"Success, '{dropdownLabel}' dropdown value '{dropdownValue}' is same as expected.");
			}
		}

		//[RegexStepDefinition(@"On the My Products page, confirm the (.*) dropdown (.*) option (does|does not) exist")]
		public void MyProductsPageConfirmLabeledDropdownOptionExists(string dropdownLabel, string optionLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.LabeledDropdownExists(dropdownLabel), $"Failure, failed to confirm '{dropdownLabel}' dropdown does exist.", $"Success, confirmed '{dropdownLabel}' dropdown does exist."))
			{
				Report.IsTrue(expected == myProductsPage.LabeledDropdownOptionExists(dropdownLabel, optionLabel), $"Failure, failed to confirm '{dropdownLabel}' dropdown '{optionLabel}' {does_doesnot} exist.", $"Success, confirmed '{dropdownLabel}' dropdown '{optionLabel}' option {does_doesnot} exist.");
			}
		}

		//[RegexStepDefinition(@"On the My Products page, click the (.*) dropdown (.*) option")]
		public void MyProductsPageConfirmLabeledDropdownOptionClick(string dropdownLabel, string optionLabel)
		{
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.LabeledDropdownExists(dropdownLabel), $"Failure, failed to confirm '{dropdownLabel}' dropdown does exist.", $"Success, confirmed '{dropdownLabel}' dropdown does exist."))
			{
				Report.IsTrue(myProductsPage.LabeledDropdownOptionClick(dropdownLabel, optionLabel), $"Failure, failed to click '{dropdownLabel}' dropdown '{optionLabel}'.", $"Success, clicked '{dropdownLabel}' dropdown '{optionLabel}' option.");
			}
		}
		#endregion

		#region Text Search Prototype Steps
		//[RegexStepDefinition(@"On the My Products page, confirm (.*) text search (does|does not) exists")]
		public void MyProductsPageConfirmTextSearchExists(string textSearchLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			bool textSearchExists = new TextSearch(textSearchLabel) != null;
			Report.IsTrue(expected == textSearchExists, $"Failure, failed to confirm '{textSearchLabel}' text search {does_doesnot} exist.", $"Success, confirmed '{textSearchLabel}' text search {does_doesnot} exist.");
		}

		//[RegexStepDefinition(@"On the My Products page, confirm (.*) text search input (does|does not) exists")]
		public void MyProductsPageConfirmTextSearchInputExists(string textSearchLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			TextSearch textSearch = new TextSearch(textSearchLabel);
			if (Report.IsTrue(textSearch != null, $"Failure, failed to confirm '{textSearchLabel}' text search does exist.", $"Success, confirmed '{textSearchLabel}' text search does exist."))
			{
				Report.IsTrue(expected == textSearch.TextInputExists(), $"Failure, failed to confirm '{textSearchLabel}' text search input {does_doesnot} exist.", $"Success, confirmed '{textSearchLabel}' text search input {does_doesnot} exist.");
			}
		}

		//[RegexStepDefinition(@"On the My Products page, click (.*) text search input")]
		public void MyProductsPageTextSearchInputClick(string textSearchLabel)
		{
			TextSearch textSearch = new TextSearch(textSearchLabel);
			if (Report.IsTrue(textSearch != null, $"Failure, failed to confirm '{textSearchLabel}' text search does exist.", $"Success, confirmed '{textSearchLabel}' text search does exist."))
			{
				if (Report.IsTrue(textSearch.TextInputExists(), $"Failure, failed to confirm '{textSearchLabel}' text search input does exist.", $"Success, confirmed '{textSearchLabel}' text search input does exist."))
				{
					Report.IsTrue(textSearch.TextInputClick(), $"Failure, failed to click '{textSearchLabel}' text search input.", $"Success, clicked '{textSearchLabel}' text search input.");
				}
			}
		}

		//[RegexStepDefinition(@"On the My Products page, in (.*) text search input, enter text: (.*)")]
		public void MyProductsPageTextSearchInputEnterText(string textSearchLabel, string inputText)
		{
			TextSearch textSearch = new TextSearch(textSearchLabel);
			if (Report.IsTrue(textSearch != null, $"Failure, failed to confirm '{textSearchLabel}' text search does exist.", $"Success, confirmed '{textSearchLabel}' text search does exist."))
			{
				if (Report.IsTrue(textSearch.TextInputExists(), $"Failure, failed to confirm '{textSearchLabel}' text search input does exist.", $"Success, confirmed '{textSearchLabel}' text search input does exist."))
				{
					Report.IsTrue(textSearch.TextInputEnterText(inputText), $"Failure, in '{textSearchLabel}' text search input failed to enter '{inputText}' text.", $"Success, in '{textSearchLabel}' text search input entered '{inputText}' text.");
				}
			}
		}

		//[RegexStepDefinition(@"On the My Products page, confirm (.*) text search input (does|does not) have value: (.*)")]
		public void MyProductsPageTextSearchInputCompareText(string textSearchLabel, string does_doesnot, string expectedText)
		{
			bool expected = does_doesnot == "does";
			TextSearch textSearch = new TextSearch(textSearchLabel);
			if (Report.IsTrue(textSearch != null, $"Failure, failed to confirm '{textSearchLabel}' text search does exist.", $"Success, confirmed '{textSearchLabel}' text search does exist."))
			{
				if (Report.IsTrue(textSearch.TextInputExists(), $"Failure, failed to confirm '{textSearchLabel}' text search input does exist.", $"Success, confirmed '{textSearchLabel}' text search input does exist."))
				{
					string inputText = textSearch.TextInputTextGet();
					Report.IsTrue(expected == inputText.Equals(expectedText), $"Failure, in '{textSearchLabel}' text search input {does_doesnot} have value '{expectedText}'{(!expected ? "." : $" but '{inputText}'.")}", $"Success, in '{textSearchLabel}' text search input {does_doesnot} have value '{expectedText}'{(expected ? "." : $" but '{inputText}'.")}");
				}
			}
		}

		//[RegexStepDefinition(@"On the My Products page, confirm (.*) text search button (does|does not) exists")]
		public void MyProductsPageConfirmTextSearchButtonExists(string textSearchLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			TextSearch textSearch = new TextSearch(textSearchLabel);
			if (Report.IsTrue(textSearch != null, $"Failure, failed to confirm '{textSearchLabel}' text search does exist.", $"Success, confirmed '{textSearchLabel}' text search does exist."))
			{
				Report.IsTrue(expected == textSearch.SearchButtonExists(), $"Failure, failed to confirm '{textSearchLabel}' text search button {does_doesnot} exist.", $"Success, confirmed '{textSearchLabel}' text search button {does_doesnot} exist.");
			}
		}

		//[RegexStepDefinition(@"On the My Products page, click (.*) text search button")]
		public void MyProductsPageClickTextSearchButtonExists(string textSearchLabel)
		{
			TextSearch textSearch = new TextSearch(textSearchLabel);
			if (Report.IsTrue(textSearch != null, $"Failure, failed to confirm '{textSearchLabel}' text search does exist.", $"Success, confirmed '{textSearchLabel}' text search does exist."))
			{
				Report.IsTrue(textSearch.SearchButtonClick(), $"Failure, failed to click '{textSearchLabel}' text search button.", $"Success, clicked '{textSearchLabel}' text search button.");
			}
		}
		#endregion
		#endregion

		#region Page Info Icon Steps
		[RegexStepDefinition(@"On the My Products page, confirm page info icon (does|does not) exists")]
		public void MyProductsPageConfirmInfoIconExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			Report.IsTrue(expected == myProductsPage.PageInfoIconExists(), $"Failure, failed to confirm page info icon {does_doesnot} exist.", $"Success, confirmed page info icon {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page, hover over page info icon")]
		public void MyProductsPageConfirmInfoIconHover()
		{
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.PageInfoIconExists(), $"Failure, failed to confirm page info icon does exist.", $"Success, confirmed page info icon does exist."))
			{
				myProductsPage.PageInfoIconHover();
				Report.Success("Hovering over page info icon.");
			}
		}

		[RegexStepDefinition(@"On the My Products page, confirm page info text (is|is not) displayed")]
		public void MyProductsPageConfirmInfoTextDisplayed(string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue(myProductsPage.PageInfoIconExists(), $"Failure, failed to confirm page info icon does exist.", $"Success, confirmed page info icon does exist."))
			{
				Report.IsTrue(myProductsPage.PageInfoIconTextDisplayed(), $"Failure, failed to confirm page info text {is_isnot} displayed.", $"Success, confirmed page info text {is_isnot} displayed.");
			}
		}
		#endregion

		#region Status Filter List Steps
		[RegexStepDefinition(@"On the My Products page, status filter list (does|does not) exists")]
		public void MyProductsPageConfirmStatusFilterListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			Report.IsTrue(expected == (myProductsPage.StatusFilterListGet() != null), $"Failure, failed to confirm status filter list {does_doesnot} exist.", $"Success, confirmed status filter list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page, status filter (.*) (does|does not) exists")]
		public void MyProductsPageConfirmStatusFilterExists(string statusFilerLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsPage myProductsPage = new MyProductsPage();
			if (Report.IsTrue((myProductsPage.StatusFilterListGet() != null), $"Failure, failed to confirm status filter list does exist.", $"Success, confirmed status filter list does exist."))
			{
				Report.IsTrue(expected == myProductsPage.StatusFilterExists(statusFilerLabel), $"Failure, failed to confirm status filter {statusFilerLabel} {does_doesnot} exist.", $"Success, confirmed status filter {statusFilerLabel} {does_doesnot} exist.");
			}
		}
		#endregion

		#region My Products Table Header Steps
		#region More Filters Button Steps
		[RegexStepDefinition(@"On the My Products page, confirm More Filters button (does|does not) exists")]
		public void MyProductsPageConfirmMoreFiltersButtonExists(string does_doesnot)
		{
			string buttonLabel = "More Filters";
			this.MyProductsPageConfirmButtonExists(buttonLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click More Filters button.")]
		public void MyProductsPageClickMoreFiltersButton()
		{
			string buttonLabel = "More Filters";
			this.MyProductsPageClickButton(buttonLabel);
		}
		#endregion
		#region Bulk Actions Button Steps
		[RegexStepDefinition(@"On the My Products page, confirm Bulk Actions button (does|does not) exists")]
		public void MyProductsPageConfirmBulkActionsButtonExists(string does_doesnot)
		{
			string buttonLabel = "Bulk Actions";
			this.MyProductsPageConfirmButtonExists(buttonLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click Bulk Actions button.")]
		public void MyProductsPageClickBulkActionsButton()
		{
			string buttonLabel = "Bulk Actions";
			this.MyProductsPageClickButton(buttonLabel);
		}
		#endregion
		#region Product ID/Name Text Search Steps
		[RegexStepDefinition(@"On the My Products page, confirm Product ID/ Name text search (does|does not) exists")]
		public void MyProductsPageConfirmProductIDNameTextSearchExists(string does_doesnot)
		{
			string textSearchLabel = "Product ID/ Name";
			this.MyProductsPageConfirmTextSearchExists(textSearchLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, confirm Product ID/ Name text search input (does|does not) exists")]
		public void MyProductsPageConfirmProductIDNameTextSearchInputExists(string does_doesnot)
		{
			string textSearchLabel = "Product ID/ Name";
			this.MyProductsPageConfirmTextSearchInputExists(textSearchLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click Product ID/ Name text search input")]
		public void MyProductsPageProductIDNameTextSearchInputClick()
		{
			string textSearchLabel = "Product ID/ Name";
			this.MyProductsPageTextSearchInputClick(textSearchLabel);
		}

		[RegexStepDefinition(@"On the My Products page, in Product ID/ Name text search input, enter text: (.*)")]
		public void MyProductsPageProductIDNameTextSearchInputEnterText(string inputText)
		{
			string textSearchLabel = "Product ID/ Name";
			this.MyProductsPageTextSearchInputEnterText(textSearchLabel, inputText);
		}

		[RegexStepDefinition(@"On the My Products page, confirm Product ID/ Name text search button (does|does not) exists")]
		public void MyProductsPageConfirmProductIDNameTextSearchButtonExists(string does_doesnot)
		{
			string textSearchLabel = "Product ID/ Name";
			this.MyProductsPageConfirmTextSearchButtonExists(textSearchLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click Product ID/Name text search button")]
		public void MyProductsPageClickProductIDNameTextSearchButtonExists()
		{
			string textSearchLabel = "Product ID/ Name";
			this.MyProductsPageClickTextSearchButtonExists(textSearchLabel);
		}
		#endregion
		#region UPC Number Text Search Steps
		[RegexStepDefinition(@"On the My Products page, confirm UPC Number text search (does|does not) exists")]
		public void MyProductsPageConfirmUPCNumberTextSearchExists(string does_doesnot)
		{
			string textSearchLabel = "UPC Number";
			this.MyProductsPageConfirmTextSearchExists(textSearchLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, confirm UPC Number text search input (does|does not) exists")]
		public void MyProductsPageConfirmUPCNumberTextSearchInputExists(string does_doesnot)
		{
			string textSearchLabel = "UPC Number";
			this.MyProductsPageConfirmTextSearchInputExists(textSearchLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click UPC Number text search input")]
		public void MyProductsPageUPCNumberTextSearchInputClick()
		{
			string textSearchLabel = "UPC Number";
			this.MyProductsPageTextSearchInputClick(textSearchLabel);
		}

		[RegexStepDefinition(@"On the My Products page, in UPC Number text search input, enter text: (.*)")]
		public void MyProductsPageUPCNumberTextSearchInputEnterText(string inputText)
		{
			string textSearchLabel = "UPC Number";
			this.MyProductsPageTextSearchInputEnterText(textSearchLabel, inputText);
		}

		[RegexStepDefinition(@"On the My Products page, confirm UPC Number text search button (does|does not) exists")]
		public void MyProductsPageConfirmUPCNumberTextSearchButtonExists(string does_doesnot)
		{
			string textSearchLabel = "UPC Number";
			this.MyProductsPageConfirmTextSearchButtonExists(textSearchLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click UPC Number text search button")]
		public void MyProductsPageClickUPCNumberTextSearchButtonExists()
		{
			string textSearchLabel = "UPC Number";
			this.MyProductsPageClickTextSearchButtonExists(textSearchLabel);
		}
		#endregion
		#region Show Archived Retailers Checkbox
		[RegexStepDefinition(@"On the My Products page, confirm Show Archived Retailers checkbox (does|does not) exists")]
		public void MyProductsPageConfirmShowArchievedRetailersCheckboxExists(string does_doesnot)
		{
			string checkboxLabel = "Show Archived Retailers";
			this.MyProductsPageConfirmCheckboxExists(checkboxLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Show Archived Retailers checkbox")]
		public void MyProductsPageClickShowArchivedRetailersCheckbox()
		{
			string checkboxLabel = "Show Archived Retailers";
			this.MyProductsPageClickCheckbox(checkboxLabel);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Show Archived Retailers checkbox (is|is not) checked")]
		public void MyProductsPageShowArchivedRetailersCheckboxChecked(string is_isnot)
		{
			string checkboxLabel = "Show Archived Retailers";
			this.MyProductsPageCheckboxChecked(checkboxLabel, is_isnot);
		}

		[RegexStepDefinition(@"On the My Products page, (check|uncheck) the Show Archived Retailers checkbox")]
		public void MyProductsPageCheckUnCheckShowArchivedRetailersCheckbox(string check_uncheck)
		{
			string checkboxLabel = "Show Archived Retailers";
			this.MyProductsPageCheckUnCheckCheckbox(check_uncheck, checkboxLabel);
		}
		#endregion
		#endregion

		#region More Filters Panel Steps
		[RegexStepDefinition(@"On the My Products page, confirm the More Filters panel (is|is not) expanded")]
		public void MyProductsPageConfirmMoreFiltersPanelIsIsNotExpanded(string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsPage myProductsPage = new MyProductsPage();
			Report.IsTrue(expected == myProductsPage.MoreFiltersPanelExpanded(), $"Failure, failed to confirm More Filters panel {is_isnot} expanded.", $"Success, confirmed More Filters panel {is_isnot} expanded.");
		}

		#region Brand Labeled Dropdown Steps
		[RegexStepDefinition(@"On the My Products page, confirm Brand dropdown (does|does not) exists")]
		public void MyProductsPageConfirmBrandLabeledDropdownExists(string does_doesnot)
		{
			string dropdownLabel = "Brand";
			this.MyProductsPageConfirmLabeledDropdownExists(dropdownLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Brand dropdown")]
		public void MyProductsPageClickBrandLabeledDropdown()
		{
			string dropdownLabel = "Brand";
			this.MyProductsPageClickLabeledDropdown(dropdownLabel);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Brand dropdown current value is: (.*)")]
		public void MyProductsPageConfirmBrandLabeledDropdownValue(string expectedValue)
		{
			string dropdownLabel = "Brand";
			this.MyProductsPageConfirmLabeledDropdownValue(dropdownLabel, expectedValue);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Brand dropdown (.*) option (does|does not) exist")]
		public void MyProductsPageConfirmBrandLabeledDropdownOptionExists(string optionLabel, string does_doesnot)
		{
			string dropdownLabel = "Brand";
			this.MyProductsPageConfirmLabeledDropdownOptionExists(dropdownLabel, optionLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Brand dropdown (.*) option")]
		public void MyProductsPageConfirmBrandLabeledDropdownOptionClick(string optionLabel)
		{
			string dropdownLabel = "Brand";
			this.MyProductsPageConfirmLabeledDropdownOptionClick(dropdownLabel, optionLabel);
		}
		#endregion

		#region Subscription Labeled Dropdown Steps
		[RegexStepDefinition(@"On the My Products page, confirm Subscription dropdown (does|does not) exists")]
		public void MyProductsPageConfirmSubscriptionLabeledDropdownExists(string does_doesnot)
		{
			string dropdownLabel = "Subscription";
			this.MyProductsPageConfirmLabeledDropdownExists(dropdownLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Subscription dropdown")]
		public void MyProductsPageClickSubscriptionLabeledDropdown()
		{
			string dropdownLabel = "Subscription";
			this.MyProductsPageClickLabeledDropdown(dropdownLabel);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Subscription dropdown current value is: (.*)")]
		public void MyProductsPageConfirmSubscriptionLabeledDropdownValue(string expectedValue)
		{
			string dropdownLabel = "Subscription";
			this.MyProductsPageConfirmLabeledDropdownValue(dropdownLabel, expectedValue);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Subscription dropdown (.*) option (does|does not) exist")]
		public void MyProductsPageConfirmSubscriptionLabeledDropdownOptionExists(string optionLabel, string does_doesnot)
		{
			string dropdownLabel = "Subscription";
			this.MyProductsPageConfirmLabeledDropdownOptionExists(dropdownLabel, optionLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Subscription dropdown (.*) option")]
		public void MyProductsPageConfirmSubscriptionLabeledDropdownOptionClick(string optionLabel)
		{
			string dropdownLabel = "Subscription";
			this.MyProductsPageConfirmLabeledDropdownOptionClick(dropdownLabel, optionLabel);
		}
		#endregion

		#region Retailer Labeled Dropdown Steps
		[RegexStepDefinition(@"On the My Products page, confirm Retailer dropdown (does|does not) exists")]
		public void MyProductsPageConfirmRetailerLabeledDropdownExists(string does_doesnot)
		{
			string dropdownLabel = "Retailer";
			this.MyProductsPageConfirmLabeledDropdownExists(dropdownLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Retailer dropdown")]
		public void MyProductsPageClickRetailerLabeledDropdown()
		{
			string dropdownLabel = "Retailer";
			this.MyProductsPageClickLabeledDropdown(dropdownLabel);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Retailer dropdown current value is: (.*)")]
		public void MyProductsPageConfirmRetailerLabeledDropdownValue(string expectedValue)
		{
			string dropdownLabel = "Retailer";
			this.MyProductsPageConfirmLabeledDropdownValue(dropdownLabel, expectedValue);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Retailer dropdown (.*) option (does|does not) exist")]
		public void MyProductsPageConfirmRetailerLabeledDropdownOptionExists(string optionLabel, string does_doesnot)
		{
			string dropdownLabel = "Retailer";
			this.MyProductsPageConfirmLabeledDropdownOptionExists(dropdownLabel, optionLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Retailer dropdown (.*) option")]
		public void MyProductsPageConfirmRetailerLabeledDropdownOptionClick(string optionLabel)
		{
			string dropdownLabel = "Retailer";
			this.MyProductsPageConfirmLabeledDropdownOptionClick(dropdownLabel, optionLabel);
		}
		#endregion

		#region Additional Programs Labeled Dropdown Steps
		[RegexStepDefinition(@"On the My Products page, confirm Additional Programs dropdown (does|does not) exists")]
		public void MyProductsPageConfirmAdditionalProgramsLabeledDropdownExists(string does_doesnot)
		{
			string dropdownLabel = "Additional Programs";
			this.MyProductsPageConfirmLabeledDropdownExists(dropdownLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Additional Programs dropdown")]
		public void MyProductsPageClickAdditionalProgramsLabeledDropdown()
		{
			string dropdownLabel = "Additional Programs";
			this.MyProductsPageClickLabeledDropdown(dropdownLabel);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Additional Programs dropdown current value is: (.*)")]
		public void MyProductsPageConfirmAdditionalProgramsLabeledDropdownValue(string expectedValue)
		{
			string dropdownLabel = "Additional Programs";
			this.MyProductsPageConfirmLabeledDropdownValue(dropdownLabel, expectedValue);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Additional Programs dropdown (.*) option (does|does not) exist")]
		public void MyProductsPageConfirmAdditionalProgramsLabeledDropdownOptionExists(string optionLabel, string does_doesnot)
		{
			string dropdownLabel = "Additional Programs";
			this.MyProductsPageConfirmLabeledDropdownOptionExists(dropdownLabel, optionLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Additional Programs dropdown (.*) option")]
		public void MyProductsPageConfirmAdditionalProgramsLabeledDropdownOptionClick(string optionLabel)
		{
			string dropdownLabel = "Additional Programs";
			this.MyProductsPageConfirmLabeledDropdownOptionClick(dropdownLabel, optionLabel);
		}
		#endregion

		#region Revisions In Progress Labeled Dropdown Steps
		[RegexStepDefinition(@"On the My Products page, confirm Revisions In Progress dropdown (does|does not) exists")]
		public void MyProductsPageConfirmRevisionsInProgressLabeledDropdownExists(string does_doesnot)
		{
			string dropdownLabel = "Revisions In Progress";
			this.MyProductsPageConfirmLabeledDropdownExists(dropdownLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Revisions In Progress dropdown")]
		public void MyProductsPageClickRevisionsInProgressLabeledDropdown()
		{
			string dropdownLabel = "Revisions In Progress";
			this.MyProductsPageClickLabeledDropdown(dropdownLabel);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Revisions In Progress dropdown current value is: (.*)")]
		public void MyProductsPageConfirmRevisionsInProgressLabeledDropdownValue(string expectedValue)
		{
			string dropdownLabel = "Revisions In Progress";
			this.MyProductsPageConfirmLabeledDropdownValue(dropdownLabel, expectedValue);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Revisions In Progress dropdown (.*) option (does|does not) exist")]
		public void MyProductsPageConfirmRevisionsInProgressLabeledDropdownOptionExists(string optionLabel, string does_doesnot)
		{
			string dropdownLabel = "Revisions In Progress";
			this.MyProductsPageConfirmLabeledDropdownOptionExists(dropdownLabel, optionLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Revisions In Progress dropdown (.*) option")]
		public void MyProductsPageConfirmRevisionsInProgressLabeledDropdownOptionClick(string optionLabel)
		{
			string dropdownLabel = "Revisions In Progress";
			this.MyProductsPageConfirmLabeledDropdownOptionClick(dropdownLabel, optionLabel);
		}
		#endregion

		#region Type Labeled Dropdown Steps
		[RegexStepDefinition(@"On the My Products page, confirm Type dropdown (does|does not) exists")]
		public void MyProductsPageConfirmTypeLabeledDropdownExists(string does_doesnot)
		{
			string dropdownLabel = "Type";
			this.MyProductsPageConfirmLabeledDropdownExists(dropdownLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Type dropdown")]
		public void MyProductsPageClickTypeLabeledDropdown()
		{
			string dropdownLabel = "Type";
			this.MyProductsPageClickLabeledDropdown(dropdownLabel);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Type dropdown current value is: (.*)")]
		public void MyProductsPageConfirmTypeLabeledDropdownValue(string expectedValue)
		{
			string dropdownLabel = "Type";
			this.MyProductsPageConfirmLabeledDropdownValue(dropdownLabel, expectedValue);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Type dropdown (.*) option (does|does not) exist")]
		public void MyProductsPageConfirmTypeLabeledDropdownOptionExists(string optionLabel, string does_doesnot)
		{
			string dropdownLabel = "Type";
			this.MyProductsPageConfirmLabeledDropdownOptionExists(dropdownLabel, optionLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Type dropdown (.*) option")]
		public void MyProductsPageConfirmTypeLabeledDropdownOptionClick(string optionLabel)
		{
			string dropdownLabel = "Type";
			this.MyProductsPageConfirmLabeledDropdownOptionClick(dropdownLabel, optionLabel);
		}
		#endregion

		#region Watching Checkbox
		[RegexStepDefinition(@"On the My Products page, confirm Watching checkbox (does|does not) exists")]
		public void MyProductsPageConfirmWatchingCheckboxExists(string does_doesnot)
		{
			string checkboxLabel = "Watching";
			this.MyProductsPageConfirmCheckboxExists(checkboxLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Watching checkbox")]
		public void MyProductsPageClickWatchingCheckbox()
		{
			string checkboxLabel = "Watching";
			this.MyProductsPageClickCheckbox(checkboxLabel);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Watching checkbox (is|is not) checked")]
		public void MyProductsPageWatchingCheckboxChecked(string is_isnot)
		{
			string checkboxLabel = "Watching";
			this.MyProductsPageCheckboxChecked(checkboxLabel, is_isnot);
		}

		[RegexStepDefinition(@"On the My Products page, (check|uncheck) the Watching checkbox")]
		public void MyProductsPageCheckUnCheckWatchingCheckbox(string check_uncheck)
		{
			string checkboxLabel = "Watching";
			this.MyProductsPageCheckUnCheckCheckbox(check_uncheck, checkboxLabel);
		}
		#endregion

		#region Show Only Discontinued Products Checkbox
		[RegexStepDefinition(@"On the My Products page, confirm Show Only Discontinued Products checkbox (does|does not) exists")]
		public void MyProductsPageConfirmShowOnlyDiscontinuedProductsCheckboxExists(string does_doesnot)
		{
			string checkboxLabel = "Show Only Discontinued Products";
			this.MyProductsPageConfirmCheckboxExists(checkboxLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Show Only Discontinued Products checkbox")]
		public void MyProductsPageClickShowOnlyDiscontinuedProductsCheckbox()
		{
			string checkboxLabel = "Show Only Discontinued Products";
			this.MyProductsPageClickCheckbox(checkboxLabel);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Show Only Discontinued Products checkbox (is|is not) checked")]
		public void MyProductsPageShowOnlyDiscontinuedProductsCheckboxChecked(string is_isnot)
		{
			string checkboxLabel = "Show Only Discontinued Products";
			this.MyProductsPageCheckboxChecked(checkboxLabel, is_isnot);
		}

		[RegexStepDefinition(@"On the My Products page, (check|uncheck) the Show Only Discontinued Products checkbox")]
		public void MyProductsPageCheckUnCheckShowOnlyDiscontinuedProductsCheckbox(string check_uncheck)
		{
			string checkboxLabel = "Show Only Discontinued Products";
			this.MyProductsPageCheckUnCheckCheckbox(check_uncheck, checkboxLabel);
		}
		#endregion

		#region Show Only Single Retailer Products Checkbox
		[RegexStepDefinition(@"On the My Products page, confirm Show Only Single Retailer Products checkbox (does|does not) exists")]
		public void MyProductsPageConfirmShowOnlySingleRetailerProductsCheckboxExists(string does_doesnot)
		{
			string checkboxLabel = "Show Only Single Retailer Products";
			this.MyProductsPageConfirmCheckboxExists(checkboxLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Show Only Single Retailer Products checkbox")]
		public void MyProductsPageClickShowOnlySingleRetailerProductsCheckbox()
		{
			string checkboxLabel = "Show Only Single Retailer Products";
			this.MyProductsPageClickCheckbox(checkboxLabel);
		}

		[RegexStepDefinition(@"On the My Products page, confirm the Show Only Single Retailer Products checkbox (is|is not) checked")]
		public void MyProductsPageShowOnlySingleRetailerProductsCheckboxChecked(string is_isnot)
		{
			string checkboxLabel = "Show Only Single Retailer Products";
			this.MyProductsPageCheckboxChecked(checkboxLabel, is_isnot);
		}

		[RegexStepDefinition(@"On the My Products page, (check|uncheck) the Show Only Single Retailer Products checkbox")]
		public void MyProductsPageCheckUnCheckShowOnlySingleRetailerProductsCheckbox(string check_uncheck)
		{
			string checkboxLabel = "Show Only Single Retailer Products";
			this.MyProductsPageCheckUnCheckCheckbox(check_uncheck, checkboxLabel);
		}
		#endregion

		#region Product ID, Ingredient ID, SKU Text Search Steps
		[RegexStepDefinition(@"On the My Products page, confirm Product ID, Ingredient ID, SKU text search (does|does not) exists")]
		public void MyProductsPageConfirmProductIDIngredientIDSKUTextSearchExists(string does_doesnot)
		{
			string textSearchLabel = "Product ID, Ingredient ID, SKU";
			this.MyProductsPageConfirmTextSearchExists(textSearchLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, confirm Product ID, Ingredient ID, SKU text search input (does|does not) exists")]
		public void MyProductsPageConfirmProductIDIngredientIDSKUTextSearchInputExists(string does_doesnot)
		{
			string textSearchLabel = "Product ID, Ingredient ID, SKU";
			this.MyProductsPageConfirmTextSearchInputExists(textSearchLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click Product ID, Ingredient ID, SKU text search input")]
		public void MyProductsPageProductIDIngredientIDSKUTextSearchInputClick()
		{
			string textSearchLabel = "Product ID, Ingredient ID, SKU";
			this.MyProductsPageTextSearchInputClick(textSearchLabel);
		}

		[RegexStepDefinition(@"On the My Products page, in Product ID, Ingredient ID, SKU text search input, enter text: (.*)")]
		public void MyProductsPageProductIDIngredientIDSKUTextSearchInputEnterText(string inputText)
		{
			string textSearchLabel = "Product ID, Ingredient ID, SKU";
			this.MyProductsPageTextSearchInputEnterText(textSearchLabel, inputText);
		}

		[RegexStepDefinition(@"On the My Products page, confirm Product ID, Ingredient ID, SKU text search input (does|does not) have value: (.*)")]
		public void MyProductsPageProductIDIngredientIDSKUTextSearchInputCompareText(string does_doesnot, string expectedText)
		{
			string textSearchLabel = "Product ID, Ingredient ID, SKU";
			this.MyProductsPageTextSearchInputCompareText(textSearchLabel, does_doesnot, expectedText);
		}

		[RegexStepDefinition(@"On the My Products page, confirm Product ID, Ingredient ID, SKU text search button (does|does not) exists")]
		public void MyProductsPageConfirmProductIDIngredientIDSKUTextSearchButtonExists(string does_doesnot)
		{
			string textSearchLabel = "Product ID, Ingredient ID, SKU";
			this.MyProductsPageConfirmTextSearchButtonExists(textSearchLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click Product ID, Ingredient ID, SKU text search button")]
		public void MyProductsPageClickProductIDIngredientIDSKUTextSearchButtonExists()
		{
			string textSearchLabel = "Product ID, Ingredient ID, SKU";
			this.MyProductsPageClickTextSearchButtonExists(textSearchLabel);
		}
		#endregion

		#region Close Button Steps
		[RegexStepDefinition(@"On the My Products page, confirm Close button (does|does not) exists")]
		public void MyProductsPageConfirmCloseButtonExists(string does_doesnot)
		{
			string buttonLabel = "Close";
			this.MyProductsPageConfirmButtonExists(buttonLabel, does_doesnot);
		}

		[RegexStepDefinition(@"On the My Products page, click the Close button")]
		public void MyProductsPageClickCloseButton()
		{
			string buttonLabel = "Close";
			this.MyProductsPageClickButton(buttonLabel);
		}
		#endregion
		#endregion

		#region My Products Table Steps
		[RegexStepDefinition(@"On the My Products page, confirm the My Products table (does|does not) exist")]
		public void MyProductsPageConfirmTableDoesDoesNotExist(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTable myProductsTable = new MyProductsTable();
			Report.IsTrue(expected == (myProductsTable != null), $"Failure, failed to confirm My Products table {does_doesnot} exist.", $"Success, confirmed My Products table {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page, confirm the My Products table column labels list (does|does not) exist")]
		public void MyProductsPageConfirmTableColumnLabelsListDoesDoesNotExist(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTable myProductsTable = new MyProductsTable();
			Report.IsTrue(expected == !myProductsTable.ColumnLabelsListGet().IsNullOrEmpty(), $"Failure, failed to confirm My Products table column label list {does_doesnot} exist.", $"Success, confirmed My Products table column label list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page, confirm the My Products table (.*) column (is|is not) displayed")]
		public void MyProductsPageConfirmTableColumnDoesDoesNotExist(string columnLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsTable myProductsTable = new MyProductsTable();
			Report.IsTrue(expected == myProductsTable.ColumnLabelDisplayed(columnLabel), $"Failure, failed to confirm My Products table {columnLabel} column {is_isnot} displayed.", $"Success, confirmed My Products table {columnLabel} column {is_isnot} displayed.");
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table, confirm row with '(.*)' as Product Name (does|does not) exist")]
		public void MyProductTableConfirmProductNameRowDoesDoesNotExist(string productName, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTable myProductsTable = new MyProductsTable();
			Report.IsTrue(expected == !myProductsTable.ProductRowByNameGet(productName).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productName}' as Product Name {does_doesnot} exist.", $"Success, confirmed row with '{productName}' as Product Name {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table, confirm row with '(.*)' as Product ID (does|does not) exist")]
		public void MyProductTableConfirmProductIDRowDoesDoesNotExist(string productID, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTable myProductsTable = new MyProductsTable();
			Report.IsTrue(expected == !myProductsTable.ProductRowByIDGet(productID).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productID}' as Product ID {does_doesnot} exist.", $"Success, confirmed row with '{productID}' as Product ID {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table in row with '(.*)' as Product Name, confirm (Date Created|Date Revised|Date Discontinued) column (does|does not) have value: (.*)")]
		public void MyProductTableConfirmProductNameRowColumnDoesDoesNotHaveValue(string productName, string columnLabel, string does_doesnot, string valueExpected)
		{
			bool expected = does_doesnot == "does";
			MyProductsTable myProductsTable = new MyProductsTable();
			if (Report.IsTrue(!myProductsTable.ProductRowByNameGet(productName).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productName}' as Product Name does exist.", $"Success, confirmed row with '{productName}' as Product Name does exist."))
			{
				string valueDisplayed = "";
				switch (columnLabel)
				{
					case "Date Created":
						valueDisplayed = myProductsTable.ProductRowByNameGet(productName).DateCreated;
						break;
					case "Date Revised":
						valueDisplayed = myProductsTable.ProductRowByNameGet(productName).DateRevised;
						break;
					case "Date Discontinued":
						valueDisplayed = myProductsTable.ProductRowByNameGet(productName).DateDiscontinued;
						break;
					default:
						Report.Error($"Error: '{columnLabel}' column label not recognized");
						break;
				}
				Report.IsTrue(expected == valueDisplayed.Equals(valueExpected), $"Failure, failed to confirm row with '{productName}' as Product Name with '{columnLabel}' column {does_doesnot} have value '{valueExpected}'.", $"Success, confirmed row with '{productName}' as Product Name with '{columnLabel}' column {does_doesnot} have value '{valueExpected}'.");
			}
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table in row with '(.*)' as Product ID, confirm (Date Created|Date Revised|Date Discontinued) column (does|does not) have value: (.*)")]
		public void MyProductTableConfirmProductIDRowColumnDoesDoesNotHaveValue(string productID, string columnLabel, string does_doesnot, string valueExpected)
		{
			bool expected = does_doesnot == "does";
			MyProductsTable myProductsTable = new MyProductsTable();
			if (Report.IsTrue(!myProductsTable.ProductRowByIDGet(productID).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productID}' as Product ID does exist.", $"Success, confirmed row with '{productID}' as Product ID does exist."))
			{
				string valueDisplayed = "";
				switch (columnLabel)
				{
					case "Date Created":
						valueDisplayed = myProductsTable.ProductRowByIDGet(productID).DateCreated;
						break;
					case "Date Revised":
						valueDisplayed = myProductsTable.ProductRowByIDGet(productID).DateRevised;
						break;
					case "Date Discontinued":
						valueDisplayed = myProductsTable.ProductRowByIDGet(productID).DateDiscontinued;
						break;
					default:
						Report.Error($"Error: '{columnLabel}' column label not recognized");
						break;
				}
				Report.IsTrue(expected == valueDisplayed.Equals(valueExpected), $"Failure, failed to confirm row with '{productID}' as Product ID with '{columnLabel}' column {does_doesnot} have value '{valueExpected}'.", $"Success, confirmed row with '{productID}' as Product ID with '{columnLabel}' column {does_doesnot} have value '{valueExpected}'.");
			}
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table row with '(.*)' as Product Name, confirm Actions button (does|does not) exist")]
		public void MyProductTableProductNameRowConfirmActionsButtonDoesDoesNotExist(string productName, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTable myProductsTable = new MyProductsTable();
			if (Report.IsTrue(!myProductsTable.ProductRowByNameGet(productName).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productName}' as Product Name does exist.", $"Success, confirmed row with '{productName}' as Product Name does exist."))
			{
				Report.IsTrue(expected == myProductsTable.ProductRowByNameGet(productName).ActionsButtonExists(), $"Failure, failed to confirm row with '{productName}' as Product Name Action button {does_doesnot} exist.", $"Success, confirmed row with '{productName}' as Product Name Action button {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table row with '(.*)' as Product ID, confirm Actions button (does|does not) exist")]
		public void MyProductTableProductIDRowConfirmActionsButtonDoesDoesNotExist(string productID, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTable myProductsTable = new MyProductsTable();
			if (Report.IsTrue(!myProductsTable.ProductRowByIDGet(productID).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productID}' as Product ID does exist.", $"Success, confirmed row with '{productID}' as Product ID does exist."))
			{
				Report.IsTrue(expected == myProductsTable.ProductRowByIDGet(productID).ActionsButtonExists(), $"Failure, failed to confirm row with '{productID}' as Product ID Action button {does_doesnot} exist.", $"Success, confirmed row with '{productID}' as Product ID Action button {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table row with '(.*)' as Product Name, click Actions button")]
		public void MyProductTableProductNameRowActionsButtonClick(string productName)
		{
			MyProductsTable myProductsTable = new MyProductsTable();
			if (Report.IsTrue(!myProductsTable.ProductRowByNameGet(productName).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productName}' as Product Name does exist.", $"Success, confirmed row with '{productName}' as Product Name does exist."))
			{
				if (Report.IsTrue(myProductsTable.ProductRowByNameGet(productName).ActionsButtonExists(), $"Failure, failed to confirm row with '{productName}' as Product Name Action button does exist.", $"Success, confirmed row with '{productName}' as Product Name Action button does exist."))
				{
					Report.IsTrue(myProductsTable.ProductRowByNameGet(productName).ActionsButtonClick(), $"Failure, failed to click row with '{productName}' as Product Name Action button.", $"Success, clicked row with '{productName}' as Product Name Action button.");
				}
			}
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table row with '(.*)' as Product ID, click Actions button")]
		public void MyProductTableProductIDRowClickActionsButton(string productID)
		{
			MyProductsTable myProductsTable = new MyProductsTable();
			if (Report.IsTrue(!myProductsTable.ProductRowByIDGet(productID).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productID}' as Product ID does exist.", $"Success, confirmed row with '{productID}' as Product ID does exist."))
			{
				if (Report.IsTrue(myProductsTable.ProductRowByIDGet(productID).ActionsButtonExists(), $"Failure, failed to confirm row with '{productID}' as Product ID Action button does exist.", $"Success, confirmed row with '{productID}' as Product ID Action button does exist."))
				{
					Report.IsTrue(myProductsTable.ProductRowByIDGet(productID).ActionsButtonClick(), $"Failure, failed to click row with '{productID}' as Product ID Action button.", $"Success, clicked row with '{productID}' as Product ID Action button.");
				}
			}
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table row with '(.*)' as Product Name, confirm Actions button menu (is|is not) displayed")]
		public void MyProductTableProductNameRowConfirmActionsButtonMenuIsIsNotDisplayed(string productName, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsTable myProductsTable = new MyProductsTable();
			if (Report.IsTrue(!myProductsTable.ProductRowByNameGet(productName).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productName}' as Product Name does exist.", $"Success, confirmed row with '{productName}' as Product Name does exist."))
			{
				if (Report.IsTrue(myProductsTable.ProductRowByNameGet(productName).ActionsButtonExists(), $"Failure, failed to confirm row with '{productName}' as Product Name Action button does exist.", $"Success, confirmed row with '{productName}' as Product Name Action button does exist."))
				{
					Report.IsTrue(myProductsTable.ProductRowByNameGet(productName).ActionsButtonMenuOpen(), $"Failure, failed to confirm row with '{productName}' as Product Name Action button menu {is_isnot} displayed.", $"Success, confirmed row with '{productName}' as Product Name Action button menu {is_isnot} displayed.");
				}
			}
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table row with '(.*)' as Product ID, confirm Actions button menu (is|is not) displayed")]
		public void MyProductTableProductIDRowConfirmActionsButtonMenuIsIsNotDisplayed(string productID, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsTable myProductsTable = new MyProductsTable();
			if (Report.IsTrue(!myProductsTable.ProductRowByIDGet(productID).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productID}' as Product ID does exist.", $"Success, confirmed row with '{productID}' as Product ID does exist."))
			{
				if (Report.IsTrue(myProductsTable.ProductRowByIDGet(productID).ActionsButtonExists(), $"Failure, failed to confirm row with '{productID}' as Product ID Action button does exist.", $"Success, confirmed row with '{productID}' as Product ID Action button does exist."))
				{
					Report.IsTrue(myProductsTable.ProductRowByIDGet(productID).ActionsButtonMenuOpen(), $"Failure, failed to confirm row with '{productID}' as Product Name Action button menu {is_isnot} displayed.", $"Success, confirmed row with '{productID}' as Product Name Action button menu {is_isnot} displayed.");
				}
			}
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table row with '(.*)' as Product Name, confirm Actions button '(.*)' option (does|does not) exist")]
		public void MyProductTableProductNameRowConfirmActionsButtonOptionDoesDoesNotExists(string productName, string optionLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTable myProductsTable = new MyProductsTable();
			if (Report.IsTrue(!myProductsTable.ProductRowByNameGet(productName).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productName}' as Product Name does exist.", $"Success, confirmed row with '{productName}' as Product Name does exist."))
			{
				if (Report.IsTrue(myProductsTable.ProductRowByNameGet(productName).ActionsButtonExists(), $"Failure, failed to confirm row with '{productName}' as Product Name Action button does exist.", $"Success, confirmed row with '{productName}' as Product Name Action button does exist."))
				{
					Report.IsTrue(expected == myProductsTable.ProductRowByNameGet(productName).ActionsButtonOptionExists(optionLabel), $"Failure, failed to confirm row with '{productName}' as Product Name Action button '{optionLabel}' option {does_doesnot} exist.", $"Success, confirmed row with '{productName}' as Product Name Action button '{optionLabel}' option {does_doesnot} exist.");
				}
			}
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table row with '(.*)' as Product ID, confirm Actions button '(.*)' option (does|does not) exist")]
		public void MyProductTableProductIDRowConfirmActionsButtonOptionDoesDoesNotExists(string productID, string optionLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTable myProductsTable = new MyProductsTable();
			if (Report.IsTrue(!myProductsTable.ProductRowByIDGet(productID).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productID}' as Product ID does exist.", $"Success, confirmed row with '{productID}' as Product ID does exist."))
			{
				if (Report.IsTrue(myProductsTable.ProductRowByIDGet(productID).ActionsButtonExists(), $"Failure, failed to confirm row with '{productID}' as Product ID Action button does exist.", $"Success, confirmed row with '{productID}' as Product ID Action button does exist."))
				{
					Report.IsTrue(expected == myProductsTable.ProductRowByIDGet(productID).ActionsButtonOptionExists(optionLabel), $"Failure, failed to confirm row with '{productID}' as Product ID Action button '{optionLabel}' option {does_doesnot} exist.", $"Success, confirmed row with '{productID}' as Product ID Action button '{optionLabel}' option {does_doesnot} exist.");
				}
			}
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table row with '(.*)' as Product Name, click Actions button '(.*)' option")]
		public void MyProductTableProductNameRowClicActionsButtonOption(string productName, string optionLabel)
		{
			MyProductsTable myProductsTable = new MyProductsTable();
			if (Report.IsTrue(!myProductsTable.ProductRowByNameGet(productName).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productName}' as Product Name does exist.", $"Success, confirmed row with '{productName}' as Product Name does exist."))
			{
				if (Report.IsTrue(myProductsTable.ProductRowByNameGet(productName).ActionsButtonExists(), $"Failure, failed to confirm row with '{productName}' as Product Name Action button does exist.", $"Success, confirmed row with '{productName}' as Product Name Action button does exist."))
				{
					Report.IsTrue(myProductsTable.ProductRowByNameGet(productName).ActionsButtonOptionClick(optionLabel), $"Failure, failed to click row with '{productName}' as Product Name Action button '{optionLabel}' option.", $"Success, clicked row with '{productName}' as Product Name Action button '{optionLabel}' option.");
				}
			}
		}

		[RegexStepDefinition(@"On the My Products page in the My Products table row with '(.*)' as Product ID, click Actions button '(.*)' option")]
		public void MyProductTableProductIDRowClicActionsButtonOption(string productID, string optionLabel)
		{
			MyProductsTable myProductsTable = new MyProductsTable();
			if (Report.IsTrue(!myProductsTable.ProductRowByIDGet(productID).IsNullOrEmpty(), $"Failure, failed to confirm row with '{productID}' as Product ID does exist.", $"Success, confirmed row with '{productID}' as Product ID does exist."))
			{
				if (Report.IsTrue(myProductsTable.ProductRowByIDGet(productID).ActionsButtonExists(), $"Failure, failed to confirm row with '{productID}' as Product ID Action button does exist.", $"Success, confirmed row with '{productID}' as Product ID Action button does exist."))
				{
					Report.IsTrue(myProductsTable.ProductRowByIDGet(productID).ActionsButtonOptionClick(optionLabel), $"Failure, failed to click row with '{productID}' as Product ID Action button '{optionLabel}' option.", $"Success, clicked row with '{productID}' as Product ID Action button '{optionLabel}' option.");
				}
			}
		}
		#endregion

		#region My Products Table Footer Steps
		#region Items On Page Dropdown Steps
		[RegexStepDefinition(@"On the My Products page, confirm Items On Page dropdown (does|does not) exist")]
		public void MyProductsPageConfirmItemsOnPageDropdownDoesDoesNotExist(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTableFooter myProductsTableFooter = new MyProductsTableFooter();
			Report.IsTrue(expected == myProductsTableFooter.ItemsOnPageSelectExists(), $"Failure, failed to confirm Items On Page dropdown {does_doesnot} exist.", $"Success, confirmed Items On Page dropdown {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page, click Items On Page dropdown")]
		public void MyProductsPageClickItemsOnPageDropdown()
		{
			MyProductsTableFooter myProductsTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductsTableFooter.ItemsOnPageSelectExists(), $"Failure, failed to confirm Items On Page dropdown does exist.", $"Success, confirmed Items On Page dropdown does exist."))
			{
				Report.IsTrue(myProductsTableFooter.ItemsOnPageSelectClick(), $"Failure, failed to click Items On Page dropdown.", $"Success, clicked Items On Page dropdown.");
			}
		}

		[RegexStepDefinition(@"On the My Products page, Items On Page dropdown (10|25|50|75|100) option (does|does not) exists")]
		public void MyProductPageItemsOnPageDropdownOptionExists(string optionLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTableFooter myProductsTableFooter = new MyProductsTableFooter();
			Report.IsTrue(expected == myProductsTableFooter.ItemsOnPageSelectOptionExists(optionLabel), $"Failure, failed to confirm Items On Page dropdown {optionLabel} option {does_doesnot} exist.", $"Success, confirmed Items On Page {optionLabel} option {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page, click Items On Page dropdown (10|25|50|75|100) option")]
		public void MyProductPageClickItemsOnPageDropdownOption(string optionLabel)
		{
			MyProductsTableFooter myProductsTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductsTableFooter.ItemsOnPageSelectOptionExists(optionLabel), $"Failure, failed to confirm Items On Page dropdown {optionLabel} option does exist.", $"Success, confirmed Items On Page {optionLabel} option does exist."))
			{
				Report.IsTrue(myProductsTableFooter.ItemsOnPageSelectOptionClick(optionLabel), $"Failure, failed to click Items On Page dropdown {optionLabel} option.", $"Success, clicked Items On Page dropdown {optionLabel} option.");
			}
		}

		[RegexStepDefinition(@"On the My Products page, confirm Items On Page dropdown (10|25|50|75|100) option (is|is not) selected")]
		public void MyProductPageConfirmItemsOnPageDropdownOptionIsIsNotSelected(string optionExpected, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsTableFooter myProductsTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductsTableFooter.ItemsOnPageSelectOptionExists(optionExpected), $"Failure, failed to confirm Items On Page dropdown {optionExpected} option does exist.", $"Success, confirmed Items On Page {optionExpected} option does exist."))
			{
				string optionCurrent = myProductsTableFooter.ItemsOnPageSelectValue();
				Report.IsTrue(expected == optionCurrent.Equals(optionExpected), $"Failure, failed to confirm Items On Page dropdown {optionExpected} option {is_isnot} selected.", $"Success, confirmed Items On Page dropdown {optionExpected} option {is_isnot} selected.");
			}
		}
		#endregion

		#region Pagiation Button Steps
		[RegexStepDefinition(@"On the My Products page, confirm (Prev|…|Next|\d+) Pagination button (does|does not) exist")]
		public void MyProductsPageConfirmPagiationButtonDoesDoesNotExist(string buttonLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			Report.IsTrue(expected == myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button {does_doesnot} exist.", $"Success, confirmed {buttonLabel} pagination button {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"On the My Products page, click (Prev|…|Next|\d+) Pagination button")]
		public void MyProductsPageClickPagiationButton(string buttonLabel)
		{
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button does exist.", $"Success, confirmed {buttonLabel} pagination button does exist."))
			{
				Report.IsTrue(myProductTableFooter.PaginationButtonClick(buttonLabel), $"Failure, failed to click {buttonLabel} pagination button.", $"Success, click {buttonLabel} pagination button currently selected.");
			}
		}

		[RegexStepDefinition(@"On the My Products page, confirm (Prev|…|Next|\d+) Pagination button (is|is not) disabled")]
		public void MyProductsPageConfirmPagiationButtonIsIsNotDisabled(string buttonLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button does exist.", $"Success, confirmed {buttonLabel} pagination button does exist."))
			{
				Report.IsTrue(expected == myProductTableFooter.PaginationButtonDisabled(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button {is_isnot} disabled.", $"Success, confirmed {buttonLabel} pagination button {is_isnot} disabled.");
			}
		}

		[RegexStepDefinition(@"On the My Products page, confirm (Prev|…|Next|\d+) Pagination button (is|is not) currently selected")]
		public void MyProductsPageConfirmPagiationButtonIsIsNotSelected(string buttonLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			MyProductsTableFooter myProductTableFooter = new MyProductsTableFooter();
			if (Report.IsTrue(myProductTableFooter.PaginationButtonExists(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button does exist.", $"Success, confirmed {buttonLabel} pagination button does exist."))
			{
				Report.IsTrue(expected == myProductTableFooter.PaginationButtonCurrent(buttonLabel), $"Failure, failed to confirm {buttonLabel} pagination button {is_isnot} currently selected.", $"Success, confirmed {buttonLabel} pagination button {is_isnot} currently selected.");
			}
		}
		#endregion
		#endregion

		#region Bulk Actions Modal Steps
		[RegexStepDefinition(@"Confirm Bulk Actions modal (does|does not) exists")]
		public void MyProductsPageConfirmBulkActionsModalExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			Report.IsTrue(expected == (bulkActionsModal != null), $"Failure, failed to confirm Bulk Actions modal {does_doesnot} exist.", $"Success, confirmed Bulk Actions modal {does_doesnot} exists.");
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, confirm Close button (does|does not) exists")]
		public void BulkActionsModalConfirmCloseButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			Report.IsTrue(expected == bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal close button {does_doesnot} exist.", $"Success, confirmed Bulk Actions modal close button {does_doesnot} exists.");
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, Click close button")]
		public void BulkActionsModalClickCloseButton()
		{
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			if (Report.IsTrue(bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal close button does exist.", $"Success, confirmed Bulk Actions modal close button does exists."))
			{
				Report.IsTrue(bulkActionsModal.CloseButtonClick(), $"Failure, failed to click Bulk Actions modal close button.", $"Success, clicked Bulk Actions modal clased button.");
			}
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, confirm Forward Product Registration button (does|does not) exists")]
		public void BulkActionsModalConfirmForwardProductRegistrationButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			Report.IsTrue(expected == bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Forward Product Registration button {does_doesnot} exist.", $"Success, confirmed Bulk Actions modal Forward Product Registration button {does_doesnot} exists.");
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, click Forward Product Registration button")]
		public void BulkActionsModalClickForwardProductRegistrationButton()
		{
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			if (Report.IsTrue(bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Forward Product Registration button does exist.", $"Success, confirmed Bulk Actions modal Forward Product Registration button does exists."))
			{
				Report.IsTrue(bulkActionsModal.CloseButtonClick(), $"Failure, failed to click Bulk Actions modal Forward Product Registration button.", $"Success, clicked Bulk Actions modal Forward Product Registration button.");
			}
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, confirm Accept Documents button (does|does not) exists")]
		public void BulkActionsModalConfirmAcceptDocumentsButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			Report.IsTrue(expected == bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Accept Documents button {does_doesnot} exist.", $"Success, confirmed Bulk Actions modal Accept Documents button {does_doesnot} exists.");
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, click Accept Documents button")]
		public void BulkActionsModalClickAcceptDocumentsButton()
		{
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			if (Report.IsTrue(bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Accept Documents button does exist.", $"Success, confirmed Bulk Actions modal Accept Documents button does exists."))
			{
				Report.IsTrue(bulkActionsModal.CloseButtonClick(), $"Failure, failed to click Bulk Actions modal Accept Documents button.", $"Success, clicked Bulk Actions modal Accept Documents button.");
			}
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, confirm Delete Products button (does|does not) exists")]
		public void BulkActionsModalConfirmDeleteProductsButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			Report.IsTrue(expected == bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Delete Products button {does_doesnot} exist.", $"Success, confirmed Bulk Actions modal Delete Products button {does_doesnot} exists.");
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, click Delete Products button")]
		public void BulkActionsModalClickDeleteProductsButton()
		{
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			if (Report.IsTrue(bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Delete Products button does exist.", $"Success, confirmed Bulk Actions modal Delete Products button does exists."))
			{
				Report.IsTrue(bulkActionsModal.CloseButtonClick(), $"Failure, failed to click Bulk Actions modal Delete Products button.", $"Success, clicked Bulk Actions modal Delete Products button.");
			}
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, confirm Internal Information Revision button (does|does not) exists")]
		public void BulkActionsModalConfirmInternalInformationRevisionButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			Report.IsTrue(expected == bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Internal Information Revision button {does_doesnot} exist.", $"Success, confirmed Bulk Actions modal Internal Information Revision button {does_doesnot} exists.");
		}

		[RegexStepDefinition(@"In the Bulk Actions modal, click Internal Information Revision button")]
		public void BulkActionsModalClickInternalInformationRevisionButton()
		{
			BulkActionsModal bulkActionsModal = new BulkActionsModal();
			if (Report.IsTrue(bulkActionsModal.CloseButtonExists(), $"Failure, failed to confirm Bulk Actions modal Internal Information Revision button does exist.", $"Success, confirmed Bulk Actions modal Internal Information Revision button does exists."))
			{
				Report.IsTrue(bulkActionsModal.CloseButtonClick(), $"Failure, failed to click Bulk Actions modal Internal Information Revision button.", $"Success, clicked Bulk Actions modal Internal Information Revision button.");
			}
		}
		#endregion
	}
}
