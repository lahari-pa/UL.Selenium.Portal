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

		[StepDefinition(@"I check the Payment Methods heading and sub headings are correct")]
		public void ThenICheckThePaymentMethodsHeadingAndSubHeadingsAreCorrect()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I check the Payment Methods heading and sub headings are correct");
			try
			{
				var myPay = new PaymentMethods();
				Delay.Seconds(5 * Delay.SpeedFactor);
				Report.IsTrue(myPay.Payment_Header_Correct(), "Payment Methods Header is Incorrect",
					"Payments Methods Header is Correct");
				Report.IsTrue(myPay.Sub_Heading_Correct(), "Payments Methods Sub Heading is Incorrect",
					"Payments Methods Sub Heading is Correct");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm the following payment options are available")]
		public void ThenIConfirmTheFollowingPaymentOptionsAreAvailable(Table table)
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I confirm the correct payment options are available");
			try
			{
				var myPay = new PaymentMethods();

				foreach (var Row in table.Rows)
				{
					Report.IsTrue(myPay.Payment_Method_Exists(Row["Options"]), Row["Options"] + " Is Not Available", Row["Options"] + " Available");
				}
				Report.Success("Payment Options are all Available");
			}
			catch (Exception ex)
			{
				Report.Failure(ex.Message);
				throw;
			}
		}

		[StepDefinition(@"I confirm that the Contact Information is correct for Account saved as (.*)")]
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

		[StepDefinition(@"I confirm that the Billing Address is correct for Account saved as (.*)")]
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

		[StepDefinition(@"I open the Edit Address form")]
		public void ThenIOpenTheEditAddressForm()
		{
			TestReport.BeginTestModule(GlobalParameters.StepCount + " - I open the Edit Address form");
			try
			{
				var myPay = new PaymentMethods();

				Report.IsTrue(myPay.Change_click(), "Failed to Click Change Button", "Change Button Clicked");

				Delay.Seconds(2 * Delay.SpeedFactor);

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
			TestReport.BeginTestModule(GlobalParameters.StepCount + " I confirm the Edit Address form has the correct fields");
			try
			{
				var myPay = new PaymentMethods_Edit_Address();

				List<string> myList = new List<string>();

				foreach (var Row in table.Rows)
				{
					myList.Add(Row["Field"]);
				}

				if (!myPay.Field_Headers_Check(myList))
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





	}
}
