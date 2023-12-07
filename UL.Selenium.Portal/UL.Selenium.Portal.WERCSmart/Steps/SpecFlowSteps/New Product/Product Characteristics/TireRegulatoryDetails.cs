using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TireRegulatoryDetails")]
	internal class TireRegulatoryDetails
	{

		[StepDefinition(@"I enter the text of Weight in kilograms \(single unit\) field to: (.*)")]
		public void GivenIEnterTheTextOfWeightInKilogramsSingleUnitFieldTo(string value)
		{
			Report.Info(string.Format("I set the text of Weight in kilograms \\(single unit\\) field to: {0}", value));
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Weight in kilograms (single unit)", value);
		}

		[StepDefinition(@"I enter the text of Height in inches \(single unit\) field to: (.*)")]
		public void GivenIEnterTheTextOHeightInInchesSingleUnitFieldTo(string value)
		{
			Report.Info(string.Format("I set the text of Height in Inches \\(single unit\\) field to: {0}", value));
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Height in inches (single unit)", value);
		}

		[StepDefinition(@"I enter the text of Product Container Or Liner Contains Bisphenol ABPA field to: (Yes|No)")]
		public void GivenEnterProductContainerOrLinerContainsBisphenolABPAValue(string value)
		{
			Report.Info(string.Format("I set the text of Product Container Or Liner Contains Bisphenol ABPA field to: {0}", value));
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Product Container Or Liner Contains Bisphenol ABPA", value);
		}

	}
}
