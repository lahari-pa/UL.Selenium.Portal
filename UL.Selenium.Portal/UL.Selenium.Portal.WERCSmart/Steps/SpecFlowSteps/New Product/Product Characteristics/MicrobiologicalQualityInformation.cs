using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:MicrobiologicalQualityInformation")]
	internal class MicrobiologicalQualityInformation
	{

		[StepDefinition(@"I enter the text of What quantity survived field to: (.*)")]
		public void GivenEnterWhatQuantitySurvivedValue(string value)
		{
			Report.Info($"I set the text of What quantity survived? field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("What quantity survived?", value);
		}

		[StepDefinition(@"I enter the text of Upload Product Studies/Test Results field to: (.*)")]
		public void GivenEnterUploadProductStudiesTestResultsValue(string value)
		{
			Report.Info($"I set the text of Upload Product Studies/Test Results field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Upload Product Studies/Test Results", value);
		}

	}
}
