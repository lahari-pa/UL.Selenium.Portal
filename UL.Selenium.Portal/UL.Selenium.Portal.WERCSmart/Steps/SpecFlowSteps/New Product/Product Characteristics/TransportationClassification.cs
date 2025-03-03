using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationClassification")]

	class TransportationClassification
	{
		[RegexStepDefinition(@"In the Transportation Classification Section, set the option in section: 'Is the product regulated for transport \(before exceptions or exemptions\)' to: (Yes, Agree|No, not regulated for transportation due to an exception|No, not regulated)")]
		public void SelctIsProductRegulatedForTransport(string option)
		{
			string section = "Is the product regulated for transport (before exceptions or exemptions)";
			new Steps_ProductPrototype().InSectionSetOption(section, option);
		}

		[RegexStepDefinition(@"In the Transportation Classification Section, the section: 'Is the product regulated for transport \(before exceptions or exemptions\)' confirm option (is|is not) selected: (Yes, Agree|No, not regulated for transportation due to an exception|No, not regulated)")]
		public void ConfirmOptionSelectedShouldThisProductBeRefrigeratedForTransportSection(string is_isnot, string option)
		{
			string section = "Is the product regulated for transport (before exceptions or exemptions)";
			new Steps_ProductPrototype().InSectionConfirmOptionIsIsNotSelected(section, option, is_isnot);
		}
		[RegexStepDefinition(@"In the Transportation Classification Section, set the option in section: 'Select applicable modes of transport for which you classify the product.': to: (DOT|IMDG|IATA|TDG)")]
		public void SetSelectAllModesOfTransport(string option)
		{
			string section = "Select applicable modes of transport for which you classify the product.";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Transportation Classification Section, set the option for (DOT|IMDG|IATA|TDG) mode of transport to: (Yes, Shipped with Limited quantity|Yes, Shipped with Consumer Commodity|Shipping fully regulated)")]
		public void SetSelectAllModesOfTransport2(string section, string option)
		{
			var MyNewProduct = new StepsNewProduct();
			MyNewProduct.SetTheSectionOptionTo("Select applicable modes of transport for which you classify the product.",
				section);
			new StepsNewProduct().SetTheOptionSubOptionTo(option,
				"Select applicable modes of transport for which you classify the product.", section);
		}
	}
}
