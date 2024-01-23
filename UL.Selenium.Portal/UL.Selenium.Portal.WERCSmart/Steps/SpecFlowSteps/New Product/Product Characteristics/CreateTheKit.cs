using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:CreateTheKit")]
	class CreateTheKit
	{
		[StepDefinition(@"In the Create the Kit page add product: (.*)")]

		public void SelectProductCreateTheKit(string productName)
		{
			new Steps_Prototype().CreateTheKitAddProduct(productName);
		}

	}
}
