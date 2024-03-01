using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Review_and_Submit
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:PurchaseSummary")]

	class SummaWERCSmart_Distributor_NewProducts_ReviewAndSubmit_PurchaseSummary
	{
		[StepDefinition(@"The Purchase Summary Page is displayed")]
		public void PurchaseSummaryIsDisplayed()
		{
			new Steps_PaymentMethods().ThenThePurchaseSummaryShouldLoad();
		}
		[StepDefinition(@"In the Purchase Summary Page, click the 'Home' button")]
		public void ClickHomeButtonInPurchaseSummary()
		{
			new Steps_PaymentMethods().ThenInTheThankYouScreenIClickHome();
		}

	}
}
