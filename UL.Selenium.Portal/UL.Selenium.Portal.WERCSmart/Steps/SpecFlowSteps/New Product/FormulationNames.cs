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
		[StepDefinition(@"I enter the text of Provide the name(s) to be used to identify the formula field to: (.*)")]
		public void GivenEnterProvideTheNamesToBeUsedToIdentifyTheFormulaValue(string value)
		{
			Report.Info($"I set the text of Provide the name(s) to be used to identify the formula field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Provide the name(s) to be used to identify the formula", value);
		}

		[StepDefinition(@"I enter the text of Provide Public Name(s) of the formula you're registering field to: (.*)")]
		public void GivenEnterProvidePublicNamesOfTheFormulaYoureRegisteringValue(string value)
		{
			Report.Info($"I set the text of Provide Public Name(s) of the formula you're registering field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Provide Public Name(s) of the formula you're registering.  This will be available to the Supplier to select for your ingredient when the ingredient is indicated to be Publicly Available. Public Names are typically on a products label- website or other information available to the general public.", value);
		}

		[StepDefinition(@"I enter the text of cleaning products its Business-to-Consumer field to: (.*)")]
		public void GivenEnterCleaningProductsItsBusinessToConsumerValue(string value)
		{
			Report.Info($"I set the text of cleaning products its Business-to-Consumer field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("For ingredients used in cleaning products its Business-to-Consumer name must comply with the requirements of the California Cleaning Product Right to Know Act.  Manufacturer must use a name that is only as generic as necessary to protect the confidential identity of the ingredient. In developing the generic name- the manufacturer must use the generic name framework provided by the Federal Environmental Protection Agency (EPA) guidance for the Toxic Substances Control Act (TSCA) Confidential Inventory.", value);
		}
	}
}
