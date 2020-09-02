using System;
using System.IO;
using System.Linq;
using UL.Automation.Selenium.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.Reporting.SpecFlow.Classes;
using UL.Automation.Utilities.Functions;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using System.Collections.Generic;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Classes;
using System.IO;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "SupplierReports")]
	class Steps_SupplierReports
	{

		[StepDefinition(@"Under the Supplier Reports menu I choose: (.*)")]
		public void GivenUnderTheSupplierReportsMenuIChoose(string choice)
		{
			Report.IsTrue(new SupplierReports().SelectReport(choice), "Failed to choose: " + choice,
				"Successfully chose: " + choice);
		}

		[StepDefinition(@"In the Supplier Reports screen the page title should be: (.*)")]
		public void InTheSupplierReportsScreenThePageTitleShouldBe(string title)
		{
			string actual = new SupplierReports().GetCurrentTitle();
			Report.IsTrue(actual == title, "Page title '" + title + "' is not showing as expected.",
				"Page title '" + title + "' is showing as expected.");
		}


		[StepDefinition(@"In the Supplier Reports screen the subheader should be: (.*)")]
		public void InTheSupplierReportsScreenTheSubheaderShouldBe(string subheading)
		{
			string actual = new SupplierReports().GetSubheadingText();
			Report.IsTrue(actual == subheading, "Page subheading'" + subheading + "' is not showing as expected.",
				"Page subheading '" + subheading + "' is showing as expected.");
		}

		[StepDefinition(@"In the Supplier Reports screen the current page should be: (.*)")]
		public void ThenInTheSupplierReportsScreenTheCurrentPageShouldBe(string expected)
		{
			string actual = new SupplierReports().GetCurrentTitle();
			Report.IsTrue(actual == expected, "Title is not showing as expected",
				"Showing subtitle: " + expected + " as expected.");
		}

		[StepDefinition(@"In the Supplier Reports screen the current sub-page should be: (.*)")]
		public void ThenInTheSupplierReportsScreenTheCurrentSubPageShouldBe(string subtitle)
		{
			Report.IsTrue(new SupplierReports().GetCurrentSubTitle() == subtitle, "Subtitle is not showing as expected",
				"Showing subtitle: " + subtitle + " as expected.");
		}

		[StepDefinition(@"In the Supplier Reports screen I click on the Download button")]
		public void GivenInTheSupplierReportsScreenIClickOnTheDownloadButton()
		{
			Report.IsTrue(new SupplierReports().ClickDownload(), "Failed to click download button",
				"Successfully clicked download button.");
		}

		[StepDefinition(@"under the supplier Reports menu I should see the following options")]
		public void GivenUnderTheSupplierReportsMenuIShouldSeeTheFollowingOptions(Table table)
		{
			List<string> SupplierReports = new SupplierReports().GetReportList();

			foreach (TableRow thisRow in table.Rows)
			{
				Report.IsTrue(SupplierReports.Contains(thisRow["Reports"]),
					thisRow["Reports"] + " is not showing as expected", thisRow["Reports"] + " is showing as expected");
			}
		}

		[StepDefinition(@"In the Kits that contain a specific product I search and select product: (.*)")]
		public void GivenInTheKitsThatContainASpecificProductISearchAndSelectProduct(string productCode)
		{
			if (productCode.ToLower().Contains("saved as"))
			{
				try
				{
					ProductGridItem item = (ProductGridItem)Context
						.GetFromContext(productCode.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase).Trim());
					productCode = item.ProductId;
				}
				catch (Exception e)
				{
					Report.Info("Failed to find saved item in context: " + productCode.Replace("saved as", "", StringComparison.InvariantCultureIgnoreCase) + e.Message);
					throw;
				}
			}
			Report.IsTrue(new SupplierReports().SelectSpecificProduct(productCode),
				"Failed to select product: " + productCode, "Successfully selected product: " + productCode);
		}

		[StepDefinition(@"In the UPC Report for Specific Product with Retailer I search and select product: (.*)")]
		public void GivenInTheUPCReportForSpecificProductWithRetailerISearchAndSelectProduct(string productCode)
		{
			Report.IsTrue(new SupplierReports().SelectSpecificProduct(productCode),
				"Failed to select product: " + productCode, "Successfully selected product: " + productCode);
		}

		[StepDefinition(@"I select a random product from the drop down")]
		public void InTheUPCReportISelectARandomProduct()
		{
			Report.IsTrue(new SupplierReports().SelectRandomProduct(), "Failed to select a random product",
				"Successfully selected a random product");
		}

		[StepDefinition(@"In the Supplier Report page in the select Retailer dropdown I select: (.*)")]
		public void GivenInTheSupplierReportPageInTheSelectRetailerDropdownISelect(string retailer)
		{
			Report.IsTrue(new SupplierReports().SelectRetailer(retailer),
				"Failed to select retailer: " + retailer, "Successfully selected retailer: " + retailer);
		}

		[StepDefinition(@"I confirm that a file is downloaded with file name: (.*) then close the Report Download popup. I save the file as (.*)")]
		public void ConfirmFileAppearsInDownloadsFolder(string file, string savedAs)
		{
			var selReportDownload = new ReportDownload();
			if (selReportDownload.Wait_for_load())
			{
				int count = 0;
				Report.Info("Confirm file is downloaded with name: " + file);
				string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
				while (count < 120)
				{
					string[] dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
					if (dir.Any())
					{
						Report.Success("File with name: " + dir.FirstOrDefault() + " was found in the download directory");
						Report.Info("Closing the Report Download popup");
						Report.IsTrue(selReportDownload.ClickClose(),
							"Failed to close the Report Download popup",
							"Successfully closed the Report Download popup");
						Context.AddToContext(savedAs, dir.FirstOrDefault());
						return;
					}
					Delay.Seconds(1);
					count++;
				}
				Report.Failure("Unable to find file: '" + file + "' in the download directory after 120 seconds");
				Report.Info("Closing the Report Download popup");
				Report.IsTrue(selReportDownload.ClickClose(),
					"Failed to close the Report Download popup",
					"Successfully closed the Report Download popup");
			}
		}

		[StepDefinition(@"I delete the Supplier Report file saved as (.*)")]
		public void DeleteExcelFile(string savedAs)
		{
			string file = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (file.IsNullOrEmpty())
			{
				Report.Failure("Could not find file saved as: " + savedAs);
				return;
			}
			Report.Info("Deleting file: " + file);
			File.Delete(file);
		}

		[StepDefinition(@"In the Supplier Report page I should see the report description should be showing with text: (.*)")]
		public void SupplierReportPageIShoudSeeDescription(string expected)
		{
			string displayed = new SupplierReports().GetCurrentSubText();
			Report.IsTrue(expected == displayed,
				"The report description text did not match the expected text. Expected: '" + expected + "'. But got: '" + displayed + "'.",
				"The report description text was displayed as expected.");
		}

		[StepDefinition(@"If the product is Private Label, I ensure that product saved as: (.*) shows as Private Label: (.*)")]
		public void IfProductIsPrivateLabelEnsureThatProductShowsAsPrivateLabel(string savedAs, string privateLabel)
		{
			var product = (ProductInformation)Context.GetFromContext(savedAs);
			string pl = Context.GetFromContext(privateLabel)?.ToString() ?? "";
			string id = product.Id;
			string name = product.Name;

			var selProdGrid = new ProductsGrid {
				ProductIdField = id
			};

			Report.IsTrue(selProdGrid.ConfirmIsPrivateLabel(pl), "Failed to match Private Label tag to product!", "Successfully match Private Label tag to product.");
		}

		[StepDefinition(@"I confirm that UPC: (.*) shows in the list of UPCs")]
		public void IConfirmThatTheUPCShowsInTheListOfUPCs(string savedAs)
		{
			string upc = Context.GetFromContext(savedAs)?.ToString() ?? "";
			List<ViewUpcs.ProductUpc> upcs = new ViewUpcs().Upcs();

			Report.IsTrue(upcs.FirstOrDefault(x => x.UpcNumber == upc) != null, "Failed to find UPC " + upc + " in list of UPCs.",
				"Successfully found UPC " + upc + " in list of UPCs.");
		}

		[StepDefinition(@"I confirm that the retailer listed for product saved as: (.*) appears as: (.*)")]
		public void IConfirmThatTheRetailerForProductAppearsAs(string savedAs, string retailer)
		{
			var product = (ProductInformation)Context.GetFromContext(savedAs);
			string ret = Context.GetFromContext(retailer)?.ToString() ?? "";
			string id = product.Id;
			string name = product.Name;

			var selProdGrid = new ProductsGrid {
				ProductIdField = id
			};

			ProductGridItem productElement = selProdGrid.FirstProductInGrid();
			List<string> retailers = productElement.Retailers;

			Report.IsTrue(retailers.FirstOrDefault(x => x == ret) != "", "Failed to find retailer " + ret + " in list of retailers.",
				"Successfully found retailer " + ret + " in list of retailers.");
		}

		[StepDefinition(@"I confirm that for product saved as: (.*) the value in the (.*) column of spreadsheet (.*) is: (.*)")]
		public void IConfirmThatForProductTheValueInTheColumnIs(string savedAs, string column, string spreadsheet, string value)
		{
			var product = (ProductInformation)Context.GetFromContext(savedAs);
			string file = Context.GetFromContext(spreadsheet)?.ToString() ?? "";
			if (file.IsNullOrEmpty())
			{
				Report.Failure("Could not find file saved as: " + spreadsheet);
				return;
			}
			var ExcelUtils = new ExcelFunctions(file.ToString(), "Table");
			int index = 1;
			while (index < ExcelUtils.Excel_GetColumn(0).Count)
			{
				if (ExcelUtils.GetCellValue(index, 0) == product.Id)
				{
					break;
				}
				index++;
			}
			string cellValue = ExcelUtils.GetCellValue(index, column);
			Report.IsTrue(cellValue.Trim() == value.Trim(), "Cell value does not match value " + value + " for column " + column + " and id " + product.Id + ". Instead found: " + cellValue.Trim(),
				"Cell value matches value " + value + " for column " + column + " and id " + product.Id + ".");
		}

		[StepDefinition(@"I confirm that for product saved as: (.*) the value in each of the columns of spreadsheet (.*) is as follows:")]
		public void IConfirmThatforProductSavedAsTheValueInEachOfTheColumnsIs(string savedAs, string spreadsheet, Table table)
		{
			var product = (ProductInformation)Context.GetFromContext(savedAs);
			string file = Context.GetFromContext(spreadsheet)?.ToString() ?? "";
			table.Rows[0]["UPC"] = Context.GetFromContext(table.Rows[0]["UPC"])?.ToString() ?? "";
			if (file.IsNullOrEmpty())
			{
				Report.Failure("Could not find file saved as: " + spreadsheet);
				return;
			}
			var ExcelUtils = new ExcelFunctions(file.ToString(), "Table");
			var headers = table.Header.ToList<string>();
			var values = table.Rows[0].Values.ToList<string>();
			int index = 1;
			while (index < ExcelUtils.Excel_GetColumn(0).Count)
			{
				if (ExcelUtils.GetCellValue(index, 0) == product.Id)
				{
					break;
				}
				index++;
			}
			for (int i = 0; i < table.Header.Count; i++)
			{
				string cellValue = ExcelUtils.GetCellValue(index, table.Header.ElementAt(i));
				Report.IsTrue(cellValue == values[i], "Failed to match cell value " + cellValue + " to table value " + values.ElementAt(i) + ".",
					"Successfully match cell value " + cellValue + ".");
			}
		}

		[StepDefinition(@"I confirm that for product saved as: (.*) the UPC in the (.*) column of spreadsheet (.*) is: (.*)")]
		public void IConfirmThatForProductTheUPCInTheColumnIs(string savedAs, string column, string spreadsheet, string upc)
		{
			var product = (ProductInformation)Context.GetFromContext(savedAs);
			string file = Context.GetFromContext(spreadsheet)?.ToString() ?? "";
			upc = Context.GetFromContext(upc)?.ToString() ?? "";
			if (file.IsNullOrEmpty())
			{
				Report.Failure("Could not find file saved as: " + spreadsheet);
				return;
			}
			var ExcelUtils = new ExcelFunctions(file.ToString(), "Table");
			int index = 1;
			while (index < ExcelUtils.Excel_GetColumn(0).Count)
			{
				if (ExcelUtils.GetCellValue(index, 0) == product.Id)
				{
					break;
				}
				index++;
			}
			string cellValue = ExcelUtils.GetCellValue(index, column);
			Report.IsTrue(cellValue.Trim() == upc.Trim(), "Cell value does not match UPC " + upc + " for column " + column + " and id " + product.Id + ".",
				"Cell value matches UPC " + upc + " for column " + column + " and id " + product.Id + ".");

		}
		[StepDefinition(@"I Check that the Description text on the supplier report page matches: (.*)")]
		public void ICheckThatTheDescriptionTextOnTheSupplierReportsPageIsCorrect(string expectedText)
		{
			Report.IsTrue(new SupplierReports().DescriptionTextMatches(expectedText), "The expected text did not match the actual text", "The expected text did match the actual text");
		}


		[StepDefinition(@"I Check that in the excel file saved as: (.*) the Eligible for deletion Dates are exactly 1 year from the Last Submission dates.")]
		public void ICheckThatInTheExcelFileSavedAsTheEligibleForDeletionDates(string savedAs)
		{

			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!File.IsNullOrEmpty(), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var utils = new ExcelFunctions(File.ToString(), "Table");

				var rows = utils.Excel_GetNoRows();
				for (int i = 1; i < rows; i++)
				{
					var rowContents = utils.GetRowContents(i);
					var productID = rowContents[0];
					var deletionDate = rowContents[3];
					DateTime lastSubDate;
					DateTime.TryParse(deletionDate, out lastSubDate);
					DateTime expectedEligibleDate = lastSubDate.AddYears(1);
					Report.Info($"The expected eligible for deletion date is {expectedEligibleDate}");

					var eligibleDate = rowContents[2];
					DateTime actualEligibleDate;
					DateTime.TryParse(eligibleDate, out actualEligibleDate);
					Report.Info($"The acutal eligible for deletion date is {actualEligibleDate}");

					Report.IsTrue(actualEligibleDate == expectedEligibleDate, "The Eligible for deletion date was not exactly one year from the last submission date for Item:" + i + " with productd ID:" + productID, "The Eligible for deletion date was exactly one year from the last submission date for Item:" + i + " with productd ID:" + productID);

				}

				////Needs fixing, currently this does not extract the dates as they are not strings in file.
				//List<string> lastSubmissions = utils.Excel_GetColumn(2);
				//List<string> eligibleForDeletions = utils.Excel_GetColumn(2);
				//for (int i = 1; i < lastSubmissions.Count; i++)
				//{
				//	DateTime lastSubDate;
				//	DateTime.TryParse(lastSubmissions[i], out lastSubDate);
				//	DateTime expectedEligibleDate = lastSubDate.AddYears(1);
				//	Report.Info($"The expected eligible for deletion date is {expectedEligibleDate}");

				//	DateTime actualEligibleDate;
				//	DateTime.TryParse(eligibleForDeletions[i], out actualEligibleDate);
				//	Report.Info($"The acutal eligible for deletion date is {actualEligibleDate}");

				//	Report.IsTrue(actualEligibleDate == expectedEligibleDate, "The Eligible for deletion date was not exactly one year from the last submission date for Item:" + i, "The Eligible for deletion date was exactly one year from the last submission date for Item:" + i);

				//}
				//return;


			}


		}

		[StepDefinition(@"in UPC Error Details WPSID box I enter product ID for the UPC Error Details report")]
		public void ThenInUPCErrorDetailsWPSIDBoxIEnterProductID()
		{
			string wpsid = TestVariables.GetVariableSavedAs("UPC Error Product ID");
			Report.IsTrue(new SupplierReports().EnterWPSID(wpsid), "Unable to enter WPSID " + wpsid, "Successfully entered WPSID " + wpsid);
		}


		[StepDefinition(@"I get a value for WERCSmart ID from the excel file saved as: (.*) and save it to context as: (.*)")]
		public void IGetAValueForWERCSmartIDFromExcelFileAndSaveItAs(string fileSavedAs, string iDSavedAs)
		{
			string File = Context.GetFromContext(fileSavedAs)?.ToString() ?? "";
			if (Report.IsTrue(!File.IsNullOrEmpty(), "No matching file was found for name: " + fileSavedAs + "!", "File was found: " + File))
			{
				var utils = new ExcelFunctions(File.ToString(), "Table");
				var rows = utils.Excel_GetNoRows();
				for (int i = 1; i < rows; i++)
				{
					var rowContents = utils.GetRowContents(i);
					var productID = rowContents[0];
					if (productID.Any())
					{
						Context.AddToContext(iDSavedAs, productID);

						var productInfo = new ProductInformation { Id = productID };
						Context.AddToContext(iDSavedAs, productInfo);


						Report.Success($"Found a WERCSmart ID: {productID} and saving it to context as: {iDSavedAs}");
						return;
					}
				}
			}
			Report.Failure($"Could not find any WERCSmart IDs in the spreadsheet saved as: {fileSavedAs}");
		}

		[Then(@"I confirm that in the excel file saved as: (.*) for the UPC saved as: (.*) there is a 'Y' in the Case Pack column and an Individual UPC listed as: (.*)")]
		public void IConfirmThatForTheExcelFileSavedAsThereIsAYinCasePackColumnAndIndvUPC(string savedAs, string casePackUPCSavedAs, string indvUPCSavedAs)
		{
			object File = Context.GetFromContext(savedAs);
			string casePackUPC = (string)Context.GetFromContext(casePackUPCSavedAs);
			string indvUPC = (string)Context.GetFromContext(indvUPCSavedAs);
			bool AllPassed = true;
			if (Report.IsTrue(File != null, "No matching file was found for name: " + savedAs + "!", "File was found: " + File.ToString()))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				//get the index of column
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));
				int columnUPCIndex = 0;
				for (int i = 0; i < ColumnTitles.Count; i++)
				{
					if (ColumnTitles[i] == "UPC")
					{
						columnUPCIndex = i;
					}
				}

				List<string> upcRowItems = ExcelUtils.Excel_GetColumn(columnUPCIndex);
				int y = 0;
				bool foundUPC = false;
				Report.Info($"Looking for Case Pack UPC: {casePackUPC} in the spreadsheet");

				foreach (string thisItem in upcRowItems)
				{
					Report.Info($"Checking Row: {y + 1}");
					if (thisItem == casePackUPC)
					{
						Report.Success("Found the CasePack UPC in the spreadsheet");
						foundUPC = true;
						break;
						//should exit from the foreach here
					}
					Report.Info($"Row did not contain the Case pack upc");
					y++;
				}
				if (foundUPC == false)
				{
					Report.Failure("Unable to find the CasePack UPC in the SpreadSheet");
					return;
				}

				int columnCasePackIndex = 0;
				for (int i = 0; i < ColumnTitles.Count; i++)
				{
					if (ColumnTitles[i] == "Case Pack")
					{
						columnCasePackIndex = i;
					}
				}
				List<string> casePackRowItems = ExcelUtils.Excel_GetColumn(columnCasePackIndex);
				if (casePackRowItems[y] != "Y")
				{
					Report.Failure($"The Case pack column for Case pack UPC: {casePackUPC} did not contain a 'Y'");
					return;
				}
				Report.Success($"The Case pack column for Case pack UPC: {casePackUPC} did contain a 'Y'");

				int columnCasePackInvUPCIndex = 0;
				for (int i = 0; i < ColumnTitles.Count; i++)
				{
					if (ColumnTitles[i] == "Case Pack Individual UPC")
					{
						columnCasePackInvUPCIndex = i;
					}
				}
				List<string> casePackInvUPCRowItems = ExcelUtils.Excel_GetColumn(columnCasePackInvUPCIndex);
				Report.Info($"The Individual Case Pack field contains: {casePackInvUPCRowItems[y]}");
				if (casePackInvUPCRowItems[y] != indvUPC)
				{
					Report.Failure($"The Case pack Indiviudal UPC column for Case pack UPC: {casePackUPC} did not contain the UPC: {indvUPC}");
					return;
				}
				Report.Success($"The Case pack Indiviudal UPC column for Case pack UPC: {casePackUPC} did contain the UPC: {indvUPC}");


			}



		}

		[StepDefinition(@"For the excel file saved as: (.*) I check that the column with heading name: (.*) does not contains: (.*) in any rows.")]
		public void ThenIConfirmThatForTheExcelFileSavedAsTheColumnDoesNotContain(string savedAs, string column, string failValue)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!File.IsNullOrEmpty(), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));

				int wantedColumnIndex = 0;
				bool wantedColumnFound = false;
				for (int i = 0; i < ColumnTitles.Count; i++)
				{
					if (ColumnTitles[i] == column)
					{
						wantedColumnIndex = i;
						wantedColumnFound = true;
						break;
					}
				}
				if (!wantedColumnFound)
				{
					Report.Failure($"The column: {column} could not be found in the spreadsheet");
					return;
				}
				List<string> wantedColumnContents = ExcelUtils.Excel_GetColumn(wantedColumnIndex);
				bool failValueNotFound = true;
				int y = 0;
				foreach (var item in wantedColumnContents)
				{
					if (item == failValue)
					{
						Report.Failure($"The Value {failValue} was found in the column {column} for the entry at postition: {y}");
						failValueNotFound = false;

					}
					y++;
				}
				Report.IsTrue(failValueNotFound, "The unwanted value was found in the search column", "The unwanted value was not found in the search column");




			}
		}


		[StepDefinition(@"For the excel file saved as: (.*) I check that the column with heading name: (.*) only contains: (.*) in all rows.")]
		public void ThenIConfirmThatForTheExcelFileSavedAsTheColumnOnlyContains(string savedAs, string column, string wantedValue)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!File.IsNullOrEmpty(), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));

				int wantedColumnIndex = 0;
				bool wantedColumnFound = false;
				for (int i = 0; i < ColumnTitles.Count; i++)
				{
					if (ColumnTitles[i] == column)
					{
						wantedColumnIndex = i;
						wantedColumnFound = true;
						break;
					}
				}
				if (!wantedColumnFound)
				{
					Report.Failure($"The column: {column} could not be found in the spreadsheet");
					return;
				}
				List<string> wantedColumnContents = ExcelUtils.Excel_GetColumn(wantedColumnIndex);
				bool wantedValueFound = true;
				int y = 0;
				foreach (var item in wantedColumnContents)
				{
					if (item != wantedValue && item != column)
					{
						Report.Failure($"The Value {wantedValue} was not found in the column {column} for the entry at postition: {y}");
						wantedValueFound = false;

					}
					y++;
				}
				Report.IsTrue(wantedValueFound, "The wanted value was not found in all rows of the search column", "The wanted value was the only value found in all rows of the search column");




			}
		}

		[StepDefinition(@"For the excel file saved as: (.*) I check that the column with heading name: (.*) does not contain: (.*) in at least 1 row.")]
		public void ThenIConfirmThatForTheExcelFileSavedAsTheColumnDoesNotContainForAtLeastOneRow(string savedAs, string column, string failValue)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!File.IsNullOrEmpty(), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));

				int wantedColumnIndex = 0;
				bool wantedColumnFound = false;
				for (int i = 0; i < ColumnTitles.Count; i++)
				{
					if (ColumnTitles[i] == column)
					{
						wantedColumnIndex = i;
						wantedColumnFound = true;
						break;
					}
				}
				if (!wantedColumnFound)
				{
					Report.Failure($"The column: {column} could not be found in the spreadsheet");
					return;
				}
				List<string> wantedColumnContents = ExcelUtils.Excel_GetColumn(wantedColumnIndex);
				bool failValueNotFound = false;
				int y = 0;
				foreach (var item in wantedColumnContents)
				{
					if (item != failValue && item != column)
					{
						Report.Info($"The Value {failValue} was not found in the column {column} for the entry at postition: {y}");
						failValueNotFound = true;

					}
					if (item == failValue && item != column)
					{
						Report.Info($"The Value {failValue} was found in the column {column} for the entry at postition: {y}");
					}
					y++;
				}
				Report.IsTrue(failValueNotFound, "The fail value was found in all rows of the search column", "The fail value was not found in at least one row of the serch column");



			}
		}

		[StepDefinition(@"For the excel file saved as: (.*) I check that the column with heading name: (.*) contains data in all rows.")]
		public void ThenIConfirmThatForTheExcelFileSavedAsTheColumnContainsDataInAllRows(string savedAs, string column)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!File.IsNullOrEmpty(), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));

				int wantedColumnIndex = 0;
				bool wantedColumnFound = false;
				for (int i = 0; i < ColumnTitles.Count; i++)
				{
					if (ColumnTitles[i] == column)
					{
						wantedColumnIndex = i;
						wantedColumnFound = true;
						break;
					}
				}
				if (!wantedColumnFound)
				{
					Report.Failure($"The column: {column} could not be found in the spreadsheet");
					return;
				}
				List<string> wantedColumnContents = ExcelUtils.Excel_GetColumn(wantedColumnIndex);
				bool wantedValueFound = true;
				int y = 0;
				foreach (var item in wantedColumnContents)
				{
					if (item.IsNullOrEmpty() && item != column)
					{
						Report.Failure($"The Value found in the column was empty for the entry at postition: {y}");
						wantedValueFound = false;

					}
					y++;
				}
				Report.IsTrue(wantedValueFound, "Not all rows contained data for the search column", "All rows contained data for the search column");


			}
		}




		[StepDefinition(@"For the excel file saved as: (.*) I check that the column with heading name: (.*) contains dates in all rows.")]
		public void ThenIConfirmThatForTheExcelFileSavedAsTheColumnContainsDatesInAllRows(string savedAs, string column)
		{
			string File = Context.GetFromContext(savedAs)?.ToString() ?? "";
			if (Report.IsTrue(!File.IsNullOrEmpty(), "No matching file was found for name: " + savedAs + "!", "File was found: " + File))
			{
				var ExcelUtils = new ExcelFunctions(File.ToString(), "Table");
				List<string> ColumnTitles = ExcelUtils.Excel_GetRow(0);
				Report.Info("Column titles: " + string.Join(",", ColumnTitles));

				int wantedColumnIndex = 0;
				bool wantedColumnFound = false;
				for (int i = 0; i < ColumnTitles.Count; i++)
				{
					if (ColumnTitles[i] == column)
					{
						wantedColumnIndex = i;
						wantedColumnFound = true;
						break;
					}
				}
				if (!wantedColumnFound)
				{
					Report.Failure($"The column: {column} could not be found in the spreadsheet");
					return;
				}
				var rows = ExcelUtils.Excel_GetNoRows();
				for (int i = 1; i < rows; i++)
				{
					var currentRow = ExcelUtils.Excel_GetRow(i);

					var currentCell = currentRow[wantedColumnIndex];
					try
					{
						DateTime dt = DateTime.Parse(currentCell);
						Report.Success($"The value found in the row: {i} was a date as expected");
					}
					catch
					{
						Report.Failure($"The value found in the row: {i} was not a");
					}

				}
			}
		}

		/// <summary>
		/// If the values of a given column are in datetime format, you must add the suffix <date> to the header title in the table
		/// </summary>
		/// <param name="savedAs"></param>
		/// <param name="table"></param>
		[StepDefinition(@"For the excel file saved as: (.*) I check that the columns with heading names found in the Table: contain data in all rows.")]
		public void ThenIConfirmThatForTheExcelFileSavedAsTheColumnsInTableContainDataInAllRows(string savedAs, Table table)
		{
			List<string> headers = new List<string>();
			foreach (TableRow thisRow in table.Rows)
			{
				headers.Add(thisRow["Headers"]);
			}
			Report.Info($"The column that we are checking in are as follows: {string.Join(",", headers)}");
			foreach (var row in headers)
			{
				if (row.Contains("<date>"))
				{
					string updatedHeader = row.Replace("<date>", "");
					updatedHeader = updatedHeader.Trim();
					this.ThenIConfirmThatForTheExcelFileSavedAsTheColumnContainsDatesInAllRows(savedAs, updatedHeader);
				}
				else
				{
					this.ThenIConfirmThatForTheExcelFileSavedAsTheColumnContainsDataInAllRows(savedAs, row);
				}

			}
		}

		[StepDefinition(@"I confirm that the latest report in the Report history table has the name: (.*)")]
		public void IConfirmLatestReportInHistoryTableHasName(string reportName)
		{
			//We are assuming that the report we just ran will still be the latest report, if another test is running at same time this may cause some issues.

			Report.IsTrue(new SupplierReports().ReportHistoryTablePresent(), "The Report History Table was not present", "The Report History Table was present");
			var foundName = new SupplierReports().ReportHistroryLatestReportName();
			Report.Info($"The Found report at the top of the report history table was: {foundName}");
			Report.IsTrue(foundName == reportName, "The found report name did not match the expected", "The found report name matched the expected");
		}

		[StepDefinition(@"I confirm that the latest report in the Report history table has the File Type: (.*)")]
		public void IConfirmLatestReportInHistoryTableHasFileType(string reportName)
		{
			//We are assuming that the report we just ran will still be the latest report, if another test is running at same time this may cause some issues.

			Report.IsTrue(new SupplierReports().ReportHistoryTablePresent(), "The Report History Table was not present", "The Report History Table was present");
			var foundName = new SupplierReports().ReportHistroryLatestReportFileType();
			Report.Info($"The Found report at the top of the report history table was: {foundName}");
			Report.IsTrue(foundName == reportName, "The found report File Type did not match the expected", "The found report File Type matched the expected");
		}


		[StepDefinition(@"I confirm that the latest report in the Report history table matches the following data:")]
		public void IConfirmLatestReportInHistoryTableHasFileType(Table table)
		{
			//We are assuming that the report we just ran will still be the latest report, if another test is running at same time this may cause some issues.


			//need to remove spaces in column titles -> check this is working

			Delay.Seconds(60);

			Report.IsTrue(new SupplierReports().ReportHistoryTablePresent(), "The Report History Table was not present", "The Report History Table was present");
			Report.IsTrue(new SupplierReports().ReportHistoryTableRowsPresent(), "The Report History Table did not contain rows", "The Report History Table did contain rows");

			Report.IsTrue(new SupplierReports().ReportHistroryTableFilterByColumn("DateRequested", "descending"), "The column was not set to the correct filter direction", "The column was set to the correct filter direction");

			Report.IsTrue(new SupplierReports().ReportHistoryTablePresent(), "The Report History Table was not present", "The Report History Table was present");
			Report.IsTrue(new SupplierReports().ReportHistoryTableRowsPresent(), "The Report History Table did not contain rows", "The Report History Table did contain rows");


			foreach (TableRow thisRow in table.Rows)
			{
				string columnTitle = thisRow["Column"];
				columnTitle = columnTitle.Replace(" ", "");
				string expectedValue = thisRow["Value"];
				if (expectedValue == "<TodaysDate>")
				{
					//This may need updating if day is 01 etc (M/dd/yyyy)					
					string datePart = DateTime.Now.ToString("M/d/yyyy");
					var columnValue = new SupplierReports().ReportHistroryLatestReportFileColumnData(columnTitle);
					Report.Info($"The found Date Requested was: {columnValue}");

					var columnValueSecondHalf = columnValue.Remove(0, columnValue.IndexOf(' ') + 1);
					var columnValueFirstHalf = columnValue.Replace(columnValueSecondHalf, "").Trim();
					Report.IsTrue(columnValueFirstHalf == datePart, "The first half of the Date Requested was not a match", "The first half of the Date Requested was a match");

					//TimeSpan convertedValue;
					bool isTimeFormat = false;

					var dateFormats = "h:mm:ss tt";



					if (GeneralUtilities.IsValidDate(columnValueSecondHalf, dateFormats))
					{
						isTimeFormat = true;
					}
					else
					{
						isTimeFormat = false;
					}
					Report.IsTrue(isTimeFormat, "The second half of the Date Requested was not a time stamp", "The second half of the Date Requested was a time stamp");



				}
				else
				{
					if (expectedValue == "<CurrentUser>")
					{
						expectedValue = new TopMenuBar().GetCurrentUserText();
					}

					columnTitle = columnTitle.Replace(" ", "");
					var foundValue = new SupplierReports().ReportHistroryLatestReportFileColumnData(columnTitle);
					Report.IsTrue(foundValue == expectedValue, "The found report value for column: " + columnTitle + " did not match the expected", "The found report value for column: " + columnTitle + " did match the expected");
				}


			}

		}

		[StepDefinition(@"I confirm that the latest report in the Report history table has a: (.*) button in the Actions Column")]
		public void IConfirmLatestReportInHistoryTableHasGivenButtonForLatest(string buttonName)
		{
			//We are assuming that the report we just ran will still be the latest report, if another test is running at same time this may cause some issues.

			Delay.Seconds(10);

			Report.IsTrue(new SupplierReports().ReportHistoryTablePresent(), "The Report History Table was not present", "The Report History Table was present");
			Report.IsTrue(new SupplierReports().ReportHistoryTableRowsPresent(), "The Report History Table did not contain rows", "The Report History Table did contain rows");

			Report.IsTrue(new SupplierReports().ReportHistroryTableFilterByColumn("DateRequested", "descending"), "The column was not set to the correct filter direction", "The column was set to the correct filter direction");

			Report.IsTrue(new SupplierReports().ReportHistoryTablePresent(), "The Report History Table was not present", "The Report History Table was present");
			Report.IsTrue(new SupplierReports().ReportHistoryTableRowsPresent(), "The Report History Table did not contain rows", "The Report History Table did contain rows");

			var foundValue = new SupplierReports().ReportHistroryLatestReportFileActionsColumnContainsButton(buttonName);
			Report.IsTrue(foundValue, "The "+buttonName+" button was not found in the actions column for the latest report", "The " + buttonName + " button was found in the actions column for the latest report");
		}

		[StepDefinition(@"I click the: (.*) button for the latest report in the Report history table")]
		public void IClickGivebnButtonForLatestReportInTable(string buttonName)
		{
			//We are assuming that the report we just ran will still be the latest report, if another test is running at same time this may cause some issues.

			Delay.Seconds(10);

			Report.IsTrue(new SupplierReports().ReportHistoryTablePresent(), "The Report History Table was not present", "The Report History Table was present");
			Report.IsTrue(new SupplierReports().ReportHistoryTableRowsPresent(), "The Report History Table did not contain rows", "The Report History Table did contain rows");

			Report.IsTrue(new SupplierReports().ReportHistroryTableFilterByColumn("DateRequested", "descending"), "The column was not set to the correct filter direction", "The column was set to the correct filter direction");

			Report.IsTrue(new SupplierReports().ReportHistoryTablePresent(), "The Report History Table was not present", "The Report History Table was present");
			Report.IsTrue(new SupplierReports().ReportHistoryTableRowsPresent(), "The Report History Table did not contain rows", "The Report History Table did contain rows");

			var clickedButton = new SupplierReports().ReportHistroryLatestReportFileActionsColumnClickButton(buttonName);
			Report.IsTrue(clickedButton, "The " + buttonName + " button was not clicked in the actions column for the latest report", "The " + buttonName + " button was clicked in the actions column for the latest report");
		}

		[StepDefinition(@"In the Supplier Reports screen the current page description should be: (.*)")]
		public void ThenInTheSupplierReportsScreenTheCurrentPageDescriptionShouldBe(string expectedDesc)
		{
			Report.IsTrue(new SupplierReports().GetCurrentDescriptionText() == expectedDesc, "Description is not showing as expected",
				"Showing Description: " + expectedDesc + " as expected.");
		}

		[StepDefinition(@"I select (Excel|CSV) from the Select File Type")]
		public void ThenISelectCSVFromTheSelectFileType(string excelOrCSV)
		{
			SupplierReports supplierReportsObject = new SupplierReports();
			Report.IsTrue(supplierReportsObject.SelectFromSelectFileType(excelOrCSV), "Failed to select " + excelOrCSV, "Successfully selected " + excelOrCSV);
		}


		[StepDefinition(@"I select the Zip Report Checkbox")]
		public void GivenISelectTheZipReportCheckbox()
		{
			SupplierReports supplierReportsObject = new SupplierReports();
			Report.IsTrue(supplierReportsObject.SelectZipReportCheckbox(), "Failed to select Zip Report Checkbox", "Successfully selected Zip Report Checkbox");
		}

		[StepDefinition(@"I select the Request Report button (excel|csv) file is produced called (.*) and save as (.*)")]
		public void ThenISelectTheRequestReportButton(string filetype, string file, string savedAs)
		{
			SupplierReports supplierReportsObject = new SupplierReports();
			Report.IsTrue(supplierReportsObject.SelectRequestReportButton(), "Failed to select Request Report button", "Successfully selected Request Report button");
			string currentTime = DateTime.Now.ToString();
			int index = currentTime.LastIndexOf(":") + 2;
			if (index > 0)
			{
				currentTime = currentTime.Substring(0, index);
			}
			Context.AddToContext("LastReportDownloadTime", currentTime);
			Delay.Seconds(10);

		}
	
		[StepDefinition(@"I click Close in the Report Download popup")]
		public void ThenIClickCloseInTheReportDownloadPopup()
		{
			SupplierReports supplierReportsObject = new SupplierReports();
			Report.IsTrue(supplierReportsObject.SelectCloseButtonInReportDownloadPopup(), "Failed to select Close button", "Successfully selected Close button");
		}

		[StepDefinition(@"I click the Download button for the most recent report")]
		public void ThenIClickTheDownloadButtonForTheMostRecentReport()
		{
			SupplierReports supplierReportsObject = new SupplierReports();
			Report.IsTrue(supplierReportsObject.SelectDownloadButtonForTheMostRecentReport(), "Failed to select Download button", "Successfully selected Download button");
			Delay.Seconds(10);
		}

		[StepDefinition(@"I confirm the most recent file has the following information Report Name: (.*) File Type: (CSV|XLSX|CSV \(Zip\)) Date Requested: (.*) Requested By: (.*)")]
		public void ThenIConfirmTheMostRecentFileHasTheFollowingInformationReportNameWasteClassificationSummaryFileTypeCSVDataRequestedRequestedByWERCSTest_Automation_ProductsAccount(string reportName, string type, string dateRequested, string requestedBy)
		{
			SupplierReports supplierReportsObject = new SupplierReports();
			Report.IsTrue(supplierReportsObject.CheckReportDataForMostRecentFile(reportName, type, dateRequested, requestedBy), "Failed to match all data for the most recent file", "Successfully matched all data for the most recent file");
		}

		[StepDefinition(@"I see a Report Download popup with the following text: (.*)")]
		public void GivenISeeAReportDownloadPopupWithTheFollowingText(string text)
		{
			SupplierReports supplierReportsObject = new SupplierReports();
			Report.IsTrue(supplierReportsObject.FindReportDownloadPopupWithTheFollowingText(text), "Failed to find the correct text in the popup", "Successfully founded the correct text in the popup");
		}

	}
}




