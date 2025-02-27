using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InternationalMarineClassification")]
	class WERCSmart_Distributor_NewProducts_InternationalMarineClassification
	{
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, set the option in section: 'UN Number': to: (.*)")]
		public void SetUNNumberIMDG(string option)
		{
			string section = "UN Number";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, set the option in section: 'Proper Shipping Name': to: (.*)")]
		public void SetProperShippingNameIMDG(string option)
		{
			string section = "Proper Shipping Name";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, set the option in section: 'Technical Name \(if applicable\)': to: (.*)")]
		public void SetTechnicalNameIMDG(string option)
		{
			string section = "Technical Name (if applicable)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, set the option in section: 'Hazard Class \(select\)': to: (.*)")]
		public void SetHazardClassIMDG(string option)
		{
			string section = "Hazard Class (select)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, set the option in section: 'Packing Group': to: (.*)")]
		public void SetPackingGroupIMDG(string option)
		{
			string section = "Packing Group (select)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, I confirm checkbox 'Copy information from my U.S. Department of Transportation data' (should|should not) be displayed")]
		public void CheckCheckboxIsDisplayed(string condition)
		{
			string section = "Copy information from my U.S. Department of Transportation data";
			new Steps_Prototype().IConfirmCheckboxWithDescriptionIsDisplayed(section, condition);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, I (check|uncheck) checkbox 'Copy information from my U.S. Department of Transportation data'")]
		public void CheckUncheckCheckbox(string condition)
		{
			string checkbox = "Copy information from my U.S. Department of Transportation data";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(condition, checkbox);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, set the option in section: 'Special Provision Number': to: (.*)")]
		public void SetSpecialProvisionNumber(string option)
		{
			string section = "Special Provision Number";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, set the option in section: 'Regulatory reference for any exemption or exceptions taken': to: (.*)")]
		public void SetRegulatoryReferenceForAnyExemptionOrExceptionsTaken(string option)
		{
			string section = "Regulatory reference for any exemption or exceptions taken";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, set the option in section: 'Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packing Group selected is not consistent with this data. Verify the data and transportation packing group. If problem persists, please contact Support.': to: (Based on defined viscosity parameters, this product is classified as PG III.|The Packaging Group inconsistency is allowed based on a Special Provision associated with the assigned UN#.|The Packaging Group inconsistency is allowed based on an exemption or exception associated with the assigned UN#.|The UN# classification assigned to this product has a specific Packaging Group required.)")]
		public void SetProductHasBoilingPoint(string option)
		{
			string section = "Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, verify section: 'UN Number' contains value: (.*)")]
		public void VerifyUNNumberIMDG(string value)
		{
			string section = "UN Number";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, verify section: 'Proper Shipping Name' contains value: (.*)")]
		public void VerifyProperShippingNameIMDG(string value)
		{
			string section = "Proper Shipping Name";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, verify section: 'Technical Name \(if applicable\)' contains value: (.*)")]
		public void VerifyTechnicalNameIMDG(string value)
		{
			string section = "Technical Name (if applicable)";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, verify section: 'Hazard Class \(select\)' contains value: (.*)")]
		public void VerifyHazardClassIMDG(string value)
		{
			string section = "Hazard Class (select)";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the International Marine \(IMDG\) Classification Section, verify section: 'Packing Group \(select\)' contains value: (.*)")]
		public void VerifyPackingGroupIMDG(string value)
		{
			string section = "Packing Group (select)";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
	}
}
