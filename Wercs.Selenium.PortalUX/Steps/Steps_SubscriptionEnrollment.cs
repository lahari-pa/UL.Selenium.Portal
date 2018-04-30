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
	[Binding, Scope(Tag = "SubEnrollment")]
	class StepsSubscriptionEnrollment
	{


		[StepDefinition(@"In the Subscription Enrollment screen I select the following enrollment options")]
		public void ThenISelectTheFollowingEnrollmentOptions(Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I select enrollment options");
			try
			{
				var mySub = new SubscriptionEnrollment();

				foreach (var thisRow in table.Rows)
				{
					string articles = thisRow["Articles"];
					string enArticles = thisRow["Enhanced Articles"];
					string formProds = thisRow["Formulated Products"];
					string featurePlan = thisRow["Feature Plan"];
					string servicesPlan = thisRow["Support Services Plan"];

					Report.IsTrue(mySub.Select_Enrollment_Options(articles, enArticles, formProds, featurePlan, servicesPlan),
						"Failed to Select Enrollment Options", "Enrollment Options Selected");
				}

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Subscription Enrollment screen I confirm heading as (.*)")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmHeadingAs(string expectedHeader)
		{
			SubscriptionEnrollment MySE = new SubscriptionEnrollment();
			var actualHeader = MySE.Get_Page_Header().Trim();
			Report.IsTrue(actualHeader == expectedHeader, "Expected: " + expectedHeader + " but got: " + actualHeader,
				"Page header is showing as expected: "+actualHeader);
		}

		[Then(@"In the Subscription Enrollment screen I confirm that I see the following subheadings:")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmThatISeeTheFollowingSubheadings(Table table)
		{
			SubscriptionEnrollment MySE = new SubscriptionEnrollment();
			List<string> subHeadings = MySE.Get_Page_SubHeaders();
			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				Report.IsTrue(subHeadings.Contains(thisRow["Subheading"]),
					"Subheading: " + thisRow["Subheading"] + " has not been found.",
					"Subheading: " + thisRow["Subheading"] + " is found as expected");
			}
		}

		[Then(@"In the Subscription Enrollment screen I confirm that I see the following Plans")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmThatISeeTheFollowingPlans(Table table)
		{
			SubscriptionEnrollment MySE = new SubscriptionEnrollment();
			List<Plan> allPlans = MySE.Get_All_Plans();

			foreach (Plan thisPlan in allPlans)
			{
				Report.Info(thisPlan.Plan_Type + " " + thisPlan.Plan_Name + " " + thisPlan.Plan_Sub + " "+ thisPlan.Best_Value.ToString() + " " + thisPlan.Selected);
			}

			//| Plan Type | Plan Name | Plan Subtext | Best Value | Selected |
			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				Report.Info("Checking on plan: " + thisRow["Plan Name"]);
				Plan MatchingPlan =
					allPlans.FirstOrDefault(x => x.Plan_Type == thisRow["Plan Type"] && x.Plan_Name == thisRow["Plan Name"]&& x.Plan_Sub== thisRow["Plan Subtext"] && x.Best_Value == (thisRow["Best Value"].ToLower()=="true") && x.Selected == (thisRow["Selected"].ToLower() == "true"));
				Report.IsTrue(MatchingPlan != null, "No matching item has been found for plan name: " + thisRow["Plan Name"],
					"Plan: " + thisRow["Plan Name"] + " has matched as expected.");
			}
		}

		[Then(@"In the Subscription Enrollment screen I confirm that under the (.*) Plan I see the following items and further details")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmThatUnderThePlanISeeTheFollowingItemsAndFurtherDetails(string plan, Table table)
		{
			SubscriptionEnrollment MySE = new SubscriptionEnrollment();

			//| Item | Further details |
			List<Plan> allPlans = MySE.Get_All_Plans();
			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				Plan thisPlan = allPlans.FirstOrDefault(x => x.Plan_Name == plan);

				Info_Point thisInfoPoint = thisPlan.Info_points.FirstOrDefault(x => x.Info_Header == thisRow["Item"]);
				Report.IsTrue(thisInfoPoint != null, "Item has not been found: " + thisRow["Item"].ToString(),"Item has been found: " + thisRow["Item"].ToString());

				if (thisRow["Further details"].Length > 0)
				{
					string actualHiddenText = MySE.Click_Info_By_Plan_Item_Return_Hidden(plan, thisRow["Item"].ToString());
					thisInfoPoint.Info_Detail = actualHiddenText;
					Report.IsTrue(thisInfoPoint.Info_Detail.Contains(thisRow["Further details"]), "Expected value: >>" + thisRow["Further details"] + "<< not showing as expected. The value showing is: >>" + thisInfoPoint.Info_Detail + "<<",
						thisRow["Further details"] + "is showing as expected.");
				}
			}
		}



		[Then(@"In the Subscription Enrollment screen I confirm that the option showing in the (.*) dropdown is: (.*)")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmThatTheOptionShowingInTheDropdownIs(string dropdown, string expectedOption)
		{
			SubscriptionEnrollment MySE = new SubscriptionEnrollment();
			string selectedOption = "";
			switch (dropdown)
			{
				case "Articles":
					selectedOption = MySE.Get_Selected_Articles();
					break;
				case "Enhanced Articles":
					selectedOption = MySE.Get_Selected_Enhanced_Articles();
					break;
				case "Formulated Products":
					selectedOption = MySE.Get_Selected_Formulated_Products();
					break;
				default:
					throw new Exception("Dropdown item did not match any of the options");
			}

			Report.IsTrue(expectedOption == selectedOption, "Selected option should be: " + expectedOption + " but is: " + selectedOption,"Option is showing as expected");
		}


		[Then(@"In the Subscription Enrollment screen I confirm that you see (.*) dropdown")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmThatYouSeeDropdown(string dropdown)
		{
			SubscriptionEnrollment MySE = new SubscriptionEnrollment();

			switch (dropdown)
			{
				case "Articles":
					Report.IsTrue(MySE.Select_Articles_exists(), "The Articles dropdown is not showing as expected",
						"The Articles dropdown is showing as expected.");
					break;
				case "Enhanced Articles":
					Report.IsTrue(MySE.Select_Enhanced_Articles_Exists(), "The Enhanced Articles dropdown is not showing as expected",
						"The Enhanced Articles dropdown is showing as expected.");
					break;
				case "Formulated Products":
					Report.IsTrue(MySE.Select_Formulated_Products_Exists(), "The Formulated Products dropdown is not showing as expected",
						"The Formulated Products dropdown is showing as expected.");
					break;
				default:
					throw new Exception("Dropdown item did not match any of the options");
			}
			
		}

		[Then(@"In the Subscription Enrollment screen I confirm that when you hover over \(i\) for (.*) you see following (heading|statement): (.*)")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmThatWhenYouHoverOverIForYouSeeFollowing(string hoverOverItem, string headerOrText, string expectedValue)
		{
			SubscriptionEnrollment MySE = new SubscriptionEnrollment();
			string actualValue = "";
			switch (hoverOverItem)
			{
				case "Articles":
					if (headerOrText.ToLower() == "heading")
					{
						actualValue = MySE.Get_Articles_info_header();
					}
					else
					{
						actualValue = MySE.Get_Articles_info_body();
					}
					break;
				case "Enhanced Articles":
					if (headerOrText.ToLower() == "heading")
					{
						actualValue = MySE.Get_Enhanced_Articles_info_header();
					}
					else
					{
						actualValue = MySE.Get_Enhanced_Articles_info_body();
					}
					break;
				case "Formulated Products":
					if (headerOrText.ToLower() == "heading")
					{
						actualValue = MySE.Get_Formulated_Products_info_header();
					}
					else
					{
						actualValue = MySE.Get_Formulated_Products_info_body();
					}
					break;
				default:
					throw new Exception("Hover over item did not match any of the options");
			}

			Report.IsTrue(actualValue == expectedValue,
				"Expected to see value: " + expectedValue + " but actually got: " + actualValue,
				"Hover over heading for Articles is showing as expected");

		}



		[StepDefinition(@"I cancel the Enrollment dialog, confirm correct page opens and Proceed")]
		public void ThenICancelTheEnrollmentDialogConfirmCorrectPageOpensAndProceed()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I cancel the Enrollment dialog, confirm correct page opens and Proceed");
			try
			{
				var mySub = new SubscriptionEnrollment();

				ThenIClickOnX("Cancel");

				Report.IsTrue(mySub.Proceed_click(), "Failed to Click Proceed Button", "Proceed Button Clicked");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm the chosen options and body text are correct")]
		public void ThenIConfirmTheChosenOptionsAndBodyTextAreCorrect(Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the chosen options and body text are correct");
			try
			{
				var mySubDlg = new SubscriptionEnrollmentDlg();

				foreach (var thisRow in table.Rows)
				{
					string articles = thisRow["Articles"];
					string enArticles = thisRow["Enhanced Articles"];
					string formProds = thisRow["Formulated Products"];
					string featurePlan = thisRow["Feature Plan"];
					string servicesPlan = thisRow["Support Services Plan"];
					string bodyText = thisRow["Body Text"];

					Report.IsTrue(mySubDlg.Check_Options(featurePlan, articles, enArticles, formProds, servicesPlan), "Failed to Check Enrollment Options", "Enrollment Options are Correct");
					Report.IsTrue(mySubDlg.Subscription_Text(bodyText), "Incorrect Subscription Text", "Correct Subscription Text");

				}

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click on (Checkout|Cancel)")]
		public void ThenIClickOnX(string button)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I click on " + button);
			try
			{
				var mySub = new SubscriptionEnrollment();
				var mySubDlg = new SubscriptionEnrollmentDlg();
				var myPay = new PaymentMethods();

				if (button == "Cancel")
				{
					Report.IsTrue(mySubDlg.Cancel_click(), "Failed to Click Cancel Button", "Cancel Button Clicked");
					Delay.Seconds(1 * Delay.SpeedFactor);
					if (!mySub.Exists)
					{
						throw new Exception("Subscription Enrollment Page Failed to Open");
					}
					Report.Info("On Subscription Enrollment Page");
				}
				if (button == "Checkout")
				{
					Report.IsTrue(mySubDlg.Checkout_click(), "Failed to Click Checkout Button", "Checkout Button Clicked");
					Delay.Seconds(10 * Delay.SpeedFactor);
					if (!myPay.Exists)
					{
						throw new Exception("Payment Methods Page Failed to Open");
					}
					Report.Info("On Payment Methods Page");
				}
				Report.Success(button + " Clicked");


			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


	}
}
