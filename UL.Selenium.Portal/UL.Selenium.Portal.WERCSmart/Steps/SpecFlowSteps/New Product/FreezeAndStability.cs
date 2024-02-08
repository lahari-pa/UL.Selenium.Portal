using Gherkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:FreezeAndStability")]
	internal class FreezeAndStability
	{
		[StepDefinition(@"I enter the text of Also known as Accelerated Conditions Testing field to: (.*)")]
		public void GivenEnterAlsoKnownAsAcceleratedConditionsTestingValue(string value)
		{
			Report.Info($"I set the text of Also known as Accelerated Conditions Testing field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Also known as Accelerated Conditions Testing", value);
		}

		[StepDefinition(@"I enter the text of Product passed Photo-stability Testing field to: (.*)")]
		public void GivenEnterProductPassedPhotoStabilityTestingValue(string value)
		{
			Report.Info($"I set the text of Product passed Photo-stability Testing field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Product passed Photo-stability Testing (Regulation EC No. 1223/2009 for light / UV radiation)", value);
		}

		[StepDefinition(@"I enter the text of Product passed the Consumer Product Safety Post Opening Testing field to: (.*)")]
		public void GivenEnterProductPassedTheConsumerProductSafetyPostOpeningTestingValue(string value)
		{
			Report.Info($"I set the text of Product passed the Consumer Product Safety Post Opening Testing field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Product passed the Consumer Product Safety Post Opening Testing for Poison Prevention Packaging Act of 1970 (PPPA) 15 U.S.C. SS 1471-1476", value);
		}
	}
}
