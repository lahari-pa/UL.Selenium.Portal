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
	[Binding, Scope(Tag = "UlSolutionCenter")]
	class StepsUlSolutionCenter
	{

		[StepDefinition(@"I should see the following option (.*)")]
		public void ThenIShouldSeeTheFollowingOption(string option)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - Checking that the option " + option + " is showing");
			try
			{
				Report.Info("Checking that the option " + option + " is showing");
				var selUlSolutionCenter = new UlSolutionCenter();

				if (!selUlSolutionCenter.Wait_for_load(10))
				{
					throw new Exception("Page failed to load!");
				}


				var optionShowing = selUlSolutionCenter.OptionShowing();
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		/// <summary>
		/// Clicking the learn more button on the UL Solution Center page
		/// </summary>
		//[StepDefinition(@"I click the Learn More button")]
		//public void ClickLearnMorebutton()
		//{
		//	TestReport.BeginTestModule(GlobalParameters.StepCount + " - Clicking 'Learn More button'");
		//	try
		//	{
		//		Report.Info("Clicking 'Learn More button'");

		//		var selUlSolutionCenter = new UlSolutionCenter();

		//		if (!selUlSolutionCenter.Wait_for_load(10))
		//		{
		//			throw new Exception("Page failed to load!");
		//		}


		//		selUlSolutionCenter.ClickMoreInformation();
		//		Report.Success("More Information link clicked!");
		//		Report.Info("Switching to new window");

		//		Context.AddToContext("MainWindowHandle", SeleniumBrowser.WebBrowser.CurrentWindowHandle);

		//		var windowHandles = SeleniumBrowser.WebBrowser.WindowHandles;
		//		var newTab = windowHandles.FirstOrDefault(x => x != SeleniumBrowser.WebBrowser.CurrentWindowHandle);
		//		SeleniumBrowser.WebBrowser.SwitchTo().Window(newTab);
		//		Report.Success("Window switched successfully!");
		//		Report.Screenshot();
		//	}
		//	catch (Exception ex)
		//	{
		//		Report.Failure(ex.Message);
		//		throw;
		//	}
		// }

	}
}
