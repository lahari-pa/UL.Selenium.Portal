using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationRefrigeration")]

	class TransportationRefrigeration
	{
		[RegexStepDefinition(@"In the Transportation - Refrigeration Section, set the option in section: 'Should this product be refrigerated for transport or storage\?' to: (Yes|No)")]
		public void SelectShouldThisProductBerefrigerated(string option)
		{
			string section = "Should this product be refrigerated for transport or storage?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Temperature Requirements for Storage and Transport Section, set the option in section: 'Does the product have temperature storage requirements\?' to: (Yes|No)")]
		public void DoesThisProductBerefrigerated(string option)
		{
			string section = "Does the product have temperature storage requirements?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}
