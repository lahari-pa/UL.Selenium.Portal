using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using NTTQA.Selenium.Reporting.Core;
using Org.BouncyCastle.Asn1.Mozilla;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product
{
	[Binding, Scope(Tag = "NewProduct")]
	class StepsLithiumBatteryTransportation
	{
		private static LithiumBatteryTransportation _lithiumBatteryTransportation = new LithiumBatteryTransportation();

		[StepDefinition(@"I set 'DOT' to: (.*)")]
		public void SetDotTo(string option)
		{
			Report.IsTrue(_lithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded", "Product characteristics tab is loaded.");
			_lithiumBatteryTransportation.Dot = option;
			Report.IsTrue(_lithiumBatteryTransportation.Dot == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"I set 'IMDG' to: (.*)")]
		public void SetImdgTo(string option)
		{
			Report.IsTrue(_lithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded", "Product characteristics tab is loaded.");
			_lithiumBatteryTransportation.Imdg = option;
			Report.IsTrue(_lithiumBatteryTransportation.Imdg == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"I set 'IATA' to: (.*)")]
		public void SetIataTo(string option)
		{
			Report.IsTrue(_lithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded","Product characteristics tab is loaded.");
			_lithiumBatteryTransportation.Iata = option;
			Report.IsTrue(_lithiumBatteryTransportation.Iata == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"I set 'TDG' to: (.*)")]
		public void SetTdgTo(string option)
		{
			Report.IsTrue(_lithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded","Product characteristics tab is loaded.");
			_lithiumBatteryTransportation.Tdg = option;
			Report.IsTrue(_lithiumBatteryTransportation.Tdg == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}


	}
}
