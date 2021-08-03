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
using static UL.Selenium.Portal.WERCSmart.Selenium_Classes.RuleWriter;
using OpenQA.Selenium.Interactions;

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



		
		[StepDefinition(@"In Rule Writer, I right click the Rule with name: (.*) and select 'New'")]
		public void WhenInRuleWriterIRightClickTheRulAndSelectNew(string ruleName)
		{
			RuleWriter wr = new RuleWriter();
			RuleWriter_RulesEditor RW_RE = new RuleWriter_RulesEditor();
			//
			var thisContextMenu = new RightClickRuleMenu();
			//
			var baseRuleRow = RW_RE.GetRuleRowFromTable("Name", "BevB -");
			if (baseRuleRow.IsNullOrEmpty())
			{
				Report.Failure($"The base rule row element was null");
				Report.Screenshot();
				return;
			}
			Actions actions = new Actions(SeleniumBrowser.WebBrowser);
			actions.MoveToElement(baseRuleRow);
			actions.ContextClick();
			actions.Perform();
			if (thisContextMenu.MenuExists())
			{
				//click 'new' next (check new is option available?)
				var optionsList = thisContextMenu.GetAllOptions();
				if (Report.IsTrue(optionsList.Contains("New"), "failed to find 'New' in context menu'", "Found 'New' in the context menu"))
				{
					if(Report.IsTrue(thisContextMenu.SelectOption("New"),"Failed to click option","Clicked option"))
					{
						var globalSteps = new GlobalSteps();
						globalSteps.ThenTheWindowShouldLoad("New Rule", "should");
						return;

					}
					else
					{
						return;
					}
				}
				else
				{
					return;
				}
			}

		}

	}
}
