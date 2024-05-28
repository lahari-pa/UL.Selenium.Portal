using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UL.Automation.Reporting.Functions;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductType_Section:ECOLOGO")]
	internal class ECOLOGO
	{
		[RegexStepDefinition(@"In the ECOLOGO Readiness Section, set the option in section: 'Take advantage of Premium Subscription benefits by electing to receive a UL ECOLOGO Readiness Assessment...': to: (Yes|Not at this time)")]
		public void GivenEnterTakedvantageOfPremiumSubscriptionBenefitsValue(string value)
		{
			Report.Info($"I set the text of Take advantage of Premium Subscription benefits field to: {value}");
			var selNewProduct = new Steps_Prototype();
			string section = "Take advantage of Premium Subscription benefits by electing to receive a UL ECOLOGO Readiness Assessment.  This report will indicate if the product is eligible to be awarded an ECOLOGO Certification, an established symbol of reduced environmental impact. Would you like to receive this assessment?";
			selNewProduct.SetTheSectionOptionTo(section, value);
		}
	}
}
