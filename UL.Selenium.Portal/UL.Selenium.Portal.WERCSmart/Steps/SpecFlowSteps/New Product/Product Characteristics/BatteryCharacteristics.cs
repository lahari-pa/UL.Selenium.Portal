using Reqnroll;
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
		#region 
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

		[RegexStepDefinition(@"In the Battery Characteristics section, confirm the Battery Characteristics table column labels list (does|does not) exist")]
		public void BatteryCharacteristicsSectionConfirmTableColumnLabelsListExists(string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			Report.IsTrue(expected == batteryCharacteristicsTable.ColumnLabelsListExists(), $"Failure, failed to confirm the Battery Characteristics Table column labels list {does_doesnot} exist.", $"Success, confirmed Battery Characteristcs Table column labels list {does_doesnot} exist.");
		}

		[RegexStepDefinition(@"In the Battery Characteristics section, confirm the Battery Characteristics table (.*) column (is|is not) displayed")]
		public void BatteryCharacteristicsSectionConfirmTableColumnExists(string columnLabel, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if(Report.IsTrue(batteryCharacteristicsTable.ColumnLabelsListExists(), $"Failure, failed to confirm the Battery Characteristics Table column labels list does exist.", $"Success, confirmed Battery Characteristcs Table column labels list does exist."))
			{
				Report.IsTrue(batteryCharacteristicsTable.ColumnLabelExists(columnLabel), $"Failure, failed to confirm '{columnLabel}' column {does_doesnot} exist.", $"Success, confirmed '{columnLabel}' column {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Battery Characteristics section, confirm Battery Characteristics table row number '(.*)' (does|does not) exist")]
		public void BatteryCharacteristicsSectionTableConfirmRowNumberExists(string rowNumberString, string does_doesnot)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (Report.IsTrue(batteryCharacteristicsTable.BatteryCharacteristicsTableRowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				Report.IsTrue(expected == batteryCharacteristicsTable.BatteryCharacteristcsTableRowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' {does_doesnot} exist.", $"Success, confirmed row '{rowNumber}' {does_doesnot} exist.");
			}
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', click Battery Common Name combobox")]
		public void BatteryCharacteristicsSectionTableClickRowBatteryCommonNameCombobox(string rowNumberString)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			if (Report.IsTrue(batteryCharacteristicsTable.BatteryCharacteristicsTableRowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				if(Report.IsTrue(batteryCharacteristicsTable.BatteryCharacteristcsTableRowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
				{
					if(Report.IsTrue(batteryCharacteristicsTable.BatteryCharacteristicsTableRowByNumber(rowNumber).BatteryCommonNameComboboxExists(), $"Failure, failed to confirm row '{rowNumber}' Battery Common Name combobox does exist.", $"Success, confirmed row '{rowNumber}' Battery Common Name combobox does exist."))
					{
						Report.IsTrue(batteryCharacteristicsTable.BatteryCharacteristicsTableRowByNumber(rowNumber).BatteryCommonNameComboboxClick(), $"Failure, failed to click row '{rowNumber}' Battery Common Name combobox.", $"Success, clicked row '{rowNumber}' Battery Common Name combobox.");
					}
				}
			}
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', click Battery Common Name searchbox text input")]
		public void BatteryCharacteristicsSectionTableClickRowBatteryCommonNameSearchboxTextInput(string rowNumberString)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			if (Report.IsTrue(batteryCharacteristicsTable.BatteryCharacteristicsTableRowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				if (Report.IsTrue(batteryCharacteristicsTable.BatteryCharacteristcsTableRowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
				{
					if (Report.IsTrue(searchBoxPrototype.WaitForContainerToBeVisible(), $"Failure, failed to confirm search box does exist.", $"Success, confirmed search box does exist."))
					{
						Report.IsTrue(searchBoxPrototype.SearchInputClick(), $"Failure, failed to click search box search input.", $"Success, clicked search box search input");
					}
				}
			}
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', enter into Battery Common Name searchbox text input: (.*)")]
		public void BatteryCharacteristicsSectionTableEnterRowBatteryCommonNameSearchboxTextInput(string rowNumberString, string searchInput)
		{
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			if (Report.IsTrue(batteryCharacteristicsTable.BatteryCharacteristicsTableRowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				if (Report.IsTrue(batteryCharacteristicsTable.BatteryCharacteristcsTableRowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
				{
					if (Report.IsTrue(searchBoxPrototype.WaitForContainerToBeVisible(), $"Failure, failed to confirm search box does exist.", $"Success, confirmed search box does exist."))
					{
						Report.IsTrue(searchBoxPrototype.SearchInputEnterText(searchInput), $"Failure, failed to enter into search box search input: '{searchInput}'.", $"Success, entered into search box search input: '{searchInput}'");
					}
				}
			}
		}

		[RegexStepDefinition(@"In the Battery Characteristics section Battery Characteristics table row number '(.*)', confirm Battery Common Name searchbox text input (does|does not) display: (.*)")]
		public void BatteryCharacteristicsSectionTableConfirmRowBatteryCommonNameSearchboxTextInputValue(string rowNumberString, string does_doesnot, string searchInput)
		{
			bool expected = does_doesnot == "does";
			Report.IsTrue(int.TryParse(rowNumberString, out int rowNumber), $"Failure, '{rowNumberString}' is not a valid number.", $"Success, entered valid number '{rowNumber}'.");
			BatteryCharacteristicsTable batteryCharacteristicsTable = new BatteryCharacteristicsTable();
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			if (Report.IsTrue(batteryCharacteristicsTable.BatteryCharacteristicsTableRowsListExists(), $"Failure, failed to confirm Battery Characteristics table rows list does exist.", $"Success, confirmed Battery Characteristics table rows list does exist."))
			{
				if (Report.IsTrue(batteryCharacteristicsTable.BatteryCharacteristcsTableRowByNumberExists(rowNumber), $"Failure, failed to confirm row '{rowNumber}' does exist.", $"Success, confirmed row '{rowNumber}' does exist."))
				{
					if (Report.IsTrue(searchBoxPrototype.WaitForContainerToBeVisible(), $"Failure, failed to confirm search box does exist.", $"Success, confirmed search box does exist."))
					{
						Report.IsTrue(searchBoxPrototype.SearchInputEnterText(searchInput), $"Failure, failed to enter into search box search input: '{searchInput}'.", $"Success, entered into search box search input: '{searchInput}'");
					}
				}
			}
		}
		#endregion
	}
}
