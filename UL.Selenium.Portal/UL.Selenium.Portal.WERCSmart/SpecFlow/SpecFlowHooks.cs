using BoDi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TReVor.Integrations.Classes;
using TReVor.Integrations.Classes.Configuration;
using UL.Automation.Helpers;

namespace UL.Selenium.Portal.WERCSmart.SpecFlow
{
	[Binding]
	internal class SpecFlowHooks
	{
		private string GetBranchName() => TReVorSettings.BranchInfo?.BranchName ?? TReVorConfig.CurrentSettings?.TReVorSettings?.SoftwareBranch;

		[BeforeScenario("OnlyInIntegration")]
		public void OnlyInStagingLogic(IObjectContainer container)
		{
			this.PerformBranchSkipLogic(container, "Staging - AZ");
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
