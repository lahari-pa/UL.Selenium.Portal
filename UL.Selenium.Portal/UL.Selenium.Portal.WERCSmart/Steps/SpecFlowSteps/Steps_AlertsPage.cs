using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.ReqnrollHelpers.Classes;



namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "AlertsPage")]
	class Steps_AlertsPage
	{
		[RegexStepDefinition(@"In the Alerts section, Enter WPS ID: (.*)")]
		public void EnterWpsID(string wpsId)
		{
			Report.StartStep("Verify WPS ID field is displayed");
			new AlertsPage().WpsIdFieldExists();
			Report.StartStep("Entering wps id: " + wpsId);
			new AlertsPage().NotificationDateText(wpsId);


		}

		[RegexStepDefinition(@"In the Alerts section, Enter Product Name: (.*)")]
		public void EnterProductName(string productName)
		{
			Report.StartStep("Verify Product name field is displayed");
			new AlertsPage().ProductNameFieldExists();
			Report.StartStep("Entering product name: " + productName);
			new AlertsPage().ProductNameText(productName);


		}
	}
}
