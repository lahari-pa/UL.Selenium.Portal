using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reqnroll;
using UL.Automation.ReqnrollHelpers.Attributes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product
{
	namespace UL.Selenium.Portal.WERCSmart.Steps
	{
		[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:InventoryStatusProp65")]
		class WERCSmart_Distributor_NewProducts_InventoryStatusProp65
		{
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, set the radio option in section: 'U.S. Toxic Substances Control Act \(TSCA\) status' to: (This product is subject to and complies with TSCA chemical Inventory listing requirements.|This product has not been evaluated with regard to TSCA chemical Inventory listing requirements.|This product is exempt from TSCA chemical Inventory listing requirements.|This product is subject to but does not comply with TSCA chemical Inventory listing requirements.)")]
			public void SelectTSCAStatus(string option)
			{
				string section = "U.S. Toxic Substances Control Act (TSCA) status";
				new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
			}

			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, set the radio option in section: 'Canadian Environmental Protection Act \(CEPA\) status' to: (Compliant with Domestic Substances List \(DSL\)|Compliant with Non-Domestic Substances List \(NDSL\)|Exempt \(DSL and/or NDSL\))")]
			public void SelectCEPAStatus(string option)
			{
				string section = "Canadian Environmental Protection Act (CEPA) status";
				new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
			}

			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, set the option in section: 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 \(commonly known as California Proposition 65\)\?' to: (Yes|No)")]
			public void SelectProp65(string option)
			{
				string section = "Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?";
				new Steps_Prototype().SetTheSectionOptionTo(section, option);
			}
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, set the radio option in section: 'Is the need to warn triggered by' to: (A chemical or chemicals in the product, or chemicals formed during the use of the product.|A chemical or chemicals in the packaging.|A chemical or chemicals in both the product and packaging.)")]
			public void SelectIsNeedToWarnTriggeredBy(string option)
			{
				string section = "Is the need to warn triggered by";
				new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
			}
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, set the radio option in section: 'How is the exposure warning transmitted\?' to: (By affixing it to the product or its packaging|By providing warning materials \(labels, shelf signage, online warning language\) to a retailer’s authorized agent|Other \(Please specify\))")]
			public void SelectHowIsTheExposureWarningTransmitted(string option)
			{
				string section = "How is the exposure warning transmitted? For more information, see ";
				new Steps_Prototype().SetTheSectionOptionTo(section, option);
			}
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, enter value in 'Other' field for section: 'How is the exposure warning transmitted\?': (.*)")]
			public void EnterOtherValueHowIsTheExposureWarningTransmitted(string option)
			{
				string section = "Other";
				new Steps_Prototype().SetTheSectionOptionTo(section, option);
			}

			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, set the radio option in section: 'Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured' to: (Prior to August 30, 2018|On or After August 30, 2018|Both, because instances of this product manufactured before, on and after August 30, 2018 are on the market.)")]
			public void SelectIsYourExposureWarningCompliantWothProp65(string option)
			{
				string section = "Is your exposure warning compliant with Proposition 65 regulations applicable to products manufactured";
				new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
			}

			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, set the radio option in section: 'If the product carries a safe-harbor short-form warning- indicate which of the following is provided:': to: (WARNING: Cancer -|WARNING: Reproductive Harm -|WARNING: Cancer and Reproductive Harm -|Does not apply)")]
			public void SelectIfTheProductCarriesASafeHarborShortFormWarningIndicateWhichIsProvided(string option)
			{
				string section = "If the product carries a safe-harbor short-form warning, indicate which of the following is provided:";
				new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
			}
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, set the radio option in section: 'If the product carries a safe-harbor long-form warning- indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning:': to: (This product can expose you to chemicals including \[name of one or more chemicals\], which is \[are\] known to the State of California to cause cancer. For more information go to|This product can expose you to chemicals including \[name of one or more chemicals\], which is \[are\] known to the State of California to cause birth defects or other reproductive harm. For more information go to|This product can expose you to chemicals including \[name of one or more chemicals\], which is \[are\] known to the State of California to cause cancer, and \[name of one or more chemicals\], which is \[are\] known to the State of California to cause birth defects or other reproductive harm. For more information go to|This product can expose you to chemicals including \[name of one or more chemicals\], which is \[are\] known to the State of California to cause cancer and birth defects or other reproductive harm. For more information go to|Does not apply)")]
			public void SelectIfTheProductCarriesASafeHarborShortFormWarningIndicateWhichIsUsed(string option)
			{
				string section = "If the product carries a safe-harbor long-form warning, indicate which of the following is used and enter the names of the Proposition 65 chemicals included in the warning:";
				new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
			}

			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, enter value in 'Enter the names of one or more listed carcinogens which are the subject of this warning' section: (.*)")]
			public void EnterNamesOfOneOrMoreListedCarcinogensWhichAreTheSubjectOfThisWarning(string option)
			{
				string section = "Enter the names of one or more listed carcinogens which are the subject of this warning";
				new Steps_Prototype().SetTheSectionOptionTo(section, option);
			}
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, enter value in 'Enter the names of one or more listed reproductive or developmental toxicants which are the subject of this warning:' section: (.*)")]
			public void EnterNamesOfOneOrMoreListedReproductiveOrDevelopmentalToxicantssWhichAreTheSubjectOfThisWarning(string option)
			{
				string section = "Enter the names of one or more listed reproductive or developmental toxicants which are the subject of this warning:";
				new Steps_Prototype().SetTheSectionOptionTo(section, option);
			}
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, enter value in 'Enter the names of one or more listed chemicals that are both carcinogens and reproductive or developmental toxicants which are the subject of this warning:' section: (.*)")]
			public void EnterNamesOfOneOrMoreListedChemicalsThatAreBothCarcinogensAndReproductiveOrDevelopmentalToxicantssWhichAreTheSubjectOfThisWarning(string option)
			{
				string section = "Enter the names of one or more listed chemicals that are both carcinogens and reproductive or developmental toxicants which are the subject of this warning:";
				new Steps_Prototype().SetTheSectionOptionTo(section, option);
			}
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, enter value in 'If the product carries a custom warning, please provide the exact text that is being used:' section: (.*)")]
			public void EnterValueIfTheProductCarriesACastomWarning(string option)
			{
				string section = "If the product carries a custom warning, please provide the exact text that is being used:";
				new Steps_Prototype().SetTheSectionOptionTo(section, option);
			}
			// table input --> |Section|
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, the following sections (should only|should|should not) be displayed:")]
			public void CheckSectionsDisplayedInventoryStatusPage(string condition , Table sections)
			{
				
				new Steps_Prototype().CheckDisplayedSections(condition, sections);
			}
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, the section 'U.S. Toxic Substances Control Act \(TSCA\) status' (should|should not) display an error message: (.*)")]
			public void ConfirmErrorMessageForTSCA(string condition, string errorMessage)
			{
				string section = "U.S. Toxic Substances Control Act (TSCA) status";
				new Steps_Prototype().ErrorMessagesAreShowingForItem(section, condition, errorMessage);
			}
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, the section 'Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 \(commonly known as California Proposition 65\)\?' (should|should not) display an error message: (.*)")]
			public void ConfirmErrorMessageForCaliProp65(string condition, string errorMessage)
			{
				string section = "Does the product carry an exposure warning required by the California Safe Drinking Water and Toxic Enforcement Act of 1986 (commonly known as California Proposition 65)?";
				new Steps_Prototype().ErrorMessagesAreShowingForItem(section, condition, errorMessage);
			}
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, for section 'How is the exposure warning transmitted\? For more information, see' click the link titled: 'Notice of Adoption Article'")]
			public void ClickLinkNoticeOfAdoptionArticle()
			{
				string linkText = "Notice of Adoption Article";
				new Steps_Prototype().ClickLinkElement(linkText);
			}
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, close the tab with the url link: (.*)")]
			public void CloseLinkNoticeOfAdoptionArticle(string linkUrl)
			{
				new Steps_Prototype().CloseTabWithUrl(linkUrl);
			}
			[RegexStepDefinition(@"In the Inventory Status, Prop 65 \(US\) Section, switch to the tab with url link: (.*)")]
			public void SwitchToTabNoticeOfAdoptionArticle(string linkUrl)
			{
				new Steps_Prototype().ConfirmNewTabOpenWithUrl(linkUrl);
			}
		}
	}
}
