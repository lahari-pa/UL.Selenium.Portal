using System;
using System.Reflection;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "RegulatoryInformation3")]
	class RegulatoryInformation3
	{
		[StepDefinition(@"In the Regulatory Information 3 Section, set the checkbox option in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.': to: (Drug Facts Panel|Supplement Facts Panel|Nutrition Facts Panel|None of the Above)")]
		public void SelectProductLabel(string option1)
		{
			string section = "Refer to your Product Label.  From the options, select those that appear on the Label.";
			new Steps_Prototype().SetTheSectionOptionTo(section, option1);
		}


		[StepDefinition(@"In the Regulatory Information 3 Section, the link: (OTC Drug Facts Label may include Active Ingredient|Nutritional and Supplement Labels|Dietary Supplements Label) (should|should not) be displayed")]
		public void Regulatory3LinkExists(string linkText, string condition)
		{
			new Steps_Prototype().LinkElementExists(condition, linkText);
		}






	}
}
