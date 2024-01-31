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
		[StepDefinition(@"I upload PDF document to Generic Private Label (all sides) field")]
		public void UploadGenericPrivateLabelAllSides()
		{
			Report.Info($"I upload PDF document to Generic Private Label (all sides) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Generic Private Label (all sides)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Upload SDS (Optional) field")]
		public void UploadSDSOptional()
		{
			Report.Info($"I upload PDF document to Upload SDS (Optional) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Upload SDS (Optional)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}
	}
}
