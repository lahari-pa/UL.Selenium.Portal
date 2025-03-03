using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:WalmartPrivateLabel")]

	internal class WalmartPrivateLabel
	{

		[RegexStepDefinition(@"I enter the text of Private Label Consumable Product field to: (.*)")]
		public void GivenEnterPrivateLabelConsumableProductValue(string value)
		{
			Report.Info($"I set the text of Private Label Consumable Product field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("This Private Label Consumable Product requires On-line Ingredient Disclosure as per the Walmart Sustainable Chemistry Implementation Guide.", value);
		}

		[RegexStepDefinition(@"I enter the text of Online Ingredient Disclosure field to: (.*)")]
		public void GivenEnterOnlineIngredientDisclosureValue(string value)
		{
			Report.Info($"I set the text of Online Ingredient Disclosure field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Online Ingredient Disclosure", value);
		}

	}
}
