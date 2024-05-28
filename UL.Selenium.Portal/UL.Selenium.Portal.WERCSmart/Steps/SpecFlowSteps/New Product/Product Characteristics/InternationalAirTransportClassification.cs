using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InternationalAirTransportClassification")]
	class WERCSmart_Distributor_NewProducts_InternationalAirTransportClassification
	{
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, set the option in section: 'UN Number': to: (.*)")]
		public void SetUNNumberIATA(string option)
		{
			string section = "UN Number";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, set the option in section: 'Proper Shipping Name': to: (.*)")]
		public void SetProperShippingNameIATA(string option)
		{
			string section = "Proper Shipping Name";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, set the option in section: 'Technical Name \(if applicable\)': to: (.*)")]
		public void SetTechnicalNameIATA(string option)
		{
			string section = "Technical Name (if applicable)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, set the option in section: 'Hazard Class \(select\)': to: (.*)")]
		public void SetHazardClassIATA(string option)
		{
			string section = "Hazard Class (select)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, set the option in section: 'Packing Group': to: (.*)")]
		public void SetPackingGroupIATA(string option)
		{
			string section = "Packing Group (select)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, I confirm checkbox 'Copy information from my U.S. Department of Transportation data' (should|should not) be displayed")]
		public void CheckCheckboxIsDisplayedIATA(string condition)
		{
			string section = "Copy information from my U.S. Department of Transportation data";
			new Steps_Prototype().IConfirmCheckboxWithDescriptionIsDisplayed(section, condition);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, I (check|uncheck) checkbox 'Copy information from my U.S. Department of Transportation data'")]
		public void CheckUncheckCheckboxIATA(string condition)
		{
			string checkbox = "Copy information from my U.S. Department of Transportation data";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(condition, checkbox);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, set the option in section: 'Special Provision Number': to: (.*)")]
		public void SetSpecialProvisionNumberIATA(string option)
		{
			string section = "Special Provision Number";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, set the option in section: 'Regulatory reference for any exemption or exceptions taken': to: (.*)")]
		public void SetRegulatoryReferenceForAnyExemptionOrExceptionsTakenIATA(string option)
		{
			string section = "Regulatory reference for any exemption or exceptions taken";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, set the option in section: 'Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packing Group selected is not consistent with this data. Verify the data and transportation packing group. If problem persists, please contact Support.': to: (Based on defined viscosity parameters, this product is classified as PG III.|The Packaging Group inconsistency is allowed based on a Special Provision associated with the assigned UN#.|The Packaging Group inconsistency is allowed based on an exemption or exception associated with the assigned UN#.|The UN# classification assigned to this product has a specific Packaging Group required.)")]
		public void SetProductHasBoilingPointIATA(string option)
		{
			string section = "Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, verify section: 'UN Number' contains value: (.*)")]
		public void VerifyUNNumberIATA(string value)
		{
			string section = "UN Number";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, verify section: 'Proper Shipping Name' contains value: (.*)")]
		public void VerifyProperShippingNameIATA(string value)
		{
			string section = "Proper Shipping Name";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, verify section: 'Technical Name \(if applicable\)' contains value: (.*)")]
		public void VerifyTechnicalNameIATA(string value)
		{
			string section = "Technical Name (if applicable)";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, verify section: 'Hazard Class \(select\)' contains value: (.*)")]
		public void VerifyHazardClassIATA(string value)
		{
			string section = "Hazard Class (select)";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the International Air Transport \(IATA\) Classification Section, verify section: 'Packing Group \(select\)' contains value: (.*)")]
		public void VerifyPackingGroupIATA(string value)
		{
			string section = "Packing Group (select)";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
	}
}
