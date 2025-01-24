using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.Utilities.Helpers;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Reflection;
using UL.Automation.Utilities;
using UL.Automation.ReqnrollHelpers.Attributes;


namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "AlertsPage")]
	class Steps_AlertsPage
	{
		[RegexStepDefinition(@"In the Alerts section, set the 'WPS ID' to: (.*)")]
		public void EnterWpsID(string wpsId)
		{
			Report.StartStep("Verify WPS ID field is displayed");
			new AlertsPage().WpsIdFieldExists();
			Report.StartStep($"Attempting to enter '{wpsId}' into wps id search text input.");
			new AlertsPage().NotificationDateText(wpsId);


		}

		[RegexStepDefinition(@"In the Alerts section, set the 'Product Name' to: (.*)")]
		public void EnterProductName(string productName)
		{
			Report.StartStep("Verify Product name field is displayed");
			new AlertsPage().ProductNameFieldExists();
			Report.StartStep($"Attempting to enter '{productName}' into product name search text input.");
			new AlertsPage().ProductNameText(productName);


		}

		[RegexStepDefinition(@"In the Alerts section, set the 'Notification Date' in format yyyy-mm-dd to: (.*)")]
		public void EnterNotificationDate(string date)
		{
			Report.StartStep("Verify Notification Date field is displayed");
			new AlertsPage().NotificationDateFieldExists();
			Report.StartStep($"Attempting to enter '{date}' into Notification Date search input.");
			new AlertsPage().NotificationDateText(date);

		}

		[RegexStepDefinition(@"In the Alerts section, set the option of 'Search Type' to: (.*)")]
		public void SelectSearchType(string option)
		{
			string label = "Search Pattern";
			new AlertsPage().SelectDropdownValue(label, option);
		}

		[RegexStepDefinition(@"In the Alerts section, set the option of 'Alert Type' to: (.*)")]
		public void SelectAlertType(string option)
		{
			string label = "Alert Type";
			var optionExists = new AlertsPage().SelectOptionExists(label);
			if (!optionExists)
			{
				new AlertsPage().MoreFiltersButtonClick();
			}
			new AlertsPage().SelectDropdownValue(label, option);
		}

		[RegexStepDefinition(@"In the Alerts section, set the option of 'Brand Name' to: (.*)")]
		public void SelectBrandName(string option)
		{
			string label = "Brand Name";
			var optionExists = new AlertsPage().SelectOptionExists(label);
			if (!optionExists)
			{
				new AlertsPage().MoreFiltersButtonClick();
			}
			new AlertsPage().SelectDropdownValue(label, option);
		}

		[RegexStepDefinition(@"In the Alerts section,  click the 'Filter' button")]
		public void ClickTheFilterButton()
		{
			string buttonText = "Filter";
			new AlertsPage().ButtonClick(buttonText);
		}

		[RegexStepDefinition(@"In the Alerts section,  click the 'Clear Filter' button")]
		public void ClickTheClearFilterButton()
		{
			string buttonText = "ClearFilter";
			new AlertsPage().ButtonClick(buttonText);
		}

		[RegexStepDefinition(@"In the Alerts section,  click the 'Export' button")]
		public void ClickTheExportButton()
		{
			string buttonText = "Export";
			new AlertsPage().ButtonClick(buttonText);
		}

		[RegexStepDefinition(@"In the Alerts section, click the ' More Filter' button")]
		public void ClickTheMoreFilterButton()
		{
			new AlertsPage().MoreFiltersButtonClick();
		}

		[RegexStepDefinition(@"In the Alerts section, (check|uncheck) the show archived checkbox")]
		public void ICheckTheCheckboxShowArchived(string check)
		{
			bool toCheck = false;
			if (check == "check")
			{
				toCheck = true;
			}
			else if (check == "uncheck")
			{
				toCheck = false;
			}
			else
			{
				throw new Exception("Specflow paramater must be equal to 'check' or 'uncheck'");
			}
			bool isChecked = new AlertsPage().ArchivedCheckbox().Checked();
			if (isChecked == toCheck)
			{
				Report.Success($"The checkbox was already {check}ed");
				return;
			}
			Report.IsTrue(new AlertsPage().CheckArchivedCheckbox(),
				$"Failed to check the checkbox!",
				$"Successfully checked the checkbox");
			Report.IsTrue(new AlertsPage().ArchivedCheckbox().Checked() == toCheck,
				$"The checkbox was not {check}ed after",
				$"The checkbox is {check}ed as expected");
		}
		[RegexStepDefinition(@"In the Alerts section, Confirm the checkbox show archived (is|is not) checked")]
		public void TheCheckboxShowArchivedIsIsNotChecked(string is_isnot)
		{
			bool expected = is_isnot == "is";
			bool isChecked = new AlertsPage().ArchivedCheckbox().Checked();
			Report.IsTrue(isChecked == expected, $"Failed to confirm the checkbox show archives {(expected ? "is not" : "is")} checked'!", $"Successfully confirmed the checkbox checkbox show archives {is_isnot} checked");
		}


	}
}
