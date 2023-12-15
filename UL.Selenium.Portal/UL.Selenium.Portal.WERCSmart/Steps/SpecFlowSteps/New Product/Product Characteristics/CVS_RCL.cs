using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	internal class CVS_RCL
	{

		[StepDefinition(@"I enter the text of Indicate the brand field to: (.*)")]
		public void GivenEnterIndicateTheBrandValue(string value)
		{
			Report.Info($"I set the text of Indicate the brand field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Indicate the brand", value);
		}

		[StepDefinition(@"I enter the text of Indicate your Product Development Manager field to: (.*)")]
		public void GivenEnterIndicateYourProductDevelopmentManagerValue(string value)
		{
			Report.Info($"I set the text of Indicate your Product Development Manager field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Indicate your Product Development Manager", value);
		}

		[StepDefinition(@"I enter the text of Indicate your Product Category field to: (.*)")]
		public void GivenEnterIndicateYourProductCategoryValue(string value)
		{
			Report.Info($"I set the text of Indicate your Product Category field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Indicate your Product Category", value);
		}

	}
}
