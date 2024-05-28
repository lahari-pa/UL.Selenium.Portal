using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:PesticideDetailsUS")]
	class WERCSmart_Distributor_NewProducts_PesticideDetailsUS
	{
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, in 'Product has an Environmental Protection Agency \(EPA\) Registration Number' enter (Yes|No)")]
		public void SelectProductHasAnEnvironmentalProtectionAgency(string option)
		{
			string section = "Product has an Environmental Protection Agency (EPA) Registration Number";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter (Yes|No)")]
		public void SelectProductHasAStateRegistration(string option)
		{
			string section = "Product has a State Registration";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter (Product is FIFRA 25\(b\) Exempt.|Food Based Pesticides - Exempt from EPA Registration|Device based products - Exempt from EPA Registration|Pheromone Traps – Exempt from EPA Registration)")]
		public void SelectTheApplicableExemption(string option)
		{
			string section = "Select the applicable exemption";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}

		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, in 'EPA Pesticide Registration No.' enter (.*)")]
		public void EnterEPANO(string option)
		{
			PesticideDetailsState pesticideDetailsStateObject = new PesticideDetailsState();
			Report.IsTrue(pesticideDetailsStateObject.EnterEpaPesticideRegistrationNo(option), "Failed to enter EPA Pesticide Registration No.", "Successfully entered EPA Pesticide Registration No.");
		}
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, click Add Row in the EPA Registration Table")]
		public void ClickAddRow()
		{
			string button = "Add Row";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, I confirm text 'Due to the lack of both an Active and an Inert Ingredient in the ingredients entered, the election for FIFRA 25\(b\) exemption is not available. Please either enter the Federal EPA Registration Number, or review the ingredients that have been entered, in its entirety, for accuracy. Note: WERCSmart requires 100% disclosure of the ingredients.' (should|should not) be displayed")]
		public void GivenIConfirmTheFormulation3rdPartyDisplaysTheCorrectText(string condition)
		{
			string section = "Select the applicable exemption";
			string[] correctText =
			{
			"Due to the lack of both an Active and an Inert Ingredient in the ingredients entered, the election for FIFRA 25(b) exemption is not available. Please either enter the Federal EPA Registration Number, or review the ingredients that have been entered, in its entirety, for accuracy. Note: WERCSmart requires 100% disclosure of the ingredients."
			};
			new Steps_Prototype().GivenIConfirmTheTextsDisplaysTheCorrectText(section, correctText, condition);

		}
	}
}
