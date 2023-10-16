using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Formulation3rdParty")]
	class WERCSmart_Distributor_NewProducts_ProductCharacteristics_Formulation3rdParty
	{
		[StepDefinition(@"In the Formulation > 3rdParty Section, set the radio option in section: 'Consent to Tier 2.1, 2.2, 4.2 Data Uses': to: (Granted|Declined)")]
		public void SelectConsentToTier(string option)
		{
			string section = "Consent to Tier 2.1, 2.2, 4.2 Data Uses";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[StepDefinition(@"In the Formulation > 3rdParty Section, set the radio option in section: 'By clicking Accept, I certify the formulation information entered is complete and accurate': to: Accept")]
		public void SelectByClickingAcceptICertifyTheFormulationInformation()
		{
			string section = "By clicking Accept, I certify the formulation information entered is complete and accurate";
			string option = "Accept";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the Formulation > 3rdParty Section, I confirm displayed 'Chemical Assessments and SDS Authoring' text is correct")]
		public void GivenIConfirmTheFormulation3rdPartyDisplaysTheCorrectText()
		{
			string section = "Formulation > 3rd Party";
			string[] correctText =
			{
			"1. Chemical Assessments and SDS Authoring",
			"WERCSmart combines direct supplier and 3rd party quantitative formulations for purposes of a product's chemical assessment, and in some cases, for SDS authoring. Unless an ingredient is checked as public, the identity of an ingredient (the CAS# and the chemical name) in a 3rd party formulation, when combined with a direct supplier's formulation, is masked (whether or not checked as a trade secret). Please note, however, that 3rd party ingredient chemical names may be disclosed on international shipping labels as required."
			};
			new Steps_Prototype().GivenIConfirmTheTextsDisplaysTheCorrectText(section, correctText);

		}
		[StepDefinition(@"In the Formulation > 3rdParty Section, I confirm displayed 'Data Use Consents' text is correct")]
		public void GivenIConfirmTheFormulation3rdPartyDataUseConsentsDisplaysTheCorrectText()
		{
			string section = "Formulation > 3rd Party";
			string[] correctText =
			{
			"2. Data Use Consents",
			"Tier 1 Data Use – Regulatory Support",
			"All suppliers, including Third-Party Suppliers, provide consent to Tier 1 data use for regulatory support purposes when they accept the WERCSmart Term of Use. All data elements defined as Confidential Data in Section II (D) of the Data Use Tier Disclosure Section of the WERCSmart Terms of Use will be treated as such and will not be provided to your customer (the Direct Supplier) or a WERCSmart Recipient, unless a local, state or federal statute or other applicable law requires that a specific element be treated as non-confidential. For example, if your component is included in a Direct Supplier’s cleaning product and that Supplier has requested that UL generate an ingredient disclosure report that is compliant with the California Cleaning Product Right-to-Know Act, please note that ingredients that you may have marked as Trade Secret or not publicly disclosed in your formulation will nonetheless be disclosed if required by the terms of the California Cleaning Product Right-to-Know Act. Your identity as the Third Party Supplier will not be disclosed in the report unless your registered component name includes your supplier name.",
			"Tier 2 and Tier 4 Data Uses – Chemical Program Support and Public Disclosure",
			"Direct suppliers with products containing your third-party component (i.e., your customers) may opt to participate in various chemical policy and product qualification programs operated by WERCSmart Recipients. Further information about these consents and data uses are provided in the Data Use Tier Disclosure section of the WERCSmart Terms of Use.",
			"You have the option of allowing this component to be included in such programs by providing the consent below.",
			"Such consent means:",
			"a. That your third-party formulation data may be utilized when UL generates aggregate usage reports, chemical screening results and transparency ratios for such Direct Supplier products (Tier 2.1),",
			"b. That the identity of ingredients in your component (i.e., the standard chemical names or CAS Numbers) may be disclosed to your customer and the relevant WERCSmart Recipient, but only if you have marked an ingredient as publicly disclosed on the formulation page (Tier 2.2) or if applicable law requires that an ingredient be publicly disclosed, and",
			"c. That your customer can publicly disclose the identity of ingredients in your component, but only if you have marked an ingredient as publicly disclosed (Tier 4.2).",
			"These consents do not authorize any disclosure of ingredient by percent weight to your customer, any retail Recipient, or the public."
			};
			new Steps_Prototype().GivenIConfirmTheTextsDisplaysTheCorrectText(section, correctText);

		}
	}
}
