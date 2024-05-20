using System;
using System.Reflection;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Classes;
using Reqnroll;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps;
using System.Linq;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TheProduct")]
	class WERCSmart_Distributor_NewProducts_ProductType_TheProduct
	{
		[RegexStepDefinition(@"In the Product Section, set the option in section: 'Product Name as it appears on the Packaging Label, Container or Safety Data Sheet \(SDS\)' to: (.*)")]
		public void SelectProductNameAsItAppearsOnPackagingLabel(string option)
		{
			string section = "Product Name as it appears on the Packaging Label, Container or Safety Data Sheet (SDS)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Section, set the option in section: 'Product Line or Brand \(optional\)' to: (.*)")]
		public void SelectProductLineOrBrand(string option)
		{
			string section = "Product Line or Brand (optional)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Section, set the option in section: 'Product Identification \(Optional\)' to: (.*)")]
		public void SelectProductIdentification(string option)
		{
			string section = "Product Identification (Optional)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Section, set the option in section: 'Type of Product \(select\)' to: (.*)")]
		public void SelectTypeOfProduct(string option)
		{
			string section = "Type of Product (select)";
			Steps_ProductPrototype productPrototype = new Steps_ProductPrototype();
			//new Steps_Prototype().SetTheSectionOptionTo(section, option);
			productPrototype.InSectionClickSearchText(section);
			productPrototype.InSearchPopUpSearchAndSelect(option);
		}

		[RegexStepDefinition(@"In the Product Section, click 'Add new Product Line/Brand name' link")]
		public void ClickLinkAddNewProductLineBrandName()
		{
			string linkText = "Add new Product Line/Brand name";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
	}
}
