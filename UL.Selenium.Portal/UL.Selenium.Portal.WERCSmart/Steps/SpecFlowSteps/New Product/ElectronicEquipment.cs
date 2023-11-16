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

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ElectronicEquipment")]
	class WERCSmart_Distributor_NewProducts_ProductType_ElectronicEquipment
	{
		[StepDefinition(@"In the Electronic Equipment Section, set the option in section: 'Contains Circuit Board' to: (Yes|No)")]
		public void SelectContainsCircuitBoard(string option)
		{
			string section = "Contains Circuit Board";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[StepDefinition(@"In the Electronic Equipment Section, set the option in section: 'Has a LCD or Plasma Display' to: (Yes|No)")]
		public void SelectHasLCDOrPlasmaDisplay(string option)
		{
			string section = "Has a LCD or Plasma Display";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[StepDefinition(@"In the Electronic Equipment Section, set the option in section: 'Display is greater than 4 inches diagonally' to: (Yes|No)")]
		public void SelectDisplayGreaterThan4inDiagonally(string option)
		{
			string section = "Display is greater than 4 inches diagonally";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[StepDefinition(@"In the Electronic Equipment Section, set the option in section: 'Display is greater than 9 inches diagonally' to: (Yes|No)")]
		public void SelectDisplayGreaterThan9inDiagonally(string option)
		{
			string section = "Display is greater than 9 inches diagonally";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}

