using Reqnroll;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Ingredients")]
	class Ingredients_Steps
	{
		[RegexStepDefinition(@"In the Ingredients Section, In the popup view with the following title: (.*) I click the (.*) button")]
		public void ThenInThePopupViewWithTheFollowingTitleProductContainsIngredientsTypicalOfAPesticideIClickTheConfirmButton(string popupTitle, string buttonTitle)
		{
			new Steps_Prototype().ClickTheFollowingButtonInThePopupView(popupTitle, buttonTitle);
			Delay.Seconds(1);
		}

		[RegexStepDefinition(@"In the Ingredients Section, I confirm I check the checkbox in the popup view with the following text: (.*)")]
		public void ThenIConfirmICheckTheCheckboxInThePopupViewWithTheFollowingText(string text)
		{
			new Steps_Prototype().CheckACheckboxWithTheFollowingText(text);
		}
		[RegexStepDefinition(@"In the Ingredients Section, confirm section: 'Ingredient Reference Number \(Optional\)' (is|is not) displayed")]
		public void IngredientReferenceNumberIsIsNotDisplayed(string is_isnot)
		{
			string section = "Ingredient Reference Number (Optional)";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}
		[RegexStepDefinition(@"In the Ingredients Section, confirm for section: 'Ingredient Reference Number \(Optional\)' error (is|is not) displayed: (.*)")]
		public void IngredientReferenceNumberErrorIsIsNotDisplayed(string is_isnot, string error)
		{
			string section = "Ingredient Reference Number (Optional)";
			new Steps_ProductPrototype().InSectionErrorMessageIsIsNotDisplayed(section, error, is_isnot);
		}
		[RegexStepDefinition(@"In the Ingredients Section, set the option in section: 'Ingredient Reference Number \(Optional\)' to: (.*)")]
		public void LiquidCoreProductSelectYesOrNo(string option)
		{
			string section = "Ingredient Reference Number (Optional)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Ingredients Section, for field '(.*)' error message '(.*)' (is|is not) displayed")]
		public void InSectionForfieldErrorMessageIsIsNotDisplayed(string field, string errorMessage, string is_isnot)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			bool expected = is_isnot == "is";
			Report.IsTrue(ingredientsTable.IngredientsErrorMessageExists(errorMessage) == expected, $"Failure, '{errorMessage}' error message {(expected ? "is not" : "is")} displayed.", $"Success, '{errorMessage}' error message {is_isnot} displayed.");
		}


	 #region Add Ingredient
	[RegexStepDefinition(@"In the Ingredients Section, click the component search box")]
		public void ClickComponentSearchBox()
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.ComponentSearchBoxExists(), $"Failure, component search box does not exist.", $"Success, component search box exists.");
			Report.IsTrue(ingredientsTable.ComponentSearchBoxClick(), $"Failure, failed to click component search box.", $"Success, clicked component search box.");
		}

		[RegexStepDefinition(@"In the Ingredients Section, confirm component search box (is|is not) displayed")]
		public void ComponentSearchBoxIsIsNotDisplayed(string is_isnot)
		{
			bool expected = is_isnot == "is";
			SearchBoxPrototype searchBox = new SearchBoxPrototype();
			Report.IsTrue(searchBox.WaitForContainerToBeVisible() == expected, $"Failure, component search box {(expected ? "is not" : "is")} displayed.", $"Success, component search box {is_isnot} displayed.");
		}

		[RegexStepDefinition(@"In the component search box, enter text: (.*)")]
		public void ComponentSearchBoxEnterText(string searchText)
		{
			SearchBoxPrototype searchBox = new SearchBoxPrototype();
			searchBox.SearchInputClick();
			Report.IsTrue(searchBox.SearchInputEnterText(searchText), $"Failure, failed to enter text: '{searchText}'", $"Success, entered text: '{searchText}'");
		}

		[RegexStepDefinition(@"In the component search box, confirm search results list (is|is not) displayed")]
		public void ComponentSearchBoxResultListIsIsnotDisplayed(string is_isnot)
		{
			bool expected = is_isnot == "is";
			SearchBoxPrototype searchBox = new SearchBoxPrototype();
			Report.IsTrue(searchBox.WaitForSearchResults(30), $"Failure, search did not finish.", $"Success, search finished.");
			Report.IsTrue(searchBox.SearchResultsExists() == expected, $"Failure, search results list {(expected ? "is not" : "is")} displayed.", $"Success, search results list {is_isnot} displayed.");
		}

		[RegexStepDefinition(@"In the component search box, click result where (component name|CAS number) contains: (.*)")]
		public void ComponentSearchBoxClickResultListOption(string searchType, string searchText)
		{
			ChemicalSearchBox searchBox = new ChemicalSearchBox();
			switch (searchType)
			{
				case "component name":
					Report.IsTrue(searchBox.SearchComponentExists(searchText), $"Failure, search result list does not contain component containing text: '{searchText}'.", $"Success, search result list does contain component containing text: '{searchText}'.");
					Report.IsTrue(searchBox.SearchComponentGet(searchText).Click(), $"Failure, failed to click result component containing text: '{searchText}'.", $"Success, clicked result component containing text: '{searchText}'.");
					break;
				case "CAS number":
					Report.IsTrue(searchBox.SearchCASNumberExists(searchText), $"Failure, search result list does not contain CAS number containing text: '{searchText}'.", $"Success, search result list does contain CAS number containing text: '{searchText}'.");
					Report.IsTrue(searchBox.SearchCASNumberGet(searchText).Click(), $"Failure, failed to click result CAS number containing text: '{searchText}'.", $"Success, clicked result CAS number containing text: '{searchText}'.");
					break;
				default:
					Report.Error("Error: Invalid Search Type");
					break;
			}
		}
		[RegexStepDefinition(@"In the Ingredients Section confirm error is displayed with text: (.*)")]
		public void IngredientsTableErrorDisplayed(string errorText)
		{
			new StepsNewProduct().ErrorMessageSpecific(errorText);

		}
		[RegexStepDefinition(@"In the Ingredients Section ingredients table, confirm row with (component name|CAS number): (.*) (is|is not) displayed")]
		public void IngredientsTableRowIsIsNotDisplayed(string searchType, string searchText, string is_isnot)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			bool expected = is_isnot == "is";
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			switch (searchType)
			{
				case "component name":
					Report.IsTrue(ingredientsTable.IngredientsRowChemicalNameExists(searchText) == expected, $"Failure, ingredients table row with component name '{searchText}' {(expected ? "is not" : "is")} displayed.", $"Success, ingredients table row with component name '{searchText}' {is_isnot} displayed.");
					break;
				case "CAS number":
					Report.IsTrue(ingredientsTable.IngredientsRowCASNumberExists(searchText) == expected, $"Failure, ingredients table row with CAS number '{searchText}' {(expected ? "is not" : "is")} displayed.", $"Success, ingredients table row with CAS number '{searchText}' {is_isnot} displayed.");
					break;
				default:
					Report.Error("Error: Invalid Search Type");
					break;
			}
		}
		//See Table format Bellow 
		//|Functional Purpose|
		[RegexStepDefinition(@"In the Ingredients Section ingredients table, for Ingredient: (.*) add Ingredient Type: (.*) and Functional Purpose:")]
		public void ForIngredientsSelectTypeAndFunctionalPurpose(string ingredientName, string ingredientType, Table table)
		{
			Report.Info($"Attempting to select the ingredient type: {ingredientType} for the Ingredient: {ingredientName}");
			Report.IsTrue(new Ingredients().ISelectIngredientType(ingredientName, ingredientType, "ComponentName"), "Failed to Select the Ingredient Type", "Successfully selected the Ingredient Type");
			Report.Info($"Attempting to Select the Functional Purposes from the table.");
			var selectedOptionsStr = new List<string>();
			foreach (TableRow row in table.Rows)
			{

				if (Report.IsTrue(new Ingredients().ISelectFunctionalPurpose(ingredientName, row["Functional Purpose"], "ComponentName"), "Failed to Select The Functional Purpose:" + row["Functional Purpose"], "Successfully selected the Functional purpose" + row["Functional Purpose"]))
				{
					selectedOptionsStr.Add(row["Functional Purpose"]);
				}

			}
			Context.AddToContext(ingredientName + "FunctionalPurposesList", selectedOptionsStr);
		}
		#endregion
		#region Table Header
		[RegexStepDefinition(@"In the Ingredients Table, confirm the '(.*)' sortable column (does|does not) exist")]
		public void IngredientsTableSortableColumnDoesDoesNotExist(string columnTitle, string does_doesnot)
		{

			bool expected = does_doesnot == "does";
			IngredientsTableHeaderRow headerRow = new IngredientsTableHeaderRow();
			Report.IsTrue(headerRow.SortableColumnTitleExists(columnTitle) == expected, $"Failure, '{columnTitle}' sortable column {(expected ? "does not" : "does")} exist.", $"Success, '{columnTitle}' sortable column {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Ingredients Table, confirm the '(.*)' sortable column (up|down) carat (does|does not) exist")]
		public void IngredientsTableSortableColumnCaratDoesDoesNotExist(string columnTitle, string caratDirection, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			IngredientsTableHeaderRow headerRow = new IngredientsTableHeaderRow();
			if (Report.IsTrue(headerRow.SortableColumnTitleExists(columnTitle), $"Failure, '{columnTitle}' sortable column does not exist.", $"Success, '{columnTitle}' sortable column does exist."))
			{
				Report.IsTrue(headerRow.SortableColumnCaratExists(columnTitle, caratDirection) == expected, $"Failure, '{columnTitle}' sortable column {caratDirection} carat {(expected ? "does not" : "does")} exist.", $"Success, '{columnTitle}' sortable column {caratDirection} carat {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Ingredients Table, confirm the '(.*)' sortable column (up|down) carat (is|is not) displayed")]
		public void IngredientsTableSortableColumnCaratIsIsNotDisplayed(string columnTitle, string caratDirection, string is_isnot)
		{
			bool expected = is_isnot == "is";
			IngredientsTableHeaderRow headerRow = new IngredientsTableHeaderRow();
			if (Report.IsTrue(headerRow.SortableColumnTitleExists(columnTitle), $"Failure, '{columnTitle}' sortable column does not exist.", $"Success, '{columnTitle}' sortable column does exist."))
			{
				Report.IsTrue(headerRow.SortableColumnCaratDisplayed(columnTitle, caratDirection) == expected, $"Failure, '{columnTitle}' sortable column {caratDirection} carat {(expected ? "is not" : "is")} displayed.", $"Success, '{columnTitle}' sortable column {caratDirection} carat {is_isnot} displayed.");
			}
		}

		[RegexStepDefinition(@"In the Ingredients Table, click the '(.*)' sortable column")]
		public void IngredientsTableSortableColumbClick(string columnTitle)
		{
			IngredientsTableHeaderRow headerRow = new IngredientsTableHeaderRow();
			if (Report.IsTrue(headerRow.SortableColumnTitleExists(columnTitle), $"Failure, '{columnTitle}' sortable column does not exist.", $"Success, '{columnTitle}' sortable column does exist."))
			{
				Report.IsTrue(headerRow.SortableColumnTitleClick(columnTitle), $"Failure, failed to click '{columnTitle}' sortable column header.", $"Success, clicked '{columnTitle}' sortable column header.");
			}

		}

		[RegexStepDefinition(@"In the Ingredients Table, confirm the '(.*)' column header (does|does not) exist")]
		public void IngredientsTableColumnHeaderDoesDoesNotExist(string columnTitle, string does_doesnot)
		{

			bool expected = does_doesnot == "does";
			IngredientsTableHeaderRow headerRow = new IngredientsTableHeaderRow();
			Report.IsTrue(headerRow.ColumnHeaderExists(columnTitle) == expected, $"Failure, '{columnTitle}' column header {(expected ? "does not" : "does")} exist.", $"Success, '{columnTitle}' column header {does_doesnot} exist.");
		}
		#endregion
		#region Table Row
		internal IngredientsTableRow IngredientsRowSearchTypeGet(string searchType, string searchText)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			IngredientsTableRow ingredientRow = new IngredientsTableRow(null);
			switch (searchType)
			{
				case "component name":
					Report.IsTrue(ingredientsTable.IngredientsRowChemicalNameExists(searchText), $"Failure, ingredients table row with component name '{searchText}' is not displayed.", $"Success, ingredients table row with component name '{searchText}' is displayed.");
					ingredientRow = ingredientsTable.IngredientsRowChemicalNameGet(searchText);
					break;
				case "CAS number":
					Report.IsTrue(ingredientsTable.IngredientsRowCASNumberExists(searchText), $"Failure, ingredients table row with CAS number '{searchText}' is not  not displayed.", $"Success, ingredients table row with CAS number '{searchText}' is displayed.");
					ingredientRow = ingredientsTable.IngredientsRowCASNumberGet(searchText);
					break;
				default:
					Report.Error("Error: Invalid Search Type");
					break;
			}
			return ingredientRow;
		}

		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column text input enter: (.*)")]
		public void IngredientsTableRowEnterPercent(string searchType, string searchText, string columnLabel, string inputText)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellTextInputExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column text input does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column text input does exist.");
			Report.IsTrue(ingredientRow.CellTextInputEnterText(columnLabel, inputText), $"Failure, in {searchType}:'{searchText}' row '{columnLabel}' column text input failed to enter text '{inputText}'.", $"Success, in {searchType}:'{searchText}' row '{columnLabel}' column text input enter text '{inputText}'.");
			string displayedText = ingredientRow.CellTextInputText(columnLabel);
			Report.IsTrue(string.Equals(displayedText, inputText), $"Failure, in {searchType}:'{searchText}' row '{columnLabel}' column text input text is '{displayedText}' and should be '{inputText}'.", $"Success, in {searchType}:'{searchText}' row '{columnLabel}' column text input text '{inputText}' is correct.");
		}
		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column verify text input is: (.*)")]
		public void IngredientsTableRowCheckText(string searchType, string searchText, string columnLabel, string inputText)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellTextInputExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column text input does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column text input does exist.");
			string displayedText = ingredientRow.CellTextInputText(columnLabel);
			Report.IsTrue(string.Equals(displayedText, inputText), $"Failure, in {searchType}:'{searchText}' row '{columnLabel}' column text input text is '{displayedText}' and should be '{inputText}'.", $"Success, in {searchType}:'{searchText}' row '{columnLabel}' column text input text '{inputText}' is correct.");
		}
		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column text input enter value: (.*) and press tab")]
		public void IngredientsTableRowEnterPercentAndPressTab(string searchType, string searchText, string columnLabel, string inputText)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellTextInputExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column text input does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column text input does exist.");
			Report.IsTrue(ingredientRow.CellTextInputEnterTextAndTab(columnLabel, inputText), $"Failure, in {searchType}:'{searchText}' row '{columnLabel}' column text input failed to enter text '{inputText}'.", $"Success, in {searchType}:'{searchText}' row '{columnLabel}' column text input enter text '{inputText}'.");
			string displayedText = ingredientRow.CellTextInputText(columnLabel);
			Report.IsTrue(string.Equals(displayedText, inputText), $"Failure, in {searchType}:'{searchText}' row '{columnLabel}' column text input text is '{displayedText}' and should be '{inputText}'.", $"Success, in {searchType}:'{searchText}' row '{columnLabel}' column text input text '{inputText}' is correct.");
		}

		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column click checkbox")]
		public void IngredientsTableRowClickCheckBox(string searchType, string searchText, string columnLabel)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellCheckBoxExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column check box does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column check box does exist.");
			Report.IsTrue(ingredientRow.CellCheckBoxClick(columnLabel), $"Failure, failed to click {searchType}:'{searchText}' row '{columnLabel}' column check box.", $"Success, clicked {searchType}:'{searchText}' row '{columnLabel}' column check box.");
		}

		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column confirm checkbox is (checked|unchecked)")]
		public void IngredientsTableRowConfirmCheckUncheckCheckBox(string searchType, string searchText, string columnLabel, string checked_unchecked)
		{
			bool expected = checked_unchecked == "checked";
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellCheckBoxExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column check box does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column check box does exist.");
			Report.IsTrue(ingredientRow.CellCheckBoxIsChecked(columnLabel) == expected, $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column check box is {(expected ? "unchecked" : "checked")}.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column check box is {checked_unchecked}.");
		}
		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column confirm error message (is|is not) displayed with text: (.*)")]
		public void IngredientsTableRowConfirmError(string searchType, string searchText, string columnLabel, string is_isnot, string text)
		{
			bool expected = is_isnot == "is";
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellErrorMessageExists(columnLabel) == expected, $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column error message is {(expected ? "is not" : "is")} displayed.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column error message {is_isnot} displayed.");
			Report.IsTrue(ingredientRow.CellErrorMessageText(columnLabel) == text, $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column error message text is not '{text}'.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column error message text is '{text}'");
		}
		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column is (enabled|disabled)")]
		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column confirm checkbox is (enabled|disabled)")]
		public void IngredientsTableRowConfirmkCheckBoxISEnabledDisabled(string searchType, string searchText, string columnLabel, string checked_unchecked)
		{
			bool expected = checked_unchecked == "enabled";
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			new StepsIngredients().ForIngredientTheTradeSecretCheckboxIsDisabledOrEnabled(searchText, columnLabel, checked_unchecked);
		}
		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column set checkbox to (checked|unchecked)")]
		public void IngredientsTableRowCheckUncheckCheckBox(string searchType, string searchText, string columnLabel, string checked_unchecked)
		{
			bool expected = checked_unchecked == "checked";
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellCheckBoxExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column check box does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column check box does exist.");
			if (ingredientRow.CellCheckBoxIsChecked(columnLabel) != expected)
			{
				Report.IsTrue(ingredientRow.CellCheckBoxClick(columnLabel), $"Failure, failed to click {searchType}:'{searchText}' row '{columnLabel}' column check box.", $"Success, clicked {searchType}:'{searchText}' row '{columnLabel}' column check box.");
			}
			Report.IsTrue(ingredientRow.CellCheckBoxIsChecked(columnLabel) == expected, $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column check box is {(expected ? "unchecked" : "checked")}.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column check box is {checked_unchecked}.");
		}

		[RegexStepDefinition("In the Ingredients table, set 'Select All' checkbox to (checked|unchecked)")]
		public void ThenInTheIngredientsTableSetCheckboxToChecked(string checked_unchecked)
		{
			bool expected = checked_unchecked == "checked";
			IngredientsTable ingredientsTable = new IngredientsTable();
			var newProductIngredients = new Ingredients();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			if (newProductIngredients.SelectAllIngredientsChecked() != expected)
			{
				Report.IsTrue(new Ingredients().ClickSelectAllIngredients(), "Failed to click 'Select All' in the ingredients table", "Successfully clicked 'Select All' in the ingredients table");
			}
			Report.IsTrue(newProductIngredients.SelectAllIngredientsChecked() == expected, $"Failure, 'Select All' checkbox is {(expected ? "unchecked" : "checked")}.", $"Success, 'Select All' check box is {checked_unchecked}.");
		}

		[RegexStepDefinition("In the Ingredients table, confirm 'Select All' checkbox is (checked|unchecked)")]
		public void ThenInTheIngredientsTableCheckboxSelectAll(string checked_unchecked)
		{
			bool expected = checked_unchecked == "checked";
			IngredientsTable ingredientsTable = new IngredientsTable();
			var newProductIngredients = new Ingredients();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			Report.IsTrue(newProductIngredients.SelectAllIngredientsChecked() == expected, $"Failure, 'Select All' checkbox is {(expected ? "unchecked" : "checked")}.", $"Success, 'Select All' check box is {checked_unchecked}.");
		}
		[RegexStepDefinition("In the Ingredients Table, confirm the 'Delete' button (is|is not) displayed")]
		public void ThenInTheIngredientsTableConfirmTheButtonIsDisplayed(string is_isnot)
		{
			new StepsIngredients().ConfirmTheDeleteButtonIsDisplayed(is_isnot);
		}
		[RegexStepDefinition("In the Ingredients Table, click the 'Delete' button")]
		public void ThenInTheIngredientsTableClickTheButton()
		{
			Report.IsTrue(new Ingredients().ClickDeleteIngredients(), "Failed to click 'Delete'", "Successfully clicked 'Delete'");
		}

		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column click select")]
		public void IngredientsTableRowSelect(string searchType, string searchText, string columnLabel)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellSelectExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column select does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column select does exist.");
			Report.IsTrue(ingredientRow.CellSelectClick(columnLabel), $"Failure, failed to click {searchType}:'{searchText}' row '{columnLabel}' column select.", $"Success, clicked {searchType}:'{searchText}' row '{columnLabel}' column select.");
		}

		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column click 'Regulated' button")]
		public void IngredientsTableRowClickRegulatedButton(string searchType, string searchText, string columnLabel)
		{
			string button = "Regulated";
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellButtonExists(columnLabel, button), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column button {button} does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column button {button} does exist.");
			Report.IsTrue(ingredientRow.CellButtonClick(columnLabel, button), $"Failure, failed to click {searchType}:'{searchText}' row '{columnLabel}' column button.", $"Success, clicked {searchType}:'{searchText}' row '{columnLabel}' column button.");
		}

		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column select (.*) option (does|does not) exist")]
		public void IngredientsTableRowSelectOptionExists(string searchType, string searchText, string columnLabel, string optionLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellSelectExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column select does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column select does exist.");
			Report.IsTrue(ingredientRow.CellSelectOptionExists(columnLabel, optionLabel) == expected, $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column select option '{optionLabel}' {(expected ? "does not" : "does")} exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column select option '{optionLabel}' {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column select option (.*)")]
		public void IngredientsTableRowSelectOptionSelect(string searchType, string searchText, string columnLabel, string optionLabel)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellSelectExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column select does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column select does exist.");
			Report.IsTrue(ingredientRow.CellSelectOptionSelect(columnLabel, optionLabel), $"Failure, to select {searchType}:'{searchText}' row '{columnLabel}' column select option '{optionLabel}'.", $"Success, selected {searchType}:'{searchText}' row '{columnLabel}' column select option '{optionLabel}'.");
		}
		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column select element (does|does not) exists")]
		public void IngredientsTableRowSelectElementExists(string searchType, string searchText, string columnLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellSelectExists(columnLabel) == expected, $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column select elemet {(expected ? "does not" : "does")} exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column select element {does_doesnot} exist.");
		}
		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column multiselect options (.*)")]
		public void IngredientsTableRowSelectOptionsMultiSelect(string searchType, string searchText, string columnLabel, string optionsListString)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			MultiSelectModal multiSelectModal = new MultiSelectModal();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellMultiSelectExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column multiselect does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column multiselect does exist.");
			Report.IsTrue(ingredientRow.CellMultiSelectClick(columnLabel), $"Failure, failed to click {searchType}:'{searchText}' row '{columnLabel}' column multiselect.", $"Success, clicked {searchType}:'{searchText}' row '{columnLabel}' column multiselect.");
			//Report.IsTrue(ingredientRow.CellSelectOptionSelect(columnLabel, optionsListString), $"Failure, to select {searchType}:'{searchText}' row '{columnLabel}' column select option '{optionLabel}'.", $"Success, selected {searchType}:'{searchText}' row '{columnLabel}' column select option '{optionLabel}'.");
			List<string> optionsList = [.. optionsListString.Split(",")];
			foreach (string option in optionsList)
			{
				string optionTrimed = option.Trim();
				Report.IsTrue(multiSelectModal.MultiSelectOptionExists(optionTrimed), $"Failure, multiselect modal option '{optionTrimed}' does not exist.", $"Success, multiselect option '{option}' exists.");
				Report.IsTrue(multiSelectModal.MultiSelectOptionClick(optionTrimed), $"Failure, failed to click multiselect modal option '{optionTrimed}'.", $"Success, clicked multiselect option '{option}'.");
				Report.IsTrue(multiSelectModal.MultiSelectSelectedOptionExists(optionTrimed), $"Failure, failed to select multiselect option '{optionTrimed}'.", $"Success, selecred mulitselect option '{optionTrimed}'.");
			}
			Report.IsTrue(multiSelectModal.CloseButtonClick(), $"Failure, failed to click multiselect modal 'Close' button.", $"Success, clicked multiselect modal 'Close' button.");
			Report.Screenshot();
		}

		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column delete selected option (.*)")]
		public void ThenInTheIngredientsTableRowWithComponentNameWaterInFunctionalPurposeColumnDeleteSelectedOptionAbrasive(string searchType, string searchText, string columnLabel, string optionLabel)
		{
			string is_isnot = "is";
			bool expected = is_isnot == "is";
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellSelectExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column select does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column select does exist.");
			if (Report.IsTrue(string.Equals(ingredientRow.CellSelectValue(columnLabel), optionLabel) == expected, $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column select option '{optionLabel}' {(expected ? "is not" : "is")} selected.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column select option '{optionLabel}' {is_isnot} selected."))
			{
				Report.IsTrue(ingredientRow.CellDeleteOptionSelected(columnLabel, optionLabel), $"Failure, for {searchType}:'{searchText}' row '{columnLabel}' column delete selected option '{optionLabel}'.", $"Success, for {searchType}:'{searchText}' row '{columnLabel}' column delete selected option '{optionLabel}'.");
			}
			else
			{
				Report.Success($"Option {optionLabel} was not selected for column {columnLabel}");
			}
		}

		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column select confirm (.*) option (is|is not) selected")]
		public void IngredientsTableRowSelectConfirmOptionIsIsNotSelected(string searchType, string searchText, string columnLabel, string optionLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellSelectExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column select does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column select does exist.");
			Report.IsTrue(string.Equals(ingredientRow.CellSelectValue(columnLabel), optionLabel) == expected, $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column select option '{optionLabel}' {(expected ? "is not" : "is")} selected.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column select option '{optionLabel}' {is_isnot} selected.");
		}

		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), confirm remove button exists")]
		public void IngredientsTableRowRemoveButtonExists(string searchType, string searchText)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.RowRemoveButtonExists(), $"Failure, {searchType}:'{searchText}' row remove button does not exist.", $"Success, {searchType}:'{searchText}' row remove button does exist.");
		}

		[RegexStepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), click remove button")]
		public void IngredientsTableRowRemoveButtonClick(string searchType, string searchText)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.RowRemoveButtonExists(), $"Failure, {searchType}:'{searchText}' row remove button does not exist.", $"Success, {searchType}:'{searchText}' row remove button does exist.");
			Report.IsTrue(ingredientRow.RowRemoveButtonClick(), $"Failure, failed to click {searchType}:'{searchText}' row remove button.", $"Success, clicked {searchType}:'{searchText}' row remove button.");
		}
		#endregion

		#region Modal Steps
		[RegexStepDefinition(@"Confirm a modal (is|is not) displayed")]
		public void IngredientsModalIsIsNotDisplayed(string is_isnot)
		{
			bool expected = is_isnot == "is";
			IngredientsModal ingredientsModal = new IngredientsModal();
			if (expected)
			{
				Report.IsTrue(ingredientsModal.WaitForContainerToBeVisible(), $"Failure, modal is not displayed.", $"Success, modal is displayed.");
			}
			else
			{
				Report.IsTrue(ingredientsModal.WaitForContainerToBeInvisible(), $"Failure, modal is displayed.", $"Success, modal is not displayed.");
			}
		}

		[RegexStepDefinition(@"Confirm displayed modal has title: (.*)")]
		public void IngredientsModalHasTitle(string expectedTitle)
		{
			IngredientsModal ingredientsModal = new IngredientsModal();
			Report.IsTrue(ingredientsModal.WaitForContainerToBeVisible(), $"Failure, modal is not displayed.", $"Success, modal is displayed.");
			string displayedTitle = ingredientsModal.HeaderTitleText();
			Report.IsTrue(string.Equals(displayedTitle, expectedTitle), $"Failure, displayed modal expected title is '{expectedTitle}' but displayed title is '{displayedTitle}'.", $"Success, expected title '{expectedTitle}' matech displayed title.");
		}

		[RegexStepDefinition(@"In displayed modal, confirm (.*) footer button (is|is not) displayed")]
		public void IngredientsModalFooterButtonIsIsNotDisplayed(string buttonLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			IngredientsModal ingredientsModal = new IngredientsModal();
			Report.IsTrue(ingredientsModal.WaitForContainerToBeVisible(), $"Failure, modal is not displayed.", $"Success, modal is displayed.");
			Report.IsTrue(ingredientsModal.FooterButtonExists(buttonLabel) == expected, $"Failure, in the displayed modal '{buttonLabel}' button {(expected ? "is not" : "is")} displayed.", $"Success, in the displayed modal '{buttonLabel}' button {is_isnot} displayed.");
		}

		[RegexStepDefinition(@"In displayed modal, click (.*) footer button")]
		public void IngredientsModalClickFooterButton(string buttonLabel)
		{
			IngredientsModal ingredientsModal = new IngredientsModal();
			Report.IsTrue(ingredientsModal.WaitForContainerToBeVisible(), $"Failure, modal is not displayed.", $"Success, modal is displayed.");
			Report.IsTrue(ingredientsModal.FooterButtonExists(buttonLabel), $"Failure, in the displayed modal '{buttonLabel}' button is not displayed.", $"Success, in the displayed modal '{buttonLabel}' button is displayed.");
			Report.IsTrue(ingredientsModal.FooterButtonClick(buttonLabel), $"Failure, in the displayed modal failed to click '{buttonLabel}' button.", $"Success, in the displayed modal clicked '{buttonLabel}' button.");
		}

		[RegexStepDefinition(@"In displayed modal, confirm (.*) footer checkbox (is|is not) displayed")]
		public void IngredientsModalFooterCheckboxIsIsNotDisplayed(string checkboxLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			IngredientsModal ingredientsModal = new IngredientsModal();
			Report.IsTrue(ingredientsModal.WaitForContainerToBeVisible(), $"Failure, modal is not displayed.", $"Success, modal is displayed.");
			Report.IsTrue(ingredientsModal.FooterCheckboxExists(checkboxLabel) == expected, $"Failure, in the displayed modal '{checkboxLabel}' checkbox {(expected ? "is not" : "is")} displayed.", $"Success, in the displayed modal '{checkboxLabel}' checkbox {is_isnot} displayed.");
		}

		[RegexStepDefinition(@"In displayed modal, (check|uncheck) (.*) footer checkbox")]
		public void IngredientsModalCheckUncheckFooterButton(string check_uncheck, string checkboxLabel)
		{
			bool expected = check_uncheck == "check";
			IngredientsModal ingredientsModal = new IngredientsModal();
			Report.IsTrue(ingredientsModal.WaitForContainerToBeVisible(), $"Failure, modal is not displayed.", $"Success, modal is displayed.");
			Report.IsTrue(ingredientsModal.FooterCheckboxExists(checkboxLabel), $"Failure, in the displayed modal '{checkboxLabel}' checkbox is not displayed.", $"Success, in the displayed modal '{checkboxLabel}' checkbox is displayed.");
			if (expected != ingredientsModal.FooterCheckboxChecked(checkboxLabel))
			{
				Report.IsTrue(ingredientsModal.FooterCheckboxClick(checkboxLabel), $"Failure, in the displayed modal failed to click '{checkboxLabel}' checkbox.", $"Success, in the displayed modal clicked '{checkboxLabel}' checkbox.");
			}
			Report.IsTrue((ingredientsModal.FooterCheckboxChecked(checkboxLabel) == expected), $"Failure, in the displayed modal failed to confirm '{checkboxLabel}' checkbox is {check_uncheck}ed.", $"Success, in the displayed modal confirmed '{checkboxLabel}' checkbox is {check_uncheck}ed.");
		}

		[RegexStepDefinition("In the Ingredients section confirm a list of regulations associated with the component is displayed in the modal window")]
		public void ThenInTheIngredientsSectionConfirmAListOfRegulationsAssociatedWithTheComponentIsDisplayedInTheModalWindow()
		{
			new StepsNewProduct().ConfirmListOfRegulationsAssociatedWithComponentDisplayed();

		}

		#endregion

		#region Shared Steps
		[RegexStepDefinition(@"In the Ingredients section, add component with (component name|CAS number): (.*)")]
		public void IngredientsTableAddIngredientBy(string searchType, string searchText)
		{
			Report.UseSubSteps = true;
			IngredientsTable ingredientsTable = new IngredientsTable();
			SearchBoxPrototype searchBox = new SearchBoxPrototype();
			Report.StartSubStep($"In the Ingredients Section ingredients table, confirm row with {searchType}: {searchText} is not displayed");
			this.IngredientsTableRowIsIsNotDisplayed(searchType, searchText, "is not");
			Report.StartSubStep($"In the Ingredients Section, click the component search box");
			this.ClickComponentSearchBox();
			Report.StartSubStep($"In the Ingredients Section, confirm component search box is displayed");
			this.ComponentSearchBoxIsIsNotDisplayed("is");
			Report.StartSubStep($"In the component search box, enter text: {searchText}");
			this.ComponentSearchBoxEnterText(searchText);
			Report.StartSubStep($"In the component search box, confirm search results list is displayed");
			this.ComponentSearchBoxResultListIsIsnotDisplayed("is");
			Report.StartSubStep($"In the component search box, click result where {searchType} contains: {searchText}");
			this.ComponentSearchBoxClickResultListOption(searchType, searchText);
			Report.StartSubStep($"In the Ingredients Section ingredients table, confirm row with {searchType}: {searchText} is displayed");
			this.IngredientsTableRowIsIsNotDisplayed(searchType, searchText, "is");
		}

		[RegexStepDefinition(@"In the Ingredients section, delete component with (component name|CAS number): (.*)")]
		public void IngredientsTableDeleteIngredientBy(string searchType, string searchText)
		{
			Report.UseSubSteps = true;
			IngredientsTable ingredientsTable = new IngredientsTable();
			IngredientsModal ingredientsModal = new IngredientsModal();
			Report.StartSubStep($"In the Ingredients Section ingredients table, confirm row with {searchType}: {searchText} is displayed");
			this.IngredientsTableRowIsIsNotDisplayed(searchType, searchText, "is");
			Report.StartSubStep($"In the Ingredients Table row with {searchType}: {searchText}, click remove button");
			this.IngredientsTableRowRemoveButtonClick(searchType, searchText);
			Report.StartSubStep($"Confirm a modal is displayed");
			this.IngredientsModalIsIsNotDisplayed("is");
			Report.StartSubStep($"Confirm displayed modal has title: Remove Component?");
			this.IngredientsModalHasTitle("Remove Component?");
			Report.StartSubStep($"In displayed modal, confirm Yes footer button is displayed");
			this.IngredientsModalFooterButtonIsIsNotDisplayed("Yes", "is");
			Report.StartSubStep($"In displayed modal, click Yes footer button");
			this.IngredientsModalClickFooterButton("Yes");
			Report.StartSubStep($"Then Confirm a modal is not displayed");
			this.IngredientsModalIsIsNotDisplayed("is not");
			Report.StartSubStep($"In the Ingredients Section ingredients table, confirm row with {searchType}: {searchText} is not displayed");
			this.IngredientsTableRowIsIsNotDisplayed(searchType, searchText, "is not");
		}

		/// Copy and paste the following tables to create the table structure as needed 
		///| SearchType | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name |
		///
		/// | SearchType | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Active Ingredient? | Public Name |
		///
		///
		/// | SearchType | SearchValue | Percent | Publicly Disclosed? | Trade Secret? | Public Name | Ingredient Type |Functional Purpose | Certified |
		[RegexStepDefinition(@"In the Ingredients section, add the following ingredients:")]
		public void IngredientsTableAddFollowingIngredients(Table inputTable)
		{
			Report.UseSubSteps = true;
			IngredientsTable ingredientsTable = new IngredientsTable();
			SearchBoxPrototype searchBox = new SearchBoxPrototype();
			List<string> requiredColumns = new List<string> { "SearchType", "SearchValue", "Percent", "Publicly Disclosed?", "Trade Secret?", "Public Name" };
			requiredColumns.ForEach(requiredColumn =>
			{
				if (!inputTable.ContainsColumn(requiredColumn))
				{
					Report.Error($"Error: Input Table does not contain '{requiredColumn}'.");
				}
			});

			foreach (TableRow inputRow in inputTable.Rows)
			{
				string[] searchTypes = new string[] { "component name", "CAS number" };
				Report.IsTrue(searchTypes.Contains(inputRow["SearchType"]), $"Failure, '{inputRow["SearchType"]}' is not a valid search type ('component name' or 'CAS number').", $"Success, '{inputRow["SearchType"]}' is a valid search type.");
				Report.StartSubStep($"In the Ingredients section, add component with {inputRow["SearchType"]}: {inputRow["SearchValue"]}");
				this.IngredientsTableAddIngredientBy(inputRow["SearchType"], inputRow["SearchValue"]);
				Report.StartSubStep($"In the Ingredients Table row with {inputRow["SearchType"]}: {inputRow["SearchValue"]}, in 'Percent' column text input enter: {inputRow["Percent"]}");
				this.IngredientsTableRowEnterPercent(inputRow["SearchType"], inputRow["SearchValue"], "Percent", inputRow["Percent"]);
				if (inputRow["Publicly Disclosed?"] == "True")
				{
					Report.StartSubStep($"In the Ingredients Table row with {inputRow["SearchType"]}: {inputRow["SearchValue"]}, in 'Publicly Disclosed?' column set checkbox to checked");
					this.IngredientsTableRowCheckUncheckCheckBox(inputRow["SearchType"], inputRow["SearchValue"], "Publicly Disclosed?", "checked");
					Report.StartSubStep($"Then In the Ingredients Table row with {inputRow["SearchType"]}: {inputRow["SearchValue"]}, in 'Public Name' column select option {inputRow["Public Name"]}");
					this.IngredientsTableRowSelectOptionSelect(inputRow["SearchType"], inputRow["SearchValue"], "Public Name", inputRow["Public Name"]);
					if (inputTable.ContainsColumn("Ingredient Type") && inputRow["Ingredient Type"] != null)
					{
						Report.StartSubStep($"Then In the Ingredients Table row with {inputRow["SearchType"]}: {inputRow["SearchValue"]}, in 'Ingredient Type' column select option {inputRow["Ingredient Type"]}");
						this.IngredientsTableRowSelectOptionSelect(inputRow["SearchType"], inputRow["SearchValue"], "Ingredient Type", inputRow["Ingredient Type"]);
					}
				}
				if (inputRow["Trade Secret?"] == "True")
				{
					Report.StartSubStep($"In the Ingredients Table row with {inputRow["SearchType"]}: {inputRow["SearchValue"]}, in 'Trade Secret?' column set checkbox to checked");
					this.IngredientsTableRowCheckUncheckCheckBox(inputRow["SearchType"], inputRow["SearchValue"], "Trade Secret?", "checked");
				}
				if (inputTable.ContainsColumn("Active Ingredient?") && inputRow["Active Ingredient"] == "True")
				{
					Report.StartSubStep($"In the Ingredients Table row with {inputRow["SearchType"]}: {inputRow["SearchValue"]}, in 'Active Ingredient?' column set checkbox to checked");
					this.IngredientsTableRowCheckUncheckCheckBox(inputRow["SearchType"], inputRow["SearchValue"], "Active Ingredient?", "checked");
				}
				if (inputTable.ContainsColumn("Functional Purpose") && inputRow["Functional Purpose"] != null)
				{
					Report.StartSubStep($"Then In the Ingredients Table row with {inputRow["SearchType"]}: {inputRow["SearchValue"]}, in 'Functional Purpose' column select option {inputRow["Ingredient Type"]}");
					this.IngredientsTableRowSelectOptionsMultiSelect(inputRow["SearchType"], inputRow["SearchValue"], "Functional Purpose", inputRow["Functional Purpose"]);
				}
			}
		}
		[RegexStepDefinition("In the Ingredients table confirm ingredients should be in the following order")]
		public void ThenInTheIngredientsTableConfirmIngredientsShouldBeInTheFollowingOrder(Table table)
		{
			new StepsIngredients().ThenInTheIngredientsTableTheIngredientsShouldBeInTheFollowingOrder(table);
		}

		[RegexStepDefinition(@"In the Ingredients section, I confirm I see the error message types in the popup with the following title: (.*)")]
		public void ThenIConfirmISeeTheTwoErrorMessagesInThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow(string popupTitle, Table table)
		{
			var newProductIngredients = new Steps_Prototype();
			newProductIngredients.ThenIConfirmISeeTheTwoErrorMessagesInThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow(popupTitle, table);
		}

		[RegexStepDefinition(@"In the Ingredients section, I click the close button for the CA Cleaning Ingredients Popup")]
		public void ThenIClickTheCloseButtonForThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow()
		{
			var newProductIngredients = new Steps_Prototype();
			newProductIngredients.ThenIClickTheCloseButtonForThePopupWithTheFollowingTitleCaliforniaCleaningRightToKnow();
		}
		[RegexStepDefinition(@"In the Ingredients section, I confirm the popup (should|should not) be displayed with the following title: (.*) and text: (.*)")]
		public void ThenIConfirmISeeTheTwoErrorMessagesInThePopupWithTheFollowingTitleWarning(string condition, string popupTitle, string text)
		{
			new Steps_ModalDialogPrototype().ConfirmModalTitleandModalText(condition, popupTitle, text);
		}

		#endregion

		#region Other Steps
		[RegexStepDefinition(@"In the Ingredients section, verify Total Percent displays value: (.*)")]
		public void ThenIVerifyTotalPercent(string value)
		{
			new StepsIngredients().GivenIConfirmPercentageOfFiveIngredients(value);
		}

		[RegexStepDefinition("In the Ingredients section, verify Transparency displays value: (.*)%")]
		public void ThenInTheIngredientsSectionVerifyTransparencyDisplaysValue(float value)
		{
			new StepsIngredients().ThenIVerifyTheTransparencyScoreDisplays(value);
		}

		#endregion

	}
}
