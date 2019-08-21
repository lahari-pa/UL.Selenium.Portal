using System;
using System.IO;
using System.Linq;
using Castle.Core.Internal;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using NTTQA.Selenium.UniversalFunctions;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using System.Collections.Generic;

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

		[StepDefinition(@"If an html file is downloaded called (.*) I create a new product with UPCs and redownload the (.*) report")]
		public void IfHTMLIsDownloadedCreateAProduct(string file, string report)
		{
			var productSetup = new Steps_ProductSetup();
			var globalSteps = new GlobalSteps();
			var homepage = new StepsHomepage();

			string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
			Report.Info("Downloads folder: " + downloadsFolder);

			string[] dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);

			int i = 0;
			Report.Info("Waiting for up to 30 seconds for the file to appear in the downloads folder...");
			while (!dir.Any() && i < 30)
			{
				dir = Directory.GetFiles(downloadsFolder, file, SearchOption.AllDirectories);
				Delay.Seconds(Delay.SpeedFactor * 1);
				i++;
			}

			if (dir.Any())
			{
				Report.Info("Found html file. Creating new product.");
				productSetup.CreateProductUsingTestCase75335("TestCase75335", "UPC75335", "Chalk");

				globalSteps.NavigateToLandingPage();
				globalSteps.LoginToWERCSmartAdmin("WERCs Product Account");
				homepage.ClickItemInQuickLinks("Supplier Reports");
				this.InTheSupplierReportsScreenThePageTitleShouldBe("Available Reports");
				this.GivenUnderTheSupplierReportsMenuIChoose(report);
				this.ThenInTheSupplierReportsScreenTheCurrentSubPageShouldBe(report);
				this.GivenInTheSupplierReportsScreenIClickOnTheDownloadButton();
			}
			else
			{
				Report.Info("Failed to find html file. Continuing with xlsx file.");
			}

		}
	}
}
