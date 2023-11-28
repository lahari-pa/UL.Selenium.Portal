using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Type
{
	[Binding, Scope(Tag = "Product:WERCSmart_Account:Distributor_Page:NewProducts_Tab:ReciewAndSubmit_Section:OptionalReportsAndDocumentsAvailableForPurchase")]
	internal class OptionalReportsAndDocumentsAvailableForPurchase
	{
		[StepDefinition(@"In the Optional Reports and Documents Available for Purchase Section, set the option in section: (.*) to: (.*)")]
		public void SetContainsCircuitBoard(string section, string option)
		{
			new Steps_Prototype().IClickTheInputSectionAndSelect(section, option);
		}
		[StepDefinition(@"In the Optional Reports and Documents Available for Purchase Section, in section: (.*) the total price should be (.*)")]
		public void CheckPrice(string section, string value)
		{
			new Steps_Prototype().TotalForSectionShouldEqual(section, value);
		}
	}
}
