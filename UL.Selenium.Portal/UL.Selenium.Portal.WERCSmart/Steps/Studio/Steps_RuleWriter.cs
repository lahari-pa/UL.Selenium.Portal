using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using System;
using TechTalk.SpecFlow;
using UL.Automation.Reporting;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Steps;
using UL.Automation.Selenium.Classes;
using UL.Automation.Reporting.Classes;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.TReVor.Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Studio_RuleWriter")]
	public class Steps_RuleWriter
	{
		[StepDefinition(@"In Rule Writer, I click the '(.*)' button")]
		public void WhenInRuleWriterIClickTheButton(string buttonName)
		{
			RuleWriter wr = new RuleWriter();
			Report.IsTrue(wr.ClickButton(buttonName), $"Failed to click the button {buttonName}", $"Successfully clicked the button {buttonName}");
		}

		[StepDefinition(@"In Rule Writer, I click the All Rules button")]
		public void WhenInRuleWriterIClickTheAllRulesButton()
		{
			RuleWriter wr = new RuleWriter();
			Report.IsTrue(wr.ClickAllRulesButton(), $"Failed to click the button All Rules", $"Successfully clicked the button All Rules");
		}


	}
}
