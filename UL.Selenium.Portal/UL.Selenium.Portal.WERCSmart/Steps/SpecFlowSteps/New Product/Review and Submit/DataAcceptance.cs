using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using Reqnroll;
using UL.Automation.Reporting.Functions;
using UL.Automation.ReqnrollHelpers.Attributes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;

namespace UL.Selenium.Portal.WERCSmart.Steps.SpecFlowSteps.New_Product.Review_and_Submit
{
	[Binding, Scope(Tag = "Product:WERCSmart_Page:NewProducts_Tab:ReviewAndSubmit_Section:DataAcceptance")]
	class WERCSmart_Distributor_NewProducts_ReviewAndSubmit_DataAcceptance
	{
		[RegexStepDefinition(@"In the Data Acceptance Section, (check|uncheck) 'Agreed' checkbox")]
		public void CheckUncheckAgreedCheckbox(string checked_unchecked)
		{
			string checkbox = "Agreed";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(checked_unchecked, checkbox);
		}
		[RegexStepDefinition(@"In the Data Acceptance Section, (check|uncheck) 'Yes, Agreed' checkbox")]
		public void CheckUncheckYesAgreedCheckbox(string checked_unchecked)
		{
			string checkbox = "Yes, Agreed";
			new Steps_Prototype().ICheckTheCheckboxWithDescription(checked_unchecked, checkbox);
		}
		[RegexStepDefinition(@"In the Data Acceptance Section, click 'Summary' button")]
		public void ClickSummaryButton()
		{
			string button = "Summary";
			new Steps_Prototype().ClickButton(button);
		}
		//If Subscription Enrollment page is displayed, step adds subscription and clicks 'Confirm Order'
		[RegexStepDefinition(@"In the Data Acceptance Section, click 'Accept' button")]
		public void ClickAcceptButton()
		{
			string button = "Accept";
			new Steps_Prototype().ClickButton(button);
			Report.UseSubSteps = true;
			var MyStepsPaymentMethods = new Steps_PaymentMethods();
			var sub = new SubscriptionEnrollment();
			var myPay = new Steps_PaymentMethods();

			if (new SubscriptionEnrollment_new().WaitForContainerToBeVisible())
			{
				var subEnrollment = new SubscriptionEnrollment_new();
				if (Report.IsTrue(subEnrollment.EnrollmentFooterExists(), $"Failure, enrollment footer does not exist.", $"Success, enrollment footer exists."))
				{
					if (Report.IsTrue(subEnrollment.EnrollmentFooterButtonExists("PROCEED"), $"Failure, in enrollment footer 'PROCEED' button does not exist.", $"Success, in enrollment footer 'PROCEED' button exists."))
					{
						Report.IsTrue(subEnrollment.EnrollmentFooterButtonClick("PROCEED"), $"Failure, in enrollment footer failed to click 'PROCEED' button.", $"Success, in enrollment footer clicked 'PROCEED' button.");
						new SubscriptionEnrollmentModal().WaitForContainerToBeVisible();
						if (Report.IsTrue(new SubscriptionEnrollmentModal().ModalButtonExists("Checkout"), $"Failure, in the Subscription Enrollment modal, I confirm 'Checkout' button does not exists.", $"Success, in the Subscription Enrollment modal, I confirm 'Checkout' button does exist."))
						{
							Report.IsTrue(new SubscriptionEnrollmentModal().ModalButtonClick("Checkout"), $"Failure, in the Subscription Enrollment modal, failed to click 'Checkout' button.", $"Success, in the Subscription Enrollment modal, successfully clicked 'Checkout' button.");
						}
					}
				}
				new PaymentMethods().WaitForContainerToBeVisible();

				if (new PaymentMethods().Payment_Method_Exists("Credit Card"))
				{
					Report.Info("Credit card details is already added");
					if(!new PaymentMethods().Credit_Card_Default())
					{
						Report.IsTrue(new PaymentMethods().ClickMakeDeaultForPaymentMetod("Credit Card"), "Failed to make Credit Card as Default Payment Method",
							"Successfully made Credit Card as Default Payment Method");
					}
					Report.StartSubStep("In the Payment Methods screen I click Continue");
					MyStepsPaymentMethods.ThenIClickContinue();
				}
				else
				{
					foreach (string address in new PaymentMethods().Get_Billing_Address())
					{
						if (address.Contains("undefined"))
						{
							Report.Info("The state is undefined in Billing Address");
							Report.Info("Attempt to edit state");
							Report.IsTrue(new PaymentMethods().Change_click(), "Failed to Click Change Button", "Change Button Clicked");
							Report.IsTrue(new PaymentMethods_Edit_Address().EditState("New York"), "Failed to select state", "Successfully selected state");
							Report.IsTrue(new PaymentMethods_Edit_Address().Save_click(), "Failed to Click Save Button", "Save Button Clicked");
						}
					}
					var myCreditCardTable = new Table("Card Type", "Card Number", "Expiration Month", "Expiration Year", "CVV", "Cardholder Name", "Postal Code");
					myCreditCardTable.AddRow("Visa", "4111 1111 1111 1111", "08", "2028", "1111", "WERCS_QA_Automation", "12205");

					if (!new PaymentMethods().Select_Payment_Method("Credit Card"))
					{
						new PaymentMethods().Add_A_New_Payment_Method("Credit Card");
						myPay.ThenIEnterCreditCardDetails(myCreditCardTable);
						Report.IsTrue(new PaymentMethods().ClickSubmitButton(), "Failed to click Submit button", "Successfully clicked Submit button");
					}
					else
					{
						myPay.ThenIEnterCreditCardDetails(myCreditCardTable);
						Report.IsTrue(new PaymentMethods().ClickSubmitButton(), "Failed to click Submit button", "Successfully clicked Submit button");
						Report.StartSubStep("In the Payment Methods screen I click Continue");
					}	
				}
			}
			if (new PaymentMethods_Subscription_Billing().Purchase_Header_Correct())
			{
				if (new PaymentMethods_Subscription_Billing().ConfirmOrderButtonExists())
				{
					Report.IsTrue(new PaymentMethods_Subscription_Billing().Confirm_Order_click(), "Failed to Click Confirm Order Button", "Confirm Order Button Clicked");
					GeneralUtilities.WaitForRefreshToDisappear(new PaymentMethods_Subscription_Billing().Btn_confirm);
					GeneralUtilities.Wait_for_load_finish();
					Report.Screenshot();
				}
			}
		}
		//Step doesn't click 'Confirm Order'
		[RegexStepDefinition(@"In the Data Acceptance Section, click 'Accept' button and don't click 'Confirm Order' button")]
		public void ClickAcceptButtonWithoutClickingConfirmOrder()
		{
			string button = "Accept";
			new Steps_Prototype().ClickButton(button);
			Report.UseSubSteps = true;
			var MyStepsPaymentMethods = new Steps_PaymentMethods();
			var sub = new SubscriptionEnrollment();
			var myPay = new Steps_PaymentMethods();

			if (new SubscriptionEnrollment_new().WaitForContainerToBeVisible())
			{
				var subEnrollment = new SubscriptionEnrollment_new();
				if (Report.IsTrue(subEnrollment.EnrollmentFooterExists(), $"Failure, enrollment footer does not exist.", $"Success, enrollment footer exists."))
				{
					if (Report.IsTrue(subEnrollment.EnrollmentFooterButtonExists("PROCEED"), $"Failure, in enrollment footer 'PROCEED' button does not exist.", $"Success, in enrollment footer 'PROCEED' button exists."))
					{
						Report.IsTrue(subEnrollment.EnrollmentFooterButtonClick("PROCEED"), $"Failure, in enrollment footer failed to click 'PROCEED' button.", $"Success, in enrollment footer clicked 'PROCEED' button.");
						new SubscriptionEnrollmentModal().WaitForContainerToBeVisible();
						if (Report.IsTrue(new SubscriptionEnrollmentModal().ModalButtonExists("Checkout"), $"Failure, in the Subscription Enrollment modal, I confirm 'Checkout' button does not exists.", $"Success, in the Subscription Enrollment modal, I confirm 'Checkout' button does exist."))
						{
							Report.IsTrue(new SubscriptionEnrollmentModal().ModalButtonClick("Checkout"), $"Failure, in the Subscription Enrollment modal, failed to click 'Checkout' button.", $"Success, in the Subscription Enrollment modal, successfully clicked 'Checkout' button.");
						}
					}
				}
				new PaymentMethods().WaitForContainerToBeVisible();

				if (new PaymentMethods().Payment_Method_Exists("Credit Card"))
				{
					Report.Info("Credit card details is already added");
					if (!new PaymentMethods().Credit_Card_Default())
					{
						Report.IsTrue(new PaymentMethods().ClickMakeDeaultForPaymentMetod("Credit Card"), "Failed to make Credit Card as Default Payment Method",
							"Successfully made Credit Card as Default Payment Method");
					}
					Report.StartSubStep("In the Payment Methods screen I click Continue");
					MyStepsPaymentMethods.ThenIClickContinue();
				}
				else
				{
					foreach (string address in new PaymentMethods().Get_Billing_Address())
					{
						if (address.Contains("undefined"))
						{
							Report.Info("The state is undefined in Billing Address");
							Report.Info("Attempt to edit state");
							Report.IsTrue(new PaymentMethods().Change_click(), "Failed to Click Change Button", "Change Button Clicked");
							Report.IsTrue(new PaymentMethods_Edit_Address().EditState("New York"), "Failed to select state", "Successfully selected state");
							Report.IsTrue(new PaymentMethods_Edit_Address().Save_click(), "Failed to Click Save Button", "Save Button Clicked");
						}
					}
					var myCreditCardTable = new Table("Card Type", "Card Number", "Expiration Month", "Expiration Year", "CVV", "Cardholder Name", "Postal Code");
					myCreditCardTable.AddRow("Visa", "4111 1111 1111 1111", "08", "2028", "1111", "WERCS_QA_Automation", "12205");

					if (!new PaymentMethods().Select_Payment_Method("Credit Card"))
					{
						new PaymentMethods().Add_A_New_Payment_Method("Credit Card");
						myPay.ThenIEnterCreditCardDetails(myCreditCardTable);
						Report.IsTrue(new PaymentMethods().ClickSubmitButton(), "Failed to click Submit button", "Successfully clicked Submit button");
					}
					else
					{
						myPay.ThenIEnterCreditCardDetails(myCreditCardTable);
						Report.IsTrue(new PaymentMethods().ClickSubmitButton(), "Failed to click Submit button", "Successfully clicked Submit button");
						Report.StartSubStep("In the Payment Methods screen I click Continue");
					}
				}
			}
		}

		[RegexStepDefinition(@"In the Data Acceptance Section, I confirm text 'Data Acceptance' text (should|should not) be displayed")]
		public void GivenIConfirmTheFormulation3rdPartyDataUseConsentsDisplaysTheCorrectText(string condition)
		{
			string section = "Data Acceptance";
			string[] correctText =
			{
			"UL’s WERCSmart recipients rely on UL WERCSmart assessments that are performed based on the data you provide about a product. Inaccurate registration data may lead to fines and unsafe working conditions (e.g. related to handling, storage, transportation and disposal of the product) and, ultimately, your organization may incur liability.",
			"By submitting this registration, you confirm that data provided is accurate and complete. If you also provided a Safety Data Sheet (SDS), Article Information Sheet (AIS) and/or Product Label, you confirm the document is compliant with the respective regulations for the region(s) selected for sale of the product. You also confirm the document(s) provided are the most current version and the documents accurately reflect the product being registered.",
			"Should UL have any questions regarding your registration, the data will be suspended or rejected and you will be notified via electronic mail (e-mail). To avoid delays, please verify your contact information is accurate below, as well as within the My Account area of UL’s WERCSmart product."
			};
			new Steps_Prototype().GivenIConfirmTheTextsDisplaysTheCorrectText(section, correctText, condition);

		}
	}
}
