using BoDi;
using Reqnroll;
using System;
using TReVor.Integrations.Classes;
using TReVor.Integrations.Classes.Configuration;
using UL.Automation.Helpers;

namespace UL.Selenium.Portal.WERCSmart.Hooks
{
	[Binding]
	internal class ReqnrollHooks
	{
		private string GetBranchName() => TReVorSettings.BranchInfo?.BranchName ?? TReVorConfig.CurrentSettings?.TReVorSettings?.SoftwareBranch;

		[BeforeScenario("OnlyInIntegration")]
		public void OnlyInStagingLogic(IObjectContainer container)
		{
			this.PerformBranchSkipLogic(container, "Staging");
		}

		[BeforeScenario("OnlyInStaging")]
		public void RunOnlyInStagingLogic(IObjectContainer container)
		{
			this.PerformBranchSkipLogic(container, "QA-Integration");
			this.PerformBranchSkipLogic(container, "QA-Integration-New");
		}

		private void PerformBranchSkipLogic(IObjectContainer container, string targetBranchName)
		{
			string branchName = this.GetBranchName();
			if (!string.IsNullOrEmpty(branchName) && string.Equals(branchName, targetBranchName, StringComparison.InvariantCultureIgnoreCase))
			{
				container.SkipTestCase("Not applicable for this environment.");
			}
		}
	}
}
