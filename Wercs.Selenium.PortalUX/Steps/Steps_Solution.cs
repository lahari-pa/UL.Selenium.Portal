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

		[StepDefinition(@"I Confirm the (.*) heading is displayed next to an icon")]
		public void ConfirmTheHeadingIsShownNextToTheLogo(string sectionHeader)
		{
			var selSolutionCenter = new UlSolutionCenter();
			var sections = selSolutionCenter.GetSections;
			var sectionMatch = sections.FirstOrDefault(x => x.Header == sectionHeader);
			if (Report.IsTrue(sectionMatch != null, $"Section with header: '{sectionHeader}' was not displayed!", $"Section with header: '{sectionHeader}' was displayed as expected"))
			{
				Report.IsTrue(sectionMatch.LogoDisplayed,
					$"A logo was not displayed for section with header: {sectionHeader}!",
					$"A logo was displayed for section with header: '{sectionHeader}' as expected");
			}
		}

		[StepDefinition(@"I Confirm the information statement for section: (.*) reads: (.*)")]
		public void ConfirmInformationStatementReads(string sectionHeader, string expectedStatement)
		{
			var selSolutionCenter = new UlSolutionCenter();
			var sections = selSolutionCenter.GetSections;
			var sectionMatch = sections.FirstOrDefault(x => x.Header == sectionHeader);
			if (sectionMatch != null)
			{
				Report.IsTrue(sectionMatch.Statement == expectedStatement,
					$"The statement for section: {sectionHeader} did not match the expected text! Expected: '{expectedStatement}'. Actual: '{sectionMatch.Statement}'",
					$"The statement for section: {sectionHeader} was showing as expected: '{expectedStatement}'");
				return;
			}
			Report.Failure($"The section with header {sectionHeader} was not found on the UL Soltuion Center page! The displayed sections were: " + string.Join(", ", sections.Select(x => $"'{x.Header}'")));
			Report.Screenshot();
		}

		[StepDefinition(@"I confirm the Learn More button is displayed for section: (.*)")]
		public void ConfirmTheLearnMoreButtonIsDisplayedForSection(string sectionHeader)
		{
			var selSolutionCenter = new UlSolutionCenter();
			var sections = selSolutionCenter.GetSections;
			var sectionMatch = sections.FirstOrDefault(x => x.Header == sectionHeader);
			if (sectionMatch != null)
			{
				Report.IsTrue(sectionMatch.LearnMoreDisplayed,
					$"The Learn More button was not displayed for section: {sectionHeader}!",
					$"The Learn More button was displayed for section: {sectionHeader} as expected");
				return;
			}
			Report.Failure($"The section with header {sectionHeader} was not found on the UL Soltuion Center page! The displayed sections were: " + string.Join(", ", sections.Select(x => $"'{x.Header}'")));
			Report.Screenshot();
		}

		[StepDefinition(@"I click the Learn More button for section: (.*)")]
		public void ClickTheLearnMoreButtonForSection(string sectionHeader)
		{
			var selSolutionCenter = new UlSolutionCenter();
			var sections = selSolutionCenter.GetSections;
			var sectionMatch = sections.FirstOrDefault(x => x.Header == sectionHeader);
			if (sectionMatch != null)
			{
				Report.IsTrue(sectionMatch.ClickLearnMore(),
					$"Failed to click the Learn More button for section: {sectionHeader}!",
					$"Successfully clicked the Learn More button for section: {sectionHeader} as expected");
				return;
			}
			Report.Failure($"The section with header {sectionHeader} was not found on the UL Soltuion Center page! The displayed sections were: " + string.Join(", ", sections.Select(x => $"'{x.Header}'")));
			Report.Screenshot();
		}
	}
}
