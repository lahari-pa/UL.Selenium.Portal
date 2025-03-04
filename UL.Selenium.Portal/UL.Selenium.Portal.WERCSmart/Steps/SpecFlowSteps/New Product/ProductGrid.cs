using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;



namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "ProductGrid")]
	class ProductGrid
	{
		[RegexStepDefinition(@"In the Product Grid, delete the product saved as: (.*)")]
		public void DeleteAProductFromTheProductGrid(string savedAs)
		{
			//new ProductsGrid().DeleteAProduct(savedAs);
			new Steps_MyProductsPage().MyProductsPageDeleteProductSavedAs(savedAs);
		}

		[RegexStepDefinition(@"In the Product Grid, delete all products with UPC Number: (.*)")]
		public void DeleteAllProductsMatchingCriteria(string value)
		{
			new ProductsGrid().DeleteAllProductsMatchingCriteria(value);
		}

	}
}
