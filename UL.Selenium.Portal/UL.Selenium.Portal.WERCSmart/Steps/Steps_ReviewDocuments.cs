using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.Core.Internal;
using iTextSharp.text;
using NTTQA_Automation_Classes.Classes;
using NTTQA_Reporting_Module;
using NTTQA_Reporting_Module.Reporting.Core;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "ReviewDocuments")]
	class Steps_ReviewDocuments
	{
		[Then(@"I should see Review Documents")]
		public void ThenIShouldSeeReviewDocuments()
		{
			Report.IsTrue(new ReviewDocuments().Wait_for_load(), "Review documents pages is not showing",
				"Review documents page is showing");
		}

		[Then(@"In the Documents section I should see the following columns: (.*)")]
		public void ThenInTheDocumentsSectionIShouldSeeTheFollowingColumns(string columns)
		{
			var newReviewDocs = new ReviewDocuments();
			List<string> actualColumns = newReviewDocs.GetColumnsFromDocumentsTable().Select(x => x.Trim()).ToList();
			List<string> expectedColumns = columns.Split(',').Select(x => x.Trim()).ToList();

			Report.IsTrue(actualColumns.SequenceEqual(expectedColumns),
				"Expected columns: " + string.Join(",", expectedColumns) + " actual columns: " +
				string.Join(",", actualColumns), "As expected, columns are: " + expectedColumns);
		}


		[Given(@"I click on the View link of the first document in Supplier Uploaded")]
		public void GivenIClickOnTheViewLinkOfTheFirstDocumentInSupplierUploaded()
		{
			var newReviewDocs = new ReviewDocuments();
			Report.IsTrue(newReviewDocs.ClickViewInFirstSupplierUploadedDoc(), "Failed to click view link", "Clicked view link");
		}

		[Then(@"a document should open")]
		public void ThenADocumentShouldOpen()
		{
			Report.Screenshot();
			List<string> OpenBrowsers = SeleniumBrowser.GetTabURLs();
			for (int i = 0; i < 30; i++)
			{
				OpenBrowsers = SeleniumBrowser.GetTabURLs();

				if (OpenBrowsers.Select(x => x.ToLower().Contains(GlobalParameters.TestUrl.ToLower()) && x.Contains("documentId"))
						.Count() > 0)
				{
					break;
				}

				Delay.Seconds(1);
			}
			OpenBrowsers = SeleniumBrowser.GetTabURLs();

			Report.IsTrue(OpenBrowsers.Select(x => x.ToLower().Contains(GlobalParameters.TestUrl.ToLower()) && x.Contains("documentId")).Count() > 0,
				"No document is found", "Document has been found as expected: " + OpenBrowsers.FirstOrDefault(x => x.Contains(GlobalParameters.TestUrl) && x.Contains("documentId")));

		}

		[Given(@"I close the document")]
		public void GivenICloseTheDocument()
		{
			List<string> OpenBrowsers = SeleniumBrowser.GetTabURLs();
			Report.Info("Open browsers: " + string.Join(",", OpenBrowsers));
			string url =
				OpenBrowsers.FirstOrDefault(x => x.ToLower().Contains(GlobalParameters.TestUrl.ToLower()) && x.Contains("documentId"));
			SeleniumBrowser.SwitchToTabWithURL(url);
			Report.Screenshot();
			Report.Info("Closing browser with url: " + url);
			Report.IsTrue(SeleniumBrowser.CloseTabWithURL(url), "Failed to close document", "Closed document");
		}


	}


}
