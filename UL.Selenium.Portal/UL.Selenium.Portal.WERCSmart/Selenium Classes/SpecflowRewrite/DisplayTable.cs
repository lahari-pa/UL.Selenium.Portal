using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NPOI.OpenXmlFormats.Dml.Diagram;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.BaseClasses;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Classes;

namespace UL.Selenium.Portal.WERCSmart.Selenium_Classes.SpecflowRewrite
{
	public class DisplayTable : SeleniumBaseObject
	{
		#region Class Objects
		private string BasePath = "//div[contains(@class,'panel-table')]";
		protected override By ContainerElementLocator => By.XPath(BasePath);
		public string Title => this.FindElement(By.XPath(".//div[@data-bind='text: description']"), 1)?.Text.Trim();
		private List<IWebElement> ColumnLabelsList => [.. this.FindElements(By.XPath(".//th[text()]"), 1)];
		private IWebElement ColumnLabel(string columnLabel) => this.ColumnLabelsList.FirstOrDefault(x => x.Text.Trim().Equals(columnLabel, System.StringComparison.Ordinal));
		public List<DisplayTableRow> RowsList => [.. this.FindElements(By.XPath(".//tbody//tr")).Select(x => new DisplayTableRow(x, this.ColumnLabelsList))];
		public DisplayTableRow RowByColumnValue(string columnLabel, string value) => this.RowsList.FirstOrDefault(x => x.TableCell(columnLabel).Text.Equals(value, System.StringComparison.Ordinal));
		#endregion

		#region Class Methods
		#region Constructors
		public DisplayTable(string title = "")
		{
			if (!title.IsNullOrEmpty())
			{
				BasePath = $"{BasePath}[.//div[@data-bind='text: description'][text()='{title}']]";
			}
		}
		#endregion

		#region Column Labels Methods
		public bool ColumnLabelsListExists()
		{
			Report.Info($"Attempting to confirm Column Labels list exists.");
			return !this.ColumnLabelsList.IsNullOrEmpty();
		}

		public int ColumnLabelsListCount()
		{
			Report.Info($"Attempting to get Column Labels list count.");
			return this.ColumnLabelsList.Count;
		}

		public List<string> ColumnLabelsStringList()
		{
			Report.Info($"Attrmpting to get list of Column Labels.");
			return this.ColumnLabelsList.Select(x => x.Text).ToList();
		}

		public bool ColumnLabelExists(string columnLabel)
		{
			Report.Info($"Attempting to confirm '{columnLabel}' Column Label exists.");
			return this.ColumnLabel(columnLabel) != null;
		}

		public bool ColumnLabelClick(string columnLabel)
		{
			Report.Info($"Attempting to click '{columnLabel}' Column Label.");
			return this.ColumnLabel(columnLabel).TryClick();
		}
		#endregion

		#region Rows Methods
		public bool RowsListExists()
		{
			Report.Info($"Attempting to confirm Rows list exists.");
			return !this.RowsList.IsNullOrEmpty();
		}

		public int RowsListCount()
		{
			Report.Info($"Attempting to get Rows list count.");
			return this.RowsList.Count;
		}

		public bool RowByColumnValueExists(string columnLabel, string value)
		{
			Report.Info($"Attempting to confirm row with '{columnLabel}' column value: '{value}' exists.");
			return this.RowByColumnValue(columnLabel, value) != null;
		}
		#endregion
		#endregion
	}

	public class DisplayTableRow
	{
		#region Class Objects
		private IWebElement ContainerElement;
		public Dictionary<string, IWebElement> ColumnLabelsDictionary = [];
		private List<IWebElement> TableCellList => [.. ContainerElement.FindElements(By.XPath(".//td"))];
		public IWebElement TableCell(string columnLabel) => ColumnLabelsDictionary[columnLabel];
		#endregion

		#region Class Methods
		public DisplayTableRow(IWebElement containerElement, List<IWebElement> columnLabelsList)
		{
			ContainerElement = containerElement;
			foreach (IWebElement columnLabel in columnLabelsList)
			{
				string datacode = columnLabel.GetAttribute("data-code");
				IWebElement TableCell = this.TableCellList.FirstOrDefault(x => x.GetAttribute("datacode").Equals(datacode, System.StringComparison.Ordinal));
				ColumnLabelsDictionary.Add(columnLabel.Text.Trim(), TableCell);
			}

		}

		#endregion
	}
}
