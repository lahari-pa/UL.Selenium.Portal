using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;



namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "OrderHistoryPage")]
	class Steps_OrderHistory
	{
		[RegexStepDefinition(@"In the Order History section, Click on (Subscription|WERCSmart)")]
		public void ClickTheOrderHistoryLink(string linkText)
		{
			new Steps_Prototype().ClickLinkElement(linkText);
		}

		[RegexStepDefinition(@"In the Order History section, Click Filter button")]
		public void ClickFlterButton()
		{
			string button = "Filter";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the Order History section, Click Clear Filter button")]
		public void ClickClearFlterButton()
		{
			string button = "Clear Filter";
			new Steps_Prototype().ClickButton(button);
		}

		[RegexStepDefinition(@"In the Order History section, Verify WERCSmart table is displayed")]
		public void VerifyWERCSmartTableIsDisplayed()
		{
			Report.IsTrue(new OrderHistoryPage().TableExists(), $"WERCSmart table is not displayed", $"Successfully WERCSmart table is displayed");
		}

		[RegexStepDefinition(@"In the Order History section, Verify Subscription table is displayed")]
		public void VerifySubscriptionTableIsDisplayed()
		{
			Report.IsTrue(new OrderHistoryPage().TableExists(), $"Subscription table is not displayed", $"Successfully Subscription table is displayed");
		}

		[RegexStepDefinition(@"In the Order History section, click action (View details|Close) for order number: (.*)")]
		public void ClickActionForOrder(string ordernumber, string action)
		{
			Report.IsTrue(new OrderHistoryPage().ClickAction(ordernumber, action),
				$"Failed to click action:{action} for order: {ordernumber}",
				$"Successfully clicked action: {action} for order: {ordernumber}");
		}



	}


}


