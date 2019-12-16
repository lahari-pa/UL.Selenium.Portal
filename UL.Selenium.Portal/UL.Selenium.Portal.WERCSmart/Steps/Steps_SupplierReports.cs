using System;
using System.IO;
using System.Linq;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using NTTQA.Selenium.UniversalFunctions;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using System.Collections.Generic;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using NTTQA.Selenium.Cache;
using UL.Selenium.Portal.WERCSmart.Classes;

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
			var ExcelUtils = new ExcelUtilities(file.ToString(), "Table");
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
			var ExcelUtils = new ExcelUtilities(file.ToString(), "Table");
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
			var ExcelUtils = new ExcelUtilities(file.ToString(), "Table");
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
				var utils = new ExcelUtilities(File.ToString(), "Table");

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
				var utils = new ExcelUtilities(File.ToString(), "Table");
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
				var ExcelUtils = new ExcelUtilities(File.ToString(), "Table");
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
				if (foundUPC==false)
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
				if(casePackRowItems[y]!="Y")
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
				var ExcelUtils = new ExcelUtilities(File.ToString(), "Table");
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
					if (item ==failValue)
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
				var ExcelUtils = new ExcelUtilities(File.ToString(), "Table");
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
					if (item != wantedValue && item!=column)
					{
						Report.Failure($"The Value {wantedValue} was not found in the column {column} for the entry at postition: {y}");
						wantedValueFound = false;

					}
					y++;
				}
				Report.IsTrue(wantedValueFound, "The wanted value was not found in all rows of the search column", "The wanted value was the only value found in all rows of the search column");




			}
		}

	}
}




