using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.WebDriver.Classes;
using UL.Automation.WebDriver.Extensions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.Utilities.Functions;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Automation.ReqnrollHelpers.Classes;
using UL.Automation.Utilities.Helpers;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Reflection;
using UL.Automation.Utilities;
using UL.Automation.ReqnrollHelpers.Attributes;
using Mailosaur.Operations;


namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "RetailPartners")]
	class Steps_RetailPartners
	{
		[RegexStepDefinition(@"In the Retail Partners page, click the (.*) retailer link")]
		public void ClickTheRetailerLink(string retailerText)
		{
			new Steps_Prototype().ClickLinkElement(retailerText);
		}


		[RegexStepDefinition(@"In the Retail Partners Details page, confirm selecting retailer redirects to (.*) retailer page")]
		public void ConfirmRetailerPageIsDisplayed(string page)
		{
			Report.IsTrue(new RetailPartnersDetails().HeaderShowing(page),
				"Retailer'" + page + "' was not showing!",
				"Retailer '" + page + "' was showing, as expected!");
		}

		[RegexStepDefinition(@"In the Retail Partners Details page, click 'What are the Data Usage Tiers?' button")]
		public void ClickWhataretheDataUsageTiersButton()
		{
			string buttonText = "What are the Data Usage Tiers?";
			new Steps_Prototype().ClickLinkElement(buttonText);
		}

		[RegexStepDefinition(@"In the Retail Partners Details page, click 'Products in Scope' button")]
		public void ClickProductsinScopeButton()
		{
			string buttonText = "Products in Scope";
			new Steps_Prototype().ClickLinkElement(buttonText);
		}

		[RegexStepDefinition(@"In the Retail Partners Details page, set the 'Tier 1: Regulatory Support' option to (On|Off)")]
		public void ClickTheTier1RegulatorySupport(string on_off)
		{
			string name = "Tier 1: Regulatory Support";

			if (Report.IsTrue(new RetailPartnersDetails().DataConsentTierToggleExists(name), "Failed to find the 'Tier 1: Regulatory Support' toggle", "Successfully found the 'Tier 1: Regulatory Support' toggle"))
			{
				Report.IsTrue(new RetailPartnersDetails().DataConsentTierToggleOn_Off(name, on_off), $"Failed to set the 'Tier 1: Regulatory Support' toggle to {on_off}", $"Successfully set the 'Tier 1: Regulatory Support' toggle to {on_off}");
			}
		}

		[RegexStepDefinition(@"In the Retail Partners Details page, set the 'Tier 2.1: Restricted Substances List (RCL) Screening and Aggregate Chemical Usage Reports' option to (On|Off)")]
		public void ClickTheTier2RestrictedSubstancesListRCLScreeningandAggregateChemicalUsageReport(string on_off)
		{
			string name = "Tier 2.1: Restricted Substances List (RCL) Screening and Aggregate Chemical Usage Reports";

			if (Report.IsTrue(new RetailPartnersDetails().DataConsentTierToggleExists(name), "Failed to find the 'Tier 2.1: Restricted Substances List (RCL) Screening and Aggregate Chemical Usage Reports' toggle", "Successfully found the 'Tier 2.1: Restricted Substances List (RCL) Screening and Aggregate Chemical Usage Reports' toggle"))
			{
				Report.IsTrue(new RetailPartnersDetails().DataConsentTierToggleOn_Off(name, on_off), $"Failed to set the 'Tier 2.1: Restricted Substances List (RCL) Screening and Aggregate Chemical Usage Reports' toggle to {on_off}", $"Successfully set the 'Tier 2.1: Restricted Substances List (RCL) Screening and Aggregate Chemical Usage Reports' toggle to {on_off}");
			}
		}


		[RegexStepDefinition(@"In the Retail Partners Details page, set the 'Tier 2.2: Chemical Identity of Publicly Disclosed Ingredient Lists and Transparency' option to (On|Off)")]
		public void ClickTheTier2ChemicalIdentityofPubliclyDisclosedIngredientListsandTransparency(string on_off)
		{
			string name = "Tier 2.2: Chemical Identity of Publicly Disclosed Ingredient Lists and Transparency";

			if (Report.IsTrue(new RetailPartnersDetails().DataConsentTierToggleExists(name), "Failed to find the 'Tier 2.2: Chemical Identity of Publicly Disclosed Ingredient Lists and Transparency' toggle", "Successfully found the 'Tier 2.2: Chemical Identity of Publicly Disclosed Ingredient Lists and Transparency' toggle"))
			{
				Report.IsTrue(new RetailPartnersDetails().DataConsentTierToggleOn_Off(name, on_off), $"Failed to set the 'Tier 2.2: Chemical Identity of Publicly Disclosed Ingredient Lists and Transparency' toggle to {on_off}", $"Successfully set the 'Tier 2.2: Chemical Identity of Publicly Disclosed Ingredient Lists and Transparency' toggle to {on_off}");
			}
		}

		[RegexStepDefinition(@"In the Retail Partners Details page, set the 'Tier 3: Supplemental Reports' option to (On|Off)")]
		public void ClickTheTier3SupplementalReports(string on_off)
		{
			string name = "Tier 3: Supplemental Reports";

			if (Report.IsTrue(new RetailPartnersDetails().DataConsentTierToggleExists(name), "Failed to find the 'Tier 3: Supplemental Reports' toggle", "Successfully found the 'Tier 3: Supplemental Reports' toggle"))
			{
				Report.IsTrue(new RetailPartnersDetails().DataConsentTierToggleOn_Off(name, on_off), $"Failed to set the 'Tier 3: Supplemental Reports' toggle to {on_off}", $"Successfully set the 'Tier 3: Supplemental Reports' toggle to {on_off}");
			}
		}

		[RegexStepDefinition(@"In the Retail Partners Details page, set the 'Tier 4: Public Disclosure Options' option to (On|Off)")]
		public void ClickTheTier4PublicDisclosureOptions(string on_off)
		{
			string name = "Tier 4: Public Disclosure Options";

			if (Report.IsTrue(new RetailPartnersDetails().DataConsentTierToggleExists(name), "Failed to find the 'Tier 4: Public Disclosure Options' toggle", "Successfully found the 'Tier 4: Public Disclosure Options' toggle"))
			{
				Report.IsTrue(new RetailPartnersDetails().DataConsentTierToggleOn_Off(name, on_off), $"Failed to set the 'Tier 4: Public Disclosure Options' toggle to {on_off}", $"Successfully set the 'Tier 4: Public Disclosure Options' toggle to {on_off}");
			}
		}

		[RegexStepDefinition(@"In the Retail Partners Details page, click 'Save' button")]
		public void ClickSaveButton()
		{
			string buttonText = "Save";
			new Steps_Prototype().ClickLinkElement(buttonText);
		}




	}
}
