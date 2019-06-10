using NTTQA.Selenium.Reporting.Core;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_ElectronicEquipment
	{
		ElectronicEquipment _electronicEquipment = new ElectronicEquipment();

		[StepDefinition(@"I set 'Has a LCD or Plasma Display' to: (No|Yes)")]
		public void SetHasAlcdOrPlasmaDisplayToNoOrYes(string noOrYes)
		{
			Report.IsTrue(this._electronicEquipment.WaitForTab("Product Characteristics"), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");
			bool expected = (noOrYes == "Yes");
			this._electronicEquipment.HasLcdOrPlasmaDisplay = expected;
			Report.IsTrue(this._electronicEquipment.HasLcdOrPlasmaDisplay == expected,
				"Failed to set Has a LCD or Plasma Display value to: " + noOrYes,
				"Successfully set Has a LCD or Plasma Display value to: " + noOrYes);
		}

		[StepDefinition(@"I set 'Contains Circuit Board' to: (No|Yes)")]
		public void SetContainsCircuitBoardToNoOrYes(string noOrYes)
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
