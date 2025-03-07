using Reqnroll;
using System;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;


namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "AlertsPage")]
	class Steps_AlertsPage
	{
		[RegexStepDefinition(@"In the Alerts Page, set the 'WPS ID' to: (.*)")]
		public void EnterWpsID(string wpsId)
		{
			Report.StartStep("Verify WPS ID field is displayed");
			new AlertsPage().WpsIdFieldExists();
			Report.StartStep($"Attempting to enter '{wpsId}' into wps id search text input.");
			new AlertsPage().WpsIdText(wpsId);


		}

		[RegexStepDefinition(@"In the Alerts Page, set the 'Product Name' to: (.*)")]
		public void EnterProductName(string productName)
		{
			Report.StartStep("Verify Product name field is displayed");
			new AlertsPage().ProductNameFieldExists();
			Report.StartStep($"Attempting to enter '{productName}' into product name search text input.");
			new AlertsPage().ProductNameText(productName);


		}

		[RegexStepDefinition(@"In the Alerts Page, set the 'Notification Date' in format yyyy-mm-dd to: (.*)")]
		public void EnterNotificationDate(string date)
		{
			Report.StartStep("Verify Notification Date field is displayed");
			new AlertsPage().NotificationDateFieldExists();
			Report.StartStep($"Attempting to enter '{date}' into Notification Date search input.");
			new AlertsPage().NotificationDateText(date);

		}

		[RegexStepDefinition(@"In the Alerts Page, set the option of 'Search Type' to: (.*)")]
		public void SelectSearchType(string option)
		{
			string label = "Search Pattern";
			new AlertsPage().SelectDropdownValue(label, option);
		}

		[RegexStepDefinition(@"In the Alerts Page, set the option of 'Alert Type' to: (.*)")]
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

		[RegexStepDefinition(@"In the Alerts Page, set the option of 'Brand Name' to: (.*)")]
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

		[RegexStepDefinition(@"In the Alerts Page,  click the 'Filter' button")]
		public void ClickTheFilterButton()
		{
			string buttonText = "Filter";
			new AlertsPage().ButtonClick(buttonText);
		}

		[RegexStepDefinition(@"In the Alerts Page,  click the 'Clear Filter' button")]
		public void ClickTheClearFilterButton()
		{
			string buttonText = "ClearFilter";
			new AlertsPage().ButtonClick(buttonText);
		}

		[RegexStepDefinition(@"In the Alerts Page,  click the 'Export' button")]
		public void ClickTheExportButton()
		{
			string buttonText = "Export";
			new AlertsPage().ButtonClick(buttonText);
		}

		[RegexStepDefinition(@"In the Alerts Page, click the ' More Filter' button")]
		public void ClickTheMoreFilterButton()
		{
			new AlertsPage().MoreFiltersButtonClick();
		}

		[RegexStepDefinition(@"In the Alerts Page, (check|uncheck) the show archived checkbox")]
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
		[RegexStepDefinition(@"In the Alerts Page, Confirm the checkbox show archived (is|is not) checked")]
		public void TheCheckboxShowArchivedIsIsNotChecked(string is_isnot)
		{
			bool expected = is_isnot == "is";
			bool isChecked = new AlertsPage().ArchivedCheckbox().Checked();
			Report.IsTrue(isChecked == expected, $"Failed to confirm the checkbox show archives {(expected ? "is not" : "is")} checked'!", $"Successfully confirmed the checkbox checkbox show archives {is_isnot} checked");
		}

		[RegexStepDefinition(@"In the Alerts Page,  (.*) field  (should|should not) be displayed")]
		public void ThenInThePageIShouldOrShouldNotSeeQuestion(string field_name, string shouldOrNot)
		{
			var thisAlertsPage = new AlertsPage();

			Report.IsTrue(thisAlertsPage.SelectOptionExists(field_name) == (shouldOrNot == "should"),
				"Field is not showing as expected", "Field is showing as expected");
		}


		[RegexStepDefinition(@"In the Alerts Page, the confirm field: 'Brand Name' (is|is not) displayed")]
		public void ConfirmBrandNameIsIsNotDisplayed(string is_isnot)
		{
			string field_name = "Brand Name";
			this.ThenInThePageIShouldOrShouldNotSeeQuestion(field_name, is_isnot);
		}

		[RegexStepDefinition(@"In the Alerts Page, the confirm field: 'Alert Type' (is|is not) displayed")]
		public void ConfirmAlertTypeIsIsNotDisplayed(string is_isnot)
		{
			string field_name = "Alert Type";
			this.ThenInThePageIShouldOrShouldNotSeeQuestion(field_name, is_isnot);
		}

		[RegexStepDefinition(@"In the My Alerts Page, click action (Details |Resolve |UPC(s) Provided ) for product name: (.*)")]
		public void ClickActionForProduct(string action, string productname)
		{
			Report.IsTrue(new AlertsPage().ForProductClickAction(productname, action),
				$"Failed to click action:{action} for product: {productname}",
				$"Successfully clicked action: {action} for product: {productname}");
		}

		[RegexStepDefinition(@"In the Alerts Page, In the Products table for the product name: (.*) selected save the type to context as: (.*)")]
		public void InAlertsPageSaveTypeForAProductName(string savedAs, string productName)
		{
			string type = new AlertsPage().GetTypeForAProduct(productName);
			Context.AddToContext(savedAs, type);
		}

		[RegexStepDefinition(@"In the Alerts Page, for Product Type: (.*) Resolve redirects to: (.*)")]
		public void ConfirmResolvePage(string type, string pageTitle)
		{

			if (type.ToLower().Contains("savedas"))
			{
				type = (string)Context.GetFromContext(type);
				Report.Info($"Type of the product is: {type}");
			}

			Report.IsTrue(new AlertsPage().GetResolvePageTitle() == pageTitle, "The search box did not contain the text that was searched for", "The search box contained the text that was searched for");

		}

		[RegexStepDefinition(@"In the Alerts Page, Details popup (is|is not) displayed")]
		public void DetailsPopupIsIsNotDisplayed(string is_isnot)
		{
			bool displayed = false;
			if (is_isnot == "is")
			{
				displayed = true;
			}
			else if (is_isnot != "is not")
			{
				Report.Failure("Step parameter must either be 'is' or 'is not'!");
				return;
			}

			Report.IsTrue(new AlertsPage().DetailsPopUpDisplayed() == displayed, $"Details popup{(displayed ? "was not" : "was")} displayed when it {(displayed ? "was" : "was not")} expected to be!", $"Details popup {(displayed ? "was" : "was not")} displayed as expected");
		}

		[RegexStepDefinition(@"In the Alerts Page,  Details Popup click the 'Close' button")]
		public void ClickTheCloseButton()
		{
			Report.IsTrue(new AlertsPage().ClickCloseInDetailsPopUp(), "The close button was not clicked successfully", "The close button was clicked successfully");
		}

	}
}
