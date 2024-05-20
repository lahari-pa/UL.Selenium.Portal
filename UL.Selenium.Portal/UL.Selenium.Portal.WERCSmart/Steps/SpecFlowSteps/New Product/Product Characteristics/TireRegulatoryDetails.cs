using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:TireRegulatoryDetails")]
	internal class TireRegulatoryDetails
	{

		[RegexStepDefinition(@"I enter the text of Product is intended for agricultural use only field to: (Yes|No)")]
		public void GivenIEnterTheTextOfProductIsIntendedForAgriculturalUseOnlyFieldTo(string value)
		{
			Report.Info($"I set the text of Product is intended for agricultural use only field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Product is intended for agricultural use only", value);
		}

		[RegexStepDefinition(@"I enter the text of Weight in kilograms \(single unit\) field to: (.*)")]
		public void GivenIEnterTheTextOfWeightInKilogramsSingleUnitFieldTo(string value)
		{
			Report.Info($"I set the text of Weight in kilograms \\(single unit\\) field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Weight in kilograms (single unit)", value);
		}

		[RegexStepDefinition(@"I enter the text of Height in inches \(single unit\) field to: (.*)")]
		public void GivenIEnterTheTextOHeightInInchesSingleUnitFieldTo(string value)
		{
			Report.Info($"I set the text of Height in Inches \\(single unit\\) field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Height in inches (single unit)", value);
		}

		[RegexStepDefinition(@"I enter the text of Product Container Or Liner Contains Bisphenol ABPA field to: (Yes|No)")]
		public void GivenEnterProductContainerOrLinerContainsBisphenolABPAValue(string value)
		{
			Report.Info($"I set the text of Product Container Or Liner Contains Bisphenol ABPA field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Product Container Or Liner Contains Bisphenol ABPA", value);
		}

	}
}
