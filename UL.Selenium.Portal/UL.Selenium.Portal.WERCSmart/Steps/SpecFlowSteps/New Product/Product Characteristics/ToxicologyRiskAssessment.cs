using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ToxicologyRiskAssesment")]

	internal class ToxicologyRiskAssessment
	{
		[StepDefinition(@"I enter the text of I want a TRA performed on the registration field to: (Yes|No)")]
		public void GivenEnterIWantATRAPerformedOnTheRegistrationValue(string value)
		{
			Report.Info($"I set the text of I want a TRA performed on the registration field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("I want a TRA performed on the registration", value);
		}
	}
}
