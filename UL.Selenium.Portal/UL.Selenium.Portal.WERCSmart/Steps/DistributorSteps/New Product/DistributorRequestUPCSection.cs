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
	[Binding, Scope(Tag = "Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ProductType_Section:DistributorRequestUPCSection")]
	class WERCSmart_Distributor_NewProducts_ProductType_DistributorRequestUPCSection
	{
		[StepDefinition(@"In the New Product Section, in section: '(Enter Manufacturer's Contact Email)': set option to to: (.*)")]
		[StepDefinition(@"In the New Product Section, in section: '(Provide Manufacturer's Uniform Product Code (UPC) for the Product)': set option to to: (.*)")]
		[StepDefinition(@"In the New Product Section, in section: '(Product Name)': set option to to: (.*)")]
		public void DistributorRequestUPCSectionSetOption(string section, string option)
		{
			var thisNewProduct = new NewProduct();
			Report.IsTrue(thisNewProduct.SetOptionInSection(section.Trim(), option.Trim()),
					$"Failed to set the input to {option.Trim()} in section: {section.Trim()}",
					$"Successfully set the input to {option.Trim()} in section: {section.Trim()}");
			Delay.Seconds(1);
		}
	}
}
