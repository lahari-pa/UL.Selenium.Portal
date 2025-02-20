using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:MyAccount:SubscriptionInformation")]

	class Steps_SubscriptionInformation
	{
		[RegexStepDefinition(@"In the Subscription Information section, verify the company name is (.*)")]
		public void VerifyCompanyName(string companyName)
		{
			if (Report.IsTrue(new SubscriptionInformation().CompanyNameExists(companyName), $"Failed to find the company name '{companyName}'", $"Successfully found the company name '{companyName}'"))
			{
				Report.IsTrue(new SubscriptionInformation().CompanyNameDisplayed(companyName), $"Failed to confirm the company name '{companyName}' is displayed", $"Successfully confirmed the company name '{companyName}' is displayed");
			}
		}
		[RegexStepDefinition(@"In the Subscription Information section, verify the (Grace Period|Credit Balance|Invoice Total Balance) is (.*)")]
		public void VerifySubscriptionInformationData(string field, string value)
		{
			if (Report.IsTrue(new SubscriptionInformation().DataFieldExists(field, value), $"Failed to find the '{field}' is '{value}'", $"Successfully found the '{field}' is '{value}'"))
			{
				Report.IsTrue(new SubscriptionInformation().VerifyDataFieldValueIsDisplayed(field, value), $"Failed to confirm the '{field}' is displayed with value: '{value}'", $"Successfully confirmed the '{field}' is displayed with value: '{value}'");
			}
		}
		[RegexStepDefinition(@"In the Subscription Information section, verify the Subscription option '(Level:|Agent Support:|Formulated:|Enhanced:|Article:|Single-Retailer:)' is (.*)")]
		public void CheckSubscriptionDataInTheSubscriptionInfo(string option, string value)
		{
			Report.IsTrue(new SubscriptionInformation().VerifySubscriptionInfoValues(option, value), $"Failed to confirm the Subscription option '{option}' is '{value}'", $"Successfully confirmed the Subscription option '{option}' is '{value}'");

		}
		[RegexStepDefinition(@"In the Subscription Information section, click the 'Upgrade' button")]
		public void ClickTheUpgradeButton()
		{
			string button = "Upgrade";
			new Steps_Prototype().ClickButton(button);
		}
		[RegexStepDefinition(@"In the Subscription Information section, verify the Status is (.*)")]
		public void VerifySubscriptionInformationDataStatus(string value)
		{
			string field = "Status"; 
			if (Report.IsTrue(new SubscriptionInformation().DataOptionExists(field), $"Failed to find the field '{field}'", $"Successfully found the field '{field}'."))
			{
				if (Report.IsTrue(new SubscriptionInformation().TextExists(), $"Failed to find the text on the page", $"Successfully found the text on the page"))
				{
					Report.IsTrue(new SubscriptionInformation().GetText().Contains(value), $"Failed to confirm the '{field}' is displayed with value: '{value}'", $"Successfully confirmed the '{field}' is displayed with value: '{value}'");
				}
			}
		}
		[RegexStepDefinition(@"In the Subscription Information section, verify the Last Invoiced is (.*)")]
		public void VerifySubscriptionInformationDataLastInvoiced(string value)
		{
			string field = "Status";
			if (Report.IsTrue(new SubscriptionInformation().DataOptionExists(field), $"Failed to find the field '{field}'", $"Successfully found the field '{field}'."))
			{
				if (Report.IsTrue(new SubscriptionInformation().TextExists(), $"Failed to find the text on the page", $"Successfully found the the text on the page"))
				{
					Report.IsTrue(new SubscriptionInformation().GetText().Contains(value), $"Failed to confirm the '{field}' is displayed with value: '{value}'", $"Successfully confirmed the '{field}' is displayed with value: '{value}'");
				}
			}
		}
		[RegexStepDefinition(@"In the Subscription Information section, verify the number of (Submitted|In Cart) products is (.*)")]
		public void VerifyNumberOfSubmittedOrInCartProducts(string submittedOrInCart, string value)
		{
			if (Report.IsTrue(new SubscriptionInformation().NumberOfSubmittedOrInCartExists(submittedOrInCart), $"Failed to find the number of {submittedOrInCart} products", $"Successfully found the number of {submittedOrInCart} products"))
			{
				Report.IsTrue(new SubscriptionInformation().GetNumberOfSubmittedOrInCart(submittedOrInCart) == value, $"Failed to confirm the number of {submittedOrInCart} products is '{value}'", $"Successfully confirmed the number of {submittedOrInCart} products is '{value}'");
			}
		}
		[RegexStepDefinition(@"In the Subscription Information section, verify the number of (Articles|Enhanced Articles|Formulated|Single Retailer) products under the (Submitted|In Cart) section is (.*)")]
		public void VerifyNumberOfProducts(string productType, string submittedOrInCart, string value)
		{
			if (Report.IsTrue(new SubscriptionInformation().NumberOfProductsExists(submittedOrInCart, productType), $"Failed to find the number of {productType} products under the '{submittedOrInCart}' section", $"Successfully found the number of {productType} products under the '{submittedOrInCart}' section"))
			{
				Report.IsTrue(new SubscriptionInformation().GetNumberOfProducts(submittedOrInCart, productType) == value, $"Failed to confirm the number of {productType} products under the '{submittedOrInCart}' section is '{value}'", $"Successfully confirmed the number of {productType} products under the '{submittedOrInCart}' section is '{value}'");
			}
		}
	}
}
