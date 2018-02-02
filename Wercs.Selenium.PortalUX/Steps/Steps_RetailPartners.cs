using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SafewareReporting;
using SafewareSeleniumUtilities;
using SeleniumUtilities;
using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "RetailPartners")]
	class StepsRetailPartners
	{
		[StepDefinition(@"I should see the following subheading (.*)")]
		public void ThenIShouldSeeTheFollowingSubheading(string subheading)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking that the subheading " + subheading + " is showing");
			try
			{
				Report.Info("Checking that the subheading " + subheading + " is showing");
				var selRetailPartners = new RetailPartners();

				if (!selRetailPartners.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}

				var subHeadingsShowing = selRetailPartners.SubHeadingsShowing();
				Report.IsTrue(subHeadingsShowing.Contains(subheading.Trim()),
					"Subheading was not showing as expected! Expected: '" + subheading + "', but found: '" + string.Join("', '", subHeadingsShowing) + "'!",
					"Subheading was showing: '" + subheading + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see the following heading (.*)")]
		public void ThenIShouldSeeTheFollowingHeading(string heading)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking that the heading " + heading + " is showing");
			try
			{
				Report.Info("Checking that the heading " + heading + " is showing");
				var selRetailPartners = new RetailPartners();

				if (!selRetailPartners.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}


				var headingShowing = selRetailPartners.HeaderShowing();
				Report.IsTrue(headingShowing.Trim() == heading.Trim(),
					"Header was not showing as expected! Expected: '" + heading + "', but found: '" + headingShowing + "'!",
					"Header was showing: '" + heading + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I select the retailer: (.*)")]
		public void SelectRetailer(string retailer)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Selecting retailer " + retailer);
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Selecting retailer " + retailer);

				var selRetailPartners = new RetailPartners();

				if (!selRetailPartners.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}


				Report.IsTrue(selRetailPartners.ClickRetailer(retailer),
					"Failed to click retailer " + retailer + "!",
					"Retailer " + retailer + " was selected successfully!");
				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm that there is a section labeled: (.*)")]
		public void ConfirmHeadingShowing(string header)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Confirming that there is a section labeled: " + header);
			try
			{
				Report.Info("Confirming that there is a section labeled: " + header);

				var selRetailDetails = new RetailParntersDetails();

				if (!selRetailDetails.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}


				Report.IsTrue(selRetailDetails.HeaderShowing(header),
					"Header '" + header + "' was not showingon page!",
					"Header '" + header + "' was showing, as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm that under the pie chart I see the label: (.*)")]
		public void ConfirmPieChartLegend(string legendLabel)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Confirming that the pie chart has legend containing: " + legendLabel);
			try
			{
				Report.Info("Confirming that the pie chart has legend containing: " + legendLabel);

				var selRetailDetails = new RetailParntersDetails();

				if (!selRetailDetails.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}

				var legendShowing = selRetailDetails.GetChartLegend();
				Report.IsTrue(legendShowing.EndsWith(legendLabel),
					"Legend was showing: '" + legendShowing + "', but expected to end with: '" + legendLabel + "'",
					"Legend was showing: '" + legendShowing + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm that: (.*) is showing under the Data Consent Tiers heading")]
		public void ThenConfirmYouSeeUnderTheDataConsentTiersHeading(string tierInformation)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Confirming that '" + tierInformation + "' is showing under the Data Consent Tiers heading");
			try
			{
				Report.Info("Confirming that '" + tierInformation + "' is showing under the Data Consent Tiers heading");

				var selRetailDetails = new RetailParntersDetails();

				if (!selRetailDetails.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}

				var tierInfoShowing = selRetailDetails.GetTierInformation();
				Report.IsTrue(tierInfoShowing == tierInformation,
					"Tier information was showing: '" + tierInfoShowing + "', but was expected to show: '" + tierInformation + "'",
					"Tier information was showing: '" + tierInformation + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the More Information hyperlink")]
		public void ClickMoreInformation()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking 'More Information' Hyperlink");
			try
			{
				Report.Info("Clicking 'More Information' Hyperlink");

				var selRetailDetails = new RetailParntersDetails();

				if (!selRetailDetails.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}


				selRetailDetails.ClickMoreInformation();
				Report.Success("More Information link clicked!");
				Report.Info("Switching to new window");

				Context.AddToContext("MainWindowHandle", GlobalParameters.Browser.WebBrowser.CurrentWindowHandle);

				var windowHandles = GlobalParameters.Browser.WebBrowser.WindowHandles;
				var newTab = windowHandles.FirstOrDefault(x => x != GlobalParameters.Browser.WebBrowser.CurrentWindowHandle);
				GlobalParameters.Browser.WebBrowser.SwitchTo().Window(newTab);
				Report.Success("Window switched successfully!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I (should|should not) see the More Information hyperlink")]
		public void MoreInformation(string should)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I " + should + " see the More Information hyperlink");
			try
			{
				Report.Info("I " + should + " see the More Information hyperlink");

				var selRetailDetails = new RetailParntersDetails();

				if (!selRetailDetails.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}


				Report.IsTrue(selRetailDetails.MoreInformationShowing() == (should == "should"),
					"More Information link " + should + " have been visible, which was not the case!",
					"More Information link " + should + " have been visible, which was the case!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the Products in Scope button")]
		public void ThenClickTheProductsInScopeButtonBelowTheMoreInformationHyperlink()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Click the Products in Scope button");
			try
			{
				Report.Info("Click the Products in Scope button");

				var selRetailDetails = new RetailParntersDetails();

				if (!selRetailDetails.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}

				string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
				var dir = Directory.GetFiles(downloadsFolder, "*_Report_DataUsage*.xlsx", SearchOption.AllDirectories);

				foreach (var file in dir)
				{
					File.Delete(file);
				}


				selRetailDetails.ClickProductsInScope();
				Report.Success("Clicked Products in Scope button!");
				Report.Screenshot();

				dir = Directory.GetFiles(downloadsFolder, "*_Report_DataUsage*.xlsx", SearchOption.AllDirectories);

				while (!dir.Any())
				{
					dir = Directory.GetFiles(downloadsFolder, "*_Report_DataUsage*.xlsx", SearchOption.AllDirectories);
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm that an excel file is produced called (.*) and save as (.*)")]
		public void ConfirmFileAppearsInDownloadsFolder(string file, string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Confirm Excel File is downloaded with name: " + file);
			try
			{
				Report.Info("Confirm Excel File is downloaded with name: " + file);
				string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
				var dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
				if (Report.IsTrue(dir.Any(), "No file was found with name " + file, "File with name: " + dir.FirstOrDefault() + " was found successfully!"))
				{
					Context.AddToContext(savedAs, dir.FirstOrDefault());
				}

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		//[StepDefinition(@"I confirm the excel file saved as (.*) can be opened and contains data")]
		//public void ThenConfirmTheExcelFileCanBeOpenedAndContainsDataWPSIDAndProductName(string savedAs)
		//{
		//	TestReport.BeginTestModule(GlobalParameters.StepCount + " - Confirm the excel file saved as " + savedAs + " can be opened and contains data");

		//	try
		//	{
		//		Report.Info("Confirm the excel file saved as " + savedAs + " can be opened and contains data");
		//		var File = Context.GetFromContext(savedAs);
		//		if (Report.IsTrue(File != null, "No matching file was found for name: " + savedAs + "!", "File was found: " + File.ToString()))
		//		{
		//			var ExcelUtils = new Excel_Utilities(File.ToString(), "Table");
		//			Report.Info("Found: " + ExcelUtils.Excel_GetNoRows() + " rows in the spreadsheet");
		//			var FirstRow = ExcelUtils.Excel_GetRow(0);
		//			Report.Info("First row contained: '" + String.Join("', '", FirstRow) + "'");
		//			bool Data = false;
		//			for (int i = 1; i <= ExcelUtils.Excel_GetNoRows(); i++)
		//			{
		//				var RowData = ExcelUtils.Excel_GetRow(i);
		//				Report.Info("Row " + i + " had " + FirstRow[0] + ": " + RowData[0] + " and " + FirstRow[1] + ": " + RowData[1]);
		//				Data = true;
		//			}

		//			Report.IsTrue(Data, "Excel did not contain any product data!", "Excel file contained product data, as expected!");
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		Report.Failure(ex.Message);
		//		throw;
		//	}
		//}

		[StepDefinition(@"I ensure the Data Consent Tier Sliders are set as follows:")]
		public void DataConsentTiersSet(Table expected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Ensure the Data Consent Tier Sliders are set");
			try
			{
				Report.Info("Ensure the Data Consent Tier Sliders are set");
				var selRetailDetails = new RetailParntersDetails();
				foreach (var row in expected.Rows)
				{
					Report.Info("Setting Tier " + row["Tier"] + " to be in the " + row["State"] + " position");
					Report.IsTrue(selRetailDetails.SetDataConsentTier("Tier " + row["Tier"], row["State"] == "On"),
						"Failed to set Tier " + row["Tier"] + " to be in the " + row["State"] + " position!",
						"Successfully set Tier " + row["Tier"] + " to be in the " + row["State"] + " position!");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I (should|should not) be able to edit Tier (.*)")]
		public void DataUsageTierEditing(string should, string tier)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Ensure Tier " + tier + " " + (should == "should" ? "is" : "is not") + " editable");
			try
			{
				Report.Info("Ensure Tier " + tier + " " + (should == "should" ? "is" : "is not") + " editable");

				var selRetailDetails = new RetailParntersDetails();
				bool currentState = selRetailDetails.GetDataConsentTier(tier);

				Report.Info("Current state is " + (currentState ? "On" : "Off"));
				Report.Info("Setting state to be: " + (!currentState ? "On" : "Off"));
				selRetailDetails.SetDataConsentTier(tier, !currentState);
				Report.Info("Option clicked");
				var newCurrentState = selRetailDetails.GetDataConsentTier(tier);
				if (should == "should")
				{
					Report.IsTrue(newCurrentState != currentState,
						"Expected to able to edit Tier " + tier + ", but this was not the case!",
						"Tier " + tier + " was edited successfully!");
				}
				else
				{
					Report.IsTrue(newCurrentState == currentState,
						"Expected to not be able to edit Tier " + tier + ", but this was not the case!",
						"Tier " + tier + " was not edited successfully!");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the save changes button (is|is not) shown")]
		public void ThenConfirmTheSaveChangesButtonIsShown(string shown)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Check that the Save Changes button " + shown + " shown");
			try
			{
				Report.Info("Check that the Save Changes button " + shown + " shown");

				var selRetailDetails = new RetailParntersDetails();
				bool buttonShowing = selRetailDetails.SaveChangesButtonShowing();

				Report.IsTrue(buttonShowing == (shown == "is"),
					"Save changes button " + (shown == "is" ? "was" : "was not") + " expected to be visble, but this was not the case!",
					"Save changes button " + (shown == "is" ? "was" : "was not") + " expected to be visble, which was the case!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the Save Changes button")]
		public void GivenClickTheSaveChangesButton()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Click the Save Changes button");
			try
			{
				Report.Info("Click the Save Changes button");

				var selRetailDetails = new RetailParntersDetails();

				Report.IsTrue(selRetailDetails.ClickSaveChanges(), "Failed to click 'Save Changes'", "Successfully clicked 'Save Changes'");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click close on the Save Changes popup dialog")]
		public void ClickCloseOnSavePopupDialog()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Closing the Save Changes popup dialog");
			try
			{
				Report.Info("Closing the Save Changes popup dialog");

				var selDataEntryChanges = new DataEntryNotification();
				if (selDataEntryChanges.Wait_for_load())
				{
					selDataEntryChanges.ClickClose();
				}
				Report.Success("Clicked close successfully!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"the following warning message should be showing: (.*)")]
		public void ThenTheFollowingWarningMessageShouldBeShowing(string expected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Correct warning message is showing");
			try
			{
				Report.Info("Correct warning message is showing");

				var selRetailDetails = new RetailParntersDetails();
				var showing = selRetailDetails.WarningMessage();

				Report.Info("Message was showing: " + showing);
				Report.Info("Expected was: " + expected);
				Report.IsTrue(showing.Trim() == expected.Trim(), "Messages did not match!", "Messages matched successfully!");

				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"Confirm the NOTE: message below the Data Consent Tiers Heading is NOT shown")]
		public void ThenConfirmTheNoteMessageBelowTheDataConsentTiersHeadingIsNotShown()
		{
			ScenarioContext.Current.Pending();
		}










	}
}
