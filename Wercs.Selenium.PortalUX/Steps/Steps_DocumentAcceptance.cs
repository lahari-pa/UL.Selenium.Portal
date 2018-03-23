using System;
using ResourcePool;
using SafewareReporting;
using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "DocumentAcceptance")]
	class StepsDocumentAcceptance
	{
		/// <summary>
		/// This is to verify the title of the page
		/// </summary>
		/// <param name="headerExpected"></param>
		[StepDefinition(@"I should see the header: (.*) on the Document Acceptance window")]
		public void CorrectDAHeaderShowing(string headerExpected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Document Acceptance window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Document Acceptance window appears");
				var selDocumentAcceptance = new DocumentAcceptance();
				var showing = selDocumentAcceptance.HeaderShowing();
				Report.IsTrue(showing == headerExpected.Trim(),
					"Document Acceptance header was not as expected! Expected: '" + headerExpected + "', but found: '" + showing + "' instead!",
					"Document Acceptance header was showing '" + headerExpected + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// This is to verify sub header 3 which is My Products
		/// </summary>
		/// <param name="subheaderExpected"></param>
		[StepDefinition(@"I should see the subheading 3: (.*) on the Document Acceptance window")]
		public void CorrectSubHeader3Showing(string subheaderExpected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Document Acceptance window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that DocumentAcceptance window appears");
				var selDocumentAcceptance = new DocumentAcceptance();
				var showing = selDocumentAcceptance.SubHeadings3Showing();
				Report.IsTrue(showing.Contains(subheaderExpected.Trim()),
					"Document Acceptance subheader3 was not as expected! Expected: '" + subheaderExpected + "', but found: '" + string.Join("', '", showing) + "' instead!",
					"Document Acceptance header was showing '" + subheaderExpected + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
	}
}
