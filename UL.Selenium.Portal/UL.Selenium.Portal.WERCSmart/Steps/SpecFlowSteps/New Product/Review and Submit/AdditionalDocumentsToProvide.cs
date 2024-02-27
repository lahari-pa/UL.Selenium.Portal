using NPOI.SS.Formula.Atp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;
using static NPOI.HSSF.Util.HSSFColor;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide")]
	internal class AdditionalDocumentsToProvide
	{
		[StepDefinition(@"I upload PDF document to Packaged Product Photo \(front and back\) field")]
		public void UploadPDFDocumentToPackagedProductPhotoFrontAndBack()
		{
			Report.Info($"I upload PDF document to Packaged Product Photo (front and back) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Packaged Product Photo (front and back)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Product Photo field")]
		public void UploadPDFDocumentToProductPhoto()
		{
			Report.Info($"I upload PDF document to Product Photo field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Product Photo", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Flash Point Testing Report field")]
		public void UploadPDFDocumentToFlashPointTestingReport()
		{
			Report.Info($"I upload PDF document to Flash Point Testing Report field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Flash Point Testing Report", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Upload SDS \(Optional\) field")]
		public void UploadPDFDocumentToOSHACompliantSafetyDataSheetOptionalValue()
		{
			Report.Info($"I upload PDF document to OSHA-compliant Safety Data Sheet (Optional) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("OSHA-compliant Safety Data Sheet (Optional)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to International Fragrance Association \(IFRA\) field")]
		public void UploadPDFDocumentToInternationalFragranceAssociationIFRA()
		{
			Report.Info($"I upload PDF document to International Fragrance Association (IFRA) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("International Fragrance Association (IFRA)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Generally Recognized as Safe \(GRAS\) field")]
		public void UploadPDFDocumentToGenerallyRecognizedAsSafeGRAS()
		{
			Report.Info($"I upload PDF document to Generally Recognized as Safe (GRAS) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Generally Recognized as Safe (GRAS)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Toxicity Characteristic Leaching Procedure \(TCLP\) field")]
		public void UploadPDFDocumentToToxicityCharacteristicLeachingProcedureTCLP()
		{
			Report.Info($"I upload PDF document to Toxicity Characteristic Leaching Procedure (TCLP) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Toxicity Characteristic Leaching Procedure (TCLP)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Upload Volatile Organic Compounds field")]
		public void UploadPDFDocumentToVolatileOrganicCompoundsRequired()
		{
			Report.Info($"I upload PDF document to Upload Volatile Organic Compounds field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Volatile Organic Compounds", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Upload Full Product Label \(required\) field")]
		public void GivenIUploadPDFDocumentToUploadFullProductLabelRequiredField()
		{
			Report.Info($"I upload PDF document to Upload Full Product Label (required) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Upload Full Product Label (required)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Provide Full Product Label \(required\) field")]
		public void UploadPDFDocumentToProvideFullProductLabelRequired()
		{
			Report.Info($"I upload PDF document to Provide Full Product Label (required) field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Provide Full Product Label (required)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to California Air Resources Board \(CARB\) Executive Order field")]
		public void UploadPDFDocumentToCaliforniaAirResourcesBoardCARBExecutiveOrder()
		{
			Report.Info($"I upload PDF document to California Air Resources Board (CARB) Executive Order field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("California Air Resources Board (CARB) Executive Order", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[StepDefinition(@"I upload PDF document to Upload Transportation Exemption Letter or Special Permit field")]
		public void UploadPDFDocumentToTransportationExemptionLetterOrSpecialPermitRequired()
		{
			Report.Info($"I upload PDF document to Upload Transportation Exemption Letter or Special Permit  field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Transportation Exemption Letter or Special Permit", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}
	}
}
