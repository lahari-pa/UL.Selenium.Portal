using NPOI.POIFS.Crypt.Dsig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product.Review_and_Submit;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{

	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:RegulatoryDocumentsToProvide")]
	class WERCSmart_Distributor_NewProducts_RegulatoryDocumentsToProvide
	{
		[StepDefinition(@"In the Regulatory Documents to Provide Section, I confirm text 'Battery registrations are made available within WERCSmart for selection while registering a Battery-Containing Product...' (should|should not) be displayed")]
		public void GivenIConfirmTheRegulatoryDocumentsToProvideDisplaysTheCorrectText(string condition)
		{
			string section = "Regulatory Documents to Provide";
			string[] correctText =
			{
			"Battery registrations are made available within WERCSmart for selection while registering a Battery-Containing Product. The Battery registration must comply with regulatory requirements in all regions served by the WERCSmart solution. You must provide a technical document or an SDS for both Canada and the US with a bilingual product label. Lithium Battery registrations must also provide the UN38.3 Testing Document."
			};
			new Steps_Prototype().GivenIConfirmTheTextsDisplaysTheCorrectText(section, correctText, condition);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, set the radio option in section: 'Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet \(SDS\) is not required, but may be provided instead of an AIS. When providing an SDS it must be both U.S. and Canada formats.' to: (I certify that I have an OSHA-Compliant Safety Data Sheet \(SDS\) for this product.|I need an OSHA-Compliant Safety Data Sheet \(SDS\) authored for this product.|I don't need an OSHA-Compliant Safety Data Sheet \(SDS\) document for this product.)")]
		public void SelectBatteriesAreConsideredArticlesUnderGlobalHarmonizedStandards(string option)
		{
			string section = "Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats.";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, set the radio option in section: 'WHMIS-compliant Safety Data Sheet, English and French-Canadian' to: (I certify that I have a WHMIS-Compliant Safety Data Sheet \(SDS\) for this product.|I need a WHMIS-Compliant bilingual Safety Data Sheet \(SDS\) authored for this product.|I don't need a WHMIS Compliant SDS)")]
		public void SelectWHMIS(string option)
		{
			string section = "WHMIS-compliant Safety Data Sheet, English and French-Canadian";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, upload file in section: 'I have an Article Information Sheet \(AIS\), Technical Data Sheet \(TDS\), Battery Data Sheet \(BDS\) to provide.'")]
		public void UploadFileForAIS()
		{
			string section = "I have an Article Information Sheet (AIS), Technical Data Sheet (TDS), Battery Data Sheet (BDS) to provide.";
			string pdfFile = "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			new Steps_Prototype().UploadPDFFile(section, pdfFile);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, upload file in section: 'OSHA SDS'")]
		public void UploadFileForOSHASDS()
		{
			string section = "OSHA SDS";
			string pdfFile = "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			new Steps_Prototype().UploadPDFFile(section, pdfFile);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, upload file in section: 'Dual-Language WHMIS SDS, in French Canadian and English'")]
		public void UploadFileForDualLanguageWHMISSDS()
		{
			string section = "Dual-Language WHMIS SDS, in French Canadian and English";
			string pdfFile = "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			new Steps_Prototype().UploadPDFFile(section, pdfFile);
		}

		[StepDefinition(@"In the Regulatory Documents to Provide Section, for section 'Dual-Language WHMIS SDS, in French Canadian and English': enter WHMIS SDS Docmument Date: (.*)")]
		public void EnterTextWHMISSDSDocmumentDate(string date)
		{
			new RegulatoryDocumentsToProvide().EnterWHMISSDSDocumentDate(date);
		}

		[StepDefinition(@"In the Regulatory Documents to Provide Section, upload file in section: 'Label in both French and English'")]
		public void UploadFileForLabelInBothFrenchAndEnglish()
		{
			string section = "Label in both French and English";
			string pdfFile = "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			new Steps_Prototype().UploadPDFFile(section, pdfFile);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, set the radio option in section: 'OSHA-compliant Safety Data Sheet, English' to: (I do not have an OSHA-compliant SDS for this battery but do have a Technical Data Sheet \(TDS\) or Battery Data Sheet \(BDS\) and would like to upload it.|Yes, I certify that I have an OSHA-compliant SDS for this product and would like to upload it.|Request to author)")]
		public void SelectOSHACompliantSafetyDataSheet(string option)
		{
			string section = "OSHA-compliant Safety Data Sheet, English";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, upload file in section: 'Upload UN38.3 Test Document \(Required\)'")]
		public void UploadFileForUN383TestDocument()
		{
			string section = "Upload UN38.3 Test Document (Required)";
			string pdfFile = "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			new Steps_Prototype().UploadPDFFile(section, pdfFile);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, upload file in section: 'Upload Full Product Label \(required\) \(For private label products please upload a generic label that is not retailer-specific.\)'")]
		public void UploadFileForProductLabel()
		{
			string section = "Product Label";
			string pdfFile = "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf";
			new Steps_Prototype().UploadPDFFile(section, pdfFile);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, click 'OSHA Hazard Communication' link")]
		public void ClickLinkFreeWaterOf2015()
		{
			string linkText = " OSHA Hazard Communication ";
			new Steps_Prototype().ClickLinkElement(linkText);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, 'OSHA Hazard Communication' link (should|should not) be displayed")]
		public void LinkFreeWaterAct1Exists(string condition)
		{
			string linkText = " OSHA Hazard Communication ";
			new Steps_Prototype().LinkElementExists(condition, linkText);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, after clicking 'OSHA Hazard Communication' link I confirm new tab (should|should not) exists")]
		public void AfterClickingFreeWeterActLinkNewTabExists(string condition)
		{
			string url = "https://www.osha.gov/hazcom";
			new Steps_Prototype().NewTabShouldExists(condition, url);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, for section (I have an Article Information Sheet \(AIS\), Technical Data Sheet \(TDS\), Battery Data Sheet \(BDS\) to provide.|OSHA SDS|Dual-Language WHMIS SDS, in French Canadian and English|Label in both French and English|Upload UN38.3 Test Document \(Required\)|Product Label) I click button 'View'")]
		public void ClickBrowseButtonForSection(string section)
		{
			string button = "view";
			new Steps_Prototype().ClickButtonForSection(section, button);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, for section (I have an Article Information Sheet \(AIS\), Technical Data Sheet \(TDS\), Battery Data Sheet \(BDS\) to provide.|OSHA SDS|Dual-Language WHMIS SDS, in French Canadian and English|Label in both French and English|Upload UN38.3 Test Document \(Required\)|Product Label) I click button 'Remove'")]
		public void ClickViewButton(string section)
		{
			string button = "remove";
			new Steps_Prototype().ClickButtonForSection(section, button);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, for section (I have an Article Information Sheet \(AIS\), Technical Data Sheet \(TDS\), Battery Data Sheet \(BDS\) to provide.|OSHA SDS|Dual-Language WHMIS SDS, in French Canadian and English|Label in both French and English|Upload UN38.3 Test Document \(Required\)|Product Label) I click button 'Browse'")]
		public void ClickBrowseButton(string section)
		{
			string button = "Browse";
			new Steps_Prototype().ClickButtonForSection(section, button);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, after clicking 'View' button I confirm pdf file is downloaded")]
		public void AfterClickingHR1321PdfIsDownloaded()
		{
			string file = "testdoc.pdf";
			string savedAs = "downloadedFile";
			new Steps_Prototype().ConfirmFileAppearsInDownloadsFolder(file, savedAs);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, for section (I have an Article Information Sheet \(AIS\), Technical Data Sheet \(TDS\), Battery Data Sheet \(BDS\) to provide.|OSHA SDS|Dual-Language WHMIS SDS, in French Canadian and English|Label in both French and English|Upload UN38.3 Test Document \(Required\)|Product Label) button Browse (should|should not) exists")]
		public void CheckBrowseButtonForLabelInBoth(string section, string condition)
		{
			string button = "Browse";
			new Steps_Prototype().CheckButtonExistsForSection(section, condition, button);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, for section (I have an Article Information Sheet \(AIS\), Technical Data Sheet \(TDS\), Battery Data Sheet \(BDS\) to provide.|OSHA SDS|Dual-Language WHMIS SDS, in French Canadian and English|Label in both French and English|Upload UN38.3 Test Document \(Required\)|Product Label) button View (should|should not) exists")]
		public void CheckButtonViewForLabelInBoth(string section, string condition)
		{
			string button = "view";
			new Steps_Prototype().CheckButtonExistsForSection(section, condition, button);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, for section (I have an Article Information Sheet \(AIS\), Technical Data Sheet \(TDS\), Battery Data Sheet \(BDS\) to provide.|OSHA SDS|Dual-Language WHMIS SDS, in French Canadian and English|Label in both French and English|Upload UN38.3 Test Document \(Required\)|Product Label) button Remove (should|should not) exists")]
		public void CheckButtonRemoveForLabelInBoth(string section, string condition)
		{
			string button = "remove";
			new Steps_Prototype().CheckButtonExistsForSection(section, condition, button);
		}
		[StepDefinition(@"In the Regulatory Documents to Provide Section, in the 'Remove Document' pop up click (Yes|No) button")]
		public void ClickButtonInRemoveDocumentPopUp(string button)
		{
			string popupTitle = "Remove Document?";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(popupTitle, button);
		}

		[StepDefinition(@"In the Regulatory Documents to Provide Section, the alert message (should|should not) be displayed with text: 'STOP! When selecting authoring of a Safety Data Sheet \(SDS\) for Canada, you need to provide your Canada address. Please go to the My Account area, and update this information in My Company. You can then resume your registration set up.'")]
		public void TextInAlertMessage(string condition)
		{
			string alertText = "STOP! When selecting authoring of a Safety Data Sheet (SDS) for Canada, you need to provide your Canada address. Please go to the My Account area, and update this information in My Company. You can then resume your registration set up.";
			new Steps_Prototype().AlertMessageDisplayed(condition, alertText);
		}

		[StepDefinition(@"In the Regulatory Documents to Provide Section, for section: 'Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet \(SDS\) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats.': the following options (should|should not) be (displayed|displayed exclusively):")]
		public void CheckOptionsForSectionBatteriesAreArticlesGlobalHarmonizedStandards(string condition, string displayed, Table table)
		{
			string section = "Batteries are considered Articles under Global Harmonized Standards. A Safety Data Sheet (SDS) is not required, but may be provided instead of an AIS.  When providing an SDS it must be both U.S. and Canada formats.";
			new Steps_Prototype().CheckOptionsInSection(condition, displayed, section, table);
		}

		[StepDefinition(@"In the Regulatory Documents to Provide Section, for section: 'WHMIS-compliant Safety Data Sheet, English and French-Canadian': the following options (should|should not) be (displayed|displayed exclusively):")]
		public void CheckOptionsForSectionWHMISCompliantSafetyDataSheet(string condition, string displayed, Table table)
		{
			string section = "WHMIS-compliant Safety Data Sheet, English and French-Canadian";
			new Steps_Prototype().CheckOptionsInSection(condition, displayed, section, table);
		}



	}
}
