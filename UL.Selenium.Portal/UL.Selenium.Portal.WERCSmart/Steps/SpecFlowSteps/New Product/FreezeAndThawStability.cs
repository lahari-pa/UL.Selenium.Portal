using Gherkin;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:FreezeAndStability")]
	internal class FreezeAndThawStability
	{

		[RegexStepDefinition(@"I enter the text of Please upload your product studies/test results field to: (.*)")]
		public void GivenEnterPleaseUploadYourProductStudiesTestResultsValue(string value)
		{
			Report.Info($"I set the text of Please upload your product studies/test results field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Please upload your product studies/test results", value);
		}

		[RegexStepDefinition(@"I enter the text of Product passed Freeze / Thaw Testing field to: (.*)")]
		public void GivenEnterProductPassedFreezeThawTestingValue(string value)
		{
			Report.Info($"I set the text of Product passed Freeze / Thaw Testing field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Product passed Freeze / Thaw Testing", value);
		}

	}
}
