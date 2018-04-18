using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SafewareReporting;
using SeleniumUtilities;
using Wercs.Selenium.PortalUX.Classes;
using Global = SeleniumUtilities.Global;

namespace Wercs.Selenium.PortalUX.Selenium_Classes
{
	class PaymentMethods : BaseDialog
	{
		[FindsBy(How = How.Id, Using = "paymentMethodsContainer")]
		protected override IWebElement containerElement { get; set; }

		public bool Payment_Header_Correct()
		{
			Report.Info("Beginning Header_Correct");

			IWebElement myHeader = containerElement
				.FindElements(By.XPath(".//div[@class='header-with-back']/h2[text()='Payment Methods']"), 10).FirstOrDefault();

			if (myHeader == null)
			{
				Report.Info("Failed to Find Header Text");
				Report.Screenshot();
				return false;
			}
			if (!myHeader.Displayed)
			{
				Report.Info("Incorrect Page Open");
				Report.Screenshot();
				return false;
			}
			Report.Success("Correct Page Opened");
			return true;
		}

		public bool Sub_Heading_Correct()
		{
			Report.Info("Beginning Sub_Heading_Correct");

			IWebElement myHeader = containerElement
				.FindElements(By.XPath(".//div[@class='main-wrapper has-title payment-methods']/h2[text()='Select your payment method']"), 10).FirstOrDefault();

			if (myHeader == null)
			{
				Report.Info("Failed to Find Sub Header Text");
				Report.Screenshot();
				return false;
			}
			if (!myHeader.Displayed)
			{
				Report.Info("Incorrect Sub Header");
				Report.Screenshot();
				return false;
			}
			Report.Success("Correct Sub Heading");
			return true;

		}

		public bool Select_Payment_Method(string payment_method)
		{
			Report.Info("Beginning Select_Payment_Method: " + payment_method);

			List<IWebElement> allProducts = containerElement.FindElements(By.XPath(".//div[@class='col-sm-3']/a/div")).ToList();

			foreach (var method in allProducts)
			{
				Report.Info("Payment Method = " + method.Text);

				if (method.Text == payment_method)
				{
					Report.Success("Payment Method Found");
					method.Click();
					return true;
				}
				Report.Info("Payment Method Doesn't Match");
			}
			Report.Info("Failed to Find Payment Method");
			return false;
		}

		public bool Payment_Method_Exists(string payment_method)
		{
			Report.Info("Beginning Payment_Method_Exists: " + payment_method);

			List<IWebElement> allProducts = containerElement.FindElements(By.XPath(".//div[@class='col-sm-3']/a/div")).ToList();

			foreach (var method in allProducts)
			{
				Report.Info("Payment Method = " + method.Text);

				if (method.Text == payment_method)
				{
					Report.Success("Payment Method Found");
					return true;
				}
				Report.Info("Payment Method Doesn't Match");
			}
			Report.Info("Failed to Find Payment Method");
			return false;
		}

		//Formulated Products
		[FindsBy(How = How.XPath, Using = ".//div[@class='col-sm-2 address-panel']")]
		private IWebElement _tbl_addresses;

		public string Get_Contact_Info()
		{
			Report.Info("Beginning Get_Contact_Info");

			IWebElement myContact = _tbl_addresses.FindElements(By.XPath("div[1]/div"), 10).FirstOrDefault();

			if (myContact == null)
			{
				Report.Info("Failed to Find Contact Information");
				Report.Screenshot();
				return "";
			}
			Report.Info("Contact Information Found");
			return myContact.Text;
		}

		public bool Confirm_Contact_Info(string company_name, string first_name, string last_name, string email_address)
		{
			Report.Info("Beginning Confirm_Contact_Info");

			string myInfo = Get_Contact_Info();

			if (!myInfo.Contains(company_name))
			{
				Report.Info("Company Name Incorrect: " + company_name);
				Report.Screenshot();
				return false;
			}
			Report.Info("Company Name Correct: " + company_name);
			if (!myInfo.Contains(first_name))
			{
				Report.Info("First Name Incorrect: " + first_name);
				Report.Screenshot();
				return false;
			}
			Report.Info("First Name Correct: " + first_name);
			if (!myInfo.Contains(last_name))
			{
				Report.Info("Last Name Incorrect: " + last_name);
				Report.Screenshot();
				return false;
			}
			Report.Info("Last Name Correct: " + last_name);
			if (!myInfo.Contains(email_address))
			{
				Report.Info("Email Address Incorrect: " + email_address);
				Report.Screenshot();
				return false;
			}
			Report.Info("Email Address Correct: " + email_address);

			Report.Info("Contact Information Correct");
			return true;
		}


		public string Get_Billing_Address()
		{
			Report.Info("Beginning Get_Billing_Address");

			IWebElement myBill = containerElement.FindElements(By.XPath(".//div/h3[text()='Billing Address']"), 10).FirstOrDefault();

			IWebElement myAddress = myBill.FindElements(By.XPath("../div"), 10).FirstOrDefault();

			if (myAddress == null)
			{
				Report.Info("Failed to Find Billing Address");
				Report.Screenshot();
				return "";
			}
			Report.Info("Billing Address Found");
			return myAddress.Text;
		}

		public bool Confirm_Billing_Address(string address_one, string address_two, string city, string state_code, string zip_code, string country, string phone_no)
		{
			Report.Info("Beginning Confirm_Billing_Address");

			string myInfo = Get_Billing_Address();

			if (!myInfo.Contains(address_one))
			{
				Report.Info("Address One Incorrect: " + address_one);
				Report.Screenshot();
				return false;
			}
			Report.Info("Address One Correct: " + address_one);
			if (!myInfo.Contains(address_two))
			{
				Report.Info("Address Two Incorrect: " + address_two);
				Report.Screenshot();
				return false;
			}
			Report.Info("Address Two Correct: " + address_two);
			if (!myInfo.Contains(city))
			{
				Report.Info("City Incorrect: " + city);
				Report.Screenshot();
				return false;
			}
			Report.Info("City Correct: " + city);
			if (!myInfo.Contains(state_code))
			{
				Report.Info("State Code Incorrect: " + state_code);
				Report.Screenshot();
				return false;
			}
			Report.Info("State Code Correct: " + state_code);
			if (!myInfo.Contains(zip_code))
			{
				Report.Info("Zip Code Incorrect: " + zip_code);
				Report.Screenshot();
				return false;
			}
			Report.Info("Zip Code Correct: " + zip_code);
			if (!myInfo.Contains(country))
			{
				Report.Info("Country Incorrect: " + country);
				Report.Screenshot();
				return false;
			}
			Report.Info("Country Correct: " + country);
			Report.Info("Zip Code Correct: " + zip_code);
			if (!myInfo.Contains(phone_no))
			{
				Report.Info("Phone Number Incorrect: " + phone_no);
				Report.Screenshot();
				return false;
			}
			Report.Info("Phone Number Correct: " + phone_no);

			Report.Info("Billing Address is Correct");
			Report.Screenshot();
			return true;
		}

		//Continue Button
		[FindsBy(How = How.Id, Using = "continueButton")]
		private IWebElement _btnContinue;

		public bool Continue_click()
		{
			Report.Info("Attempting to Click Continue Button");
			_btnContinue.Click();
			return true;
		}

		//Change Button
		[FindsBy(How = How.XPath, Using = ".//div/a[text()='Change']")]
		private IWebElement _btnChange;

		public bool Change_click()
		{
			Report.Info("Attempting to Click Change Button");
			_btnChange.Click();
			return true;
		}




	}

	class PaymentMethods_Edit_Address : BaseDialog
	{
		[FindsBy(How = How.Id, Using = "editAddressDetails")]
		protected override IWebElement containerElement { get; set; }

		public bool Sub_Headings_Correct(string sub_1, string sub_2)
		{
			Report.Info("Beginning Sub_Headings_Correct");

			if (!Exists)
			{
				Report.Info("Failed to Open Edit Address Form");
				Report.Screenshot();
				return false;
			}
			Report.Info("Edit Address Form Open");

			IWebElement myH1 = containerElement.FindElements(By.XPath(".//div/h4[text()='" + sub_1 + "']"), 10).FirstOrDefault();

			if (myH1 == null)
			{
				Report.Info("Failed to Find Header with Text: " + sub_1);
				Report.Screenshot();
				return false;
			}
			Report.Success("Header with Text: " + sub_1 + " Found");

			IWebElement myH2 = containerElement.FindElements(By.XPath(".//div/h4[text()='" + sub_2 + "']"), 10).FirstOrDefault();

			if (myH2 == null)
			{
				Report.Info("Failed to Find Header with Text: " + sub_2);
				Report.Screenshot();
				return false;
			}
			Report.Success("Header with Text: " + sub_2 + " Found");

			Report.Success("Sub Headers are Correct");
			Report.Screenshot();
			return true;
		}

		//===================================================================================================== PRIMARY ACCOUNT CONTACT

		//Primary Account Contact Section
		[FindsBy(How = How.XPath, Using = ".//div/h4[text()='Primary Account Contact']/..")]
		private IWebElement _section_pac;

		public bool Edit_Primary_Account_Contact(string firstName = "", string lastName = "", string email = "")
		{
			Report.Info("Beginning Edit_Primary_Account_Contact");

			if (!Exists)
			{
				Report.Info("Not on Edit Address Form");
				Report.Screenshot();
				return false;
			}
			Report.Info("Edit Address Form Open");
			if (firstName != "")
			{
				IWebElement myFirst = _section_pac.FindElements(By.XPath(".//input[@name='firstName']"), 10).FirstOrDefault();
				if (myFirst == null)
				{
					Report.Info("Failed to Find First Name Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing First Name: " + firstName);
				myFirst.EnterText(firstName);
			}
			if (lastName != "")
			{
				IWebElement myLast = _section_pac.FindElements(By.XPath(".//input[@name='lastName']"), 10).FirstOrDefault();
				if (myLast == null)
				{
					Report.Info("Failed to Find Last Name Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Last Name: " + lastName);
				myLast.EnterText(lastName);
			}
			if (email != "")
			{
				IWebElement myEmail = _section_pac.FindElements(By.XPath(".//input[@name='email']"), 10).FirstOrDefault();
				if (myEmail == null)
				{
					Report.Info("Failed to Find Email Address Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Email Address: " + email);
				myEmail.EnterText(email);
			}
			Delay.Seconds(1 * Delay.SpeedFactor);
			Report.Success("Primary Account Contact Edited");
			Report.Screenshot();
			return true;
		}


		//================================================================================================= BILLING ADDRESS

		//Billing Address Section
		[FindsBy(How = How.XPath, Using = ".//div/h4[text()='Billing Address']/..")]
		private IWebElement _section_bill;

		public bool Billing_Headers_Check(List<string> myList)
		{
			Report.Info("Beginning Billing_Headers_Check");

			Delay.Seconds(3 * Delay.SpeedFactor);

			if (!Exists)
			{
				Report.Info("Not on Edit Address Form");
				Report.Screenshot();
				return false;
			}

			IWebElement myFieldHeader = null;

			foreach (var field in myList)
			{
				Report.Info("Field = " + field);
				switch (field)
				{
					case "First Name":
						myFieldHeader = _section_pac.FindElements(By.XPath(".//label[text()='First Name']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Last Name":
						myFieldHeader = _section_pac.FindElements(By.XPath(".//label[text()='Last Name']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Email Address":
						myFieldHeader = _section_pac.FindElements(By.XPath(".//label[text()='Email Address']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Address 1":
						myFieldHeader = _section_bill.FindElements(By.XPath(".//label[text()='Address Line 1']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Address 2":
						myFieldHeader = _section_bill.FindElements(By.XPath(".//label[text()='Address Line 2']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "City":
						myFieldHeader = _section_bill.FindElements(By.XPath(".//label[text()='City']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "State":
						myFieldHeader = _section_bill.FindElements(By.XPath(".//label[text()='State']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Zip Code":
						myFieldHeader = _section_bill.FindElements(By.XPath(".//label[text()='Zip']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Country":
						myFieldHeader = _section_bill.FindElements(By.XPath(".//label[text()='Country']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Phone Number":
						myFieldHeader = _section_bill.FindElements(By.XPath(".//label[text()='Phone']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Shipping/Billing Checkbox":
						myFieldHeader = containerElement.FindElements(By.XPath(".//div[@class='checkbox']/label"), 10).FirstOrDefault();
						if (myFieldHeader.Text.Trim() != "Shipping Address is the same as billing address")
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					default:
						Report.Error("Unable to Find Correct Field Name");
						return false;
				}
			}
			Report.Info("Edit Address Fields are Correct");
			Report.Screenshot();
			return true;
		}

		//============================================================================= FIELDS

		public bool Edit_Billing_Address(string address1 = "", string address2 = "", string city = "", string state = "", string zip = "", string country = "", string phone = "")
		{
			Report.Info("Beginning Edit_Billing_Address");

			var myPay = new PaymentMethods();

			if (!myPay.Change_click())
			{
				Report.Info("Failed to Click Change Button");
				Report.Screenshot();
				return false;
			}
			Delay.Seconds(2 * Delay.SpeedFactor);
			if (!Exists)
			{
				Report.Info("Not on Edit Address Form");
				Report.Screenshot();
				return false;
			}
			Report.Info("Edit Address Form Open");
			if (address1 != "")
			{
				IWebElement myAdd1 = _section_bill.FindElements(By.XPath(".//input[@name='address1']"), 10).FirstOrDefault();
				if (myAdd1 == null)
				{
					Report.Info("Failed to Find Address Line 1 Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Address Line 1: " + address1);
				myAdd1.EnterText(address1);
			}
			if (address2 != "")
			{
				IWebElement myAdd2 = _section_bill.FindElements(By.XPath(".//input[@name='address2']"), 10).FirstOrDefault();
				if (myAdd2 == null)
				{
					Report.Info("Failed to Find Address Line 2 Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Address Line 2: " + address2);
				myAdd2.EnterText(address2);
			}
			if (city != "")
			{
				IWebElement myCity = _section_bill.FindElements(By.XPath(".//input[@name='city']"), 10).FirstOrDefault();
				if (myCity == null)
				{
					Report.Info("Failed to Find City Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing City: " + city);
				myCity.EnterText(city);
			}
			if (state != "")
			{
				IWebElement myState = _section_bill.FindElements(By.XPath(".//input[@name='state']"), 10).FirstOrDefault();
				if (myState == null)
				{
					Report.Info("Failed to Find State Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing State: " + state);
				myState.EnterText(state);
			}
			if (state != "")
			{
				IWebElement myState = _section_bill.FindElements(By.XPath(".//input[@name='state']"), 10).FirstOrDefault();
				if (myState == null)
				{
					Report.Info("Failed to Find State Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing State: " + state);
				myState.EnterText(state);
			}
			if (zip != "")
			{
				IWebElement myZip = _section_bill.FindElements(By.XPath(".//input[@name='zip']"), 10).FirstOrDefault();
				if (myZip == null)
				{
					Report.Info("Failed to Find Zip Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Zip Code: " + zip);
				myZip.EnterText(zip);
			}
			if (country != "")
			{
				IWebElement myCountry = _section_bill.FindElements(By.XPath(".//input[@name='country']"), 10).FirstOrDefault();
				if (myCountry == null)
				{
					Report.Info("Failed to Find Zip Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Zip Code: " + country);
				myCountry.Select(country);
			}
			if (phone != "")
			{
				IWebElement myPhone = _section_bill.FindElements(By.XPath(".//input[@name='phone']"), 10).FirstOrDefault();
				if (myPhone == null)
				{
					Report.Info("Failed to Find Phone Text Box");
					Report.Screenshot();
					return false;
				}
				Report.Info("Editing Phone Number: " + phone);
				myPhone.EnterText(phone);
			}
			Delay.Seconds(1 * Delay.SpeedFactor);
			Report.Success("Billing Address Edited");
			Report.Screenshot();
			return true;
		}

		//Shipping Address is the same as billing address
		[FindsBy(How = How.XPath, Using = ".//div[@class='checkbox']/label/input")]
		private IWebElement _chk_same;

		public bool Shipp_Same_As_Bill_Check(bool bEnable)
		{
			Report.Info("Shipping Address is the same as Billing Address - " + bEnable);
			_chk_same.Check(bEnable);
			return true;
		}

		//Cancel Button
		[FindsBy(How = How.XPath, Using = ".//button[@class='btn btn-danger']")]
		private IWebElement _btnCancel;

		public bool Cancel_click()
		{
			Report.Info("Attempting to Click Cancel Button");
			_btnCancel.Click();
			return true;
		}

		//Save Button
		[FindsBy(How = How.Id, Using = "SaveAddress")]
		private IWebElement _btnSave;

		public bool Save_click()
		{
			Report.Info("Attempting to Click Save Button");
			_btnSave.Click();
			return true;
		}


		//==================================================================================== SHIPPING ADDRESS

		//Shipping Address Section
		[FindsBy(How = How.XPath, Using = ".//div/h4[text()='Shipping Address']/..")]
		private IWebElement _section_ship;

		public bool Shipping_Headers_Check(List<string> myList)
		{
			Report.Info("Beginning Shipping_Headers_Check");

			Delay.Seconds(3 * Delay.SpeedFactor);

			if (!Exists)
			{
				Report.Info("Not on Edit Address Form");
				Report.Screenshot();
				return false;
			}

			IWebElement myFieldHeader = null;

			foreach (var field in myList)
			{
				Report.Info("Field = " + field);
				switch (field)
				{
					case "Address 1":
						myFieldHeader = _section_ship.FindElements(By.XPath(".//label[text()='Address Line 1']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Address 2":
						myFieldHeader = _section_ship.FindElements(By.XPath(".//label[text()='Address Line 2']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "City":
						myFieldHeader = _section_ship.FindElements(By.XPath(".//label[text()='City']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "State":
						myFieldHeader = _section_ship.FindElements(By.XPath(".//label[text()='State']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Zip Code":
						myFieldHeader = _section_ship.FindElements(By.XPath(".//label[text()='Zip']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Country":
						myFieldHeader = _section_ship.FindElements(By.XPath(".//label[text()='Country']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					case "Phone Number":
						myFieldHeader = _section_ship.FindElements(By.XPath(".//label[text()='Phone']"), 10).FirstOrDefault();
						if (!myFieldHeader.Displayed)
						{
							Report.Info(field + " Field Not Displayed");
							Report.Screenshot();
							return false;
						}

						Report.Success(field + " Field Displayed");
						break;
					default:
						Report.Error("Unable to Find Correct Field Name");
						return false;
				}
			}
			Report.Info("Shipping Address Fields are Correct");
			Report.Screenshot();
			return true;
		}

		public bool Shipping_Address_Hidden()
		{
			Report.Info("Shipping_Address_Hidden");

			if (_section_ship.Displayed)
			{
				Report.Info("Shipping Address Not Hidden");
				Report.Screenshot();
				return false;
			}
			Report.Success("Shipping Address Hidden");
			Report.Screenshot();
			return true;
		}


	}




}
