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

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "RegulatoryInformation3")]
	class RegulatoryInformation3
	{
		[RegexStepDefinition(@"In the Regulatory Information 3 Section, in section: 'Refer to your Product Label.  From the options, select those that appear on the Label.' click the checkbox option: (Drug Facts Panel|Supplement Facts Panel|Nutrition Facts Panel|None of the Above)")]
		public void SelectProductLabel(string option)
		{
			string section = "Refer to your Product Label.  From the options, select those that appear on the Label.";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}


		[RegexStepDefinition(@"In the Regulatory Information 3 Section, the following link: (OTC Drug Facts Label \(may include Active Ingredient\)|Nutritional and Supplement Labels|Dietary Supplements Label) (should|should not) be displayed")]
		public void Regulatory3LinkExists(string linkText, string condition)
		{
			new Steps_Prototype().LinkElementExists(condition, linkText);
		}

		[RegexStepDefinition(@"In the Regulatory Information 3 Section, click the following link: (OTC Drug Facts Label \(may include Active Ingredient\)|Nutritional and Supplement Labels|Dietary Supplements Label)")]
		public void Regulatory3ClickLinks(string linkText)
		{
			new Steps_Prototype().ClickLinkElement(linkText);
		}

		[RegexStepDefinition(@"In the Regulatory Information 3 Section, the error 'Please select at least one option from above.' (is|is not) displayed for section 'Refer to your Product Label. From the options, select those that appear on the Label.'")]
		public void Regulatory3ErrorIsIsNotDisplayed(string is_isnot)
		{
			string section = "Refer to your Product Label.  From the options, select those that appear on the Label.";
			string error = "Please select at least one option from above.";
			new Steps_ProductPrototype().InSectionErrorMessageIsIsNotDisplayed(section, error, is_isnot);
		}

		[RegexStepDefinition(@"In the Regulatory Information 3 Section, the statement 'Based on the product's recommended use and formulation, this is a possible Nutritional Supplement. Please complete the additional question below to ensure proper classification of this product for the retailer\(s\).' (is|is not) displayed'")]
		public void Regulatory3TextIsIsNotDisplayed(string is_isnot)
		{
			string text = "Based on the product's recommended use and formulation, this is a possible Nutritional Supplement. Please complete the additional question below to ensure proper classification of this product for the retailer(s).\r\n";
		}



	}
}
