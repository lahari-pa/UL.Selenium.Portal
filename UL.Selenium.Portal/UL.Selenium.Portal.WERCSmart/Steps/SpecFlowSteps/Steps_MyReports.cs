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
			string section = "Zip Report?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
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


		[RegexStepDefinition(@"In the My Reports page,search WPSID by entering value: (.*)")]
		public void SearchWPSId(string text)
		{
			SupplierReports supplierReportsObject = new SupplierReports();
			Report.IsTrue(supplierReportsObject.EnterTextIntoWPSIDTextFieldInMyReportsPage(text), "Failed to find the correct text in WPSID textfield", "Successfully found the correct text in WPSID textfield");
			Report.IsTrue(supplierReportsObject.SelectFirstResultInWPSIDTextFieldSearchResultsInMyReportsPage(), "Failed to select first result in the WPSID textfield search results", "Successfully selected the first result in the WPSID textfield search results");
		}


	}
}
