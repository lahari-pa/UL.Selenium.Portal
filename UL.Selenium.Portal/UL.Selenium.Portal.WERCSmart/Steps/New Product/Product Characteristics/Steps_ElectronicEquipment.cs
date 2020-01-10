using UL.Automation.Reporting.Functions;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_ElectronicEquipment
	{
		private ElectronicEquipment ElectronicEquipment => new ElectronicEquipment();

		[StepDefinition(@"I set 'Has a LCD or Plasma Display' to: (No|Yes)")]
		public void SetHasAlcdOrPlasmaDisplayToNoOrYes(string noOrYes)
		{
			Report.IsTrue(this.ElectronicEquipment.WaitForTab(NewProduct.Tab.ProductCharacteristics), "Product characteristics has not loaded",
				"Product Characteristics tab is loaded.");
			bool expected = (noOrYes == "Yes");
			this.ElectronicEquipment.HasLcdOrPlasmaDisplay = expected;
			Report.IsTrue(this.ElectronicEquipment.HasLcdOrPlasmaDisplay == expected,
				"Failed to set Has a LCD or Plasma Display value to: " + noOrYes,
				"Successfully set Has a LCD or Plasma Display value to: " + noOrYes);
		}

		[StepDefinition(@"I set 'Contains Circuit Board' to: (No|Yes)")]
		public void SetContainsCircuitBoardToNoOrYes(string noOrYes)
		{
			Report.IsTrue(this.ElectronicEquipment.WaitForTab(NewProduct.Tab.ProductCharacteristics), "Product characteristics has not loaded",
				"Product Characteristics tab is loaded.");
			bool expected = noOrYes == "Yes";
			this.ElectronicEquipment.ContainsCircuitBoard = expected;
			Report.IsTrue(this.ElectronicEquipment.ContainsCircuitBoard == expected,
				"Failed to set Contains Circuit Board value to: " + noOrYes,
				"Successfully set Contains Circuit Board value to: " + noOrYes);
		}
	}
}
