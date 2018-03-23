using System;
using System.IO;
using System.Linq;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;

using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "MessageCenter")]
	class StepsMessageCenter
	{
		/// <summary>
		/// This is to verify the title of the page
		/// </summary>
		/// <param name="headerExpected"></param>
		[StepDefinition(@"I should see the header: (.*) on the Message Center window")]
		public void CorrectHeaderShowing(string headerExpected)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Message Center window should appear");
			try
			{
				GeneralUtilities.Wait_for_load_finish();
				Report.Info("Checking that Message Center window appears");
				var selMessageCenter = new MessageCenter();
				var showing = selMessageCenter.HeaderShowing();
				Report.IsTrue(showing == headerExpected.Trim(),
					"Message Center header was not as expected! Expected: '" + headerExpected + "', but found: '" + showing + "' instead!",
					"Message Center header was showing '" + headerExpected + "', as expected!");
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
