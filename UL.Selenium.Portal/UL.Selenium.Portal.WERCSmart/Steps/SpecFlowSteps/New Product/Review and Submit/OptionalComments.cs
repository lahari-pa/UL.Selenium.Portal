using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:OptionalComments")]
	class WERCSmart_Distributor_NewProducts_ReviewAndSubmit_OptionalComments
	{
		[RegexStepDefinition(@"In the Optional Comments Section, set the option in section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' to: (.*)")]
		public void SetOptionalComments(string option)
		{
			string section = "Provide any additional comments or information about the product that you want the Assessment Team to know.";
			new Steps_ProductPrototype().InSectionEnterText(section, option);
		}
		[RegexStepDefinition(@"In the Optional Comments Section, section: 'Provide any additional comments or information about the product that you want the Assessment Team to know.' (is|is not) available")]
		public void OptionalCommentsSectionIsAvailable(string is_isnot)
		{
			string section = "Provide any additional comments or information about the product that you want the Assessment Team to know.";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}
	}
}
