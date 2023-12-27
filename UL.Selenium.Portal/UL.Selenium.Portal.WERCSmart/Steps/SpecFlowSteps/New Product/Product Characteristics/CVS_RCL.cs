using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:CVS_RCL")]
	internal class CVS_RCL
	{
		[StepDefinition(@"I enter the text of what is the CVS merchandising category for this product field to: (.*)")]
		public void GivenEnterCVSMerchandisingCategoryForThisProductValue(string value)
		{
			Report.Info($"I set the text of what is the CVS merchandising category for this product field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("What is the CVS merchandising category for this product?", value);
		}

		[StepDefinition(@"I enter the text of who is the Product Development Manager (PDM) for this product field to: (.*)")]
		public void GivenEnterProductDevelopmentManagerPDMForThisProductValue(string value)
		{
			Report.Info($"I set the text of who is the Product Development Manager (PDM) for this product field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Who is the Product Development Manager (PDM) for this product?", value);
		}

		[StepDefinition(@"I enter the text of Indicate the brand field to: (.*)")]
		public void GivenEnterIndicateTheBrandValue(string value)
		{
			Report.Info($"I set the text of Indicate the brand field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Indicate the brand", value);
		}

		[StepDefinition(@"I enter the text of is this product specifically designed- marketed or labeled for infants- babies- or children field to: (Yes|No)")]
		public void GivenEnterProductSpecificallyDesignedMarketedOrLabeledtValue(string value)
			{ 
			Report.Info($"I set the text of is this product specifically designed- marketed or labeled for infants- babies- or children field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Is this product specifically designed- marketed or labeled for infants- babies- or children?", value);
		}

		[StepDefinition(@"I enter the text of Indicate your Product Development Manager field to: (.*)")]
		public void GivenEnterIndicateYourProductDevelopmentManagerValue(string value)
		{
			Report.Info($"I set the text of Indicate your Product Development Manager field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Indicate your Product Development Manager", value);
		}

		[StepDefinition(@"I enter the text of is this a topically used product which includes but is not limited to liquids- ointments- bath soaps/bombs- scrubs- masks- wipes- lotions- creams and gels field to: (Yes|No)")]
		public void GivenEnterTopicallyUsedProductWhichIncludesButIsNotLimitedToValue(string value)
		{ 
			Report.Info($"I set the text of is this a topically used product which includes but is not limited to liquids- ointments- bath soaps/bombs- scrubs- masks- wipes- lotions- creams and gels field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Is this a topically used product which includes but is not limited to liquids- ointments- bath soaps/bombs- scrubs- masks- wipes- lotions- creams and gels?", value);
		}

		[StepDefinition(@"I enter the text of Indicate your Product Category field to: (.*)")]
		public void GivenEnterIndicateYourProductCategoryValue(string value)
		{
			Report.Info($"I set the text of Indicate your Product Category field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Indicate your Product Category", value);
		}

		[StepDefinition(@"I enter the text of CVS Store Brand associated to this product field to: (.*)")]
		public void GivenEnterCVSStoreBrandAssociatedToThisProductValue(string value)
		{
			Report.Info($"I set the text of CVS Store Brand associated to this product field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("What is the CVS Store Brand associated to this product?", value);
		}

		[StepDefinition(@"I enter the text of Select the options that appear on the label field to: (.*)")]
		public void GivenEnterSelectTheOptionsThatAppearOnTheLabelValue(string value)
		{
			Report.Info($"I set the text of Select the options that appear on the label field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Refer to your Product Label. Select the options that appear on the label.", value);
		}





		[StepDefinition(@"I enter the text of Is this product intended to be rinsed off after use field to: (Yes|No)")]
		public void GivenEnterProductIntendedToBeRinsedOffAfterUseValue(string value)
		{
			Report.Info($"I set the text of Is this product intended to be rinsed off after use field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Is this product intended to be rinsed off after use?", value);
		}

		[StepDefinition(@"I enter the text of Does your product contain a Prop 65 chemical field to: (Yes|No)")]
		public void GivenEnterProductIntendedToBeIngestedValue(string value)
		{
			Report.Info($"I set the text of Is this product intended to be ingested field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Is this product intended to be ingested?", value);
		}

		[StepDefinition(@"I enter the text of This product a personal care sanitizer- wash- or cleanser field to: (Yes|No)")]
		public void GivenEnterThisProductAPersonalCareSanitizerWashOrCleanserValue(string value)
		{
			Report.Info($"I set the text of This product a personal care sanitizer- wash- or cleanser field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Is this product a personal care sanitizer- wash- or cleanser (e.g.- Hand- Body- Facial)?", value);
		}

	}
}
