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
		[StepDefinition(@"I confirm the following sections are displayed in the UL Solution Center page:")]
		public void ThenConfirmInTheUlSolutionCenterPageYouSeeSectionsFor(TechTalk.SpecFlow.Table table)
		{
			var selSolutionCenter = new UlSolutionCenter();
			List<string> sectionsShowing = selSolutionCenter.OptionShowing();
			Report.IsTrue(sectionsShowing.Count == table.RowCount,
				$"Expected there to be: {table.RowCount} items displayed in UL Solution Center but there were: {sectionsShowing.Count}",
				$"There were {table.RowCount} items displayed in UL Solution Center as expected");
			foreach (var thisrow in table.Rows)
			{
				string sectionToFind = thisrow["Sections"];
				Report.IsTrue(sectionsShowing.Contains(sectionToFind),
					"Section: " + sectionToFind + " is not showing. The following are: " + string.Join(",", sectionsShowing),
					"As expected, section: " + sectionToFind + " is showing.");
			}
		}
	}
}
