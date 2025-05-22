using MathNet.Numerics.Financial;
using NPOI.HSSF.Record.Chart;
using NPOI.SS.Formula.Functions;
using Reqnroll;
using System.Collections.Generic;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.SpecflowRewrite;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:BatteryStateOfCharge")]
	public class BatteryCharacteristics
	{
		#region Type of Battery Steps
		[RegexStepDefinition(@"In the Battery Characteristics Section, set the option in section: 'Type of Battery' to: (Battery|Button cell battery|Cell)")]
		public void BatteryCharacteristicsSectionSetTypeOfBatteryTo(string option)
		{
			string section = "Type of Battery";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		#endregion

		#region Battery Characteristics Table Steps
		[RegexStepDefinition(@"In the Battery Characteristics section, confirm Battery Characteristics table (does|does not) exist")]
		public void BatteryCharacteristicsSectionConfirmTableExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			Report.IsTrue(expected == !batteryCharacteristicsTable.IsNullOrEmpty(), $"Failure, failed to confirm Battery Characteristics table {does_doesnot} exist.", $"Success, confirmed Battery Characteristics table {does_doesnot} exist.");
		}

		#region Battery Characteristics Table Column Labels Steps
		[RegexStepDefinition(@"In the Battery Characteristics section, confirm the Battery Characteristics table column labels list (does|does not) exist")]
		public void BatteryCharacteristicsSectionConfirmTableColumnLabelsListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			Report.IsTrue(expected == batteryCharacteristicsTable.ColumnLabelsListExists(), $"Failure, failed to confirm the Battery Characteristics Table column labels list {does_doesnot} exist.", $"Success, confirmed Battery Characteristcs Table column labels list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section, confirm the Battery Characteristics table (.*) column (does|does not) exist")]
		public void BatteryCharacteristicsSectionConfirmTableColumnExists(string columnLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if(!Report.IsTrue(batteryCharacteristicsTable.ColumnLabelsListExists(), $"Failure, failed to confirm the Battery Characteristics Table column labels list does exist.", $"Success, confirmed Battery Characteristcs Table column labels list does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.ColumnLabelExists(columnLabel), $"Failure, failed to confirm '{columnLabel}' column {does_doesnot} exist.", $"Success, confirmed '{columnLabel}' column {does_doesnot} exist.");
		}
		#endregion

		#region Battery Characteristics Table Rows Steps
		[RegexStepDefinition(@"In the Battery Characteristics section, confirm the Battery Characteristcs table (does|does not) have (.*) (row|rows)")]
		public void BatteryCharacteristicsSectionConfirmTableHasNRows(string does_doesnot, string rowNumberString, string row_rows)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			Report.IsTrue(expected == (batteryCharacteristicsTable.RowsListCount() == rowNumber), $"Failure, failed to confirm Battery Characteristics table {does_doesnot} have {rowNumber} {row_rows}.", $"Success, confirmed Battery Characteristics table {does_doesnot} have {rowNumber} {row_rows}.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section, confirm Battery Characteristics table row number '(.*)' (does|does not) exist")]
		public void BatteryCharacteristicsSectionTableConfirmRowNumberExists(string rowNumberString, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			Report.IsTrue(expected == batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' {does_doesnot} exist.", $"Success, confirmed row '{rowNumber}' {does_doesnot} exist.");
		}

		#region Battery Common Name Steps
		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', click Battery Common Name combobox")]
		public void BatteryCharacteristicsSectionTableClickRowBatteryCommonNameCombobox(string rowNumberString)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).BatteryCommonNameComboboxExists(), $"Failure, failed to confirm row '{rowNumber}' Battery Common Name combobox does exist.", $"Success, confirmed row '{rowNumber}' Battery Common Name combobox does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).BatteryCommonNameComboboxClick(), $"Failure, failed to click row '{rowNumber}' Battery Common Name combobox.", $"Success, clicked row '{rowNumber}' Battery Common Name combobox.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', click Battery Common Name searchbox text input")]
		public void BatteryCharacteristicsSectionTableClickRowBatteryCommonNameSearchboxTextInput(string rowNumberString)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(searchBoxPrototype.WaitForContainerToBeVisible(), $"Failure, failed to confirm search box does exist.", $"Success, confirmed search box does exist."))
			{
				return;
			}
			Report.IsTrue(searchBoxPrototype.SearchInputClick(), $"Failure, failed to click search box search input.", $"Success, clicked search box search input");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', enter into Battery Common Name searchbox text input: (.*)")]
		public void BatteryCharacteristicsSectionTableEnterRowBatteryCommonNameSearchboxTextInput(string rowNumberString, string searchInput)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(searchBoxPrototype.WaitForContainerToBeVisible(), $"Failure, failed to confirm search box does exist.", $"Success, confirmed search box does exist."))
			{
				return;
			}
			Report.IsTrue(searchBoxPrototype.SearchInputEnterText(searchInput), $"Failure, failed to enter into search box search input: '{searchInput}'.", $"Success, entered into search box search input: '{searchInput}'");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm Battery Common Name searchbox results (does|does not) contain: (.*)")]
		public void BatteryCharacteristicsSectionTableConfirmRowBatteryCommonNameSearchboxResultsContain(string rowNumberString, string does_doesnot, string searchInput)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(searchBoxPrototype.WaitForContainerToBeVisible(), $"Failure, failed to confirm search box does exist.", $"Success, confirmed search box does exist."))
			{
				return;
			}
			Report.IsTrue(expected == searchBoxPrototype.SearchResultTextExists(searchInput), $"Failure, failed to confrim search box search results {does_doesnot} contain: '{searchInput}'.", $"Success, confirmed search box search results {does_doesnot} contain: '{searchInput}'");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', click Battery Common Name searchbox result: (.*)")]
		public void BatteryCharacteristicsSectionTableClickRowBatteryCommonNameSearchboxResult(string rowNumberString, string searchInput)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(searchBoxPrototype.WaitForContainerToBeVisible(), $"Failure, failed to confirm search box does exist.", $"Success, confirmed search box does exist."))
			{
				return;
			}
			if (!Report.IsTrue(searchBoxPrototype.SearchResultTextExists(searchInput), $"Failure, failed to confrim search box search results does contain: '{searchInput}'.", $"Success, confirmed search box search results does contain: '{searchInput}'"))
			{
				return;
			}
			Report.IsTrue(searchBoxPrototype.SearchResultTextGet(searchInput).Click(), $"Failure, failed to click search box search result '{searchInput}'.", $"Success, clicked search box search result '{searchInput}'.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm Battery Common Name searchbox text input (does|does not) display: (.*)")]
		public void BatteryCharacteristicsSectionTableConfirmRowBatteryCommonNameSearchboxTextInputValue(string rowNumberString, string does_doesnot, string searchInput)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			string searchboxValue = batteryCharacteristicsTable.RowByNumber(rowNumber).BatteryCommonNameComboboxGetValue();
			Report.IsTrue(expected == searchboxValue.Equals(searchInput, System.StringComparison.Ordinal), $"Failure, failed to confirm search box value '{searchboxValue}' {does_doesnot} match expected value '{searchInput}'.", $"Success, confirmed searchbox value '{searchboxValue}' {does_doesnot} match expected value '{searchInput}'.");
		}

		#region Shared Step
		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', set Battery Common Name to: (.*)")]
		public void BatteryCharacteristicsSectionTableSetRowBatteryCommonName(string rowNumberString, string searchInput)
		{
			Report.UseSubSteps = true;
			Report.StartSubStep($"In the Battery Characteristics section, confirm Battery Characteristics table row number '{rowNumberString}' does exist");
			this.BatteryCharacteristicsSectionTableConfirmRowNumberExists(rowNumberString, "does");
			Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '{rowNumberString}', click Battery Common Name combobox");
			this.BatteryCharacteristicsSectionTableClickRowBatteryCommonNameCombobox(rowNumberString);
			Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '{rowNumberString}', click Battery Common Name searchbox text input");
			this.BatteryCharacteristicsSectionTableClickRowBatteryCommonNameSearchboxTextInput(rowNumberString);
			Report.StartSubStep($"Then In the Battery Characteristics section Battery Characteristics table row number '{rowNumberString}', enter into Battery Common Name searchbox text input: {searchInput}");
			this.BatteryCharacteristicsSectionTableEnterRowBatteryCommonNameSearchboxTextInput(rowNumberString, searchInput);
			Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '{rowNumberString}', confirm Battery Common Name searchbox results does contain: {searchInput}");
			this.BatteryCharacteristicsSectionTableConfirmRowBatteryCommonNameSearchboxResultsContain(rowNumberString, "does", searchInput);
			Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '{rowNumberString}', click Battery Common Name searchbox result: {searchInput}");
			this.BatteryCharacteristicsSectionTableClickRowBatteryCommonNameSearchboxResult(rowNumberString, searchInput);
			Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '{rowNumberString}', confirm Battery Common Name searchbox text input does display: {searchInput}");
			this.BatteryCharacteristicsSectionTableConfirmRowBatteryCommonNameSearchboxTextInputValue(rowNumberString, "does", searchInput);
		}
		#endregion

		#endregion

		#region IEC/ANSI Name Steps
		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', click IEC/ANSI Name select")]
		public void BatteryCharacteristicsSectionTableRowClickIECANSINameSelect(string rowNumberString)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).IECANSINameSelectExists(), $"Failure, failed to confirm row '{rowNumber}' IEC/ANSI Name select does exist.", $"Success, confirmed row '{rowNumber}' IEC/ANSI Name select does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).IECANSINameSelectClick(), $"Failure, failed to click row '{rowNumber}' IEC/ANSI Name select.", $"Success, clicked row '{rowNumber}' IEC/ANSI Name select.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm IEC/ANSI Name select '(.*)' option (does|does not) exist")]
		public void BatteryCharacteristicsSectionTableRowConfirmIECANSINameSelectOptionExists(string rowNumberString, string optionLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).IECANSINameSelectExists(), $"Failure, failed to confirm row '{rowNumber}' IEC/ANSI Name select does exist.", $"Success, confirmed row '{rowNumber}' IEC/ANSI Name select does exist."))
			{
				return;
			}
			Report.IsTrue(expected == batteryCharacteristicsTable.RowByNumber(rowNumber).IECANSINameSelectOptionExists(optionLabel), $"Failure, failed to confirm row '{rowNumber}' IEC/ANSI Name select '{optionLabel}' option {does_doesnot} exist.", $"Success, confirmed row '{rowNumber}' IEC/ANSI Name select '{optionLabel}' option {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', click IEC/ANSI Name select '(.*)' option")]
		public void BatteryCharacteristicsSectionTableRowClickIECANSINameSelectOptionExists(string rowNumberString, string optionLabel)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).IECANSINameSelectExists(), $"Failure, failed to confirm row '{rowNumber}' IEC/ANSI Name select does exist.", $"Success, confirmed row '{rowNumber}' IEC/ANSI Name select does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).IECANSINameSelectOptionExists(optionLabel), $"Failure, failed to confirm row '{rowNumber}' IEC/ANSI Name select '{optionLabel}' option does exist.", $"Success, confirmed row '{rowNumber}' IEC/ANSI Name select '{optionLabel}' option does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).IECANSINameSelectOptionClick(optionLabel), $"Failure, failed to click row '{rowNumber}' IEC/ANSI Name select '{optionLabel}' option.", $"Success, clicked row '{rowNumber}' IEC/ANSI Name selet '{optionLabel}' option.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm IEC/ANSI Name select (does|does not) display value: (.*)")]
		public void BatteryCharacteristicsSectionTableRowConfirmIECANSINameSelectDisplaysValue(string rowNumberString, string does_doesnot, string expectedValue)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).IECANSINameSelectExists(), $"Failure, failed to confirm row '{rowNumber}' IEC/ANSI Name select does exist.", $"Success, confirmed row '{rowNumber}' IEC/ANSI Name select does exist."))
			{
				return;
			}
			string displayedValue = batteryCharacteristicsTable.RowByNumber(rowNumber).IECANSINameSelectGetValue();
			Report.IsTrue(expected == expectedValue.Equals(displayedValue), $"Failure, failed to confirm row '{rowNumber}' IEC/ANSI Name select displayed value '{displayedValue}' {does_doesnot} match expected value '{expectedValue}'.", $"Success, confirmed row '{rowNumber}' IEC/ANSI Name select displayed value '{displayedValue}' {does_doesnot} match expected value '{expectedValue}'.");
		}
		#endregion

		#region Standard Dimensions Steps
		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', click Standard Dimensions select")]
		public void BatteryCharacteristicsSectionTableRowClickStandardDimensionsSelect(string rowNumberString)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).StandardDimensionsSelectExists(), $"Failure, failed to confirm row '{rowNumber}' Standard Dimensions select does exist.", $"Success, confirmed row '{rowNumber}' Standard Dimensions select does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).StandardDimensionsSelectClick(), $"Failure, failed to click row '{rowNumber}' Standard Dimensions select.", $"Success, clicked row '{rowNumber}' Standard Dimensions select.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm Standard Dimensions select '(.*)' option (does|does not) exist")]
		public void BatteryCharacteristicsSectionTableRowConfirmStandardDimensionsSelectOptionExists(string rowNumberString, string optionLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).StandardDimensionsSelectExists(), $"Failure, failed to confirm row '{rowNumber}' Standard Dimensions select does exist.", $"Success, confirmed row '{rowNumber}' Standard Dimensions select does exist."))
			{
				return;
			}
			Report.IsTrue(expected == batteryCharacteristicsTable.RowByNumber(rowNumber).StandardDimensionsSelectOptionExists(optionLabel), $"Failure, failed to confirm row '{rowNumber}' Standard Dimensions select '{optionLabel}' option {does_doesnot} exist.", $"Success, confirmed row '{rowNumber}' Standard Dimensions select '{optionLabel}' option {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', click Standard Dimensions select '(.*)' option")]
		public void BatteryCharacteristicsSectionTableRowClickStandardDimensionsSelectOptionExists(string rowNumberString, string optionLabel)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).StandardDimensionsSelectExists(), $"Failure, failed to confirm row '{rowNumber}' Standard Dimensions select does exist.", $"Success, confirmed row '{rowNumber}' Standard Dimensions select does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).StandardDimensionsSelectOptionExists(optionLabel), $"Failure, failed to confirm row '{rowNumber}' Standard Dimensions select '{optionLabel}' option does exist.", $"Success, confirmed row '{rowNumber}' Standard Dimensions select '{optionLabel}' option does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).StandardDimensionsSelectOptionClick(optionLabel), $"Failure, failed to click row '{rowNumber}' Standard Dimensions select '{optionLabel}' option.", $"Success, clicked row '{rowNumber}' Standard Dimensions selet '{optionLabel}' option.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm Standard Dimensions select (does|does not) display value: (.*)")]
		public void BatteryCharacteristicsSectionTableRowConfirmStandardDimensionsSelectDisplaysValue(string rowNumberString, string does_doesnot, string expectedValue)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).StandardDimensionsSelectExists(), $"Failure, failed to confirm row '{rowNumber}' Standard Dimensions select does exist.", $"Success, confirmed row '{rowNumber}' Standard Dimensions select does exist."))
			{
				return;
			}
			string displayedValue = batteryCharacteristicsTable.RowByNumber(rowNumber).StandardDimensionsSelectGetValue();
			Report.IsTrue(expected == expectedValue.Equals(displayedValue), $"Failure, failed to confirm row '{rowNumber}' Standard Dimensions select displayed value '{displayedValue}' {does_doesnot} match expected value '{expectedValue}'.", $"Success, confirmed row '{rowNumber}' Standard Dimensions select displayed value '{displayedValue}' {does_doesnot} match expected value '{expectedValue}'.");
		}
		#endregion

		#region Rechargable Battery Steps
		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm Rechargable Battery checkbox (does|does not) exist")]
		public void BatteryCharacteristicsSectionTableRowConfirmRechargableBatteryCheckboxExists(string rowNumberString, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			Report.IsTrue(expected == batteryCharacteristicsTable.RowByNumber(rowNumber).RechargebleBatteryCheckboxExists(), $"Failure, failed to confirm row '{rowNumber}' Rechargable Battery checkbox {does_doesnot} exist.", $"Success, confirmed row '{rowNumber}' Rechargable Battery checkbox {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', click Rechargable Battery checkbox")]
		public void BatteryCharacteristicsSectionTableRowClickRechargableBatteryCheckbox(string rowNumberString)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).RechargebleBatteryCheckboxExists(), $"Failure, failed to confirm row '{rowNumber}' Rechargable Battery checkbox does exist.", $"Success, confirmed row '{rowNumber}' Rechargable Battery checkbox does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).RechargebleBatteryCheckboxClick(), $"Failure, failed to click row '{rowNumber}' Rechargable Battery checkbox.", $"Success, clicked row '{rowNumber}' Rechargable Battery checkbox.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm Rechargable Battery checkbox (is|is not) checked")]
		public void BatteryCharacteristicsSectionTableRowConfirmRechargableBatteryCheckboxChecked(string rowNumberString, string is_isnot)
		{
			bool expected = is_isnot == "is";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).RechargebleBatteryCheckboxExists(), $"Failure, failed to confirm row '{rowNumber}' Rechargable Battery checkbox does exist.", $"Success, confirmed row '{rowNumber}' Rechargable Battery checkbox does exist."))
			{
				return;
			}
			Report.IsTrue(expected == batteryCharacteristicsTable.RowByNumber(rowNumber).RechargebleBatteryCheckboxChecked(), $"Failure, failed to confirm row '{rowNumber}' Rechargable Battery checkbox {is_isnot} checked.", $"Success, confirmed row '{rowNumber}' Rechargable Battery checkbox {is_isnot} checked.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', (check|uncheck) Rechargable Battery checkbox")]
		public void BatteryCharacteristicsSectionTableRowCheckUncheckRechargableBatteryCheckbox(string rowNumberString, string check_uncheck)
		{
			bool expected = check_uncheck == "check";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).RechargebleBatteryCheckboxExists(), $"Failure, failed to confirm row '{rowNumber}' Rechargable Battery checkbox does exist.", $"Success, confirmed row '{rowNumber}' Rechargable Battery checkbox does exist."))
			{
				return;
			}
			if (expected != batteryCharacteristicsTable.RowByNumber(rowNumber).RechargebleBatteryCheckboxChecked())
			{
				Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).RechargebleBatteryCheckboxClick(), $"Failure, failed to click row '{rowNumber}' Rechargable Battery checkbox.", $"Success, clicked row '{rowNumber}' Rechargable Battery checkbox.");
			}
			Report.IsTrue(expected == batteryCharacteristicsTable.RowByNumber(rowNumber).RechargebleBatteryCheckboxChecked(), $"Failure, failed to confirm row '{rowNumber}' Rechargable Battery checkbox is {check_uncheck}ed.", $"Success, confirmed row '{rowNumber}' Rechargable Battery checkbox is {check_uncheck}ed.");
		}
		#endregion

		#region Non-Lithium-Ion Watt Hour Steps
		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm Non-Lithium-Ion Watt Hour text input (does|does not) exist")]
		public void BatteryCharacteristicsSectionTableRowConfirmNonLithiumIonWattHourTextInputExists(string rowNumberString, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			Report.IsTrue(expected == batteryCharacteristicsTable.RowByNumber(rowNumber).NonLithiumIonWattHourTextInputExists(), $"Failure, failed to confirm row '{rowNumber}' Non-Lithium-Ion Watt Hour text input {does_doesnot} exist.", $"Success, confirmed row '{rowNumber}' Non-Lithium-Ion Watt Hour text input {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', click Non-Lithium-Ion Watt Hour text input")]
		public void BatteryCharacteristicsSectionTableRowClickNonLithiumIonWattHourTextInput(string rowNumberString)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).NonLithiumIonWattHourTextInputExists(), $"Failure, failed to confirm row '{rowNumber}' Non-Lithium-Ion Watt Hour text input does exist.", $"Success, confirmed row '{rowNumber}' Non-Lithium-Ion Watt Hour text input does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).NonLithiumIonWattHourTextInputClick(), $"Failure, failed to click row '{rowNumber}' Non-Lithium-Ion Watt Hour text input.", $"Success, clicked row '{rowNumber}' Non-Lithium-Ion Watt Hour text input.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', clear Non-Lithium-Ion Watt Hour text input")]
		public void BatteryCharacteristicsSectionTableRowClearNonLithiumIonWattHourTextInput(string rowNumberString)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).NonLithiumIonWattHourTextInputExists(), $"Failure, failed to confirm row '{rowNumber}' Non-Lithium-Ion Watt Hour text input does exist.", $"Success, confirmed row '{rowNumber}' Non-Lithium-Ion Watt Hour text input does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).NonLithiumIonWattHourTextInputClear(), $"Failure, failed to clear row '{rowNumber}' Non-Lithium-Ion Watt Hour text input.", $"Success, clear row '{rowNumber}' Non-Lithium-Ion Watt Hour text input.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', enter into Non-Lithium-Ion Watt Hour text input: (.*)")]
		public void BatteryCharacteristicsSectionTableRowEnterIntoNonLithiumIonWattHourTextInput(string rowNumberString, string textInput)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).NonLithiumIonWattHourTextInputExists(), $"Failure, failed to confirm row '{rowNumber}' Non-Lithium-Ion Watt Hour text input does exist.", $"Success, confirmed row '{rowNumber}' Non-Lithium-Ion Watt Hour text input does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).NonLithiumIonWattHourTextInputEnterText(textInput), $"Failure, failed to enter into row '{rowNumber}' Non-Lithium-Ion Watt Hour text input: '{textInput}'.", $"Success, entered into row '{rowNumber}' Non-Lithium-Ion Watt Hour text input: '{textInput}'.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm Non-Lithium-Ion Watt Hour text input (does|does not) match: (.*)")]
		public void BatteryCharacteristicsSectionTableRowConfirmNonLithiumIonWattHourTextInputMatches(string rowNumberString, string does_doesnot, string expectedText)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).NonLithiumIonWattHourTextInputExists(), $"Failure, failed to confirm row '{rowNumber}' Non-Lithium-Ion Watt Hour text input does exist.", $"Success, confirmed row '{rowNumber}' Non-Lithium-Ion Watt Hour text input does exist."))
			{
				return;
			}
			string displayedText = batteryCharacteristicsTable.RowByNumber(rowNumber).NonLithiumIonWattHourTextInputGetValue();
			Report.IsTrue(expected == displayedText.Equals(expectedText), $"Failure, failed to confirm row '{rowNumber}' Non-Lithium-Ion Watt Hour displayed text: '{displayedText}' {does_doesnot} match expected text: '{expectedText}'.", $"Success, confirmed row '{rowNumber}' Non-Lithium-Ion Watt Hour displayed text: '{displayedText}' {does_doesnot} match expected text: '{expectedText}'.");
		}
		#endregion

		#region Unit Weight Steps
		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm Unit Weight text input (does|does not) exist")]
		public void BatteryCharacteristicsSectionTableRowConfirmUnitWeightTextInputExists(string rowNumberString, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			Report.IsTrue(expected == batteryCharacteristicsTable.RowByNumber(rowNumber).UnitWeightTextInputExists(), $"Failure, failed to confirm row '{rowNumber}' Unit Weight text input {does_doesnot} exist.", $"Success, confirmed row '{rowNumber}' Unit Weight text input {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', click Unit Weight text input")]
		public void BatteryCharacteristicsSectionTableRowClickUnitWeightTextInput(string rowNumberString)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).UnitWeightTextInputExists(), $"Failure, failed to confirm row '{rowNumber}' Unit Weight text input does exist.", $"Success, confirmed row '{rowNumber}' Unit Weight text input does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).UnitWeightTextInputClick(), $"Failure, failed to click row '{rowNumber}' Unit Weight text input.", $"Success, clicked row '{rowNumber}' Unit Weight text input.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', clear Unit Weight text input")]
		public void BatteryCharacteristicsSectionTableRowClearUnitWeightTextInput(string rowNumberString)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).UnitWeightTextInputExists(), $"Failure, failed to confirm row '{rowNumber}' Unit Weight text input does exist.", $"Success, confirmed row '{rowNumber}' Unit Weight text input does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).UnitWeightTextInputClear(), $"Failure, failed to clear row '{rowNumber}' Unit Weight text input.", $"Success, clear row '{rowNumber}' Unit Weight text input.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', enter into Unit Weight text input: (.*)")]
		public void BatteryCharacteristicsSectionTableRowEnterIntoUnitWeightTextInput(string rowNumberString, string textInput)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).UnitWeightTextInputExists(), $"Failure, failed to confirm row '{rowNumber}' Unit Weight text input does exist.", $"Success, confirmed row '{rowNumber}' Unit Weight text input does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).UnitWeightTextInputEnterText(textInput), $"Failure, failed to enter into row '{rowNumber}' Unit Weight text input: '{textInput}'.", $"Success, entered into row '{rowNumber}' Unit Weight text input: '{textInput}'.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm Unit Weight text input (does|does not) match: (.*)")]
		public void BatteryCharacteristicsSectionTableRowConfirmUnitWeightTextInputMatches(string rowNumberString, string does_doesnot, string expectedText)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).UnitWeightTextInputExists(), $"Failure, failed to confirm row '{rowNumber}' Unit Weight text input does exist.", $"Success, confirmed row '{rowNumber}' Unit Weight text input does exist."))
			{
				return;
			}
			string displayedText = batteryCharacteristicsTable.RowByNumber(rowNumber).UnitWeightTextInputGetValue();
			Report.IsTrue(expected == displayedText.Equals(expectedText), $"Failure, failed to confirm row '{rowNumber}' Unit Weight displayed text: '{displayedText}' {does_doesnot} match expected text: '{expectedText}'.", $"Success, confirmed row '{rowNumber}' Unit Weight displayed text: '{displayedText}' {does_doesnot} match expected text: '{expectedText}'.");
		}
		#endregion

		#region Remove Button Steps
		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm Remove button (does|does not) exist")]
		public void BatteryCharacteristicsSectionTableRowConfirmRemoveButtonExists(string rowNumberString, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			Report.IsTrue(expected == batteryCharacteristicsTable.RowByNumber(rowNumber).RemoveButtonExists(), $"Failure, failed to confirm row '{rowNumber}' Remove button {does_doesnot} exist.", $"Success, confirmed row '{rowNumber}' Remove button {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', click Remove button")]
		public void BatteryCharacteristicsSectionTableRowClickRemoveButton(string rowNumberString)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (!Report.IsTrue(batteryCharacteristicsTable.RowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
			{
				return;
			}
			if (!Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).RemoveButtonExists(), $"Failure, failed to confirm row '{rowNumber}' Remove button does exist.", $"Success, confirmed row '{rowNumber}' Remove button does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.RowByNumber(rowNumber).RemoveButtonClick(), $"Failure, failed to click row '{rowNumber}' Remove button.", $"Success, clicked row '{rowNumber}' Remove button.");
		}
		#endregion

		#endregion

		#region Add Another Battery Steps
		[RegexStepDefinition(@"In the Battery Characteristics section, confirm Add Another Battery button (does|does not) exist")]
		public void BatteryCharacteristicsSectionConfirmAddAnotherBatteryButtonExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			Report.IsTrue(expected == batteryCharacteristicsTable.AddAnotherBatteryButtonExists(), $"Failure, failed to confirm Add Another Battery button {does_doesnot} exist.", $"Success, confirmed Add Another Battery button {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section, click Add Another Battery button")]
		public void BatteryCharacteristicsSectionClickAddAnotherBatteryButton()
		{
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if(!Report.IsTrue(batteryCharacteristicsTable.AddAnotherBatteryButtonExists(), $"Failure, failed to confirm Add Another Battery button does exist.", $"Success, confirmed Add Another Battery button does exist."))
			{
				return;
			}
			Report.IsTrue(batteryCharacteristicsTable.AddAnotherBatteryButtonClick(), $"Failure, failed to click Add Another Battery button.", $"Success, clicked Add Another Battery button.");
		}
		#endregion

		#region Shared Steps
		/// Copy and paste the following tables to create the table structure as needed 
		///| Battery Common Name | IEC/ANSI Name | Standard Dimensions | Rechargeable Battery | Non-Lithium-Ion Watt Hour | Unit Weight | 
		[RegexStepDefinition(@"In the Battery Characteristics section, add the following batteries:")]
		public void BatteryCharacteristicsSectionAddFillowingBatteries(Table inputTable)
		{
			Report.UseSubSteps = true;
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			List<string> requiredColumns = new List<string> { "Battery Common Name", "IEC/ANSI Name", "Standard Dimensions", "Rechargeable Battery", "Non-Lithium-Ion Watt Hour", "Unit Weight" };
			requiredColumns.ForEach(requiredColumn =>
			{
				if (!inputTable.ContainsColumn(requiredColumn))
				{
					Report.Error($"Error: Input Table does not contain '{requiredColumn}'.");
				}
			});

			if (!batteryCharacteristicsTable.RowByNumber(1).BatteryCommonNameComboboxGetValue().IsNullOrEmpty())
			{
				Report.StartSubStep($"Then In the Battery Characteristics section, click Add Another Battery button");
				this.BatteryCharacteristicsSectionClickAddAnotherBatteryButton();
			}
			int i = batteryCharacteristicsTable.RowsListCount();
			foreach (TableRow inputRow in inputTable.Rows)
			{
				Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', set Battery Common Name to: {inputRow["Battery Common Name"]}");
				this.BatteryCharacteristicsSectionTableSetRowBatteryCommonName("1", inputRow["Battery Common Name"]);
				if (inputTable.ContainsColumn("IEC/ANSI Name") && !inputRow["IEC/ANSI Name"].IsNullOrEmpty())
				{
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', click IEC/ANSI Name select");
					this.BatteryCharacteristicsSectionTableRowClickIECANSINameSelect("1");
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', confirm IEC/ANSI Name select '{inputRow["IEC/ANSI Name"]}' option does exist");
					this.BatteryCharacteristicsSectionTableRowConfirmIECANSINameSelectOptionExists("1", inputRow["IEC/ANSI Name"], "does");
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', click IEC/ANSI Name select '{inputRow["IEC/ANSI Name"]}' option");
					this.BatteryCharacteristicsSectionTableRowClickIECANSINameSelectOptionExists("1", inputRow["IEC/ANSI Name"]);
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', confirm IEC/ANSI Name select does display value: {inputRow["IEC/ANSI Name"]}");
					this.BatteryCharacteristicsSectionTableRowConfirmIECANSINameSelectDisplaysValue("1", "does", inputRow["IEC/ANSI Name"]);
				}
				if (inputTable.ContainsColumn("Standard Dimensions") && !inputRow["Standard Dimensions"].IsNullOrEmpty())
				{
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', click Standard Dimensions select");
					this.BatteryCharacteristicsSectionTableRowClickStandardDimensionsSelect("1");
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', confirm Standard Dimensions select '{inputRow["Standard Dimensions"]}' option does exist");
					this.BatteryCharacteristicsSectionTableRowConfirmStandardDimensionsSelectOptionExists("1", inputRow["Standard Dimensions"], "does");
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', click Standard Dimensions select '{inputRow["Standard Dimensions"]}' option");
					this.BatteryCharacteristicsSectionTableRowClickStandardDimensionsSelectOptionExists("1", inputRow["Standard Dimensions"]);
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', confirm Standard Dimensions select does display value: {inputRow["Standard Dimensions"]}");
					this.BatteryCharacteristicsSectionTableRowConfirmStandardDimensionsSelectDisplaysValue("1", "does", inputRow["Standard Dimensions"]);
				}

				if (inputTable.ContainsColumn("Rechargeable Battery") && !inputRow["Rechargeable Battery"].IsNullOrEmpty())
				{
					bool expected = inputRow["Rechargeable Battery"].Equals("True", System.StringComparison.OrdinalIgnoreCase);
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', {(expected ? "check" : "uncheck")} Rechargable Battery checkbox");
					this.BatteryCharacteristicsSectionTableRowCheckUncheckRechargableBatteryCheckbox("1", expected ? "check" : "uncheck");
				}

				if (inputTable.ContainsColumn("Non-Lithium-Ion Watt Hour") && !inputRow["Non-Lithium-Ion Watt Hour"].IsNullOrEmpty())
				{
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', confirm Non-Lithium-Ion Watt Hour text input does exist");
					this.BatteryCharacteristicsSectionTableRowConfirmNonLithiumIonWattHourTextInputExists("1", "does");
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', click Non-Lithium-Ion Watt Hour text input");
					this.BatteryCharacteristicsSectionTableRowClickNonLithiumIonWattHourTextInput("1");
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', enter into Non-Lithium-Ion Watt Hour text input: {inputRow["Non-Lithium-Ion Watt Hour"]}");
					this.BatteryCharacteristicsSectionTableRowEnterIntoNonLithiumIonWattHourTextInput("1", inputRow["Non-Lithium-Ion Watt Hour"]);
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', confirm Non-Lithium-Ion Watt Hour text input does match: {inputRow["Non-Lithium-Ion Watt Hour"]}");
					this.BatteryCharacteristicsSectionTableRowConfirmNonLithiumIonWattHourTextInputMatches("1", "does", inputRow["Non-Lithium-Ion Watt Hour"]);
				}

				if (inputTable.ContainsColumn("Unit Weight") && !inputRow["Unit Weight"].IsNullOrEmpty())
				{
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', confirm Unit Weight text input does exist");
					this.BatteryCharacteristicsSectionTableRowConfirmUnitWeightTextInputExists("1", "does");
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', click Unit Weight text input");
					this.BatteryCharacteristicsSectionTableRowClickUnitWeightTextInput("1");
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', enter into Unit Weight text input: {inputRow["Unit Weight"]}");
					this.BatteryCharacteristicsSectionTableRowEnterIntoUnitWeightTextInput("1", inputRow["Unit Weight"]);
					Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '1', confirm Unit Weight text input does match: {inputRow["Unit Weight"]}");
					this.BatteryCharacteristicsSectionTableRowConfirmUnitWeightTextInputMatches("1", "does", inputRow["Unit Weight"]);
				}

				if (i < inputTable.RowCount)
				{
					Report.StartSubStep($"In the Battery Characteristics section, confirm the Battery Characteristcs table does have {i} row");
					this.BatteryCharacteristicsSectionConfirmTableHasNRows("does", i.ToString(), (i == 1) ? "row" : "rows");
					Report.StartSubStep($"Then In the Battery Characteristics section, click Add Another Battery button");
					this.BatteryCharacteristicsSectionClickAddAnotherBatteryButton();
					Report.StartSubStep($"In the Battery Characteristics section, confirm the Battery Characteristcs table does have {++i} rows");
					this.BatteryCharacteristicsSectionConfirmTableHasNRows("does", i.ToString(), "rows");
				}
			}
		}

		[RegexStepDefinition(@"In the Battery Characteristics section, remove item row: (.*)")]
		public void BatteryCharacteristicsSectionRemoveItemRow(string rowNumberString)
		{
			Report.UseSubSteps = true;
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			Ingredients_Steps ingredients_Steps = new Ingredients_Steps();
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			int rowCount = batteryCharacteristicsTable.RowsListCount();
			if (Report.IsTrue(rowNumber <= rowCount, $"Failure, row '{rowNumber}' does not exist in Battery Characteristics table (Max row:{rowCount}).", $"Success, row '{rowNumber}' does exist in Battery Characteristics table."))
			{
				Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '{rowNumber}', confirm Remove button does exist");
				this.BatteryCharacteristicsSectionTableRowConfirmRemoveButtonExists(rowNumberString, "does");
				Report.StartSubStep($"In the Battery Characteristics section Battery Characteristics table row number '{rowNumber}', click Remove button");
				this.BatteryCharacteristicsSectionTableRowClickRemoveButton(rowNumberString);
				Report.StartSubStep($"Confirm a modal is displayed");
				ingredients_Steps.IngredientsModalIsIsNotDisplayed("is");
				Report.StartSubStep($"Confirm displayed modal has title: Remove Item");
				ingredients_Steps.IngredientsModalHasTitle("Remove Item");
				Report.StartSubStep($"In displayed modal, click Yes footer button");
				ingredients_Steps.IngredientsModalClickFooterButton("Yes");
				Report.StartSubStep($"Confirm a modal is not displayed");
				ingredients_Steps.IngredientsModalIsIsNotDisplayed("is not");
				rowCount = --rowCount;
				Report.StartSubStep($"In the Battery Characteristics section, confirm the Battery Characteristcs table does have {rowCount} {(rowCount > 1 ? "rows" : "row")}");
				this.BatteryCharacteristicsSectionConfirmTableHasNRows("does", rowCount.ToString(), rowCount > 1 ? "rows" : "row");
			}
		}
		#endregion

		#endregion
	}
}
