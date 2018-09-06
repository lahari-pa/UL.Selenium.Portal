using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SafewareReporting;
using TechTalk.SpecFlow;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "DocumentAcceptance")]
	class Steps_DocumentAcceptance
	{
		[StepDefinition(@"I confirm there are products listed under My Products on the Document Acceptance page")]
		public void ConfirmThereAreProductsListedUnderMyProducts()
		{
			var selDocumentAcceptance = new DocumentAcceptance();
			var products = selDocumentAcceptance.GetProducts();
			Report.IsTrue(products.Any(),
				"No products were listed under My Products!",
				"There were products listed under My Products");
		}
	}
}
