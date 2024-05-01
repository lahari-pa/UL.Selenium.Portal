using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
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

		[StepDefinition(@"In the Product Includes Battery Section enter value (.*) in (Battery Type|Grams Lithium|Watt Hours) field")]
		public void EnterBatterySelectInformation(string value, string option)
		{
			Report.IsTrue(new ProductIncludesBattery().SetSelectBatteriesOptions(option, value), $"Failed to enter {value} in {option} field", $"Succesfully entered {value} in {option} field");
		}
		[StepDefinition(@"In the Product Includes Battery Section enter value (.*) in (Quantity of Batteries per Package|Quantity of Batteries to Operate Product) field")]
		public void EnterBatteryInputInformation(string value, string option)
		{
			Report.IsTrue(new ProductIncludesBattery().EnterInputBatteriesOption(option, value), $"Failed to enter {value} in {option} field", $"Succesfully entered {value} in {option} field");
		}
		[StepDefinition(@"In the Product Includes Battery Section enter value (.*) in 'Manufacturer' field")]
		public void EnterBatteryManufacturer(string value)
		{
			Report.IsTrue(new ProductIncludesBattery().SetBatteriesSearchSelectOption("Manufacturer", value), $"Failed to enter {value} in Manufacturer field", $"Succesfully entered {value} in Manufacturer field");
		}

		[StepDefinition(@"In the Product Includes Battery Section enter the values in the table:")]
		public void GivenICallSharedProductIncludesBatteryAnyType(Table table)
		{
			try
			{
				foreach (TableRow thisRow in table.Rows)
				{
					if (table.ContainsColumn("Battery Type"))
					{
						this.EnterBatterySelectInformation($"{thisRow["Battery Type"]}", "Battery Type");
					}
					if(table.ContainsColumn("Grams Lithium"))
					{
						this.EnterBatterySelectInformation($"{thisRow["Grams Lithium"]}", "Grams Lithium");
					}
					if (table.ContainsColumn("Manufacturer"))
					{
						this.EnterBatteryManufacturer($"{thisRow["Manufacturer"]}");
					}
					if (table.ContainsColumn("Quantity of Batteries per Package"))
					{
						this.EnterBatteryInputInformation($"{thisRow["Quantity of Batteries per Package"]}", "Quantity of Batteries per Package");
					}
					if (table.ContainsColumn("Quantity of Batteries to Operate Product"))
					{
						this.EnterBatteryInputInformation($"{thisRow["Quantity of Batteries to Operate Product"]}", "Quantity of Batteries to Operate Product");
					}
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

	}
}
