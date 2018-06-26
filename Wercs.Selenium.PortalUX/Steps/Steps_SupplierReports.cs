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



	}
}
