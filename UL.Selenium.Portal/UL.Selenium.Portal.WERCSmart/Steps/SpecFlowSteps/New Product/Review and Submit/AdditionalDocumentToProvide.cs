using NPOI.POIFS.Crypt.Dsig;
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
		
		[StepDefinition(@"I upload PDF document to Upload SDS (Optional) field")]
		public void UploadPDFDocumentToOSHACompliantSafetyDataSheetOptionalValue()
		{
			Report.Info($"I upload PDF document to OSHA-compliant Safety Data Sheet (Optional) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("OSHA-compliant Safety Data Sheet (Optional)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Upload SDS (Optional) field")]
		public void UploadPDFDocumentToFullProductLabelRequired()
		{
			Report.Info($"I upload PDF document to Upload Full Product Label (required)  field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Upload Full Product Label (required) ", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}
	}
}
