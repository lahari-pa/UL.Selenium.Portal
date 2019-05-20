using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Reporting_Module;
using NTTQA_Reporting_Module.Reporting.Core;
using NTTQA_TReVor_Module.Classes;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "RetailPartners")]
	class StepsRetailPartners
	{
		[Given(@"If I see the retail partners page I set all data consent tiers to true for all retailers in the top section")]
		public void GivenIfISeeTheRetailPartnersPageISetAllDataConsentTiersToTrueForAllRetailersInTheTopSection()
		{
			var selRetailPartners = new RetailPartners();

			if (!selRetailPartners.Wait_for_load(10))
			{
				Report.Info("Retail partners page has not loaded so no need to deal with it. ");
			}
			else
			{
				//get list of all top level retail partners
				List<string> ListOfMyDataAndRecipients = selRetailPartners.ListOfRetailersWithAdditionalADataConsentRequests();

				//open each one and select all data consent tiers
				foreach (string retailer in ListOfMyDataAndRecipients)
				{
					if (!selRetailPartners.RetailerShowingInAdditionalDataConsentRequests(retailer))
					{
						Report.Info("Retailer: " + retailer + " is no longer showing.");
						break;
					}

					Report.IsTrue(selRetailPartners.ClickRetailer(retailer), "Failed to click retailer " + retailer + "!", "Retailer " + retailer + " was selected successfully!");
					GeneralUtilities.Wait_for_load_finish();
					Report.Screenshot();

					RetailParntersDetails thisRetailParntersDetails = new RetailParntersDetails();
					List<string> DataConsentTiers = thisRetailParntersDetails.GetAllDataConsentTiers();

					foreach (string DCT in DataConsentTiers)
					{
						thisRetailParntersDetails.SetDataConsentTier(DCT, true);
					}

					this.GivenClickTheSaveChangesButton();
					this.ClickCloseOnSavePopupDialog();

					thisRetailParntersDetails.ClickBackButton();

					GeneralUtilities.Wait_for_load_finish();
					if (!selRetailPartners.Wait_for_load(10))
					{
						throw new Exception("Retail partners page has not loaded.");
					}

				}

				//navigate to the home screen
				NavigationBar myNavBar = new NavigationBar();
				myNavBar.Click_Icon("Home");

			}

		}

		[StepDefinition(@"I toggle the data consent tier: (.*) to: (on|off)")]
		public void SetDataConsentTier(string dct, string onOff)
		{
			var selRetailParntersDetails = new RetailParntersDetails();
			var toggle = onOff == "on";
			Report.IsTrue(selRetailParntersDetails.SetDataConsentTier(dct, toggle), "failed to toggle the data consent tier: " + dct + " to: " + onOff, "Successfully toggled the data consent tier: " + dct + " to: " + onOff);
		}

		[StepDefinition(@"I (should|should not) see the following subheading (.*)")]
		public void ThenIShouldSeeTheFollowingSubheading(string should, string subheading)
		{
			var expected = should == "should";

			var selRetailPartners = new RetailPartners();

			if (!selRetailPartners.Wait_for_load(10))
			{
				throw new Exception("Page failed to load!");
			}

			var subHeadingsShowing = selRetailPartners.SubHeadingsShowing();
			Report.IsTrue(subHeadingsShowing.Contains(subheading.Trim()) == expected,
				"Subheading " + (expected ? "was not" : "was") + " showing as expected! Expected: '" + subheading + "', but found: '" + string.Join("', '", subHeadingsShowing) + "'!",
				"Subheading " + (expected ? "was" : "was not") + " showing: '" + subheading + "', as expected!");
			Report.Screenshot();

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

		[StepDefinition(@"I should see the retailer heading: (.*)")]
		public void CorrectRetailerShowing(string retailer)
		{
			Report.IsTrue(new RetailParntersDetails().GetSelectedRetailer().Trim() == retailer.Trim(), "Retailer: " + retailer + " was not showing!", "Retailer: " + retailer + " was showing as expected!");
		}

		[StepDefinition(@"I select the retailer: (.*)")]
		public void SelectRetailer(string retailer)
		{
			GeneralUtilities.Wait_for_load_finish();
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

		[StepDefinition(@"Section: (.*) should be showing text: (.*)")]
		public void SectionShouldBeShowingText(string section, string text)
		{
			var showing = new RetailParntersDetails().GetSectionText(section).Trim();
			Report.IsTrue(showing == text.Trim(), "Text was not showing: " + text.Trim() + ". Instead found: " + showing, "Text was showing: " + text.Trim() + ", as expected!");
		}

		[StepDefinition(@"I should see the button: (.*) in section: (.*)")]
		public void ButtonsShowingInSection(string button, string section)
		{
			var buttons = new RetailParntersDetails().GetButtons(section);
			Report.Info("Buttons showing: " + string.Join(", ", buttons));
			Report.IsTrue(buttons.Contains(button.Trim()), "Failed to find the button: " + button + "!", "Succesfully found the button: " + button);
		}

		[StepDefinition(@"I confirm that there is a section labeled: (.*)")]
		public void ConfirmHeadingShowing(string header)
		{
			Report.IsTrue(new RetailParntersDetails().HeaderShowing(header),
				"Header '" + header + "' was not showing on page!",
				"Header '" + header + "' was showing, as expected!");
		}

		[StepDefinition(@"The Supplier ID Table (should|should not) be showing")]
		public void SupplierIdShowingCorrectly(string shouldornot)
		{
			bool expected = shouldornot == "should";
			Report.IsTrue(new RetailParntersDetails().SupplierIDTableShowing() == expected, (expected ? "Expected" : "Did not expect") + " the Supplier ID table to be showing!", "The Supplier ID " + (expected ? "was" : "was not") + " table showing, as expected!");
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

		[StepDefinition(@"The pie chart should be showing on the retailer details page")]
		public void PieChartShowing()
		{
			Report.IsTrue(new RetailParntersDetails().PieChartShowing(), "Pie Chart was not visible!", "Pie chart was visible, as exoected!");
		}

		[StepDefinition(@"The pie chart footer text should contain: (.*)")]
		public void PieChartFooterTextShowingAsExpected(string text)
		{
			var showing = new RetailParntersDetails().GetPieChartFooterText();
			Report.Info("Text found was: " + showing);
			Report.IsTrue(showing.Contains(text), "Showing text did not contain: " + text + "!", "Displayed text successfully contained: " + text);
		}

		[StepDefinition(@"I see a percentage number in the middle of the pie chart")]
		public void PercentageMiddleOfPieChart()
		{
			var percentage = new RetailParntersDetails().ChartCentrePercentage();
			Report.IsTrue(!percentage.IsNullOrEmpty(),
				"There was no percentage showing in the middle of the pie chart",
				"The percentage: " + percentage + " was displayed in the middle of the pie chart");
		}

		[StepDefinition(@"I confirm that the color of the pie chart for the Retailer selected is Green")]
		public void ColorOfPieChartForSelectedRetailerGreen()
		{
			var selRetailPartnersDetails = new RetailParntersDetails();
			var testChartFill = selRetailPartnersDetails.ChartRetailerFill();
			Report.IsTrue(testChartFill == "#9ac36c",
				"The pie chart fill for the retailer was not green. The hex code displayed is: " + testChartFill,
				"The pie chart fill for the retailer was green as expected. The hex code displayed is: " + testChartFill);
		}

		[StepDefinition(@"I confirm the percentage in the pie chart legend statement matches the percentage shown in the middle of the pie chart")]
		public void PieChartLegendPercentageMatchesPieChartPercentage()
		{
			var selRetailPartnersDetails = new RetailParntersDetails();
			var chartPercentage = selRetailPartnersDetails.ChartCentrePercentage();
			var chartLegend = selRetailPartnersDetails.GetChartLegend();
			Report.IsTrue(chartLegend.Contains(chartPercentage),
				"The percentage showing in the pie chart legend does not match the percentage within the pie chart",
				"The percentage showing in the pie chart legend matches the percentage within the pie chart as expected");
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

		[When(@"I confirm that: (.*) is showing under the Data Consent Tiers")]
		public void ThenConfirmFollwoingInformationDisplays(string info)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Confirming that '" + info + "' is showing under the Data Consent Tiers heading");
			try
			{
				Report.Info("Confirming that '" + info + "' is showing under the Data Consent Tiers heading");

				var selRetailDetails = new RetailParntersDetails();

				if (!selRetailDetails.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}

				var infoShowing = selRetailDetails.DoesNotRequireDataConsentInfo().Replace("\r\n", " ");
				Report.IsTrue(infoShowing == info,
					"Tier information was showing: '" + infoShowing + "', but was expected to show: '" + info + "'",
					"Tier information was showing: '" + info + "', as expected!");
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

				Context.AddToContext("MainWindowHandle", SeleniumBrowser.WebBrowser.CurrentWindowHandle);

				var windowHandles = SeleniumBrowser.WebBrowser.WindowHandles;
				var newTab = windowHandles.FirstOrDefault(x => x != SeleniumBrowser.WebBrowser.CurrentWindowHandle);
				SeleniumBrowser.WebBrowser.SwitchTo().Window(newTab);
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

		[StepDefinition(@"I click the Products in Scope button and confirm that an (excel|html) file is produced called (.*) and save as (.*)")]
		public void ThenClickTheProductsInScopeButtonBelowTheMoreInformationHyperlink(string filetype, string file, string savedAs)
		{
			Report.Info("Click the Products in Scope button");

			var selRetailDetails = new RetailParntersDetails();

			if (!selRetailDetails.Wait_for_load(10))
			{
				throw new Exception("Page failed to load!");
			}

			string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
			Report.Info("Downloads folder: " + downloadsFolder);

			var dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);

			foreach (var file_ in dir)
			{
				File.Delete(file_);
			}


			selRetailDetails.ClickProductsInScope();
			Report.Success("Clicked Products in Scope button!");
			Report.Screenshot();

			dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);

			int i = 0;
			Report.Info("Waiting for up to 30 seconds for the file to appear in the downloads folder...");
			while (!dir.Any() && i < 30)
			{
				dir = Directory.GetFiles(downloadsFolder, "*_Report_DataUsage*.xlsx", SearchOption.AllDirectories);
				Delay.Seconds(Delay.SpeedFactor * 1);
				i++;
			}

			if (Report.IsTrue(dir.Any(), "No file was found with name " + file, "File with name: " + dir.FirstOrDefault() + " was found successfully!"))
			{
				Context.AddToContext(savedAs, dir.FirstOrDefault());
			}

		}

		[StepDefinition(@"I confirm that an (excel|html) file is produced called (.*) and save as (.*)")]
		public void ConfirmFileAppearsInDownloadsFolder(string filetype, string file, string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Confirm Excel File is downloaded with name: " + file);
			try
			{
				Report.Info("Confirm " + filetype + " file is downloaded with name: " + file);
				string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
				Report.Info("Downloads folder: " + downloadsFolder);
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

		[StepDefinition(@"I confirm the excel file saved as (.*) can be opened and contains data")]
		public void ThenConfirmTheExcelFileCanBeOpenedAndContainsDataWPSIDAndProductName(string savedAs)
		{
			Report.Info("Confirm the excel file saved as " + savedAs + " can be opened and contains data");
			var File = Context.GetFromContext(savedAs);
			if (Report.IsTrue(File != null, "No matching file was found for name: " + savedAs + "!", "File was found: " + File.ToString()))
			{
				var ExcelUtils = new Excel_Utilities(File.ToString(), "Table");
				Report.Info("Found: " + ExcelUtils.Excel_GetNoRows() + " rows in the spreadsheet");
				var FirstRow = ExcelUtils.Excel_GetRow(0);
				Report.Info("Header row contained: '" + string.Join("', '", FirstRow) + "'");
				bool Data = false;
				for (int i = 1; i < ExcelUtils.Excel_GetNoRows(); i++)
				{
					var RowData = ExcelUtils.Excel_GetRow(i);
					Report.Info("Row " + i + " had " + FirstRow[0] + ": " + RowData[0] + " and " + FirstRow[1] + ": " + RowData[1]);
					Data = true;
				}

				Report.IsTrue(Data, "Excel did not contain any product data!", "Excel file contained product data, as expected!");
			}
		}

		[StepDefinition(@"I confirm the html file saved as (.*) can be opened and contains text: (.*)")]
		public void CheckingDownloadedHTMLFile(string savedAs, string text)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Confirm the excel file saved as " + savedAs + " can be opened and contains data");
			Report.Info("Confirm the excel file saved as " + savedAs + " can be opened and contains data");
			var file = Context.GetFromContext(savedAs);
			if (Report.IsTrue(file != null, "No matching file was found for name: " + savedAs + "!", "File was found: " + file.ToString(), false, false))
			{
				if (Report.IsTrue(File.ReadAllText(file.ToString()) != "", "File: " + file + " did not contain any content!", "File was not empty", false, false))
				{
					Report.IsTrue(File.ReadAllText(file.ToString()).Contains(text), "File did not contain text: " + text + ", content of file was: " + File.ReadAllText(file.ToString()), "File contained text: " + text + "!", false, false);
				}
			}
		}

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

		[StepDefinition(@"the Data Consent Tier: (.*) should be set to: (on|off)")]
		public void DataConsentTierShouldBeSetTo(string tier, string onOff)
		{
			var toggle = onOff == "on";
			Report.IsTrue(new RetailParntersDetails().GetDataConsentTier(tier) == toggle,
				"The Data Consent Tier: " + tier + " was not set to: " + onOff,
				"The Data Consent Tier: " + tier + " was set to " + onOff);
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
			Report.Info("Click the Save Changes button");
			var selRetailDetails = new RetailParntersDetails();
			Report.IsTrue(selRetailDetails.ClickSaveChanges(), "Failed to click 'Save Changes'", "Successfully clicked 'Save Changes'");
		}

		[StepDefinition(@"I click close on the Save Changes popup dialog")]
		public void ClickCloseOnSavePopupDialog()
		{
			Report.Info("Closing the Save Changes popup dialog");

			var selDataEntryChanges = new DataEntryNotification();
			if (selDataEntryChanges.Wait_for_load())
			{
				Report.IsTrue(selDataEntryChanges.ClickClose(), "Failed to click close", "Clicked close successfully!");
			}
		}

		[StepDefinition(@"if the save button is visible, I save changes and close the popup dialog")]
		public void ClickSaveClosePopupIfVisible()
		{
			var selRetailDetails = new RetailParntersDetails();
			if (selRetailDetails.SaveChangesButtonShowing())
			{
				Report.Info("The save button was visible, so saving changes.");
				Report.IsTrue(selRetailDetails.ClickSaveChanges(),
					"Failed to click 'Save Changes'",
					"Successfully clicked 'Save Changes'");
				var selDataEntryChanges = new DataEntryNotification();
				Report.Info("Closing the save changes dialog if it appears");
				if (selDataEntryChanges.Wait_for_load())
				{
					Report.Info("The save changes dialog appeared. Clicking Close.");
					Report.IsTrue(selDataEntryChanges.ClickClose(), "Failed to click close in the Save Changes dialog", "Successfully clicked close in the Save Changes dialog");
				}
				else
				{
					Report.Info("The save changes dialog did not appear");
				}
			}
		}

		[StepDefinition(@"the following warning message should be showing: (.*)")]

		[StepDefinition(@"the warning message in the Retail Partners details page should contain the following:")]
		public void WarningMessagesRetailPartnersShouldContain(Table warning)
		{
			var expected = new List<string>();
			warning.Rows.ForEach(x => expected.Add(x["Message"]));
			var displayed = new RetailParntersDetails().WarningMessages();
			var differences = expected.Except(displayed);
			Report.IsTrue(!differences.Any(),
				"The warning message did not match the expected text. Displayed is: " + string.Join("; ", displayed) + ". Expected is: " + string.Join("; ", expected),
				"The warning message matched the expected text.");

		}

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

		[StepDefinition(@"I confirm the NOTE message below the Data Consent Tiers Heading is NOT shown")]
		public void ThenConfirmTheNoteMessageBelowTheDataConsentTiersHeadingIsNotShown()
		{
			var displayed = new RetailParntersDetails().WarningMessages();
			Report.IsTrue(!displayed.Any(x => x.Contains("NOTE")),
				"The NOTE error message was displayed under the Data Cosent Tiers Heading",
				"The NOTE error message was not diplayed under the Data Consent Tiers Heading");
		}

		[StepDefinition(@"I confirm that none of the available Retailer Tiles are blank")]
		public void NoRetailerTilesAreBlank()
		{
			Report.IsTrue(new RetailPartners().NoRetailerTilesAreEmpty(), "Some retailer partner containers were empty!", "No retailer partner containers were empty!");
		}

		[StepDefinition(@"I check that the following retailers are showing:")]
		public void RetailersAreCorrectlyShowing(Table expected)
		{
			var showing = new RetailPartners().GetAllAvailableRetailers();
			var retList = new List<string>();
			foreach (var show in showing)
			{
				string[] parts1 = show.Split('/');
				string[] parts2 = parts1[parts1.Length - 1].Split('?');
				string filename = parts2[0];
				retList.Add(Path.GetFileNameWithoutExtension(filename).ToUpper());
			}
			foreach (var row in expected.Rows)
			{
				Report.IsTrue(retList.Contains(row["Code"]), "Failed to find retailer: " + row["Retailer"], "Successfully found a retailer: " + row["Retailer"], false, false);
			}
			Report.Screenshot();
		}

		[StepDefinition(@"I should see Retailer tiles under the (All Retailers|Most Recent Retailers) heading")]
		public void RetailerTilesUnderMostRecentRetailers(string heading)
		{
			var selRetailPartners = new RetailPartners();
			if (heading == "All Retailers")
			{
				Report.IsTrue(selRetailPartners.TilesAppearBelowHeading("all-retailers"), "There were no tiles below heading: " + heading, "Tiles were showing below heading: " + heading);
				return;
			}
			Report.IsTrue(selRetailPartners.TilesAppearBelowHeading("most-recent"), "There were no tiles below heading: " + heading, "Tiles were showing below heading: " + heading);
		}

		[StepDefinition(@"I confirm that the retailers shown under the Most Recent Retailers heading are not repeated under the All Retailers heading")]
		public void RetailersShownUnderMostRecentHeadingAreNotRepeatedUnderAllRetailers()
		{
			var selRetailPartners = new RetailPartners();
			bool anyMatch = selRetailPartners.AllRetailerTilesBelowHeading("most-recent").Intersect(selRetailPartners.AllRetailerTilesBelowHeading("all-retailers")).Any();
			Report.IsTrue(!anyMatch, "There were retailers appearing under Most Recent Retailers which were repeated under All Retailers", "No Retailers under the Most Recent heading were repeated under the All Retailers heading");
		}

		[StepDefinition(@"I confirm that if the Retailer logo is not shown, then the Retailer name is shown in the Retailer tile")]
		public void RetailerLogoIsNotShownThenRetailerNameIsShown()
		{
			var selRetailPartners = new RetailPartners();
			var allRetailers = selRetailPartners.GetAllAvailableRetailers();
			var count = allRetailers.Count;
			for (int i = 1; i <= count; i++)
			{
				//string[] parts = allRetailers[i - 1].Split('/');
				//var filename = parts[parts.Length - 1].Split('?')[0];
				//var retailerCode = Path.GetFileNameWithoutExtension(filename).ToUpper();
				var retailerName = selRetailPartners.AllRetailerNames()[i - 1];
				if (!selRetailPartners.RetailerImageDisplayed(i))
				{
					Report.IsTrue(selRetailPartners.RetailerTextDisplayed(i),
						"The Retailer logo for: '" + retailerName + "' was not displayed, and neither was the Retailer name, when it should be",
						"The Retailer logo for: '" + retailerName + "' was not displayed, so the Retailer name was displayed as expected.");
				}
				else
				{
					Report.Info("The retailer logo was displayed for: " + retailerName);
				}
			}
		}

		[StepDefinition(@"I click on close in the Report Download dialog")]
		public void GivenIClickOnCloseInTheReportDownloadDialog()
		{
			Report.IsTrue(new ReportDownload().ClickClose(), "Failed to click close on Report Download modal dialog", "Successfully clicked close");
		}

		[StepDefinition(@"I click the back arrow next to CVS")]
		public void GivenIClickTheBackArrowNextToCVS()
		{
			Report.IsTrue(new RetailParntersDetails().ClickBackButton(), "Failed to click the back arrow",
				"Successfully clicked the back arrow");
		}

		[StepDefinition(@"I should see the Retail Partners page")]
		public void ThenIShouldSeeTheRetailPartnersPage()
		{
			Report.IsTrue(new RetailPartners().Wait_for_load(60), "Retail partners page is not showing as expected",
				"Retail partners page is showing as expected");
		}

		[StepDefinition(@"I should see the Retailer Detail page")]
		public void ThenIShouldSeeTheRetailerDetailPage()
		{
			Report.IsTrue(new RetailParntersDetails().Wait_for_load(60), "Retailer detail page is not showing as expected",
				"Retailer detail page is showing as expected");
		}

		[StepDefinition(@"I check that in the Supplier ID table the following columns are showing:")]
		public void ThenICheckThatInTheSupplierIDTableTheFollowingColumnsAreShowing(Table supplierIDTable)
		{
			List<string> SupplierIDHeaders = new RetailParntersDetails().GetSupplierIDTableHeaders().OrderBy(x => x).ToList();

			List<string> ExpectedSupplierIDHeaders = supplierIDTable.Rows.Select(row => row["Column name"].Trim()).OrderBy(x => x).ToList();

			bool passed = true;

			foreach (string thisHeader in ExpectedSupplierIDHeaders)
			{
				if (!SupplierIDHeaders.Contains(thisHeader))
				{
					passed = false;
					Report.Error(thisHeader + " was not found.");
				}
			}

			Report.IsTrue(passed,
				"Expected supplier column names: " + string.Join(",", ExpectedSupplierIDHeaders) +
				" and actual column names: " + string.Join(",", SupplierIDHeaders) + " do not match",
				"Expected and actual Supplier ID table column names match as expected");

		}

		[Given(@"I click on the Add new Supplier ID link")]
		public void GivenIClickOnTheAddNewSupplierIDLink()
		{
			Report.IsTrue(new RetailParntersDetails().ClickAddSupplierId(), "Failed to click add supplier id link",
				"Successfully clicked add supplier id link");
		}

		[Then(@"I confirm the pop up shows the heading: (.*)")]
		public void ThenIConfirmThePopUpShowsTheHeading(string title)
		{
			var actualTitle = new ModalDialog().GetTitle();
			Report.IsTrue(actualTitle == title, "Title is " + actualTitle + " but should be: " + title,
				"Title is showing as expected: " + title);
		}
		[StepDefinition(@"I click the back arrow on the Retail Partners Details page")]
		public void ClickTheBackArrowRetailPartnersDetails()
		{
			Report.IsTrue(new RetailParntersDetails().ClickBackButton(), "Failed to click the back arrow",
				"Successfully clicked the back arrow");
			GeneralUtilities.Wait_for_load_finish();
		}

		[Then(@"I confirm the pop up shows the Supplier ID heading and data entry field")]
		public void ThenIConfirmThePopUpShowsTheSupplierIDHeadingAndDataEntryField()
		{
			Report.IsTrue(new AddNewSupplier().EnterSupplierIDExists(), "Supplier ID field does not exist as expected",
				"Supplier ID field exists as expected");
		}

		[Then(@"I confirm the pop up shows the Company or Brand Name heading and data entry field")]
		public void ThenIConfirmThePopUpShowsTheCompanyOrBrandNameHeadingAndDataEntryField()
		{
			Report.IsTrue(new AddNewSupplier().EnterCompanyOrBrandNameExists(), "Company or brand name field does not exist as expected",
				"Company or brand name exists as expected");
		}

		[Then(@"I confirm the pop up shows the Is Default Heading and check box")]
		public void ThenIConfirmThePopUpShowsTheIsDefaultHeadingAndCheckBox()
		{
			Report.IsTrue(new AddNewSupplier().IsDefaultExists(), "Is Default field does not exist as expected",
				"Is Default exists as expected");
		}


		[Then(@"I confirm the pop up shows a Save button")]
		public void ThenIConfirmThePopUpShowsASaveButton()
		{
			Report.IsTrue(new AddNewSupplier().SaveButtonExists(), "Save button does not exist as expected",
				"Save button exists as expected");
		}

		[StepDefinition(@"I confirm the pop up shows a Cancel button")]
		public void ThenIConfirmThePopUpShowsACancelButton()
		{
			Report.IsTrue(new AddNewSupplier().CancelButtonExists(), "Cancel button does not exist as expected",
				"Cancel button exists as expected");
		}

		[StepDefinition(@"in the modal dialog I click (cancel|save)")]
		public void GivenInTheModalDialogIClickButton(string cancelOrSave)
		{
			if (cancelOrSave == "cancel")
			{
				Report.IsTrue(new ModalDialog().Click_Cancel(), "Failed to click cancel button",
					"Successfully clicked cancel");
			}
			else
			{
				Report.IsTrue(new ModalDialog().ClickSave(), "Failed to click save button",
					"Successfully clicked save");
			}
		}

		[Then(@"I confirm the Add New Supplier ID pop up closes")]
		public void ThenIConfirmTheAddNewSupplierIDPopUpCloses()
		{
			Delay.Seconds(1);
			Report.IsTrue(!(new ModalDialog().Exists), "Dialog has not closed as expected",
				"Dialog has closed as expected");
		}

		[Given(@"I confirm in the browser popup")]
		public void GivenIConfirmInTheBrowserPopup()
		{
			SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
		}

		[Then(@"I confirm that the excel file saved as: (.*) contains the following columns:")]
		public void ThenIConfirmThatTheExcelFileSavedAsContainsTheFollowingColumns(string savedAs, Table table)
		{
			var File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!File.IsNullOrEmpty(), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new Excel_Utilities(File.ToString(), "Table");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));

				foreach (TableRow thisRow in table.Rows)
				{
					Report.IsTrue(ColumnTitles.Contains(thisRow["Column"]),
						"Column name is not found: " + thisRow["Column"],
						"Column name has been found as expected: " + thisRow["Column"], false, false);
				}
			}
		}

		[StepDefinition(@"I click each Wal-mart affiliate retailer and should be taken to the Wal-mart/SAM'S CLUB view")]
		public void AllWalMartAffiliatesNavigateToSamsClub()
		{
			var retailerInfo = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("WM-BO","Bonobos"),
				new KeyValuePair<string, string>("WM-CO","Walmart.com"),
				new KeyValuePair<string, string>("WM-HN","Hayneedle"),
				new KeyValuePair<string, string>("WM-JE","Jet"),
				new KeyValuePair<string, string>("WM-MC","MODCLOTH"),
				new KeyValuePair<string, string>("WM-MJ","Moosejaw"),
				new KeyValuePair<string, string>("WM-SC","Shoes.com")
			};
			var retailerNames = retailerInfo.Select(x => x.Value).ToList();
			foreach (var retailer in retailerInfo)
			{
				TestReport.UseSubSteps = false;
				TestReport.StartStep("Clicking the retailer: " + retailer.Value + " should navigate to the Wal-Mart/SAM'S CLUB Retail Partners Details page with all 7 affiliates shown under <retailer> & You");
				TestReport.UseSubSteps = true;
				var selRetailPartners = new RetailPartners();
				var selRetailPartnersDetails = new RetailParntersDetails();
				TestReport.StartStep("Clicking on the logo for the retailer: " + retailer.Value + " in the Retail Partners page");
				Report.IsTrue(selRetailPartners.ClickRetailerLogo(retailer.Key),
					"Failed to click on the logo for retailer: " + retailer.Value,
					"Successfully clicked on the logo for retailer: " + retailer.Value);
				TestReport.StartStep("I confirm that the Wal-mart/SAM'S CLUB Details page is shown");
				Report.IsTrue(selRetailPartnersDetails.GetSelectedRetailer() == "Wal-Mart/SAM'S CLUB",
					"The selected retailer on Retail Partner Details page was not 'Wal-Mart/SAM'S CLUB'",
					"The selected retailer on Retail Partner Details page was 'Wal-Mart/SAM'S CLUB' as expected");
				TestReport.StartStep("I confirm that under the <Retailer> & You heading all 7 Wal-Mart affiliate retailers are displayed");
				var actualRetailers = selRetailPartnersDetails.WalmartRegistrationsRetailers();
				Report.IsTrue(!actualRetailers.Except(retailerNames).Any() && actualRetailers.Count == retailerNames.Count,
					"The actual list of retailers showing under '<Retailer> & You' did not match the expected list. Showing retailers were: " + string.Join(", ", actualRetailers.Select(x => "'" + x + "'")),
					"The actual list of retailers showing under '<Retailer> & You matched the expected list");
				selRetailPartnersDetails.ClickBackButton();
			}
		}

		[Then(@"I confirm that the excel file saved as: (.*) in column: (.*) there are no numbers")]
		public void ThenIConfirmThatTheExcelFileSavedAsInColumnThereAreNoNumbers(string savedAs, string columnName)
		{
			var File = Context.GetFromContext(savedAs);
			bool AllPassed = true;
			if (Report.IsTrue(File != null, "No matching file was found for name: " + savedAs + "!", "File was found: " + File.ToString()))
			{
				var ExcelUtils = new Excel_Utilities(File.ToString(), "Table");
				//get the index of column
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));
				int ColumnIndex = 0;
				for (int i = 0; i < ColumnTitles.Count; i++)
				{
					if (ColumnTitles[i] == columnName)
					{
						ColumnIndex = i;
					}
				}
				List<string> RowItems = ExcelUtils.Excel_GetColumn(ColumnIndex);
				foreach (string thisItem in RowItems)
				{
					if (thisItem.Any(char.IsDigit))
					{
						Report.Info("The following item contains a digit: " + thisItem);
						AllPassed = false;
					}
				}
			}
			Report.IsTrue(AllPassed, "Not all items were strings", "As expected all items were strings");
		}

		[StepDefinition(@"I delete the excel file saved as (.*)")]
		public void DeleteExcelFile(string savedAs)
		{
			var file = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (file.IsNullOrEmpty())
			{
				Report.Failure("Could not find file saved as: " + savedAs);
				return;
			}
			Report.Info("Deleting file: " + file);
			File.Delete(file);
		}

		[StepDefinition(@"I click the ""(.*)"" information button in the Retail Partners Details screen")]
		public void ClickInformationButtonInDataTierDetails(string button)
		{
			Report.IsTrue(new RetailParntersDetails().ClickInfoButton(button), $"Failed to click the {button} button!", $"Successfully clicked the {button} button");
		}

		[StepDefinition(@"I confirm the ""(.*)"" information button is displayed on the Retail Partners Details screen")]
		public void ConfirmTheInfoButtonIsDisplayedOnRetailPartnersDetails(string button)
		{
			Report.IsTrue(new RetailParntersDetails().InfoButton(button) != null,
				$@"The ""{button}"" button was not displayed!",
				$@"The ""{button}"" was dipslayed as expected");
		}

		[StepDefinition(@"I click the ""(.*)"" tab in Data Tier Details")]
		public void ClickTabInDataTierDetails(string tab)
		{
			Report.IsTrue(new DataTierDetails().ClickTab(tab), $"Failed to click the {tab} tab!", $"Successfully clicked the {tab} tab");
		}

		[StepDefinition(@"The Data Tier Details popup shows the following tabs:")]
		public void DataTierDetailsPopUpShowsTheFollowingTabs(Table tabs)
		{
			var expectedTabs = new List<string>();
			tabs.Rows.ForEach(x => expectedTabs.Add(x["Tab"]));
			var displayedTabs = new DataTierDetails().AllTabs();
			Report.IsTrue(expectedTabs.All(x => displayedTabs.Contains(x)) && expectedTabs.Count == displayedTabs.Count,
				$@"The displayed tabs did not match the expected tabs! Expected: ""{string.Join(", ", expectedTabs.Select(x => $"'{x}'"))}"". Found: ""{string.Join(", ", displayedTabs.Select(x => $"'{x}'"))}""",
				"The displayed tabs matched the expected tabs.");
		}

		[StepDefinition(@"I close the Data Tier Details popup")]
		public void ClickCloseDataTierDetails()
		{
			Report.IsTrue(new DataTierDetails().ClickClose(), "Failed to click close!", "Successfully clicked close");
		}

		[StepDefinition(@"I confirm the text displayed in the Data Tier Details popup matches for each section:")]
		public void ConfirmTheTextDisplayedinDataTierDetialsPopupContains(Table paragraphText)
		{
			var displayedParagraphs_ = new DataTierDetails().TabParagraphs();
			foreach (var row in paragraphText.Rows)
			{
				var expectedSection = row["Section"];
				var expectedText = row["Text"];
				Report.IsTrue(displayedParagraphs_.Any(x => x.Key == expectedSection && x.Value.Contains(expectedText)),
					$"Did not find expected text in section: {expectedSection}! Expected: {expectedText}",
					$"Found the expected text in section: {expectedSection}. Text: {expectedText}");
			}
		}

		[StepDefinition(@"I confirm the Data Tier Details subheading reads: (.*)")]
		public void ConfirmTheDataTierDetailsSubheadingReads(string expectedSubheading)
		{
			var actualSubHeading = new DataTierDetails().SubHeading().Trim();
			Report.IsTrue(expectedSubheading.Trim() == actualSubHeading,
				$"The Data Tier Details subheading did not match the expected text! Expected: '{expectedSubheading}'. Actual: '{actualSubHeading}'",
				"The Data Tier Details subheading matched the expected text");
		}

		[StepDefinition(@"I confirm the Retailer Details Page has loaded")]
		public void IConfirmTheRetailerDetailsPageHasLoaded()
		{
			Report.IsTrue(new RetailParntersDetails().Wait_for_load(), "The Retailer Details page was not loaded!", "The Retailer Details page was loaded as expected");
		}

		[StepDefinition(@"I confirm the Data Consent Tiers table is displayed")]
		public void ConfirmTheDataConsentTiersTableIsDisplayed()
		{
			Report.IsTrue(new RetailParntersDetails().DataConsentTiersTable() != null,
				"The Data Consent Tiers table was not displayed!",
				"The Data Consent Tiers table was displayed as expected.");
		}

		[StepDefinition(@"I confirm that row: (.*) of the Data Consent Tiers table displays: ""(.*)""")]
		public void ConfirmThatRowOfTheDataConsentTiersTableDisplaysText(string row, string text)
		{
			var selRetailPartnersDetails = new RetailParntersDetails();
			var tierRows = selRetailPartnersDetails.GetAllDataConsentTiers();
			if (int.TryParse(row, out var rowNum))
			{
				if (tierRows.Count < rowNum)
				{
					Report.Failure("Table contains fewer rows than the specified row: " + row);
					return;
				}
				Report.IsTrue(tierRows[rowNum - 1] == text,
					$@"Row {row} did not show text ""{text}""!",
					$@"Row {row} showed text ""{text}"" as expected");
				return;
			}
			Report.Failure($"Row number supplied ({row}) was not parsable as an int!");
		}

		[StepDefinition(@"in the Add New Supplier Dialog I Confirm an error shows below the Supplier ID question: (.*)")]
		public void GivenIConfirmAnErrorShowsBelowTheSupplierIDQuestion(string expectedError)
		{
			AddNewSupplier thisAddNewSupplier = new AddNewSupplier();
			string actualError = thisAddNewSupplier.GetSupplierError();
			if (actualError == null)
			{
				actualError = "";
			}

			Report.IsTrue(actualError == expectedError, "Expected error: " + expectedError + " but got: " + actualError,
				"Error is showing as expected");
		}

		[StepDefinition(@"in the Add New Supplier Dialog I Confirm an error shows below Company or Brand Name question: (.*)")]
		public void GivenIConfirmAnErrorShowsBelowTheCompanyQuestion(string expectedError)
		{
			AddNewSupplier thisAddNewSupplier = new AddNewSupplier();
			string actualError = thisAddNewSupplier.GetCompanyNameError();
			if (actualError == null)
			{
				actualError = "";
			}

			Report.IsTrue(actualError == expectedError, "Expected error: " + expectedError + " but got: " + actualError,
				"Error is showing as expected");
		}

		[StepDefinition(@"in the Add New Supplier Dialog I enter the following in the Supplier ID input: (.*)")]
		public void GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheSupplierIDInput(string supplierIDInput)
		{
			AddNewSupplier thisAddNewSupplier = new AddNewSupplier();
			Report.IsTrue(thisAddNewSupplier.EnterSupplierID(supplierIDInput), "Failed to add supplier ID input",
				"Entered supplier ID value");
		}

		[StepDefinition(@"in the Add New Supplier Dialog I enter the following in the Company or Brand Name input: (.*)")]
		public void GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheCompanyOrBrandNameInput(string companyInput)
		{
			AddNewSupplier thisAddNewSupplier = new AddNewSupplier();
			Report.IsTrue(thisAddNewSupplier.EnterCompanyOrBrandName(companyInput), "Failed to add company or brand name input",
				"Entered company or brand name value");
		}

		[StepDefinition(@"in the Add New Supplier Dialog I Confirm that no error shows below Company or Brand Name question")]
		public void GivenInTheAddNewSupplierDialogIConfirmThatNoErrorShowsBelowCompanyOrBrandNameQuestion()
		{
			AddNewSupplier thisAddNewSupplier = new AddNewSupplier();
			Report.IsTrue(!thisAddNewSupplier.CompanyNameErrorExists(), "Company or brand name error is incorrectly showing",
				"As expected no error is showing below Company or Brand name question");
		}

		[StepDefinition(@"in the Add New Supplier Dialog I Confirm that no error shows below Supplier ID question")]
		public void GivenInTheAddNewSupplierDialogIConfirmThatNoErrorShowsBelowSupplierIDQuestion()
		{
			AddNewSupplier thisAddNewSupplier = new AddNewSupplier();
			Report.IsTrue(!thisAddNewSupplier.SupplierIDErrorExists(), "Supplier ID error is incorrectly showing",
				"As expected no error is showing below Supplier ID question");
		}

		//| Supplier ID | Company or Brand Name |
		[Then(@"I confirm that in the Supplier IDS list the following row exists")]
		public void ThenIConfirmThatInTheSupplierIDSListTheFollowingRowExists(Table table)
		{
			List<Supplier> allSuppliers = new RetailParntersDetails().GetAllSuppliers();

			string expectedSupplierID = table.Rows[0]["Supplier ID"];
			string expectedCompany = table.Rows[0]["Company or Brand Name"];
			Supplier matchingSupplier = allSuppliers.FirstOrDefault(x => x.SupplierID == expectedSupplierID && x.CompanyOrBrandName == expectedCompany);

			Report.IsTrue(matchingSupplier != null, "No matching row was found in the list",
				"Matching row as found as expected");
		}
		[StepDefinition(@"in the Add New Supplier Dialog I click save")]
		public void GivenInTheAddNewSupplierDialogIClickSave()
		{
			AddNewSupplier thisAddNewSupplier = new AddNewSupplier();
			thisAddNewSupplier.ClickSave();
			Delay.Seconds(2);
		}


		//x = 1 for O'Reilly, 2 for Sears, 3 for Wal-Mart
		[StepDefinition(@"I find the Supplier ID for (.*) in the SupplierID table and save as (.*)")]
		public void GivenIFindTheSupplierIDForSupplierInTheSupplierIDTable(string supplier, string saveAs)
		{
			List<Supplier> allSuppliers = new RetailParntersDetails().GetAllSuppliers();
			Regex regex = new Regex(@"\d+");
			List<string> potentialRootStrings = new List<string>();
			foreach (Supplier thisSupplier in allSuppliers)
			{
				MatchCollection matches = Regex.Matches(thisSupplier.SupplierID, @"\d{5}1");
				// Use foreach-loop.
				foreach (Match match in matches)
				{
					if (match.Success)
					{
						potentialRootStrings.Add(thisSupplier.SupplierID.Substring(0, 5));
					}
				}
			}

			string foundRootString = "";
			foreach (var thisRootString in potentialRootStrings)
			{
				if (allSuppliers.Select(x => x.SupplierID).ToList().Contains(thisRootString + "2") &&
					allSuppliers.Select(x => x.SupplierID).ToList().Contains(thisRootString + "3"))
				{
					foundRootString = thisRootString;
					break;
				}
			}

			if (!(foundRootString.Length > 0))
			{
				throw new Exception("No root string has been found");
			}

			string requiredId = foundRootString;
			switch (supplier)
			{
				case "O'Reilly":
					requiredId = requiredId + "1";
					break;
				case "Sears":
					requiredId = requiredId + "2";
					break;
				case "Wal-Mart":
					requiredId = requiredId + "3";
					break;
				default:
					throw new Exception("You need to specify O'Reilly, Sears or Wal-Mart");
			}

			Context.AddToContext(saveAs, requiredId);

		}

		[StepDefinition(@"I Confirm the Is Active column for SupplierID saved as (.*) (shows|does not show) a green check mark")]
		public void GivenIConfirmTheIsActiveColumnForSupplierIDSavedAsSupplierIDShowsAGreenCheckMark(string savedAs, string showsDoesNotShow)
		{
			List<Supplier> allSuppliers = new RetailParntersDetails().GetAllSuppliers();
			string SupplierId = Context.GetFromContext(savedAs).ToString();
			if (showsDoesNotShow == "shows")
			{
				Report.IsTrue(allSuppliers.FirstOrDefault(x => x.SupplierID == SupplierId).IsActive,
					"SupplierID: " + SupplierId + " is not showing as active",
					"SupplierID: " + SupplierId + " is showing as active");
			}
			else
			{
				Report.IsTrue(!allSuppliers.FirstOrDefault(x => x.SupplierID == SupplierId).IsActive,
					"SupplierID: " + SupplierId + " is showing as active",
					"SupplierID: " + SupplierId + " is not showing as active");
			}

		}


		[StepDefinition(@"I click download PDF for ""(.*)""")]
		public void ClickDownloadPdf(string option)
		{
			Report.IsTrue(new DataTierDetails().ClickDownloadPdfWithHeading(option), $"Failed to click download pdf option for {option}!", $"Successfully clicked download pdf option for {option}");
		}
	}
}

