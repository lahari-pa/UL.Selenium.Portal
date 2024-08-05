using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:NeonicotinoidWarning")]
	class WERCSmart_Distributor_NewProducts_ProductCharacteristics_NeonicotinoidWarning
	{
		[RegexStepDefinition(@"In the Neonicotinoid Warning Section, warning message (should|should not) be displayed")]
		public void NeonicotinoidWarningMessage(string condition)
		{
			string title = "Danger & Warning";
			string subTitle = "This product contains a neonicotinoid pesticide which may adversely affect pollinating bee populations.";
			string text = "Presence of this ingredient may limit the sale of this product through a Retailer. Please refer to the EPA website for more information.";
			new Steps_Prototype().ThenIShouldSeeAnAlertWithTitleSubtitleText(condition, title, subTitle, text);
		}
		[RegexStepDefinition(@"In the Neonicotinoid Warning Section, click 'EPA website' link")]
		public void NeonicotinoidClickLink()
		{
			string link = "EPA website";
			new Steps_Prototype().ClickLinkElement(link);
		}
		[RegexStepDefinition(@"In the Neonicotinoid Warning Section, after clicking 'EPA website' link confirm new tab opens")]
		public void NeonicotinoidNewTab()
		{
			string url = "https://www.epa.gov/pollinator-protection/epa-actions-protect-pollinators";
			new Steps_Prototype().ConfirmNewTabOpenWithUrl(url);
		}
		[RegexStepDefinition(@"In the Neonicotinoid Warning Section, after clicking 'EPA website' link close new tab")]
		public void NeonicotinoidCloseNewTab()
		{
			string url = "https://www.epa.gov/pollinator-protection/epa-actions-protect-pollinators";
			new Steps_Prototype().CloseTabWithUrl(url);
		}

	}
}
