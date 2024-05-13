using OpenQA.Selenium.DevTools.V108.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Automation.Utilities.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Ingredients;
using UL.Automation.SpecFlow.Classes;



namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Ingredients")]
	class Ingredients_Steps
	{

		[StepDefinition(@"In the Ingredients Section, In the popup view with the following title: (.*) I click the (.*) button")]
		public void ThenInThePopupViewWithTheFollowingTitleProductContainsIngredientsTypicalOfAPesticideIClickTheConfirmButton(string popupTitle, string buttonTitle)
		{
			new Steps_Prototype().ClickTheFollowingButtonInThePopupView(popupTitle, buttonTitle);
			Delay.Seconds(1);
		}

		[StepDefinition(@"In the Ingredients Section, I confirm I check the checkbox in the popup view with the following text: (.*)")]
		public void ThenIConfirmICheckTheCheckboxInThePopupViewWithTheFollowingText(string text)
		{
			new Steps_Prototype().CheckACheckboxWithTheFollowingText(text);
		}

		[StepDefinition(@"In the Ingredients Section, set the option in section: 'Ingredient Reference Number (Optional) to: (.*)")]
		public void LiquidCoreProductSelectYesOrNo(string option)
		{
			string section = "Ingredient Reference Number (Optional)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		#region Add Ingredient
		[StepDefinition(@"In the Ingredients Section, click the component search box")]
		public void ClickComponentSearchBox()
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.ComponentSearchBoxExists(), $"Failure, component search box does not exist.", $"Success, component search box exists.");
			Report.IsTrue(ingredientsTable.ComponentSearchBoxClick(), $"Failure, failed to click component search box.", $"Success, clicked component search box.");
		}

		[StepDefinition(@"In the Ingredients Section, confirm component search box (is|is not) displayed")]
		public void ComponentSearchBoxIsIsNotDisplayed(string is_isnot)
		{
			bool expected = is_isnot == "is";
			SearchBoxPrototype searchBox = new SearchBoxPrototype();
			Report.IsTrue(searchBox.WaitForContainerToBeVisible() == expected, $"Failure, component search box {(expected ? "is not" : "is")} displayed.", $"Success, component search box {is_isnot} displayed.");
		}

		[StepDefinition(@"In the component search box, enter text: (.*)")]
		public void ComponentSearchBoxEnterText(string searchText)
		{
			SearchBoxPrototype searchBox = new SearchBoxPrototype();
			searchBox.SearchInputClick();
			Report.IsTrue(searchBox.SearchInputEnterText(searchText), $"Failure, failed to enter text: '{searchText}'", $"Success, entered text: '{searchText}'");
		}

		[StepDefinition(@"In the component search box, confirm search results list (is|is not) displayed")]
		public void ComponentSearchBoxResultListIsIsnotDisplayed(string is_isnot)
		{
			bool expected = is_isnot == "is";
			SearchBoxPrototype searchBox = new SearchBoxPrototype();
			Report.IsTrue(searchBox.WaitForSearchResults(30), $"Failure, search did not finish.", $"Success, search finished.");
			Report.IsTrue(searchBox.SearchResultsExists() == expected, $"Failure, search results list {(expected ? "is not" : "is")} displayed.", $"Success, search results list {is_isnot} displayed.");
		}

		[StepDefinition(@"In the component search box, click result where (component name|CAS number) contains: (.*)")]
		public void ComponentSearchBoxClickResultListOption(string searchType, string searchText)
		{
			SearchBoxPrototype searchBox = new SearchBoxPrototype();
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

		[StepDefinition(@"In the Ingredients Section ingredients table, confirm row with (component name|CAS number): (.*) (is|is not) displayed")]
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
		[StepDefinition(@"In the Ingredients Section ingredients table, for Ingredient: (.*) add Ingredient Type: (.*) and Functional Purpose:")]
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
		[StepDefinition(@"In the Ingredients Table, confirm the '(.*)' sortable column (does|does not) exist")]
		public void IngredientsTableSortableColumnDoesDoesNotExist(string columnTitle, string does_doesnot)
		{

			bool expected = does_doesnot == "does";
			IngredientsTableHeaderRow headerRow = new IngredientsTableHeaderRow();
			Report.IsTrue(headerRow.SortableColumnTitleExists(columnTitle) == expected, $"Failure, '{columnTitle}' sortable column {(expected ? "does not" : "does")} exist.", $"Success, '{columnTitle}' sortable column {does_doesnot} exist.");
		}

		[StepDefinition(@"In the Ingredients Table, confirm the '(.*)' sortable column (up|down) carat (does|does not) exist")]
		public void IngredientsTableSortableColumnCaratDoesDoesNotExist(string columnTitle, string caratDirection, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			IngredientsTableHeaderRow headerRow = new IngredientsTableHeaderRow();
			if (Report.IsTrue(headerRow.SortableColumnTitleExists(columnTitle), $"Failure, '{columnTitle}' sortable column does not exist.", $"Success, '{columnTitle}' sortable column does exist."))
			{
				Report.IsTrue(headerRow.SortableColumnCaratExists(columnTitle, caratDirection) == expected, $"Failure, '{columnTitle}' sortable column {caratDirection} carat {(expected ? "does not" : "does")} exist.", $"Success, '{columnTitle}' sortable column {caratDirection} carat {does_doesnot} exist.");
			}
		}

		[StepDefinition(@"In the Ingredients Table, confirm the '(.*)' sortable column (up|down) carat (is|is not) displayed")]
		public void IngredientsTableSortableColumnCaratIsIsNotDisplayed(string columnTitle, string caratDirection, string is_isnot)
		{
			bool expected = is_isnot == "is";
			IngredientsTableHeaderRow headerRow = new IngredientsTableHeaderRow();
			if (Report.IsTrue(headerRow.SortableColumnTitleExists(columnTitle), $"Failure, '{columnTitle}' sortable column does not exist.", $"Success, '{columnTitle}' sortable column does exist."))
			{
				Report.IsTrue(headerRow.SortableColumnCaratDisplayed(columnTitle, caratDirection) == expected, $"Failure, '{columnTitle}' sortable column {caratDirection} carat {(expected ? "is not" : "is")} displayed.", $"Success, '{columnTitle}' sortable column {caratDirection} carat {is_isnot} displayed.");
			}
		}

		[StepDefinition(@"In the Ingredients Table, click the '(.*)' sortable column")]
		public void IngredientsTableSortableColumbClick(string columnTitle)
		{
			IngredientsTableHeaderRow headerRow = new IngredientsTableHeaderRow();
			if (Report.IsTrue(headerRow.SortableColumnTitleExists(columnTitle), $"Failure, '{columnTitle}' sortable column does not exist.", $"Success, '{columnTitle}' sortable column does exist."))
			{
				Report.IsTrue(headerRow.SortableColumnTitleClick(columnTitle), $"Failure, failed to click '{columnTitle}' sortable column header.", $"Success, clicked '{columnTitle}' sortable column header.");
			}

		}

		[StepDefinition(@"In the Ingredients Table, confirm the '(.*)' column header (does|does not) exist")]
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

		[StepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column text input enter: (.*)")]
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

		[StepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column click checkbox")]
		public void IngredientsTableRowClickCheckBox(string searchType, string searchText, string columnLabel)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellCheckBoxExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column check box does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column check box does exist.");
			Report.IsTrue(ingredientRow.CellCheckBoxClick(columnLabel), $"Failure, failed to click {searchType}:'{searchText}' row '{columnLabel}' column check box.", $"Success, clicked {searchType}:'{searchText}' row '{columnLabel}' column check box.");
		}

		[StepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column confirm checkbox is (checked|unchecked)")]
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

		[StepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column set checkbox to (checked|unchecked)")]
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

		[StepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column click select")]
		public void IngredientsTableRowSelect(string searchType, string searchText, string columnLabel)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellSelectExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column select does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column select does exist.");
			Report.IsTrue(ingredientRow.CellSelectClick(columnLabel), $"Failure, failed to click {searchType}:'{searchText}' row '{columnLabel}' column select.", $"Success, clicked {searchType}:'{searchText}' row '{columnLabel}' column select.");
		}

		[StepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column select (.*) option (does|does not) exist")]
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

		[StepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column select option (.*)")]
		public void IngredientsTableRowSelectOptionSelect(string searchType, string searchText, string columnLabel, string optionLabel)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.CellSelectExists(columnLabel), $"Failure, {searchType}:'{searchText}' row '{columnLabel}' column select does not exist.", $"Success, {searchType}:'{searchText}' row '{columnLabel}' column select does exist.");
			Report.IsTrue(ingredientRow.CellSelectOptionSelect(columnLabel, optionLabel), $"Failure, to select {searchType}:'{searchText}' row '{columnLabel}' column select option '{optionLabel}'.", $"Success, selected {searchType}:'{searchText}' row '{columnLabel}' column select option '{optionLabel}'.");
		}

		[StepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), in (.*) column select confirm (.*) option (is|is not) selected")]
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

		[StepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), confirm remove button exists")]
		public void IngredientsTableRowRemoveButtonExists(string searchType, string searchText)
		{
			IngredientsTable ingredientsTable = new IngredientsTable();
			Report.IsTrue(ingredientsTable.WaitForContainerToBeVisible(), $"Failure, ingredients table does not exist.", $"Success, ingredients table exists.");
			Report.IsTrue(!ingredientsTable.IngredientRowList.IsNullOrEmpty(), $"Failure, ingredients table is empty.", $"Success, ingredients table is not empty.");
			IngredientsTableRow ingredientRow = this.IngredientsRowSearchTypeGet(searchType, searchText);
			Report.IsTrue(ingredientRow.RowRemoveButtonExists(), $"Failure, {searchType}:'{searchText}' row remove button does not exist.", $"Success, {searchType}:'{searchText}' row remove button does exist.");
		}

		[StepDefinition(@"In the Ingredients Table row with (component name|CAS number): (.*), click remove button")]
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
		[StepDefinition(@"Confirm a modal (is|is not) displayed")]
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

		[StepDefinition(@"Confirm displayed modal has title: (.*)")]
		public void IngredientsModalHasTitle(string expectedTitle)
		{
			IngredientsModal ingredientsModal = new IngredientsModal();
			Report.IsTrue(ingredientsModal.WaitForContainerToBeVisible(), $"Failure, modal is not displayed.", $"Success, modal is displayed.");
			string displayedTitle = ingredientsModal.HeaderTitleText();
			Report.IsTrue(string.Equals(displayedTitle, expectedTitle), $"Failure, displayed modal expected title is '{expectedTitle}' but displayed title is '{displayedTitle}'.", $"Success, expected title '{expectedTitle}' matech displayed title.");
		}

		[StepDefinition(@"In displayed modal, confirm (.*) footer button (is|is not) displayed")]
		public void IngredientsModalFooterButtonIsIsNotDisplayed(string buttonLabel, string is_isnot)
		{
			bool expected = is_isnot == "is";
			IngredientsModal ingredientsModal = new IngredientsModal();
			Report.IsTrue(ingredientsModal.WaitForContainerToBeVisible(), $"Failure, modal is not displayed.", $"Success, modal is displayed.");
			Report.IsTrue(ingredientsModal.FooterButtonExists(buttonLabel) == expected, $"Failure, in the displayed modal '{buttonLabel}' button {(expected?"is not":"is")} displayed.", $"Success, in the displayed modal '{buttonLabel}' button {is_isnot} displayed.");
		}

		[StepDefinition(@"In displayed modal, click (.*) footer button")]
		public void IngredientsModalClickFooterButton(string buttonLabel)
		{
			IngredientsModal ingredientsModal = new IngredientsModal();
			Report.IsTrue(ingredientsModal.WaitForContainerToBeVisible(), $"Failure, modal is not displayed.", $"Success, modal is displayed.");
			Report.IsTrue(ingredientsModal.FooterButtonExists(buttonLabel), $"Failure, in the displayed modal '{buttonLabel}' button is not displayed.", $"Success, in the displayed modal '{buttonLabel}' button is displayed.");
			Report.IsTrue(ingredientsModal.FooterButtonClick(buttonLabel), $"Failure, in the displayed modal failed to click '{buttonLabel}' button.", $"Success, in the displayed modal clicked '{buttonLabel}' button.");
		}
		#endregion

		#region Shared Steps
		[StepDefinition(@"In the Ingredients section, add component with (component name|CAS number): (.*)")]
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

		[StepDefinition(@"In the Ingredients section, delete component with (component name|CAS number): (.*)")]
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
		[StepDefinition(@"In the Ingredients section, add the following ingredients:")]
		public void IngredientsTableAddFollowingIngredients(Table inputTable)
		{
			Report.UseSubSteps = true;
			IngredientsTable ingredientsTable = new IngredientsTable();
			SearchBoxPrototype searchBox = new SearchBoxPrototype();
			List<string> requiredColumns = new List<string> { "SearchType", "SearchValue", "Percent", "Publicly Disclosed?", "Trade Secret?", "Public Name" };
			requiredColumns.ForEach(requiredColumn =>
			{
				if(!inputTable.ContainsColumn(requiredColumn))
				{
					Report.Error($"Error: Input Table does not contain '{requiredColumn}'.");
				}
			});

			foreach(TableRow inputRow in inputTable.Rows)
			{
				string[] searchTypes = new string[] { "component name", "CAS number" };
				Report.IsTrue(searchTypes.Contains(inputRow["SearchType"]),$"Failure, '{inputRow["SearchType"]}' is not a valid search type ('component name' or 'CAS number').",$"Success, '{inputRow["SearchType"]}' is a valid search type.");
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
				}
				if (inputRow["Trade Secret?"] == "True")
				{
					Report.StartSubStep($"In the Ingredients Table row with {inputRow["SearchType"]}: {inputRow["SearchValue"]}, in 'Trade Secret?' column set checkbox to checked");
					this.IngredientsTableRowCheckUncheckCheckBox(inputRow["SearchType"], inputRow["SearchValue"], "Trade Secret?", "checked");
				}
				if(inputTable.ContainsColumn("Active Ingredient?") && inputRow["Active Ingredient"] == "True")
				{
					Report.StartSubStep($"In the Ingredients Table row with {inputRow["SearchType"]}: {inputRow["SearchValue"]}, in 'Active Ingredient?' column set checkbox to checked");
					this.IngredientsTableRowCheckUncheckCheckBox(inputRow["SearchType"], inputRow["SearchValue"], "Active Ingredient?", "checked");
				}
			}
		}
		#endregion
	}
}
