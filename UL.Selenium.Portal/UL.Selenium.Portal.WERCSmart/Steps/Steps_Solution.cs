using Reqnroll;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Solutions")]
	class StepsSolution
	{
		[RegexStepDefinition(@"I confirm the following sections are displayed in the UL Solution Center page:")]
		public void ThenConfirmInTheUlSolutionCenterPageYouSeeSectionsFor(Table table)
		{
			var selSolutionCenter = new UlSolutionCenter();
			List<string> sectionsShowing = selSolutionCenter.OptionShowing();
			Report.IsTrue(sectionsShowing.Count == table.RowCount,
				$"Expected there to be: {table.RowCount} items displayed in UL Solution Center but there were: {sectionsShowing.Count}",
				$"There were {table.RowCount} items displayed in UL Solution Center as expected");
			foreach (TableRow thisrow in table.Rows)
			{
				string sectionToFind = thisrow["Sections"];
				Report.IsTrue(sectionsShowing.Contains(sectionToFind),
					"Section: " + sectionToFind + " is not showing. The following are: " + string.Join(",", sectionsShowing),
					"As expected, section: " + sectionToFind + " is showing.");
			}
		}

		[RegexStepDefinition(@"I Confirm the (.*) heading is displayed next to an icon")]
		public void ConfirmTheHeadingIsShownNextToTheLogo(string sectionHeader)
		{
			var selSolutionCenter = new UlSolutionCenter();
			List<UlSection> sections = selSolutionCenter.GetSections;
			UlSection sectionMatch = sections.FirstOrDefault(x => x.Header == sectionHeader);
			if (Report.IsTrue(sectionMatch != null, $"Section with header: '{sectionHeader}' was not displayed!", $"Section with header: '{sectionHeader}' was displayed as expected"))
			{
				Report.IsTrue(sectionMatch.LogoDisplayed,
					$"A logo was not displayed for section with header: {sectionHeader}!",
					$"A logo was displayed for section with header: '{sectionHeader}' as expected");
			}
		}

		[RegexStepDefinition(@"I Confirm the information statement for section: (.*) reads: (.*)")]
		public void ConfirmInformationStatementReads(string sectionHeader, string expectedStatement)
		{
			var selSolutionCenter = new UlSolutionCenter();
			List<UlSection> sections = selSolutionCenter.GetSections;
			UlSection sectionMatch = sections.FirstOrDefault(x => x.Header == sectionHeader);
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

		[RegexStepDefinition(@"I confirm the Learn More button is displayed for section: (.*)")]
		public void ConfirmTheLearnMoreButtonIsDisplayedForSection(string sectionHeader)
		{
			var selSolutionCenter = new UlSolutionCenter();
			List<UlSection> sections = selSolutionCenter.GetSections;
			UlSection sectionMatch = sections.FirstOrDefault(x => x.Header == sectionHeader);
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

		[RegexStepDefinition(@"I click the Learn More button for section: (.*)")]
		public void ClickTheLearnMoreButtonForSection(string sectionHeader)
		{
			var selSolutionCenter = new UlSolutionCenter();
			List<UlSection> sections = selSolutionCenter.GetSections;
			UlSection sectionMatch = sections.FirstOrDefault(x => x.Header == sectionHeader);
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

		[RegexStepDefinition(@"I switch to the (.*) information tab")]
		public void SwitchToTheTab(string sectionTab)
		{
			string[] urls = { "" };
			switch (sectionTab)
			{
				case "ECOLOGO":
					urls = new[] { "https://www.ul.com/resources/ecologo-certification-program" };
					break;
				case "Prospector":
					urls = new[] { "https://www.ulprospector.com/en/eu", "https://www.ulprospector.com/en/na" };
					break;
				case "ULGHS":
					//urls = new[] { "https://msc.ul.com/en/products/ulghs" };
					urls = new[] { "https://www.ulghs.com/" };
					break;
				case "UL Secure Connect (ULSC)":
					//urls = new[] { "https://msc.ul.com/en/products/wercs-studio/" };
					urls = new[] { "https://www.ul.com/" };
					break;
				case "GoodGuide for Suppliers":
					urls = new[] { "https://choosegoodguide.com/" };
					break;
				case "GoodGuide for Consumers":
					urls = new[] { "https://goodguide.com/" };
					break;
				case "Navigator":
					urls = new[] { "https://www.ul.com/resources/apps/navigator" };
					break;
			}
			Report.Info("Switch to Tab: " + string.Join(", ", urls));
			string currentHandle = SeleniumWebDriver.CurrentDriver.CurrentWindowHandle;
			Context.AddToContext("MainWindowHandle", currentHandle);
			ReadOnlyCollection<string> allHandles = SeleniumWebDriver.CurrentDriver.WindowHandles;
			foreach (string handle in allHandles)
			{
				SeleniumWebDriver.CurrentDriver.SwitchTo().Window(handle);
				SeleniumWebDriver.CurrentDriver.WaitForPageLoad(10);
				var currentUrl = SeleniumWebDriver.CurrentDriver.Url;
				Report.Info("Checking URL: " + currentUrl);
				if (urls.Any(x => currentUrl.Contains(x)))
				{
					Report.Success("Successfully Switch to Tab: " + sectionTab + "!");
					Report.Screenshot();
					return;
				}
				//foreach (string url in urls)
				//{
				//	if (currentUrl.Contains(url))
				//	{
				//		Report.Success("Successfully Switch to Tab: " + sectionTab + "!");
				//		Report.Screenshot();
				//		return;
				//	}
				//}
			}
			Report.Failure("Failed to find tab with url: " + string.Join(", ", urls));
		}

		[RegexStepDefinition(@"I find the Navigator section logo and check that it appears as expected")]
		public void IFindTheLogoForSectionIsAsExepcted()
		{

			string url = new UlSolutionCenter().GetSectionLogoUrl("Navigator");
			Bitmap actualBitmap = GeneralUtilities.CreateBitmapFromURL(url);
			EmbeddedResources.ExtractToFile("UL.Selenium.Portal.WERCSmart.Dependencies.Images.NAVIGATOR-LOGO TM.png", out string filePath);
			if (filePath == null)
			{
				Report.Failure("Failed to extract dependency file");
				return;
			}

			Bitmap expectBitmap = GeneralUtilities.CreateBitmapFromFile(filePath);
			bool imagesAreSame = false;
			try
			{
				imagesAreSame = GeneralFunctions.CompareImages(expectBitmap, actualBitmap);
				Report.IsTrue(imagesAreSame, "The Navigator Logo was not as expected", "The Navigator Logo was as expected");
			}
			catch (Exception ex)
			{
				Report.Failure($"The Navigator Logo was not as expected: {ex.Message}");
			}

		}
	}
}
