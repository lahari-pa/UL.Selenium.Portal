using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:NewProduct")]
	class WERCSmart_Distributor_NewProducts_ProductType_NewProduct
	{
		[RegexStepDefinition(@"In the New Product Section, set the radio option in section: 'Select the type of product to create': to: '(Create Formulated Registration using SDS Import|Create Formulated Registration|Create an Article Registration|Create a Registration by Copying an Existing Registration)'")]
		public void SelectProductTypeToCreate(string option)
		{
			string section = "Select the type of product to create:";
			new Steps_ProductPrototype().InSectionSetOption(section, option);
		}
		[RegexStepDefinition(@"In the New Product Section, set the radio option in section: 'Would you like to Create a New Product\?': to: (Yes, create a new product)")]
		public void SelectProductTypeToCreatePharma(string option)
		{
			string section = "Would you like to Create a New Product?";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[RegexStepDefinition(@"In the New Product Section, confirm for section: 'Please select the source product' error (is|is not) displayed: (.*)")]
		public void PleaseSelectTheSourceErrorIsIsNotDisplayed(string is_isnot, string error)
		{
			string section = "Please select the source product";
			new Steps_ProductPrototype().InSectionErrorMessageIsIsNotDisplayed(section, error, is_isnot);
		}
	}
}
