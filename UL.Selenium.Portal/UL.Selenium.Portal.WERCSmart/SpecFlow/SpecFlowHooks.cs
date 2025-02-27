using Reqnroll;
using System;
using TReVor.Integrations.Classes;
using TReVor.Integrations.Classes.Configuration;
using UL.Automation.Helpers;
using UL.Automation.Interfaces;

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
	}
}
