using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.WebDriver.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Type
{
	[Binding, Scope(Tag = "PhysicalAndChemicalProp")]
	 class PhysicalAndChemicalProp
	{

		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'Primary Physical State' to: (Product is packaged in a gas cylinder \(e.g., whip cream\)|Liquid|Solid|Gas|Aerosol)")]
		public void SelectPrimaryPhsicalState(string option)
		{
			string section = "Primary Physical State";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'Secondary Physical State' to: (.*)")]
		public void SelectSecondaryPhsicalState(string option)
		{
			string section = "Secondary Physical State";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, for section: 'Relative Density' enter text: (.*)")]
		public void EnterTextForRelativeDensity(string text)
		{
			string section = "Relative Density";
			new Steps_Prototype().SetTheSectionOptionTo(section,text);
		}

		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'Relative Density' to: (g/ml \(grams per milliliter\)|lb./gal. \(pounds per gallon\))")]
		public void SelectRelativeDensity(string option)
		{
			string section = "Relative Density";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, for section: 'pH' enter text: (.*)")]
		public void EnterTextForPH(string text)
		{
			string section = "pH";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}

		[StepDefinition(@"In the Physical and Chemical Properties Section, for section: 'pH' select the checkbox option: 'I do not have exact pH data available to me'")]
		public void SelectCheckboxForPH()
		{
			string section = "check";
			string text = "I do not have exact pH data available to me";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(section, text);
		}

		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'pH' to: (<= 2|2.1 - 3.9|4 - 6.9|7 \(Neutral\)|7.1 - 9.9|10 - 12.4|>= 12.5|Not tested/Unknown)")]
		public void SelectPhRange(string option)
		{
			string section = "pH";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, for question: 'When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5\?' set the option to: (Yes|No)")]
		public void SelectProductContainsMicrobeads(string option)
		{
			string section = "When mixed with an equal amount of water, will this produce a solution with a pH <= 2 or a pH >= 12.5?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, for section: 'Boiling Point \(in Celsius\)' enter text: (.*)")]
		public void EnterTextForBoilingPoint(string text)
		{
			string section = "Boiling Point (in Celsius)";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}

		[StepDefinition(@"In the Physical and Chemical Properties Section, for section: 'Boiling Point \(in Celsius\)' select the checkbox option: 'I do not have exact Boiling Point data available to me'")]
		public void SelectCheckboxForBoilingPoint()
		{
			string section = "check";
			string text = "I do not have exact Boiling Point data available to me";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(section, text);
		}

		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'Boiling Point \(in Celsius\)' to: (<= 20C \(68F\)|20.1C \(68.1F\) - 35C \(95F\)|>35C \(95F\) - 37.7C \(99.9F\)|> 37.7C \(99.9F\)|Not tested/Unknown)")]
		public void SelectBoilingPoint(string option)
		{
			string section = "Boiling Point (in Celsius)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, for section: 'Flash Point \(in Celsius\)' enter text: (.*)")]
		public void EnterTextForFlashPoint(string text)
		{
			string section = "Flash Point (in Celsius)";
			new Steps_Prototype().SetTheSectionOptionTo(section, text);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, for section: 'Flash Point \(in Celsius\)' select the checkbox option: 'I do not have exact Flash Point data available to me'")]
		public void SelectCheckboxForFlashPoint()
		{
			string section = "check";
			string text = "I do not have exact Flash Point data available to me";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(section, text);
		}

		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'Flash Point \(in Celsius\)' to: (<23C|>=23C and <38C|>=38C and <=60C|>60C and <=93C|>=93C and <=815C|Not Tested/Unknown|None, No Flash Point)")]
		public void SelectFlashPoint(string option)
		{
			string section = "Flash Point (in Celsius)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'Flash Point Testing Method Used' to: (Closed cup method|Open cup method|Not applicable/available)")]
		public void SelectFlashPointTestingMethod(string option)
		{
			string section = "Flash Point Testing Method Used";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'Select the best Water Solubility description' to: (Cloth not soluble|Completely soluble|Dispersible|Immiscible|Insoluble in water|Miscible|Miscible in water|Moderately soluble|Mostly soluble|Negligible|No data available|Partially soluble|Soluble in water)")]
		public void SelectWaterSolubility(string option)
		{
			string section = "Select the best Water Solubility description";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then' to: (This product is classified as a D001 Hazardous Waste under RCRA \(as per Section 13 or 15 of the SDS\).|This product is classified as a D003 Hazardous Waste under RCRA.|This product is not classified as D001 or D003 Hazardous Waste under RCRA)")]
		public void SelectHazardousWaste(string option)
		{
			string section = "When the product has a flammable propellant, or contains ingredients with a flash point below 60⁰C then";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'Select all potential allergens included in this product' to: (Dairy|Egg|Wheat|Peanuts|Tree Nuts|Soybeans|Shellfish or Crustaceans|None of the Above)")]
		public void SelectPotentialAllergens(string option)
		{
			string section = "Select all potential allergens included in this product";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'Product is manufactured in a facility that processes, or contains' to: (Dairy or products containing dairy or milk|Eggs or products containing eggs|Wheat or products containing wheat|Peanuts or products containing peanuts|Tree nuts or products containing tree nuts|Soybeans or products containing soybeans|Shellfish or Crustaceans|None of the Above)")]
		public void SelectIngredientsFacilityProcesses(string option)
		{
			string section = "Product is manufactured in a facility that processes, or contains";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'Product is verified and sold as' to: (Kosher|Gluten-free|Halal|Genetically Modified Organisms \(GMOs\)-free|Organic per USDA Standards|Non-Perishable|None of the Above)")]
		public void SelectProductVerifiedAndSoldAs(string option)
		{
			string section = "Product is verified and sold as";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following sweeteners' to: (Saccharin|Aspartame|Acesulfame potassium|Advantame|Steviol glycosides|Luo han guo fruit extracts|Sucralose|Neotame|None of the Above)")]
		public void SelectProductSweeteners(string option)
		{
			string section = "Product contains the following sweeteners";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[StepDefinition(@"In the Physical and Chemical Properties Section, set the option in section: 'Product contains the following artificial dye\(s\)' to: (FD&C Blue No. 1|FD&C Blue No. 2|FD&C Green No. 3|Orange B|FD&C Yellow No. 5|Citrus Red No. 2|FD&C Red No. 2|FD&C Red No. 3|FD&C Red No. 40|FD&C Yellow No. 6|None of the Above)")]
		public void SelectArtificalDyes(string option)
		{
			string section = "Product contains the following artificial dye(s)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}





	}
}
