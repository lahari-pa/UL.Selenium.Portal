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
	}
}
