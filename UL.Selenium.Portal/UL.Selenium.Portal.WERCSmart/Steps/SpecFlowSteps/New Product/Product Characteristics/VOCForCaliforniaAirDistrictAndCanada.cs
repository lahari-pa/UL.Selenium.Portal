using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOCForCaliforniaAirDistrictAndCanada")]
	class WERCSmart_Distributor_NewProducts_VOCForCaliforniaAirDistrictAndCanada
	{
		[StepDefinition(@"In the VOC for California Air District\(s\) and Canada Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: (Yes|No)")]
		public void SetProductHasBennGranted(string option)
		{
			string section = "Product has been granted an ";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the VOC for California Air District\(s\) and Canada Section, set the option in section: 'Product is a Low Solid': to: (Yes|No)")]
		public void SetProductIsALowSolid(string option)
		{
			string section = "Product is a Low Solid";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the VOC for California Air District\(s\) and Canada Section, set the option in section: 'Would you like to use the VOC data provided to be copied for all areas \(e.g. country, state, local\) for comparison\?': to: (Yes|No, I would like to manually enter VOC value for each area.)")]
		public void SetWouldYouLikeToUseTheVOCData(string option)
		{
			string section = "Would you like to use the VOC data provided to be copied for all areas (e.g. country, state, local) for comparison?";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[StepDefinition(@"In the VOC for California Air District\(s\) and Canada Section, set the option in section: 'VOC content of product in g\/L, including water and exempt compounds.': to: (.*)")]
		public void SetVOCContentOfProduct(string option)
		{
			string section = "VOC content of product in g/L, including water and exempt compounds.";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the VOC for California Air District\(s\) and Canada Section, set the option in section: 'VOC content in g\/L contained in this product': to: (.*)")]
		public void SetVOCContentIngL(string option)
		{
			string section = "VOC content in g/L contained in this product";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

	}
}
