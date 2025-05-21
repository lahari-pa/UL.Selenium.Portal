using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.SpecflowRewrite
{
	internal class BatteryCharacteristicsTable : SeleniumBaseObject
	{
		#region Class Objects
		protected override By ContainerElementLocator => By.XPath("//div[contains(@class,'panel-table')]");
		public string Title => this.FindElement(By.XPath(".//div[@data-bind='text: description']"), 1)?.Text.Trim();
		private List<IWebElement> ColumnLabelsList => [.. this.FindElements(By.XPath(".//th[text()]"), 1)];
		private IWebElement ColumnLabel(string columnLabel) => this.ColumnLabelsList.FirstOrDefault(x => x.Text.Trim() == columnLabel);
		private List<BatteryCharacteristicsTableRow> BatteryCharacteristicsTableRowsList => [.. this.ContainerElement.FindElements(By.XPath(".//tbody//tr"), 1).Select(x => new BatteryCharacteristicsTableRow(x))];
		public BatteryCharacteristicsTableRow BatteryCharacteristicsTableRowByNumber(int rowNumber) => this.BatteryCharacteristicsTableRowsList.ElementAt(rowNumber - 1);
		private List<IWebElement> ErrorAlertsList => [.. this.FindElements(By.XPath(".//div[@class = 'alert alert-danger']//span[@data-bind]"), 1)];
		private List<IWebElement> WarningAlertsList => [.. this.FindElements(By.XPath(".//div[@class = 'alert alert-warning']//span[@data-bind]"), 1)];
		private IWebElement AddAnotherBatteryButton => this.FindElement(By.XPath(".//button[normalize-space()='Add Another Battery']"), 1);
		#endregion

		#region Class Methods
		#region Column Labels Methods
		public bool ColumnLabelsListExists()
		{
			Report.Info($"Attempting to confirm column labels list exists.");
			return !this.ColumnLabelsList.IsNullOrEmpty();
		}

		public List<string> ColumnLabelsListGet()
		{
			Report.Info($"Attempting to get column labels list.");
			return [.. this.ColumnLabelsList.Select(x => x.Text.Trim())];
		}

		public bool ColumnLabelExists(string columnLabel)
		{
			Report.Info($"Attempting to confirm '{columnLabel}' column label exists.");
			return this.ColumnLabel(columnLabel) != null;
		}
		#endregion

		#region Battery Characteristics Table Rows Methods
		public bool BatteryCharacteristicsTableRowsListExists()
		{
			Report.Info($"Attemptig to confirm battery characteristics table rows list exists.");
			return !this.BatteryCharacteristicsTableRowsList.IsNullOrEmpty();
		}

		public int BatteryCharacteristicsTableRowsListCount()
		{
			Report.Info($"Attempting to get battery characteristcs table rows list count.");
			return this.BatteryCharacteristicsTableRowsList.Count;
		}

		public bool BatteryCharacteristcsTableRowByNumberExists(int rowNumber)
		{
			Report.Info($"Attempting to confirm battery characteristics table row with '{rowNumber}' row number exists.");
			return rowNumber > 0 && rowNumber <= this.BatteryCharacteristicsTableRowsList.Count;
		}
		#endregion

		#region Error Alerts Methods
		public bool ErrorAlertsListExists()
		{
			Report.Info($"Attempting to confirm error alerts list exists.");
			return !this.ErrorAlertsList.IsNullOrEmpty();
		}
		#endregion

		#region Warning Alerts Methods
		public bool WarningAlertsListExists()
		{
			Report.Info($"Attempting to confirm warning alerts list exists.");
			return !this.WarningAlertsList.IsNullOrEmpty();
		}
		#endregion

		#region Add Another Battery Button Methods
		public bool AddAnotherBatteryButtonExists()
		{
			Report.Info($"Attempting to confirm Add Another Battery button exists.");
			return this.AddAnotherBatteryButton != null;
		}

		public bool AddAnotherBatteryButtonClick()
		{
			Report.Info($"Attempting to click Add Another Battery button.");
			return this.AddAnotherBatteryButton.TryClick();
		}
		#endregion
		#endregion
	}

	public class BatteryCharacteristicsTableRow(IWebElement containerElement)
	{
		#region Class Objects
		private IWebElement ContainerElement { get; set; } = containerElement;
		private IWebElement BatteryCommonNameCombobox => this.ContainerElement.FindElement(By.XPath(".//td[@datacode='BATCOM']//span[@role='combobox']"), 1);
		private IWebElement IECANSINameSelect => this.ContainerElement.FindElement(By.XPath(".//td[@datacode='BATIEC']//select"), 1);
		private List<IWebElement> IECANSINameSelectOptionsList => [.. this.IECANSINameSelect.FindElements(By.XPath(".//option"), 1)];
		private IWebElement IECANSINameSelectOption(string optionLabel) => this.IECANSINameSelectOptionsList.FirstOrDefault(x => x.Text.Trim().Equals(optionLabel, System.StringComparison.Ordinal));
		private IWebElement StandardDimensionsSelect => this.ContainerElement.FindElement(By.XPath(".//td[@datacode='BATDIM']//select"), 1);
		private List<IWebElement> StandardDimensionsSelectOptionsList => [.. this.StandardDimensionsSelect.FindElements(By.XPath(".//option"), 1)];
		private IWebElement StandardDimensionsSelectOption(string optionLabel) => this.StandardDimensionsSelectOptionsList.FirstOrDefault(x => x.Text.Trim().Equals(optionLabel, System.StringComparison.Ordinal));
		private IWebElement RechargebleBatteryCheckbox => this.ContainerElement.FindElement(By.XPath(".//td[@datacode='RECHARGE']//input[@type='checkbox']"), 1);
		private IWebElement NonLithiumIonWattHourTextInput => this.ContainerElement.FindElement(By.XPath(".//td[@datacode='BATTWH']//input[@type='text']"), 1);
		private IWebElement UnitWeightTextInput => this.ContainerElement.FindElement(By.XPath(".//td[@datacode='BATTWGHT']//input[@type='text']"), 1);
		private IWebElement RemoveButton => this.ContainerElement.FindElement(By.XPath(".//a[@aria-label = 'Delete row']"), 1);
		#endregion

		#region Class Methods
		#region Battery Common Name Methods
		public bool BatteryCommonNameComboboxExists()
		{
			Report.Info($"Attempting to confirm Battery Common Name combobox exists.");
			return this.BatteryCommonNameCombobox != null;
		}

		public bool BatteryCommonNameComboboxClick()
		{
			Report.Info($"Attempting to click Battery Common Name combobox.");
			return this.BatteryCommonNameCombobox.TryClick();
		}

		public string BatteryCommonNameComboboxGetValue()
		{
			Report.Info($"Attempting to get Battery Common Name combobox value.");
			return this.BatteryCommonNameCombobox.GetValue();
		}

		public bool BatteryCommonNameComboboxExpanded()
		{
			Report.Info($"Attempting to confirm Battery Common Name combobox is expanded.");
			return this.BatteryCommonNameCombobox.GetAttribute("aria-expanded").Equals("true", System.StringComparison.Ordinal);
		}
		#endregion

		#region IEC/ANSI Name Select Methods
		public bool IECANSINameSelectExists()
		{
			Report.Info($"Attempting to confirm IEC/ANSI Name select exists.");
			return this.IECANSINameSelect != null;
		}

		public bool IECANSINameSelectClick()
		{
			Report.Info($"Attempting to click IEC/ANSI Name select.");
			return this.IECANSINameSelect.TryClick();
		}

		public string IECANSINameSelectGetValue()
		{
			Report.Info($"Attempting to get IEC/ANSI Name select value.");
			return this.IECANSINameSelect.GetValue();
		}

		public List<string> IECANSINameSelectOptionsListGet()
		{
			Report.Info($"Attempting to get IEC/ANSI Name select options list");
			return [.. this.IECANSINameSelectOptionsList.Select(x => x.Text.Trim())];
		}

		public bool IECANSINameSelectOptionExists(string optionLabel)
		{
			Report.Info($"Attempting to confirm IEC/ANSI Name select '{optionLabel}' option exists.");
			return this.IECANSINameSelectOption(optionLabel) != null;
		}

		public bool IECANSINameSelectOptionClick(string optionLabel)
		{
			Report.Info($"Attempting to click IEC/ANSI Name select '{optionLabel}' option.");
			return this.IECANSINameSelectOption(optionLabel).TryClick();
		}
		#endregion

		#region Standard Dimensions Select Methods
		public bool StandardDimensionsSelectExists()
		{
			Report.Info($"Attempting to confirm Standard Dimensions select exists.");
			return this.StandardDimensionsSelect != null;
		}

		public bool StandardDimensionsSelectClick()
		{
			Report.Info($"Attempting to click Standard Dimensions select.");
			return this.StandardDimensionsSelect.TryClick();
		}

		public string StandardDimensionsSelectGetValue()
		{
			Report.Info($"Attempting to get Standard Dimensions select value.");
			return this.StandardDimensionsSelect.GetValue();
		}

		public List<string> StandardDimensionsSelectOptionsListGet()
		{
			Report.Info($"Attempting to get Standard Dimensions select options list");
			return [.. this.StandardDimensionsSelectOptionsList.Select(x => x.Text.Trim())];
		}

		public bool StandardDimensionsSelectOptionExists(string optionLabel)
		{
			Report.Info($"Attempting to confirm Standard Dimensions select '{optionLabel}' option exists.");
			return this.StandardDimensionsSelectOption(optionLabel) != null;
		}

		public bool StandardDimensionsSelectOptionClick(string optionLabel)
		{
			Report.Info($"Attempting to click Standard Dimensions select '{optionLabel}' option.");
			return this.StandardDimensionsSelectOption(optionLabel).TryClick();
		}
		#endregion

		#region Rechargeble Battery Checkbox Methods
		public bool RechargebleBatteryCheckboxExists()
		{
			Report.Info($"Attempting to confirm Rechargeble Battery checkbox exists.");
			return this.RechargebleBatteryCheckbox != null;
		}

		public bool RechargebleBatteryCheckboxClick()
		{
			Report.Info($"Attempting to click Rechargeble Battery checkbox.");
			return this.RechargebleBatteryCheckbox.TryClick();
		}

		public bool RechargebleBatteryCheckboxChecked()
		{
			Report.Info($"Attempting to confirm Rechargeble Battery checkbox is checked.");
			return this.RechargebleBatteryCheckbox.Checked();
		}
		#endregion

		#region Non-Lithium-Ion Watt Hour Text Input Methods
		public bool NonLithiumIonWattHourTextInputExists()
		{
			Report.Info($"Attempting to confirm Non-Lithium-Ion Watt Hour text input exists.");
			return this.NonLithiumIonWattHourTextInput != null;
		}

		public bool NonLithiumIonWattHourTextInputClick()
		{
			Report.Info($"Attempting to click Non-Lithium-Ion Watt Hour text input.");
			return this.NonLithiumIonWattHourTextInput.TryClick();
		}

		public bool NonLithiumIonWattHourTextInputEnterText(string inputText)
		{
			Report.Info($"Attempting to enter into Non-Lithium-Ion Watt Hour text input: '{inputText}'.");
			return this.NonLithiumIonWattHourTextInput.TryEnterText(inputText);
		}

		public string NonLithiumIonWattHourTextInputGetValue()
		{
			Report.Info($"Attempting to get Non-Lithium-Ion Watt Hour text input value.");
			return this.NonLithiumIonWattHourTextInput.GetValue();
		}

		public bool NonLithiumIonWattHourTextInputClear()
		{
			Report.Info($"Attempting to clear Non-Lithium-Ion Watt Hour text input.");
			return this.NonLithiumIonWattHourTextInput.ClearTextBox();
		}
		#endregion

		#region Unit Weight Text Input Methods
		public bool UnitWeightTextInputExists()
		{
			Report.Info($"Attempting to confirm Unit Weight text input exists.");
			return this.UnitWeightTextInput != null;
		}

		public bool UnitWeightTextInputClick()
		{
			Report.Info($"Attempting to click Unit Weight text input.");
			return this.UnitWeightTextInput.TryClick();
		}

		public bool UnitWeightTextInputEnterText(string inputText)
		{
			Report.Info($"Attempting to enter into Unit Weight text input: '{inputText}'.");
			return this.UnitWeightTextInput.TryEnterText(inputText);
		}

		public string UnitWeightTextInputGetValue()
		{
			Report.Info($"Attempting to get Unit Weight text input value.");
			return this.UnitWeightTextInput.GetValue();
		}

		public bool UnitWeightTextInputClear()
		{
			Report.Info($"Attempting to clear Unit Weight text input.");
			return this.UnitWeightTextInput.ClearTextBox();
		}
		#endregion

		#region Remove Button Methods
		public bool RemoveButtonExists()
		{
			Report.Info($"Attempting to confirm delete row button exists.");
			return this.RemoveButton != null;
		}

		public bool RemoveButtonClick()
		{
			Report.Info($"Attempting to click delete row button.");
			return this.RemoveButton.TryClick();
		}
		#endregion
		#endregion
	}
}
