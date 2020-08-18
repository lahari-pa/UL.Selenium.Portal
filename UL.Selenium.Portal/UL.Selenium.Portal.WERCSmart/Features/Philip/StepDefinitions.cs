using System;
using System.IO;
using System.Linq;
using Microsoft.Web.Administration;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Automation.Selenium.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Philip
{
	[Binding, Scope(Tag = "Philip")]
	class StepDefinitions
	{
		public object TheProduct { get; private set; }
		public string File { get; private set; }

		//[StepDefinition(@"I confirm there is a checkbox displayed in the message at the top of the Ingredients page")]
		//public void GivenIConfirmThereIsAMessageDisplayedAtTheTopOfTheIngredientsPage()
		//{
		//	WebElements webElementsObject = new WebElements();
		//	Report.IsTrue(webElementsObject.CheckForMessageAtTheTopOfIngredientsPage(), "Failed to find message at the top of the ingredients page", "Successfully found message at the top of the ingredients page");
		//}

		[StepDefinition(@"I confirm the Formulation > Batteries displays the correct text")]
		public void GivenIConfirmTheFormulationBatteriesDisplaysTheCorrectText()
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckTextInForumulationBatteriesPage(), "The text in the Formulation > Batteries page displayed the incorrect text", "The text in the Formulation > Batteries page displayed the correct text");
		}

		[StepDefinition(@"I select (Excel|CSV) from the Select File Type")]
		public void ThenISelectCSVFromTheSelectFileType(string excelOrCSV)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.SelectFromSelectFileType(excelOrCSV), "Failed to select " + excelOrCSV, "Successfully selected " + excelOrCSV);
			Delay.Seconds(9999);
		}


		[StepDefinition(@"I select the Zip Report Checkbox")]
		public void GivenISelectTheZipReportCheckbox()
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.SelectZipReportCheckbox(), "Failed to select Zip Report Checkbox", "Successfully selected Zip Report Checkbox");
		}

		[StepDefinition(@"I see a Report Download popup with the following text: (.*)")]
		public void GivenISeeAReportDownloadPopupWithTheFollowingText()
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.SelectZipReportCheckbox(), "Failed to find the correct text in the popup", "Successfully founded the correct text in the popup");
		}


		[StepDefinition(@"I select the Request Report button (excel|html) file is produced called (.*) and save as (.*)")]
		public void ThenISelectTheRequestReportButton(string filetype, string file, string savedAs)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.SelectRequestReportButton(), "Failed to select Request Report button", "Successfully selected Request Report button");

			Delay.Seconds(10);

			//string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
			//Report.Info("Downloads folder: " + downloadsFolder);

			//string[] dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);

			//var selRetailDetails = new RetailPartnersDetails();

			//foreach (string file_ in dir)
			//{ 
			//	File.Delete(file_);
			//}


			//selRetailDetails.ClickProductsInScope();
			//Report.Success("Clicked Products in Scope button!");
			//Report.Screenshot();

			//dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);

			//int i = 0;
			//Report.Info("Waiting for up to 30 seconds for the file to appear in the downloads folder...");
			//while (!dir.Any() && i < 30)
			//{
			//	dir = Directory.GetFiles(downloadsFolder, "*_Report_DataUsage*.xlsx", SearchOption.AllDirectories);
			//	Delay.Seconds(Delay.SpeedFactor * 1);
			//	i++;
			//}

			//if (Report.IsTrue(dir.Any(), "No file was found with name " + file, "File with name: " + dir.FirstOrDefault() + " was found successfully!"))
			//{
			//	Context.AddToContext(savedAs, dir.FirstOrDefault());
			//}


		}

		[StepDefinition(@"I click Close in the Report Download popup")]
		public void ThenIClickCloseInTheReportDownloadPopup()
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.SelectCloseButtonInReportDownloadPopup(), "Failed to select Close button", "Successfully selected Close button");
		}

		[StepDefinition(@"I click the Download button for the most recent Report")]
		public void ThenIClickTheDownloadButtonForTheMostRecentReport()
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.SelectDownloadButtonForMostRecenReport(), "Failed to select Download button", "Successfully selected Download button");
			Delay.Seconds(10);
		}

		[StepDefinition(@"I confirm the most recent file has the following information Report Name: (.*) File Type: (CSV|XLSX|CSV (Zip)| XLSX (Zip)) Date Requested: (.*) Requested By: (.*)")]
		public void ThenIConfirmTheMostRecentFileHasTheFollowingInformationReportNameWasteClassificationSummaryFileTypeCSVDataRequestedRequestedByWERCSTest_Automation_ProductsAccount(string reportName, string type, string dateRequested, string requestedBy)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckReportDataForMostRecentFile(reportName, type, dateRequested, requestedBy), "Failed to select match data for most recent file", "Successfully matched data for most recent file");
		}












		[StepDefinition(@"I Check the Delete Rows Warning Popup contains the following text, Line One: (.*), Line Two: (.*)")]
		public void ThenICheckTheDeleteRowsWarningPopupContainsTheFollowingTextYouAreAboutToDelete(string lineOne, string lineTwo)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckDeleteRowsWarningPopupContainsText(lineOne, lineTwo), "Failed to confirm the following text in the Delete Rows Warning Popup: " + lineOne + lineTwo, "Successfully confirmed the following text in the Delete Rows Warning Popup: " + lineOne + lineTwo);
		}


		[StepDefinition(@"I check for the following text: (.*) in the Optional Reports and Documents Available for Purchase Page")]
		public void ThenICheckForTheFollowingTextInTheOptionalReportsAndDocumentsAvailableForPurchasePage(string text)
		{
			WebElements webElementsObject = new WebElements();
			Report.IsTrue(webElementsObject.CheckForTheFollowingTextInTheOptionReportsPage(text), "Failed to confirm the following text: " + text + " in the Optional Reports page", "Successfully confirmed the following text: " + text + " in the Optional Reports page");
		}




		[StepDefinition(@"I confirm that the the option: (.*) (.*) checked for the following section: (.*)")]
		public void ThenIConfirmThatTheTheOptionCheckedForTheFollowingSection(string option, string isOrIsNot, string section)
		{
			WebElements webElementsObject = new WebElements();

			if (isOrIsNot.ToLower() == "is")
			{
				Report.IsTrue(webElementsObject.ConfirmOptionIsCheckedInSection(option, section), "The option " + option + " was not checked", "The option " + option + " was checked");
			}
			else
			{
				Report.IsTrue(!webElementsObject.ConfirmOptionIsCheckedInSection(option, section), "The option " + option + " was checked", "The option " + option + " was not checked");
			}
		}

		[StepDefinition(@"I confirm that the following section is available for selection: (.*)")]
		public void ThenIConfirmThatTheFollowingSectionIsAvailableForSelection(string sectionName)
		{
			WebElements webElementsObject = new WebElements();
			webElementsObject.ConfirmSectionIsAvailableForSelection(sectionName);
		}


		[StepDefinition(@"I click close for the warning popup titled: (.*)")]
		public void ThenIClickContinueForTheWarningPopupTitledCaliforniaCleaningRightToKnow(string title)
		{
			WebElements webElementsObject = new WebElements();
			//webElementsObject.ClickCloseInPopupWithTitle(title);
		}


	}
}
