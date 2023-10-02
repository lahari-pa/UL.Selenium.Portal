using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.DistributorSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryInformation2")]
	internal class RegulatoryInformation2
	{
		[StepDefinition(@"In the Regulatory Information 2 Section, set the option in section: 'Product contains microbeads': to: (Yes|No)")]
		public void SelectProductContainsMicrobeads(string option)
		{
			string section = "Product contains microbeads";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Regulatory Information 2 Section, set the option in section: 'Product is considered ""Rinse off""': to: (Yes|No)")]
		public void SelectProductRinseOff(string option)
		{
			string section = "Product is considered \"Rinse off\"";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Regulatory Information 2 Section, click link HR 1321")]
		public void ClickLinkHR1321()
		{
			string linkText = "HR 1321";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[StepDefinition(@"In the Regulatory Information 2 Section, click link Free Water Act of 2015")]
		public void ClickLinkFreeWaterOf2015()
		{
			string linkText = "Free Water Act of 2015";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
	}
}
