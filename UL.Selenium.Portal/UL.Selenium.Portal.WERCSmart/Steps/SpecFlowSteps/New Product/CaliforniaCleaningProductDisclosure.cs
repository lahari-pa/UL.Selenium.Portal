using System;
using System.Reflection;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:CaliforniaCleaningProductDisclosure")]
	class WERCSmart_Distributor_NewProducts_ProductType_CaliforniaCleaningProductDisclosure
	{
		[StepDefinition(@"In the California Cleaning Product Disclosure Section, set the radio option in section: 'Who is publicly identified on the product label as responsible for the product?': to: (Manufacturer|Final Domestic Distributor)")]
		public void SelectPublicResponsibilityForProduct(string option)
		{
			string section = "Who is publicly identified on the product label as responsible for the product?";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}

		[StepDefinition(@"In the California Cleaning Product Disclosure Section, set the option in section: 'Who is the Final Domestic Distributor \(if any\) of the product?' to: (.*)")]
		public void SetFinalDomesticDistributor(string option)
		{
			string section = "Who is the Final Domestic Distributor (if any) of the product?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[StepDefinition(@"In the California Cleaning Product Disclosure Section, set the option in section: 'Is your identity, as the Manufacturer of this product, Confidential Business Information \(CBI\)?' to: (Yes|No)")]
		public void SelectIsIdentityCBI(string option)
		{
			string section = "Is your identity, as the Manufacturer of this product, Confidential Business Information (CBI)?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[StepDefinition(@"In the California Cleaning Product Disclosure Section, set the option in section: 'Company's Toll-Free Phone Number' to: (.*)")]
		public void SetCompanyPhoneNumber(string option)
		{
			string section = "Company's Toll-Free Phone Number";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[StepDefinition(@"In the California Cleaning Product Disclosure Section, set the option in section: 'Company Web Address' to: (.*)")]
		public void SetCompanyWebAddress(string option)
		{
			string section = "Company Web Address";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[StepDefinition(@"In the California Cleaning Product Disclosure Section, set the option in section: 'Select the product's GTIN Brick Code' to: (.*)")]
		public void SetGTINBrickCode(string option)
		{
			string section = "Select the product's GTIN Brick Code";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}
