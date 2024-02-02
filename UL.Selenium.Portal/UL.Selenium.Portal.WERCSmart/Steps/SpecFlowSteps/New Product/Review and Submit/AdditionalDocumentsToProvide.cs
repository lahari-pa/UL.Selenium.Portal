using NPOI.SS.Formula.Atp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide")]
	internal class AdditionalDocumentsToProvide
	{
		[StepDefinition(@"I upload PDF document to Generic Private Label (all sides) field")]
		public void UploadPDFDocumentToGenericPrivateLabelAllSides()
		{
			Report.Info($"I upload PDF document to Generic Private Label (all sides) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Generic Private Label (all sides)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Upload SDS (Optional) field")]
		public void UploadPDFDocumentToSDSOptional()
		{
			Report.Info($"I upload PDF document to Upload SDS (Optional) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Upload SDS (Optional)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to International Fragrance Association (IFRA) field")]
		public void UploadPDFDocumentToInternationalFragranceAssociationIFRA()
		{
			Report.Info($"I upload PDF document to International Fragrance Association (IFRA) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("International Fragrance Association (IFRA)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Generally Recognized as Safe (GRAS) field")]
		public void UploadPDFDocumentToGenerallyRecognizedAsSafeGRAS()
		{
			Report.Info($"I upload PDF document to Generally Recognized as Safe (GRAS) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Generally Recognized as Safe (GRAS)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Toxicity Characteristic Leaching Procedure (TCLP) field")]
		public void UploadPDFDocumentToToxicityCharacteristicLeachingProcedureTCLP()
		{
			Report.Info($"I upload PDF document to Toxicity Characteristic Leaching Procedure (TCLP) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Toxicity Characteristic Leaching Procedure (TCLP)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}
	}
}
