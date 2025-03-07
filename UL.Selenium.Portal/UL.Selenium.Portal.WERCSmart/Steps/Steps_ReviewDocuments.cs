using Reqnroll;
using System.Collections.Generic;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "ReviewDocuments")]
	class Steps_ReviewDocuments
	{
		[RegexStepDefinition(@"I should see Review Documents")]
		public void ThenIShouldSeeReviewDocuments()
		{
			Report.IsTrue(new ReviewDocuments().Wait_for_load(), "Review documents pages is not showing",
				"Review documents page is showing");
		}

		[RegexStepDefinition(@"In the Documents section I should see the following columns: (.*)")]
		public void ThenInTheDocumentsSectionIShouldSeeTheFollowingColumns(string columns)
		{
			var newReviewDocs = new ReviewDocuments();
			var actualColumns = newReviewDocs.GetColumnsFromDocumentsTable().Select(x => x.Trim()).ToList();
			var expectedColumns = columns.Split(',').Select(x => x.Trim()).ToList();

			Report.IsTrue(actualColumns.SequenceEqual(expectedColumns),
				"Expected columns: " + string.Join(",", expectedColumns) + " actual columns: " +
				string.Join(",", actualColumns), "As expected, columns are: " + expectedColumns);
		}


		[RegexStepDefinition(@"I click on the View link of the first document in Supplier Uploaded")]
		public void GivenIClickOnTheViewLinkOfTheFirstDocumentInSupplierUploaded()
		{
			var newReviewDocs = new ReviewDocuments();
			Report.IsTrue(newReviewDocs.ClickViewInFirstSupplierUploadedDoc(), "Failed to click view link", "Clicked view link");
		}

		[RegexStepDefinition(@"a document should open")]
		public void ThenADocumentShouldOpen()
		{
			Report.Screenshot();
			List<string> OpenBrowsers = SeleniumBrowser.GetTabURLs();
			for (int i = 0; i < 30; i++)
			{
				OpenBrowsers = SeleniumBrowser.GetTabURLs();

				if (OpenBrowsers.Select(x => x.ToLower().Contains(SeleniumBrowser.BaseTestUrl.ToLower()) && x.Contains("documentId"))
						.Count() > 0)
				{
					break;
				}

				Delay.Seconds(1);
			}
			OpenBrowsers = SeleniumBrowser.GetTabURLs();

			Report.IsTrue(OpenBrowsers.Select(x => x.ToLower().Contains(SeleniumBrowser.BaseTestUrl.ToLower()) && x.Contains("documentId")).Count() > 0,
				"No document is found", "Document has been found as expected: " + OpenBrowsers.FirstOrDefault(x => x.Contains(SeleniumBrowser.BaseTestUrl) && x.Contains("documentId")));

		}

		[RegexStepDefinition(@"I close the document")]
		public void GivenICloseTheDocument()
		{
			List<string> OpenBrowsers = SeleniumBrowser.GetTabURLs();
			Report.Info("Open browsers: " + string.Join(",", OpenBrowsers));
			string url =
				OpenBrowsers.FirstOrDefault(x => x.ToLower().Contains(SeleniumBrowser.BaseTestUrl.ToLower()) && x.Contains("documentId"));
			SeleniumBrowser.SwitchToTabWithURL(url);
			Report.Screenshot();
			Report.Info("Closing browser with url: " + url);
			Report.IsTrue(SeleniumBrowser.CloseTabWithURL(url), "Failed to close document", "Closed document");
		}


	}


}
