using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps
{
	[Binding, Scope(Tag = "MyAccount:SubscriptionUpgrade")]
	class StepsSubscriptionUpgrade
	{
		[RegexStepDefinition(@"In the Subscription Upgrade section, for (Articles|Enhanced Articles|Formulated Products), select (.*)")]
		public void InTheSubscriptionPageSelectOptionForSection(string subscriptionSection, string subscriptionValue)
		{
			if (Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionSection).SelectElementExists(), $"Failed to find the select element for section '{subscriptionSection}'", $"Successfully found the select element for section '{subscriptionSection}'"))
			{
				Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionSection).SelectOption(subscriptionValue), $"Failed to select the option '{subscriptionValue}' for section '{subscriptionSection}'.", $"Successfully selected the option '{subscriptionValue}' for section '{subscriptionSection}'.");
			}
		}
		[RegexStepDefinition(@"In the Subscription Upgrade section, for (Articles|Enhanced Articles|Formulated Products), confirm selected option (is|is not) (.*)")]
		public void InTheSubscriptionPageConfirmSelectedOptionForSection(string subscriptionSection, string is_isnot, string subscriptionValue)
		{
			bool expected = is_isnot == "is";
			if (Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionSection).SelectElementExists(), $"Failed to find the select element for section '{subscriptionSection}'", $"Successfully found the select element for section '{subscriptionSection}'"))
			{
				Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionSection).SelectedOption() == subscriptionValue == expected, $"Failed to confirm the selected option {(expected ? "is not" : "is")} '{subscriptionValue}' for section '{subscriptionSection}'.", $"Successfully confirmed the selected option {is_isnot} '{subscriptionValue}' for section '{subscriptionSection}'.");
			}
		}
		[RegexStepDefinition(@"In the Subscription Upgrade section, select a subscription plan (Limited|Standard|Premium)")]
		public void InTheSubscriptionPageSelectSubscriptionPlan(string subscriptionPlan)
		{
			if (Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionPlan).RadioLabelExists(), $"Failed to find the radio element label for section '{subscriptionPlan}'", $"Successfully found the radio element label for section '{subscriptionPlan}'"))
			{
				if (Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionPlan).SelectRadioOption(), $"Failed to click the '{subscriptionPlan}' option", $"Successfully clicked the '{subscriptionPlan}' option"))
				{
					if (Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionPlan).RadioInputExists(), $"Failed to find the radio element input for section '{subscriptionPlan}'", $"Successfully found the radio element input for section '{subscriptionPlan}'"))
					{
						Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionPlan).InputRadioIsChecked(), $"Failed to select the '{subscriptionPlan}' option as a subscription plan", $"Successfully selected the '{subscriptionPlan}' option as a subscription plan");

					}
				}
			}
		}
		[RegexStepDefinition(@"In the Subscription Upgrade section, verify the selected subscription plan (is|is not) (Limited|Standard|Premium)")]
		public void InTheSubscriptionPageSelectedSubscriptionPlan(string is_isnot, string subscriptionPlan)
		{
			bool expected = is_isnot == "is";
			if (Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionPlan).RadioInputExists(), $"Failed to find the radio element input for section '{subscriptionPlan}'", $"Successfully found the radio element input for section '{subscriptionPlan}'"))
			{
				Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionPlan).InputRadioIsChecked() == expected, $"Failed to confirm the selected subscription plan {(expected ? "is not" : "is")} '{subscriptionPlan}'.", $"Successfully confirmed the selected subscription plan {is_isnot} '{subscriptionPlan}'.");

			}
		}
		[RegexStepDefinition(@"In the Subscription Upgrade section, select an Agent Support Service Plan (Bronze Level Support|Silver Agent Support|Gold Agent Support)")]
		public void InTheSubscriptionPageSelectAgentSupportServicePlan(string subscriptionPlan)
		{
			if (Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionPlan).RadioLabelExists(), $"Failed to find the radio element label for section '{subscriptionPlan}'", $"Successfully found the radio element label for section '{subscriptionPlan}'"))
			{
				if (Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionPlan).SelectRadioOption(), $"Failed to click the '{subscriptionPlan}' option", $"Successfully clicked the '{subscriptionPlan}' option"))
				{
					if (Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionPlan).RadioInputExists(), $"Failed to find the radio element input for section '{subscriptionPlan}'", $"Successfully found the radio element input for section '{subscriptionPlan}'"))
					{
						Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionPlan).InputRadioIsChecked(), $"Failed to select the '{subscriptionPlan}' option as a subscription plan", $"Successfully selected the '{subscriptionPlan}' option as a subscription plan");

					}
				}
			}
		}
		[RegexStepDefinition(@"In the Subscription Upgrade section, verify the selected Agent Support Service Plan (is|is not) (Bronze Level Support|Silver Agent Support|Gold Agent Support)")]
		public void InTheSubscriptionPageSelectedAgentSupportServicePlan(string is_isnot, string subscriptionPlan)
		{
			bool expected = is_isnot == "is";
			if (Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionPlan).RadioInputExists(), $"Failed to find the radio element input for section '{subscriptionPlan}'", $"Successfully found the radio element input for section '{subscriptionPlan}'"))
			{
				Report.IsTrue(new SubscriptionEnrolmentUpgradeSection(subscriptionPlan).InputRadioIsChecked() == expected, $"Failed to confirm the selected Agent Support Service Plan {(expected ? "is not" : "is")} '{subscriptionPlan}'.", $"Successfully confirmed the selected sAgent Support Service Plan {is_isnot} '{subscriptionPlan}'.");

			}
		}
		[RegexStepDefinition(@"In the Subscription Upgrade section, click the 'PROCEED' button")]
		public void InTheSubscriptionPageClickTheButton()
		{
			string button = "PROCEED";
			new StepsSubscriptionEnrollmentNew().InEnrollmentFooterClickButton(button);
		}
		[RegexStepDefinition(@"In the Subscription Upgrade section, the 'Your Total' footer exists and displays the text: Based on the above selected items, your estimated Subscription Plan total, excluding sales tax, is:")]
		public void InTheSubscriptionPageConfirmFooterExistsAndDisplaysText()
		{
			string footerLabel = "Your Total";
			string footerTextAreaText = "Based on the above selected items, your estimated Subscription Plan total, excluding sales tax, is:";
			new StepsSubscriptionEnrollmentNew().ConfirmFooterExistsAndDisplaysText(footerLabel, footerTextAreaText);
		}
		[RegexStepDefinition(@"In the Subscription Upgrade section, confirm the (Estimated Annual Cost|Estimated Annual Cost per Product) displays value: (.*)")]
		public void InTheSubscriptionPageInEnrollmentFooterConfirmCalculatorDisplays(string footerCalculatorLabel, string footerCalculatorValue)
		{
			new StepsSubscriptionEnrollmentNew().InEnrollmentFooterConfirmCalculatorDisplays(footerCalculatorLabel, footerCalculatorValue);
		}
		[RegexStepDefinition(@"In the Subscription Upgrade section, confirm the 'Subscription Upgrade' modal window (should|should not) be displayed")]
		public void InTheSubscriptionPageInTheModalIsDisplayed(string condition)
		{
			string modalTitle = "Subscription Upgrade";
			new Steps_Prototype().ThenIConfirmThePopUpShowsTheHeading(condition, modalTitle);
		}
		[RegexStepDefinition(@"In the Subscription Upgrade section, in the 'Subscription Upgrade' modal click the '(Cancel|Checkout)' button")]
		public void InTheSubscriptionPageInTheModalClickButton(string button)
		{
			Steps_ModalDialogPrototype modalDialogPrototype = new Steps_ModalDialogPrototype();
			modalDialogPrototype.DisplayedModalClickFooterButton(button);
		}
		[RegexStepDefinition(@"In the Subscription Upgrade section, in the 'Subscription Upgrade' modal click the header close button")]
		public void InTheSubscriptionPageInTheModalClickCloseButton()
		{
			Steps_ModalDialogPrototype modalDialogPrototype = new Steps_ModalDialogPrototype();
			modalDialogPrototype.DisplayedModalClickHeaderCloseButton();
		}
	}
}
