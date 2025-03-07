using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:BatteryStateOfCharge")]
	class WERCSmart_NewProducts_BarrteryStateOfCharge
	{
		[RegexStepDefinition(@"In the Battery State of Charge Section, set the option in section: 'What is the state of charge of the battery\?' to: (Exact value is not available but does not exceed 30\% of the rated capacity.|Exact value is available.|Exact value is not available but exceeds 30\% of the rated capacity.|I don't know.)")]
		public void SetContainsCircuitBoard(string option)
		{
			string section = "What is the state of charge of the battery?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}
