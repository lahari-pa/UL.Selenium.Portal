using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:USDepartamentOfTransportationDOT")]
	class WERCSmart_Distributor_NewProducts_USDepartamentOfTransportationDOT
	{
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'UN Number': to: (.*)")]
		public void SetUNNumberIMDG(string option)
		{
			string section = "UN Number";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'Proper Shipping Name': to: (.*)")]
		public void SetProperShippingNameIMDG(string option)
		{
			string section = "Proper Shipping Name";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'Technical Name \(if applicable\)': to: (.*)")]
		public void SetTechnicalNameIMDG(string option)
		{
			string section = "Technical Name (if applicable)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'Hazard Class': to: (.*)")]
		public void SetHazardClassIMDG(string option)
		{
			string section = "Hazard Class (select)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'Select Hazard Class \(if available\)': to: (.*)")]
		public void SelectHazardClassIMDG(string option)
		{
			string section = "Select Hazard Class (if available)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'Packing Group': to: (.*)")]
		public void SetPackingGroupIMDG(string option)
		{
			string section = "Packing Group (select)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'Select Packing Group \(if available\)': to: (.*)")]
		public void SelectPackingGroupIMDG(string option)
		{
			string section = "Select Packing Group (if available)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'Special Provision Number': to: (.*)")]
		public void SetSpecialProvisionNumber(string option)
		{
			string section = "Special Provision Number";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'Regulatory reference for any exemption or exceptions taken': to: (.*)")]
		public void SetRegulatoryReferenceForAnyExemptionOrExceptionsTaken(string option)
		{
			string section = "Regulatory reference for any exemption or exceptions taken";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'For the lighter, provide the DOT Approval Number \(LAA\)': to: (.*)")]
		public void SetForTheLighterprovideDOTApprovalNumber(string option)
		{
			string section = "For the lighter, provide the DOT Approval Number (LAA)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, set the option in section: 'Product has a boiling point of <=35⁰C and flash point of >60⁰C. Packing Group selected is not consistent with this data. Verify the data and transportation packing group. If problem persists, please contact Support.': to: (Based on defined viscosity parameters, this product is classified as PG III.|The Packaging Group inconsistency is allowed based on a Special Provision associated with the assigned UN#.|The Packaging Group inconsistency is allowed based on an exemption or exception associated with the assigned UN#.|The UN# classification assigned to this product has a specific Packaging Group required.)")]
		public void SetProductHasBoilingPoint(string option)
		{
			string section = "Product has a boiling point of <=35⁰C  and flash point of >60⁰C. Packing Group selected is not consistent with this data.  Verify the data and transportation packing group.  If problem persists, please contact Support.";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, verify section: 'UN Number' contains value: (.*)")]
		public void VerifyUNNumberIMDG(string value)
		{
			string section = "UN Number";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, verify section: 'Proper Shipping Name' contains value: (.*)")]
		public void VerifyProperShippingNameIMDG(string value)
		{
			string section = "Proper Shipping Name";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, verify section: 'Technical Name \(if applicable\)' contains value: (.*)")]
		public void VerifyTechnicalNameIMDG(string value)
		{
			string section = "Technical Name (if applicable)";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, verify section: 'Hazard Class \(select\)' contains value: (.*)")]
		public void VerifyHazardClassIMDG(string value)
		{
			string section = "Hazard Class (select)";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}
		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, verify section: 'Packing Group \(select\)' contains value: (.*)")]
		public void VerifyPackingGroupIMDG(string value)
		{
			string section = "Packing Group (select)";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}

		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, verify that the section: 'UN Number' is highlighted in red indicating an error")]
		public void CheckUNSectionsWithRedError()
		{
			string section = "UN Number";
			new Steps_Prototype().SectionIsHighlightedInRedIndicatingAnError(section);
		}

		[RegexStepDefinition(@"In the U.S. Department of Transportation \(DOT\) Classification Section, the section: 'UN Number' (should|should not) be showing error message: (.*)")]
		public void CheckUNSectionsWithErrorMessages(string condition ,string message)
		{
			string section = "UN Number";
			new Steps_Prototype().ErrorMessagesAreShowingForItem(section,condition,message);
		}

	}

}
