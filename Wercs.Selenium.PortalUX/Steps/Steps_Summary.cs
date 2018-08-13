using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using ResourcePool;
using SafewareReporting;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "SummaryPage")]
	class Steps_Summary
	{
		[StepDefinition(@"in the Summary page I save the UPC number to context as: (.*)")]
		public void SaveUPCToContext(string savedAs)
		{
			var upc = new SummaryPage().UPCNumber();
			Context.AddToContext(savedAs, upc);
		}

		[StepDefinition(@"in the Summary page I save the Product ID to context as: (.*)")]
		public void SaveProductIDToContext(string savedAs)
		{
			var productID = new SummaryPage().ProductID();
			Context.AddToContext(savedAs, productID);
		}

		[StepDefinition(@"in the Summary page the UPC number should match that saved as: (.*)")]
		public void SummaryPageUPCShouldMatchSavedAs(string savedAs)
		{
			var actualUPC = new SummaryPage().UPCNumber();
			var expectedUPC = Context.GetFromContext(savedAs).ToString();
			Report.IsTrue(expectedUPC == actualUPC,
				"The actual UPC number did not match the expected value! Expected: " + expectedUPC + ". Actual: " + actualUPC,
				"The actual UPC number matched the expected value: " + expectedUPC);
		}
	}
}
