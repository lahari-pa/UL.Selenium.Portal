using System;
using System.Collections.Generic;
using System.Linq;
using ResourcePool;
using SafewareReporting;
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



	}
}
