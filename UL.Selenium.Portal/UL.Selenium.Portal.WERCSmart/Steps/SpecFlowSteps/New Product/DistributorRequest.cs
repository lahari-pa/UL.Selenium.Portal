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
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:DistributorRequest")]
	internal class DistributorRequest
	{
		[RegexStepDefinition(@"In the 'Distributor Request' page, I enter the text of 'Manufacturer's Contact Email' field to: (.*)")]
		public void GivenEnterManufacturersContactEmailValue(string value)
		{
			Report.Info($"In the 'Distributor Request' page, I set the text of 'Manufacturer's Contact Email' field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Manufacturer's Contact Email", value);
		}

		[RegexStepDefinition(@"In the 'Distributor Request' page, I enter the text of 'Manufacturer's UPC for the Product' field to: (.*)")]
		public void GivenEnterManufacturersUPCForThProductValue(string value)
		{
			Report.Info($"In the 'Distributor Request' page, I set the text of 'Manufacturer's UPC for the Product' field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Manufacturer's UPC for the Product", value);
		}

		[RegexStepDefinition(@"In the 'Distributor Request' page, I enter the text of 'Product Name' field to: (.*)")]
		public void GivenEnterProductNameValue(string value)
		{
			Report.Info($"In the 'Distributor Request' page, I set the text of 'Product Name' field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("Product Name", value);
		}

		[RegexStepDefinition(@"In the 'Distributor Request' page, I enter the text of 'The Manufacturer has not yet approved the request.' field to: (.*)")]
		public void GivenEnterTheManufacturerHasNotYetApprovedTheRequestValue(string value)
		{
			Report.Info($"In the 'Distributor Request' page, I set the text of 'The Manufacturer has not yet approved the request.' field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("The Manufacturer has not yet approved the request", value);
		}

		[RegexStepDefinition(@"In the 'Distributor Request' page, I upload PDF document to 'Close Request Form' field")]
		public void UploadPDFDocumentToCloseRequestForm()
		{
			Report.Info($"In the 'Distributor Request' page, I upload PDF document to 'Close Request Form' field");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.UploadPDFFile("Close Request Form", "UL.Selenium.Portal.WERCSmart.Dependencies.PDF.testdoc.pdf");
		}

		[RegexStepDefinition(@"In the 'Distributor Request' page, I enter the text of 'The Manufacturer has rejected the request.' field to: (.*)")]
		public void GivenEnterTheTheManufacturerHasRejectedTheRequestValue(string value)
		{
			Report.Info($"In the 'Distributor Request' page, I set the text of 'The Manufacturer has rejected the request.' field to: {value}");
			var selNewProduct = new Steps_Prototype();
			selNewProduct.SetTheSectionOptionTo("The Manufacturer has rejected the request.", value);
		}

	}
}
