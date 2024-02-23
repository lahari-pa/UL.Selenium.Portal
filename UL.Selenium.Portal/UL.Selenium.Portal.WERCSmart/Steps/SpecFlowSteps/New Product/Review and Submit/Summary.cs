using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Review_and_Submit
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:Summary")]

	class SummaWERCSmart_Distributor_NewProducts_ReviewAndSubmit_Summary
	{
		[StepDefinition(@"In the Summary Page, the '(.*)' section should be showing the following value: (.*)")]
		public void InTheSummarySectionCheckTypeOfProduct(string section, string value)
		{
			new Steps_Prototype().ShouldBeShowingFollowing(section, value);
		}
	}
}
