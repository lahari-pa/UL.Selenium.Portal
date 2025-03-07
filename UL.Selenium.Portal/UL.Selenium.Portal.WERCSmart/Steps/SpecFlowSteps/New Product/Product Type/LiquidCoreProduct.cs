using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Type
{
	[Binding, Scope(Tag = "LiquidCoreProduct")]
	class LiquidCoreProduct
	{
		[RegexStepDefinition(@"In the Liquid Core Product Section, set the option in section: 'Is there a free liquid in the Product's container that is 10ml or greater\?' to: (Yes|No)")]
		public void LiquidCoreProductSelectYesOrNo(string option)
		{
			string section = "Is there a free liquid in the Product's container that is 10ml or greater?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}
