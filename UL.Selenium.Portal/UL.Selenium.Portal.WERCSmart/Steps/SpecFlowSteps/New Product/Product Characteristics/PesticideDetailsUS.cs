using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
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

		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, confirm the question: 'Product has an Environmental Protection Agency \(EPA\) Registration Number' (is|is not) displayed")]
		public void ConfirmAnEnvironmentalProtectionAgencyDisplayed(string is_isnot)
		{
			string section = "Product has an Environmental Protection Agency (EPA) Registration Number";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}

		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, in 'Product has a State Registration' enter (Yes|No)")]
		public void SelectProductHasAStateRegistration(string option)
		{
			string section = "Product has a State Registration";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, confirm the question: 'Select the applicable exemption' (is|is not) displayed")]
		public void ConfirmSelectTheApplicableExemption(string is_isnot)
		{
			string section = "Select the applicable exemption";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, in 'Select the applicable exemption' enter (Product is FIFRA 25\(b\) Exempt.|Food Based Pesticides - Exempt from EPA Registration|Device based products - Exempt from EPA Registration|Pheromone Traps – Exempt from EPA Registration)")]
		public void SelectTheApplicableExemption(string option)
		{
			string section = "Select the applicable exemption";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, for section: 'Select the applicable exemption': the following options (should|should not) be (displayed|displayed exclusively):")]
		public void CheckOptionsInSelectTheApplicableExemptionSection(string condition, string displayed, Table table)
		{
			string section = "Select the applicable exemption";
			new Steps_Prototype().CheckOptionsInSection(condition, displayed, section, table);
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
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, confirm for section: 'Product has an Environmental Protection Agency \(EPA\) Registration Number' error (is|is not) displayed: (.*)")]
		public void EPAErrorIsIsNotDisplayed(string is_isnot, string error)
		{
			string section = "Product has an Environmental Protection Agency (EPA) Registration Number";
			new Steps_ProductPrototype().InSectionErrorMessageIsIsNotDisplayed(section, error, is_isnot);
		}
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, confirm for section: 'Product has a State Registration' error (is|is not) displayed: (.*)")]
		public void ProductStateRegistrationErrorIsIsNotDisplayed(string is_isnot, string error)
		{
			string section = "Product has a State Registration";
			new Steps_ProductPrototype().InSectionErrorMessageIsIsNotDisplayed(section, error, is_isnot);
		}
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, confirm for section: 'Select the applicable exemption' error (is|is not) displayed: (.*)")]
		public void SelectApplicableExemptionErrorIsIsNotDisplayed(string is_isnot, string error)
		{
			string section = "Select the applicable exemption";
			new Steps_ProductPrototype().InSectionErrorMessageIsIsNotDisplayed(section, error, is_isnot);
		}
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, confirm for section: 'Product has an Environmental Protection Agency \(EPA\) Registration Number' options background color (is|is not) default saved as: (.*)")]
		public void EPAOptionsColor(string is_isnot, string savedAs)
		{
			string section = "Product has an Environmental Protection Agency (EPA) Registration Number";
			string option1 = "Yes";
			string option2 = "No";
			string defaultColor = (string)Context.GetFromContext(savedAs);
			if (!defaultColor.IsNullOrEmpty())
			{
				new Steps_ProductPrototype().InSectionOptionBackground(section, option1, is_isnot, defaultColor);
				new Steps_ProductPrototype().InSectionOptionBackground(section, option2, is_isnot, defaultColor);
			}
			else
			{
				Report.Failure("Cannot get default color");
			}
		}
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, for section: 'Product has an Environmental Protection Agency \(EPA\) Registration Number' get default option's background color and save it as: (.*)")]
		public void GetEPAOptionsColor(string savedAs)
		{
			string section = "Product has an Environmental Protection Agency (EPA) Registration Number";
			string option1 = "Yes";
			new Steps_ProductPrototype().InSectionGetOptionBackgroundColor(section, option1, savedAs);
		}
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, confirm for section: 'Product has a State Registration' options background color (is|is not) default saved as: (.*)")]
		public void StateRegistrationOptionsColor(string is_isnot, string savedAs)
		{
			string section = "Product has a State Registration";
			string option1 = "Yes";
			string option2 = "No";
			string defaultColor = (string)Context.GetFromContext(savedAs);
			if (!defaultColor.IsNullOrEmpty())
			{
				new Steps_ProductPrototype().InSectionOptionBackground(section, option1, is_isnot, defaultColor);
				new Steps_ProductPrototype().InSectionOptionBackground(section, option2, is_isnot, defaultColor);
			}
			else
			{
				Report.Failure("Cannot get default color");
			}
		}
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, for section: 'Product has a State Registration' get default option's background color and save it as: (.*)")]
		public void GetStateRegistrationOptionsColor(string savedAs)
		{
			string section = "Product has a State Registration";
			string option1 = "Yes";
			new Steps_ProductPrototype().InSectionGetOptionBackgroundColor(section, option1, savedAs);
		}
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, confirm following options (should|should not) be (displayed|exclusively displayed) for section: 'Product has an Environmental Protection Agency \(EPA\) Registration Number'")]
		public void ThenInThePesticideDetails_UASectionConfirmFollowingOptionsShouldShouldNotBeDisplayedExclusivelyDisplayedForSectionAlberta(string should, string exclusive, Table table)
		{
			string section = "Product has an Environmental Protection Agency (EPA) Registration Number";
			new Steps_Prototype().CheckOptionsInSection(should, exclusive, section, table);
		}
		[RegexStepDefinition(@"In the Pesticide Details - U.S. Section, confirm the EPA Pesticide Registration table (is|is not) displayed")]
		public void ThenInThePesticideDetails_UASectionConfirmFEPARegistrationNumberTable(string is_isnot)
		{
			bool expected = is_isnot == "is";
			Report.IsTrue(new NewProduct().Table() != null == expected, $"The EPA Registration Number Table {(expected ? "is not" : "is")} displayed", $"The EPA Registration Number Table {is_isnot} displayed");
		}

	}
}
