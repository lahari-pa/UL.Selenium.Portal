using NPOI.SS.Formula.Atp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Characteristics;
using static NPOI.HSSF.Util.HSSFColor;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide")]
	internal class AdditionalDocumentsToProvide
	{
		[RegexStepDefinition(@"In the Additional Documents to Provide Section, upload PDF document to Packaged Product Photo \(front and back\) field")]
		public void UploadPDFDocumentToPackagedProductPhotoFrontAndBack()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Packaged Product Photo (front and back)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide Section, upload PDF document to Product Photo field")]
		public void UploadPDFDocumentToProductPhoto()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Product Photo", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide Section, upload PDF document to Flash Point Testing Report field")]
		public void UploadPDFDocumentToFlashPointTestingReport()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Flash Point Document", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide Section, upload PDF document to Upload SDS \(Optional\) field")]
		public void UploadPDFDocumentToOSHACompliantSafetyDataSheetOptionalValue()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("OSHA SDS", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide Section, upload PDF document to International Fragrance Association \(IFRA\) field")]
		public void UploadPDFDocumentToInternationalFragranceAssociationIFRA()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("International Fragrance Association (IFRA)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide Section, upload PDF document to Generally Recognized as Safe \(GRAS\) field")]
		public void UploadPDFDocumentToGenerallyRecognizedAsSafeGRAS()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Generally Recognized as Safe (GRAS)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide Section, upload PDF document to Toxicity Characteristic Leaching Procedure \(TCLP\) field")]
		public void UploadPDFDocumentToToxicityCharacteristicLeachingProcedureTCLP()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Toxicity Characteristic Leaching Procedure (TCLP)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide Section, upload PDF document to Upload Volatile Organic Compounds field")]
		public void UploadPDFDocumentToVolatileOrganicCompoundsRequired()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Product Label", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide Section, upload PDF document to Upload Full Product Label \(required\) field")]
		public void GivenIUploadPDFDocumentToUploadFullProductLabelRequiredField()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Product Label", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide Section, upload PDF document to Generic Private Label \(all sides\) field")]
		public void GivenIUploadPDFDocumentToGenericPrivateLabelAllSidesField()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Product Label", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide Section, upload PDF document to Provide Full Product Label \(required\) field")]
		public void UploadPDFDocumentToProvideFullProductLabelRequired()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Please upload a PDF of the product label (full label).", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide Section, upload PDF document to California Air Resources Board \(CARB\) Executive Order field")]
		public void UploadPDFDocumentToCaliforniaAirResourcesBoardCARBExecutiveOrder()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("California Air Resources Board (CARB) Executive Order", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide Section, upload PDF document to Upload Transportation Exemption Letter or Special Permit field")]
		public void UploadPDFDocumentToTransportationExemptionLetterOrSpecialPermitRequired()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Exemption Letter", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide Section, for section (.*) button View (should|should not) exists")]
		public void InTheAdditionalDocumentsToProviveCheckButtonViewForSection(string section, string condition)
		{
			string button = "view";
			new Steps_Prototype().CheckButtonExistsForSection(section, condition, button);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide Section, for section (.*) button Remove (should|should not) exists")]
		public void InTheAdditionalDocumentsToProvideCheckButtonRemoveForSection(string section, string condition)
		{
			string button = "remove";
			new Steps_Prototype().CheckButtonExistsForSection(section, condition, button);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide Section, for section (.*) I click button 'View'")]
		public void InTheAdditionalDocumentsToProvideClickViewButtonForSection(string section)
		{
			string button = "view";
			new Steps_Prototype().ClickButtonForSection(section, button);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide Section, after clicking 'View' button I confirm pdf file is downloaded")]
		public void InTheAdditionalDocumentsToProvideAfterClickingViewPdfIsDownloaded()
		{
			string file = "testdoc.pdf";
			string savedAs = "downloadedFile";
			new Steps_Prototype().ConfirmFileAppearsInDownloadsFolder(file, savedAs);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'OSHA-compliant Safety Data Sheet \(Optional\)' (is|is not) displayed")]
		public void ThenInTheAdditionalDocumentsToProvideSectionOSHAIsDisplayed(string condition)
		{
			string section = "OSHA-compliant Safety Data Sheet (Optional)";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'Flash Point Testing Report' (is|is not) displayed")]
		public void ThenInTheAdditionalDocumentsToProvideSectionFlashPointIsDisplayed(string condition)
		{
			string section = "Flash Point Testing Report";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'Toxicity Characteristic Leaching Procedure \(TCLP\)' (is|is not) displayed")]
		public void ThenInTheAdditionalDocumentsToProvideSectionTCLPIsIsNotDisplayed(string condition)
		{
			string section = "Toxicity Characteristic Leaching Procedure (TCLP)";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'Upload SDS \(Optional\)' (is|is not) displayed")]
		public void ThenInTheAdditionalDocumentsToProvideSectionUploadSDSIsIsNotDisplayed(string condition)
		{
			string section = "Upload SDS (Optional)";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide Section: 'Provide Full Product Label \(required\)' error message (should|should not) display: (.*)")]
		public void UploadFileForProductLabelShouldShouldNotDisplayError(string shouldShouldNot, string pipeDelimitedErrorMessages)
		{
			string section = "Provide Full Product Label (required)";
			new Steps_Prototype().ErrorMessagesAreShowingForItem(section, shouldShouldNot, pipeDelimitedErrorMessages);
		}

	}
}
