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

	}
}
