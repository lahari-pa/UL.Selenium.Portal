using NPOI.SS.Formula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:FormulationNames")]
	internal class FormulationNames
	{
		[StepDefinition(@"In the Formulation Names section, I enter the text of Provide the name\(s\) to be used to identify the formula field to: (.*)")]
		public void GivenEnterProvideTheNamesToBeUsedToIdentifyTheFormulaValue(string value)
		{
			Report.Info($"I set the text of Provide the name(s) to be used to identify the formula field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Provide the name(s) to be used to identify the formula", value);
		}

		[StepDefinition(@"In the Formulation Names section, I enter the text of Provide Public Name\(s\) of the formula you're registering field to: (.*)")]
		public void GivenEnterProvidePublicNamesOfTheFormulaYoureRegisteringValue(string value)
		{
			Report.Info($"I set the text of Provide Public Name(s) of the formula you're registering field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Provide Public Name(s) of the formula you're registering.  This will be available to the Supplier to select for your ingredient when the ingredient is indicated to be Publicly Available. Public Names are typically on a products label- website or other information available to the general public.", value);
		}

		[StepDefinition(@"In the Formulation Names section, I enter the text of cleaning products its Business-to-Consumer field to: (.*)")]
		public void GivenEnterCleaningProductsItsBusinessToConsumerValue(string value)
		{
			Report.Info($"I set the text of cleaning products its Business-to-Consumer field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("For ingredients used in cleaning products its Business-to-Consumer name must comply with the requirements of the California Cleaning Product Right to Know Act.  Manufacturer must use a name that is only as generic as necessary to protect the confidential identity of the ingredient. In developing the generic name- the manufacturer must use the generic name framework provided by the Federal Environmental Protection Agency (EPA) guidance for the Toxic Substances Control Act (TSCA) Confidential Inventory.", value);
		}

		[StepDefinition(@"In the Formulation Names section, for section: 'Formula Name for the WERCSmart Ingredient Directory' confirm that the textbox field is populated with: (.*)")]
		public void ConfirmTextFieldValueForFormulaName(string value)
		{
			string section = "Formula Name for the WERCSmart Ingredient Directory";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, value);
		}

		[StepDefinition(@"In the Formulation Names section, for section: 'Formula Name for the WERCSmart Ingredient Directory' enter text: (.*)")]
		public void EnterTextForFormulaName(string value)
		{
			string section = "Formula Name for the WERCSmart Ingredient Directory";
			new Steps_Prototype().SetTheSectionOptionTo(section, value);
		}

		[StepDefinition(@"In the Formulation Names section, for section: 'Formula Name for the WERCSmart Ingredient Directory' clear the textbox field")]
		public void ClearTextForFormulaName()
		{
			string section = "Formula Name for the WERCSmart Ingredient Directory";
			Report.Info($"Clearing the text box for section: {section}");
			new Steps_Prototype().ClearTextBoxField(section, section);
		}

		[StepDefinition(@"In the Formulation Names section, the section: 'Formula Name for the WERCSmart Ingredient Directory' (should|should not) display an error message: (.*)")]
		public void ConfirmErrorMessageForSectionFormulaName(string condition, string errorMessage)
		{
			string section = "Formula Name for the WERCSmart Ingredient Directory";
			new Steps_Prototype().ErrorMessagesAreShowingForItem(section, condition, errorMessage);
		}

		[StepDefinition(@"In the Formulation Names section, confirm that the full text for section: 'Provide Public Name\(s\) of the formula you're registering.' (is|is not) displayed")]
		public void ConfirmSectionProvidePublicNameDisplayed(string condition)
		{
			string section = "Provide Public Name(s) of the formula you're registering.  This will be available to the Supplier to select for your ingredient when the ingredient is indicated to be Publicly Available. Public Names are typically on a products label, website or other information available to the general public.";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}

		[StepDefinition(@"In the Formulation Names section, for section: 'Provide Public Name\(s\) of the formula you're registering.' confirm that the textbox option: (Public Name 1|Public Name 2|Public Name 3) displays the shadow text: (Public Name 1|Public Name 2|Public Name 3)")]
		public void ConfirmTextFieldValueForFormulaName(string section, string shadowTextOption)
		{
			new Steps_Prototype().ShadowTextDisplayed(section, shadowTextOption);
		}

		[StepDefinition(@"In the Formulation Names section, confirm that the full text for section: 'Business to Consumer Name' (is|is not) displayed")]
		public void ConfirmSectionBusinessToConsumerNameDisplayed(string condition)
		{
			string section = "For ingredients used in cleaning products its Business-to-Consumer name must comply with the requirements of the California Cleaning Product Right to Know Act.  Manufacturer must use a name that is only as generic as necessary to protect the confidential identity of the ingredient. In developing the generic name, the manufacturer must use the generic name framework provided by the Federal Environmental Protection Agency (EPA) guidance for the Toxic Substances Control Act (TSCA) Confidential Inventory.";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, condition);
		}

		[StepDefinition(@"In the Formulation Names section, for section: 'Business to Consumer Name' confirm that the textbox displays the shadow text: (.*)")]
		public void ConfirmTextFieldValueForBusinessToConsumerName(string shadowText)
		{
			string section = "Business to Consumer Name";
			new Steps_Prototype().ShadowTextDisplayed(section, shadowText);
		}

		[StepDefinition(@"In the Formulation Names section, for section: 'Business to Consumer Name' enter text: (.*)")]
		public void EnterTextForBusinessToConsumerName(string value)
		{
			string section = "Business to Consumer Name";
			new Steps_Prototype().SetTheSectionOptionTo(section, value);
		}

		[StepDefinition(@"In the Formulation Names section, the section: 'Business to Consumer Name' (should|should not) display an error message: (.*)")]
		public void ConfirmErrorMessageForSectionBusinessToConsumerName(string condition, string errorMessage)
		{
			string section = "Business to Consumer Name";
			new Steps_Prototype().ErrorMessagesAreShowingForItem(section, condition, errorMessage);
		}
	}
}
