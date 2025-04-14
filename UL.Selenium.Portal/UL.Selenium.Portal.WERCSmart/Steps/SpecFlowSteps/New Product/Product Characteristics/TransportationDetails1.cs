using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:TransportationDetails1")]
	class WERCSmart_Distributor_NewProducts_TransportationDetails1
	{
		[RegexStepDefinition(@"In the Transportation Details 1 Section, set the option in section: 'Product is Regulated for Transport': to: (Yes|No, due to an exemption or exception|Not Regulated)")]
		public void SetProductIsRegulatedForTransport(string option)
		{
			string section = "Product is Regulated for Transport";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[RegexStepDefinition(@"In the Transportation Details 1 Section, set the option in section: 'Select all modes of transport that you've classified the product for': to: (DOT|IMDG|IATA|TDG)")]
		public void SetSelectAllModesOfTransport(string option)
		{
			string section = "Select all modes of transport that you've classified the product for";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Transportation Details 1 Section, set the option for (DOT|IMDG|IATA|TDG) mode of transport to: (Shipping with limited quantity|Shipping fully regulated|Shipping with consumer commodity)")]
		public void SetSelectAllModesOfTransport2(string section, string option)
		{
			var MyNewProduct = new StepsNewProduct();
			MyNewProduct.SetTheSectionOptionTo("Select all modes of transport that you've classified the product for",
				section);
			new StepsNewProduct().SetTheOptionSubOptionTo(option,
				"Select all modes of transport that you've classified the product for", section);
		}
		[RegexStepDefinition(@"In the Transportation Details 1 Section, set the option in section: 'Provide Special Permit numbers \(if applicable\)': to: (.*)")]
		public void SetProvideSpecialPermitNumbers(string option)
		{
			string section = "Provide Special Permit numbers (if applicable)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Transportation Details 1 Section, set the option in section: 'Please select DOT Exceptions if applicable\?': to: (.*)")]
		public void SetSelectDOTExceptions(string option)
		{
			string section = "Please select DOT Exceptions if applicable?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Transportation Details 1 Section, set the option in section: 'Other DOT Exception': to: (.*)")]
		public void SetOtherDOTExceptions(string option)
		{
			string section = "Other DOT Exception";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Transportation Details 1 page the 'Other DOT Exception' question (is|is not) displayed")]
		public void ThenInTheTransportationDetailsPageOtherDOTExceptionsIfApplicableQuestionIsDisplayed(string is_isnot)
		{
			string section = "Other DOT Exception";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}
		[RegexStepDefinition(@"In the Transportation Details 1 Section, verify in 'Product is Regulated for Transport' section (is|is not) option: (.*)")]
		public void ThenInTheTransportationDetailsSectionVerifyInSectionIsOptionYes(string is_isnot, string option)
		{
			string section = "Product is Regulated for Transport";
			new Steps_ProductPrototype().InSectionVerifyOption(section, option, is_isnot);
		}
		[RegexStepDefinition(@"In the Transportation Details 1 Section, verify in 'Please select DOT Exceptions if applicable\?' section (is|is not) option: (.*)")]
		public void ThenInTheTransportationDetailsSectionVerifyInSectionOptions(string is_isnot, string option)
		{
			string section = "Please select DOT Exceptions if applicable?";
			new Steps_ProductPrototype().InSectionVerifyOption(section, option, is_isnot);
		}
		[RegexStepDefinition(@"In the Transportation Details 1 page the 'Please select DOT Exceptions if applicable\?' question (is|is not) displayed")]
		public void ThenInTheTransportationDetailsPageThePleaseSelectDOTExceptionsIfApplicableQuestionIsDisplayed(string is_isnot)
		{
			string section = "Please select DOT Exceptions if applicable?";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}
		[RegexStepDefinition(@"In the Transportation Details 1 Section, verify in 'Please select DOT Exceptions if applicable\?' section the error message (should|should not) be displayed: (.*)")]
		public void ThenInTheTransportationDetailsSectionExceptionsVerifyErrorMessage(string should_shouldnot, string pipeDelimitedErrorMessages)
		{
			string section = "Please select DOT Exceptions if applicable?";
			new Steps_Prototype().ErrorMessagesAreShowingForItem(section, should_shouldnot, pipeDelimitedErrorMessages);
		}
		[RegexStepDefinition(@"In the Transportation Details 1 Section, for section 'Product is Regulated for Transport': the following options (should|should not) be (displayed|displayed exclusively):")]
		public void CheckOptionsInProductIsRegulatedForTransportSection(string condition, string displayed, Table table)
		{

			string section = "Product is Regulated for Transport";
			new Steps_Prototype().CheckOptionsInSection(condition, displayed, section, table);
		}
		[RegexStepDefinition(@"In the Transportation Details 1 Section, the error 'This is a required field' (is|is not) displayed for section 'Product is Regulated for Transport'")]
		public void ProductIsRegulatedForTransportErrorIsIsNotDisplayed(string is_isnot)
		{
			string section = "Product is Regulated for Transport";
			string error = "This is a required field";
			new Steps_ProductPrototype().InSectionErrorMessageIsIsNotDisplayed(section, error, is_isnot);
		}
		[RegexStepDefinition(@"In the Transportation Details 1 page the 'Provide Special Permit numbers \(if applicable\)' question (is|is not) displayed")]
		public void ThenInTheTransportationDetailsPageProvideSpecialPermitNumbersQuestionIsDisplayed(string is_isnot)
		{
			string section = "Provide Special Permit numbers (if applicable)";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}


	}
}
