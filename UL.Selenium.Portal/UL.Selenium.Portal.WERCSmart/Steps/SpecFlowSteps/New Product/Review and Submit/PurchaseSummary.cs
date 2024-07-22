using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Review_and_Submit
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:PurchaseSummary")]

	class SummaWERCSmart_Distributor_NewProducts_ReviewAndSubmit_PurchaseSummary
	{
		[RegexStepDefinition(@"The Purchase Summary Page is displayed")]
		public void PurchaseSummaryIsDisplayed()
		{
			new Steps_PaymentMethods().ThenThePurchaseSummaryShouldLoad();
		}
		[RegexStepDefinition(@"In the Purchase Summary Page, click the 'Home' button")]
		public void ClickHomeButtonInPurchaseSummary()
		{
			new Steps_PaymentMethods().ThenInTheThankYouScreenIClickHome();
		}
		[RegexStepDefinition("In the Purchase Summary page message is displayed with text: (.*)")]
		public void ThenInThePurchaseSummaryPageMessageIsDisplayedWithText( string text)
		{
			if (!new PaymentMethods_Thank_You().Thank_You_TextExists(text))
			{
				Report.Info($"Failed to confirm message '{text}' is displayed. Attempt to verify thenk you message after upgrading the subscription");
				Report.IsTrue(new PaymentMethods_Thank_You().Thank_You_TextExists("You have successfully upgraded your subscription plan. Thank you for relying on UL to provide over 45 retailers with critical product information they need in order to on-board your products and keep employees, consumers, and the environment safe."), $"Failed to confirm message 'You have successfully upgraded your subscription plan. Thank you for relying on UL to provide over 45 retailers with critical product information they need in order to on-board your products and keep employees, consumers, and the environment safe.We are committed to helping you monitor and manage all of your product data needs with the highest standards of confidentiality and service. If we can be of any assistance, please contact our Support Team or review our Support Site for helpful tools.' is displayed", $"Successfully confirmed message 'You have successfully upgraded your subscription plan. Thank you for relying on UL to provide over 45 retailers with critical product information they need in order to on-board your products and keep employees, consumers, and the environment safe.\r\n\r\nWe are committed to helping you monitor and manage all of your product data needs with the highest standards of confidentiality and service. If we can be of any assistance, please contact our Support Team or review our Support Site for helpful tools.' is displayed");
			}
			else
			{
				Report.Success($"Successfully confirmed message '{text}' is displayed");
			}

		}


	}
}
