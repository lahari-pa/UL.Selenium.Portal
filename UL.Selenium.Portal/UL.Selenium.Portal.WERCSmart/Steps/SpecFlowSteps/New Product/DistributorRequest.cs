using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:DistributorRequest")]
	internal class DistributorRequest
	{
		[StepDefinition(@"I enter the text of Manufacturer's Contact Email field to: (.*)")]
		public void GivenEnterManufacturersContactEmailValue(string value)
		{
			Report.Info($"I set the text of Manufacturer's Contact Email field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Manufacturer's Contact Email", value);
		}

		[StepDefinition(@"I enter the text of Manufacturer's UPC for the Product field to: (.*)")]
		public void GivenEnterManufacturersUPCForThProductValue(string value)
		{
			Report.Info($"I set the text of Manufacturer's UPC for the Product field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Manufacturer's UPC for the Product", value);
		}

		[StepDefinition(@"I enter the text of Product Name field to: (.*)")]
		public void GivenEnterProductNameValue(string value)
		{
			Report.Info($"I set the text of Product Name field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Product Name", value);
		}

		[StepDefinition(@"I enter the text of The Manufacturer has not yet approved the request. field to: (.*)")]
		public void GivenEnterTheManufacturerHasNotYetApprovedTheRequestValue(string value)
		{
			Report.Info($"I set the text of The Manufacturer has not yet approved the request. field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("The Manufacturer has not yet approved the request", value);
		}
	}
}
