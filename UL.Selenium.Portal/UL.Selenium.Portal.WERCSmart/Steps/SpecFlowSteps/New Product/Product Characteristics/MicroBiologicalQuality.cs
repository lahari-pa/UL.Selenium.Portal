using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:MicroBiologicalQuality")]
	internal class MicroBiologicalQuality
	{

		[StepDefinition(@"I enter the text of Product designed for Age Group field to: (.*)")]
		public void GivenEnterProductDesignedForAgeGroupValue(string value)
		{
			Report.Info($"I set the text of Product designed for Age Group field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Product designed for Age Group", value);
		}

		[StepDefinition(@"I enter the text of Did any organisms survive the US Pharmacopia Microbiological Testing field to: (.*)")]
		public void GivenEnterDidAnyOrganismsSurviveTheUSPharmacopiaMicrobiologicalTestingValue(string value)
		{
			Report.Info($"I set the text of Did any organisms survive the US Pharmacopia Microbiological Testing field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Did any organisms survive the US Pharmacopia Microbiological Testing?", value);
		}

		[StepDefinition(@"I enter the text of If so- which micro-organisms survived field to: (.*)")]
		public void GivenEnterIfSoWhichMicroOrganismsSurvivedValue(string value)
		{
			Report.Info($"I set the text of If so- which micro-organisms survived field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("If so- which micro-organisms survived", value);
		}

	}
}
