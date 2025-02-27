using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;

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
