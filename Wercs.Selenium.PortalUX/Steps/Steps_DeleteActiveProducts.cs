using System;
using ResourcePool;
using SafewareReporting;
using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "DeleteActiveProducts")]
	class StepsDeleteActiveProducts
	{
		/// <summary>
		/// This is to verify the title of the page
		/// </summary>
		/// <param name="headerExpected"></param>
		[StepDefinition(@"I should see the header: (.*) on the Delete Active Product window")]
		public void CorrectDAPHeaderShowing(string headerExpected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Delete Active Product window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Delete Active Product window appears");
				var selDeleteActiveProduct = new DeleteActiveProducts();
				var showing = selDeleteActiveProduct.HeaderShowing();
				Report.IsTrue(showing == headerExpected.Trim(),
					"Delete Active Product header was not as expected! Expected: '" + headerExpected + "', but found: '" + showing + "' instead!",
					"Delete Active Product header was showing '" + headerExpected + "', as expected!");
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
		[StepDefinition(@"I should see the subheading 3: (.*) on the Delete Active Product window")]
		public void CorrectSubHeader3Showing(string subheaderExpected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Delete Active Product window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Delete Active Product window appears");
				var selDeleteActiveProduct = new DeleteActiveProducts();
				var showing = selDeleteActiveProduct.SubHeadings3Showing();
				Report.IsTrue(showing.Contains(subheaderExpected.Trim()),
					"Delete Active Product subheader3 was not as expected! Expected: '" + subheaderExpected + "', but found: '" + string.Join("', '", showing) + "' instead!",
					"Delete Active Product header was showing '" + subheaderExpected + "', as expected!");
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
