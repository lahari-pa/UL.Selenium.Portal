using System;
using System.Reflection;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Classes;
using Reqnroll;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:DistributorRequestUPCSection")]
	class WERCSmart_Distributor_NewProducts_ProductType_DistributorRequestUPCSection
	{
		[RegexStepDefinition(@"In the New Product Section, in section: 'Enter Manufacturer's Contact Email': set option to to: (.*)")]
		public void DistributorRequestUPCSectionEmailSetOption(string option)
		{
			string section = "Enter Manufacturer's Contact Email";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the New Product Section, in section: 'Provide Manufacturer's Uniform Product Code /(UPC/) for the Product': set option to to: (.*)")]
		public void DistributorRequestUPCSectionManufacturerSetOption(string option)
		{
			string section = "Enter Manufacturer's Contact Email";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the New Product Section, in section: 'Product Name': set option to to: (.*)")]
		public void DistributorRequestUPCSectionProductNameSetOption(string option)
		{
			string section = "Enter Manufacturer's Contact Email";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
	}
}
