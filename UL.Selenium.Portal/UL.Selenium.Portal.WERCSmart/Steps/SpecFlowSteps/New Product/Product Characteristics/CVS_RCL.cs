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

		[StepDefinition(@"I enter the text of product contains microbeads field to: (Yes|No)")]
		public void GivenEnteProductContainsMicrobeadslValue(string value)
		{
			Report.Info($"I set the text of product contains microbeads field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Product contains microbeads?", value);
		}

		[StepDefinition(@"I enter the text of list the label claims for the product field to: (.*)")]
		public void GivenEnterListTheLabelClaimsForTheProductValue(string value)
		{
			Report.Info($"I set the text of list the label claims for the product field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("List the label claims for the product", value);
		}

		[StepDefinition(@"I enter the text of list the foreseeable mis-uses for the product field to: (.*)")]
		public void GivenEnterListTheForeseeableMisusesForTheProductValue(string value)
		{
			Report.Info($"I set the text of list the foreseeable mis-uses for the product field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("List the foreseeable mis-uses for the product", value);
		}

		[StepDefinition(@"I enter the text of select all body parts where the product may be applied field to: (.*)")]
		public void GivenEnteSelectAllBodyPartsWhereTheProductMayBeAppliedValue(string value)
		{
			Report.Info($"I set the text of select all body parts where the product may be applied field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("select all body parts where the product may be applied", value);
		}

		[StepDefinition(@"I enter the text of Other field to: (.*)")]
		public void GivenEnterOtherValue(string value)
		{
			Report.Info($"I set the text of Other field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Other", value);
		}

	}
}
