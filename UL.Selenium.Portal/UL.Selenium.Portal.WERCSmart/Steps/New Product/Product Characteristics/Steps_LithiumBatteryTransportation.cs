using UL.Automation.Reporting.Functions;
using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product
{
	[Binding, Scope(Tag = "NewProduct")]
	class StepsLithiumBatteryTransportation
	{
		private LithiumBatteryTransportation LithiumBatteryTransportation => new LithiumBatteryTransportation();

		[RegexStepDefinition(@"I set 'DOT' to: (.*)")]
		public void SetDotTo(string option)
		{
			Report.IsTrue(this.LithiumBatteryTransportation.WaitForTab(NewProduct.Tab.ProductCharacteristics), "Product characteristics has not loaded", "Product characteristics tab is loaded.");
			this.LithiumBatteryTransportation.Dot = option;
			Report.IsTrue(this.LithiumBatteryTransportation.Dot == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[RegexStepDefinition(@"I set 'IMDG' to: (.*)")]
		public void SetImdgTo(string option)
		{
			Report.IsTrue(this.LithiumBatteryTransportation.WaitForTab(NewProduct.Tab.ProductCharacteristics), "Product characteristics has not loaded", "Product characteristics tab is loaded.");
			this.LithiumBatteryTransportation.Imdg = option;
			Report.IsTrue(this.LithiumBatteryTransportation.Imdg == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[RegexStepDefinition(@"I set 'IATA' to: (.*)")]
		public void SetIataTo(string option)
		{
			Report.IsTrue(this.LithiumBatteryTransportation.WaitForTab(NewProduct.Tab.ProductCharacteristics), "Product characteristics has not loaded","Product characteristics tab is loaded.");
			this.LithiumBatteryTransportation.Iata = option;
			Report.IsTrue(this.LithiumBatteryTransportation.Iata == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[RegexStepDefinition(@"I set 'TDG' to: (.*)")]
		public void SetTdgTo(string option)
		{
			Report.IsTrue(this.LithiumBatteryTransportation.WaitForTab(NewProduct.Tab.ProductCharacteristics), "Product characteristics has not loaded","Product characteristics tab is loaded.");
			this.LithiumBatteryTransportation.Tdg = option;
			Report.IsTrue(this.LithiumBatteryTransportation.Tdg == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}


	}
}
