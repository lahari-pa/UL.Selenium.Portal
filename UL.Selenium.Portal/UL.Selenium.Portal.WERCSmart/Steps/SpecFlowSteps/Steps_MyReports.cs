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
	[Binding, Scope(Tag = "ReportsPage")]
	class Steps_MyReports
	{
		[RegexStepDefinition(@"In the My  Reports page, I select (.*) report link")]
		public void ClickTheRetportLink(string retailerText)
		{
			new Steps_Prototype().ClickLinkElement(retailerText);
		}


		[RegexStepDefinition(@"In the My Reports page, click the 'Request Report' button")]
		public void ClickTheRequestReportButton()
		{
			string button = "Request Report";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the My Reports page, set the option in section: 'Select File Type' to: (.*)")]
		public void SelectFileType(string option)
		{
			string section = "Select File Type";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the My Reports page, (check|uncheck) checkbox in 'Zip Report?'")]
		public void ZipReportCheckbox(string option)
		{
			SupplierReports supplierReportsObject = new SupplierReports();
			Report.IsTrue(supplierReportsObject.SelectZipReportCheckbox(), "Failed to select Zip Report Checkbox", "Successfully selected Zip Report Checkbox");
		}

		[RegexStepDefinition(@"In the My Reports page, the 'Report Download' modal window (should|should not) be displayed")]
		public void TheReportDownloadIsDisplayed(string condition)
		{
			string modalTitle = "Report Download";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeading(condition, modalTitle);
		}

		[RegexStepDefinition(@"In the My Reports page, in 'Report Download' modal window click (Close|x)")]
		public void ClickCloseInReportDownload(string buttonTitle)
		{
			string popupTitle = "Report Download";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, buttonTitle);
		}


		[RegexStepDefinition(@"In the My Reports page, search WPSID by entering value: (.*)")]
		public void SearchWPSId(string text)
		{
			SupplierReports supplierReportsObject = new SupplierReports();
			Report.IsTrue(supplierReportsObject.EnterTextIntoWPSIDTextFieldInMyReportsPage(text), "Failed to find the correct text in WPSID textfield", "Successfully found the correct text in WPSID textfield");
			Report.IsTrue(supplierReportsObject.SelectFirstResultInWPSIDTextFieldSearchResultsInMyReportsPage(), "Failed to select first result in the WPSID textfield search results", "Successfully selected the first result in the WPSID textfield search results");
		}

		[RegexStepDefinition(@"In the My Reports page, click Download button for the report with Report Name: (.*) File Type: (CSV|XLSX|CSV \(Zip\)|XLSX \(Zip\)) Requested By: (.*)")]
		public void ClickTheDownloadButtonForTheReportWithReportNameFileTypeRequestedBy(string reportName, string type, string requestedBy)
		{
			GeneralUtilities.Wait_for_load_finish();
			SupplierReports supplierReportsObject = new SupplierReports();
			Report.IsTrue(supplierReportsObject.ReportHistroryTableFilterByColumn("DateRequested", "descending"), "The column was not set to the correct filter direction", "The column was set to the correct filter direction");
			Report.IsTrue(supplierReportsObject.SelectDownloadButtonForTheMostRecentReport(reportName, type, requestedBy), "Failed to click Download button", "Successfully clicked Download button");
			GeneralUtilities.Wait_for_load_finish();
		}

		[RegexStepDefinition(@"In the My Reports page, Verify the report information Report Name: (.*) File Type: (CSV|XLSX|CSV \(Zip\)|XLSX \(Zip\)) Requested By: (.*)")]
		public void VerifyReportIsDisplayedInTable(string reportName, string type, string requestedBy)
		{
			SupplierReports supplierReportsObject = new SupplierReports();
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(supplierReportsObject.ReportHistroryTableFilterByColumn("DateRequested", "descending"), "The column was not set to the correct filter direction", "The column was set to the correct filter direction");
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(supplierReportsObject.CheckReportDataForMostRecentFile(reportName, type, requestedBy), "Failed to display report in table", "Successfully displayed report in table");
		}



		[RegexStepDefinition(@"In the My Reports Page, set the 'Start Date' in format mm-dd-yyyy to: (.*)")]
		public void EnterStartDate(string date)
		{
			string label = "Start Date";
			Report.StartStep($"Attempting to enter '{date}' into Start Date search input.");
			new SupplierReports().DateText(label, date);

		}

		[RegexStepDefinition(@"In the My Reports Page, set the 'End Date' in format mm-dd-yyyy to: (.*)")]
		public void EnterEndDate(string date)
		{
			string label = "End Date";
			Report.StartStep($"Attempting to enter '{date}' into End Date search input.");
			new SupplierReports().DateText(label, date);

		}
	}
}
