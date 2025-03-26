using Reqnroll;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using System;
using System.IO;
using UL.Automation.ReqnrollHelpers.Classes;



namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "DeleteActiveOrdersPage")]
	class Steps_DeleteActiveOrders
	{
		[RegexStepDefinition(@"In the Delete Active Orders section, In UPC Number field enter value: (.*)")]
		public void EnterUPCNumber(string value)
		{
			string fieldname = "UPC Number";
			new DeleteActiveOrdersPage().EnterText(fieldname, value);
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, In WPS ID field enter value: (.*)")]
		public void EnterWPSID(string value)
		{
			string fieldname = "WPS ID";
			new DeleteActiveOrdersPage().EnterText(fieldname, value);
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, In Product Name field enter value: (.*)")]
		public void EnterProductName(string value)
		{
			string fieldname = "Product Name";
			new DeleteActiveOrdersPage().EnterText(fieldname, value);
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, Filter the products by: (All|Not Yet Submitted|Completed)")]
		public void FilterTheProductsByOptions(string filter)
		{
			Report.Info("Filtering Product Grid by " + filter);
			var deleteActiveOrdersPage = new DeleteActiveOrdersPage();
			Report.IsTrue(deleteActiveOrdersPage.ClickStatusFilter(filter), $"Failed to click filter option:{filter}", $"Successfully filtered grid by: {filter}");
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, click 'Filter' button")]
		public void ClickFilter()
		{
			string button = "Filter";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the Delete Active Orders section, click 'Clear Filter' button")]
		public void ClickClearFilter()
		{
			string button = "Clear Filter";
			new Steps_Prototype().ClickButton(button);
		}






	}


}

