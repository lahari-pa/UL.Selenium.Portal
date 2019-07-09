using NTTQA.Selenium.Reporting.Core;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_RegulatoryInformation1
	{
		private RegulatoryInformation1 RegulatoryInformation1 => new RegulatoryInformation1();

		[StepDefinition(@"For 'U\.S\. Toxic Substances Control Act \(TSCA\) status' I select: (.*)")]
		public void SetTSCATo(string option)
		{
			Report.IsTrue(this.RegulatoryInformation1.WaitForTab(NewProduct.Tab.ProductCharacteristics), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");
			this.RegulatoryInformation1.TscaStatus = option;
			Report.IsTrue(this.RegulatoryInformation1.TscaStatus == option,
				"Failed to set TSCA status: " + option,
				"Successfully set TSCA status: " + option);
		}

		[StepDefinition(@"For Canadian Environmental Protection Act (CEPA) status I select: (.*)")]
		public void SetCEPATo(string option)
		{
			Report.IsTrue(this.RegulatoryInformation1.WaitForTab(NewProduct.Tab.ProductCharacteristics), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");
			this.RegulatoryInformation1.CEPAStatus = option;
			Report.IsTrue(this.RegulatoryInformation1.CEPAStatus == option,
				"Failed to set CEPA status: " + option,
				"Successfully set CEPA status: " + option);
		}

		[StepDefinition(@"I set 'Prop65' to: (No|Yes)")]
		public void SetProp65ToNoOrYes(string noOrYes)
		{
			Report.IsTrue(this.RegulatoryInformation1.WaitForTab(NewProduct.Tab.ProductCharacteristics), "Product characteristics has not loaded",
				"Product characteristics tab is loaded.");
			var expected = (noOrYes == "Yes");
			this.RegulatoryInformation1.Prop65 = expected;
			Report.IsTrue(this.RegulatoryInformation1.Prop65 == expected,
				"Failed to set Prop 65 value to: " + noOrYes,
				"Successfully set Prop 65 value to: " + noOrYes);
		}
	}
}
