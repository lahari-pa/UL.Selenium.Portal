using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsUS")]
	class WERCSmart_Distributor_NewProducts_PesticideDetailsUS
	{
		[StepDefinition(@"In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency \(EPA\) Registration Number' enter comment (Yes|No)")]
		public void SelectProductHasAnEnvironmentalProtectionAgency(string option)
		{
			string section = "Product has an Environmental Protection Agency (EPA) Registration Number";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[StepDefinition(@"In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter comment (Yes|No)")]
		public void SelectProductHasAStateRegistration(string option)
		{
			string section = "Product has a State Registration";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[StepDefinition(@"In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter comment (Product is FIFRA 25\(b\) Exempt.|Food Based Pesticides - Exempt from EPA Registration|Device based products - Exempt from EPA Registration|Pheromone Traps – Exempt from EPA Registration)")]
		public void SelectTheApplicableExemption(string option)
		{
			string section = "Select the applicable exemption";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}

		[StepDefinition(@"In the Pesticide Details - U.S. Section, in 'EPA Pesticide Registration No.' enter (.*)")]
		public void EnterEPANO(string option)
		{
			new Steps_Prototype().ThenIEnterTheFollowingEPAPesticideRegistrationNo_(option);
		}
		[StepDefinition(@"In the Pesticide Details - U.S. Section, click Add Row in the EPA Registration Table")]
		public void ClickAddRow()
		{
			string button = "Add Row";
			new Steps_Prototype().ClickButton(button);
		}
	}
}
