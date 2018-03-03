using System;
using ResourcePool;
using SafewareReporting;
using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "ForwardProductRegistration")]
	class StepsForwardProductRegistration
	{
		[StepDefinition(@"I should see the header: (.*) on the Forward Product Registration window")]
		public void CorrectHeaderShowing(string headerExpected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Forward Product Registration window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Forward Product Registration window appears");
				var selForwardProductRegistration = new ForwardProductRegistration();
				var showing = selForwardProductRegistration.HeaderShowing();
				Report.IsTrue(showing == headerExpected.Trim(),
					"Forward Product Registration header was not as expected! Expected: '" + headerExpected + "', but found: '" + showing + "' instead!",
					"Forward Product Registration header was showing '" + headerExpected + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should see the subheading: (.*) on the Forward Product Registration window")]
		public void CorrectSubHeaderShowing(string subheaderExpected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Forward Product Registration window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Forward Product Registration window appears");
				var selForwardProductRegistration = new ForwardProductRegistration();
				var showing = selForwardProductRegistration.SubHeadingsShowing();
				Report.IsTrue(showing.Contains(subheaderExpected.Trim()),
					"Forward Product Registration subheader was not as expected! Expected: '" + subheaderExpected + "', but found: '" + string.Join("', '", showing) + "' instead!",
					"Forward Product Registration header was showing '" + subheaderExpected + "', as expected!");
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I should be sent to the Product Registration page with retailers list displayed")]
		public void ThenIShouldBeSentToTheProductRegistrationPageWithRetailersListDisplayed()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Forward Product Registration window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Forward Product Registration window appears");
				var selForwardProductRegistration = new ForwardProductRegistration();
				Report.IsTrue(selForwardProductRegistration.Wait_for_load(), "Forward Product Registration window did not appear!", "Forward Product Registration window appeared successfully");
				Report.IsTrue(selForwardProductRegistration.ListOfRetailers() != null, "No retailers were found!", "Retailers were found in the list, as expected");
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
