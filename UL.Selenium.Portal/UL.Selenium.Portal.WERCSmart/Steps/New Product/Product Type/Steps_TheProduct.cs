using NTTQA.Selenium.Reporting.Core;
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
			Report.IsTrue(this.TheProduct.ProductName == productName, "Failed to set the Product Name");
		}
	}
}
