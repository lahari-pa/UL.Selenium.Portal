using System;
using System.IO;
using System.Linq;
using Castle.Core.Internal;
using NTTQA.Selenium.Classes;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "SupplierReports")]
	class Steps_SupplierReports
	{

		[Given(@"Under the Supplier Reports menu I choose: (.*)")]
		public void GivenUnderTheSupplierReportsMenuIChoose(string choice)
		{
			Report.IsTrue(new SupplierReports().SelectReport(choice), "Failed to choose: " + choice,
				"Successfully chose: " + choice);
		}

		[Then(@"In the Supplier Reports screen the current page should be: (.*)")]
		public void ThenInTheSupplierReportsScreenTheCurrentPageShouldBe(string title)
		{
			Report.IsTrue(new SupplierReports().GetCurrentTitle() == title, "Title is not showing as expected",
				"Showing title: " + title + " as expected.");
		}

		[Given(@"In the Supplier Reports screen I click on the Download button")]
		public void GivenInTheSupplierReportsScreenIClickOnTheDownloadButton()
		{
			Report.IsTrue(new SupplierReports().ClickDownload(), "Failed to click download button",
				"Successfully clicked download button.");
		}

		[Given(@"under the supplier Reports menu I should see the following options")]
		public void GivenUnderTheSupplierReportsMenuIShouldSeeTheFollowingOptions(Table table)
		{
			var SupplierReports = new SupplierReports().GetReportList();

			foreach (TableRow thisRow in table.Rows)
			{
				Report.IsTrue(SupplierReports.Contains(thisRow["Reports"]),
					thisRow["Reports"] + " is not showing as expected", thisRow["Reports"] + " is showing as expected");
			}
		}

		[Given(@"In the Kits that contain a specific product I search and select product: (.*)")]
		public void GivenInTheKitsThatContainASpecificProductISearchAndSelectProduct(string productCode)
		{
			Report.IsTrue(new SupplierReports().SelectKitThatContainsSpecificProduct(productCode),
				"Failed to select product: " + productCode, "Successfully selected product: " + productCode);
		}

		[Given(@"In the UPC Report for Specific Product with Retailer I search and select product: (.*)")]
		public void GivenInTheUPCReportForSpecificProductWithRetailerISearchAndSelectProduct(string productCode)
		{
			Report.IsTrue(new SupplierReports().SelectKitThatContainsSpecificProduct(productCode),
				"Failed to select product: " + productCode, "Successfully selected product: " + productCode);
		}

		[Given(@"In the Supplier Report page in the select Retailer dropdown I select: (.*)")]
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
				var count = 0;
				Report.Info("Confirm file is downloaded with name: " + file);
				string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
				while (count < 120)
				{
					var dir = Directory.GetFiles(downloadsFolder, "*" + file.Replace("<Date>", "*"), SearchOption.AllDirectories);
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
			var file = Context.GetFromContext(savedAs)?.ToString() ?? "";
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
			var displayed = new SupplierReports().GetCurrentSubText();
			Report.IsTrue(expected == displayed,
				"The report description text did not match the expected text. Expected: '" + expected + "'. But got: '" + displayed + "'.",
				"The report description text was displayed as expected.");
		}
	}
}
