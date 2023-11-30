using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Type
{
	[Binding, Scope(Tag = "PhysicalAndChemicalProp")]
	internal class PhysicalAndChemicalProp
	{
		// ADD OPT. FOR gas cylinder text = "Product is packaged in a gas cylinder (e.g.- whip cream)" -- escape issue 

		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: (Liquid|Solid|Gas|Aerosol)")]
		public void SelectPrimaryPhsicalState(string option)
		{
			string section = "Primary Physical State";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		// INSTERT SECONDARY PHYSICAL STATE STEP HERE -- dropdown 


		[StepDefinition(@"In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: (.*)")]
		public void EnterTextForRelativeDensity(string text)
		{
			string section = "Relative Density";
			new Steps_Prototype().SetTheSectionOptionTo(section,text);
		}

		//INSTERT RELATIVE DENSITY SET OPTION STEP HERE -- escape issue 

		[StepDefinition(@"In the Physical and Chemical Properties Section, for section: 'pH' enter text: (.*)")]
		public void EnterTextForPH(string text)
		{
			string section = "pH";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}

		[StepDefinition(@"In the Physical and Chemical Properties Section, for section: 'pH' select the checkbox option: 'I do not have exact pH data available to me'")]
		public void SelectCheckboxForPH()
		{
			string section = "pH";
			string text = "I do not have exact pH data available to me";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}

		//INSTERT PH DROPDOWN STEP HERE -- escape issue 

		[StepDefinition(@"In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water- will this produce a solution with a pH <= 2 or a pH >= 12.5?' set the option to: (Yes|No)")]
		public void SelectProductContainsMicrobeads(string option)
		{
			string section = "When mixed with an equal amount of water- will this produce a solution with a pH <= 2 or a pH >= 12.5?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' enter text: (.*)")]
		public void EnterTextForBoilingPoint(string text)
		{
			string section = "Boiling Point (in Celsius)";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}

		[StepDefinition(@"In the Physical and Chemical Properties Section, for section: 'Boiling Point (in Celsius)' select the checkbox option: 'I do not have exact Boiling Point data available to me'")]
		public void SelectCheckboxForBoilingPoint()
		{
			string section = "Boiling Point (in Celsius)";
			string text = "I do not have exact Boiling Point data available to me";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}








	}
}
