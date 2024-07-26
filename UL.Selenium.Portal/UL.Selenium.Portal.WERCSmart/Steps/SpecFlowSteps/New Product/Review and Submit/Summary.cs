using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.ForwardProductRegistration;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Review_and_Submit
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary")]

	class SummaWERCSmart_Distributor_NewProducts_ReviewAndSubmit_Summary
	{
		[RegexStepDefinition(@"In the Summary Page, the '(.*)' section should be showing the following value: (.*)")]
		public void InTheSummarySectionCheckTypeOfProduct(string section, string value)
		{
			new StepsDataSummarySheet().ShouldBeShowingFollowing(section, value);
		}
		[RegexStepDefinition(@"I switch to the tab with Data Summary page")]
		public void SwitchToTheSummary()
		{
			new GlobalSteps().SwitchToDataSumaryTab();
		}
		[RegexStepDefinition(@"I close the tab with Data Summary page")]
		public void CloseTheSummaryPage()
		{
			new GlobalSteps().CloseDataSummaryTab();
		}
		[RegexStepDefinition(@"In the Summary Page, verify table data in column (.*) showing the value: (.*)")]
		public void InTheSummarySectionCheckTableData(string column, string value)
		{
			if(value.ToLower().Contains("saved as"))
			{
				value = Context.GetFromContext(value.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim()).ToString();		
			}
			Report.IsTrue(new DataSummary().VerifyTableValueInSammeryPage(column, value), $"Failed to confirm there is value {value} in column {column}", $"Successfully confirmed there is value {value} in column {column}");
		}
		[RegexStepDefinition(@"In the Summary Page, verify table data for 'Document' section (.*) in column (.*) showing the value: (.*)")]
		public void InTheSummaryDocumenrSectionCheckTableData(string sectionName, string column, string value)
		{
			if (value.ToLower().Contains("saved as"))
			{
				value = Context.GetFromContext(value.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim()).ToString();
			}
			Report.IsTrue(new DataSummary().VerifyDocumentsTableValueInSammeryPage(sectionName, column, value), $"Failed to confirm there is value {value} in column {column}", $"Successfully confirmed there is value {value} in column {column}");
		}
		[RegexStepDefinition(@"In the Summary Page, the document section (.*) should be showing the following document: (.*)")]
		public void InTheSummaryPageDocumentSectionShouldBeShowingTheFollowingDocument(string section, string option)
		{
			var dataSummarySheet = new DataSummary();
			string found = dataSummarySheet.GetDocumentForSection(section, option);
			Report.IsTrue(found.Contains(option),
				$"Expected: {option} but got: {found} for section {section}.",
				$"Got value: {option} as expected for section {section}.");
		}
		[RegexStepDefinition(@"In the Summary Page, the Product Document section (.*) should be showing the following document: (.*)")]
		public void InTheSummaryPageProductDocumentSectionShouldBeShowingTheFollowingDocument(string section, string option)
		{
			var dataSummarySheet = new DataSummary();
			string found = dataSummarySheet.GetProductDocumentForSection(section, option);
			Report.IsTrue(found.Contains(option),
				$"Expected: {option} but got: {found} for section {section}.",
				$"Got value: {option} as expected for section {section}.");
		}
		[RegexStepDefinition(@"In the Summary Page, the Product Document section (.*) click the view link for the following document: (.*)")]
		public void InTheSummaryPageProductDocumentSectionClickViewForTheFollowingDocument(string section, string option)
		{
			var dataSummarySheet = new DataSummary();
			bool result = dataSummarySheet.ClickViewProductDocumentForSection(section, option);
			Report.IsTrue(result,
				$"Failure, failed to click view button for {option} in section {section}.",
				$"Success, clicked view button for {option} in section {section}.");
		}
		[RegexStepDefinition(@"In the Summary Page, click the View button for section: (.*)")]
		public void InTheSummaryPageIClickTheViewButtonForDocument(string section)
		{
			var dataSummarySheet = new DataSummary();
			Report.IsTrue(dataSummarySheet.ClickViewForDocument(section),
				$"Failed to click the View button for section {section}.",
				$"Successfully clicked the View button for section {section}.");
		}
		[RegexStepDefinition(@"In the Summary Page, after clicking 'View' button I confirm pdf file is downloaded")]
		public void InTheSummaryPageAfterClickingViewPdfIsDownloaded()
		{
			string file = "testdoc.pdf";
			string savedAs = "downloadedFile";
			new Steps_Prototype().ConfirmFileAppearsInDownloadsFolder(file, savedAs);
		}
	}
}

