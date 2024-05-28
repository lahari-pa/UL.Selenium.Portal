using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Type
{
	[Binding, Scope(Tag = "Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ReciewAndSubmit_Section:OptionalReportsAndDocumentsAvailableForPurchase")]
	internal class OptionalReportsAndDocumentsAvailableForPurchase
	{
		[RegexStepDefinition(@"In the Optional Reports and Documents Available for Purchase Section, set the option in section: (.*) to: (.*)")]
		public void SetContainsCircuitBoard(string section, string selection)
		{
			var reports = new OptionalReports();
			Report.IsTrue(reports.SelectInputForSection(section, selection), $"Failed to select input {selection} for section {section}.",
				$"Successfully selected input {selection} for section {section}.");
		}
		[RegexStepDefinition(@"In the Optional Reports and Documents Available for Purchase Section, in section: (.*) the total price should be (.*)")]
		public void CheckPrice(string section, string value)
		{
			var reports = new OptionalReports();
			Report.IsTrue(reports.CheckTotalForSection(section, value), $"Failed to find the correct value {value} for section {section}.",
				$"Successfully found correct value {value} for section {section}.");
		}
	}
}
