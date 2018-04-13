using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mailosaur;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;
using WERCSmart;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "Solutions")]
	class StepsSolution
	{

		[Then(@"Confirm in the UL Solution Center page you see sections for:")]
		public void ThenConfirmInTheUlSolutionCenterPageYouSeeSectionsFor(TechTalk.SpecFlow.Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + "- Confirm in the UL Solution Center page you see sections for:");
			UlSolutionCenter thisSolutionCenter = new UlSolutionCenter();
			
			Report.Screenshot();
			try
			{
				List<string> sectionsShowing = thisSolutionCenter.OptionShowing();
				foreach (TechTalk.SpecFlow.TableRow thisrow in table.Rows)
				{
					string sectionToFind = thisrow["Sections"];
					Report.IsTrue(sectionsShowing.Contains(sectionToFind),
						"Section: " + sectionToFind + " is not showing. The following are: " + string.Join(",", sectionsShowing),
						"As expected, section: " + sectionToFind + " is showing.");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

	}
}
