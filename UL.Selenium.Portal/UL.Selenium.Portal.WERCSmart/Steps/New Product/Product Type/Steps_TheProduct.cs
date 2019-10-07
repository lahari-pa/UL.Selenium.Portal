using System;
using NTTQA.Selenium.Reporting.Core;
using NTTQA.Selenium.SpecFlow;
using NUnit.Framework.Internal;
using TechTalk.SpecFlow;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product.Product_Type;

namespace UL.Selenium.Portal.WERCSmart.Steps.New_Product.Product_Type
{
	[Binding, Scope(Tag = "NewProduct")]
	class Steps_TheProduct
	{
		private TheProduct TheProduct => new TheProduct();

		[StepDefinition(@"I set 'Product Name' to: (.*)")]
		public void SetProductNameTo(string productName)
		{
			Report.IsTrue(this.TheProduct.WaitForTab(NewProduct.Tab.ProductType), "Product Type tab is not active",
				"Product Type tab is loaded.");
			Report.Info("Setting Product Name to: " + productName);
			this.TheProduct.ProductName = productName;
			Report.IsTrue(this.TheProduct.ProductName == productName, "Failed to set the Product Name", "Successfully set the Product Name");
		}

		[StepDefinition(@"I set 'Type of Product' to: (.*)")]
		public void SetTypeOfProductTo(string typeOfProduct)
		{
			Report.IsTrue(this.TheProduct.WaitForTab(NewProduct.Tab.ProductType), "Product type has not loaded", "Product type tab is loaded.");
			this.TheProduct.ProductType = typeOfProduct;
			Report.IsTrue(this.TheProduct.ProductType.ToLower().Contains(typeOfProduct.ToLower()), "Failed to set Type of Product to: " + typeOfProduct, "Successfully set Type of Product to: " + typeOfProduct);
		}

		[StepDefinition(@"I set 'Product Line Or Brand' to: (.*)'")]
		public void SetProductLineOrBrand(string lineOrBrand)
		{
			Report.IsTrue(this.TheProduct.WaitForTab(NewProduct.Tab.ProductType), "Product type has not loaded", "Product type tab is loaded.");
			this.TheProduct.ProductLineOrBrand = lineOrBrand;
			Report.IsTrue(this.TheProduct.ProductLineOrBrand == lineOrBrand, "Failed to Set Product Line or Brand", "Set Product Line or Brand");
		}

		[StepDefinition(@"I set Product Name to: (.*) Type of Product to: (.*) and Product Line Or Brand to: (.*)")]
		public void SetProductNameProductTypeProductLine(string name, string type, string brand)
		{
			TestReport.UseSubSteps = true;
			TestReport.StartStep("Setting Product Name to: " + name);
			this.SetProductNameTo(name);
			TestReport.StartStep("Setting Product Line or Brand to: " + brand);
			this.SetProductLineOrBrand(brand);
			TestReport.StartStep("Setting Type of Product to: " + type);
			this.SetTypeOfProductTo(type);
			new StepsNewProduct().ClickContinue();

		}
	}
}
