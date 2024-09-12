using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.ReqnrollHelpers.Attributes;

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
	}
}
