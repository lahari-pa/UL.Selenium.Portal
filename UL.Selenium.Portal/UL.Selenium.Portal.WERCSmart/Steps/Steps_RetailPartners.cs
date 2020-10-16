using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UL.Automation.Selenium.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using System.Collections.ObjectModel;
using UL.Automation.Reporting;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;
using NPOI.SS.Formula.Functions;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "RetailPartners")]
	class StepsRetailPartners
	{

		[StepDefinition(@"If I see the retail partners page I set all data consent tiers to true for all retailers in the top section")]
		public void GivenIfISeeTheRetailPartnersPageISetAllDataConsentTiersToTrueForAllRetailersInTheTopSection()
		{
			var selRetailPartners = new RetailPartners();

			if (!selRetailPartners.Wait_for_load(30))
			{
				Report.Info("Retail partners page has not loaded so no need to deal with it. ");
			}
			//if(new ModalDialog().WaitForContainerToBeVisible(5))
			//{
			//	new ModalDialog().ClickButton("GO TO MY RETAILERS");
			//	selRetailPartners.Wait_for_load(10);
			//}
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

					var thisRetailPartnersDetails = new RetailPartnersDetails();
					List<string> DataConsentTiers = thisRetailPartnersDetails.GetAllDataConsentTiers();

					foreach (string DCT in DataConsentTiers)
					{
						thisRetailPartnersDetails.SetDataConsentTier(DCT, true);
					}

					this.GivenClickTheSaveChangesButton();
					this.ClickCloseOnSavePopupDialog();

					thisRetailPartnersDetails.ClickBackButton();

					GeneralUtilities.Wait_for_load_finish();
					if (!selRetailPartners.Wait_for_load(10))
					{
						throw new Exception("Retail partners page has not loaded.");
					}
				}
				//navigate to the home screen
				var myNavBar = new NavigationBar();
				myNavBar.Click_Icon("Home");
			}

		}

		[StepDefinition(@"I toggle the data consent tier: (.*) to: (on|off)")]
		public void SetDataConsentTier(string dct, string onOff)
		{
			var selRetailPartnersDetails = new RetailPartnersDetails();
			bool toggle = onOff == "on";
			Report.IsTrue(selRetailPartnersDetails.SetDataConsentTier(dct, toggle), "failed to toggle the data consent tier: " + dct + " to: " + onOff, "Successfully toggled the data consent tier: " + dct + " to: " + onOff);
		}

		[StepDefinition(@"I (should|should not) see the following subheading (.*)")]
		public void ThenIShouldSeeTheFollowingSubheading(string should, string subheading)
		{
			bool expected = should == "should";

			var selRetailPartners = new RetailPartners();

			if (!selRetailPartners.Wait_for_load(10))
			{
				throw new Exception("Page failed to load!");
			}

			List<string> subHeadingsShowing = selRetailPartners.SubHeadingsShowing();
			Report.IsTrue(subHeadingsShowing.Contains(subheading.Trim()) == expected,
				"Subheading " + (expected ? "was not" : "was") + " showing as expected! Expected: '" + subheading + "', but found: '" + string.Join("', '", subHeadingsShowing) + "'!",
				"Subheading " + (expected ? "was" : "was not") + " showing: '" + subheading + "', as expected!");
			Report.Screenshot();

		}

		[StepDefinition(@"I should see the following heading (.*)")]
		public void ThenIShouldSeeTheFollowingHeading(string heading)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Checking that the heading " + heading + " is showing");
			try
			{
				Report.Info("Checking that the heading " + heading + " is showing");
				var selRetailPartners = new RetailPartners();

				if (!selRetailPartners.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}


				string headingShowing = selRetailPartners.HeaderShowing();
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
			Report.IsTrue(new RetailPartnersDetails().GetSelectedRetailer().Trim() == retailer.Trim(), "Retailer: " + retailer + " was not showing!", "Retailer: " + retailer + " was showing as expected!");
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

		[StepDefinition(@"I confirm that the Data Consent Tiers information matches the information saved as: (.*)")]
		public void ConfirmThatDataConsentTiersMatches(string savedAs)
		{
			string tiers = Context.GetFromContext(savedAs)?.ToString();
			var tiersList = tiers.Split(',').ToList();

			foreach (string tier in tiersList)
			{
				string dataTier = tier.Split('=')[0];
				string trueFalse = tier.Split('=')[1];

				Report.IsTrue(new RetailPartnersDetails().ConfirmDataTier(dataTier, trueFalse), "Failed to find status of '" + trueFalse + "' for data consent tier '" + dataTier + "'.",
					"Successfully found status of '" + trueFalse + "' for data consent tier '" + dataTier + "'.");
			}

		}

		/// <summary>
		/// The retail partner details is in Data Consent Tiers section.
		/// It is the section of text above 'What are the Data Usage Tiers?'
		/// eg: Lowe's requires suppliers of products to grant Tier 1 at this time.
		/// </summary>
		[StepDefinition(@"Retail partner details should be showing text: (.*)")]
		public void RetailPartnersDetailShouldBeShowing(string text)
		{
			string showing = new RetailPartnersDetails().GetDCDescription();
			Report.IsTrue(showing == text.Trim(), "Text was not showing: " + text.Trim() + ". Instead found: " + showing, "Text was showing: " + text.Trim() + ", as expected!");
		}


		[StepDefinition(@"Section: (.*) should be showing text: (.*)")]
		public void SectionShouldBeShowingText(string section, string text)
		{
			string showing = new RetailPartnersDetails().GetSectionText(section).Trim();
			Report.IsTrue(showing == text.Trim(), "Text was not showing: " + text.Trim() + ". Instead found: " + showing, "Text was showing: " + text.Trim() + ", as expected!");
		}

		[StepDefinition(@"I should see the button: (.*) in section: (.*)")]
		public void ButtonsShowingInSection(string button, string section)
		{
			List<string> buttons = new RetailPartnersDetails().GetButtons(section);
			Report.Info("Buttons showing: " + string.Join(", ", buttons));
			Report.IsTrue(buttons.Contains(button.Trim()), "Failed to find the button: " + button + "!", "Succesfully found the button: " + button);
		}

		[StepDefinition(@"I confirm that there is a section labeled: (.*)")]
		public void ConfirmHeadingShowing(string header)
		{
			Report.IsTrue(new RetailPartnersDetails().HeaderShowing(header),
				"Header '" + header + "' was not showing on page!",
				"Header '" + header + "' was showing, as expected!");
		}

		[StepDefinition(@"The Supplier ID Table (should|should not) be showing")]
		public void SupplierIdShowingCorrectly(string shouldornot)
		{
			bool expected = shouldornot == "should";
			Report.IsTrue(new RetailPartnersDetails().SupplierIDTableShowing() == expected, (expected ? "Expected" : "Did not expect") + " the Supplier ID table to be showing!", "The Supplier ID " + (expected ? "was" : "was not") + " table showing, as expected!");
		}

		[StepDefinition(@"I confirm that under the pie chart I see the label: (.*)")]
		public void ConfirmPieChartLegend(string legendLabel)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Confirming that the pie chart has legend containing: " + legendLabel);
			try
			{
				Report.Info("Confirming that the pie chart has legend containing: " + legendLabel);

				var selRetailDetails = new RetailPartnersDetails();

				if (!selRetailDetails.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}

				string legendShowing = selRetailDetails.GetChartLegend();
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
			Report.IsTrue(new RetailPartnersDetails().PieChartShowing(), "Pie Chart was not visible!", "Pie chart was visible, as exoected!");
		}

		[StepDefinition(@"The pie chart footer text should contain: (.*)")]
		public void PieChartFooterTextShowingAsExpected(string text)
		{
			string showing = new RetailPartnersDetails().GetPieChartFooterText();
			Report.Info("Text found was: " + showing);
			Report.IsTrue(showing.Contains(text), "Showing text did not contain: " + text + "!", "Displayed text successfully contained: " + text);
		}

		[StepDefinition(@"I see a percentage number in the middle of the pie chart")]
		public void PercentageMiddleOfPieChart()
		{
			string percentage = new RetailPartnersDetails().ChartCentrePercentage();
			Report.IsTrue(!string.IsNullOrEmpty(percentage),
				"There was no percentage showing in the middle of the pie chart",
				"The percentage: " + percentage + " was displayed in the middle of the pie chart");
		}

		[StepDefinition(@"I confirm that the color of the pie chart for the Retailer selected is Green")]
		public void ColorOfPieChartForSelectedRetailerGreen()
		{
			var selRetailPartnersDetails = new RetailPartnersDetails();
			string testChartFill = selRetailPartnersDetails.ChartRetailerFill();
			Report.IsTrue(testChartFill == "#9ac36c",
				"The pie chart fill for the retailer was not green. The hex code displayed is: " + testChartFill,
				"The pie chart fill for the retailer was green as expected. The hex code displayed is: " + testChartFill);
		}

		[StepDefinition(@"I confirm the percentage in the pie chart legend statement matches the percentage shown in the middle of the pie chart")]
		public void PieChartLegendPercentageMatchesPieChartPercentage()
		{
			var selRetailPartnersDetails = new RetailPartnersDetails();
			string chartPercentage = selRetailPartnersDetails.ChartCentrePercentage();
			string chartLegend = selRetailPartnersDetails.GetChartLegend();
			Report.IsTrue(chartLegend.Contains(chartPercentage),
				"The percentage showing in the pie chart legend does not match the percentage within the pie chart",
				"The percentage showing in the pie chart legend matches the percentage within the pie chart as expected");
		}

		[StepDefinition(@"I confirm that: (.*) is showing under the Data Consent Tiers heading")]
		public void ThenConfirmYouSeeUnderTheDataConsentTiersHeading(string tierInformation)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Confirming that '" + tierInformation + "' is showing under the Data Consent Tiers heading");
			try
			{
				Report.Info("Confirming that '" + tierInformation + "' is showing under the Data Consent Tiers heading");

				var selRetailDetails = new RetailPartnersDetails();

				if (!selRetailDetails.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}

				string tierInfoShowing = selRetailDetails.GetTierInformation();
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
			Report.StartStep(ReportSettings.StepCounter + " - Confirming that '" + info + "' is showing under the Data Consent Tiers heading");
			try
			{
				Report.Info("Confirming that '" + info + "' is showing under the Data Consent Tiers heading");

				var selRetailDetails = new RetailPartnersDetails();

				if (!selRetailDetails.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}

				string infoShowing = selRetailDetails.DoesNotRequireDataConsentInfo().Replace("\r\n", " ");
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
			Report.StartStep(ReportSettings.StepCounter + " - Clicking 'More Information' Hyperlink");
			try
			{
				Report.Info("Clicking 'More Information' Hyperlink");

				var selRetailDetails = new RetailPartnersDetails();

				if (!selRetailDetails.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}


				selRetailDetails.ClickMoreInformation();
				Report.Success("More Information link clicked!");
				Report.Info("Switching to new window");

				Delay.Seconds(10);
				
				Context.AddToContext("MainWindowHandle", SeleniumBrowser.WebBrowser.CurrentWindowHandle);
			
				ReadOnlyCollection<string> windowHandles = SeleniumBrowser.WebBrowser.WindowHandles;
			
				string newTab = windowHandles.FirstOrDefault(x => x != SeleniumBrowser.WebBrowser.CurrentWindowHandle);
			
				SeleniumBrowser.WebBrowser.SwitchTo().Window(newTab);
		
				Report.Success("Window switched successfully!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure("Exception: " + ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I (should|should not) see the More Information hyperlink")]
		public void MoreInformation(string should)
		{
			Report.StartStep(ReportSettings.StepCounter + " - I " + should + " see the More Information hyperlink");
			try
			{
				Report.Info("I " + should + " see the More Information hyperlink");

				var selRetailDetails = new RetailPartnersDetails();

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

			var selRetailDetails = new RetailPartnersDetails();

			if (!selRetailDetails.Wait_for_load(10))
			{
				throw new Exception("Page failed to load!");
			}

			string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
			Report.Info("Downloads folder: " + downloadsFolder);

			string[] dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);

			foreach (string file_ in dir)
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
				//dir = Directory.GetFiles(downloadsFolder, "*_Report_DataUsage*.xlsx", SearchOption.AllDirectories);
				dir = Directory.GetFiles(downloadsFolder, "" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
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
			Report.StartStep(ReportSettings.StepCounter + " - Confirm Excel File is downloaded with name: " + file);
			try
			{
				Delay.Seconds(10);
				Report.Info("Confirm " + filetype + " file is downloaded with name: " + file);
				string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
				Report.Info("Downloads folder: " + downloadsFolder);
				string[] dir2 = Directory.GetFiles(downloadsFolder, "*", SearchOption.AllDirectories);
				string[] dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
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
			object File = Context.GetFromContext(savedAs);
			if (Report.IsTrue(File != null, "No matching file was found for name: " + savedAs + "!", "File was found: " + File.ToString()))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				Report.Info("Found: " + ExcelUtils.Excel_GetNoRows() + " rows in the spreadsheet");
				List<string> FirstRow = ExcelUtils.Excel_GetRow(0);
				Report.Info("Header row contained: '" + string.Join("', '", FirstRow) + "'");
				bool Data = false;
				for (int i = 1; i < ExcelUtils.Excel_GetNoRows(); i++)
				{
					List<string> RowData = ExcelUtils.Excel_GetRow(i);
					Report.Info("Row " + i + " had " + FirstRow[0] + ": " + RowData[0] + " and " + FirstRow[1] + ": " + RowData[1]);
					Data = true;
				}

				Report.IsTrue(Data, "Excel did not contain any product data!", "Excel file contained product data, as expected!");
			}
		}

		[StepDefinition(@"I confirm the csv file saved as (.*) can be opened and contains data")]
		public void ThenConfirmTheCSVFileCanBeOpenedAndContainsDataWPSIDAndProductName(string savedAs)
		{
			Report.Info("Confirm the excel file saved as " + savedAs + " can be opened and contains data");
			object File = Context.GetFromContext(savedAs);
			if (Report.IsTrue(File != null, "No matching file was found for name: " + savedAs + "!", "File was found: " + File.ToString()))
			{
				var lines = System.IO.File.ReadAllLines(File.ToString());

				if (lines != null)
				{
					Report.IsTrue(lines != null, "CSV file contains data");
				}

				Report.IsTrue(lines != null, "CSV did not contain any product data!", "CSV file contained product data, as expected!");
			}
		}

		[StepDefinition(@"I confirm the html file saved as (.*) can be opened and contains text: (.*)")]
		public void CheckingDownloadedHTMLFile(string savedAs, string text)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Confirm the excel file saved as " + savedAs + " can be opened and contains data");
			Report.Info("Confirm the excel file saved as " + savedAs + " can be opened and contains data");
			object file = Context.GetFromContext(savedAs);
			if (Report.IsTrue(file != null, "No matching file was found for name: " + savedAs + "!", "File was found: " + file.ToString(), false, false))
			{
				if (Report.IsTrue(File.ReadAllText(file.ToString()) != "", "File: " + file + " did not contain any content!", "File was not empty", false, false))
				{
					Report.IsTrue(File.ReadAllText(file.ToString()).Contains(text), "File did not contain text: " + text + ", content of file was: " + File.ReadAllText(file.ToString()), "File contained text: " + text + "!", false, false);
				}
			}
		}

		[StepDefinition(@"I ensure the Data Consent Tier Sliders exist for the following tiers:")]
		public void DataConsentTiersSlidersExist(Table expected)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Ensure the Data Consent Tier Sliders exist");
			try
			{
				Report.Info("Ensure the Data Consent Tier Sliders exist");
				var selRetailDetails = new RetailPartnersDetails();
				foreach (TableRow row in expected.Rows)
				{
					Report.IsTrue(selRetailDetails.GetDataConsentTier("Tier " + row["Tier"]),
						"Failed to find slider for Tier " + row["Tier"],
						"Successfully found slider for Tier " + row["Tier"]);
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I ensure the Data Consent Tier On/Off switch exists for the following tiers:")]
		public void DataConsentTiersOnOffSwitchExist(Table expected)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Ensure the Data Consent Tier On/Off switch exist");
			try
			{
				Report.Info("Ensure the Data Consent Tier On/Off switch exist");
				var selRetailDetails = new RetailPartnersDetails();
				foreach (TableRow row in expected.Rows)
				{
					Report.IsTrue(selRetailDetails.GetDataConsentTierOnofFSwitch("Tier " + row["Tier"]),
						"Failed to find slider for Tier " + row["Tier"],
						"Successfully found slider for Tier " + row["Tier"]);
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I ensure the Data Consent Tier Sliders are set as follows:")]
		public void DataConsentTiersSet(Table expected)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Ensure the Data Consent Tier Sliders are set");
			try
			{
				Report.Info("Ensure the Data Consent Tier Sliders are set");
				var selRetailDetails = new RetailPartnersDetails();
				foreach (TableRow row in expected.Rows)
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
			bool toggle = onOff == "on";
			Report.IsTrue(new RetailPartnersDetails().GetDataConsentTier(tier) == toggle,
				"The Data Consent Tier: " + tier + " was not set to: " + onOff,
				"The Data Consent Tier: " + tier + " was set to " + onOff);
		}
		[StepDefinition(@"I (should|should not) be able to edit Tier (.*)")]
		public void DataUsageTierEditing(string should, string tier)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Ensure Tier " + tier + " " + (should == "should" ? "is" : "is not") + " editable");
			try
			{
				Report.Info("Ensure Tier " + tier + " " + (should == "should" ? "is" : "is not") + " editable");

				var selRetailDetails = new RetailPartnersDetails();
				bool currentState = selRetailDetails.GetDataConsentTier(tier);

				Report.Info("Current state is " + (currentState ? "On" : "Off"));
				Report.Info("Setting state to be: " + (!currentState ? "On" : "Off"));
				selRetailDetails.SetDataConsentTier(tier, !currentState);
				Report.Info("Option clicked");
				bool newCurrentState = selRetailDetails.GetDataConsentTier(tier);
				if (should == "should")
				{
					Report.IsTrue(newCurrentState != currentState,
						"Expected to able to edit Tier " + tier + ", but this was not the case!",
						"Tier " + tier + " was edited successfully!");
					Report.Info("Turning the Data Tier back to the original state");
					Report.IsTrue(selRetailDetails.SetDataConsentTier(tier, currentState), "Failed to set the tier '" + tier + "' to: " + currentState, "Successfully set the tier " + tier + " to: " + currentState);
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
			Report.StartStep(ReportSettings.StepCounter + " - Check that the Save Changes button " + shown + " shown");
			try
			{
				Report.Info("Check that the Save Changes button " + shown + " shown");

				var selRetailDetails = new RetailPartnersDetails();
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
			var selRetailDetails = new RetailPartnersDetails();
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
			Delay.Seconds(0);
		}

		[StepDefinition(@"if the save button is visible, I save changes and close the popup dialog")]
		public void ClickSaveClosePopupIfVisible()
		{
			var selRetailDetails = new RetailPartnersDetails();
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
			warning.Rows.Cast<TableRow>().ToList().ForEach(x => expected.Add(x["Message"]));
			List<string> displayed = new RetailPartnersDetails().WarningMessages();
			IEnumerable<string> differences = expected.Except(displayed);
			Report.IsTrue(!differences.Any(),
				"The warning message did not match the expected text. Displayed is: " + string.Join("; ", displayed) + ". Expected is: " + string.Join("; ", expected),
				"The warning message matched the expected text.");

		}

		public void ThenTheFollowingWarningMessageShouldBeShowing(string expected)
		{
			Report.StartStep(ReportSettings.StepCounter + " - Correct warning message is showing");
			try
			{
				Report.Info("Correct warning message is showing");

				var selRetailDetails = new RetailPartnersDetails();
				string showing = selRetailDetails.WarningMessage();

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
			List<string> displayed = new RetailPartnersDetails().WarningMessages();
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
			List<string> showing = new RetailPartners().GetAllAvailableRetailers();
			var retList = new List<string>();
			foreach (string show in showing)
			{
				string[] parts1 = show.Split('/');
				string[] parts2 = parts1[parts1.Length - 1].Split('?');
				string filename = parts2[0];
				retList.Add(Path.GetFileNameWithoutExtension(filename).ToUpper());
			}
			foreach (TableRow row in expected.Rows)
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
			List<string> allRetailers = selRetailPartners.GetAllAvailableRetailers();
			int count = allRetailers.Count;
			for (int i = 1; i <= count; i++)
			{
				//string[] parts = allRetailers[i - 1].Split('/');
				//var filename = parts[parts.Length - 1].Split('?')[0];
				//var retailerCode = Path.GetFileNameWithoutExtension(filename).ToUpper();
				string retailerName = selRetailPartners.AllRetailerNames()[i - 1];
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
			Delay.Seconds(10);
			Report.IsTrue(new ReportDownload().ClickClose(), "Failed to click close on Report Download modal dialog", "Successfully clicked close");
		}

		[StepDefinition(@"I click the back arrow next to CVS")]
		public void GivenIClickTheBackArrowNextToCVS()
		{
			Report.IsTrue(new RetailPartnersDetails().ClickBackButton(), "Failed to click the back arrow",
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
			Report.IsTrue(new RetailPartnersDetails().Wait_for_load(60), "Retailer detail page is not showing as expected",
				"Retailer detail page is showing as expected");
		}

		[StepDefinition(@"I check that in the Supplier ID table the following columns are showing:")]
		public void ThenICheckThatInTheSupplierIDTableTheFollowingColumnsAreShowing(Table supplierIDTable)
		{
			var SupplierIDHeaders = new RetailPartnersDetails().GetSupplierIDTableHeaders().OrderBy(x => x).ToList();

			var ExpectedSupplierIDHeaders = supplierIDTable.Rows.Select(row => row["Column name"].Trim()).OrderBy(x => x).ToList();

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

		[StepDefinition(@"I click on the Add new Supplier ID link")]
		public void GivenIClickOnTheAddNewSupplierIDLink()
		{
			Report.IsTrue(new RetailPartnersDetails().ClickAddSupplierId(), "Failed to click add supplier id link",
				"Successfully clicked add supplier id link");
			//Delay.Seconds(5);
		}

		[StepDefinition(@"I confirm the pop up shows the heading: (.*)")]
		public void ThenIConfirmThePopUpShowsTheHeading(string title)
		{
			Report.IsTrue(new ModalDialog().WaitForContainerToBeVisible(), "The modal was not visible", "The modal was visible");
			string actualTitle = new ModalDialog().GetTitle();
			Report.IsTrue(actualTitle == title, "Title is " + actualTitle + " but should be: " + title,
				"Title is showing as expected: " + title);
		}
		[StepDefinition(@"I click the back arrow on the Retail Partners Details page")]
		public void ClickTheBackArrowRetailPartnersDetails()
		{
			Report.IsTrue(new RetailPartnersDetails().ClickBackButton(), "Failed to click the back arrow",
				"Successfully clicked the back arrow");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"I confirm the pop up shows the Supplier ID heading and data entry field")]
		public void ThenIConfirmThePopUpShowsTheSupplierIDHeadingAndDataEntryField()
		{
			Report.IsTrue(new AddNewSupplier().EnterSupplierIDExists(), "Supplier ID field does not exist as expected",
				"Supplier ID field exists as expected");
		}

		[StepDefinition(@"I confirm the pop up shows the Company or Brand Name heading and data entry field")]
		public void ThenIConfirmThePopUpShowsTheCompanyOrBrandNameHeadingAndDataEntryField()
		{
			Report.IsTrue(new AddNewSupplier().EnterCompanyOrBrandNameExists(), "Company or brand name field does not exist as expected",
				"Company or brand name exists as expected");
		}

		[StepDefinition(@"I confirm the pop up shows the Is Default Heading and check box")]
		public void ThenIConfirmThePopUpShowsTheIsDefaultHeadingAndCheckBox()
		{
			Report.IsTrue(new AddNewSupplier().IsDefaultExists(), "Is Default field does not exist as expected",
				"Is Default exists as expected");
		}


		[StepDefinition(@"I confirm the pop up shows a Save button")]
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

		[StepDefinition(@"in the modal dialog I click (cancel|save|Yes|No)")]
		public void GivenInTheModalDialogIClickButton(string type)
		{
			//if (cancelOrSave == "cancel")
			//{
			//	Report.IsTrue(new ModalDialog().Click_Cancel(), "Failed to click cancel button",
			//		"Successfully clicked cancel", false, false);
			//}
			//else
			//{
			//	Report.IsTrue(new ModalDialog().ClickSave(), "Failed to click save button",
			//		"Successfully clicked save");
			//}
			switch (type)
			{
				case ("cancel"):
					Report.IsTrue(new ModalDialog().Click_Cancel(), "Failed to click cancel button",
						"Successfully clicked cancel", false, false);
					break;
				case ("save"):
					Report.IsTrue(new ModalDialog().ClickSave(), "Failed to click save button",
						"Successfully clicked save", false, false);
					break;
				case ("Yes"):
					Report.IsTrue(new ModalDialog().Click_Yes(), "Failed to click yes button",
						"Successfully clicked yes", false, false);
					break;
				case ("No"):
					Report.IsTrue(new ModalDialog().Click_No(), "Failed to click no button",
						"Successfully no cancel", false, false);
					break;
				default:
					Report.Failure("Invalid input parameter used! Valid options:'cancel|save|Yes|No'");
					return;
			}
		}

		[StepDefinition(@"I confirm the Add New Supplier ID pop up closes")]
		public void ThenIConfirmTheAddNewSupplierIDPopUpCloses()
		{
			Delay.Seconds(1);
			Report.IsTrue(!(new ModalDialog().Exists), "Dialog has not closed as expected",
				"Dialog has closed as expected");
		}

		[StepDefinition(@"I confirm in the browser popup")]
		public void GivenIConfirmInTheBrowserPopup()
		{
			SeleniumBrowser.WebBrowser.SwitchTo().Alert().Accept();
		}

		[StepDefinition(@"I confirm that the CSV file saved as: (.*) contains the following columns:")]
		public void ThenIConfirmThatTheCSVFileSavedAsContainsTheFollowingColumns(string savedAs, Table table)
		{
			Report.Info("Confirm the CSV file saved as " + savedAs + " can be opened and contains data");
			object File = Context.GetFromContext(savedAs);
			if (Report.IsTrue(File != null, "No matching file was found for name: " + savedAs + "!", "File was found: " + File.ToString()))
			{
				var lines = System.IO.File.ReadAllLines(File.ToString());

				if (lines != null)
				{
					Report.IsTrue(lines != null, "CSV file contains data");
				}

				string linesStr = lines[0];

				foreach (TableRow row in table.Rows)
				{
					if ((!linesStr.Contains(row[@"Column"] + ",")) && (!linesStr.Contains("," + row[@"Column"])))
					{
						Report.Failure("The following data was not found: " + row[@"Column"]);
						return;
					}
				}

				Report.Success("All columns in table have been found"); 
				
			}

		}

		[StepDefinition(@"I confirm that the excel file saved as: (.*) contains the following columns:")]
		public void ThenIConfirmThatTheExcelFileSavedAsContainsTheFollowingColumns(string savedAs, Table table)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));

				var expectedColumns = new List<string>();
				foreach (TableRow thisRow in table.Rows)
				{
					expectedColumns.Add(thisRow["Column"]);
				}

				int unexpectedCount = 0;
				if (expectedColumns.Count < ColumnTitles.Count)
				{
					Report.Info("Found unexpected columns!");
					foreach (string ColumnTitle in ColumnTitles)
					{
						if (!expectedColumns.Contains(ColumnTitle))
						{
							unexpectedCount++;
							Report.Info("Found unexpected column title: " + ColumnTitle + ".");
						}
					}
					Report.Failure("Found " + unexpectedCount + " unexpected columns.", false);
				}

				foreach (TableRow thisRow in table.Rows)
				{
					Report.IsTrue(ColumnTitles.Contains(thisRow["Column"]),
						"Column name is not found: " + thisRow["Column"],
						"Column name has been found as expected: " + thisRow["Column"], false, false);
				}
			}
		}

		[StepDefinition(@"I get the excel row data file saved as: (.*) and save the data to context")]
		public void GrabExcelRowDataAndSaveItToContext(string savedAs)
		{

			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!File.IsNullOrEmpty(), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");

				List<string> FirstRow = ExcelUtils.Excel_GetRow(0);
				List<string> SecondRow = ExcelUtils.Excel_GetRow(3);

				Dictionary<string, string> excelData = new Dictionary<string, string>();
				for (int i = 0; i < SecondRow.Count; i++)
				{
					if ((SecondRow[i] != "-") && (SecondRow[i] != null))
					{
						Context.AddToContext(FirstRow[i], SecondRow[i]);
						excelData.Add(FirstRow[i], SecondRow[i]);
					}

				}
				Context.AddToContext("ExcelDictionaryData", excelData);

			}
		}

		[StepDefinition(@"I confirm that the excel file saved as: (.*) contains the following columns: and they are in the correct order.")]
		public void ThenIConfirmThatTheExcelFileSavedAsContainsTheFollowingColumnsAndAreInTheCorrectOrder(string savedAs, Table table)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));

				var expectedColumns = new List<string>();
				foreach (TableRow thisRow in table.Rows)
				{
					expectedColumns.Add(thisRow["Column"]);
				}

				if (Math.Abs(expectedColumns.Count - ColumnTitles.Count) != 0)
				{
					Report.Failure("Found " + Math.Abs(expectedColumns.Count - ColumnTitles.Count) + " unexpected columns.");
				}

				for (int i = 1; i < expectedColumns.Count; i++)
				{
					Report.Info($"The expected column at postion: {i} is: {expectedColumns[i]} and the coloum found was {ColumnTitles[i]}");
					Report.IsTrue(expectedColumns[i] == ColumnTitles[i], "The Column headings did not match", "The Column headings matched");

				}

				//foreach (TableRow thisRow in table.Rows)
				//{
				//	Report.IsTrue(ColumnTitles.Contains(thisRow["Column"]),
				//		"Column name is not found: " + thisRow["Column"],
				//		"Column name has been found as expected: " + thisRow["Column"], false, false);
				//}
			}
		}

		[StepDefinition(@"I save the product with name: (.*) and id: (.*) as: (.*)")]
		public void ISaveProductWithNameAndIDAs(string name, string id, string saveAs)
		{
			id = Context.GetFromContext(id)?.ToString() ?? "";
			name = Context.GetFromContext(name)?.ToString() ?? "";
			var newProductInformation = new ProductInformation {
				Id = id,
				Name = name
			};
			Context.AddToContext(saveAs, newProductInformation);
		}

		[StepDefinition(@"I save the first product in the excel spreadsheet saved as: (.*) as (.*)")]
		public void ISaveTheFirstProductInTheExcelSpreadSheetAs(string spreadsheet, string product)
		{
			string File = Context.GetFromContext(spreadsheet)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + spreadsheet + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> thisProduct = ExcelUtils.Excel_GetRow(1);
				var newProductInformation = new ProductInformation {
					Id = thisProduct[0],
					Name = thisProduct[1]
				};
				Context.AddToContext(product, newProductInformation);
			}
		}

		[StepDefinition(@"I save the first row in the spreadsheet saved as (.*) as (.*)")]
		public void ISaveTheFirstRowOfTheSpreadsheetAs(string spreadsheet, string savedAs)
		{
			string File = Context.GetFromContext(spreadsheet)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + spreadsheet + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> headers = ExcelUtils.Excel_GetRow(0);
				List<string> thisProduct = ExcelUtils.Excel_GetRow(1);

				var dictionary = new Dictionary<string, string>();
				for (int i = 0; i < headers.Count && i < thisProduct.Count; i++)
				{
					dictionary[headers[i]] = thisProduct[i];
				}
				Context.AddToContext(savedAs, dictionary);
			}
		}

		[StepDefinition(@"I save the value with the header (.*) on the first product in the excel spreadsheet saved as: (.*) as (.*)")]
		public void SaveTheValueWithHeaderAs(string header, string spreadsheet, string saveAs)
		{
			string File = Context.GetFromContext(spreadsheet)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + spreadsheet + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				string value = ExcelUtils.GetCellValue(1, header, 0);
				Report.Info("Found value " + value + " for header " + header + ". Adding to context.");
				Context.AddToContext(saveAs, value);
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
			foreach (KeyValuePair<string, string> retailer in retailerInfo)
			{
				ReportSettings.UseSubSteps = false;
				Report.StartStep("Clicking the retailer: " + retailer.Value + " should navigate to the Wal-Mart/SAM'S CLUB Retail Partners Details page with all 7 affiliates shown under <retailer> & You");
				ReportSettings.UseSubSteps = true;
				var selRetailPartners = new RetailPartners();
				var selRetailPartnersDetails = new RetailPartnersDetails();
				Report.StartStep("Clicking on the logo for the retailer: " + retailer.Value + " in the Retail Partners page");
				Report.IsTrue(selRetailPartners.ClickRetailerLogo(retailer.Key),
					"Failed to click on the logo for retailer: " + retailer.Value,
					"Successfully clicked on the logo for retailer: " + retailer.Value);
				Report.StartStep("I confirm that the Wal-mart/SAM'S CLUB Details page is shown");
				Report.IsTrue(selRetailPartnersDetails.GetSelectedRetailer() == "Wal-Mart/SAM'S CLUB",
					"The selected retailer on Retail Partner Details page was not 'Wal-Mart/SAM'S CLUB'",
					"The selected retailer on Retail Partner Details page was 'Wal-Mart/SAM'S CLUB' as expected");
				Report.StartStep("I confirm that under the <Retailer> & You heading all 7 Wal-Mart affiliate retailers are displayed");
				List<string> actualRetailers = selRetailPartnersDetails.WalmartRegistrationsRetailers();
				Report.IsTrue(!actualRetailers.Except(retailerNames).Any() && actualRetailers.Count == retailerNames.Count,
					"The actual list of retailers showing under '<Retailer> & You' did not match the expected list. Showing retailers were: " + string.Join(", ", actualRetailers.Select(x => "'" + x + "'"), 2),
					"The actual list of retailers showing under '<Retailer> & You matched the expected list");
				selRetailPartnersDetails.ClickBackButton();
			}
		}

		[StepDefinition(@"I confirm that the excel file saved as: (.*) in column: (.*) there are no numbers")]
		public void ThenIConfirmThatTheExcelFileSavedAsInColumnThereAreNoNumbers(string savedAs, string columnName)
		{
			object File = Context.GetFromContext(savedAs);
			bool AllPassed = true;
			if (Report.IsTrue(File != null, "No matching file was found for name: " + savedAs + "!", "File was found: " + File.ToString()))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
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
			string file = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (string.IsNullOrEmpty(file))
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
			Report.IsTrue(new RetailPartnersDetails().ClickInfoButton(button), $"Failed to click the {button} button!", $"Successfully clicked the {button} button");
		}

		[StepDefinition(@"I confirm the ""(.*)"" information button is displayed on the Retail Partners Details screen")]
		public void ConfirmTheInfoButtonIsDisplayedOnRetailPartnersDetails(string button)
		{
			Report.IsTrue(new RetailPartnersDetails().InfoButton(button) != null,
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
			Delay.Seconds(10);
			var expectedTabs = new List<string>();
			tabs.Rows.Cast<TableRow>().ToList().ForEach(x => expectedTabs.Add(x["Tab"]));
			List<string> displayedTabs = new DataTierDetails().AllTabs();
			Report.IsTrue(expectedTabs.All(x => displayedTabs.Contains(x)) && expectedTabs.Count == displayedTabs.Count,
				$@"The displayed tabs did not match the expected tabs! Expected: ""{string.Join(", ", expectedTabs.Select(x => $"'{x}'"), 2)}"". Found: ""{string.Join(", ", displayedTabs.Select(x => $"'{x}'"), 2)}""",
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
			List<KeyValuePair<string, string>> displayedParagraphs_ = new DataTierDetails().TabParagraphs();
			foreach (TableRow row in paragraphText.Rows)
			{
				string expectedSection = row["Section"];
				string expectedText = row["Text"];
				Report.IsTrue(displayedParagraphs_.Any(x => x.Key == expectedSection && x.Value.Contains(expectedText)),
					$"Did not find expected text in section: {expectedSection}! Expected: {expectedText}",
					$"Found the expected text in section: {expectedSection}. Text: {expectedText}");
			}
		}

		[StepDefinition(@"I confirm the Data Tier Details subheading reads: (.*)")]
		public void ConfirmTheDataTierDetailsSubheadingReads(string expectedSubheading)
		{
			string actualSubHeading = new DataTierDetails().SubHeading().Trim();
			Report.IsTrue(expectedSubheading.Trim() == actualSubHeading,
				$"The Data Tier Details subheading did not match the expected text! Expected: '{expectedSubheading}'. Actual: '{actualSubHeading}'",
				"The Data Tier Details subheading matched the expected text");
		}

		[StepDefinition(@"I confirm the Retailer Details Page has loaded")]
		public void IConfirmTheRetailerDetailsPageHasLoaded()
		{
			Report.IsTrue(new RetailPartnersDetails().Wait_for_load(), "The Retailer Details page was not loaded!", "The Retailer Details page was loaded as expected");
		}

		[StepDefinition(@"I confirm the Data Consent Tiers table is displayed")]
		public void ConfirmTheDataConsentTiersTableIsDisplayed()
		{
			Report.IsTrue(new RetailPartnersDetails().DataConsentTiersTable() != null,
				"The Data Consent Tiers table was not displayed!",
				"The Data Consent Tiers table was displayed as expected.");
		}

		[StepDefinition(@"I confirm that row: (.*) of the Data Consent Tiers table displays: ""(.*)""")]
		public void ConfirmThatRowOfTheDataConsentTiersTableDisplaysText(string row, string text)
		{
			var selRetailPartnersDetails = new RetailPartnersDetails();
			List<string> tierRows = selRetailPartnersDetails.GetAllDataConsentTiers();
			if (int.TryParse(row, out int rowNum))
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
			var thisAddNewSupplier = new AddNewSupplier();
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
			var thisAddNewSupplier = new AddNewSupplier();
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
			var thisAddNewSupplier = new AddNewSupplier();
			Report.IsTrue(thisAddNewSupplier.EnterSupplierID(supplierIDInput), "Failed to add supplier ID input",
				"Entered supplier ID value");
		}

		[StepDefinition(@"in the Add New Supplier Dialog I enter the following in the Company or Brand Name input: (.*)")]
		public void GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheCompanyOrBrandNameInput(string companyInput)
		{
			var thisAddNewSupplier = new AddNewSupplier();
			Report.IsTrue(thisAddNewSupplier.EnterCompanyOrBrandName(companyInput), "Failed to add company or brand name input",
				"Entered company or brand name value");
		}

		[StepDefinition(@"in the Add New Supplier Dialog I select the first option in the Company or Brand Name input and save to context as: (.*)")]
		public void GivenInTheAddNewSupplierDialogISelectTheFirstOptionInTheCompanyOrBrandNameInput(string savedAs)
		{
			var thisAddNewSupplier = new AddNewSupplier();
			var options = thisAddNewSupplier.CompanyOrBrandNameOptions();
			if (options == null || !options.Any())
			{
				Report.Failure("No options were found in the Company or Brand Name select input!");
				Report.Screenshot();
				return;
			}
			var option = options.First();
			Context.AddToContext(savedAs, option);
			Report.Info("Selecting option: " + option);
			Report.IsTrue(thisAddNewSupplier.EnterCompanyOrBrandName(option), "Failed to add company or brand name input",
				"Entered company or brand name value");
		}

		//CompanyOrBrandNameOptions()

		[StepDefinition(@"in the Add New Supplier Dialog I Confirm that no error shows below Company or Brand Name question")]
		public void GivenInTheAddNewSupplierDialogIConfirmThatNoErrorShowsBelowCompanyOrBrandNameQuestion()
		{
			var thisAddNewSupplier = new AddNewSupplier();
			Report.IsTrue(!thisAddNewSupplier.CompanyNameErrorExists(), "Company or brand name error is incorrectly showing",
				"As expected no error is showing below Company or Brand name question");
		}

		[StepDefinition(@"in the Add New Supplier Dialog I Confirm that no error shows below Supplier ID question")]
		public void GivenInTheAddNewSupplierDialogIConfirmThatNoErrorShowsBelowSupplierIDQuestion()
		{
			var thisAddNewSupplier = new AddNewSupplier();
			Report.IsTrue(!thisAddNewSupplier.SupplierIDErrorExists(), "Supplier ID error is incorrectly showing",
				"As expected no error is showing below Supplier ID question");
		}

		/// <summary>
		/// Requires a table with columns: | Supplier ID | Company or Brand Name |
		/// Company or Brand Name may use 'saved as: (.*)' where (.*) is the Context savedAs string
		/// </summary>
		[StepDefinition(@"I confirm that in the Supplier IDS list the following row exists")]
		public void ThenIConfirmThatInTheSupplierIDSListTheFollowingRowExists(Table table)
		{
			List<Supplier> allSuppliers = new RetailPartnersDetails().GetAllSuppliers();

			string expectedSupplierID = table.Rows[0]["Supplier ID"];
			string expectedCompany = table.Rows[0]["Company or Brand Name"];
			if (expectedCompany.StartsWith("saved as:"))
			{
				var savedAs = expectedCompany.Replace("saved as:", "").Trim();
				expectedCompany = Context.GetFromContext(savedAs)?.ToString();
				if (expectedCompany == null)
				{
					Report.Failure("Failed to get Company Brand Name from context as: " + savedAs);
					return;
				}
			}
			Supplier matchingSupplier = allSuppliers.FirstOrDefault(x => x.SupplierID == expectedSupplierID && x.CompanyOrBrandName == expectedCompany);

			Report.IsTrue(matchingSupplier != null, "No matching row was found in the list",
				"Matching row as found as expected");
		}
		[StepDefinition(@"in the Add New Supplier Dialog I click save")]
		public void GivenInTheAddNewSupplierDialogIClickSave()
		{

			var thisAddNewSupplier = new AddNewSupplier();
			Report.IsTrue(thisAddNewSupplier.ClickSave(), "Failed to click save", "Successfully clicked save");
			Delay.Seconds(2);
		}


		//x = 1 for O'Reilly, 2 for Sears, 3 for Wal-Mart
		[StepDefinition(@"I find the Supplier ID for (.*) in the SupplierID table and save as (.*)")]
		public void GivenIFindTheSupplierIDForSupplierInTheSupplierIDTable(string supplier, string saveAs)
		{
			List<Supplier> allSuppliers = new RetailPartnersDetails().GetAllSuppliers();
			var regex = new Regex(@"\d+");
			var potentialRootStrings = new List<string>();
			foreach (Supplier thisSupplier in allSuppliers)
			{
				MatchCollection matches = Regex.Matches(thisSupplier.SupplierID, @"\d{5}1");
				// Use foreach-loop.
				foreach (System.Text.RegularExpressions.Match match in matches)
				{
					if (match.Success)
					{
						potentialRootStrings.Add(thisSupplier.SupplierID.Substring(0, 5));
					}
				}
			}

			string foundRootString = "";
			foreach (string thisRootString in potentialRootStrings)
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

		//Creating a new version of this method as the above one was erroring and I am not sure why its getting rootstrings etc?
		[StepDefinition(@"For retailer: (.*) I confirm the the supplier ID: (.*) is found in the supplier ID Table and save it as: (.*)")]
		public void GivenIFindTheSupplierIDForSupplierInTheSupplierIDTable(string supplier, string expectedID, string saveAs)
		{
			List<Supplier> allSuppliers = new RetailPartnersDetails().GetAllSuppliers();
			var regex = new Regex(@"\d+");
			var potentialRootStrings = new List<string>();
			if (expectedID.Contains("x"))
			{
				switch (supplier)
				{
					case "O'Reilly":
						expectedID = expectedID.Replace("x", "1");
						break;
					case "Sears":
						expectedID = expectedID.Replace("x", "2");
						break;
					case "Wal-Mart":
						expectedID = expectedID.Replace("x", "3");
						break;
					default:
						throw new Exception("You need to specify O'Reilly, Sears or Wal-Mart");
				}
			}

			foreach (Supplier thisSupplier in allSuppliers)
			{

				if (thisSupplier.SupplierID == expectedID)
				{
					Report.Success($"The Supplier ID: {expectedID} was found in the supplier ID table");
					Report.Info($"Adding the supplier ID to context as: {saveAs}");
					Context.AddToContext(saveAs, expectedID);
					return;
				}
				//MatchCollection matches = Regex.Matches(thisSupplier.SupplierID, @"\d{5}1");
				//// Use foreach-loop.
				//foreach (Match match in matches)
				//{
				//	if (match.Success)
				//	{
				//		if(match.ToString()==expectedID)
				//		{
				//			Report.Success($"The Supplier ID: {expectedID} was foun in the supplier ID table");
				//			Report.Info($"Adding the supplier ID to context as: {saveAs}");
				//			Context.AddToContext()
				//		}						

				//	}
				//}
			}

			Report.Failure($"The Supplier ID: {expectedID} was not found in the supplier ID table");
			return;
			//Context.AddToContext(saveAs, requiredId);

		}

		[StepDefinition(@"I Confirm the Is Active column for SupplierID saved as (.*) (shows|does not show) a green check mark")]
		public void GivenIConfirmTheIsActiveColumnForSupplierIDSavedAsSupplierIDShowsAGreenCheckMark(string savedAs, string showsDoesNotShow)
		{
			List<Supplier> allSuppliers = new RetailPartnersDetails().GetAllSuppliers();
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

		public bool MatchAbbreviatedRetailer(string abbreviation, string retailerToMatch)
		{
			var abbreviationList = abbreviation.Split(',').Select(x => x.Trim()).ToList();
			string capitalLetters = string.Concat(retailerToMatch.Where(c => c >= 'A' && c <= 'Z'));


			foreach (string abbrv in abbreviationList)
			{
				if (capitalLetters.Length >= abbrv.Length)
				{
					if (capitalLetters.Substring(0, abbrv.Length) == abbrv)
					{
						Report.Info("Retailer to match has been abbreviated to: " +
									capitalLetters.Substring(0, abbrv.Length) + " and a match has been found");
						return true;
					}
				}
				Report.Info("No match was found between " + retailerToMatch + " and " + abbrv);
			}
			return false;
		}


		[StepDefinition(@"I click download PDF for ""(.*)""")]
		public void ClickDownloadPdf(string option)
		{
			Report.IsTrue(new DataTierDetails().ClickDownloadPdfWithHeading(option), $"Failed to click download pdf option for {option}!", $"Successfully clicked download pdf option for {option}");
		}

		[StepDefinition(@"The success message in the Save Changes popup dialog should contain the following:")]
		public void SuccessMessagesSaveChangesPopupShouldContain(Table warning)
		{
			var expected = new List<string>();
			warning.Rows.Cast<TableRow>().ToList().ForEach(x => expected.Add(x["Message"]));
			List<string> displayed = new DataEntryNotification().SuccessMessages();
			IEnumerable<string> differences = expected.Except(displayed);
			Report.IsTrue(!differences.Any(),
				"The success message did not match the expected text. Displayed is: " + string.Join("; ", displayed) + ". Expected is: " + string.Join("; ", expected),
				"The sucess message matched the expected text.");

		}

		[StepDefinition(@"I create a new supplier products account: (.*) and create a new brand in that account")]
		public void CreateNewSupplierProductsAccountAndCreateAProductWithRetailerCVS(string savedAs)
		{
			//delete this step
			Report.Info("Setting up account for user: '" + savedAs + "'");
			var subCompanyInfo = new Table("Email", "Country", "FirstName", "LastName", "Password", "Address1", "Address2", "City", "State", "Zip", "CompanyName", "CompanyPhone",
				"EmergencyPhoneNumber", "SupplierType", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "Pin");
			subCompanyInfo.AddRow("User_<random>", "UNITED STATES", "WERCS", "Test_Automation_ProductsAccount", "Welcome1!", "Address1", "Address2", "Latham", "Florida", "12205", "QA_Automation_ProductsAccount", "123-456-7889",
				"123-456-7889", "Manufacturer", "PhoneQuestion", "PhoneHint", "MentorQuestion", "MentorHint", "FriendQuestion", "FriendHint", "AnimalQuestion", "AnimalHint", "CollegeQuestion", "CollegeHint", "1234");
			WERCSmartUser account = new StepsSupplierAccounts().SaveUser(subCompanyInfo, savedAs);
			new StepsSupplierAccounts().BasicSignup(savedAs);

			var myHome = new StepsHomepage();
			var myAccount = new StepsMyAccount();
			var mySubscriptionEnrollment = new StepsSubscriptionEnrollment();
			var myPay = new Steps_PaymentMethods();
			var myAccountSteps = new StepsMyAccount();
			var myPkgType = new Steps_PackagingTypes();
			var newProductSteps = new StepsNewProduct();
			var myBrand = new Steps_Brands();
			var myRetailPartner = new StepsRetailPartners();
			var myProductsetup = new Steps_ProductSetup();
			var dataNotification = new GoToDataTierNotification();
			myHome.ThenIClickOnUserItem("My Account");
			//Subscription 
			myAccount.ThenIClickOnNewSubscription();
			var subEnrollTable = new Table("Articles", "Enhanced Articles",
				"Formulated Products", "Feature Plan", "Support Services Plan");
			subEnrollTable.AddRow("Up to 400 Product(s)", "Up to 400 Product(s)", "Up to 400 Product(s)", "Standard", "Bronze");
			mySubscriptionEnrollment.ThenISelectTheFollowingEnrollmentOptions(subEnrollTable);
			mySubscriptionEnrollment.ThenIClickOnX("Checkout");
			myPay.ThenISelectPaymentMethodX("Credit Card");
			var myCreditCardTable = new Table("Card Type", "Card Number", "Expiration Month", "Expiration Year", "CVV", "Cardholder Name");
			myCreditCardTable.AddRow("Visa", "4111 1111 1111 1111", "08", "2028", "1111", "WERCS_QA_Automation");
			myPay.ThenIEnterCreditCardDetails(myCreditCardTable);
			myPay.ThenIClickContinue();
			myPay.ThenInThePurchaseSummaryScreenIClickConfirmOrder();
			myPay.ThenInTheThankYouScreenIClickHome();
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("Subscription Information");
			myAccount.ThenInTheSubscriptionInformationScreenIConfirmTheStatusHasTheCorrectInformationFormulatedArticlesEnhancedArticles("400", "400", "400");

			//My Packaging Type
			myHome.ThenIClickOnUserItem("My Account");
			myAccount.ThenInTheMyAccountScreenINavigateToTheXPage("My Library");
			myAccountSteps.ClickAddNewMyLibrary("My Packaging Types");
			newProductSteps.GivenIShouldSeeXPage("Packaging Type");
			newProductSteps.SetTheSectionOptionTo("Package Type Name", "myPkg");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Bill of Materials");
			myPkgType.SavePackagingTypeDetails("MyPkg1");
			myPkgType.ClickAddRowBillOfMaterials();
			myPkgType.SelectOptionForFieldInTable("Clear Glass", "My Packaging Materials");
			myPkgType.SelectOptionForFieldInTable("2", "My Packaging Weight (grams)");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container or any packaging", "No");
			newProductSteps.SetTheSectionOptionTo("Do you have a CONEG Certificate", "No");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("CONEG");
			newProductSteps.SetTheSectionOptionTo("Does your container contain", "None of the above");
			newProductSteps.SetTheSectionOptionTo("Packaging Component Recyclable", "21");
			newProductSteps.ClickContinue();
			newProductSteps.GivenIShouldSeeXPage("Data Acceptance");
			newProductSteps.GivenInTheDataAcceptancePageIClickOnTheAcceptButton();
			myPkgType.PackagingTypeSavedAsAppearsInGrid("MyPkg1", "appears");

			//My Brands
			myAccount.ClickTabMyLibrary("My Brands");
			myAccount.ClickAddNewMyLibrary("My Brands");
			myBrand.EnterBrandNameExpandedRow("TestBrand");
			myBrand.ClickSaveMyBrandsGrid();
			myBrand.ActiveValueIsYesForLastBrand("Yes");


			//create a product for CVS data tier
			myProductsetup.CreateProductConditionerForCVSAndTakeToDataSummary("product2", "Conditioner");
			myHome.ClickItemInNavigationPanel("Retail Partners");
			myRetailPartner.SelectRetailer("CVS");
			myRetailPartner.ConfirmHeadingShowing("Data Consent Tiers");


		}

		[StepDefinition(@"I navigate to the Data Consent Tiers Page for CVS")]
		public void INavigateToTheDataConentTiersPageForCVS()
		{

			var myHome = new StepsHomepage();
			myHome.ClickItemInNavigationPanel("Retail Partners");
			this.SelectRetailer("CVS");
			this.ConfirmHeadingShowing("Data Consent Tiers");
		}

		//[StepDefinition(@"I Check that The expected data tiers for CVS are present in the Data Consent Tiers Section")]
		//public void ICheckThatTheGivenDataTiersArePresent()
		//{
		//	var retailerPartnerDetails = new RetailPartnersDetails();

		//	List<string> tiersPresent = retailerPartnerDetails.GetAllDataConsentTiers();

		//	List<string> expectedTiers = retailerPartnerDetails.ExpectedCVSDataTiers();

		//	foreach (var item in expectedTiers)
		//	{

		//		Report.IsTrue(tiersPresent.Any(x => x.Contains(item)), "The Data Consent Tiers found did not include the tier: " + item, "The Data Consent Tiers found did include the tier: " + item);
		//	}


		//}

		[StepDefinition(@"I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section")]
		public void ICheckThatTheGivenDataTiersAreOnlyOnesPresent()
		{
			var retailerPartnerDetails = new RetailPartnersDetails();

			List<string> tiersPresent = retailerPartnerDetails.GetAllDataConsentTiers();

			List<string> expectedTiers = retailerPartnerDetails.ExpectedCVSDataTiers();


			//List<string> testItems = tiersPresent.FindAll(x => !expectedTiers.Contains(x));
			//Report.IsTrue(testItems.Count==0, "The Data Consent Tiers found did not match. The found differences were: " + string.Join(",", testItems), "The Data Consent Tiers were an exact match");


			var diffFound = new List<string>();
			foreach (var item in tiersPresent)
			{
				if (!expectedTiers.Contains(item))
				{
					diffFound.Add(item);
				}
			}
			Report.IsTrue(diffFound.Count == 0, "The Data Consent Tiers found did not match. The found differences were: " + string.Join(",", diffFound), "The Data Consent Tiers were an exact match");

			//var diff = tiersPresent.Except(expectedTiers);
			//Report.IsTrue(diff.Any(), "The Data Consent Tiers found did not match. The found differences were: " + string.Join(",", diff), "The Data Consent Tiers were an exact match");

		}

		[StepDefinition(@"I Check that the data consent tiers available for selection only include Tier 1")]
		public void ICheckThatTheDataConsentTiersAvailableForSelectionOnlyIncludeTier1()
		{
			var retailerPartnerDetails = new RetailPartnersDetails();

			string tier1 = "Tier 1: Regulatory Support";

			List<string> tiersPresent = retailerPartnerDetails.GetAllDataConsentTiers();

			List<string> tierdiff = tiersPresent.FindAll(x => !x.Contains(tier1));

			Report.IsTrue(tierdiff.Count() == 0, "The Data Consent Tiers found included more than Tier 1. The found differences were: " + string.Join(",", tierdiff), "The Data Consent Tiers found only included Tier 1");


		}

		[Then(@"I confirm that the excel file saved as: (.*) contains the WPSID for the Product saved as: (.*)")]
		public void IConfirmTheExcelFileSavedAsContainsProductSavedAs(string fileSavedAs, string productSavedAS)
		{
			object File = Context.GetFromContext(fileSavedAs);


			if (!Context.Contains(productSavedAS))
			{
				Report.Failure($"Could not the product saved as: {productSavedAS} in context");
				return;
			}

			var wsProduct = (ProductInformation)Context.GetFromContext(productSavedAS);
			string iD = wsProduct.Id;

			if (Report.IsTrue(File != null, "No matching file was found for name: " + fileSavedAs + "!", "File was found: " + File.ToString()))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				//get the index of column
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));
				int wPSIDColumnIndex = 0;
				bool wPSIDColumnFound = false;
				for (int i = 0; i < ColumnTitles.Count; i++)
				{
					if (ColumnTitles[i] == "WPS ID")
					{
						wPSIDColumnIndex = i;
						wPSIDColumnFound = true;
						break;
					}
				}
				if (!wPSIDColumnFound)
				{
					Report.Failure("The column: WPS ID could not be found in the spreadsheet");
					return;
				}
				List<string> wPSIDColumnContents = ExcelUtils.Excel_GetColumn(wPSIDColumnIndex);
				foreach (var item in wPSIDColumnContents)
				{
					if (item == iD)
					{
						Report.Success($"Succesfully found the WPSID in the excel file");
						return;
					}
				}
				Report.Failure($"The WPSID: {iD} was not found in the column 'WPS ID'");

			}

		}

		[StepDefinition(@"I click the Products in Scope button and confirm that a file is not produced called (.*)")]
		public void ThenClickTheProductsInScopeButtonBelowTheMoreInformationHyperlinkAndNotFileProduced(string file)
		{
			Report.Info("Click the Products in Scope button");

			var selRetailDetails = new RetailPartnersDetails();

			if (!selRetailDetails.Wait_for_load(10))
			{
				throw new Exception("Page failed to load!");
			}

			string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
			Report.Info("Downloads folder: " + downloadsFolder);

			string[] dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);

			foreach (string file_ in dir)
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

				dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
				Delay.Seconds(Delay.SpeedFactor * 1);
				i++;
			}

			Report.IsTrue(!dir.Any(), "A File with name: " + dir.FirstOrDefault() + " was found", "No File was found");

			Report.Info("Downloads folder: " + downloadsFolder);

			foreach (string file_ in dir)
			{
				Report.Info($"Deleteing the file with name: {file_}");
				File.Delete(file_);
			}

		}

		[StepDefinition(@"I click the Products in Scope button and confirm that a file is produced called (.*) and save as (.*)")]
		public void ThenClickTheProductsInScopeButtonAndCheckForFile(string file, string savedAs)
		{
			Report.Info("Click the Products in Scope button");

			var selRetailDetails = new RetailPartnersDetails();

			if (!selRetailDetails.Wait_for_load(10))
			{
				throw new Exception("Page failed to load!");
			}

			string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
			Report.Info("Downloads folder: " + downloadsFolder);

			string[] dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);

			foreach (string file_ in dir)
			{
				Report.Info($"Deleteing the file with name: {file_}");
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

				dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
				Delay.Seconds(Delay.SpeedFactor * 1);
				i++;
			}

			if (Report.IsTrue(dir.Any(), "No file was found with name " + file, "File with name: " + dir.FirstOrDefault() + " was found successfully!"))
			{
				Context.AddToContext(savedAs, dir.FirstOrDefault());
			}

			this.GivenIClickOnCloseInTheReportDownloadDialog();
		}


		[StepDefinition(@"I confirm that the excel file saved as: (.*) contains the WPSID saved as: (.*) and has a 'Y' in the columns:")]
		public void ThenIConfirmThatTheExcelFileSavedAsContainsWPSIDAndYInColumns(string fileSavedAs, string wpsidSavedAs, Table table)
		{
			string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + fileSavedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));

				int wpsIDColumnIndex = 0;
				for (int j = 0; j < ColumnTitles.Count; j++)
				{
					if (ColumnTitles[j] == "WPS ID")
					{
						wpsIDColumnIndex = j;
					}
				}
				string wpsidStr = ((ProductInformation)Context.GetFromContext(wpsidSavedAs)).Id;
				List<string> wpsidItems = ExcelUtils.Excel_GetColumn(wpsIDColumnIndex);
				int wantedWpsidPosition = 0;
				bool foundWpsid = false;
				foreach (var wpsidItem in wpsidItems)
				{
					if (wpsidItem != wpsidStr)
					{
						wantedWpsidPosition++;
					}
					else
					{
						Report.Success($"The WPSID was found at position: {wantedWpsidPosition}");
						foundWpsid = true;
						break;
					}
				}
				if (!foundWpsid)
				{
					Report.Failure("Could not find the WPSID in the SpreadSheet");
					return;
				}

				foreach (TableRow row in table.Rows)
				{
					string currentRow = row["Column"];
					int columnUPCIndex = 0;
					for (int i = 0; i < ColumnTitles.Count; i++)
					{
						if (ColumnTitles[i] == currentRow)
						{
							columnUPCIndex = i;
						}
					}

					List<string> upcRowItems = ExcelUtils.Excel_GetColumn(columnUPCIndex);
					Report.Info($"Looking for a 'Y' for WPSID: {wpsidStr} in the Column: {currentRow}");
					string actualValue = upcRowItems[wantedWpsidPosition];
					Report.Info($"actual value was: {actualValue}");
					Report.IsTrue(actualValue == "Y", "The actual value was not 'Y'", "The actual value was 'Y'");

				}

			}
		}







		[StepDefinition(@"I confirm that the excel file saved as: (.*) contains CVS products with tiers 2.1, 2.2, 3 and 4.1 granted")]
		public void ThenIConfirmThatTheExcelFileSavedAsContainsCVSProductsWithTiers(string fileSavedAs)
		{
			string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + fileSavedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));

				int retailerColumnIndex = 0;
				bool columnRetailerFound = false;
				for (int j = 0; j < ColumnTitles.Count; j++)
				{
					if (ColumnTitles[j] == "Client")
					{
						retailerColumnIndex = j;
						columnRetailerFound = true;
					}
				}
				if (!columnRetailerFound)
				{
					return;
				}

				int column21Index = 0;
				bool Column21Found = false;
				for (int t = 0; t < ColumnTitles.Count; t++)
				{
					if (ColumnTitles[t] == "2.1 Granted")
					{
						column21Index = t;
						Column21Found = true;
					}
				}
				if (!Column21Found)
				{
					return;
				}

				bool Column22Found = false;
				int column22Index = 0;
				for (int y = 0; y < ColumnTitles.Count; y++)
				{
					if (ColumnTitles[y] == "2.2 Granted")
					{
						column22Index = y;
						Column22Found = true;
					}
				}
				if (!Column22Found)
				{
					return;
				}

				bool Column3Found = false;
				int column3Index = 0;
				for (int y = 0; y < ColumnTitles.Count; y++)
				{
					if (ColumnTitles[y] == "3 Granted")
					{
						column3Index = y;
						Column3Found = true;
					}
				}
				if (!Column22Found)
				{
					return;
				}

				bool Column41Found = false;
				int column41Index = 0;
				for (int x = 0; x < ColumnTitles.Count; x++)
				{
					if (ColumnTitles[x] == "4.1 Granted")
					{
						column41Index = x;
						Column41Found = true;
					}
				}
				if (!Column41Found)
				{
					return;
				}

				string checkedRetailer = "CV";
				List<string> displayedRetailers = ExcelUtils.Excel_GetColumn(retailerColumnIndex);
				int wantedRetailerPosition = 0;
				bool foundRetailer = false;
				foreach (var activeRetailer in displayedRetailers)
				{
					if (activeRetailer != checkedRetailer)
					{
						wantedRetailerPosition++;
					}
					else
					{
						Report.Success($"The retailer was found at position: {wantedRetailerPosition}");
						foundRetailer = true;
						break;
					}
				}
				if (!foundRetailer)
				{
					Report.Failure("Could not find the retailer in the SpreadSheet");
					return;
				}

				List<string> cvsRow = ExcelUtils.Excel_GetRow(wantedRetailerPosition);
				//bool tiersListedCorrectly = true;				

				Report.IsTrue(cvsRow[column21Index] != "0", "The Tier 2.1 Granted Column For CVS did not contain products", "The Tier 2.1 Granted Column For CVS contained products");
				Report.IsTrue(cvsRow[column22Index] != "0", "The Tier 2.2 Granted Column For CVS did not contain products", "The Tier 2.2 Granted Column For CVS contained products");
				Report.IsTrue(cvsRow[column3Index] != "0", "The Tier 3 Granted Column For CVS did not contain products", "The Tier 3 Granted Column For CVS contained products");
				Report.IsTrue(cvsRow[column41Index] != "0", "The Tier 4.2 Granted Column For CVS did not contain products", "The Tier 4.1 Granted Column For CVS contained products");



			}


		}

		[StepDefinition(@"I navigate to the CVS retailer Page then check that it contains the expected data tiers and that Products in Scope downloads a file, save it as: (.*) and check that is shows the expected product saved as: (.*)")]
		public void INavigateToTheCVSRetailerPageThenCheckThatItContainsExpectedTiersAndProductsInScopeAsExpected(string fileSavedAs, string productSavedAs)
		{
			ReportSettings.UseSubSteps = true;
			Report.StartStep("I navigate to the Data Consent Tiers Page for CVS");
			this.INavigateToTheDataConentTiersPageForCVS();
			Report.StartStep("I Check that The expected data tiers for CVS are the only ones present in the Data Consent Tiers Section");
			this.ICheckThatTheGivenDataTiersAreOnlyOnesPresent();
			Report.StartStep($"Products in Scope button and confirm that a file is produced called CV_Report_DataUsageTier_<Date>.xlsx and save as {fileSavedAs}");
			this.ThenClickTheProductsInScopeButtonAndCheckForFile("CV_Report_DataUsageTier_<Date>.xlsx", fileSavedAs);
			Report.StartStep($"I confirm that the excel file saved as: {fileSavedAs} contains the WPSID for the Product saved as: {productSavedAs}");
			this.IConfirmTheExcelFileSavedAsContainsProductSavedAs(fileSavedAs, productSavedAs);
			Report.StartStep($"I delete the Supplier Report file saved as {fileSavedAs}");
			new Steps_SupplierReports().DeleteExcelFile(fileSavedAs);
			Report.StartStep($"I navigate to the Homepage and then In the Products Grid I delete All products");
			new StepsProductGrid().INavigateToTheHomepageThenInTheProductsGridIDeleteAllProducts();

		}

		[StepDefinition(@"I confirm that the excel file saved as: (.*) includes the column: (.*) between: (.*) and (.*)")]
		public void ThenIConfirmThatTheExcelFileSavedAsIncludesheFollowingColumnsAndAreInTheCorrectOrder(string savedAs, string focusColumn, string column1, string column2)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));

				int y = 0;
				foreach (var item in ColumnTitles)
				{
					if (item == column1)
					{
						break;
					}
					y++;
				}

				Report.IsTrue(ColumnTitles[y + 1] == focusColumn && ColumnTitles[y + 2] == column2, "The Column was not found between the 2 specified columns", "The Column was found between the 2 specified columns");

			}
		}

		[StepDefinition(@"I confirm that the excel file saved as: (.*) includes the following columns:")]
		public void ThenIConfirmThatTheExcelFileSavedAsIncludesTheFollowingColumns(string savedAs, Table table)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
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


		[StepDefinition(@"I confirm that the excel file saved as: (.*) contains the WPSID saved as: (.*) and has: (.*) in the column: (.*)")]
		public void ThenIConfirmThatTheExcelFileSavedAsContainsUPCNumberAndYInColumns(string fileSavedAs, string wpsidSavedAs, string containsValue, string searchColumn)
		{
			string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + fileSavedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));

				int wpsIDColumnIndex = 0;
				for (int j = 0; j < ColumnTitles.Count; j++)
				{
					if (ColumnTitles[j] == "WPSID")
					{
						wpsIDColumnIndex = j;
					}
				}
				string wpsidStr = ((ProductInformation)Context.GetFromContext(wpsidSavedAs)).Id;
				List<string> wpsidItems = ExcelUtils.Excel_GetColumn(wpsIDColumnIndex);
				int wantedWpsidPosition = 0;
				bool foundWpsid = false;
				foreach (var wpsidItem in wpsidItems)
				{
					if (wpsidItem != wpsidStr)
					{
						wantedWpsidPosition++;
					}
					else
					{
						Report.Success($"The WPSID was found at position: {wantedWpsidPosition}");
						foundWpsid = true;
						break;
					}
				}
				if (!foundWpsid)
				{
					Report.Failure("Could not find the WPSID in the SpreadSheet");
					return;
				}

				int columnUPCIndex = 0;
				for (int i = 0; i < ColumnTitles.Count; i++)
				{
					if (ColumnTitles[i] == searchColumn)
					{
						columnUPCIndex = i;
					}
				}

				List<string> upcRowItems = ExcelUtils.Excel_GetColumn(columnUPCIndex);
				Report.Info($"Looking for {containsValue} for WPSID: {wpsidStr} in the Column: {searchColumn}");
				string actualValue = upcRowItems[wantedWpsidPosition];
				Report.Info($"actual value was: {actualValue}");
				Report.IsTrue(actualValue == containsValue, "The actual value was not: " + containsValue, "The actual value was: " + containsValue);

			}
		}

		[StepDefinition(@"I confirm that the excel file saved as: (.*) contains the following retailers:")]
		public bool ThenIConfirmThatTheExcelFileSavedAsContainsTheFollowingRetailers(string savedAs, Table table)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!string.IsNullOrEmpty(File), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<List<string>> ListOfRetailerNames = new List<List<string>>();

				for (int i = 1; i < table.RowCount + 1; i++)
				{
					List<string> RetailerName = ExcelUtils.Excel_GetRow(i);

					ListOfRetailerNames.Add(RetailerName);
				}

				var abbr = new RetailerAbbreviations();
				string selectedAbbr = "";

				foreach (TableRow thisRow in table.Rows)
				{

					string retailer = thisRow["Retailer"];
					bool isFound = false;

					abbr.Map.TryGetValue(retailer, out selectedAbbr);

					foreach (List<string> Retailer in ListOfRetailerNames)
					{

						if (Retailer[0] == selectedAbbr)
						{
							isFound = true;
						}
					}

					if (!isFound)
					{
						Report.Failure("The reatiler: " + retailer + " was not found");
						return isFound;
					}

				}

				Report.Info("All retailers were fonud");
				return true;
			}

			Report.Failure("Excel data was not found");
			return false;
		}


		[StepDefinition(@"I (should|should not) see radio option: (.*)")]
		public void ISeeRadioOption(string shouldOrShouldNot, string radioButtonText)
		{
			RetailPartners retailPartnersObject = new RetailPartners();
			Report.IsTrue(retailPartnersObject.FindRadioButton(shouldOrShouldNot, radioButtonText), "Failed to see/not see the radio button with the following text: " + radioButtonText, "Succes saw/not saw the radio button with the following text: " + radioButtonText);
		}

		[StepDefinition(@"I check if AIS is not uploaded")]
		public void ICheckIfAISIsNotUploaded()
		{
			RetailPartners retailPartnersObject = new RetailPartners();
			Report.IsTrue(retailPartnersObject.CheckIfAISIsUploaded(), "Failed to check if AIS is uploaded", "Successfully checked if AIS is uploaded");
		}

		[StepDefinition(@"I confirm the excel file saved as: (.*) (contains|does not contain) the following data: (.*)")]
		public bool ThenIConfirmTheExcelFileSavedAsProductsInScopeReportForBBBContainsTheFollowingDataCleaningSuppliesProductForBBB(string savedAs, string containsOrDoesNotContain, string data)
		{
			Report.Info("Confirm the excel file saved as " + savedAs + " can be opened and contains data");
			object File = Context.GetFromContext(savedAs);
			if (Report.IsTrue(File != null, "No matching file was found for name: " + savedAs + "!", "File was found: " + File.ToString()))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				Report.Info("Found: " + ExcelUtils.Excel_GetNoRows() + " rows in the spreadsheet");

				for (int i = 0; i < ExcelUtils.Excel_GetNoRows(); i++)
				{
					List<string> row = ExcelUtils.Excel_GetRow(i);
					Report.Info("Header row contained: '" + string.Join("', '", row) + "'");
					foreach (var str in row)
					{
						if (str == data && containsOrDoesNotContain == "contains")
						{
							Report.Success("Excel file contained the following data: " + data);
							return true;
						}
						if (str == data && containsOrDoesNotContain == "does not contain")
						{
							Report.Failure("Excel file contained the following data: " + data);
							return false;
						}
					}
				}

				if (containsOrDoesNotContain == "contains")
				{
					Report.Failure("Excel file did not contain the following data: " + data);
					return false;
				}

				if (containsOrDoesNotContain == "does not contain")
				{
					Report.Success("Excel file did not contain the following data: " + data);
					return true;
				}

			}

			return false;
		}


		[StepDefinition(@"For Retailer: (.*) If the supplier ID: (.*) is not found In the Supplier Table I add it with the first option in the Company or Brand Name field.")]
		public void ForRetailerCheckForSupplierIDAndAddIfNotFound(string retailer, string supplierID)
		{
			if (Report.IsTrue(new RetailPartnersDetails().GetSelectedRetailer().Trim() == retailer.Trim(), "Retailer: " + retailer + " was not showing!", "Retailer: " + retailer + " was showing as expected!"))
			{
				if (supplierID.Contains("x"))
				{
					switch (retailer)
					{
						case "O'Reilly":
							supplierID = supplierID.Replace("x", "1");
							break;
						case "Sears":
							supplierID = supplierID.Replace("x", "2");
							break;
						case "Wal-Mart":
							supplierID = supplierID.Replace("x", "3");
							break;
						default:
							throw new Exception("You need to specify O'Reilly, Sears or Wal-Mart");
					}
				}


				List<Supplier> allSuppliers = new RetailPartnersDetails().GetAllSuppliers();
				foreach (Supplier thisSupplier in allSuppliers)
				{

					if (thisSupplier.SupplierID == supplierID)
					{
						Report.Success($"The Supplier ID: {supplierID} was found to already be in the supplier ID table, no need to add it.");
						return;
					}

				}

				Report.Info($"The Supplier ID: {supplierID} was not found in the supplier ID table, beginning the steps to add it.");
				this.GivenIClickOnTheAddNewSupplierIDLink();
				new GlobalSteps().IWaitForModalPopupToBeVisible();
				string companyBrandSavedAs = "companybrand" + supplierID;
				this.GivenInTheAddNewSupplierDialogISelectTheFirstOptionInTheCompanyOrBrandNameInput(companyBrandSavedAs);
				this.GivenInTheAddNewSupplierDialogIEnterTheFollowingInTheSupplierIDInput(supplierID);
				this.GivenInTheAddNewSupplierDialogIClickSave();
				var supplierDetailsTable = new Table("Supplier ID", "Company or Brand Name");
				supplierDetailsTable.AddRow(supplierID, "saved as: " + companyBrandSavedAs);

				this.ThenIConfirmThatInTheSupplierIDSListTheFollowingRowExists(supplierDetailsTable);
			}
			return;


		}


	}





}

