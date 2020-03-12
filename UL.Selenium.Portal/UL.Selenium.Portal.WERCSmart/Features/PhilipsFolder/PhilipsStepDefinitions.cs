using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Features.PhilipsFolder;

namespace UL.Selenium.Portal.WERCSmart.Features.PhilipsFolder {

	[Binding, Scope(Tag = "Philip")]
	public class PhilipsStepDefinitions
	{
		[StepDefinition(@"I check for the following columns")]
		public void ThenICheckForTheFollowingColumns(Table table)
		{
		PhilipsWebElements philipsWebElementsObject = new PhilipsWebElements();
		Report.IsTrue(philipsWebElementsObject.FindColumnWithTable(table), "Failed to find all", "Successfully found all");
		}

		[StepDefinition(@"I click the checkbox labeled: (.*)")]
		public void ThenIClickTheCheckboxLabeledAbc(string label)
		{
			PhilipsWebElements philipsWebElementsObject = new PhilipsWebElements();
			Report.IsTrue(philipsWebElementsObject.ClickCheckBoxWithLabel(label), "Failed to click box", "Successfully clicked box");
		}


	}

}
