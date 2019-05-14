using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using NTTQA_Reporting_Module.Reporting.Core;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product
{
	[Binding, Scope(Tag = "NewProduct")]
	class StepsLithiumBatteryTransportation
	{
		public static LithiumBatteryTransportation LithiumBatteryTransportation;

		[StepDefinition(@"For 'DOT, indicate the transportation classification' I select: (.*)")]
		public void ForDotIndicateTransportationClassificationISelect(string option)
		{
			Report.IsTrue(LithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded", "Product characteristics tab is loaded.");
			LithiumBatteryTransportation.Dot = option;
			Report.IsTrue(LithiumBatteryTransportation.Dot == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"For 'IMDG, indicate the transportation classification' I select: (.*)")]
		public void ForImdgIndicateTransportationClassificationISelect(string option)
		{
			Report.IsTrue(LithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded", "Product characteristics tab is loaded.");
			LithiumBatteryTransportation.Imdg = option;
			Report.IsTrue(LithiumBatteryTransportation.Imdg == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"For 'IATA, indicate the transportation classification' I select: (.*)")]
		public void ForIataIndicateTransportationClassificationISelect(string option)
		{
			Report.IsTrue(LithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded","Product characteristics tab is loaded.");
			LithiumBatteryTransportation.Iata = option;
			Report.IsTrue(LithiumBatteryTransportation.Iata == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"For 'TDG, indicate the transportation classification' I select: (.*)")]
		public void ForTdgIndicateTransportationClassificationISelect(string option)
		{
			Report.IsTrue(LithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded","Product characteristics tab is loaded.");
			LithiumBatteryTransportation.Tdg = option;
			Report.IsTrue(LithiumBatteryTransportation.Tdg == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"For 'U\.S\. Toxic Substances Control Act \(TSCA\) status' I select: (.*)")]
		public void ForUSToxicSubstancesControlActTSCAStatusISelect(string option)
		{
			Report.IsTrue(LithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");
			// set Tsca status
			LithiumBatteryTransportation.TscaStatus = option;
			// get Tsca status
			Report.IsTrue(LithiumBatteryTransportation.TscaStatus == option,
				"Failed to set TSCA status: " + option,
				"Successfully set TSCA status: " + option);
		}


	}
}
