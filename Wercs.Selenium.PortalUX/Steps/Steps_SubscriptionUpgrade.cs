using System;
using System.Collections.Generic;
using System.Linq;
using NTTQA_Reporting_Module.Reporting.Core;
using SeleniumUtilities;
using TechTalk.SpecFlow;
using TestStack.White.UIItems.WindowItems;
using Wercs.Selenium.PortalUX.Classes;
using Wercs.Selenium.PortalUX.Selenium_Classes;

namespace Wercs.Selenium.PortalUX.Steps
{
	[Binding, Scope(Tag = "SubUpgrade")]
	class Steps_SubscriptionUpgrade
	{

		[StepDefinition(@"In the Subscription Upgrade screen I confirm heading as (.*)")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmHeadingAs(string expectedHeader)
		{
			SubscriptionEnrollment MySE = new SubscriptionEnrollment();
			var actualHeader = MySE.Get_Page_Header().Trim();
			Report.IsTrue(actualHeader == expectedHeader, "Expected: " + expectedHeader + " but got: " + actualHeader,
				"Page header is showing as expected: " + actualHeader);
		}

		[StepDefinition(@"In the Subscription Upgrade screen I confirm I cannot downgrade the existing plan")]
		public void ThenInTheSubscriptionUpgradeScreenIConfirmICannotDowngradeTheExistingPlan(Table table)
		{
			var mySub = new SubscriptionUpgrade();

			foreach (var thisRow in table.Rows)
			{
				string plan = thisRow["Plan"];
				string current = thisRow["Current"];
				string downgrade = thisRow["Downgrade"];

				Report.IsTrue(mySub.Downgrade_Range(plan, current, downgrade), "Able to Downgrade Existing Plan",
					"Unable to Downgrade Existing Plan");
			}
		}

		[StepDefinition(@"In the Subscription Upgrade screen I confirm the (Premium|Standard|Limited Plus|Limited) Feature Plan is selected")]
		public void ThenInTheSubscriptionUpgradeScreenIConfirmTheXFeaturePlanIsSelected(string featurePlan)
		{
			var mySub = new SubscriptionUpgrade();

			Report.IsTrue(mySub.Feature_Plan_Selected(featurePlan), "Failed to Check " + featurePlan + " is Selected",
				"Successfully Checked " + featurePlan + " is Selected");

		}

		[StepDefinition(@"In the Subscription Upgrade screen I confirm I cannot downgrade the current Feature Plan: (Premium|Standard|Limited Plus)")]
		public void ThenInTheSubscriptionUpgradeScreenIConfirmICannotDowngradeTheCurrentFeaturePlanX(string featurePlan)
		{
			var mySub = new SubscriptionUpgrade();

			Report.IsTrue(mySub.Downgrade_Feature_Plan_Check(featurePlan), "Failed to Check " + featurePlan + " Plan Cannot be Downgraded",
				"Successfully Checked " + featurePlan + " Plan Cannot be Downgraded");
		}

		[StepDefinition(@"In the Subscription Upgrade screen I confirm the (Gold|Silver|Bronze|General Support) Support Services Plan is selected")]
		public void ThenInTheSubscriptionUpgradeScreenIConfirmTheXSupportServicesPlanIsSelected(string supportPlan)
		{
			var mySub = new SubscriptionUpgrade();

			Report.IsTrue(mySub.Support_Plan_Selected(supportPlan), "Failed to Check " + supportPlan + " is Selected",
				"Successfully Checked " + supportPlan + " is Selected");
		}

		[StepDefinition(@"In the Subscription Upgrade screen I confirm I cannot downgrade the current Support Services Plan: (Gold|Silver)")]
		public void ThenInTheSubscriptionUpgradeScreenIConfirmICannotDowngradeTheCurrentSupportServicesPlanX(string supportPlan)
		{
			var mySub = new SubscriptionUpgrade();

			Report.IsTrue(mySub.Downgrade_Support_Plan_Check(supportPlan), "Failed to Check " + supportPlan + " Plan Cannot be Downgraded",
				"Successfully Checked " + supportPlan + " Plan Cannot be Downgraded");
		}

		[StepDefinition(@"In the Subscription Upgrade screen I confirm the Proceed button is (disabled when there is no change|enabled when a change is made) in the plan selection")]
		public void ThenInTheSubscriptionUpgradeScreenIConfirmTheProceedButtonIsDisabledWhenThereIsNoChangeInThePlanSelection(string enabled)
		{
			var mySub = new SubscriptionUpgrade();

			if (enabled == "disabled when there is no change")
			{
				Report.IsTrue(!mySub.Proceed_button_enabled(), "Proceed Button is Enabled",
					"Proceed Button is Disabled");
			}
			if (enabled == "enabled when a change is made")
			{
				Report.IsTrue(mySub.Proceed_button_enabled(), "Proceed Button is Disabled",
					"Proceed Button is Enabled");
			}
		}

		[StepDefinition(@"In the Subscription Upgrade screen for (Articles|Enhanced Articles|Formulated Products) I select (.*)")]
		public void ThenInTheSubscriptionUpgradeScreenForXISelectY(string rangeType, string rangeValue)
		{
			var mySub = new SubscriptionUpgrade();

			if (rangeType == "Articles")
			{
				Report.IsTrue(mySub.Select_Articles(rangeValue), "Failed to Select " + rangeValue + " for " + rangeType,
					"Selected " + rangeValue + " for " + rangeType);
			}
			if (rangeType == "Enhanced Articles")
			{
				Report.IsTrue(mySub.Select_Enhanced_Articles(rangeValue), "Failed to Select " + rangeValue + " for " + rangeType,
					"Selected " + rangeValue + " for " + rangeType);
			}
			if (rangeType == "Formulated Products")
			{
				Report.IsTrue(mySub.Select_Formulated_Products(rangeValue), "Failed to Select " + rangeValue + " for " + rangeType,
					"Selected " + rangeValue + " for " + rangeType);
			}

		}

		[StepDefinition(@"In the Subscription Upgrade screen I confirm the (Estimated Annual Cost|Estimated Annual Cost per Product) changes when (Articles|Enhanced Articles|Formulated Products) are changed to (.*)")]
		public void ThenInTheSubscriptionUpgradeScreenIConfirmTheEstimatedAnnualCostChangesWhenAPlanSelectionIsChanged(string costText, string rangeType, string rangeValue)
		{
			var mySub = new SubscriptionUpgrade();

			Report.IsTrue(mySub.Sub_Upgrade_Cost_Change(costText, rangeType, rangeValue), "Failed to Check " + costText + " Changes when " + rangeType + " are Changed to " + rangeValue,
				costText + " Successfully Changed when " + rangeType + " are Changed to " + rangeValue);
		}

		[StepDefinition(@"In the Subscription Upgrade screen I select the following enrollment options")]
		public void ThenInTheSubscriptionUpgradeScreenISelectTheFollowingEnrollmentOptions(Table table)
		{
			var mySub = new StepsSubscriptionEnrollment();

			mySub.ThenISelectTheFollowingEnrollmentOptions(table);
		}

		[StepDefinition(@"In the Subscription popup I confirm the (.*) header exists")]
		public void ThenInTheSubscriptionPopupIConfirmTheXHeaderExists(string headerText)
		{
			var mySub = new SubscriptionEnrollmentDlg();

			Report.IsTrue(mySub.Header_Correct(headerText), headerText + " Header Incorrect", headerText + " Header Correct");
		}



	}
}
