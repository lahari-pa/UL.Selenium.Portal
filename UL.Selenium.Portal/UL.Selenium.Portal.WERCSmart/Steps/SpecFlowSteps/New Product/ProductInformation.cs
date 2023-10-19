using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation")]
	internal class ProductInformation
	{
		[StepDefinition(@"In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25\(b\) Exempt' to: (Product is intended for preventing, destroying, repelling, or mitigating pests \(including insects, rodents, mold, virus, bacteria, and other micro-organisms\)|Product is intended for use as a plant regulator \(controls growth\), defoliant \(removes leaves\), or desiccant \(dehydrates plants to control growth\)|Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description \(ex. kills, sterilizes, disinfects, sanitizes, antimicrobial\))")]
		public void SelectFefra25Exemp(string option)
		{
			string section = "Which best describes your product, including when FIFRA 25(b) Exempt";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}

		[StepDefinition(@"In the Product Information Section, set the option in section: 'Product has been classified using OSHA \(US\) Globally Harmonized Standards \(GHS\) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards \(Canada\)' to: (Yes|No)")]
		public void SelectOSHAGloballyHarmonizedStandards(string option)
		{
			string section = "Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: (Yes|No)")]
		public void SelectProductIsShippedDirectly(string option)
		{
			string section = "Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: (Yes|No)")]
		public void SelectProductsMustComplyWithCaliforniaCleaningProductRighttoKnowAct(string option)
		{
			string section = "Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Product Information Section, set the option in section: 'Select countries the product may be sold in' to: (United States|Canada))")]
		public void SelectCountriesTheProductMayBeSold(string option)
		{
			string section = "Select countries the product may be sold in";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}
