using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

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
		[StepDefinition(@"In the Product Includes Battery Section, the text message (should|should not) be displayed with text: 'Product includes a battery when sold'")]
		public void TextInAlertMessage(string condition)
		{
			string alertText = "Product includes a battery when sold";
			new Steps_Prototype().AlertMessageDisplayed(condition, alertText);
		}
		[StepDefinition(@"In the Product Includes Battery Section, set the radio option in section: 'Battery Type': to: (Carbon Zinc|Alkaline)")]
		public void SelectBatteryType(string option)
		{
			string section = "Battery Type";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Product Includes Battery Section enter value (.*) in (Battery Type|Manufacturer|Quantity of Batteries per Package|Quantity of Batteries to Operate Product|Grams Lithium|Watt Hours) field")]
		public void EnterBatteryInformation(string value, string option)
		{
			new Steps_Prototype().EnterBatteryInformation(value, option);

		}
	}
}
