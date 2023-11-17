using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Type
{
	[Binding, Scope(Tag = "Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ProductCharacteristics_Section:ElectronicEquipment")]
	internal class ElectronicEquipment
	{
		[StepDefinition(@"In the Electronic Equipment Section, set the option in section: 'Contains Circuit Board' to: (Yes|No)")]
		public void SetContainsCircuitBoard(string option)
		{
			string section = "Contains Circuit Board";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Electronic Equipment Section, set the option in section: 'Has a LCD or Plasma Display' to: (Yes|No)")]
		public void SetHasLCDorPlasmaDisplay(string option)
		{
			string section = "Has a LCD or Plasma Display";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Electronic Equipment Section, set the option in section: 'Display is greater than 4 inches diagonally' to: (Yes|No)")]
		public void SetDisplayIsGreaterThan4Inches(string option)
		{
			string section = "Display is greater than 4 inches diagonally";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Electronic Equipment Section, set the option in section: 'Display is greater than 9 inches diagonally' to: (Yes|No)")]
		public void SetDisplayIsGreaterThan9Inches(string option)
		{
			string section = "Display is greater than 9 inches diagonally";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Electronic Equipment Section, set the option in section: 'Has a Cathode Ray Tube \(CRT\)' to: (Yes|No)")]
		public void SetHasCathodeRayTube(string option)
		{
			string section = "Has a Cathode Ray Tube (CRT)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}
