using System;
using System.Collections.Generic;
using UL.Automation.WebDriver.Classes;
using UL.Automation.Reporting.Functions;
using UL.Automation.SpecFlow.Classes;
using TechTalk.SpecFlow;
using TReVor.Api.Wrapper.Classes;
using UL.Automation.Reporting;
using UL.Automation.TReVor.Classes;
using UL.Selenium.Portal.WERCSmart.Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes;
using UL.Selenium.Portal.WERCSmart.Selenium_Classes.New_Product;
using TReVor.Core.Classes.Software;

namespace UL.Selenium.Portal.WERCSmart.Steps
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

			foreach (TableRow Row in table.Rows)
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm that the Contact Information is correct for Account saved as " + savedAs);
			try
			{
				var myPay = new PaymentMethods();

				if (savedAs == "New_Sub")
				{
					if (Context.FeatureContext.ContainsKey("CurrentAccount"))
					{
						savedAs = Context.FeatureContext["CurrentAccount"].ToString();
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm that the Billing Address is correct for Account saved as " + savedAs);
			try
			{
				var myPay = new PaymentMethods();
				var myAcc = new MyAccount();

				if (savedAs == "New_Sub")
				{
					if (Context.FeatureContext.ContainsKey("CurrentAccount"))
					{
						savedAs = Context.FeatureContext["CurrentAccount"].ToString();
					}
					Report.Info("Account = " + savedAs);
				}

				var userDetails = (WERCSmartUser)Context.GetFromContext(savedAs);

				string address_one = userDetails.Address1;
				string address_two = userDetails.Address2;
				//string city_state_zip = userDetails.City + " " + myAcc.Get_State_Code(userDetails.State) + " " + userDetails.Zip;
				string city_state_zip = userDetails.City + " " + userDetails.State + " " + userDetails.Zip;
				//string state = myAcc.Get_State_Code(userDetails.State);
				//string zip_code = userDetails.Zip;
				string country = userDetails.Country;
				string phone_no = userDetails.CompanyPhone;

				Report.IsTrue(myPay.Confirm_Billing_Address(address_one, address_two, city_state_zip, country, phone_no),
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
			Report.StartStep(Report.Details.StepIndex + " - I open the Edit Address form");
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm the Sub Headings are correct");
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm the Edit Address form has the correct fields");
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				var myList = new List<string>();

				foreach (TableRow Row in table.Rows)
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
			Report.StartStep(Report.Details.StepIndex + " - I " + check + " the Shipping Adreess is the same as the billing address checkbox");
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm the Shipping Address form has the correct fields");
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				var myList = new List<string>();

				foreach (TableRow Row in table.Rows)
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm the Shipping Address is hidden");
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
			Report.StartStep(Report.Details.StepIndex + " - I cancel the Edit Address form");
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
			Report.StartStep(Report.Details.StepIndex + " - I edit the Primary Account Contact");
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				foreach (TableRow thisRow in table.Rows)
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
			Report.StartStep(Report.Details.StepIndex + " - I edit the Billing Address");
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				if (savedAs == "New_Sub")
				{
					if (Context.FeatureContext.ContainsKey("CurrentAccount"))
					{
						savedAs = Context.FeatureContext["CurrentAccount"].ToString();
					}
					Report.Info("Account = " + savedAs);
				}

				var wsUser = (WERCSmartUser)Context.GetFromContext(savedAs);
				foreach (TableRow thisRow in table.Rows)
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm the Continue Button is " + enabled);
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm the " + payMethod + " fields are correct");
			try
			{
				var myPay = new PaymentMethods();

				var myList = new List<string>();

				foreach (TableRow Row in table.Rows)
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm the Wire Transfer warning message appears");
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm the PayPal text message appears");
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm error messages for " + payMethod + " fields are correct");
			try
			{
				var myPay = new PaymentMethods();

				var myList = new List<string>();

				foreach (TableRow Row in table.Rows)
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
			Report.StartStep(Report.Details.StepIndex + " - In the Payment Methods screen I click Continue");
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
			Report.StartStep(Report.Details.StepIndex + " - In the Payment Methods screen I enter Credit Card details");
			try
			{
				var myPay = new PaymentMethods();

				foreach (TableRow thisRow in table.Rows)
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm the Purchase Summary header is displayed");
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
			Report.StartStep(Report.Details.StepIndex + " - I check the Subscription Billing header is correct");
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm the Yearly Radio Option is " + select);
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm the column headings are correct");
			try
			{
				var mySub = new PaymentMethods_Subscription_Billing();
				Delay.Seconds(5 * Delay.SpeedFactor);
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
			Report.StartStep(Report.Details.StepIndex + " - I confirm the folling statement is shown: " + statement);
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
			Report.StartStep(Report.Details.StepIndex + " - In the Purchase Summary screen I confirm the Prices and Payment section contains the correct text");
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
			Report.StartStep(Report.Details.StepIndex + " - In the Purchase Summary screen I confirm the following statement is shown: " + confirm_text);
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
			Report.StartStep(Report.Details.StepIndex + " - In the Purchase Summary screen I click Confirm Order");
			try
			{
				var mySub = new PaymentMethods_Subscription_Billing();
				for (int i = 0; i < 60; i++)
				{
					if (mySub.ConfirmOrderButtonExists())
					{
						break;
					}
					Delay.Seconds(1);
				}

				if (mySub.ConfirmOrderButtonExists())
				{
					Report.IsTrue(mySub.Confirm_Order_click(), "Failed to Click Confirm Order Button", "Confirm Order Button Clicked");
					GeneralUtilities.WaitForRefreshToDisappear(mySub._btn_confirm);
					GeneralUtilities.Wait_for_load_finish();
					Report.Screenshot();

				}
				else
				{
					Report.Error("Confirm order button does not exist");
					Report.Screenshot();
				}


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
			Report.StartStep(Report.Details.StepIndex + " - In the Thank You screen I check the Header is correct");
			try
			{
				var myPay = new PaymentMethods_Thank_You();
				Delay.Seconds(5 * Delay.SpeedFactor);
				GeneralUtilities.Wait_for_load_finish();
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
			Report.StartStep(Report.Details.StepIndex + " - In the Thank You screen I check the Confirmation statement is correct");
			try
			{
				var myPay = new PaymentMethods_Thank_You();

				Report.Info($"Thank You Text = '{ty_text}'");

				Report.IsTrue(myPay.Thank_You_TextExists(ty_text.Trim()), $"Displayed Text does not contain: '{ty_text}'",
					$"Displayed Text contains: '{ty_text}'");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Subscription Issue screen I confirm the following statement is shown: (.*)")]
		public void ThenInTheSubscriptionIssueScreenIConfirmTheFollowingStatementIsShownX(string si_text)
		{
			Report.StartStep(ReportSettings.StepCounter + " - In the Subscription Issue screen I check the Confirmation statement is correct");
			try
			{
				var myPay = new PaymentMethods_Thank_You();

				Report.Info("Subscription Issue Text = " + si_text);

				Report.IsTrue(myPay.Subscription_Issue_TextExists(si_text), $"Displayed Text does not contain: '{si_text}'",
					$"Displayed Text contains: '{si_text}'");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Purchase Summary page Confirm thank you message is shown if product details is not shown: (.*)")]
		public void ConfirmThankYouMessageIfProductDetailsNotPresent(string message)
		{
			var mySub = new PaymentMethods_Subscription_Billing();
			if (mySub.Product_Billing_Header_Displayed())
			{
				Report.StartStep(ReportSettings.StepCounter + " - If purchase details are showing click confirm order");
				Report.Info("The Product Billing section was displayed, so trying to click 'Confirm Order'");
				Report.IsTrue(mySub.Confirm_Order_click(), "Failed to Click Confirm Order Button", "Confirm Order Button Clicked");
				Delay.Seconds(10);
			}
			else
			{
				Report.StartStep(ReportSettings.StepCounter + " - In the Thank You screen I check the Confirmation statement is correct");
				try
				{
					var myPay = new PaymentMethods_Thank_You();

					Report.Info($"Thank You Text = {message}");
					Report.IsTrue(myPay.Thank_You_TextExists(message.Trim()), $"Displayed Text does not contain: '{message}'",
						$"Displayed Text contains: '{message}'");
				}
				catch (Exception ex)
				{
					Report.Failure(ex.Message);
					throw;
				}
			}
		}

		[StepDefinition(@"In the Thank You screen I click Home")]
		public void ThenInTheThankYouScreenIClickHome()
		{
			var myPay = new PaymentMethods_Thank_You();
			Report.IsTrue(myPay.Home_click(), "Failed to Click Home Button",
				"Home Button Clicked");

			Delay.Seconds(5 * Delay.SpeedFactor);

			var myHome = new StepsHomepage();

			myHome.ThenTheWercSmartHomepageShouldLoad();
		}


		[StepDefinition(@"the PayPal page should load")]
		public void ThenThePayPalPageShouldLoad()
		{
			var MyPP = new PaymentMethods_PayPal();
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
			SoftwareCredentialBasic user = TReVor.Integrations.Classes.TReVorSettings.Credentials.GetCredential(savedAs);
			this.GivenILogInWithEmailAndPassword(user.UserName, user.Password);
		}

		[StepDefinition(@"I log into PayPal with email: (.*) and password: (.*) and click Continue")]
		public void GivenILogInWithEmailAndPassword(string username, string password)
		{

			var selPaypal = new PaymentMethods_PayPal();
			Report.IsTrue(selPaypal.Wait_for_load(), "PayPal login page did not load!", "PayPal login page loaded successfully!");

			Report.Info("Entering Email: '" + username + "'");
			selPaypal.EmailField = username;
			selPaypal.Click_Next();

			Report.Info("Entering Password: '********'");
			selPaypal.PasswordField = password;

			Report.Info("Clicking login");
			selPaypal.Click_Login();

			Report.Info("Clicking AgreeAndContinue");
			var reviewPayPal = new PaymentMethods_PayPal_MemberReview();
			reviewPayPal.Click_AgreeAndContinue();
		}

		[StepDefinition(@"In the Payment Methods under Add a new Payment method I select: (.*)")]
		public void ThenISelectAddANewPaymentMethod(string payMethod)
		{
			var myPay = new PaymentMethods();
			Delay.Seconds(3 * Delay.SpeedFactor);
			Report.IsTrue(myPay.Add_A_New_Payment_Method(payMethod), "Failed to Select " + payMethod,
				"Successfully Selected " + payMethod);
			Delay.Seconds(3 * Delay.SpeedFactor);
		}

		[StepDefinition(@"In the Add new Credit card popup I click Save")]
		public void ThenIClickSave()
		{
			var myPay = new Add_Credit_Card_Popup();
			Delay.Seconds(2 * Delay.SpeedFactor);
			Report.IsTrue(myPay.Click_Save(), "Failed to Click Save", "Save Button Clicked");
			Delay.Seconds(10 * Delay.SpeedFactor);
		}

		[StepDefinition(@"I click on Make Default for user: (.*)")]
		public void GivenIClickOnMakeDefault(string user)
		{
			Report.IsTrue(new PaymentMethods().ClickMakeDefault(user), "Failed to click the make default",
				"Successfully clicked make default");
			GeneralUtilities.Wait_for_load_finish();
		}

		[StepDefinition(@"In the Purchase Summary screen I click Remove for product (.*)")]
		public void InThePurchaseSummaryScreenIClickRemove(string product)
		{
	
			var newProduct = new NewProduct();

			if (product.ToLower().Contains("saved as"))
			{
				object savedAsItem = Context.GetFromContext(product.Replace("saved as", "").Trim());
				if (savedAsItem.GetType() == typeof(string))
				{
					product = savedAsItem.ToString();
				}
				else
				{
					product = ((ProductInformation)savedAsItem).Id;
				}
			}

			Report.IsTrue(newProduct.PurchaseSummaryClickRemove(product), "Failed to click Remove for product '" + product + "'.",
				"Successfully clicked Remove for product '" + product + "'.");
		}

		[StepDefinition(@"I click on the 'Edit' button in Company information in the Billing Address section")]
		public void ThenIClickOnTheLinkInCompanyInformationInTheBillingAddressSection()
		{
			MyAccount MyAccountObject = new MyAccount();
			Report.IsTrue(MyAccountObject.ClickOnEditButtonInCompanyInformationPageInBillingAddressSection(), "Failed to click on 'Edit' button", "Successfully clicked 'Edit' button");
		}

		[StepDefinition(@"I select the state: (.*) in the Billing Address section")]
		public void ThenISelectAStateInTheBillingAddressSection(string state)
		{
			MyAccount_CompanyInfo MyAccount_CompanyInfoObject = new MyAccount_CompanyInfo();
			Report.IsTrue(MyAccount_CompanyInfoObject.SelectAStateAsAnOptionInCompanyInformationPageBillingAddressSection(state), "Failed to select state: " + state, "Successfully selected state: " + state);
		}

		[StepDefinition(@"I click the 'Save' button in the Billing Address section")]
		public void ThenIClickTheSaveButtonInTheBillingAddressSeciton()
		{
			MyAccount_CompanyInfo MyAccount_CompanyInfoObject = new MyAccount_CompanyInfo();
			Report.IsTrue(MyAccount_CompanyInfoObject.ClickSaveButtonInCompanyInformationPageBillingAddressSection(), "Failed to click on 'Save' button", "Successfully clicked 'Save' button");
		}

		[StepDefinition(@"I click on the 'Edit' button in Company information in the Shipping Address section")]
		public void ThenIClickOnTheLinkInCompanyInformationInTheShippingAddressSection()
		{
			MyAccount_CompanyInfo MyAccount_CompanyInfoObject = new MyAccount_CompanyInfo();
			Report.IsTrue(MyAccount_CompanyInfoObject.ClickEditButtonAsAnOptionInCompanyInformationPageShippingAddressSection(), "Failed to click on 'Edit' button", "Successfully clicked 'Edit' button");
		}

		[StepDefinition(@"I select the state: (.*) in the Shipping Address section")]
		public void ThenISelectAStateInTheShippingAddressSection(string state)
		{
			MyAccount_CompanyInfo MyAccount_CompanyInfoObject = new MyAccount_CompanyInfo();
			Report.IsTrue(MyAccount_CompanyInfoObject.SelectAStateAsAnOptionInCompanyInformationPageShippingAddressSection(state), "Failed to select state: " + state, "Successfully selected state: " + state);
		}

		[StepDefinition(@"I click the 'Save' button in the Shipping Address section")]
		public void ThenIClickTheSaveButtonInTheShippingAddressSeciton()
		{
			MyAccount_CompanyInfo MyAccount_CompanyInfoObject = new MyAccount_CompanyInfo();
			Report.IsTrue(MyAccount_CompanyInfoObject.ClickSaveButtonAsAnOptionInCompanyInformationPageShippingAddressSection(), "Failed to click on 'Save' button", "Successfully clicked 'Save' button");
		}

		[StepDefinition(@"I confirm that the correct state: (.*) has been saved in the Billing Address")]
		public void ThenIConfirmThatTheCorrectStateHasBeenSavedInTheBillingAddress(string stateName)
		{
			MyAccount_CompanyInfo MyAccount_CompanyInfoObject = new MyAccount_CompanyInfo();
			Report.IsTrue(MyAccount_CompanyInfoObject.FindStateWithNameInBillingAddressSection(stateName), "The state was not confirmed", "The state was confirmed");
		}

		[StepDefinition(@"I confirm that the correct state: (.*) has been saved in the Shipping Address")]
		public void ThenIConfirmThatTheCorrectStateHasBeenSavedInTheShippingAddress(string stateName)
		{
			MyAccount_CompanyInfo MyAccount_CompanyInfoObject = new MyAccount_CompanyInfo();
			Report.IsTrue(MyAccount_CompanyInfoObject.FindStateWithNameInShippingAddressSection(stateName), "The state was not confirmed", "The state was confirmed");
		}

		[StepDefinition(@"In the Account Name field, change the name of the Company (.*) and Confirm the Contact Information is updated with the New Company Name")]
		public void ThenIChangeAndConfirmTheNameOfTheCompany(string companyName)
		{
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				Report.IsTrue(myPay.ConfirmCompanyName(companyName),
						"I Confirm the Contact Information is not updated with the New Company Name", "I Confirm the Contact Information is updated with the New Company Name");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I click the back arrow next to payment methods")]
		public void GivenIClickTheBackArrowNextToPaymentMethods()
		{
			Report.IsTrue(new PaymentMethods().ClickBackButton(), "Failed to click the back arrow",
				"Successfully clicked the back arrow");
		}

		[StepDefinition(@"In the payment methods page I confirm that the Contact Information account name: (.*), firstname: (.*),last name: (.*), email addresss: (.*) appear correct")]
		public void IConfirmContactInformationAppear(string account_name, string first_name, string last_name, string email_address)
		{
			try
			{
				var myPay = new PaymentMethods();
				GeneralUtilities.Wait_for_load_finish();
				Report.IsTrue(myPay.Confirm_Contact_Info(account_name, first_name, last_name, email_address),
					"Contact Information Incorrect", "Confirmed Contact Information");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the payment methods page I confirm that the Billing Address address one: (.*), address two: (.*), cityStateZip: (.*), country: (.*), phoneNo: (.*) appear correct")]
		public void IConfirmBillingAddressAppear(string address_one, string address_two, string city_state_zip, string country, string phone_no)
		{
			try
			{
				var myPay = new PaymentMethods();
				Report.IsTrue(myPay.Confirm_Billing_Address(address_one, address_two, city_state_zip, country, phone_no),
					"Billing Address Incorrect", "Confirmed Billing Address");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the company information page I confirm that the Address (.*) for: action_menu: (.*) country: (.*) address one: (.*), address two: (.*), city: (.*), State: (.*), Zip: (.*), phoneNo: (.*), saveAddressOption: (.*) updated correctly")]
		public void IConfirmUpdateContactInformation(string action, string action_menu, string country, string address1, string address2, string city, string state, string zip, string phone, string saveOption)
		{
			try
			{
				Report.Info("Editing the contact address Information");
				var myInfo = new ContactInformation_Edit_Address();
				myInfo.ClickEditAction(action);
				Delay.Seconds(2 * Delay.SpeedFactor);
				myInfo.Edit_Country_Address(action, country);
				myInfo.Edit_Address_One(action, address1);
				myInfo.Edit_Address_Two(action, address2);
				myInfo.Edit_City_Address(action, city);
				myInfo.Edit_State_Address(action, state);
				myInfo.Edit_Zip_Address(action, zip);
				myInfo.Edit_Phone_Number(action, phone);

				Report.Info("Saving the contact information");
				myInfo.Save_click(saveOption);
				Delay.Seconds(5 * Delay.SpeedFactor);

				Report.Info("Making sure that the Contact information edited successfully");
				Report.IsTrue(myInfo.Confirm_Country_AddressAppear(action_menu, country), $"{ action_menu} country Incorrect", $"Confirmed editing {action_menu} country");
				Report.IsTrue(myInfo.Confirm_addressOne_AddressAppear(action_menu, address1), $"{ action_menu} address one Incorrect", $"Confirmed editing {action_menu} one");
				Report.IsTrue(myInfo.Confirm_addressTwo_AddressAppear(action_menu, address2), $"{ action_menu} address two Incorrect", $"Confirmed editing {action_menu} two");
				Report.IsTrue(myInfo.Confirm_City_AddressAppear(action_menu, city), $"{ action_menu} city Incorrect", $"Confirmed editing {action_menu} city");
				Report.IsTrue(myInfo.Confirm_State_AddressAppear(action_menu, state), $"{ action_menu} state Incorrect", $"Confirmed editing {action_menu} state");
				Report.IsTrue(myInfo.Confirm_Zip_Code_AddressAppear(action_menu, zip), $"{ action_menu} zip code Incorrect", $"Confirmed editing {action_menu} zip code");
				Report.IsTrue(myInfo.Confirm_PhoneNo_AddressAppear(action_menu, phone), $"{ action_menu} phone number Incorrect", $"Confirmed editing {action_menu} phone number");				
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
		
		[StepDefinition(@"In the Purchase Summary screen I Confirm that for Billing Frequency I see following: yearly: (.*), quarterly: (.*), monthly: (.*) options")]
		public void ThenIConfirmTheBillingFrequencyRadioButtons(string yearly, string quarterly, string monthly)
		{
			try
			{
				Delay.Seconds(2 * Delay.SpeedFactor);
				var mySub = new PaymentMethods_Subscription_Billing();
				mySub.Billing_frequency_options(yearly, quarterly, monthly);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"In the Purchase Summary screen I Confirm that for Billing Frequency I see Yearly label")]
		public void ThenIConfirmYearlyLabel()
		{
			try
			{
				Delay.Seconds(2 * Delay.SpeedFactor);
				var mySub = new PaymentMethods_Subscription_Billing();

				Report.IsTrue(mySub.Billing_frequency_YearlyLabel(), "Cannot see Yearly label", "Can see Yearly label");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I Click on the back arrow in Payment methods")]
		public void ThenIClickOnTheBackArrow()
		{
			Report.StartStep(Report.Details.StepIndex + " - Click on the back arrow next to ");
			try
			{
				var myPay = new PaymentMethods();
				Delay.Seconds(2 * Delay.SpeedFactor);
				Report.IsTrue(myPay.Continue_back_arrow(), "Failed to Click Back Arrow", "Back Arrow Clicked");
				Delay.Seconds(15 * Delay.SpeedFactor);
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}
	}
}
