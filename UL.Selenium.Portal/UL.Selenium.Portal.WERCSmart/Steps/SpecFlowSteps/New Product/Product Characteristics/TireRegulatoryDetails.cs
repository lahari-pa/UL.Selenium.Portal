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
		[StepDefinition(@"I enter the text of Product is intended for agricultural use only field to: (Yes|No)")]
		public void GivenIEnterTheTextOfProductIsIntendedForAgriculturalUseOnlyFieldTo(string value)
		{
			Report.Info($"I set the text of Product is intended for agricultural use only field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Product is intended for agricultural use only", value);
		}
	}
}
