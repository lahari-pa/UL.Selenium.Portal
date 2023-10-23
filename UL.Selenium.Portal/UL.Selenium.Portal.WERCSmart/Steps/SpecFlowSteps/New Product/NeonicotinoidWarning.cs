using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:NeonicotinoidWarning")]
	class WERCSmart_Distributor_NewProducts_ProductCharacteristics_NeonicotinoidWarning
	{
		[StepDefinition(@"In the Neonicotinoid Warning Section, warning message (should|should not) be displayed")]
		public void NeonicotinoidWarningMessage(string condition)
		{
			string title = "Danger & Warning";
			string subTitle = "This product contains a neonicotinoid pesticide which may adversely affect pollinating bee populations.";
			string text = "Presence of this ingredient may limit the sale of this product through a Retailer. Please refer to the EPA website for more information.";
			new Steps_Prototype().ThenIShouldSeeAnAlertWithTitleSubtitleText(condition, title, subTitle, text);
		}
	}
}
