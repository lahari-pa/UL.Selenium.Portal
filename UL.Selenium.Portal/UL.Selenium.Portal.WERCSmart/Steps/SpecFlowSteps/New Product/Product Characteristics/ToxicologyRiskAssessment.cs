using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ToxicologyRiskAssesment")]

	internal class ToxicologyRiskAssessment
	{
		[RegexStepDefinition(@"I enter the text of I want a TRA performed on the registration field to: (Yes|No)")]
		public void GivenEnterIWantATRAPerformedOnTheRegistrationValue(string value)
		{
			Report.Info($"I set the text of I want a TRA performed on the registration field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("I want a TRA performed on the registration", value);
		}

		[RegexStepDefinition(@"I enter the text of Toxicology Risk Assessment field to: (.*)")]
		public void GivenEnterToxicologyRiskAssessmentValue(string value)
		{
			Report.Info($"I set the text of Toxicology Risk Assessment field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Toxicological Risk Assessments are an analysis of the Human health risk for specific audiences", value);
		}

		[RegexStepDefinition(@"I enter the text of You've completed the additional information needed for the TRA field to: (.*)")]
		public void GivenEnterYouveCompletedTheAdditionalInformationNeededForTheTRAValue(string value)
		{
			Report.Info($"I set the text of You've completed the additional information needed for the TRA field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("You've completed the additional information needed for the TRA", value);
		}

	}
}
