using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using NTTQA_Reporting_Module.Reporting.Core;
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
		
		[StepDefinition(@"For 'DOT, indicate the transportation classification' I select: (.*)")]
		public void ForDotIndicateTransportationClassificationISelect(string option)
		{
			Report.IsTrue(_lithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded", "Product characteristics tab is loaded.");
			_lithiumBatteryTransportation.Dot = option;
			Report.IsTrue(_lithiumBatteryTransportation.Dot == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"For 'IMDG, indicate the transportation classification' I select: (.*)")]
		public void ForImdgIndicateTransportationClassificationISelect(string option)
		{
			Report.IsTrue(_lithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded", "Product characteristics tab is loaded.");
			_lithiumBatteryTransportation.Imdg = option;
			Report.IsTrue(_lithiumBatteryTransportation.Imdg == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"For 'IATA, indicate the transportation classification' I select: (.*)")]
		public void ForIataIndicateTransportationClassificationISelect(string option)
		{
			Report.IsTrue(_lithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded","Product characteristics tab is loaded.");
			_lithiumBatteryTransportation.Iata = option;
			Report.IsTrue(_lithiumBatteryTransportation.Iata == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"For 'TDG, indicate the transportation classification' I select: (.*)")]
		public void ForTdgIndicateTransportationClassificationISelect(string option)
		{
			Report.IsTrue(_lithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded","Product characteristics tab is loaded.");
			_lithiumBatteryTransportation.Tdg = option;
			Report.IsTrue(_lithiumBatteryTransportation.Tdg == option,"Failed to set battery packaged option: " + option,"Successfully set battery packaged option: " + option);
		}

		[StepDefinition(@"For 'U\.S\. Toxic Substances Control Act \(TSCA\) status' I select: (.*)")]
		public void ForUSToxicSubstancesControlActTSCAStatusISelect(string option)
		{
			Report.IsTrue(_lithiumBatteryTransportation.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");
			// set Tsca status
			_lithiumBatteryTransportation.TscaStatus = option;
			// get Tsca status
			Report.IsTrue(_lithiumBatteryTransportation.TscaStatus == option,
				"Failed to set TSCA status: " + option,
				"Successfully set TSCA status: " + option);
		}


	}
}
