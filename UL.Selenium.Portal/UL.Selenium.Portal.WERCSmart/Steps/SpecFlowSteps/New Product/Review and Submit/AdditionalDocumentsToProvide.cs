using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:AdditionalDocumentsToProvide")]
	internal class AdditionalDocumentsToProvide
	{
		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document to Packaged Product Photo \(front and back\) field")]
		public void UploadPDFDocumentToPackagedProductPhotoFrontAndBack()
		{
			var selNewProduct = new Steps_Prototype();
			string section = "Packaged Product Photo (front and back)";
			string pdfFile = "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			selNewProduct.UploadPDFFile("Packaged Product Photo (front and back)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document to Product Photo field")]
		public void UploadPDFDocumentToProductPhoto()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Product Photo", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document to Flash Point Testing Report field")]
		public void UploadPDFDocumentToFlashPointTestingReport()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Flash Point Document", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document to 'OSHA-compliant Safety Data Sheet \(Optional\)' field")]
		public void UploadPDFDocumentToOSHACompliantSafetyDataSheetOptionalValue()
		{
			var selNewProduct = new Steps_Prototype();
			string section = "OSHA-compliant Safety Data Sheet (Optional)";
			selNewProduct.UploadPDFFileSectionAndLabel(section,"", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document to International Fragrance Association \(IFRA\) field")]
		public void UploadPDFDocumentToInternationalFragranceAssociationIFRA()
		{
			var selNewProduct = new Steps_Prototype();
			string section = "IFRA Certificate (Perfumery Products)";
			string pdfFile = "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			selNewProduct.UploadPDFFile(section, pdfFile);
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document to Generally Recognized as Safe \(GRAS\) field")]
		public void UploadPDFDocumentToGenerallyRecognizedAsSafeGRAS()
		{
			var selNewProduct = new Steps_Prototype();
			string section = "GRAS Certificate (Flavor Products)";
			string pdfFile = "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			selNewProduct.UploadPDFFile(section, pdfFile);
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document to Toxicity Characteristic Leaching Procedure \(TCLP\) field")]
		public void UploadPDFDocumentToToxicityCharacteristicLeachingProcedureTCLP()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Toxicity Characteristic Leaching Procedure (TCLP)", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document for section: Volatile Organic Compounds - Product Label")]
		public void UploadPDFDocumentToVolatileOrganicCompoundsRequired()
		{
			var selNewProduct = new Steps_Prototype();
			string label = "Product Label";
			string section = "Volatile Organic Compounds";
			string pdfFile = "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			selNewProduct.UploadPDFFileSectionAndLabel(section,label, pdfFile);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document for section: Volatile Organic Compounds - VOC Exemption Letter")]
		public void UploadPDFDocumentToVOCExemptionLetter()
		{
			var selNewProduct = new Steps_Prototype();
			string section = "VOC Exemption Letter";
			string pdfFile = "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			selNewProduct.UploadPDFFile(section, pdfFile);
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document to Upload Full Product Label \(required\) field")]
		public void GivenIUploadPDFDocumentToUploadFullProductLabelRequiredField()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Product Label", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document to Generic Private Label \(all sides\) field")]
		public void GivenIUploadPDFDocumentToGenericPrivateLabelAllSidesField()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Product Label", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document to Provide Full Product Label \(required\) field")]
		public void UploadPDFDocumentToProvideFullProductLabelRequired()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Please upload a PDF of the product label (full label).", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document to California Air Resources Board \(CARB\) Executive Order field")]
		public void UploadPDFDocumentToCaliforniaAirResourcesBoardCARBExecutiveOrder()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("California Air Resources Board (CARB) Executive Order", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the Additional Documents to Provide, upload PDF document to Upload Transportation Exemption Letter or Special Permit field")]
		public void UploadPDFDocumentToTransportationExemptionLetterOrSpecialPermitRequired()
		{
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Exemption Letter", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, for section (.*) button View (should|should not) exists")]
		public void InTheAdditionalDocumentsToProviveCheckButtonViewForSection(string section, string condition)
		{
			string button = "view";
			new Steps_Prototype().CheckButtonExistsForSection(section, condition, button);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, for section 'OSHA-compliant Safety Data Sheet \(Optional\)' the button 'View' (should|should not) exists")]
		public void InTheAdditionalDocumentsToProviveCheckButtonViewForSectionandLabel(string condition)
		{
			string section = "OSHA-compliant Safety Data Sheet (Optional)";
			string label = "";
			string button = "view";
			new Steps_Prototype().CheckButtonExistsForSectionandLabel(section, label, condition, button);
		} 
		[RegexStepDefinition(@"In the Additional Documents to Provide, for section (.*) button Remove (should|should not) exists")]
		public void InTheAdditionalDocumentsToProvideCheckButtonRemoveForSection(string section, string condition)
		{
			string button = "remove";
			new Steps_Prototype().CheckButtonExistsForSection(section, condition, button);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, for section 'OSHA-compliant Safety Data Sheet \(Optional\)' the button 'Remove' (should|should not) exists")]
		public void InTheAdditionalDocumentsToProvideCheckButtonRemoveForSectionandLabel(string condition)
		{
			string section = "OSHA-compliant Safety Data Sheet (Optional)";
			string label = "";
			string button = "remove";
			new Steps_Prototype().CheckButtonExistsForSectionandLabel(section, label, condition, button);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, for section (.*) I click button 'View'")]
		public void InTheAdditionalDocumentsToProvideClickViewButtonForSection(string section)
		{
			string button = "view";
			new Steps_Prototype().ClickButtonForSection(section, button);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, for the section 'OSHA-compliant Safety Data Sheet \(Optional\)', I click the 'View' button")]
		public void InTheAdditionalDocumentsToProvideClickViewButtonForSectionandLabel()
		{
			string section = "OSHA-compliant Safety Data Sheet (Optional)";
			string label = "";
			string button = "view";
			new Steps_Prototype().ClickButtonForSectionandLabel(section,label, button);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, after clicking 'View' button I confirm pdf file is downloaded")]
		public void InTheAdditionalDocumentsToProvideAfterClickingViewPdfIsDownloaded()
		{
			string file = "testdoc.pdf";
			string savedAs = "downloadedFile";
			new Steps_Prototype().ConfirmFileAppearsInDownloadsFolder(file, savedAs);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'OSHA-compliant Safety Data Sheet \(Optional\)' (is|is not) displayed")]
		public void OSHACompliantIsDisplayed(string condition)
		{
			string section = "OSHA-compliant Safety Data Sheet (Optional)";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'Safety Data Sheet \(Optional\)' (is|is not) displayed")]
		public void SafetyDataSheetIsDisplayed(string condition)
		{
			string section = "Safety Data Sheet (Optional)";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'Flash Point Testing Report' (is|is not) displayed")]
		public void FlashPointTestingReportIsDisplayed(string condition)
		{
			string section = "Flash Point Testing Report";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'Toxicity Characteristic Leaching Procedure \(TCLP\)' (is|is not) displayed")]
		public void TCLPIsIsNotDisplayed(string condition)
		{
			string section = "Toxicity Characteristic Leaching Procedure (TCLP)";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'Provide Full Product Label \(required\)' (is|is not) displayed")]
		public void ProvideFullProductLabelDisplayed(string condition)
		{
			string section = "Provide Full Product Label (required)";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'Upload SDS \(Optional\)' (is|is not) displayed")]
		public void UploadSDSIsIsNotDisplayed(string condition)
		{
			string section = "Upload SDS (Optional)";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'Generic Private Label \(all sides\)' (is|is not) displayed")]
		public void GenericPrivateLabelIsIsNotDisplayed(string condition)
		{
			string section = "Generic Private Label (all sides)";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'Transportation Exemption Letter or Special Permit' (is|is not) displayed")]
		public void TransportationExemptionLetterorSpecialPermitIsIsNotDisplayed(string condition)
		{
			string section = "Transportation Exemption Letter or Special Permit";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'Provide Full Product Label \(required\)' error message (should|should not) display: (.*)")]
		public void UploadFileForProductLabelShouldShouldNotDisplayError(string shouldShouldNot, string pipeDelimitedErrorMessages)
		{
			string section = "Provide Full Product Label (required)";
			new Steps_Prototype().ErrorMessagesAreShowingForItem(section, shouldShouldNot, pipeDelimitedErrorMessages);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'Volatile Organic Compounds' error message (should|should not) display: (.*)")]
		public void VolatileOrganicCompoundsShouldShouldNotDisplayError(string shouldShouldNot, string pipeDelimitedErrorMessages)
		{
			string section = "Volatile Organic Compounds";
			new Steps_Prototype().ErrorMessagesAreShowingForItem(section, shouldShouldNot, pipeDelimitedErrorMessages);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, section 'International Fragrance Association \(IFRA\)' error message (should|should not) display: (.*)")]
		public void IFRASectionShouldNotDisplayError(string shouldShouldNot, string pipeDelimitedErrorMessages)
		{
			string section = "International Fragrance Association (IFRA)";
			new Steps_Prototype().ErrorMessagesAreShowingForItem(section, shouldShouldNot, pipeDelimitedErrorMessages);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, for section 'Generally Recognized as Safe \(GRAS\)' error message (should|should not) display: (.*)")]
		public void GRASectionShouldNotDisplayError(string shouldShouldNot, string pipeDelimitedErrorMessages)
		{
			string section = "Generally Recognized as Safe (GRAS)";
			new Steps_Prototype().ErrorMessagesAreShowingForItem(section, shouldShouldNot, pipeDelimitedErrorMessages);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, for section 'OSHA-compliant Safety Data Sheet \(Optional\)' error message (should|should not) display: (.*)")]
		public void OSHACompliantSectionShouldNotDisplayError(string shouldShouldNot, string pipeDelimitedErrorMessages)
		{
			string section = "OSHA-compliant Safety Data Sheet (Optional)";
			new Steps_Prototype().ErrorMessagesAreShowingForItem(section, shouldShouldNot, pipeDelimitedErrorMessages);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide Section, for section (Product Label|IFRA Certificate \(Perfumery Products\)|TCLP Test Results \(Optional\)|STLC/TTLC Results for California \(Optional\)|Toxicology or Eco-Tox Testing Data \(Optional\)) I click button 'Browse'")]
		public void ClickBrowseButton(string section)
		{
			string button = "Browse";
			new Steps_Prototype().ClickButtonForSection(section, button);
		}
		[RegexStepDefinition(@"In the Additional Documents to Provide, for section (.*) the 'Browse' button (should|should not) exists")]
		public void CheckBrowseButtonExistsForSection(string section, string condition)
		{
			string button = "Browse";
			new Steps_Prototype().CheckButtonExistsForSection(section, condition, button);
		}
	}
}
