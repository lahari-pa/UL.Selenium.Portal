using Reqnroll;
using System;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;



namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "RetailPartners")]
	class Steps_RetailPartners
	{
		[RegexStepDefinition(@"In the Retail Partners page, click the (.*) retailer link")]
		public void ClickTheRetailerLink(string retailer)
		{
			GeneralUtilities.Wait_for_load_finish();
			var selRetailPartners = new RetailPartners();

			if (!selRetailPartners.WaitForContainerToBeVisible(30))
			{
				throw new Exception("Page failed to load!");
			}

			Report.IsTrue(selRetailPartners.ClickRetailer(retailer),
				$"Failed to click retailer {retailer} !",
				$"Retailer {retailer} was selected successfully!");
			GeneralUtilities.Wait_for_load_finish();
			Report.Screenshot();
		}


		[RegexStepDefinition(@"In the Retail Partners Details page, confirm selecting retailer redirects to (.*) retailer page")]
		public void ConfirmRetailerPageIsDisplayed(string page)
		{
			Report.IsTrue(new RetailPartnersDetails().HeaderShowing(page),
				$"Retailer'{page}' was not showing!",
				$"Retailer '{page}' was showing, as expected!");
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


		[RegexStepDefinition(@"In the Retail Partners page, confirm Retailer (.*) is displayed under Most Recent Retailers")]
		public void RetailerDisplayedUnderMostRecentRetailers(string retailer)
		{
			string heading = "most-recent";
			var selRetailPartners = new RetailPartners();

			Report.IsTrue(new RetailPartners().RetailerDisplayedBelowHeading(heading, retailer), $"Retailer '{retailer}' is displayed under Most Recent Retailers ", $"Retailer '{retailer}' is displayed under Most Recent Retailers");
		}

		[RegexStepDefinition(@"In the Retail Partners page, confirm Retailer (.*) is displayed under All Retailers")]
		public void RetailerDisplayedUnderAllRetailers(string retailer)
		{
			string heading = "all-retailers";
			var selRetailPartners = new RetailPartners();

			Report.IsTrue(new RetailPartners().RetailerDisplayedBelowHeading(heading, retailer), $"Retailer '{retailer}' is displayed under All Retailers ", $"Retailer  '{retailer}' is displayed under All Retailers ");
		}


		[RegexStepDefinition(@"In the Retail Partners page, I confirm that there is a section labeled: (.*)")]
		public void ConfirmSectionShowing(string header)
		{
			Report.IsTrue(new RetailPartnersDetails().HeaderShowing(header),
				$"Header {header} was not showing on page!",
				$"Header {header} was showing, as expected!");
		}

		[RegexStepDefinition(@"In the Retail Partners page, Retail partner details should be showing text: (.*)")]
		public void RetailPatnersDetailShouldBeShowing(string text)
		{
			string showing = new RetailPartnersDetails().GetDCDescription().Trim();
			text = text.Trim();
			Report.IsTrue(showing == text, $"Text was not showing: {text}, Instead found: {showing}", $"Text was showing: {text}  as expected!");
		}



	}
}
