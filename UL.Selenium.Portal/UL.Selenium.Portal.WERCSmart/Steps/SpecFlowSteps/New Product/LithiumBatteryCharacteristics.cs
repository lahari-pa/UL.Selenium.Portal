using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:LithiumBatteryCharacteristics")]
	class WERCSmart_NewProducts_ProductType_LithiumBatteryCharacteristics
	{
		[StepDefinition(@"In the Lithium Battery Characteristics Section, in 'Type of Battery' select (.*)")]
		public void SelectTypeOfBattery(string option)
		{
			string section = "Type of Battery";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[StepDefinition(@"In the Lithium Battery Characteristics Section, in 'Weight of Lithium in grams' enter (.*)")]
		public void SelectWeightofLithiumingrams(string option)
		{
			string section = "Weight of Lithium in grams (single unit)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[StepDefinition(@"In the Lithium Battery Characteristics Section, in 'Weight of the single unit' enter (.*)")]
		public void SelectWeightOFSingleUnit(string option)
		{
			string section = "Weight of the single unit (grams)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Lithium Battery Characteristics Section, in 'Battery is manufactured under a Quality Management Program outlined in IATA 3.9.2.6' enter (YES|No|Unknown)")]
		public void SelectBatteryIsManufacturedUmder(string option)
		{
			string section = "Battery is manufactured under a Quality Management Program outlined in ";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Lithium Battery Characteristics Section, in 'Watt-hour of the battery' enter (.*)")]
		public void SelectWattHour(string option)
		{
			string section = "Watt-hour of the battery (single unit)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}
