using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails2")]

	class WERCSmart_Distributor_NewProducts_TransportationDetails2
	{

		[RegexStepDefinition(@"In the Transportation Details 2 Section, set the option in section: 'International Shipping when DOT Exemption taken\?': to: (I do not ship internationally but I do know the classification|I do not ship internationally and I do not know the classification)")]
		public void SetInternationalShippingWhenDOTExemptionTaken(string option)
		{
			string section = "International Shipping when DOT Exemption taken?";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[RegexStepDefinition(@"In the Transportation Details 2 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: (IMDG|IATA|TDG)")]
		public void SelectAllModesOfTransportThatYouClassifieldTheProduct(string option)
		{
			string section = "Select all modes of transport that you've classified the product for";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Transportation Details 2 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: (Shipping with limited quantity|Shipping with consumer commodity|Shipping fully regulated)")]
		public void SelectAllModesOfTransportThatYouClassifieldTheProductFor(string option)
		{
			string section = "Select all modes of transport that you've classified the product for";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

	}
}
