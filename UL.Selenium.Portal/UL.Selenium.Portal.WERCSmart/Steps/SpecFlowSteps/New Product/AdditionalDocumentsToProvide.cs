using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide")]
	internal class AdditionalDocumentsToProvide
	{
		[StepDefinition(@"I enter the text of Generic Private Label (all sides) field to: (.*)")]
		public void GivenEnterGenericPrivateLabelAllSidesValue(string value)
		{
			Report.Info($"I set the text of Generic Private Label (all sides) field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Generic Private Label (all sides)", value);
		}

		[StepDefinition(@"I enter the text of Upload SDS (Optional) field to: (.*)")]
		public void GivenEnterUploadSDSOptionalValue(string value)
		{
			Report.Info($"I set the text of Upload SDS (Optional) field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Upload SDS (Optional)", value);
		}
	}
}
