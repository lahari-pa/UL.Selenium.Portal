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
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:FuelContainerRegulatoryDetails")]
	internal class FuelContainerRegulatoryDetails
	{
		[RegexStepDefinition(@"In the Fuel Container Regulatory Details Section, set the option in section: 'Product is a Safety Can' to: (Yes|No)")]
		public void GivenIEnterTheTextOfProductIsASafetyCanFieldTo(string value)
		{ 
			Report.Info($"I set the text of Product is a Safety Can field to: {value}");
			var selNewProduct = new Steps_Prototype();
			string section = "Product is a Safety Can";
			selNewProduct.SetTheSectionOptionTo(section, value);
		}
		[RegexStepDefinition(@"In the Fuel Container Regulatory Details Section, set the option in section: 'Product is sold in California' to: (Yes|No)")]
		public void GivenEnterProductIsSoldInCaliforniaValue(string value)
		{
			Report.Info($"I set the text of Product is sold in California field to: {value}");
			var selNewProduct = new Steps_Prototype();
			string section = "Product is sold in California";
			selNewProduct.SetTheSectionOptionTo(section, value);
		}
	}
}
