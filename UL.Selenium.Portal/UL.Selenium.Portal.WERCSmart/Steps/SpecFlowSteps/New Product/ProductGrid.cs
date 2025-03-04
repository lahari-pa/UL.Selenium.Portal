using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;



namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "ProductGrid")]
	class ProductGrid
	{
		[RegexStepDefinition(@"In the Product Grid, delete the product saved as: (.*)")]
		public void DeleteAProductFromTheProductGrid(string savedAs)
		{
			new ProductsGrid().DeleteAProduct(savedAs);
		}

		[RegexStepDefinition(@"In the Product Grid, delete all products with UPC Number: (.*)")]
		public void DeleteAllProductsMatchingCriteria(string value)
		{
			new ProductsGrid().DeleteAllProductsMatchingCriteria(value);
		}
		[RegexStepDefinition(@"In the Product Grid, click the 'Product ID/ Name' search input textbox")]
		public void ClickProductIDSearchbox()
		{
			new Steps_MyProductsPage().MyProductsPageProductIDNameTextSearchInputClick();
		}
		[RegexStepDefinition(@"In the Product Grid, in 'Product ID/ Name' search input textbox, enter the product id savedas: (.*)")]
		public void EnterProductIDSearchbox(string savedas)
		{
			Report.Info("Attempting to get product from context");
			if (!Context.Contains(savedas))
			{
				Report.Failure($"Context did not contain the Product saved as: {savedas}");
			}
			else
			{
				Report.Info("Found in Context");
			}
			var obj = Context.GetFromContext(savedas);
			Report.Info("Attempting to convert Product to type ProductInformation");
			var Product = (ProductInformation)obj;
			new Steps_MyProductsPage().MyProductsPageProductIDNameTextSearchInputEnterText(savedas);
		}
	}
}
