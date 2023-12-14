using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Product_Characteristics
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ProductCharacteristics_Section:VOC_OzoneTransportCommission")]
	class WERCSmart_Distributor_NewProducts_VOCOzoneTransportCommission
	{
		[StepDefinition(@"In the VOC - Ozone Transport Commission Section, set the option in section: 'Product has been granted an Alternative Control Plan, or is exempt as an Innovative Product or other variant under the applicable regulations.': to: (Yes|No)")]
		public void SetProductHasBennGranted(string option)
		{
			string section = "Product has been granted an ";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB': to: (.*)")]
		public void SelectCARB(string option)
		{
			string section = "Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the CARB";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the VOC - Ozone Transport Commission Section, set the option in section: 'Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule': to: (.*)")]
		public void SelectOTC(string option)
		{
			string section = "Amount of VOC content as weight percentage of the total formula, excluding exempt compounds as defined by the OTC Model Rule";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the VOC - Ozone Transport Commission Section, set the option in section: 'Would you like to use the VOC percentages entered for all areas \(e.g. country, state, local\) for comparison\?': to: (Yes|No, I would like to manually enter VOC value for each area.)")]
		public void SetWouldYouLikeToUseVOCPercentages(string option)
		{
			string section = "Would you like to use the VOC percentages entered for all areas (e.g. country, state, local) for comparison?";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[StepDefinition(@"In the VOC - Ozone Transport Commission Section, set the option in section: 'HVOC \(high volatile organic compound\) content as weight percent of the total formulation': to: (.*)")]
		public void SelectVOC(string option)
		{
			string section = "HVOC (high volatile organic compound) content as weight percent of the total formulation";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the VOC - Ozone Transport Commission Section, set the option in section: 'MVOC \(medium volatile organic compound\) content as weight percentage of the total formulation': to: (.*)")]
		public void SelectMVOC(string option)
		{
			string section = "MVOC (medium volatile organic compound) content as weight percentage of the total formulation";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the VOC - Ozone Transport Commission Section, set the option in section: 'VOC content in grams ozone per gram': to: (.*)")]
		public void SelectVOCPerGram(string option)
		{
			string section = "VOC content in grams ozone per gram";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the VOC - Ozone Transport Commission Section, set the option in section: 'Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1.': to: (Agree|Disagree)")]
		public void SetProductDoesNotContainMoreThan(string option)
		{
			string section = "Product does not contain more than 0.05 grams of VOC per use, as defined in the California Consumer Products Regulation, Title 17, CCR Division 3, Chapter 1.";
			new Steps_Prototype().SetRadioOptionInSectionTo(section, option);
		}
		[StepDefinition(@"In the VOC - Ozone Transport Commission Section, set the option in section: 'Product label specifies a dilution ratio which results in a final VOC concentration for the product during use': to: (Yes|No)")]
		public void SetProductLabelSpecifiesADilutionRatio(string option)
		{
			string section = "Product label specifies a dilution ratio which results in a final VOC concentration for the product during use";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}

		[StepDefinition(@"In the VOC - Ozone Transport Commission Section, set the option in section: 'Product's VOC content as sold': to: (.*)")]
		public void EnterVOCContentAsSold(string option)
		{
			string section = "Product's VOC content as sold";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the VOC - Ozone Transport Commission Section, set the option in section: 'Product's VOC content as used': to: (.*)")]
		public void EnterVOCContentAsUsed(string option)
		{
			string section = "Product's VOC content as used";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the VOC - Ozone Transport Commission section, I confirm text 'Please be sure you have selected the correct product type. For further questions, please contact Support.' (should|should not) be displayed")]
		public void VOCTextInAlertMessage(string condition)
		{
			string alertText = "Please be sure you have selected the correct product type. For further questions, please contact Support.";
			new Steps_Prototype().AlertMessageDisplayed(condition, alertText);
		}
		[StepDefinition(@"In the VOC - Ozone Transport Commission Section, set the option in section: 'Verify VOC content is below the threshold of 0.02lb/start of CARB': to: (Yes|No)")]
		public void SetVerifyVOCContentIsBelowCARB(string option)
		{
			string section = "Verify VOC content is below the threshold of 0.02lb/start of CARB";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the VOC - Ozone Transport Commission Section, set the option in section: 'Verify VOC content is below the threshold of 0.02lb/start of OTC': to: (Yes|No)")]
		public void SetVerifyVOCContentIsBelowOTC(string option)
		{
			string section = "Verify VOC content is below the threshold of 0.02lb/start of OTC";
			new Steps_Prototype().SetTheSectionOptionTo(section, option);
		}
		[StepDefinition(@"In the VOC - Ozone Transport Commission section, I confirm text 'Need help\? Regulatory services are included in Premium Subscription. Upgrade now!' (should|should not) be displayed")]
		public void NeedHelpTextInAlertMessage(string condition)
		{
			string alertText = "Need help? Regulatory services are included in Premium Subscription. Upgrade now!";
			new Steps_Prototype().AlertMessageDisplayed(condition, alertText);
		}

	}
}
