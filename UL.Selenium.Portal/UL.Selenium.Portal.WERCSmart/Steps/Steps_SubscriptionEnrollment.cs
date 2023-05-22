using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Utilities.Functions;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using UL.Automation.Reporting;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;

namespace UL.Selenium.Portal.WERCSmart.Steps
{
	[Binding, Scope(Tag = "SubEnrollment")]
	class StepsSubscriptionEnrollment
	{


		[StepDefinition(@"In the Subscription Enrollment screen I select the following enrollment options")]
		public void ThenISelectTheFollowingEnrollmentOptions(Table table)
		{
			Report.StartStep(Report.Details.StepIndex + " - I select enrollment options");
			try
			{
				var mySub = new SubscriptionEnrollment();

				foreach (TableRow thisRow in table.Rows)
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

		[StepDefinition(@"the Subscription Enrollment page should load")]
		public void ThenTheSubscriptionEnrollmentPageShouldLoad()
		{
			var MySE = new SubscriptionEnrollment();
			Report.IsTrue(MySE.Wait_for_load(60), "Subscription enrollment page is not showing",
				"Subscription enrollment page is showing.");
		}


		[StepDefinition(@"In the Subscription Enrollment screen I confirm heading as (.*)")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmHeadingAs(string expectedHeader)
		{
			var MySE = new SubscriptionEnrollment();
			string actualHeader = MySE.Get_Page_Header().Trim();
			Report.IsTrue(actualHeader == expectedHeader, "Expected: " + expectedHeader + " but got: " + actualHeader,
				"Page header is showing as expected: " + actualHeader);
		}

		[StepDefinition(@"In the Subscription Enrollment screen I confirm that I see the following subheadings:")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmThatISeeTheFollowingSubheadings(Table table)
		{
			var MySE = new SubscriptionEnrollment();
			List<string> subHeadings = MySE.Get_Page_SubHeaders();
			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				Report.IsTrue(subHeadings.Contains(thisRow["Subheading"]),
					"Subheading: " + thisRow["Subheading"] + " has not been found.",
					"Subheading: " + thisRow["Subheading"] + " is found as expected");
			}
		}

		[StepDefinition(@"In the Subscription Enrollment screen I confirm that I see the following Plans")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmThatISeeTheFollowingPlans(Table table)
		{
			var MySE = new SubscriptionEnrollment();
			var allPlans = new List<Plan>();
			if (Context.ScenarioContext.ContainsKey("Plans"))
			{
				allPlans = (List<Plan>)Context.GetFromContext("Plans");
			}
			else
			{
				allPlans = MySE.Get_All_Plans();
				Context.AddToContext("Plans", allPlans);
			}

			foreach (Plan thisPlan in allPlans)
			{
				Report.Info(thisPlan.Plan_Type + " " + thisPlan.Plan_Name + " " + thisPlan.Plan_Sub + " " + thisPlan.Best_Value.ToString() + " " + thisPlan.Selected);
			}

			//| Plan Type | Plan Name | Plan Subtext | Best Value | Selected |
			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				Report.Info("Checking on plan: " + thisRow["Plan Name"]);
				/*
				Plan MatchingPlan =
					allPlans.FirstOrDefault(x => x.Plan_Type == thisRow["Plan Type"] && x.Plan_Name == thisRow["Plan Name"] && x.Plan_Sub == thisRow["Plan Subtext"] && x.Best_Value == (thisRow["Best Value"].ToLower() == "true") && x.Selected == (thisRow["Selected"].ToLower() == "true"));
				*/
				Plan MatchingPlan =
					allPlans.FirstOrDefault(x => x.Plan_Type.Trim() == thisRow["Plan Type"].Trim() && x.Plan_Name.Trim() == thisRow["Plan Name"].Trim()  && x.Best_Value == (thisRow["Best Value"].ToLower().Trim() == "true") && x.Selected == (thisRow["Selected"].ToLower().Trim() == "true"));
				Report.IsTrue(MatchingPlan != null, "No matching item has been found for plan name: " + thisRow["Plan Name"],
					"Plan: " + thisRow["Plan Name"] + " has matched as expected.");
			}
		}

		[StepDefinition(@"under subheading (.*) I should see text: (.*)")]
		public void ThenUnderSubheadingIShouldSeeText(string subHeading, string text)
		{
			var MySE = new SubscriptionEnrollment();
			string actualText = MySE.Get_Extra_Text_SubHeader(subHeading);
			Report.IsTrue(actualText == text, "Text is not showing as expected. Expected: " + text + " but got: " + actualText,
				"Text is showing as expected: " + text);
		}

		[StepDefinition(@"under subheading (.*) I should see hyperlink: (.*)")]
		public void ThenUnderSubheadingIShouldSeeLink(string subHeading, string link)
		{
			var MySE = new SubscriptionEnrollment();
			string actualLink = MySE.Get_Extra_Text_Link(subHeading);
			Report.IsTrue(actualLink == link, "Text is not showing as expected. Expected: " + link + " but got: " + actualLink,
				"Text is showing as expected: " + link);
		}

		[StepDefinition(@"I select feature plan: (.*)")]
		public void GivenISelectFeaturePlan(string plan)
		{
			var MySE = new SubscriptionEnrollment();
			MySE.Select_Feature_Plan(plan);
		}


		[StepDefinition(@"under subheading (.*) clicking on hyperlink: (.*) opens Agency Service Agreement popup")]
		public void ThenClickingOnHyperlinkOpensAgencyServiceAgreementPopup(string subHeading, string link)
		{
			var MySE = new SubscriptionEnrollment();
			MySE.Click_Extra_Text_Link(subHeading, link);
			var MyASA = new AgencyServiceAgreementDlg();

			Report.IsTrue(MyASA.Wait_for_load(30), "Agency Service Agreement has not appeared as expected",
				"Agency Service Agreement pop is showing as expected");

		}

		[StepDefinition(@"on the Agency Service Agreement popup clicking Close closes the popup")]
		public void ThenOnTheAgencyServiceAgreementPopupClickingCloseClosesThePopup()
		{
			var MyASA = new AgencyServiceAgreementDlg();
			MyASA.ClickCloseButton();
		}


		[StepDefinition(@"Agency Service Agreement popup contains the following text: (.*)")]
		public void ThenAgencyServiceAgreementPopupContainsTheFollowingText(string text)
		{
			var MyASA = new AgencyServiceAgreementDlg();
			//string actualText = MyASA.GetBodyText();
			//Report.IsTrue(actualText == text, "Expected text >>" + text + "<< but got text: >>" + actualText,
			//	"Agency Service Agreement pop is showing as expected: " + actualText);
			string actualText = MyASA.AgencyPopupText();
			Report.IsTrue(actualText == text, "Expected text >>" + text + "<< but got text: >>" + actualText,
				"Agency Service Agreement pop is showing as expected: " + actualText);

			Report.Info("Actual message length is: " + actualText.Length.ToString() +
						" expected message length is: " + text.Trim().Length);
			if (actualText.Trim() != text.Trim())
			{
				var builder = new StringBuilder();
				char[] ar1 = actualText.ToArray();
				for (int i = 0; i < ar1.Length; i++)
				{
					if (actualText.Length > i + 1 && ar1[i].Equals(text[i]))
					{
						builder.Append(ar1[i]);
					}
					else
					{
						Report.Info("Failed on actual is: " + ar1[i] + " and expected is: " + text[i]);
						break;
					}
				}

				Report.Info("Matched up to " + builder);
			}
		}

		[StepDefinition(@"I set the (Articles|Enhanced Articles|Formulated Products) to be: (.*), then the Annual Cost should be: (.*)")]
		public void CheckingThatUpdatingInputsChangesCost(string section, string option, string cost)
		{
			if (Report.IsTrue(new SubscriptionEnrollment().SetSection(section, option), "Failed to set section: " + section + " to option: " + option, "Successfully set section: " + section + " to option: " + option))
			{
				string actualCost = new SubscriptionEnrollment().GetEstimatedAnualCost();
				Report.IsTrue(actualCost.Trim() == cost.Trim(), string.Format("Expected to see a total cost of: {0}, but found: {1}!", cost, actualCost), string.Format("Total cost was showing {0}, as expected", cost));
			}
		}

		[StepDefinition(@"I should see following statement at the bottom (.*)")]
		public void ThenIShouldSeeFollowingStatementAtTheBottom(string statement)
		{
			var MySE = new SubscriptionEnrollment();
			string actualText = MySE.GetFooterSubsCalculatorText();

			GeneralFunctions.DoStringsMatch(statement, actualText, true);
			Report.IsTrue(GeneralFunctions.DoStringsMatch(statement.Trim(), actualText.Trim()), "Expecting: " + statement + " but showing: " + actualText,
				"Text is showing as expected: " + actualText);
		}

		[StepDefinition(@"I should see Estimated Annual Cost of: (.*)")]
		public void ThenIShouldSeeEstimatedAnnualCostOf(string cost)
		{
			var MySE = new SubscriptionEnrollment();
			string actualCost = MySE.GetEstimatedAnualCost();
			Report.IsTrue(actualCost.Trim() == cost.Trim(), "Expected cost: " + cost + " actual cost: " + actualCost,
				"Cost is showing as expected: " + cost);
		}

		[StepDefinition(@"I should see Estimated Annual Cost per Product of:(.*)")]
		public void ThenIShouldSeeEstimatedAnnualCostPerProductOf(string cost)
		{
			var MySE = new SubscriptionEnrollment();
			string actualCost = MySE.GetEstimatedAnualCostPerProduct();
			Report.IsTrue(actualCost.Trim() == cost.Trim(), "Expected cost: " + cost + " actual cost: " + actualCost,
				"Cost is showing as expected: " + cost);
		}

		[StepDefinition(@"I should see Proceed button (enabled|disabled)")]
		public void ThenIShouldSeeProceedButtonDisabled(string enabled)
		{
			bool expectedEnabled = enabled == "enabled";
			Report.IsTrue(new SubscriptionEnrollment().Proceed_button_enabled() == expectedEnabled, string.Format("Proceed button is {0}", expectedEnabled ? "disabled" : "enabled"), "Proceed button is " + enabled);
		}


		[StepDefinition(@"In the Subscription Enrollment screen I confirm that I (do|do not) see the following Plans:")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmThatIDoOrNotSeeTheFollowingPlans(string doOrNot, Table table)
		{
			var MySE = new SubscriptionEnrollment();
			List<string> planNames = MySE.GetAllPlanNames();
			if (doOrNot == "do")
			{
				foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
				{
					Report.IsTrue(planNames.Contains(thisRow["plan"]), thisRow["plan"] + " is not showing as expected",
						thisRow["plan"] + " is showing as expected");
				}
			}
			else
			{
				foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
				{
					Report.IsTrue(!planNames.Contains(thisRow["plan"]), thisRow["plan"] + " is showing as expected and should not be",
						thisRow["plan"] + " is not showing as expected");
				}

			}
		}



		[StepDefinition(@"In the Subscription Enrollment screen I confirm that under the (.*) Plan I see the following items and further details")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmThatUnderThePlanISeeTheFollowingItemsAndFurtherDetails(string plan, Table table)
		{
			var MySE = new SubscriptionEnrollment();
			var allPlans = new List<Plan>();
			if (Context.ScenarioContext.ContainsKey("Plans"))
			{
				allPlans = (List<Plan>)Context.GetFromContext("Plans");
			}
			else
			{
				allPlans = MySE.Get_All_Plans();
				Context.AddToContext("Plans", allPlans);
			}

			//| Item | Further details |Link text  | Link url

			foreach (TechTalk.SpecFlow.TableRow thisRow in table.Rows)
			{
				Plan thisPlan = allPlans.FirstOrDefault(x => x.Plan_Name == plan);

				Info_Point thisInfoPoint = thisPlan.Info_points.FirstOrDefault(x => x.Info_Header == thisRow["Item"]);
				Report.IsTrue(thisInfoPoint != null, "Item has not been found: " + thisRow["Item"].ToString(), "Item has been found: " + thisRow["Item"].ToString(), false, false);

				if (thisRow.ContainsKey("Further details") && thisRow["Further details"].Length > 0)
				{
					string actualHiddenText = MySE.Click_Info_By_Plan_Item_Return_Hidden(plan, thisRow["Item"].ToString());
					thisInfoPoint.Info_Detail = actualHiddenText;
					Report.IsTrue(thisInfoPoint.Info_Detail.Contains(thisRow["Further details"]), "Expected value: >>" + thisRow["Further details"] + "<< not showing as expected. The value showing is: >>" + thisInfoPoint.Info_Detail + "<<",
						thisRow["Further details"] + "is showing as expected.");
				}

				if (table.ContainsColumn("Link text"))
				{
					if (thisRow["Link text"].Length > 0)
					{
						var ExpectedText = thisRow["Link text"].Split(',').ToList();
						var ExpectedURLs = thisRow["Link url"].Split(',').ToList();

						if (ExpectedURLs.Count != ExpectedText.Count)
						{
							throw new Exception(
								"The test needs to supply matching numbered comma-delimited lists of expected link text and urls.");
						}

						var ExpectedLinks = new List<Info_Link>();

						for (int i = 0; i < ExpectedText.Count; i++)
						{
							ExpectedLinks.Add(new Info_Link(ExpectedText[i], ExpectedURLs[i]));
						}

						List<Info_Link> ActualLinks = thisInfoPoint.Info_Links;

						foreach (Info_Link thisExpectedInfoLink in ExpectedLinks)
						{
							Info_Link MatchingLink = ActualLinks.FirstOrDefault(x =>
								x.Link_URL == thisExpectedInfoLink.Link_URL && x.Link_Text == thisExpectedInfoLink.Link_Text);
							if (MatchingLink != null)
							{
								Report.IsTrue(
									MySE.Click_link(plan, thisRow["Item"], thisExpectedInfoLink.Link_Text, thisExpectedInfoLink.Link_URL),
									"Failed to correctly click link: " + thisExpectedInfoLink.Link_Text,
									"Correctly clicked link: " + thisExpectedInfoLink.Link_Text);
							}
						}
					}

				}
			}
		}



		[StepDefinition(@"In the Subscription Enrollment screen I confirm that the option showing in the (Articles|Enhanced Articles|Formulated Products) dropdown is: (.*)")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmThatTheOptionShowingInTheDropdownIs(string dropdown, string expectedOption)
		{
			string selected = new SubscriptionEnrollment().GetSectionSelectedOption(dropdown);
			Report.IsTrue(expectedOption == selected, "Selected option should be: " + expectedOption + " but is: " + selected, "Option is showing as expected");
		}


		[StepDefinition(@"In the Subscription Enrollment screen I confirm that you see (.*) dropdown")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmThatYouSeeDropdown(string dropdown)
		{
			var MySE = new SubscriptionEnrollment();

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

		[StepDefinition("I check that the following are showing in the (Articles|Enhanced Articles|Formulated Products) dropdown:")]
		public void CheckThatCorrectItemsAreShowing(string section, Table expected)
		{
			List<string> showing = new SubscriptionUpgrade().ReturnSelectDropDownItems(section);
			Report.Info("Available items: " + string.Join(", ", showing));
			foreach (TableRow row in expected.Rows)
			{
				Report.IsTrue(showing.Contains(row[0].Trim()), "Failed to find the item: " + row[0] + "!", "Item: " + row[0].Trim() + " was found successfully!", false, false);
			}
			Report.Screenshot();
		}

		[StepDefinition(@"The (Articles|Enhanced Articles|Formulated Products) popup should have (header|content): (.*)")]
		public void CheckingContentOfPopupDialog(string section, string type, string text)
		{
			new SubscriptionEnrollment().HoverOverInformationElement(section);
			var Popup = new SubscriptionPopup();
			switch (type)
			{
				case ("header"):
					Report.IsTrue(Popup.GetHeaderText().Trim() == text.Trim(), "Header was not as expected! Found: " + Popup.GetHeaderText().Trim() + ", but expected: " + text.Trim(), "Header was showing: " + text + " as expected");
					return;
				case ("content"):
					string bodyText = Popup.GetBodyText().Trim();
					Report.IsTrue(bodyText == text.Trim(), "Body text was not as expected! Found: " + bodyText + ", but expected: " + text.Trim(), "Body text was showing: " + text + " as expected");
					return;
			}
		}

		[StepDefinition(@"In the Subscription Enrollment screen I confirm that when you hover over \(i\) for (.*) you see following (heading|statement): (.*)")]
		public void ThenInTheSubscriptionEnrollmentScreenIConfirmThatWhenYouHoverOverIForYouSeeFollowing(string hoverOverItem, string headerOrText, string expectedValue)
		{
			var MySE = new SubscriptionEnrollment();
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
			Report.StartStep(Report.Details.StepIndex + " - I cancel the Enrollment dialog, confirm correct page opens and Proceed");
			try
			{
				var mySub = new SubscriptionEnrollment();

				this.ThenIClickOnX("Cancel");

				Report.IsTrue(mySub.Proceed_click(), "Failed to Click Proceed Button", "Proceed Button Clicked");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click on the Proceed button")]
		public void ClickProceedButton()
		{
			Report.IsTrue(new SubscriptionEnrollment().Proceed_click(), "Failed to click the proceed button!", "Successfully clicked the proceed button!");
		}

		[StepDefinition(@"The selected item in section: (Select the feature plan|Select the Support Services Plan) should be: (.*)")]
		public void VerifyCorrectItemIsSelectedInSection(string section, string text)
		{
			string showing = new SubscriptionEnrollment().GetSelectedItemInSection(section).Split(new string[] { "\r\n" }, StringSplitOptions.None).FirstOrDefault().Trim();
			Report.IsTrue(text.Trim() == showing.Trim(), "Selected item was not as expected! Expected: " + text.Trim() + ", but found: " + showing.Trim(), "Item " + text.Trim() + " was successfully selected!");
		}

		[StepDefinition(@"I confirm the chosen options and body text are correct")]
		public void ThenIConfirmTheChosenOptionsAndBodyTextAreCorrect(Table table)
		{
			Report.StartStep(Report.Details.StepIndex + " - I confirm the chosen options and body text are correct");
			try
			{
				var mySubDlg = new SubscriptionEnrollmentDlg();

				foreach (TableRow thisRow in table.Rows)
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
			Report.StartStep(Report.Details.StepIndex + " - I click on " + button);
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

		[StepDefinition(@"I see the alert message with text: (.*) under Subscription Enrollment")]
		public void TopAlertMessage(string value)
		{
			List<string> actualText = new SubscriptionEnrollment().GetAlertMessage();
			//Report.IsTrue(actualText == value,
			//	"The alert message was not showing the expeted text! Expected: '" + value + "' but got: '" + actualText,
			//	"The alert message was showing the expected text: '" + value + "'");
			Report.IsTrue(actualText.Contains(value), "Warning is not showing as expected. Expected: " + value + " but got: " + string.Join(",", actualText),
				"Warning is showing as expected");
		}
	}
}
