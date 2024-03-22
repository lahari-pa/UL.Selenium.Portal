using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "ProductGrid")]
	 class ProductGrid
	{
		[StepDefinition(@"In the Product Grid, delete the product saved as: (.*)")]
		public void DeleteAProductFromTheProductGrid(string savedAs)
		{
			new Steps_Prototype().DeleteAProduct(savedAs);
		}




	}
}
