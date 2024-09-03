using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Reporting.Functions;
using UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:ProductInformation")]
	internal class ProductInformation
	{
		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Which best describes your product, including when FIFRA 25\(b\) Exempt' to: (Product is intended for preventing, destroying, repelling, or mitigating pests \(including insects, rodents, mold, virus, bacteria, and other micro-organisms\)|Product is intended for use as a plant regulator \(controls growth\), defoliant \(removes leaves\), or desiccant \(dehydrates plants to control growth\)|Product is not a pesticide and does not make or imply a pesticidal claim on the labeling or in the product description \(ex. kills, sterilizes, disinfects, sanitizes, antimicrobial\))")]
		public void SelectFefra25Exemp(string option)
		{
			string section = "Which best describes your product, including when FIFRA 25(b) Exempt";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, confirm the question: 'Which best describes your product, including when FIFRA 25\(b\) Exempt' (is|is not) displayed")]
		public void ConfirmFefra25ExemptIsIsNotDisplayed(string is_isnot)
		{
			string section = "Which best describes your product, including when FIFRA 25(b) Exempt";
			new Steps_ProductPrototype().ThenInThePageIShouldOrShouldNotSeeQuestion(section, is_isnot);
		}
		[RegexStepDefinition(@"In the Product Information Section, confirm following options (should|should not) be (displayed|exclusively displayed) for section: 'Which best describes your product, including when FIFRA 25\(b\) Exempt'")]
		public void ThenInThePesticideDetails_CanadaSectionConfirmFollowingOptionsShouldShouldNotBeDisplayedExclusivelyDisplayedForSectionAlberta(string should, string exclusive, Table table)
		{
			string section = "Which best describes your product, including when FIFRA 25(b) Exempt";
			new Steps_Prototype().CheckOptionsInSection(should, exclusive, section, table);
		}

		[RegexStepDefinition(@"In the Product Information Section, the section: 'Which best describes your product, including when FIFRA 25\(b\) Exempt' (should|should not) be showing error message: (.*)")]
		public void CheckUNSectionsWithErrorMessages(string condition, string message)
		{
			string section = "Which best describes your product, including when FIFRA 25(b) Exempt";
			new Steps_Prototype().ErrorMessagesAreShowingForItem(section, condition, message);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Product has been classified using OSHA \(US\) Globally Harmonized Standards \(GHS\) under 29 CFR 1910\.1200 and\/or CCOHS WHMIS Standards \(Canada\)' to: (Yes|No)")]
		public void SelectOSHAGloballyHarmonizedStandards(string option)
		{
			string section = "Product has been classified using OSHA (US) Globally Harmonized Standards (GHS) under 29 CFR 1910.1200 and/or CCOHS WHMIS Standards (Canada)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Product is shipped directly by supplier to the consumer. Retailer sells online and does not ship, or otherwise distribute, the product to the consumer. Retailer may accept product for returns.' to: (Yes|No)")]
		public void SelectProductIsShippedDirectly(string option)
		{
			string section = "Product is shipped directly by supplier to the consumer.  Retailer sells online and does not ship, or otherwise distribute, the product to the consumer.  Retailer may accept product for returns.";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Product is sold as a Retailer's Own Brand \(Private Label, Store Brand\) product' to: (Yes|No)")]
		public void SelectProductIsRetailerPrivateLabel(string option)
		{
			string section = "Product is sold as a Retailer's Own Brand (Private Label, Store Brand) product";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer \(Goods Not for Resale\)' to: (Yes|No)")]
		public void SelectProductIsSoldToTheRetailer(string option)
		{
			string section = "Product is sold to the Retailer solely for the Retailer's use and is not sold to the Consumer (Goods Not for Resale)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Product is marketed for use by, or on, a child \(US is 12 and under; Canada is 14 and under\)' to: (Yes|No)")]
		public void SelectProductIsMarketedForUseByChild(string option)
		{
			string section = "Product is marketed for use by, or on, a child (US is 12 and under; Canada is 14 and under)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.' to: (Yes|No)")]
		public void SelectProductsMustComplyWithCaliforniaCleaningProductRighttoKnowAct(string option)
		{
			string section = "Cleaning products must comply with California's Cleaning Product Right to Know Act. I would like to provide the additional information needed for this program during registration.";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Select countries the product may be sold in' to: (United States|Canada)")]
		public void SelectCountriesTheProductMayBeSold(string option)
		{
			string section = "Select countries the product may be sold in";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Does the product contain fertilizer \(N, P, K\)\?' to: (Yes|No)")]
		public void SelectDoesProductContainFertilizer(string option)
		{
			string section = "Does the product contain fertilizer (N, P, K)?";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Nitrogen /Nitrates \(“N”\)' to: (.*)")]
		public void SetNitrogen(string option)
		{
			string section = "Nitrogen /Nitrates (“N”)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Phosphates \/Phosphorous \(“P”\)' to: (.*)")]
		public void SetPhosphates(string option)
		{
			string section = "Phosphates /Phosphorous (“P”)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Potassium\(“K”\)' to: (.*)")]
		public void SetPotassium(string option)
		{
			string section = "Potassium(“K”)";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Slow-Release Agent' to: (.*)")]
		public void SetSlowReleaseAgent(string option)
		{
			string section = "Slow-Release Agent";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Select one option below' to: (Battery is packaged for Retail Sale|Battery is not packaged for Retail Sale)")]
		public void SelectOneOptionBelow(string option)
		{
			string section = "Select one option below";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Would you like to set the product as Item Preview' to: 'Yes - Add to Item Preview'")]
		public void SettheProductAsItemPreview()
		{
			string section = "Would you like to set the product as Item Preview";
			string option = "Yes - Add to Item Preview";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Select the product's Country of Origin' to: (.*)")]
		public void SelectTheCountryOfOrigin(string option)
		{
			string section = "Select the product's Country of Origin";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations' to: (.*)")]
		public void RetailersWillBeSellingMyProductAtTheirStoreLocations(string option)
		{
			string section = "Retailers will be selling my product at their store locations in (select either or both) ";
			new Steps_Prototype().CheckingFieldInputIsCorrect(section, "United States");
		}

		[RegexStepDefinition(@"In the Product Information Section, set the option in section: 'Retailers will be selling my product at their store locations in \(select either or both\)' (to|to not) select: (United States|Canada)")]
		public void RetailersSellingLocation(string to_notto, string option)
		{
			bool expected = to_notto == "to";
			string is_isnot = expected ? "is" : "is not";
			string section = "Retailers will be selling my product at their store locations in (select either or both) ";
			Steps_ProductPrototype productPrototype = new Steps_ProductPrototype();
			productPrototype.InSectionSetOptionIsIsNotSelected(section, option, is_isnot);
		}

		[RegexStepDefinition(@"In the Product Information Section, confirm the option in section: 'Retailers will be selling my product at their store locations in \(select either or both\)' is (checked|not checked) for: (United States|Canada)")]
		public void RetailersSellingLocationConfirm(string checked_notchecked, string option)
		{
			bool expected = checked_notchecked == "checked";
			string is_isnot = expected ? "is" : "is not";
			string section = "Retailers will be selling my product at their store locations in (select either or both) ";
			Steps_ProductPrototype productPrototype = new Steps_ProductPrototype();
			productPrototype.InSectionConfirmOptionIsIsNotSelected(section, option, is_isnot);
		}

		[RegexStepDefinition(@"In the Product Information Section, Check or Uncheck for the section (.*): Retailers will be selling my product at their store locations in \(select either or both\) to : (.*)")]
		public void CheckOrUncheckRetailersSellingLocation(string section, string option)
		{
			if (section == "check")
			{
				new Steps_Prototype().ICheckTheCheckboxWithDescription(section, option);
			}
			else if(section == "uncheck")
			{
				new Steps_Prototype().ICheckTheCheckboxWithDescription(section, option);
			}
		}
		[RegexStepDefinition(@"In the Product Information Section, a warning pop-up (should|should not) be displayed with text: 'The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of the product in Pinellas County, Florida \(Restricted\). This is informational only and does not restrict your registration to the Retailer.'")]
		public void WarningPopupIsDisplayedInProductInformation(string condition)
		{
			string title = "Warning";
			string text = "The ratio of Slow-Release Agent to Nitrogen will prohibit sale and use of the product in Pinellas County, Florida (Restricted). This is informational only and does not restrict your registration to the Retailer.";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeadingAndText(condition, title, text);
		}
		[RegexStepDefinition("In the Product Information Section Section, in Warning modal window click 'Ok' button")]
		public void ThenInTheProductInfoSectionInWarningModalWindowClickButton()
		{
			string title = "Warning";
			string button = "Ok";
			new Steps_Prototype().ThenInThePopupViewWithTheFollowingTitleIClickTheButton(title, button);
		}

		[RegexStepDefinition(@"In the Product Information Section, enter the value in section: 'Enter NDC #': (.*)")]
		public void EnterNDCNumber(string option)
		{
			Steps_ProductPrototype productPrototype = new Steps_ProductPrototype();
			string section = "Enter NDC #";
			productPrototype.InSectionClickSearchText(section);
			SearchBoxPrototype searchBoxPrototype = new SearchBoxPrototype();
			Report.IsTrue(searchBoxPrototype.SearchInputExists(), $"Failure, search input box does not exist.", $"Success, search input box exists.");
			Report.IsTrue(searchBoxPrototype.SearchInputEnterText(option), $"Failure, failed to enter '{option}' in search input box.", $"Success, entered '{option}' in search input box.");
			GeneralUtilities.Wait_for_load_finish();
			Report.IsTrue(searchBoxPrototype.SearchResultTextExists(option), $"Failure, '{option}' search result is not displayed.", $"Success, '{option}' search result is displayed.");
			Report.IsTrue(searchBoxPrototype.SearchResultTextGetContains(option).Click(), $"Failure, failed to click '{option}' search result.", $"Success, clicked '{option}' search result.");
			searchBoxPrototype.WaitForContainerToBeInvisible();
		}
	}
}
