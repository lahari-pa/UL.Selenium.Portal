using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Steps.New_Product;


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
				Report.Info($"Failed to confirm message '{text}' is displayed. Attempt to verify thank you message after upgrading the subscription");
				Report.IsTrue(new PaymentMethods_Thank_You().Thank_You_TextExists("You have successfully upgraded your subscription plan. Thank you for relying on UL to provide over 45 retailers with critical product information they need in order to on-board your products and keep employees, consumers, and the environment safe."), $"Failed to confirm message 'You have successfully upgraded your subscription plan. Thank you for relying on UL to provide over 45 retailers with critical product information they need in order to on-board your products and keep employees, consumers, and the environment safe.We are committed to helping you monitor and manage all of your product data needs with the highest standards of confidentiality and service. If we can be of any assistance, please contact our Support Team or review our Support Site for helpful tools.' is displayed", $"Successfully confirmed message 'You have successfully upgraded your subscription plan. Thank you for relying on UL to provide over 45 retailers with critical product information they need in order to on-board your products and keep employees, consumers, and the environment safe.\r\n\r\nWe are committed to helping you monitor and manage all of your product data needs with the highest standards of confidentiality and service. If we can be of any assistance, please contact our Support Team or review our Support Site for helpful tools.' is displayed");
			}
			else
			{
				Report.Success($"Successfully confirmed message '{text}' is displayed");
			}
		}

		[RegexStepDefinition(@"In the Purchase Summary Page, confirm heading 'Product Billing' (is|is not) displayed")]
		public void ProductBillingHeadingPurchaseSummary(string is_isnot)
		{
			bool expected = is_isnot == "is";
			Report.IsTrue(new PaymentMethods_Subscription_Billing().Product_Billing_Header_Displayed() == expected, $"Failure, heading 'Product Billing' {(expected ? "is not" : "is")} displayed", $"Success, heading 'Product Billing' {is_isnot} displayed.");
		}

		[RegexStepDefinition(@"In the Purchase Summary Page, confirm Product Billing table (is|is not) displayed")]
		public void ProductBillingTablePurchaseSummary(string is_isnot)
		{
			bool expected = is_isnot == "is";
			if (Report.IsTrue(new PurchaseSummary().ProductBillingTableExists() == expected, $"Failure, table 'Product Billing' {(expected ? "is not" : "is")} exist", $"Success, table 'Product Billing' {is_isnot} exist."))
			{
				Report.IsTrue(new PurchaseSummary().ProductBillingTableIsDisplayed() == expected, $"Failure, table 'Product Billing' {(expected ? "is not" : "is")} displayed", $"Success, table 'Product Billing' {is_isnot} displayed.");
			}
		}

		[RegexStepDefinition(@"In the Purchase Summary Page, the 'Prices and Payment' text message (should|should not) be displayed")]
		public void LithiumBatteryTransportationTextInAlertMessage(string condition)
		{
			string alertText = "Prices and Payment\r\nPrices are quoted in U.S. Dollars and applicable sales tax will be reflected on your final invoice based on your billing location. Payment may be made by credit card, ACH transfer or such other methods as may introduced by UL. Payment is required when your order is submitted. The method of payment designated on the My Account area will be used. UL reserves the right to accept or refuse any payment made in any form. UL does not collect or process your payment details. Credit card providers may confirm your order. Payment processing delays may also delay processing of your order.";
			new Steps_Prototype().AlertMessageDisplayed(condition, alertText);
		}
				
		[RegexStepDefinition(@"In the Purchase Summary Page, the 'Save for Later' button (is|is not) displayed")]
		public void CheckSaveForLaterButtonExists(string is_isnot)
		{
			bool expected = is_isnot == "is";
			string button = "Save for Later";
			Report.IsTrue(new NewProduct().ButtonExists(button) == expected, $"Failed to confirm the 'Save for Later' button {(expected ? "is not" : "is")} displayed",
							$"Successfully confirmed the 'Save for Later' button {expected} displayed");
		}
		[RegexStepDefinition(@"In the Purchase Summary Page, the 'Confirm Order' button (is|is not) displayed")]
		public void CheckConfirmOrderButtonExists(string is_isnot)
		{
			bool expected = is_isnot == "is";
			string button = "Confirm Order ";
			Report.IsTrue(new NewProduct().ButtonExists(button) == expected, $"Failed to confirm the 'Confirm Order' button {(expected ? "is not" : "is")} displayed",
										$"Successfully confirmed the 'Confirm Order' button {expected} displayed");
		}
		[RegexStepDefinition(@"In the Purchase Summary Page, click the 'Confirm Order' button")]
		public void ClickConfirmOrderButtonExists()
		{
			string button = "Confirm Order ";
			new Steps_Prototype().ClickButton(button);
		}
		[RegexStepDefinition(@"In the Purchase Summary Page, click the 'Save for Later' button")]
		public void ClickSaveForLaterButtonExists()
		{
			string button = "Save for Later";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the Purchase Summary Page, verify 'Item Description' shows Product's Name: (.*) and product ID saved as: (.*)")]
		public void VerifyItemDescriptionProductName(string productName, string savedAs)
		{
			var productDetails = (Selenium_Classes.New_Product.ProductInformation)Context.GetFromContext(savedAs);
			string id = productDetails.Id;
			productName = productName + $" ({id})";
		
			Report.IsTrue(new PurchaseSummary().GetProductName() == productName, $"Failed to confirm product's name '{productName}' is displayed", $"Successfully confirmed product's name '{productName}' is displayed");
		}

		[RegexStepDefinition(@"In the Purchase Summary Page, verify the 'Chemical Assessment' for NR \(No Retailer\/No UPC\) not have a charge")]
		public void VerifyItemDescriptionCharge()
		{
			string itemDescription = "Chemical assessment";
			string retailer = "No Retailer/No UPC Product";
			string amount = "$0.00";
			if(Report.IsTrue(new PurchaseSummary().TableRowExists(itemDescription), $"Failed to confirm table row with Item Description {itemDescription} exists", $"Successfully confirmed row with Item Description {itemDescription} exists"))
			{
				Report.IsTrue(new PurchaseSummary().GetRetailerName(itemDescription) == retailer, $"Failed to confirm the displayed retailer for {itemDescription} is {retailer}", $"Successfully confirmed the displayed retailer for {itemDescription} is {retailer}");
				Report.IsTrue(new PurchaseSummary().GetAmount(itemDescription).Equals(amount), $"Failed to confirm the amount for {itemDescription} is {amount}", $"Successfully confirmed the amount for {itemDescription} is {amount}");

			}
		}
		[RegexStepDefinition(@"In the Purchase Summary Page, verify the 'SDS authoring North American Combined GHS SDS ENGLISH \(USA\)' for NR \(No Retailer\/No UPC\) have a charge")]
		public void VerifyItemDescriptionIsCharged()
		{
			string itemDescription = "SDS authoring North American Combined GHS SDS ENGLISH (USA)";
			string retailer = "No Retailer/No UPC Product";
			string amount = "$0.00";
			if (Report.IsTrue(new PurchaseSummary().TableRowExists(itemDescription), $"Failed to confirm table row with Item Description {itemDescription} exists", $"Successfully confirmed row with Item Description {itemDescription} exists"))
			{
				Report.IsTrue(new PurchaseSummary().GetRetailerName(itemDescription) == retailer, $"Failed to confirm the displayed retailer for {itemDescription} is {retailer}", $"Successfully confirmed the displayed retailer for {itemDescription} is {retailer}");
				Report.IsFalse(new PurchaseSummary().GetAmount(itemDescription).Equals(amount), $"Failed to confirm the amount for {itemDescription} is not {amount}", $"Successfully confirmed the amount for {itemDescription} is not {amount}");
			}
		}
	}
}
