using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTQA_Reporting_Module;
using NTTQA_Reporting_Module.Reporting.Core;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_ElectronicEquipment
	{
		ElectronicEquipment _electronicEquipment = new ElectronicEquipment();

		[StepDefinition(@"For 'Has a LCD or Plasma Display' I select: (No|Yes)")]
		public void ForHasAlcdOrPlasmaDisplayISelectNoOrYes(string noOrYes)
		{
			Report.IsTrue(this._electronicEquipment.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");
			bool expected = (noOrYes == "Yes");
			this._electronicEquipment.HasLcdOrPlasmaDisplay = expected;
			Report.IsTrue(this._electronicEquipment.HasLcdOrPlasmaDisplay == expected,
				"Failed to set Has a LCD or Plasma Display value to: " + noOrYes,
				"Successfully set Has a LCD or Plasma Display value to: " + noOrYes);
		}

		[StepDefinition(@"For 'Contains Circuit Board' I select: (No|Yes)")]
		public void ForContainsCircuitBoardISelectNoOrYes(string noOrYes)
		{
			Report.IsTrue(this._electronicEquipment.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");
			bool expected = (noOrYes == "Yes");
			this._electronicEquipment.ContainsCircuitBoard = expected;
			Report.IsTrue(this._electronicEquipment.ContainsCircuitBoard == expected,
				"Failed to set Contains Circuit Board value to: " + noOrYes,
				"Successfully set Contains Circuit Board value to: " + noOrYes);
		}
	}
}
