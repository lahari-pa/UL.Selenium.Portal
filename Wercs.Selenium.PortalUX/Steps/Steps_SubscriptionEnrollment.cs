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
	class Steps_SubscriptionEnrollment
	{


		[StepDefinition(@"I select the following enrollment options")]
		public void ThenISelectTheFollowingEnrollmentOptions(Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I select enrollment options");
			try
			{
				var mySub = new SubscriptionEnrollment();

				foreach (var ThisRow in table.Rows)
				{
					string articles = ThisRow["Articles"];
					string en_articles = ThisRow["Enhanced Articles"];
					string form_prods = ThisRow["Formulated Products"];
					string feature_plan = ThisRow["Feature Plan"];
					string services_plan = ThisRow["Support Services Plan"];

					Report.IsTrue(mySub.Select_Enrollment_Options(articles, en_articles, form_prods, feature_plan, services_plan),
						"Failed to Select Enrollment Options", "Enrollment Options Selected");
				}

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
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
				var mySubDlg = new SubscriptionEnrollment_Dlg();

				foreach (var ThisRow in table.Rows)
				{
					string articles = ThisRow["Articles"];
					string en_articles = ThisRow["Enhanced Articles"];
					string form_prods = ThisRow["Formulated Products"];
					string feature_plan = ThisRow["Feature Plan"];
					string services_plan = ThisRow["Support Services Plan"];
					string body_text = ThisRow["Body Text"];

					Report.IsTrue(mySubDlg.Check_Options(feature_plan, articles, en_articles, form_prods, services_plan), "Failed to Check Enrollment Options", "Enrollment Options are Correct");
					Report.IsTrue(mySubDlg.Subscription_Text(body_text), "Incorrect Subscription Text", "Correct Subscription Text");

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
				var mySubDlg = new SubscriptionEnrollment_Dlg();
				var myPay = new PaymentMethods();

				if (button == "Cancel")
				{
					Report.IsTrue(mySubDlg.Cancel_click(), "Failed to Click Cancel Button", "Cancel Button Clicked");
					Delay.Seconds(1 * Delay.SpeedFactor);
					if (mySub.Exists)
					{
						throw new Exception("Subscription Enrollment Page Failed to Open");
					}
					Report.Info("On Subscription Enrollment Page");
				}
				if (button == "Checkout")
				{
					Report.IsTrue(mySubDlg.Checkout_click(), "Failed to Click Checkout Button", "Checkout Button Clicked");
					Delay.Seconds(1 * Delay.SpeedFactor);
					if (myPay.Exists)
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
