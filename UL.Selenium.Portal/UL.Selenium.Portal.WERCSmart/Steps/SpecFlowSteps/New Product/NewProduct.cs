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
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct")]
	class WERCSmart_Distributor_NewProducts_ProductType_NewProduct
	{
		[RegexStepDefinition(@"In the New Product Section, set the radio option in section: 'Select the type of product to create': to: (Create a New Registration|Copy from an Existing Registration|Request a UPC from a Manufacturer)")]
		public void SelectProductTypeToCreate(string option)
		{
			string section = "Select the type of product to create";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
	}
}
