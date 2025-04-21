using OpenQA.Selenium;
using Reqnroll;
using System;
using TReVor.Integrations.Classes;
using TReVor.Integrations.Classes.Configuration;
using UL.Automation.Helpers;
using UL.Automation.Interfaces;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;

namespace UL.Selenium.Portal.WERCSmart.SpecFlow
{
	[Binding]
	internal class SpecFlowHooks
	{
		private string GetBranchName() => TReVorSettings.BranchInfo?.BranchName ?? TReVorConfig.CurrentSettings?.TReVorSettings?.SoftwareBranch;

		[BeforeScenario("OnlyInIntegration")]
		public void OnlyInStagingLogic(IGenericContainer container)
		{
			this.PerformBranchSkipLogic(container, "Staging");
		}

		[BeforeScenario("OnlyInStaging")]
		public void RunOnlyInStagingLogic(IGenericContainer container)
		{
			this.PerformBranchSkipLogic(container, "QA-Integration");
			this.PerformBranchSkipLogic(container, "QA-Integration-New");
		}

		private void PerformBranchSkipLogic(IGenericContainer container, string targetBranchName)
		{
			string branchName = this.GetBranchName();
			if (!string.IsNullOrEmpty(branchName) && string.Equals(branchName, targetBranchName, StringComparison.InvariantCultureIgnoreCase))
			{
				container.SkipTestCase("Not applicable for this environment.");
			}
		}

		[BeforeStep(Order = 5)]
		public static void WaitForLoadingBarToDisappear()
		{
			IWebElement PortalLoadingBar = SeleniumWebDriver.CurrentDriver.FindElement(By.XPath("//div[contains(@class,'pace-active')]"), 1);
			PortalLoadingBar.WaitUntilElementInvisible(30);
		}
	}
}
