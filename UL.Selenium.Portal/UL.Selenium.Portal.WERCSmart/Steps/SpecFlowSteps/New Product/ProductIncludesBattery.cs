using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ProductIncludesBattery")]
	class WERCSmart_Distributor_NewProducts_ProductType_NewProduct
	{
		[StepDefinition(@"In the Product Includes Battery Section, set the radio option in section: 'Indicate how battery is packaged': to: (Installed in the product|The battery is shipped with but not included in my product.|Installed in the Product and Shipped with Additional Batteries not within the Product.)")]
		public void SelectIndicateHowBatteryIsPackaged(string option)
		{
			string section = "Indicate how battery is packaged";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[StepDefinition(@"In the Product Includes Battery Section, set the radio option in section: 'Battery Type': to: (Carbon Zinc|Alkaline)")]
		public void SelectBatteryType(string option)
		{
			string section = "Battery Type";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}
