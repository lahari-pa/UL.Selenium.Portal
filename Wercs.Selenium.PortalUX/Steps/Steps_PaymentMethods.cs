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
	[Binding, Scope(Tag = "PaymentMethods")]
	class Steps_PaymentMethods
	{

		[StepDefinition(@"In the Payment Methods screen I check the Payment Methods heading and sub headings are correct")]
		public void ThenICheckThePaymentMethodsHeadingAndSubHeadingsAreCorrect()
		{
			var myPay = new PaymentMethods();
			Delay.Seconds(5 * Delay.SpeedFactor);
			Report.IsTrue(myPay.Payment_Header_Correct(), "Payment Methods Header is Incorrect",
				"Payments Methods Header is Correct");
			Report.IsTrue(myPay.Sub_Heading_Correct(), "Payments Methods Sub Heading is Incorrect",
				"Payments Methods Sub Heading is Correct");
		}

		[StepDefinition(@"In the Payment Methods screen I confirm the following payment options are available")]
		public void ThenIConfirmTheFollowingPaymentOptionsAreAvailable(Table table)
		{
			var myPay = new PaymentMethods();

			foreach (var Row in table.Rows)
			{
				Report.IsTrue(myPay.Payment_Method_Exists(Row["Options"]), Row["Options"] + " Is Not Available", Row["Options"] + " Available");
			}
			Report.Success("Payment Options are all Available");
		}

		[StepDefinition(@"In the Payment Methods screen I confirm the Default method is: (.*)")]
		public void ThenInThePaymentMethodsScreenIConfirmTheDefaultMethodIsX(string defaultMethod)
		{
			var myPay = new PaymentMethods();

			if (defaultMethod == "Credit Card")
			{
				Report.IsTrue(myPay.Credit_Card_Default(), "Failed to Confirm Default Payment Method is " + defaultMethod,
					"Successfully Confirmed Default Payment Method is " + defaultMethod);
			}

		}


		[StepDefinition(@"In the Payment Methods screen I select Payment Method: (.*)")]
		public void ThenISelectPaymentMethodX(string payMethod)
		{
			var myPay = new PaymentMethods();
			Delay.Seconds(3 * Delay.SpeedFactor);
			Report.IsTrue(myPay.Select_Payment_Method(payMethod), "Failed to Select " + payMethod,
				"Successfully Selected " + payMethod);
			Delay.Seconds(3 * Delay.SpeedFactor);
		}


		[StepDefinition(@"In the Payment Methods screen I confirm that the Contact Information is correct for Account saved as (.*)")]
		public void ThenIConfirmThatTheContactInformationIsCorrect(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm that the Contact Information is correct for Account saved as " + savedAs);
			try
			{
				var myPay = new PaymentMethods();

				if (savedAs == "New_Sub")
				{
					if (FeatureContext.Current.ContainsKey("CurrentAccount"))
					{
						savedAs = FeatureContext.Current["CurrentAccount"].ToString();
					}
					Report.Info("Account = " + savedAs);
				}

				var userDetails = (WERCSmartUser)Context.GetFromContext(savedAs);

				string account_name = userDetails.CompanyName;
				string first_name = userDetails.FirstName;
				string last_name = userDetails.LastName;
				string email_address = userDetails.Email;

				Report.IsTrue(myPay.Confirm_Contact_Info(account_name, first_name, last_name, email_address),
					"Contact Information Incorrect", "Confirmed Contact Information");

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Payment Methods screen I confirm that the Billing Address is correct for Account saved as (.*)")]
		public void ThenIConfirmThatTheBillingAddressIsCorrect(string savedAs)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm that the Billing Address is correct for Account saved as " + savedAs);
			try
			{
				var myPay = new PaymentMethods();
				var myAcc = new MyAccount();

				if (savedAs == "New_Sub")
				{
					if (FeatureContext.Current.ContainsKey("CurrentAccount"))
					{
						savedAs = FeatureContext.Current["CurrentAccount"].ToString();
					}
					Report.Info("Account = " + savedAs);
				}

				var userDetails = (WERCSmartUser)Context.GetFromContext(savedAs);

				string address_one = userDetails.Address1;
				string address_two = userDetails.Address2;
				string city = userDetails.City;
				string state = myAcc.Get_State_Code(userDetails.State);
				string zip_code = userDetails.Zip;
				string country = userDetails.Country;
				string phone_no = userDetails.CompanyPhone;

				Report.IsTrue(myPay.Confirm_Billing_Address(address_one, address_two, city, state, zip_code, country, phone_no),
					"Billing Address Incorrect", "Confirmed Billing Address");

			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Payment Methods screen I open the Edit Address form")]
		public void ThenIOpenTheEditAddressForm()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I open the Edit Address form");
			try
			{
				var myPay = new PaymentMethods();

				Report.IsTrue(myPay.Change_click(), "Failed to Click Change Button", "Change Button Clicked");

				Delay.Seconds(4 * Delay.SpeedFactor);

				var myEdit = new PaymentMethods_Edit_Address();

				if (!myEdit.Exists)
				{
					throw new Exception("Failed to Open Edit Address Form");
				}
				Report.Success("Edit Address Form Opened");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm the Sub Headings are correct: (.*), (.*)")]
		public void ThenIConfirmTheSubHeadingsAreCorrect(string sub1, string sub2)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the Sub Headings are correct");
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				Report.Info("Sub Heading = " + sub1);
				Report.Info("Sub Heading = " + sub2);

				Report.IsTrue(myPay.Sub_Headings_Correct(sub1, sub2), "Sub Headings are Incorrect", "Sub Headings are Correct");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm the Edit Address form has the correct fields")]
		public void ThenIConfirmTheEditAddressFormHasTheCorrectFields(Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the Edit Address form has the correct fields");
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				List<string> myList = new List<string>();

				foreach (var Row in table.Rows)
				{
					myList.Add(Row["Field"]);
				}

				if (!myPay.Billing_Headers_Check(myList))
				{
					throw new Exception("Failed to Check Fields are Correct");
				}
				Report.Success("Fields are Correct");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I (check|un-check) the Shipping Address is the same as the billing address checkbox")]
		public void ThenICheckTheShippingAdreessIsTheSameAsTheBillingAddressCheckbox(string check)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I " + check + " the Shipping Adreess is the same as the billing address checkbox");
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				bool myCheck = check != "un-check";

				Report.IsTrue(myPay.Shipp_Same_As_Bill_Check(myCheck), "Failed to " + check + " Checkbox",
					"Successfully " + check + "ed Checkbox");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm the Shipping Address form has the correct fields")]
		public void ThenIConfirmTheShippingAddressFormHasTheCorrectFields(Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the Shipping Address form has the correct fields");
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				List<string> myList = new List<string>();

				foreach (var Row in table.Rows)
				{
					myList.Add(Row["Field"]);
				}

				if (!myPay.Shipping_Headers_Check(myList))
				{
					throw new Exception("Failed to Check Fields are Correct");
				}
				Report.Success("Fields are Correct");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm the Shipping Address is hidden")]
		public void ThenIConfirmTheShippingAddressIsHidden()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the Shipping Address is hidden");
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				Report.IsTrue(myPay.Shipping_Address_Hidden(), "Shipping Address Found", "Shipping Address is Hidden");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I cancel the Edit Address form")]
		public void ThenICancelTheEditAddressForm()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I cancel the Edit Address form");
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				Report.IsTrue(myPay.Cancel_click(), "Failed to Click Cancel", "Cancel Button Clicked");
				Delay.Seconds(2 * Delay.SpeedFactor);
				var myPaymentOp = new PaymentMethods();

				if (!myPaymentOp.Exists)
				{
					throw new Exception("Failed to Open Payment Methods Page");
				}
				Report.Success("Payment Methods Page Open");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I edit the Primary Account Contact")]
		public void ThenIEditThePrimaryAccountContact(Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I edit the Primary Account Contact");
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				foreach (var thisRow in table.Rows)
				{
					string firstName = thisRow["First Name"];
					string lastName = thisRow["Last Name"];
					string email = thisRow["Email Address"];

					if (firstName == "<empty>")
					{
						firstName = "";
					}
					if (lastName == "<empty>")
					{
						lastName = "";
					}
					if (email == "<empty>")
					{
						email = "";
					}

					Report.IsTrue(myPay.Edit_Primary_Account_Contact(firstName, lastName, email),
						"Failed to Edit Primary Account Contact", "Primary Account Contact Edited Successfully");

				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I edit the Billing Address for user saved as: (.*)")]
		public void ThenIEditTheBillingAddress(string savedAs, Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I edit the Billing Address");
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				if (savedAs == "New_Sub")
				{
					if (FeatureContext.Current.ContainsKey("CurrentAccount"))
					{
						savedAs = FeatureContext.Current["CurrentAccount"].ToString();
					}
					Report.Info("Account = " + savedAs);
				}

				var wsUser = (WERCSmartUser)Context.GetFromContext(savedAs);
				foreach (var thisRow in table.Rows)
				{
					string address1 = thisRow["Address Line 1"];
					string address2 = thisRow["Address Line 2"];
					string city = thisRow["City"];
					string state = thisRow["State"];
					string zip = thisRow["Zip Code"];
					string country = thisRow["Country"];
					string phone_no = thisRow["Phone Number"];

					if (address1 == "<empty>")
					{
						address1 = "";
					}
					if (address2 == "<empty>")
					{
						address2 = "";
					}
					if (city == "<empty>")
					{
						city = "";
					}
					if (state == "<empty>")
					{
						state = "";
					}
					if (zip == "<empty>")
					{
						zip = "";
					}
					if (country == "<empty>")
					{
						country = "";
					}
					if (phone_no == "<empty>")
					{
						phone_no = "";
					}

					Report.IsTrue(myPay.Edit_Billing_Address(address1, address2, city, state, zip, country, phone_no),
						"Failed to Edit Billing Address", "Billing Address Edited Successfully");

					wsUser.Address1 = address1 == "" ? wsUser.Address1 : address1;
					wsUser.Address2 = address2 == "" ? wsUser.Address2 : address2;
					wsUser.City = city == "" ? wsUser.City : city;
					wsUser.State = state == "" ? wsUser.State : state;
					wsUser.Zip = zip == "" ? wsUser.Zip : zip;
					wsUser.Country = country == "" ? wsUser.Country : country;
					wsUser.CompanyPhone = phone_no == "" ? wsUser.CompanyPhone : phone_no;

					Context.AddToContext(savedAs, wsUser);

					Report.IsTrue(myPay.Save_click(), "Failed to Click Save Button", "Save Button Clicked");
					Delay.Seconds(10 * Delay.SpeedFactor);
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Payment Methods screen I confirm the Continue Button is (enabled|disabled)")]
		public void ThenIConfirmTheContinueButtonIsX(string enabled)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the Continue Button is " + enabled);
			try
			{
				var myPay = new PaymentMethods();

				Report.IsTrue(myPay.Continue_Button_Enabled(enabled), "Failed: Continue Button is Not" + enabled, "Success: Continue Button is " + enabled);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Payment Methods screen I confirm the (Credit Card|ACH) fields are correct")]
		public void ThenIConfirmTheXFieldsAreCorrect(string payMethod, Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the " + payMethod + " fields are correct");
			try
			{
				var myPay = new PaymentMethods();

				List<string> myList = new List<string>();

				foreach (var Row in table.Rows)
				{
					myList.Add(Row["Field"]);
				}

				if (payMethod == "Credit Card")
				{
					if (!myPay.Credit_Card_Fields_Check(myList))
					{
						throw new Exception("Failed to Check " + payMethod + " Fields are Correct");
					}
					Report.Success(payMethod + " Fields are Correct");
				}
				if (payMethod == "ACH")
				{
					if (!myPay.ACH_Fields_Check(myList))
					{
						throw new Exception("Failed to Check " + payMethod + " Fields are Correct");
					}
					Report.Success(payMethod + " Fields are Correct");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Payment Methods screen I confirm the following warning message appears: (.*)")]
		public void ThenIConfirmTheFollowingWarningMessageAppears(string warningMsg)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the Wire Transfer warning message appears");
			try
			{
				var myPay = new PaymentMethods();

				Report.IsTrue(myPay.Wire_Transfer_Warning(warningMsg), "Incorrect Warning Message", "Correct Warning Message");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Payment Methods screen I confirm the following text message appears for PayPal: (.*)")]
		public void ThenIConfirmTheFollowingTextMessageAppearsForPayPal(string textMsg)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the PayPal text message appears");
			try
			{
				var myPay = new PaymentMethods();
				string actualText = myPay.Paypal_text();
				Report.IsTrue(actualText == textMsg, "Expected text >>" + textMsg + "<< but got text: >>" + actualText,
					"PayPal text is showing as expected: " + actualText);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Payment Methods screen I confirm (Credit Card|ACH) error messages for the following fields are displayed")]
		public void ThenIConfirmErrorMessagesForTheFollowingFieldsAreDisplayed(string payMethod, Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm error messages for " + payMethod + " fields are correct");
			try
			{
				var myPay = new PaymentMethods();

				List<string> myList = new List<string>();

				foreach (var Row in table.Rows)
				{
					myList.Add(Row["Field"]);
				}
				Delay.Seconds(10 * Delay.SpeedFactor);
				if (payMethod == "Credit Card")
				{
					if (!myPay.Credit_Card_Error_Check(myList))
					{
						throw new Exception("Failed to Check " + payMethod + " Error Messages are Correct");
					}
					Report.Success(payMethod + " Error Messages are Correct");
				}
				if (payMethod == "ACH")
				{
					if (!myPay.ACH_Error_Check(myList))
					{
						throw new Exception("Failed to Check " + payMethod + " Error Messages are Correct");
					}
					Report.Success(payMethod + " Error Messages are Correct");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Payment Methods screen I click Continue")]
		public void ThenIClickContinue()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Payment Methods screen I click Continue");
			try
			{
				var myPay = new PaymentMethods();
				Delay.Seconds(2 * Delay.SpeedFactor);
				Report.IsTrue(myPay.Continue_click(), "Failed to Click Continue", "Continue Button Clicked");
				Delay.Seconds(15 * Delay.SpeedFactor);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Payment Methods screen I enter Credit Card details")]
		public void ThenIEnterCreditCardDetails(Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Payment Methods screen I enter Credit Card details");
			try
			{
				var myPay = new PaymentMethods();

				foreach (var thisRow in table.Rows)
				{
					string card_type = thisRow["Card Type"];
					string card_no = thisRow["Card Number"];
					string exp_month = thisRow["Expiration Month"];
					string exp_year = thisRow["Expiration Year"];
					string cvv = thisRow["CVV"];
					string cardh_name = thisRow["Cardholder Name"];

					Report.IsTrue(myPay.Enter_Credit_Card_Details(card_type, card_no, exp_month, exp_year, cvv, cardh_name),
						"Failed to Enter Credit Card Details", "Credit Card Details Entered");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Purchase Summary screen I confirm the Purchase Summary header is displayed")]
		public void ThenIConfirmThePurchaseSummaryHeaderIsDisplayed()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the Purchase Summary header is displayed");
			try
			{
				var myPay = new PaymentMethods_Subscription_Billing();
				Delay.Seconds(5 * Delay.SpeedFactor);
				Report.IsTrue(myPay.Purchase_Header_Correct(), "Purchase Summary Header is Incorrect",
					"Purchase Summary Header is Correct");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Purchase Summary screen I check the Subscription Billing header is correct")]
		public void ThenICheckTheSubscriptionBillingHeaderIsCorrect()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I check the Subscription Billing header is correct");
			try
			{
				var mySub = new PaymentMethods_Subscription_Billing();

				Delay.Seconds(5 * Delay.SpeedFactor);
				Report.IsTrue(mySub.Subscription_Billing_Header_Correct(), "Header is Incorrect", "Header is Correct");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Purchase Summary screen I confirm the Yearly Radio Option is (selected|not selected)")]
		public void ThenIConfirmTheYearlyRadioOptionIsX(string select)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the Yearly Radio Option is " + select);
			try
			{
				Delay.Seconds(2 * Delay.SpeedFactor);
				var mySub = new PaymentMethods_Subscription_Billing();
				if (select == "selected")
				{
					Report.IsTrue(mySub.Yearly_Option_Selected(), "Yearly Radio Option is Not Selected", "Yearly Radio Option is Selected");
				}
				if (select == "not selected")
				{
					Report.IsTrue(mySub.Yearly_Option_Selected(), "Yearly Radio Option is Selected", "Yearly Radio Option is Not Selected");
				}
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Purchase Summary screen I confirm the column headings are correct: (.*), (.*), (.*)")]
		public void ThenIConfirmTheColumnHeadingsAreCorrectXYZ(string column_1, string column_2, string column_3)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the column headings are correct");
			try
			{
				var mySub = new PaymentMethods_Subscription_Billing();

				Report.IsTrue(mySub.Column_Headings_Correct(column_1, column_2, column_3), "Column Headers Incorrect",
					"Column Headers Correct");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Purchase Summary screen I confirm the folling statement is shown: (.*)")]
		public void ThenIConfirmTheFollingStatementIsShownX(string statement)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the folling statement is shown: " + statement);
			try
			{
				var mySub = new PaymentMethods_Subscription_Billing();

				Report.IsTrue(mySub.Table_Footer_Statement(statement), "Statement is Not Shown",
					"Statement is Shown");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Purchase Summary screen I confirm the Prices and Payment section contains the text: (.*)")]
		public void ThenInThePurchaseSummaryScreenIConfirmThePricesAndPaymentSectionContainsTheText(string prices_text)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Purchase Summary screen I confirm the Prices and Payment section contains the correct text");
			try
			{
				var mySub = new PaymentMethods_Subscription_Billing();

				Report.Info("Prices and Payment Text = " + prices_text);

				Report.IsTrue(mySub.Prices_And_Payment_Section(prices_text), "Prices and Payment Section Incorrect",
					"Prices and Payment Section Correct");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Purchase Summary screen I confirm the following statement is shown: (.*)")]
		public void ThenInThePurchaseSummaryScreenIConfirmTheFollowingStatementIsShown(string confirm_text)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Purchase Summary screen I confirm the following statement is shown: " + confirm_text);
			try
			{
				var mySub = new PaymentMethods_Subscription_Billing();

				Report.Info("Confirmation Text = " + confirm_text);

				Report.IsTrue(mySub.Confirmation_Text_Correct(confirm_text), "Confirmation Section Incorrect",
					"Confirmation Section Correct");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Purchase Summary screen I click Confirm Order")]
		public void ThenInThePurchaseSummaryScreenIClickConfirmOrder()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Purchase Summary screen I click Confirm Order");
			try
			{
				var mySub = new PaymentMethods_Subscription_Billing();

				Report.IsTrue(mySub.Confirm_Order_click(), "Failed to Click Confirm Order Button", "Confirm Order Button Clicked");

				Delay.Seconds(20 * Delay.SpeedFactor);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Purchase Summary screen if Product Billing is displayed I click Confirm Order")]
		public void ThenInThePurchaseSummaryScreenIfProductBillingIsShownIClickConfirmOrder()
		{
			var mySub = new PaymentMethods_Subscription_Billing();
			if (mySub.Product_Billing_Header_Displayed())
			{
				Report.Info("The Product Billing section was displayed, so trying to click 'Confirm Order'");
				Report.IsTrue(mySub.Confirm_Order_click(), "Failed to Click Confirm Order Button", "Confirm Order Button Clicked");
				Delay.Seconds(10);
			};
			Report.Info("The Product Billing section was not displayed, so not clicking 'Confirm Order'");

		}

		[StepDefinition(@"In the Thank You screen I check the Header is correct")]
		public void ThenInTheThankYouScreenICheckTheHeaderIsCorrect()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Thank You screen I check the Header is correct");
			try
			{
				var myPay = new PaymentMethods_Thank_You();
				Delay.Seconds(5 * Delay.SpeedFactor);
				Report.IsTrue(myPay.ThankYou_Header_Correct(), "Thank You Header is Incorrect",
					"Thank You Header is Correct");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Thank You screen I confirm the following statement is shown: (.*)")]
		public void ThenInTheThankYouScreenIConfirmTheFollowingStatementIsShownX(string ty_text)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Thank You screen I check the Confirmation statement is correct");
			try
			{
				var myPay = new PaymentMethods_Thank_You();

				Report.Info("Thank You Text = " + ty_text);

				Report.IsTrue(myPay.Thank_You_Text(ty_text), "Thank You Text is Incorrect",
					"Thank You text is Correct");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Thank You screen I click Home")]
		public void ThenInTheThankYouScreenIClickHome()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - In the Thank You screen I click Home");
			try
			{
				var myPay = new PaymentMethods_Thank_You();
				Report.IsTrue(myPay.Home_click(), "Failed to Click Home Button",
					"Home Button Clicked");

				Delay.Seconds(5 * Delay.SpeedFactor);

				var myHome = new StepsHomepage();

				myHome.ThenTheWercSmartHomepageShouldLoad();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"the PayPal page should load")]
		public void ThenThePayPalPageShouldLoad()
		{
			PaymentMethods_PayPal MyPP = new PaymentMethods_PayPal();
			Report.IsTrue(MyPP.Wait_for_load(60), "PayPal page is not showing",
				"PayPal page is showing.");
		}

		[StepDefinition(@"the Purchase Summary should load")]
		[StepDefinition(@"the Purchase Summary should be loaded")]
		public void ThenThePurchaseSummaryShouldLoad()
		{
			try
			{
				Report.Info("Making sure that the Purchase Summary is loaded");
				var mySub = new PaymentMethods_Subscription_Billing();

				Report.IsTrue(mySub.Wait_for_load(), "Purchase Summary failed to load!", "Purchase Summary loaded successfully!");
				GeneralUtilities.Wait_for_load_finish();
				Report.Screenshot();
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}


		[StepDefinition(@"I log into PayPal with user saved as: (.*) and click Continue")]
		public void GivenILogInWithEmailAndPassword(string savedAs)
		{
			var user = TReVor.TestUsers.GetUserSavedAs(savedAs);
			GivenILogInWithEmailAndPassword(user.Username, user.Password);
		}

		[StepDefinition(@"I log into PayPal with email: (.*) and password: (.*) and click Continue")]
		public void GivenILogInWithEmailAndPassword(string username, string password)
		{

			var selPaypal = new PaymentMethods_PayPal();
			Report.IsTrue(selPaypal.Wait_for_load(), "PayPal login page did not load!", "PayPal login page loaded successfully!");

			Report.Info("Entering Email: '" + username + "'");
			selPaypal.EmailField = username;
			selPaypal.Click_Next();

			Report.Info("Entering Password: '" + password + "'");
			selPaypal.PasswordField = password;

			Report.Info("Clicking login");
			selPaypal.Click_Login();

			Report.Info("Clicking AgreeAndContinue");
			var reviewPayPal = new PaymentMethods_PayPal_MemberReview();
			reviewPayPal.Click_AgreeAndContinue();
		}
	}
}
