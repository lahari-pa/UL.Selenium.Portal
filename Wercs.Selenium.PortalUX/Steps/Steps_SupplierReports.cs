using System;
using System;
using System.Collections.Generic;
using System.Linq;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TestStack.White.UIItems.WindowItems;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
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
			Report.IsTrue(new SupplierReports().GetCurrentTitle()==title, "Title is not showing as expected",
				"Showing title: " + title + " as expected.");
		}

		[Given(@"In the Supplier Reports screen I click on the Download button")]
		public void GivenInTheSupplierReportsScreenIClickOnTheDownloadButton()
		{
			Report.IsTrue(new SupplierReports().ClickDownload() , "Failed to click download button",
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


	}
}
