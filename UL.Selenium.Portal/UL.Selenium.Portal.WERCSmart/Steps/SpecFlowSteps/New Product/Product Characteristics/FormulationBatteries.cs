using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:Formulated_Batteries")]
	class WERCSmart_Distributor_NewProducts_Formulation_Batteries
	{
		[RegexStepDefinition(@"In the Formulation > Batteries Section, set the radio option in section: 'Consent to Tier 2.1, 2.2, 4.2 Data Uses': to: (Granted|Declined)")]
		public void SelectConsentToTier(string option)
		{
			string section = "Consent to Tier 2.1, 2.2, 4.2 Data Uses";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[RegexStepDefinition(@"In the Formulation > Batteries Section, I confirm text 'Data Use Consents' (should|should not) be displayed")]
		public void GivenIConfirmTheFormulationBatteriesDisplaysTheCorrectText(string condition)
		{
			string section = "Formulation > Batteries";
			string[] correctText =
			{
			"Data Use Consents",
			"Direct suppliers with products containing your battery (i.e., your customers) may opt to participate in various chemical policy and product qualification programs operated by WERCSmart Recipients. Further information about these consents and data uses are provided in the Data Use Tier Disclosure section of the WERCSmart Terms of Use.",
			"You have the option of allowing this battery to be included in such programs by providing the consent below. Such consent means:",
			"a. That your battery data may be utilized when UL generates aggregate usage reports, chemical screening results and transparency ratios for such Direct Supplier products (Tier 2.1),",
			"b. That the identity of ingredients in your battery (i.e., the standard chemical names or CAS Numbers) may be disclosed to your customer and the relevant WERCSmart Recipient, but only if you have marked an ingredient as publicly disclosed on the formulation page (Tier 2.2) or if applicable law requires that an ingredient be publicly disclosed, and",
			"c. That your customer can publicly disclose the identity of ingredients in your battery, but only if you have marked an ingredient as publicly disclosed (Tier 4.2).",
			"These consents do not authorize any disclosure of ingredient by percent weight to your customer, any retail Recipient, or the public."
			};
			new Steps_Prototype().GivenIConfirmTheTextsDisplaysTheCorrectText(section, correctText, condition);

		}


	}
}
