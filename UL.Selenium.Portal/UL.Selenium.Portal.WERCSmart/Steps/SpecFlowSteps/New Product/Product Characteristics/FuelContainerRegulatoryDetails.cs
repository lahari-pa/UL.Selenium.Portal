using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:FuelContainerRegulatoryDetails")]
	internal class FuelContainerRegulatoryDetails
	{
		[StepDefinition(@"I enter the text of Product is a Safety Can field to: (Yes|No)")]
		public void GivenIEnterTheTextOfProductIsASafetyCanFieldTo(string value)
		{ 
			Report.Info($"I set the text of Product is a Safety Can field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Product is a Safety Can", value);
			
		}

		[StepDefinition(@"I enter the text of Product is sold in California field to: (Yes|No)")]
		public void GivenEnterProductIsSoldInCaliforniaValue(string value)
		{
			Report.Info($"I set the text of Product is sold in California field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Product is sold in California", value);
		}
	}
}
